
using Domain;
using Restaurant.Exceptions;
using Restaurant.GuiControllers;
using Restaurant.ServerCommunication;
using Restaurant.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant
{
    public partial class FormMain : Form
    {
        private ControllerMain _controllerMain;
        public FormMain()
        {
            InitializeComponent();
            _controllerMain = new ControllerMain(this);
            _controllerMain.initData();
        }

        private void buttonStolovi_Click(object sender, EventArgs e)
        {
            try
            {
                panelLeft.Controls.Clear();
                UserControlStolovi ucStolovi = new UserControlStolovi
                {
                    Dock = DockStyle.Fill
                };
                panelLeft.Controls.Add(ucStolovi);
            }
            catch (ServerCommunicationException ex)
            {
                MessageBox.Show("Greska sa serverom");
                throw ex;
            }
        }

        private void buttonStavkeCenovnika_Click(object sender, EventArgs e)
        {
            try
            {
                panelLeft.Controls.Clear();
                UserControlStavkaCenovnika ucStavka = new UserControlStavkaCenovnika
                {
                    Dock = DockStyle.Fill
                };
                panelLeft.Controls.Add(ucStavka);
            }
            catch (ServerCommunicationException ex)
            {
                MessageBox.Show("Greska sa serverom");
                throw ex;
            }
        }

        private void buttonPorucivanje_Click(object sender, EventArgs e)
        {
            try
            {
                panelLeft.Controls.Clear();
                UserControlPorucivanje ucPorucivanje = new UserControlPorucivanje
                {
                    Dock = DockStyle.Fill
                };
                panelLeft.Controls.Add(ucPorucivanje);
            }catch(ServerCommunicationException ex)
            {
                MessageBox.Show("Greska sa serverom");
                throw ex;
            }
        }

        private void buttonPorudzbine_Click(object sender, EventArgs e)
        {
            try
            {
                panelLeft.Controls.Clear();
                UserControlPorudzbine ucPorudzbine = new UserControlPorudzbine
                {
                    Dock = DockStyle.Fill
                };
                panelLeft.Controls.Add(ucPorudzbine);

            }
            catch (ServerCommunicationException ex)
            {
                MessageBox.Show("Greska sa serverom");
                throw ex;
            }
        }

    }
}
