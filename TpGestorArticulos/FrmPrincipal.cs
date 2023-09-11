using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TpGestorArticulos
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                ArticulosNegocio negocio = new ArticulosNegocio();
                dgvArticulos.DataSource = negocio.ListarArticulos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // abre la ventana
            frmEditor editor = new frmEditor();
            editor.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmEditor editor = new frmEditor();
            Articulo articulo = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            editor.LoadArticulo(articulo);
            editor.ShowDialog();
        }

        private void dgvArticulos_DoubleClick(object sender, EventArgs e)
        {
            // get selected item
            Articulo articulo = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            // open editor
            frmDetalle detalle = new frmDetalle();
            //editor.LoadArticulo(articulo);
            detalle.ShowDialog();
        }
    }
}
