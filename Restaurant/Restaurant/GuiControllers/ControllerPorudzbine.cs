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
    public class ControllerPorudzbine
    {
        private UserControlPorudzbine userControlPorudzbine;
        private BindingList<Porudzbina> _listaPorudzbina;
        private BindingList<StavkaCenovnika> _stavkePorudzbine;
        int _prviLoad = 1;
        int _loadBrojac = 1;
        int _prviLoadStatus = 1;
        public ControllerPorudzbine(UserControlPorudzbine userControlPorudzbine)
        {
            this.userControlPorudzbine = userControlPorudzbine;
        }
        internal void initData()
        {
            //userControlPorudzbine.DataGridViewDetaljiPorudzbine.Visible = false;

            _listaPorudzbina = new BindingList<Porudzbina>(Communication.Instance.VratiSvePorudzbine());
            userControlPorudzbine.DataGridViewSvePorudzbine.DataSource = _listaPorudzbina;

            userControlPorudzbine.ComboBoxFilterStolovi.DataSource = Communication.Instance.VratiSveStolove();
            userControlPorudzbine.ComboBoxStatusPorudzbine.DataSource = Enum.GetValues(typeof(StatusPorudzbine));
            userControlPorudzbine.ComboBoxStatusPorudzbine.SelectedItem = StatusPorudzbine.Kreirana;
            userControlPorudzbine.ComboBoxFilterStolovi.DataSource = Communication.Instance.VratiSveStoloveSaStatusomPorudzbine(StatusPorudzbine.Kreirana);

            userControlPorudzbine.DataGridViewSvePorudzbine.Columns["ImeTabele"].Visible = false;
            userControlPorudzbine.DataGridViewSvePorudzbine.Columns["InsertVrednosti"].Visible = false;
            userControlPorudzbine.DataGridViewSvePorudzbine.Columns["Id"].Visible = false;
            userControlPorudzbine.DataGridViewSvePorudzbine.Columns["Where"].Visible = false;
            userControlPorudzbine.DataGridViewSvePorudzbine.Columns["Set"].Visible = false;
            userControlPorudzbine.DataGridViewSvePorudzbine.Columns["JoinTableName"].Visible = false;
            userControlPorudzbine.DataGridViewSvePorudzbine.Columns["JoinFirst"].Visible = false;
            userControlPorudzbine.DataGridViewSvePorudzbine.Columns["JoinSecond"].Visible = false;
            userControlPorudzbine.DataGridViewSvePorudzbine.Columns["JoinSecondTableName"].Visible = false;
            userControlPorudzbine.DataGridViewSvePorudzbine.Columns["JoinJoinON"].Visible = false;
            userControlPorudzbine.DataGridViewSvePorudzbine.Columns["PorudzbinaID"].Visible = false;

            

            //eventovi :
            userControlPorudzbine.ButtonIzbrisiPorudzbinu.Click += buttonIzbrisiPorudzbinu_Click;
            userControlPorudzbine.ButtonIzmeniPorudzbinu.Click += buttonIzmeniPorudzbinu_Click;
            userControlPorudzbine.ButtonNaplati.Click += buttonNaplati_Click;
            userControlPorudzbine.ComboBoxFilterStolovi.SelectedIndexChanged += comboBoxFilterStolovi_SelectedIndexChanged;
            userControlPorudzbine.DataGridViewSvePorudzbine.RowEnter += dataGridViewSvePorudzbine_RowEnter;
            userControlPorudzbine.ComboBoxStatusPorudzbine.SelectedIndexChanged += comboBoxStatusPorudzbine_SelectedIndexChanged;
            userControlPorudzbine.ButtonFiltriraj.Click += buttonFiltriraj_Click;
        }
        private void buttonIzbrisiPorudzbinu_Click(object sender, EventArgs e)
        {

            if (userControlPorudzbine.DataGridViewSvePorudzbine.SelectedRows.Count == 0)
            {
                MessageBox.Show("niste izabrali nijedanu stavku");
                return;
            }
            Porudzbina porudzbina = (Porudzbina)userControlPorudzbine.DataGridViewSvePorudzbine.SelectedRows[0].DataBoundItem;
            porudzbina.Sto.Rezervisan = false;
            Communication.Instance.OslobodiSto(porudzbina.Sto);
            Communication.Instance.ObrisiPorudzbinu(porudzbina);
            MessageBox.Show("Obrisali ste porudzbinu");

            RefresujVrednostiUdataGridViewPorudzbine();
        }
        private void RefresujVrednostiUdataGridViewPorudzbine()
        {
            _listaPorudzbina = new BindingList<Porudzbina>(Communication.Instance.VratiSvePorudzbine());
            userControlPorudzbine.DataGridViewSvePorudzbine.DataSource = _listaPorudzbina;
        }
        private void buttonIzmeniPorudzbinu_Click(object sender, EventArgs e)
        {
            if (userControlPorudzbine.DataGridViewSvePorudzbine.SelectedRows.Count == 0)
            {
                MessageBox.Show("niste izabrali nijedanu porudzbinu");
                return;
            }
            Porudzbina porudzbina = (Porudzbina)userControlPorudzbine.DataGridViewSvePorudzbine.SelectedRows[0].DataBoundItem;
            _stavkePorudzbine = new BindingList<StavkaCenovnika>(VratiSveStavkeJednePorudzbine(porudzbina));

            FormIzmenaNaplataStavke novaForma = new FormIzmenaNaplataStavke(porudzbina);


            novaForma.ShowDialog();

            RefresujVrednostiUdataGridViewPorudzbine();
        }
        private List<StavkaCenovnika> VratiSveStavkeJednePorudzbine(Porudzbina porudzbina)
        {
            List<StavkaCenovnika> stavke = new List<StavkaCenovnika>();
            foreach (var narucenaStavka in porudzbina.NaruceneStavke)
            {
                stavke.Add(narucenaStavka.StavkaCenovnika);
            }
            return stavke;
        }
        private void buttonNaplati_Click(object sender, EventArgs e)
        {

            if (userControlPorudzbine.DataGridViewSvePorudzbine.SelectedRows.Count == 0)
            {
                MessageBox.Show("niste izabrali nijedanu porudzbinu");
                return;
            }
            Porudzbina porudzbina = (Porudzbina)userControlPorudzbine.DataGridViewSvePorudzbine.SelectedRows[0].DataBoundItem;
            if (porudzbina.StatusPorudzbine == StatusPorudzbine.Naplacena)
            {
                MessageBox.Show("Porudzbina je već naplaćena");
                return;
            }

            FormNaplacivanje frm = new FormNaplacivanje(porudzbina);
            frm.ShowDialog();

            userControlPorudzbine.GroupBoxfilter.Visible = false;
            RefresujVrednostiUdataGridViewPorudzbine();


        }
        private void comboBoxFilterStolovi_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingList<Porudzbina> listaPorudzbinaSaIzabranimStatusom = new BindingList<Porudzbina>();
            Sto s;

            StatusPorudzbine izbranStaus = (StatusPorudzbine)userControlPorudzbine.ComboBoxStatusPorudzbine.SelectedItem;
            if (userControlPorudzbine.ComboBoxFilterStolovi.SelectedItem == null) //ako nije selektovano nista od stolova
            {
                List<Sto> listaStolova = Communication.Instance.VratiSveStoloveSaStatusomPorudzbine(izbranStaus);
                s = listaStolova.Count == 0 ? null : listaStolova[0];
            }
            else
            {
                s = (Sto)userControlPorudzbine.ComboBoxFilterStolovi.SelectedItem;
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

                userControlPorudzbine.DataGridViewSvePorudzbine.DataSource = listaPorudzbinaSaIzabranimStatusom;

                if (listaPorudzbinaSaIzabranimStatusom.Count == 1)
                {
                    Porudzbina p = listaPorudzbinaSaIzabranimStatusom[0];
                    _stavkePorudzbine = new BindingList<StavkaCenovnika>(VratiSveStavkeJednePorudzbine(p));
                    userControlPorudzbine.DataGridViewDetaljiPorudzbine.DataSource = _stavkePorudzbine;
                }
            }

        }
        private void dataGridViewSvePorudzbine_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (_loadBrojac == 1 || _loadBrojac == 2)
            {
                _loadBrojac++;
                return;
            }
            if (userControlPorudzbine.DataGridViewSvePorudzbine.SelectedRows.Count == 0)
            {
                return;
            }
            //userControlPorudzbine.DataGridViewDetaljiPorudzbine.Visible = true;
            Porudzbina porudzbina = (Porudzbina)userControlPorudzbine.DataGridViewSvePorudzbine.SelectedRows[0].DataBoundItem;

            _stavkePorudzbine = new BindingList<StavkaCenovnika>(VratiSveStavkeJednePorudzbine(porudzbina));
            userControlPorudzbine.DataGridViewDetaljiPorudzbine.DataSource = _stavkePorudzbine;

            userControlPorudzbine.DataGridViewDetaljiPorudzbine.Columns["ImeTabele"].Visible = false;
            userControlPorudzbine.DataGridViewDetaljiPorudzbine.Columns["InsertVrednosti"].Visible = false;
            userControlPorudzbine.DataGridViewDetaljiPorudzbine.Columns["Id"].Visible = false;
            userControlPorudzbine.DataGridViewDetaljiPorudzbine.Columns["Where"].Visible = false;
            userControlPorudzbine.DataGridViewDetaljiPorudzbine.Columns["Set"].Visible = false;
            userControlPorudzbine.DataGridViewDetaljiPorudzbine.Columns["JoinTableName"].Visible = false;
            userControlPorudzbine.DataGridViewDetaljiPorudzbine.Columns["JoinFirst"].Visible = false;
            userControlPorudzbine.DataGridViewDetaljiPorudzbine.Columns["JoinSecond"].Visible = false;
            userControlPorudzbine.DataGridViewDetaljiPorudzbine.Columns["JoinSecondTableName"].Visible = false;
            userControlPorudzbine.DataGridViewDetaljiPorudzbine.Columns["JoinJoinON"].Visible = false;

        }
        private void comboBoxStatusPorudzbine_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            StatusPorudzbine izbranStaus = (StatusPorudzbine)userControlPorudzbine.ComboBoxStatusPorudzbine.SelectedItem;
            userControlPorudzbine.ComboBoxFilterStolovi.DataSource = Communication.Instance.VratiSveStoloveSaStatusomPorudzbine(izbranStaus);
            comboBoxFilterStolovi_SelectedIndexChanged(sender, e);
        }
        private void buttonFiltriraj_Click(object sender, EventArgs e)
        {
            userControlPorudzbine.GroupBoxfilter.Visible = !(userControlPorudzbine.GroupBoxfilter.Visible);
        }
    }
}
