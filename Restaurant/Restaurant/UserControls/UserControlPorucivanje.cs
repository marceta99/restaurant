
using Domain;
using Restaurant.ServerCommunication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.UserControls
{
    public partial class UserControlPorucivanje : UserControl
    {
        private List<Sto> _stolovi;
        private Porudzbina _novaPorudzbina;
        private BindingList<NarucenaStavka> _naruceneStavke;
        private int _prvaNarudzbina = 1; 
        public UserControlPorucivanje()
        {
            InitializeComponent();

            _stolovi = StoloviKojiSuSlobodni();
            
            comboBoxSto.DataSource = _stolovi; 
            comboBoxKategorija.DataSource = Communication.Instance.VratiSveKategorije();
            comboBoxBrojPorcija.DataSource = new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20};

            _novaPorudzbina = new Porudzbina
            {
                Datum = DateTime.Now,
                NaruceneStavke = new List<NarucenaStavka>()
            };

            

        }
        private List<Sto> StoloviKojiSuSlobodni()
        {
            List<Sto> listaSvihStolova = Communication.Instance.VratiSveStolove();
            List<Sto> listaNerezervisanih = new List<Sto>();
            foreach(var sto in listaSvihStolova)
            {
                if (!Communication.Instance.DaLiJeRezervisan(sto))
                {
                    listaNerezervisanih.Add(sto);
                }
            }
            return listaNerezervisanih;

        }

        private void comboBoxKategorija_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kategorija k = (Kategorija)comboBoxKategorija.SelectedItem;
            List<StavkaCenovnika> stavkeIzKategorije = Communication.Instance.VratiSveStavkeIzKategorije(k);

            comboBoxStavkaMenija.DataSource = stavkeIzKategorije;
        }

        private void buttonDodajStavkuUPorudzbinu_Click(object sender, EventArgs e)
        {
            int brojStola;
            Boolean izabranSto = int.TryParse(comboBoxSto.SelectedItem?.ToString(), out brojStola);

            if (!izabranSto)
            {
                MessageBox.Show("nisu svi podaci izabrani");
                return;
            }

            double cenaStavke;

            Sto sto =(Sto)comboBoxSto.SelectedItem;
            sto.Rezervisan = true;
            
            StavkaCenovnika stavka = (StavkaCenovnika)comboBoxStavkaMenija.SelectedItem;
            int brojPorcija = (int)comboBoxBrojPorcija.SelectedItem;

            NarucenaStavka narucenaStavka = new NarucenaStavka();
            narucenaStavka.BrojNarucenihPorcija = brojPorcija;
            narucenaStavka.StavkaCenovnika = stavka;

            cenaStavke = stavka.CenaStavkeSaPDV * brojPorcija;
            _novaPorudzbina.UkupnaVrednost += cenaStavke;
            labelUkupnaCena.Text = _novaPorudzbina.UkupnaVrednost.ToString();

            if (_prvaNarudzbina == 1)
            {
                _novaPorudzbina.Sto = sto; //samo u prvom slucaju bira sto jer posle sve 
                _prvaNarudzbina++;  //narucene stavke u jednoj narudzbini ce biti sa tog  istog stola
                comboBoxSto.Enabled = false;
                buttonSacuvajPorudzbinu.Enabled = true;
                Communication.Instance.RezervisiSto(sto);
            }

            foreach(var ranijeNarucenaStavka in _novaPorudzbina.NaruceneStavke) { 
                if(ranijeNarucenaStavka.StavkaCenovnika == narucenaStavka.StavkaCenovnika)
                {
                    ranijeNarucenaStavka.BrojNarucenihPorcija += narucenaStavka.BrojNarucenihPorcija;
                    

                    RefresujVrednostiUdataGridView();

                    return;
                }
            }

            _novaPorudzbina.NaruceneStavke.Add(narucenaStavka);


            RefresujVrednostiUdataGridView();
        }

        private void buttonIzbrisiIzabranuStavku_Click(object sender, EventArgs e)
        {
            if (dataGridViewStavkeUPorudzbini.SelectedRows.Count == 0)
            {
                MessageBox.Show("niste izabrali nijedanu stavku");
                return;
            }
            NarucenaStavka stavka = (NarucenaStavka)dataGridViewStavkeUPorudzbini.SelectedRows[0].DataBoundItem;

            double ukupnaCenaNaruceneStavkeKojuBrisemo = stavka.BrojNarucenihPorcija * stavka.StavkaCenovnika.CenaStavkeSaPDV;
            _novaPorudzbina.UkupnaVrednost -= ukupnaCenaNaruceneStavkeKojuBrisemo;
            labelUkupnaCena.Text = _novaPorudzbina.UkupnaVrednost.ToString();

            _novaPorudzbina.NaruceneStavke.Remove(stavka);
            

            MessageBox.Show("Obrisali ste stavku");

            RefresujVrednostiUdataGridView();
        }
        private void RefresujVrednostiUdataGridView()
        {
            _naruceneStavke = new BindingList<NarucenaStavka>(_novaPorudzbina.NaruceneStavke);
            dataGridViewStavkeUPorudzbini.DataSource = _naruceneStavke;
        }

        private void buttonSacuvajPorudzbinu_Click(object sender, EventArgs e)
        {
            Communication.Instance.DodajNovuPorudzbinu(_novaPorudzbina);

            _novaPorudzbina.Sto.Rezervisan = true;
            Communication.Instance.RezervisiSto(_novaPorudzbina.Sto);
            _stolovi = StoloviKojiSuSlobodni();
            comboBoxSto.DataSource = _stolovi;


            MessageBox.Show("Uspesno ste sacuvali porudzbinu");
            buttonSacuvajPorudzbinu.Enabled = false;
            comboBoxSto.Enabled = true;
            _prvaNarudzbina = 1;
            labelUkupnaCena.Text = "0.00"; 

            _naruceneStavke = new BindingList<NarucenaStavka>();
            dataGridViewStavkeUPorudzbini.DataSource = _naruceneStavke;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (dataGridViewStavkeUPorudzbini.SelectedRows.Count == 0)
            {
                MessageBox.Show("niste izabrali nijedanu stavku");
                return;
            }
            NarucenaStavka stavka = (NarucenaStavka)dataGridViewStavkeUPorudzbini.SelectedRows[0].DataBoundItem;

            foreach (var ranijeNarucenaStavka in _novaPorudzbina.NaruceneStavke)
            {
                if (ranijeNarucenaStavka.StavkaCenovnika == stavka.StavkaCenovnika)
                {
                    ranijeNarucenaStavka.BrojNarucenihPorcija--;
                    _novaPorudzbina.UkupnaVrednost -= ranijeNarucenaStavka.StavkaCenovnika.CenaStavkeSaPDV;
                    labelUkupnaCena.Text = _novaPorudzbina.UkupnaVrednost.ToString();

                    if (ranijeNarucenaStavka.BrojNarucenihPorcija == 0)
                    {
                        buttonIzbrisiIzabranuStavku_Click(sender, e);
                        RefresujVrednostiUdataGridView();
                        return;
                    }
                    RefresujVrednostiUdataGridView();

                }
            }

        }
    }
}
