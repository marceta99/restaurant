using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerProject
{
    public partial class FormServer : Form
    {
        private Server _server; 
        public FormServer()
        {
            InitializeComponent();
            buttonPokreniServer.Enabled = true;
            buttonZaustaviServer.Enabled = false; 
        }

        private void buttonPokreniServer_Click(object sender, EventArgs e)
        {
            try
            {
                _server = new Server();
                _server.Start();

                Thread nit1 = new Thread(_server.Listen);
                nit1.Start();
                buttonPokreniServer.Enabled = false;
                buttonZaustaviServer.Enabled = true;
            
            }catch(SocketException ex) //npr greska ce da pukne ako je port na kome hocemo da pokrenemo server vec zauzet
            {
                Debug.WriteLine(">>>" + ex.Message);
            }

        }

        private void buttonZaustaviServer_Click(object sender, EventArgs e)
        {
            _server.Stop();
            buttonPokreniServer.Enabled = true;
            buttonZaustaviServer.Enabled = false; 
        }
    }
}
