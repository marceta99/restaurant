
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

namespace Restaurant.UserControls
{
    public partial class UserControlPorudzbine : UserControl
    {

        private ControllerPorudzbine _controllerPorudzbine;
        public UserControlPorudzbine()
        {
            InitializeComponent();
            _controllerPorudzbine = new ControllerPorudzbine(this);
            try
            {
                _controllerPorudzbine.initData();
            }
            catch (ServerCommunicationException ex)
            {
                throw ex;
            }
        }

        
    }
}
