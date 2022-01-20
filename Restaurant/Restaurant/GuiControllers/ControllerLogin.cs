using Domain;
using Restaurant.Exceptions;
using Restaurant.ServerCommunication;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.GuiControllers
{
    public class ControllerLogin
    {
        private FormLogin formLogin;
        private bool _loginFailed = false;
        public ControllerLogin(FormLogin formLogin)
        {
            this.formLogin = formLogin;
        }

        internal void initData()
        {
             formLogin.ButtonLogin.Click += buttonLogin_Click;
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string korisnickoIme = formLogin.TextBoxKorisnickoIme.Text;
            string sifra = formLogin.TextBoxSifra.Text;

            if (string.IsNullOrEmpty(korisnickoIme) || string.IsNullOrEmpty(sifra))
            {
                formLogin.TextBoxKorisnickoIme.BackColor = Color.Red;
                formLogin.TextBoxSifra.BackColor = Color.Red;
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
                try
                {
                    Communication.Instance.Connect();

                }catch(ServerCommunicationException ex)
                {
                    MessageBox.Show("Greska sa serverom, probajte da se ulogujete malo kasnije");
                    return;
                }
            }
            Korisnik korisnik = Communication.Instance.Login(noviKorisnik);
            Session.Instance.TrenutniKorisnik = korisnik;

            if (korisnik != null)
            {
                if (korisnik.Uloga == Uloga.Konobar)
                {
                    MessageBox.Show($"Dobrodosli {korisnik.KorisnickoIme} : Konobar");
                    Session.Instance.TrenutniKorisnik.Uloga = Uloga.Konobar;
                    formLogin.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show($"Dobrodosli {korisnik.KorisnickoIme} : Menadzer");
                    Session.Instance.TrenutniKorisnik.Uloga = Uloga.Menadzer;
                    formLogin.DialogResult = DialogResult.OK;
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
