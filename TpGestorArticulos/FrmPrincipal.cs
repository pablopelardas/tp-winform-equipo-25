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
                dgvArticulos.Columns["Precio"].DefaultCellStyle.Format = "C";
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
            Articulo articulo = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            frmEditor editor = new frmEditor(articulo);
            editor.ShowDialog();
        }

        private void dgvArticulos_DoubleClick(object sender, EventArgs e)
        {
            Articulo articulo = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            frmDetalle detalle = new frmDetalle(articulo);
            detalle.ShowDialog();
        }
    }
}
