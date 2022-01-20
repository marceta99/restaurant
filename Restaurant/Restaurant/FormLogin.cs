
using Domain;
using Restaurant.Exceptions;
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
    public partial class FormLogin : Form
    {
        
        private ControllerLogin _controllerLogin; 
        public FormLogin()
        {
            InitializeComponent();
            _controllerLogin = new ControllerLogin(this);
            _controllerLogin.initData();
        
        }
    }
}
