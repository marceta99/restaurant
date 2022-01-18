using Domain;
using Restaurant.ServerCommunication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.GuiControllers
{
    public class ContollerIzmenaNaplateStavke
    {
        private FormIzmenaNaplataStavke formIzmenaNaplataStavke;
        private Porudzbina _porudzbina;
        private BindingList<NarucenaStavka> _naruceneStavke;
        public ContollerIzmenaNaplateStavke(FormIzmenaNaplataStavke formIzmenaNaplataStavke)
        {
            this.formIzmenaNaplataStavke = formIzmenaNaplataStavke;
        }
        internal void initData(Porudzbina porudzbina)
        {
            _porudzbina = porudzbina;
            _naruceneStavke = new BindingList<NarucenaStavka>(porudzbina.NaruceneStavke);


            formIzmenaNaplataStavke.ComboBoxSto.DataSource = Communication.Instance.VratiSveStolove();
            formIzmenaNaplataStavke.ComboBoxSto.Enabled = false;
            formIzmenaNaplataStavke.ComboBoxSto.SelectedItem = _porudzbina.Sto;


            formIzmenaNaplataStavke.LabelUkupnaCena.Text = _porudzbina.UkupnaVrednost.ToString();

            formIzmenaNaplataStavke.DataGridViewStavkeUPorudzbini.DataSource = _naruceneStavke;

            formIzmenaNaplataStavke.ComboBoxKategorija.DataSource = Communication.Instance.VratiSveKategorije();
            formIzmenaNaplataStavke.ComboBoxBrojPorcija.DataSource = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

            //eventovi : 
            formIzmenaNaplataStavke.ComboBoxKategorija.SelectedIndexChanged += comboBoxKategorija_SelectedIndexChanged;
            formIzmenaNaplataStavke.ButtonDodajStavkuUPorudzbinu.Click += buttonDodajStavkuUPorudzbinu_Click;
            formIzmenaNaplataStavke.ButtonIzbrisiIzabranuStavku.Click += buttonIzbrisiIzabranuStavku_Click;
            formIzmenaNaplataStavke.ButtonSmanjiBrojPorcija.Click += buttonSmanjiBrojPorcija_Click;
        }
        private void comboBoxKategorija_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kategorija k = (Kategorija)formIzmenaNaplataStavke.ComboBoxKategorija.SelectedItem;
            List<StavkaCenovnika> stavkeIzKategorije = Communication.Instance.VratiSveStavkeIzKategorije(k);

            formIzmenaNaplataStavke.ComboBoxStavkaMenija.DataSource = stavkeIzKategorije;
        }
        private void buttonDodajStavkuUPorudzbinu_Click(object sender, EventArgs e)
        {
            double cenaStavke;

            StavkaCenovnika stavka = (StavkaCenovnika)formIzmenaNaplataStavke.ComboBoxStavkaMenija.SelectedItem;
            int brojPorcija = (int)formIzmenaNaplataStavke.ComboBoxBrojPorcija.SelectedItem;

            NarucenaStavka narucenaStavka = new NarucenaStavka();
            narucenaStavka.BrojNarucenihPorcija = brojPorcija;
            narucenaStavka.StavkaCenovnika = stavka;

            cenaStavke = stavka.CenaStavkeSaPDV * brojPorcija;
            _porudzbina.UkupnaVrednost += cenaStavke;
            formIzmenaNaplataStavke.LabelUkupnaCena.Text = _porudzbina.UkupnaVrednost.ToString();


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
        private void RefresujVrednostiUdataGridView()
        {
            _naruceneStavke = new BindingList<NarucenaStavka>(_porudzbina.NaruceneStavke);
            formIzmenaNaplataStavke.DataGridViewStavkeUPorudzbini.DataSource = _naruceneStavke;
        }
        private void buttonIzbrisiIzabranuStavku_Click(object sender, EventArgs e)
        {
            if (formIzmenaNaplataStavke.DataGridViewStavkeUPorudzbini.SelectedRows.Count == 0)
            {
                MessageBox.Show("niste izabrali nijedanu stavku");
                return;
            }
            NarucenaStavka stavka = (NarucenaStavka)formIzmenaNaplataStavke.DataGridViewStavkeUPorudzbini.SelectedRows[0].DataBoundItem;

            double ukupnaCenaNaruceneStavkeKojuBrisemo = stavka.BrojNarucenihPorcija * stavka.StavkaCenovnika.CenaStavkeSaPDV;
            _porudzbina.UkupnaVrednost -= ukupnaCenaNaruceneStavkeKojuBrisemo;
            formIzmenaNaplataStavke.LabelUkupnaCena.Text = _porudzbina.UkupnaVrednost.ToString();

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
        private void buttonSmanjiBrojPorcija_Click(object sender, EventArgs e)
        {
            if (formIzmenaNaplataStavke.DataGridViewStavkeUPorudzbini.SelectedRows.Count == 0)
            {
                MessageBox.Show("niste izabrali nijedanu stavku");
                return;
            }
            NarucenaStavka stavka = (NarucenaStavka)formIzmenaNaplataStavke.DataGridViewStavkeUPorudzbini.SelectedRows[0].DataBoundItem;

            foreach (var ranijeNarucenaStavka in _porudzbina.NaruceneStavke)
            {
                if (ranijeNarucenaStavka.StavkaCenovnika == stavka.StavkaCenovnika)
                {
                    ranijeNarucenaStavka.BrojNarucenihPorcija--;
                    _porudzbina.UkupnaVrednost -= ranijeNarucenaStavka.StavkaCenovnika.CenaStavkeSaPDV;
                    formIzmenaNaplataStavke.LabelUkupnaCena.Text = _porudzbina.UkupnaVrednost.ToString();
                    if (ranijeNarucenaStavka.BrojNarucenihPorcija == 0)
                    {
                        buttonIzbrisiIzabranuStavku_Click(sender, e);
                        formIzmenaNaplataStavke.LabelUkupnaCena.Text = _porudzbina.UkupnaVrednost.ToString();

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
