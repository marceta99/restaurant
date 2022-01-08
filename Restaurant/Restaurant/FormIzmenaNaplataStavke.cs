
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

namespace Restaurant
{
    public partial class FormIzmenaNaplataStavke : Form
    {
        private Porudzbina _porudzbina;
        private BindingList<NarucenaStavka> _naruceneStavke;

        public FormIzmenaNaplataStavke(Porudzbina porudzbina)
        {
            InitializeComponent();

            _porudzbina = porudzbina;
            _naruceneStavke = new BindingList<NarucenaStavka>(porudzbina.NaruceneStavke);


            comboBoxSto.DataSource = Communication.Instance.VratiSveStolove();
            comboBoxSto.Enabled = false;
            comboBoxSto.SelectedItem = _porudzbina.Sto;

            
            labelUkupnaCena.Text = _porudzbina.UkupnaVrednost.ToString();

            dataGridViewStavkeUPorudzbini.DataSource = _naruceneStavke;

            comboBoxKategorija.DataSource = Communication.Instance.VratiSveKategorije();
            comboBoxBrojPorcija.DataSource = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };


        }

        private void comboBoxKategorija_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kategorija k = (Kategorija)comboBoxKategorija.SelectedItem;
            List<StavkaCenovnika> stavkeIzKategorije = Communication.Instance.VratiSveStavkeIzKategorije(k);

            comboBoxStavkaMenija.DataSource = stavkeIzKategorije;
        }

        private void buttonDodajStavkuUPorudzbinu_Click(object sender, EventArgs e)
        {
            double cenaStavke;

            StavkaCenovnika stavka = (StavkaCenovnika)comboBoxStavkaMenija.SelectedItem;
            int brojPorcija = (int)comboBoxBrojPorcija.SelectedItem;

            NarucenaStavka narucenaStavka = new NarucenaStavka();
            narucenaStavka.BrojNarucenihPorcija = brojPorcija;
            narucenaStavka.StavkaCenovnika = stavka;

            cenaStavke = stavka.CenaStavkeSaPDV * brojPorcija;
            _porudzbina.UkupnaVrednost += cenaStavke;
            labelUkupnaCena.Text = _porudzbina.UkupnaVrednost.ToString();


            foreach (var ranijeNarucenaStavka in _porudzbina.NaruceneStavke)
            {
                if (ranijeNarucenaStavka.StavkaCenovnika == narucenaStavka.StavkaCenovnika)
                {
                    ranijeNarucenaStavka.BrojNarucenihPorcija += narucenaStavka.BrojNarucenihPorcija;

                    Porucivanje porucivanje = new Porucivanje
                    {
                        Porudzbina = _porudzbina,
                        StavkaCenovnika = ranijeNarucenaStavka.StavkaCenovnika,
                        BrojPorcija = ranijeNarucenaStavka.BrojNarucenihPorcija
                    };
                    Communication.Instance.DodajBrojPorcijaStarojStavci(porucivanje);
                    Communication.Instance.PromeniPorudzbinu(_porudzbina);

                    RefresujVrednostiUdataGridView();

                    return;
                }
            }

            _porudzbina.NaruceneStavke.Add(narucenaStavka);
            Porucivanje porucivanje1 = new Porucivanje
            {
                BrojPorcija = narucenaStavka.BrojNarucenihPorcija,
                Porudzbina = _porudzbina,
                StavkaCenovnika = narucenaStavka.StavkaCenovnika
            };
            Communication.Instance.DodajNovoPorucivanje(porucivanje1);
            Communication.Instance.PromeniPorudzbinu(_porudzbina);


            
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
            _porudzbina.UkupnaVrednost -= ukupnaCenaNaruceneStavkeKojuBrisemo;
            labelUkupnaCena.Text = _porudzbina.UkupnaVrednost.ToString();
            
            _porudzbina.NaruceneStavke.Remove(stavka);
            Porucivanje porucivanje = new Porucivanje
            {
                Porudzbina = _porudzbina,
                StavkaCenovnika = stavka.StavkaCenovnika
            };
            Communication.Instance.ObrisiPorucivanjeZaStavku(porucivanje);


            MessageBox.Show("Obrisali ste stavku");
            RefresujVrednostiUdataGridView();
        }

        private void RefresujVrednostiUdataGridView()
        {
            _naruceneStavke = new BindingList<NarucenaStavka>(_porudzbina.NaruceneStavke);
            dataGridViewStavkeUPorudzbini.DataSource = _naruceneStavke;
        }

        private void buttonSmanjiBrojPorcija_Click(object sender, EventArgs e)
        {
            if (dataGridViewStavkeUPorudzbini.SelectedRows.Count == 0)
            {
                MessageBox.Show("niste izabrali nijedanu stavku");
                return;
            }
            NarucenaStavka stavka = (NarucenaStavka)dataGridViewStavkeUPorudzbini.SelectedRows[0].DataBoundItem;

            foreach (var ranijeNarucenaStavka in _porudzbina.NaruceneStavke)
            {
                if (ranijeNarucenaStavka.StavkaCenovnika == stavka.StavkaCenovnika)
                {
                    ranijeNarucenaStavka.BrojNarucenihPorcija--;
                    _porudzbina.UkupnaVrednost -= ranijeNarucenaStavka.StavkaCenovnika.CenaStavkeSaPDV;
                    labelUkupnaCena.Text = _porudzbina.UkupnaVrednost.ToString();
                    if(ranijeNarucenaStavka.BrojNarucenihPorcija == 0)
                    {
                        buttonIzbrisiIzabranuStavku_Click(sender, e);
                        labelUkupnaCena.Text = _porudzbina.UkupnaVrednost.ToString();

                        RefresujVrednostiUdataGridView();
                        return;
                    }
                    Communication.Instance.PromeniPorudzbinu(_porudzbina);
                    RefresujVrednostiUdataGridView();

                }
            }
            //Controller.Instance.PromeniPorudzbinu(_porudzbina);
            RefresujVrednostiUdataGridView();

        }
    }
}
