
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
    public partial class UserControlPorudzbine : UserControl
    {
        private BindingList<Porudzbina> _listaPorudzbina;
        private BindingList<StavkaCenovnika> _stavkePorudzbine;
        int _prviLoad = 1;
        int _loadBrojac = 1;
        int _prviLoadStatus = 1;
        public UserControlPorudzbine()
        {
            InitializeComponent();

            _listaPorudzbina = new BindingList<Porudzbina>(Communication.Instance.VratiSvePorudzbine());
            dataGridViewSvePorudzbine.DataSource = _listaPorudzbina;

            comboBoxFilterStolovi.DataSource = Communication.Instance.VratiSveStolove();
            comboBoxStatusPorudzbine.DataSource = Enum.GetValues(typeof(StatusPorudzbine));
            comboBoxStatusPorudzbine.SelectedItem = StatusPorudzbine.Kreirana;
            comboBoxFilterStolovi.DataSource = Communication.Instance.VratiSveStoloveSaStatusomPorudzbine(StatusPorudzbine.Kreirana);
        }

        private void buttonPrikaziDetaljeIzabraneStavke_Click(object sender, EventArgs e)
        {

            if (dataGridViewSvePorudzbine.SelectedRows.Count == 0)
            {
                MessageBox.Show("niste izabrali nijedanu stavku");
                return;
            }
            Porudzbina porudzbina = (Porudzbina)dataGridViewSvePorudzbine.SelectedRows[0].DataBoundItem;

            _stavkePorudzbine = new BindingList<StavkaCenovnika>(VratiSveStavkeJednePorudzbine(porudzbina));
            dataGridViewDetaljiPorudzbine.DataSource = _stavkePorudzbine; 
        
        }

        private void buttonIzbrisiPorudzbinu_Click(object sender, EventArgs e)
        {

            if (dataGridViewSvePorudzbine.SelectedRows.Count == 0)
            {
                MessageBox.Show("niste izabrali nijedanu stavku");
                return;
            }
            Porudzbina porudzbina = (Porudzbina)dataGridViewSvePorudzbine.SelectedRows[0].DataBoundItem;
            porudzbina.Sto.Rezervisan = false;
            Communication.Instance.OslobodiSto(porudzbina.Sto);
            Communication.Instance.ObrisiPorudzbinu(porudzbina);
            MessageBox.Show("Obrisali ste porudzbinu");

            RefresujVrednostiUdataGridViewPorudzbine();
        }
        private void RefresujVrednostiUdataGridViewPorudzbine()
        {
            _listaPorudzbina = new BindingList<Porudzbina>(Communication.Instance.VratiSvePorudzbine());
            dataGridViewSvePorudzbine.DataSource = _listaPorudzbina;
        }
        private List<StavkaCenovnika> VratiSveStavkeJednePorudzbine(Porudzbina porudzbina)
        {
            List<StavkaCenovnika> stavke = new List<StavkaCenovnika>();
            foreach(var narucenaStavka in porudzbina.NaruceneStavke)
            {
                stavke.Add(narucenaStavka.StavkaCenovnika);
            }
            return stavke; 
        }

        private void buttonIzmeniPorudzbinu_Click(object sender, EventArgs e)
        {
            if (dataGridViewSvePorudzbine.SelectedRows.Count == 0)
            {
                MessageBox.Show("niste izabrali nijedanu porudzbinu");
                return;
            }
            Porudzbina porudzbina = (Porudzbina)dataGridViewSvePorudzbine.SelectedRows[0].DataBoundItem;
            _stavkePorudzbine = new BindingList<StavkaCenovnika>(VratiSveStavkeJednePorudzbine(porudzbina));

            FormIzmenaNaplataStavke novaForma = new FormIzmenaNaplataStavke(porudzbina);


            novaForma.ShowDialog();

            RefresujVrednostiUdataGridViewPorudzbine();
        }

        private void buttonNaplati_Click(object sender, EventArgs e)
        {

            if (dataGridViewSvePorudzbine.SelectedRows.Count == 0)
            {
                MessageBox.Show("niste izabrali nijedanu porudzbinu");
                return;
            }
            Porudzbina porudzbina = (Porudzbina)dataGridViewSvePorudzbine.SelectedRows[0].DataBoundItem;
            if(porudzbina.StatusPorudzbine == StatusPorudzbine.Naplacena)
            {
                MessageBox.Show("Porudzbina je već naplaćena");
                return;
            }

            FormNaplacivanje frm = new FormNaplacivanje(porudzbina);
            frm.ShowDialog();

            groupBoxfilter.Visible = false;
            RefresujVrednostiUdataGridViewPorudzbine();


        }

        private void comboBoxFilterStolovi_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingList<Porudzbina> listaPorudzbinaSaIzabranimStatusom = new BindingList<Porudzbina>();
            Sto s;

            if (_prviLoad == 1 || _prviLoad ==2)
            {
                _prviLoad++;
                return;
            }
            StatusPorudzbine izbranStaus = (StatusPorudzbine)comboBoxStatusPorudzbine.SelectedItem;
            if (comboBoxFilterStolovi.SelectedItem == null) //ako nije selektovano nista od stolova
            {
                List<Sto> listaStolova = Communication.Instance.VratiSveStoloveSaStatusomPorudzbine(izbranStaus);
                 s = listaStolova.Count == 0 ? null : listaStolova[0];
            }
            else
            {
                 s = (Sto)comboBoxFilterStolovi.SelectedItem;
            }

            if (s != null)
            {

                _listaPorudzbina = new BindingList<Porudzbina>(Communication.Instance.VratiSvePorudzbineSaStola(s));
                if (izbranStaus == StatusPorudzbine.Kreirana)
                {
                    foreach (var por in _listaPorudzbina)
                    {
                        if (por.StatusPorudzbine == StatusPorudzbine.Kreirana)
                        {
                            listaPorudzbinaSaIzabranimStatusom.Add(por);
                        }
                    }
                }
                else
                {
                    foreach (var por in _listaPorudzbina)
                    {
                        if (por.StatusPorudzbine == StatusPorudzbine.Naplacena)
                        {
                            listaPorudzbinaSaIzabranimStatusom.Add(por);
                        }
                    }
                }

                dataGridViewSvePorudzbine.DataSource = listaPorudzbinaSaIzabranimStatusom;

                if(listaPorudzbinaSaIzabranimStatusom.Count == 1)
                {
                    Porudzbina p = listaPorudzbinaSaIzabranimStatusom[0];
                    _stavkePorudzbine = new BindingList<StavkaCenovnika>(VratiSveStavkeJednePorudzbine(p));
                    dataGridViewDetaljiPorudzbine.DataSource = _stavkePorudzbine;
                }
            }
            
        }


        private void dataGridViewSvePorudzbine_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(_loadBrojac ==1 || _loadBrojac == 2)
            {
                _loadBrojac++;
                return;
            }
            if (dataGridViewSvePorudzbine.SelectedRows.Count == 0)
            {
                return;
            }
            Porudzbina porudzbina = (Porudzbina)dataGridViewSvePorudzbine.SelectedRows[0].DataBoundItem;

            _stavkePorudzbine = new BindingList<StavkaCenovnika>(VratiSveStavkeJednePorudzbine(porudzbina));
            dataGridViewDetaljiPorudzbine.DataSource = _stavkePorudzbine;

        }

        private void comboBoxStatusPorudzbine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_prviLoadStatus == 1 )
            {
                _prviLoadStatus++;
                return; 
            }
            StatusPorudzbine izbranStaus = (StatusPorudzbine)comboBoxStatusPorudzbine.SelectedItem;
            comboBoxFilterStolovi.DataSource = Communication.Instance.VratiSveStoloveSaStatusomPorudzbine(izbranStaus);
            comboBoxFilterStolovi_SelectedIndexChanged(sender, e);
        }

        private void buttonFiltriraj_Click(object sender, EventArgs e)
        {
            groupBoxfilter.Visible = !(groupBoxfilter.Visible);
        }

        
    }
}
