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

        }

        private void cargarMrcCtg()
        {
            try
            {
                // Categorias
                CategoriaNegocio categoriasNegocio = new CategoriaNegocio();
                dgvCategorias.DataSource = categoriasNegocio.ListarCategorias();
                dgvCategorias.Columns["Id"].Visible = false;
                foreach (DataGridViewColumn col in dgvCategorias.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // Marcas
                MarcaNegocio marcasNegocio = new MarcaNegocio();
                dgvMarcas.DataSource = marcasNegocio.ListarMarcas();
                dgvMarcas.Columns["Id"].Visible = false;
                foreach (DataGridViewColumn col in dgvMarcas.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void frmMrcCtg_Load(object sender, EventArgs e)
        {
            cargarMrcCtg();


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmMrcCtgAux aux = new frmMrcCtgAux();
            seleccionarIdTitulo(aux);
            aux.idAux = -1;
            aux.ShowDialog();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //falta validacion de si existen articulos con esa categoria

            if (tabControl.SelectedTab.Name == "tabCategorias")
            {
                Categoria categ = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                categoriaNegocio.Eliminar(categ.Id);
            }
            else
            {
                Marca marca = (Marca)dgvCategorias.CurrentRow.DataBoundItem;
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                marcaNegocio.Eliminar(marca.Id);
            }

            cargarMrcCtg();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmMrcCtgAux aux = new frmMrcCtgAux();
            seleccionarIdTitulo(aux);
            aux.ShowDialog();
        }

        private void seleccionarIdTitulo(frmMrcCtgAux aux)
        {
            if (tabControl.SelectedTab.Name == "tabCategorias")
            {
                aux.elemCtg = true;
                Categoria categ = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
                aux.idAux = categ.Id;
                aux.modificarTitulo("Agregar Categoria");
            }
            else 
            {
                aux.elemCtg = false;
                Marca marca = (Marca)dgvCategorias.CurrentRow.DataBoundItem;
                aux.idAux = marca.Id;
                aux.modificarTitulo("Agregar Marca");
            }
        }
    }
}
