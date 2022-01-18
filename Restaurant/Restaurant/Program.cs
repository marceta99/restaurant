using Restaurant.GuiControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormLogin loginForma = new FormLogin();
            loginForma.ShowDialog();
            DialogResult rezultatLoginForme = loginForma.DialogResult;

            if(rezultatLoginForme == DialogResult.OK)
            {
                Application.Run(new FormMain());
            }

        }
    }
}
