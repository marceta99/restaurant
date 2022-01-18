
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

namespace Restaurant.UserControls
{
    public partial class UserControlStolovi : UserControl
    {
        private BindingList<Sto> _stolovi = new BindingList<Sto>();
        private ControllerStolovi _controller; 
       
        public UserControlStolovi()
        {
            InitializeComponent();
            _controller = new ControllerStolovi(this);
            _controller.initData();  

        }
    }
}
