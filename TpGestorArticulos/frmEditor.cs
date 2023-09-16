using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace TpGestorArticulos
{
    public partial class frmEditor : Form
    {
        private List<string> _images;
        private Articulo _articulo;
        public frmEditor()
        {
            InitializeComponent();
        }

        public frmEditor(Articulo articulo)
        {
            InitializeComponent();
            this.Text = "Modificar Artículo";
            _articulo = articulo;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validamos los datos del formulario
            if (ValidarDatos())
            {
                // Creamos un articulo con los datos del formulario
                try
                {
                    if (_articulo == null) _articulo = new Articulo();
                    _articulo.Nombre = txtNombre.Text;
                    _articulo.Codigo = txtCodigo.Text;
                    _articulo.Descripcion = rtxtDescripcion.Text;
                    _articulo.Precio = float.Parse(txtPrecio.Text);
                    _articulo.Categoria = (Categoria)cbxCategoria.SelectedItem;
                    _articulo.Marca = (Marca)cbxMarca.SelectedItem;
                    sliderImagenes.GuardarImagenesLocales();
                    _articulo.Imagenes = _images;
                    // Guardamos el articulo en la base de datos
                    ArticulosNegocio articulosNegocio = new ArticulosNegocio();
                    if (_articulo.Id != -1)
                    {
                        articulosNegocio.Modificar(_articulo);
                    }
                    else articulosNegocio.Agregar(_articulo);
                    // Cerramos el formulario
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private bool ValidarDatos()
        {
            try
            {
                if (txtNombre.Text.Length == 0)
                {
                    throw new Exception("El nombre no puede estar vacío");
                }
                if (txtCodigo.Text.Length == 0)
                {
                    throw new Exception("El código no puede estar vacío");
                }
                if (rtxtDescripcion.Text.Length == 0)
                {
                    throw new Exception("La descripción no puede estar vacía");
                }
                if (!float.TryParse(txtPrecio.Text, out float precio))
                {
                    throw new Exception("El precio debe ser un numero");
                }
                if (float.Parse(txtPrecio.Text) <= 0)
                {
                    throw new Exception("El precio debe ser mayor a 0");
                }
                if ((int)cbxCategoria.SelectedValue == -1)
                {
                    throw new Exception("Por favor seleccione una categoria");
                }
                if ((int)cbxMarca.SelectedValue == -1)
                {
                    throw new Exception("Por favor seleccione una marca");
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        private void frmEditor_Load(object sender, EventArgs e)
        {
            cargarCategorias();
            cargarMarcas();
            if (_articulo != null)
            {
                txtNombre.Text = _articulo.Nombre.Length > 0 ? _articulo.Nombre : "";
                rtxtDescripcion.Text = _articulo.Descripcion.Length > 0 ? _articulo.Descripcion : "";
                txtPrecio.Text = _articulo.Precio > 0 ? _articulo.Precio.ToString() : "";
                cbxCategoria.SelectedValue = _articulo.Categoria.Id;
                if (cbxCategoria.SelectedValue == null) cbxCategoria.SelectedValue = -1;
                cbxMarca.SelectedValue = _articulo.Marca.Id;
                if (cbxMarca.SelectedValue == null) cbxMarca.SelectedValue = -1;
                txtCodigo.Text = _articulo.Codigo.Length > 0 ? _articulo.Codigo : "";
                _images = new List<string>(_articulo.Imagenes);
                if (_images.Count == 0)
                    _images.Add("");

            }
            else
            {
                // Inicializamos la lista de imagenes
                _articulo = new Articulo();
                _articulo.Categoria = cbxCategoria.SelectedItem as Categoria;
                _articulo.Marca = cbxMarca.SelectedItem as Marca;
                _images = new List<string>();
                _images.Add("");
            }
            sliderImagenes.InitSlider(ref _images);

        }
        private void cargarMarcas()
        {
            int idMarca = -1;
            if (_articulo != null)
            {
                idMarca = _articulo.Marca.Id;
            }
            MarcaNegocio marcasNegocio = new MarcaNegocio();
            List<Marca> marcas = marcasNegocio.ListarMarcas();
            marcas.Insert(0, new Marca(-1, "Seleccione una marca"));
            cbxMarca.DataSource = marcas;
            cbxMarca.ValueMember = "Id";
            cbxMarca.DisplayMember = "Nombre";
            cbxMarca.SelectedValue = idMarca;
        }
        private void cargarCategorias()
        {
            int idCategoria = -1;
            if (_articulo != null)
            {
                idCategoria = _articulo.Categoria.Id;
            }
            CategoriaNegocio categoriasNegocio = new CategoriaNegocio();
            List<Categoria> categorias = categoriasNegocio.ListarCategorias();
            categorias.Insert(0, new Categoria(-1, "Seleccione una categoria"));
            cbxCategoria.DataSource = categorias;
            cbxCategoria.ValueMember = "Id";
            cbxCategoria.DisplayMember = "Nombre";
            cbxCategoria.SelectedValue = idCategoria;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("¿Esta seguro que desea cancelar los cambios que realizó?", "Cancelar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            Close();
        }

        private void abrirEditorMrcCtg(object sender, EventArgs e)
        {
            string tabName = ((Button)sender).Name.Replace("btn", "");
            frmMrcCtg mrcCtg = new frmMrcCtg(tabName);
            mrcCtg.ShowDialog();
            if (tabName == "Categorias") cargarCategorias();
            else cargarMarcas();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_articulo == null) return;
            ComboBox cbx = (ComboBox)sender;
            string tabName = cbx.Name.Replace("cbx", "");
            if (tabName == "Categoria")
            {
                _articulo.Categoria = cbx.SelectedItem as Categoria;
            }
            else _articulo.Marca = cbx.SelectedItem as Marca;
        }
    }
}
