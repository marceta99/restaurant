
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
    public partial class FormIzmenaNaplataStavke : Form
    {
        

        private ContollerIzmenaNaplateStavke _controllerIzmenaNaplate;
        public FormIzmenaNaplataStavke(Porudzbina porudzbina)
        {
            InitializeComponent();
            _controllerIzmenaNaplate = new ContollerIzmenaNaplateStavke(this);
            _controllerIzmenaNaplate.initData(porudzbina);

        }
    }
}
