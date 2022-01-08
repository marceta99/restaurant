
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
        public FormMain()
        {
            InitializeComponent();
            /*buttonPorucivanje.Visible = Controller.Instance.IsKonobar;
            buttonPorudzbine.Visible = Controller.Instance.IsKonobar;

            buttonStavkeCenovnika.Visible = Controller.Instance.IsMenadzer;
            buttonStolovi.Visible = Controller.Instance.IsMenadzer;*/

        }

        private void buttonStolovi_Click(object sender, EventArgs e)
        {
            panelLeft.Controls.Clear();
            UserControlStolovi ucStolovi = new UserControlStolovi
            {
                Dock = DockStyle.Fill
            };
            panelLeft.Controls.Add(ucStolovi);
        }

        private void buttonStavkeCenovnika_Click(object sender, EventArgs e)
        {
            panelLeft.Controls.Clear();
            UserControlStavkaCenovnika ucStavka = new UserControlStavkaCenovnika
            {
                Dock = DockStyle.Fill
            };
            panelLeft.Controls.Add(ucStavka);
        }

        private void buttonPorucivanje_Click(object sender, EventArgs e)
        {
            panelLeft.Controls.Clear();
            UserControlPorucivanje ucPorucivanje = new UserControlPorucivanje
            {
                Dock = DockStyle.Fill
            };
            panelLeft.Controls.Add(ucPorucivanje);
        }

        private void buttonPorudzbine_Click(object sender, EventArgs e)
        {
            panelLeft.Controls.Clear();
            UserControlPorudzbine ucPorudzbine = new UserControlPorudzbine
            {
                Dock = DockStyle.Fill
            };
            panelLeft.Controls.Add(ucPorudzbine);
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Communication.Instance.CloseConnection();
        }


    }
}
