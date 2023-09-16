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
        public frmMrcCtg(string tabName)
        {
            InitializeComponent();
            tabControl.SelectedIndex = tabName == "Categorias" ? 0 : 1;
        }

        public void cargarMrcCtg()
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
            string titulo = seleccionarIdTitulo(aux) ? "1" : "2";
            aux.modificarTitulo(titulo);
            aux.idAux = -1;
            aux.ShowDialog();
            cargarMrcCtg();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticulosNegocio negocio = new ArticulosNegocio();

                if (tabControl.SelectedTab.Name == "tabCategorias")
                {
                    if (dgvCategorias.CurrentRow == null)
                    {
                        MessageBox.Show("Por favor seleccione un item a eliminar", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    Categoria categ = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;

                    if (negocio.ValidarArticulosPorMrcCtg(categ.Id, "IdCategoria"))
                    {
                        CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                        categoriaNegocio.Eliminar(categ.Id);
                    }
                    else
                    {
                        MessageBox.Show("No se pueden eliminar categorias relacionadas a un artículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    if (dgvMarcas.CurrentRow == null)
                    {
                        MessageBox.Show("Por favor seleccione un item a eliminar", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    Marca marca = (Marca)dgvMarcas.CurrentRow.DataBoundItem;
                    if (negocio.ValidarArticulosPorMrcCtg(marca.Id, "IdMarca"))
                    {
                        MarcaNegocio marcaNegocio = new MarcaNegocio();
                        marcaNegocio.Eliminar(marca.Id);
                    }
                    else
                    {
                        MessageBox.Show("No se pueden eliminar marcas relacionadas a un artículo.");
                    }
                }

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Por favor seleccione un item a modificar","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            cargarMrcCtg();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmMrcCtgAux aux = new frmMrcCtgAux();
            string titulo = seleccionarIdTitulo(aux)? "3":"4";
            aux.modificarTitulo(titulo);
            if (aux.idAux == -1) MessageBox.Show("Por favor seleccione un item a modificar", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else aux.ShowDialog();
            cargarMrcCtg();
        }

        private bool seleccionarIdTitulo(frmMrcCtgAux aux)
        {   
            try
            {
                if (tabControl.SelectedTab.Name == "tabCategorias")
                {
                    aux.elemCtg = true;
                    aux.modificarTitulo("Agregar Categoria");
                    if (dgvCategorias.CurrentRow == null) aux.idAux = -1;
                    else aux.idAux = ((Categoria)dgvCategorias.CurrentRow.DataBoundItem).Id;
                }
                else
                {
                    aux.elemCtg = false;
                    aux.modificarTitulo("Agregar Marca");
                    if (dgvMarcas.CurrentRow == null) aux.idAux = -1;
                    else aux.idAux = ((Marca)dgvMarcas.CurrentRow.DataBoundItem).Id;
                }

                return aux.elemCtg;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                aux.idAux = -1;
                return false;
            }
        }
    }
}