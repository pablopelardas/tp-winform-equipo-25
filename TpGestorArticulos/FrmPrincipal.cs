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
            // cargar combo de campos grilla
            cboCampo0.DataSource = dgvArticulos.Columns.Cast<DataGridViewColumn>().Select(x => x.HeaderText).ToList();
            // cargar cboCriterio0
            actualizarCriterios();

        }

        private void actualizarCriterios()
        {
            DataGridViewColumn campo = dgvArticulos.Columns[cboCampo0.SelectedIndex];
            if (campo.ValueType == typeof(string))
            {
                cboCriterio0.DataSource = new List<string> { "Contiene", "Igual" };
            }
            else if (campo.ValueType == typeof(int) || campo.ValueType == typeof(float))
            {
                cboCriterio0.DataSource = new List<string> { "Mayor", "Menor", "Igual" };
            }
            else
            {
                cboCriterio0.DataSource = new List<string>();
            }
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

        private void cboCampo0_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridViewColumn campo = dgvArticulos.Columns[cboCampo0.SelectedIndex];
            if (campo.ValueType == typeof(string))
            {
                cboCriterio0.DataSource = new List<string> { "Contiene", "Igual" };
            }
            else if (campo.ValueType == typeof(int) || campo.ValueType == typeof(float))
            {
                cboCriterio0.DataSource = new List<string> { "Mayor", "Menor", "Igual" };
            }
            else if (campo.ValueType == typeof(Marca) || campo.ValueType == typeof(Categoria))
            {
                cboCriterio0.DataSource = new List<string> { "Contiene", "Igual" };
            }
            else
            {
                cboCriterio0.DataSource = new List<string>();
            }
        }
    }
}