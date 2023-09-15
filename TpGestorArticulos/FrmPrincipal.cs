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
        List<Articulo> articulosSinFiltrar = new List<Articulo>();
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            cargarGrilla();
            dgvArticulos.Columns["Precio"].DefaultCellStyle.Format = "C";
            filterGroup.Init(articulosSinFiltrar, dgvArticulos);
            
        }

        private void cargarGrilla()
        {
            try
            {
                ArticulosNegocio negocio = new ArticulosNegocio();
                dgvArticulos.DataSource = negocio.ListarArticulos();
                dgvArticulos.Columns["Precio"].DefaultCellStyle.Format = "C";
                acomodarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmEditor editor = new frmEditor();
            editor.ShowDialog();
            cargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo articulo = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            frmEditor editor = new frmEditor(articulo);
            editor.ShowDialog();
            cargarGrilla();
        }

        private void dgvArticulos_DoubleClick(object sender, EventArgs e)
        {
            Articulo articulo = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            frmDetalle detalle = new frmDetalle(articulo);
            detalle.ShowDialog();
        }

        private void panelContenedor_SizeChanged(object sender, EventArgs e)
        {
            acomodarColumnas();
        }

        private void acomodarColumnas()
        {
            foreach (DataGridViewColumn col in dgvArticulos.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            Articulo articulo = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            negocio.Eliminar(articulo.Id);
            cargarGrilla();
        }
    }
}