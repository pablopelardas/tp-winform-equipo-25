using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TpGestorArticulos;

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
            Application.Run(new FrmPrincipal());
        }
    }
}
