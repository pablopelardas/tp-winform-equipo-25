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
        List<Articulo> articulosDB = new List<Articulo>();
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            cargarListaDB();
            filterGroup.Init(articulosDB, dgvArticulos);
            filterGroup.OnFilterApplied += new EventHandler(filterGroup_FilterApplied);
            filterGroup.OnClean += new EventHandler(filterGroup_Clean);
            
        }

        private void filterGroup_FilterApplied(object sender, EventArgs e)
        {
            articulosDB = filterGroup.ArticulosFiltrados;
            cargarGrilla();
        }
        private void filterGroup_Clean(object sender, EventArgs e)
        {
            cargarListaDB();
        }

        private void cargarListaDB()
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            articulosDB.Clear();
            articulosDB = negocio.ListarArticulos();
            cargarGrilla();
        }

        private void cargarGrilla(List<Articulo> data = null)
        {
            try
            {
                dgvArticulos.DataSource = null;
                if (data == null)
                {
                    dgvArticulos.DataSource = articulosDB;
                }
                else
                {
                    dgvArticulos.DataSource = data;
                }
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
            cargarListaDB();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un articulo");
                return;
            }
            Articulo articulo = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            frmEditor editor = new frmEditor(articulo);
            editor.ShowDialog();
            cargarListaDB();
        }

        private void dgvArticulos_AbrirDetalle(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un articulo");
                return;
            }
            Articulo articulo = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            frmDetalle detalle = new frmDetalle(articulo);
            detalle.ShowDialog();
        }
        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada = null;
            if (txtBuscador.Text.Length >= 2)
            {
                listaFiltrada = articulosDB.FindAll(X => X.Nombre.ToLower().Contains(txtBuscador.Text.ToLower()) || X.Codigo.ToLower().Contains(txtBuscador.Text.ToLower()) || X.Descripcion.ToLower().Contains(txtBuscador.Text.ToLower()) || X.Categoria.Nombre.ToLower().Contains(txtBuscador.Text.ToLower()) || X.Marca.Nombre.ToLower().Contains(txtBuscador.Text.ToLower()));

            }
            cargarGrilla(listaFiltrada);
        }

        private void panelContenedor_SizeChanged(object sender, EventArgs e)
        {
            acomodarColumnas();
        }

        private void acomodarColumnas()
        {
            dgvArticulos.Columns["Precio"].DefaultCellStyle.Format = "C";
            foreach (DataGridViewColumn col in dgvArticulos.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un articulo");
                return;
            }
            ArticulosNegocio negocio = new ArticulosNegocio();
            Articulo articulo = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            negocio.Eliminar(articulo.Id);
            cargarListaDB();
        }
    }
}