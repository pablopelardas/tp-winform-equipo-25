using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace TpGestorArticulos
{
    public partial class frmMrcCtg : Form
    {
        public frmMrcCtg()
        {
            InitializeComponent();

            //botón cancelar:
            this.CancelButton = btnCancelar;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nuevoNombre = nuevoNomb.Text;

            MessageBox.Show(nuevoNombre+" guardado");
        }

        private void frmMrcCtg_Load(object sender, EventArgs e)
        {
            string aux = "Marca";
            
            lblTitulo.Text = "Administrador de "+aux;
            lblNombre.Text = aux;

            List<Marca> marcas = new List<Marca>();
            marcas = ListarMarcas();
            foreach (Marca marca in marcas)
            {
                opcActuales.Items.Add(marca.Nombre);
            }
            
            
        }
    }
}
