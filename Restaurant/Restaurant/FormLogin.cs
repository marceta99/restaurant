
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
    public partial class FormLogin : Form
    {
        private bool _loginFailed = false;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string korisnickoIme = textBoxKorisnickoIme.Text;
            string sifra = textBoxSifra.Text;

            if (string.IsNullOrEmpty(korisnickoIme) || string.IsNullOrEmpty(sifra))
            {
                textBoxKorisnickoIme.BackColor = Color.Red;
                textBoxSifra.BackColor = Color.Red;
                MessageBox.Show("Morate uneti korisnicko ime i sifru");
                return;
            }
            Korisnik noviKorisnik = new Korisnik
            {
                KorisnickoIme = korisnickoIme,
                Sifra = sifra
            };
            if (!_loginFailed)
            {
                Communication.Instance.Connect();
            }
            Korisnik korisnik = Communication.Instance.Login(noviKorisnik);

            if(korisnik != null)
            {
                if(korisnik.Uloga == Uloga.Konobar)
                {
                    MessageBox.Show($"Dobrodosli {korisnik.KorisnickoIme} : Konobar");
                    DialogResult = DialogResult.OK;
                }
                else
                {

                    MessageBox.Show($"Dobrodosli {korisnik.KorisnickoIme} : Menadzer");
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                _loginFailed = true;
                MessageBox.Show("Pogresno uneta sifra ili korisnicko ime");
            }
            //DialogResult = DialogResult.OK;
        }
    }
}
