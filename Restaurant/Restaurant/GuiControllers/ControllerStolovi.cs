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
    class ControllerStolovi
    {
        private UserControlStolovi userControlStolovi;
        private BindingList<Sto> _stolovi = new BindingList<Sto>();


        public ControllerStolovi(UserControlStolovi userControlStolovi)
        {
            this.userControlStolovi = userControlStolovi;
            
        }
        internal void initData()
        {
            userControlStolovi.ComboBoxBrojStolica.DataSource = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };

            _stolovi = new BindingList<Sto>(Communication.Instance.VratiSveStolove());

            userControlStolovi.ComboBoxBrojStola.DataSource = BrojeviStolovaKojiMoguDaSeKoriste();

            userControlStolovi.DataGridViewStolovi.DataSource = _stolovi;
            userControlStolovi.DataGridViewStolovi.Columns["StoID"].Visible = false;

            //eventovi : 
            userControlStolovi.ButtonDodajSto.Click += buttonDodajSto_Click;
            userControlStolovi.ButtonIzbrisiSto.Click += buttonIzbrisiSto_Click;
            userControlStolovi.ButtonIzmeniSto.Click += buttonIzmeniSto_Click;
            userControlStolovi.ButtonSacuvajIzmene.Click += buttonSacuvajIzmene_Click;
        }
        private void buttonSacuvajIzmene_Click(object sender, EventArgs e)
        {
            Sto sto = (Sto)userControlStolovi.DataGridViewStolovi.SelectedRows[0].DataBoundItem;

            sto.BrojStola = (int)userControlStolovi.ComboBoxIzmenjeniBrojeviStola.SelectedItem;
            sto.BrojStolica = (int)userControlStolovi.ComboBoxIzmenjeniBrojeviStolica.SelectedItem;

            Communication.Instance.IzmeniSto(sto);


            userControlStolovi.ComboBoxIzmenjeniBrojeviStola.Enabled = false;
            userControlStolovi.ComboBoxIzmenjeniBrojeviStolica.Enabled = false;
            userControlStolovi.ButtonSacuvajIzmene.Enabled = false;

            userControlStolovi.ButtonIzbrisiSto.Enabled = true;
            userControlStolovi.ButtonDodajSto.Enabled = true;
            userControlStolovi.ComboBoxBrojStola.Enabled = true;
            userControlStolovi.ComboBoxBrojStola.Enabled = true;

            RefresujVrednostiUdataGridView();
            RefresujMoguceVrednostiZaBrojStola();
        }
        private void buttonIzmeniSto_Click(object sender, EventArgs e)
        {
            if (userControlStolovi.DataGridViewStolovi.SelectedRows.Count == 0)
            {
                MessageBox.Show("niste izabrali nijedan sto");
                return;
            }
            Sto sto = (Sto)userControlStolovi.DataGridViewStolovi.SelectedRows[0].DataBoundItem;

            userControlStolovi.ComboBoxIzmenjeniBrojeviStola.Enabled = true;
            userControlStolovi.ComboBoxIzmenjeniBrojeviStolica.Enabled = true;
            userControlStolovi.ButtonSacuvajIzmene.Enabled = true;

            userControlStolovi.ButtonIzbrisiSto.Enabled = false;
            userControlStolovi.ButtonDodajSto.Enabled = false;
            userControlStolovi.ComboBoxBrojStola.Enabled = false;
            userControlStolovi.ComboBoxBrojStola.Enabled = false;

            List<int> listaStolova = BrojeviStolovaKojiMoguDaSeKoriste();
            listaStolova.Add(sto.BrojStola);

            userControlStolovi.ComboBoxIzmenjeniBrojeviStola.DataSource = listaStolova;
            userControlStolovi.ComboBoxIzmenjeniBrojeviStolica.DataSource = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };

            userControlStolovi.ComboBoxIzmenjeniBrojeviStola.SelectedItem = sto.BrojStola;
            userControlStolovi.ComboBoxIzmenjeniBrojeviStolica.SelectedItem = sto.BrojStolica;
        }
        private void buttonIzbrisiSto_Click(object sender, EventArgs e)
        {
            if (userControlStolovi.DataGridViewStolovi.SelectedRows.Count == 0)
            {
                MessageBox.Show("niste izabrali nijedan sto");
                return;
            }
            Sto sto = (Sto)userControlStolovi.DataGridViewStolovi.SelectedRows[0].DataBoundItem;

            if (sto.Rezervisan)
            {
                MessageBox.Show("Ne mozete obrisati ovaj sto jer je vec rezervisan");
                return;
            }
            try
            {
                Communication.Instance.IzbrisiSto(sto);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vec su ranije pravljenje porudzbine nad ovim stolom tako da ga ne mozete obrisati");
                return;
            }
            MessageBox.Show("Obrisali ste sto");

            RefresujVrednostiUdataGridView();
            RefresujMoguceVrednostiZaBrojStola();
        }
        private List<int> BrojeviStolovaKojiMoguDaSeKoriste()
        {
            List<int> listaBrojevaDo25 = new List<int>();

            for (int i = 1; i < 25; i++)
            {
                listaBrojevaDo25.Add(i);
            }
            foreach (var sto in _stolovi)
            {
                listaBrojevaDo25.Remove(sto.BrojStola);
            }
            return listaBrojevaDo25;

        }
        private void buttonDodajSto_Click(object sender, EventArgs e)
        {

            Sto noviSto = new Sto
            {
                BrojStola = (int)userControlStolovi.ComboBoxBrojStola.SelectedItem,
                BrojStolica = (int)userControlStolovi.ComboBoxBrojStolica.SelectedItem

            };
            Communication.Instance.DodajNoviSto(noviSto);

            RefresujVrednostiUdataGridView();
            RefresujMoguceVrednostiZaBrojStola();

        }
        private void RefresujVrednostiUdataGridView()
        {
            _stolovi = new BindingList<Sto>(Communication.Instance.VratiSveStolove());
            userControlStolovi.DataGridViewStolovi.DataSource = _stolovi;

        }
        private void RefresujMoguceVrednostiZaBrojStola()
        {
            _stolovi = new BindingList<Sto>(Communication.Instance.VratiSveStolove());
            userControlStolovi.ComboBoxBrojStola.DataSource = BrojeviStolovaKojiMoguDaSeKoriste();
        }
    }
}
