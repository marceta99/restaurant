
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
    public partial class UserControlStolovi : UserControl
    {
        private BindingList<Sto> _stolovi = new BindingList<Sto>();
       
        public UserControlStolovi()
        {
            InitializeComponent();

            comboBoxBrojStolica.DataSource = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
            
            _stolovi = new BindingList<Sto>(Communication.Instance.VratiSveStolove());

            comboBoxBrojStola.DataSource = BrojeviStolovaKojiMoguDaSeKoriste();

            dataGridViewStolovi.DataSource = _stolovi;
            dataGridViewStolovi.Columns["StoID"].Visible = false; 

        }

        private void buttonDodajSto_Click(object sender, EventArgs e)
        {

            Sto noviSto = new Sto
            {
                BrojStola = (int)comboBoxBrojStola.SelectedItem,
                BrojStolica = (int)comboBoxBrojStolica.SelectedItem

            };
            Communication.Instance.DodajNoviSto(noviSto);

            RefresujVrednostiUdataGridView();
            RefresujMoguceVrednostiZaBrojStola();

        }

        private void buttonIzbrisiSto_Click(object sender, EventArgs e)
        {
            if(dataGridViewStolovi.SelectedRows.Count == 0)
            {
                MessageBox.Show("niste izabrali nijedan sto");
                return; 
            }
            Sto sto = (Sto)dataGridViewStolovi.SelectedRows[0].DataBoundItem;

            if (sto.Rezervisan)
            {
                MessageBox.Show("Ne mozete obrisati ovaj sto jer je vec rezervisan");
                return;
            }
            try
            {
                Communication.Instance.IzbrisiSto(sto);
            }catch(Exception ex)
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

        private void RefresujVrednostiUdataGridView()
        {
            _stolovi = new BindingList<Sto>(Communication.Instance.VratiSveStolove());
            dataGridViewStolovi.DataSource = _stolovi;

        }

        private void RefresujMoguceVrednostiZaBrojStola()
        {
            _stolovi = new BindingList<Sto>(Communication.Instance.VratiSveStolove());
            comboBoxBrojStola.DataSource = BrojeviStolovaKojiMoguDaSeKoriste();
        }

        private void buttonIzmeniSto_Click(object sender, EventArgs e)
        {
            if (dataGridViewStolovi.SelectedRows.Count == 0)
            {
                MessageBox.Show("niste izabrali nijedan sto");
                return;
            }
            Sto sto = (Sto)dataGridViewStolovi.SelectedRows[0].DataBoundItem;

            comboBoxIzmenjeniBrojeviStola.Enabled = true;
            comboBoxIzmenjeniBrojeviStolica.Enabled = true;
            buttonSacuvajIzmene.Enabled = true;

            buttonIzbrisiSto.Enabled = false;
            buttonDodajSto.Enabled = false;
            comboBoxBrojStola.Enabled = false;
            comboBoxBrojStola.Enabled = false;

            List<int> listaStolova = BrojeviStolovaKojiMoguDaSeKoriste();
            listaStolova.Add(sto.BrojStola);

            comboBoxIzmenjeniBrojeviStola.DataSource = listaStolova;
            comboBoxIzmenjeniBrojeviStolica.DataSource = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };

            comboBoxIzmenjeniBrojeviStola.SelectedItem = sto.BrojStola;
            comboBoxIzmenjeniBrojeviStolica.SelectedItem = sto.BrojStolica;
        }
        private void buttonSacuvajIzmene_Click(object sender, EventArgs e)
        {
            Sto sto = (Sto)dataGridViewStolovi.SelectedRows[0].DataBoundItem;

            sto.BrojStola = (int)comboBoxIzmenjeniBrojeviStola.SelectedItem;
            sto.BrojStolica = (int)comboBoxIzmenjeniBrojeviStolica.SelectedItem;

            Communication.Instance.IzmeniSto(sto);


            comboBoxIzmenjeniBrojeviStola.Enabled = false;
            comboBoxIzmenjeniBrojeviStolica.Enabled = false;
            buttonSacuvajIzmene.Enabled = false;

            buttonIzbrisiSto.Enabled = true;
            buttonDodajSto.Enabled = true;
            comboBoxBrojStola.Enabled = true;
            comboBoxBrojStola.Enabled = true;

            RefresujVrednostiUdataGridView();
            RefresujMoguceVrednostiZaBrojStola();
        }
    }
}
