
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
    public partial class UserControlPorucivanje : UserControl
    {
        private ControllerPorucivanje _controllerPorucivanje;
        public UserControlPorucivanje()
        {
             InitializeComponent();
            _controllerPorucivanje = new ControllerPorucivanje(this);
            try
            {
                _controllerPorucivanje.initData();

            }catch(ServerCommunicationException ex)
            {
                throw ex;
                
            }
        }
    }
}
