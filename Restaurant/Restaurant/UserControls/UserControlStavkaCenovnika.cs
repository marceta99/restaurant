
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
    public partial class UserControlStavkaCenovnika : UserControl
    {
        private BindingList<StavkaCenovnika> _stavke = new BindingList<StavkaCenovnika>();
        private BindingList<StavkaCenovnika> _stavkeIzKategorije = new BindingList<StavkaCenovnika>();
        int _prviLoad = 1;
        private StavkaCenovnika _stavkaZaIzmenu = null;
        public UserControlStavkaCenovnika()
        {
            InitializeComponent();

            _stavke = new BindingList<StavkaCenovnika>(Communication.Instance.VratiSveStavke());

            dataGridViewStavke.DataSource = _stavke;
            dataGridViewStavke.Columns["StavkaID"].Visible = false;

            comboBoxValuta.DataSource = Communication.Instance.VratiSveValute();
            comboBoxKategorija.DataSource = Communication.Instance.VratiSveKategorije();
            comboBoxFilterKategorije.DataSource = Communication.Instance.VratiSveKategorije();
            

        }

        private void buttonDodajStavku_Click(object sender, EventArgs e)
        {
            double procenatPDV;
            double cenaBezPdv;
            double cenaSaPDV;
            bool dobraCenaBezPdva = double.TryParse(textBoxCenaBezPDV.Text, out cenaBezPdv);
            bool dobarPdv = double.TryParse(textBoxProcenatPDV.Text, out procenatPDV);

            string naziv = textBoxNazivStavke.Text;

            if (!(!string.IsNullOrEmpty(naziv) && dobraCenaBezPdva && dobarPdv))
            {

                MessageBox.Show("Niste pravilno uneli cenu ili naziv");
                return;
            }
            cenaSaPDV = cenaBezPdv + ((cenaBezPdv / 100) * procenatPDV);

            StavkaCenovnika s = new StavkaCenovnika
            {
                NazivStavke = naziv,
                CenaStavkeBezPDV = cenaBezPdv,
                CenaStavkeSaPDV = cenaSaPDV,
                Valuta = (Valuta)comboBoxValuta.SelectedItem,
                Kategorija = (Kategorija)comboBoxKategorija.SelectedItem
            };
            Communication.Instance.DodajNovuStavku(s);

            RefresujVrednostiUdataGridView();
            RefresujInputeIDugmice();


            MessageBox.Show("Uspesno ste dodali novu stavku");

        }

        private void buttonIzbrisiStavku_Click(object sender, EventArgs e)
        {
            if (dataGridViewStavke.SelectedRows.Count == 0)
            {
                MessageBox.Show("niste izabrali nijedanu stavku");
                return;
            }
            StavkaCenovnika stavka = (StavkaCenovnika)dataGridViewStavke.SelectedRows[0].DataBoundItem;
            try
            {
                Communication.Instance.ObrisiStavku(stavka);
                MessageBox.Show("Obrisali ste stavku");
                RefresujVrednostiUdataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ne mozete obrisati izabranu stavku");
            }
        }

        private void buttonIzmeniStavku_Click(object sender, EventArgs e)
        {
            if (dataGridViewStavke.SelectedRows.Count == 0)
            {
                MessageBox.Show("niste izabrali nijedanu stavku");
                return;
            }
            StavkaCenovnika stavka = (StavkaCenovnika)dataGridViewStavke.SelectedRows[0].DataBoundItem;

            textBoxNazivStavke.Text = stavka.NazivStavke;
            textBoxCenaBezPDV.Text = stavka.CenaStavkeBezPDV.ToString();
            textBoxCenaSaPDV.Text = stavka.CenaStavkeSaPDV.ToString();
            comboBoxValuta.SelectedItem = Valuta.RSD;

            comboBoxKategorija.SelectedItem = stavka.Kategorija;

            buttonDodajStavku.Enabled = false;
            buttonSacuvajIzmene.Enabled = true;

            _stavkaZaIzmenu = stavka;

        }

        private void comboBoxFilterKategorije_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_prviLoad == 1)
            {
                _prviLoad++;
                return;
            }

            Kategorija k = (Kategorija)comboBoxFilterKategorije.SelectedItem;
            _stavkeIzKategorije = new BindingList<StavkaCenovnika>(Communication.Instance.VratiSveStavkeIzKategorije(k));

            dataGridViewStavke.DataSource = _stavkeIzKategorije;
        }

        private void buttonSacuvajIzmene_Click(object sender, EventArgs e)
        {
            double cenaSaPdv;
            double cenaBezPdv;
            bool dobraCenaBezPdva = double.TryParse(textBoxCenaBezPDV.Text, out cenaBezPdv);
            bool dobraCenaSaPdv = double.TryParse(textBoxCenaSaPDV.Text, out cenaSaPdv);

            string naziv = textBoxNazivStavke.Text;

            if (!(!string.IsNullOrEmpty(naziv) && dobraCenaBezPdva && dobraCenaSaPdv))
            {

                MessageBox.Show("Niste pravilno uneli cenu ili naziv");
                return;
            }
            StavkaCenovnika s = _stavkaZaIzmenu;
            s.NazivStavke = naziv;
            s.CenaStavkeBezPDV = cenaBezPdv;
            s.CenaStavkeSaPDV = cenaSaPdv;
            s.Valuta = (Valuta)comboBoxValuta.SelectedItem;
            s.Kategorija = (Kategorija)comboBoxKategorija.SelectedItem;

            Communication.Instance.IzmeniStavku(s);

            RefresujVrednostiUdataGridView();
            RefresujInputeIDugmice();
            MessageBox.Show("Uspesno ste promenili stavku");

            

        }

        private void RefresujInputeIDugmice()
        {
            textBoxNazivStavke.Text = "";
            textBoxCenaSaPDV.Text = "";
            textBoxCenaBezPDV.Text = "";

            buttonDodajStavku.Enabled = !(buttonDodajStavku.Enabled);
            buttonSacuvajIzmene.Enabled = !(buttonSacuvajIzmene.Enabled);
        }
        private void RefresujVrednostiUdataGridView()
        {
            _stavke = new BindingList<StavkaCenovnika>(Communication.Instance.VratiSveStavke());
            dataGridViewStavke.DataSource = _stavke;
        }

        private void textBoxProcenatPDV_Leave(object sender, EventArgs e)
        {
            double procenatPDV;
            double cenaBezPdv;
            double cenaSaPDV;
            bool dobraCenaBezPdva = double.TryParse(textBoxCenaBezPDV.Text, out cenaBezPdv);
            bool dobarPdv = double.TryParse(textBoxProcenatPDV.Text, out procenatPDV);

            string naziv = textBoxNazivStavke.Text;

            if (!(dobraCenaBezPdva && dobarPdv))
            {

                MessageBox.Show("Niste pravilno uneli cenu bez pdv-a ili procenat pdv-a");
                return;
            }
            cenaSaPDV = cenaBezPdv + ((cenaBezPdv / 100) * procenatPDV);
            textBoxCenaSaPDV.Text = cenaSaPDV.ToString();
        }
    }
}
