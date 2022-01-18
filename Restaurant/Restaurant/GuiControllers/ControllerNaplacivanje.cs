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
    public class ControllerNaplacivanje
    {
        private FormNaplacivanje formNaplacivanje;
        private Porudzbina _porudzbina;
        public ControllerNaplacivanje(FormNaplacivanje formNaplacivanje)
        {
            this.formNaplacivanje = formNaplacivanje;

        }
        internal void initData(Porudzbina porudzbina)
        {
            _porudzbina = porudzbina;

            formNaplacivanje.LabelDatumPor.Text = _porudzbina.Datum.ToString().Substring(0, 10);
            formNaplacivanje.Label1.Text = _porudzbina.Sto.BrojStola.ToString();
            formNaplacivanje.Label3.Text = _porudzbina.UkupnaVrednost.ToString() + " RSD";

            //eventovi :
            formNaplacivanje.ButtonNaplaceno.Click += buttonNaplaceno_Click;
        }
        private void buttonNaplaceno_Click(object sender, EventArgs e)
        {
            _porudzbina.StatusPorudzbine = StatusPorudzbine.Naplacena;

            Communication.Instance.PromeniPorudzbinu(_porudzbina);
            Communication.Instance.OslobodiSto(_porudzbina.Sto);

            MessageBox.Show("Poruzdzbina je naplaćena");
            formNaplacivanje.Close();
        }

    }
}
