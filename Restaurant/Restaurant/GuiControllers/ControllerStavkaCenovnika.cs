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
    public class ControllerStavkaCenovnika
    {
        private UserControlStavkaCenovnika userControlStavkaCenovnika;
        private BindingList<StavkaCenovnika> _stavke = new BindingList<StavkaCenovnika>();
        private BindingList<StavkaCenovnika> _stavkeIzKategorije = new BindingList<StavkaCenovnika>();
        int _prviLoad = 1;
        private StavkaCenovnika _stavkaZaIzmenu = null;

        public ControllerStavkaCenovnika(UserControlStavkaCenovnika userControlStavkaCenovnika)
        {
            this.userControlStavkaCenovnika = userControlStavkaCenovnika;
        }
        internal void initData()
        {
            _stavke = new BindingList<StavkaCenovnika>(Communication.Instance.VratiSveStavke());

            userControlStavkaCenovnika.DataGridViewStavke.DataSource = _stavke;
            userControlStavkaCenovnika.DataGridViewStavke.Columns["StavkaID"].Visible = false;

            userControlStavkaCenovnika.ComboBoxValuta.DataSource = Communication.Instance.VratiSveValute();
            userControlStavkaCenovnika.ComboBoxKategorija.DataSource = Communication.Instance.VratiSveKategorije();
            userControlStavkaCenovnika.ComboBoxFilterKategorije.DataSource = Communication.Instance.VratiSveKategorije();

            //eventovi :

            userControlStavkaCenovnika.ButtonDodajStavku.Click += buttonDodajStavku_Click;
            userControlStavkaCenovnika.ButtonIzbrisiStavku.Click += buttonIzbrisiStavku_Click;
            userControlStavkaCenovnika.ButtonIzmeniStavku.Click += buttonIzmeniStavku_Click;
            userControlStavkaCenovnika.ButtonSacuvajIzmene.Click += buttonSacuvajIzmene_Click;
            userControlStavkaCenovnika.ComboBoxFilterKategorije.SelectedIndexChanged += comboBoxFilterKategorije_SelectedIndexChanged;
            userControlStavkaCenovnika.TextBoxProcenatPDV.Leave += textBoxProcenatPDV_Leave;
        }
        private void buttonDodajStavku_Click(object sender, EventArgs e)
        {
            double procenatPDV;
            double cenaBezPdv;
            double cenaSaPDV;
            bool dobraCenaBezPdva = double.TryParse(userControlStavkaCenovnika.TextBoxCenaBezPDV.Text, out cenaBezPdv);
            bool dobarPdv = double.TryParse(userControlStavkaCenovnika.TextBoxProcenatPDV.Text, out procenatPDV);

            string naziv = userControlStavkaCenovnika.TextBoxNazivStavke.Text;

            if (!(!string.IsNullOrEmpty(naziv) && dobraCenaBezPdva && dobarPdv))
            {

                MessageBox.Show("Niste pravilno uneli cenu ili naziv ili pdv");
                return;
            }
            cenaSaPDV = cenaBezPdv + ((cenaBezPdv / 100) * procenatPDV);

            StavkaCenovnika s = new StavkaCenovnika
            {
                NazivStavke = naziv,
                CenaStavkeBezPDV = cenaBezPdv,
                CenaStavkeSaPDV = cenaSaPDV,
                Valuta = (Valuta)userControlStavkaCenovnika.ComboBoxValuta.SelectedItem,
                Kategorija = (Kategorija)userControlStavkaCenovnika.ComboBoxKategorija.SelectedItem
            };
            Communication.Instance.DodajNovuStavku(s);

            RefresujVrednostiUdataGridView();
            RefresujInputeIDugmice();


            MessageBox.Show("Uspesno ste dodali novu stavku");

        }
        private void RefresujInputeIDugmice()
        {
            userControlStavkaCenovnika.TextBoxNazivStavke.Text = "";
            userControlStavkaCenovnika.TextBoxCenaSaPDV.Text = "";
            userControlStavkaCenovnika.TextBoxCenaBezPDV.Text = "";

            userControlStavkaCenovnika.ButtonDodajStavku.Enabled = !(userControlStavkaCenovnika.ButtonDodajStavku.Enabled);
            userControlStavkaCenovnika.ButtonSacuvajIzmene.Enabled = !(userControlStavkaCenovnika.ButtonSacuvajIzmene.Enabled);
        }
        private void RefresujVrednostiUdataGridView()
        {
            _stavke = new BindingList<StavkaCenovnika>(Communication.Instance.VratiSveStavke());
            userControlStavkaCenovnika.DataGridViewStavke.DataSource = _stavke;
        }
        private void buttonIzbrisiStavku_Click(object sender, EventArgs e)
        {
            if (userControlStavkaCenovnika.DataGridViewStavke.SelectedRows.Count == 0)
            {
                MessageBox.Show("niste izabrali nijedanu stavku");
                return;
            }
            StavkaCenovnika stavka = (StavkaCenovnika)userControlStavkaCenovnika.DataGridViewStavke.SelectedRows[0].DataBoundItem;
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
            if (userControlStavkaCenovnika.DataGridViewStavke.SelectedRows.Count == 0)
            {
                MessageBox.Show("niste izabrali nijedanu stavku");
                return;
            }
            StavkaCenovnika stavka = (StavkaCenovnika)userControlStavkaCenovnika.DataGridViewStavke.SelectedRows[0].DataBoundItem;

            userControlStavkaCenovnika.TextBoxNazivStavke.Text = stavka.NazivStavke;
            userControlStavkaCenovnika.TextBoxCenaBezPDV.Text = stavka.CenaStavkeBezPDV.ToString();
            userControlStavkaCenovnika.TextBoxCenaSaPDV.Text = stavka.CenaStavkeSaPDV.ToString();
            userControlStavkaCenovnika.ComboBoxValuta.SelectedItem = Valuta.RSD;

            userControlStavkaCenovnika.ComboBoxKategorija.SelectedItem = stavka.Kategorija;

            userControlStavkaCenovnika.ButtonDodajStavku.Enabled = false;
            userControlStavkaCenovnika.ButtonSacuvajIzmene.Enabled = true;

            _stavkaZaIzmenu = stavka;

        }
        private void buttonSacuvajIzmene_Click(object sender, EventArgs e)
        {
            double cenaSaPdv;
            double cenaBezPdv;
            bool dobraCenaBezPdva = double.TryParse(userControlStavkaCenovnika.TextBoxCenaBezPDV.Text, out cenaBezPdv);
            bool dobraCenaSaPdv = double.TryParse(userControlStavkaCenovnika.TextBoxCenaSaPDV.Text, out cenaSaPdv);
            bool dobarPdv = double.TryParse(userControlStavkaCenovnika.TextBoxProcenatPDV.Text, out double pdv);

            string naziv = userControlStavkaCenovnika.TextBoxNazivStavke.Text;

            if (!(!string.IsNullOrEmpty(naziv) && dobraCenaBezPdva && dobarPdv))
            {

                MessageBox.Show("Niste pravilno uneli cenu ili naziv");
                return;
            }
            StavkaCenovnika s = _stavkaZaIzmenu;
            s.NazivStavke = naziv;
            s.CenaStavkeBezPDV = cenaBezPdv;
            s.CenaStavkeSaPDV = cenaSaPdv;
            s.Valuta = (Valuta)userControlStavkaCenovnika.ComboBoxValuta.SelectedItem;
            s.Kategorija = (Kategorija)userControlStavkaCenovnika.ComboBoxKategorija.SelectedItem;

            Communication.Instance.IzmeniStavku(s);

            RefresujVrednostiUdataGridView();
            RefresujInputeIDugmice();
            MessageBox.Show("Uspesno ste promenili stavku");



        }
        private void comboBoxFilterKategorije_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (_prviLoad == 1)
            {
                _prviLoad++;
                return;
            }*/

            Kategorija k = (Kategorija)userControlStavkaCenovnika.ComboBoxFilterKategorije.SelectedItem;
            _stavkeIzKategorije = new BindingList<StavkaCenovnika>(Communication.Instance.VratiSveStavkeIzKategorije(k));

            userControlStavkaCenovnika.DataGridViewStavke.DataSource = _stavkeIzKategorije;
        }
        private void textBoxProcenatPDV_Leave(object sender, EventArgs e)
        {
            double procenatPDV;
            double cenaBezPdv;
            double cenaSaPDV;
            bool dobraCenaBezPdva = double.TryParse(userControlStavkaCenovnika.TextBoxCenaBezPDV.Text, out cenaBezPdv);
            bool dobarPdv = double.TryParse(userControlStavkaCenovnika.TextBoxProcenatPDV.Text, out procenatPDV);

            string naziv = userControlStavkaCenovnika.TextBoxNazivStavke.Text;

            /*if (!(dobraCenaBezPdva && dobarPdv))
            {

                MessageBox.Show("Niste pravilno uneli cenu bez pdv-a ili procenat pdv-a");
                return;
            }*/
            cenaSaPDV = cenaBezPdv + ((cenaBezPdv / 100) * procenatPDV);
            userControlStavkaCenovnika.TextBoxCenaSaPDV.Text = cenaSaPDV.ToString();
        }
    }
}
