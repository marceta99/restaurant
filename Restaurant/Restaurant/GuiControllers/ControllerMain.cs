using Domain;
using Restaurant.ServerCommunication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.GuiControllers
{
    public class ControllerMain
    {
        private FormMain formMain;

        public ControllerMain(FormMain formMain)
        {
            this.formMain = formMain;
            
        }

        internal void initData()
        {
            /*if (Session.Instance.TrenutniKorisnik.Uloga == Uloga.Konobar) //ako se ulogovao kao konobar
            {
                formMain.ButtonPorucivanje.Visible = true;
                formMain.ButtonPorudzbine.Visible = true;
                formMain.ButtonStavkeCenovnika.Visible = false;
                formMain.ButtonStolovi.Visible = false;
            }
            else //ako se ulogovao kao menadzer
            {
                formMain.ButtonStavkeCenovnika.Visible = true;
                formMain.ButtonStolovi.Visible = true;
                formMain.ButtonPorucivanje.Visible = false;
                formMain.ButtonPorudzbine.Visible = false;
            }*/
            //eventovi:
            formMain.FormClosed += FormMain_FormClosed;
        }
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Communication.Instance.CloseConnection();
        }
    }
}
