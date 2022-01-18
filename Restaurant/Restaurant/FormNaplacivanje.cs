
using Domain;
using Restaurant.GuiControllers;
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
        
        private ControllerNaplacivanje _controllerNaplacivanje;
        public FormNaplacivanje(Porudzbina porudzbina)
        {
            InitializeComponent();
            _controllerNaplacivanje = new ControllerNaplacivanje(this);
            _controllerNaplacivanje.initData(porudzbina);
        }
    }
}
