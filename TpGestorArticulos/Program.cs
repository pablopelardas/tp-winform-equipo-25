using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TpGestorArticulos;
using System.Timers;
using System.Runtime.Remoting.Channels;

namespace App
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            ArticulosNegocio artNegocio = new ArticulosNegocio();
            artNegocio.SincronizarImagenes();
            // que lo sincronice cada 5 minutos
            // 
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 300000;
            timer.Elapsed += (sender, e) =>
            {
                artNegocio.SincronizarImagenes();
            };
            timer.Enabled = true;



            Application.Run(new frmPadre());
        }
    }
}
