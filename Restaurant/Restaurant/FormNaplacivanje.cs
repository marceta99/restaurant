
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
    public partial class FormNaplacivanje : Form
    {
        private Porudzbina _porudzbina;
        public FormNaplacivanje(Porudzbina porudzbina)
        {
            InitializeComponent();

            _porudzbina = porudzbina;

            labelDatumPor.Text = _porudzbina.Datum.ToString().Substring(0,10);
            label1.Text =  _porudzbina.Sto.BrojStola.ToString();
            label3.Text = _porudzbina.UkupnaVrednost.ToString()+" RSD";



        }

        private void buttonNaplaceno_Click(object sender, EventArgs e)
        {
            _porudzbina.StatusPorudzbine = StatusPorudzbine.Naplacena;

            Communication.Instance.PromeniPorudzbinu(_porudzbina);
            Communication.Instance.OslobodiSto(_porudzbina.Sto);

            MessageBox.Show("Poruzdzbina je naplaćena");
            this.Close();
        }
    }
}
