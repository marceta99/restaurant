using Domain;
using Restaurant.ServerCommunication;
using Restaurant.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.GuiControllers
{
    public class ControllerPorucivanje
    {
        private UserControlPorucivanje userControlPorucivanje;
        private List<Sto> _stolovi;
        private Porudzbina _novaPorudzbina;
        private BindingList<NarucenaStavka> _naruceneStavke;
        private int _prvaNarudzbina = 1;
        public ControllerPorucivanje(UserControlPorucivanje userControlPorucivanje)
        {
            this.userControlPorucivanje = userControlPorucivanje;
        }

        internal void initData()
        {
            _stolovi = StoloviKojiSuSlobodni();

            userControlPorucivanje.ComboBoxSto.DataSource = _stolovi;
            userControlPorucivanje.ComboBoxKategorija.DataSource = Communication.Instance.VratiSveKategorije();
            userControlPorucivanje.ComboBoxBrojPorcija.DataSource = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

            _novaPorudzbina = new Porudzbina
            {
                Datum = DateTime.Now,
                NaruceneStavke = new List<NarucenaStavka>()
            };

            //eventovi : 
            userControlPorucivanje.ComboBoxKategorija.SelectedIndexChanged += comboBoxKategorija_SelectedIndexChanged;
            userControlPorucivanje.ButtonDodajStavkuUPorudzbinu.Click += buttonDodajStavkuUPorudzbinu_Click;
            userControlPorucivanje.ButtonIzbrisiIzabranuStavku.Click += buttonIzbrisiIzabranuStavku_Click;
            userControlPorucivanje.ButtonSacuvajPorudzbinu.Click += buttonSacuvajPorudzbinu_Click;
            userControlPorucivanje.Button1.Click += button1_Click;
        }
        private List<Sto> StoloviKojiSuSlobodni()
        {
            List<Sto> listaSvihStolova = Communication.Instance.VratiSveStolove();
            List<Sto> listaNerezervisanih = new List<Sto>();
            foreach (var sto in listaSvihStolova)
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
            Kategorija k = (Kategorija)userControlPorucivanje.ComboBoxKategorija.SelectedItem;
            List<StavkaCenovnika> stavkeIzKategorije = Communication.Instance.VratiSveStavkeIzKategorije(k);

            userControlPorucivanje.ComboBoxStavkaMenija.DataSource = stavkeIzKategorije;
        }
        private void buttonDodajStavkuUPorudzbinu_Click(object sender, EventArgs e)
        {
            int brojStola;
            Boolean izabranSto = int.TryParse(userControlPorucivanje.ComboBoxSto.SelectedItem?.ToString(), out brojStola);

            if (!izabranSto)
            {
                MessageBox.Show("nisu svi podaci izabrani");
                return;
            }

            double cenaStavke;

            Sto sto = (Sto)userControlPorucivanje.ComboBoxSto.SelectedItem;
            sto.Rezervisan = true;

            StavkaCenovnika stavka = (StavkaCenovnika)userControlPorucivanje.ComboBoxStavkaMenija.SelectedItem;
            int brojPorcija = (int)userControlPorucivanje.ComboBoxBrojPorcija.SelectedItem;

            if(stavka == null)
            {
                MessageBox.Show("Niste izabrali dobro");
                return;
            }

            NarucenaStavka narucenaStavka = new NarucenaStavka();
            narucenaStavka.BrojNarucenihPorcija = brojPorcija;
            narucenaStavka.StavkaCenovnika = stavka;

            cenaStavke = stavka.CenaStavkeSaPDV * brojPorcija;
            _novaPorudzbina.UkupnaVrednost += cenaStavke;
            userControlPorucivanje.LabelUkupnaCena.Text = _novaPorudzbina.UkupnaVrednost.ToString();

            if (_prvaNarudzbina == 1)
            {
                _novaPorudzbina.Sto = sto; //samo u prvom slucaju bira sto jer posle sve 
                _prvaNarudzbina++;  //narucene stavke u jednoj narudzbini ce biti sa tog  istog stola
                userControlPorucivanje.ComboBoxSto.Enabled = false;
                userControlPorucivanje.ButtonSacuvajPorudzbinu.Enabled = true;
                Communication.Instance.RezervisiSto(sto);
            }

            foreach (var ranijeNarucenaStavka in _novaPorudzbina.NaruceneStavke)
            {
                if (ranijeNarucenaStavka.StavkaCenovnika == narucenaStavka.StavkaCenovnika)
                {
                    ranijeNarucenaStavka.BrojNarucenihPorcija += narucenaStavka.BrojNarucenihPorcija;


                    RefresujVrednostiUdataGridView();

                    return;
                }
            }

            _novaPorudzbina.NaruceneStavke.Add(narucenaStavka);


            RefresujVrednostiUdataGridView();
        }
        private void RefresujVrednostiUdataGridView()
        {
            _naruceneStavke = new BindingList<NarucenaStavka>(_novaPorudzbina.NaruceneStavke);
            userControlPorucivanje.DataGridViewStavkeUPorudzbini.DataSource = _naruceneStavke;
        }
        private void buttonIzbrisiIzabranuStavku_Click(object sender, EventArgs e)
        {
            if (userControlPorucivanje.DataGridViewStavkeUPorudzbini.SelectedRows.Count == 0)
            {
                MessageBox.Show("niste izabrali nijedanu stavku");
                return;
            }
            NarucenaStavka stavka = (NarucenaStavka)userControlPorucivanje.DataGridViewStavkeUPorudzbini.SelectedRows[0].DataBoundItem;

            double ukupnaCenaNaruceneStavkeKojuBrisemo = stavka.BrojNarucenihPorcija * stavka.StavkaCenovnika.CenaStavkeSaPDV;
            _novaPorudzbina.UkupnaVrednost -= ukupnaCenaNaruceneStavkeKojuBrisemo;
            userControlPorucivanje.LabelUkupnaCena.Text = _novaPorudzbina.UkupnaVrednost.ToString();

            _novaPorudzbina.NaruceneStavke.Remove(stavka);


            MessageBox.Show("Obrisali ste stavku");

            RefresujVrednostiUdataGridView();
        }
        private void buttonSacuvajPorudzbinu_Click(object sender, EventArgs e)
        {
            Communication.Instance.DodajNovuPorudzbinu(_novaPorudzbina);

            _novaPorudzbina.Sto.Rezervisan = true;
            Communication.Instance.RezervisiSto(_novaPorudzbina.Sto);
            _stolovi = StoloviKojiSuSlobodni();
            userControlPorucivanje.ComboBoxSto.DataSource = _stolovi;


            MessageBox.Show("Uspesno ste sacuvali porudzbinu");
            userControlPorucivanje.ButtonSacuvajPorudzbinu.Enabled = false;
            userControlPorucivanje.ComboBoxSto.Enabled = true;
            _prvaNarudzbina = 1;
            userControlPorucivanje.LabelUkupnaCena.Text = "0.00";

            _naruceneStavke = new BindingList<NarucenaStavka>();
            userControlPorucivanje.DataGridViewStavkeUPorudzbini.DataSource = _naruceneStavke;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (userControlPorucivanje.DataGridViewStavkeUPorudzbini.SelectedRows.Count == 0)
            {
                MessageBox.Show("niste izabrali nijedanu stavku");
                return;
            }
            NarucenaStavka stavka = (NarucenaStavka)userControlPorucivanje.DataGridViewStavkeUPorudzbini.SelectedRows[0].DataBoundItem;

            foreach (var ranijeNarucenaStavka in _novaPorudzbina.NaruceneStavke)
            {
                if (ranijeNarucenaStavka.StavkaCenovnika == stavka.StavkaCenovnika)
                {
                    ranijeNarucenaStavka.BrojNarucenihPorcija--;
                    _novaPorudzbina.UkupnaVrednost -= ranijeNarucenaStavka.StavkaCenovnika.CenaStavkeSaPDV;
                    userControlPorucivanje.LabelUkupnaCena.Text = _novaPorudzbina.UkupnaVrednost.ToString();

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
