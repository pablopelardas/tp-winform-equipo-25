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
                    _articulo.Precio = decimal.Parse(txtPrecio.Text);
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
            // Cargamos las categorias y marcas en los combobox
            List<Categoria> categorias = new List<Categoria>();
            List<Marca> marcas = new List<Marca>();
            categorias.Add(new Categoria() { Id = -1, Nombre = "Seleccione una categoria" });
            marcas.Add(new Marca() { Id = -1, Nombre = "Seleccione una marca" });

            // MOCK DATA
            categorias.Add(new Categoria() { Id = 1, Nombre = "Accesorios" });
            categorias.Add(new Categoria() { Id = 2, Nombre = "Almacenamiento" });
            categorias.Add(new Categoria() { Id = 3, Nombre = "Audio" });

            // MOCK DATA
            marcas.Add(new Marca() { Id = 1, Nombre = "Marca 1" });
            marcas.Add(new Marca() { Id = 2, Nombre = "Marca 2" });
            marcas.Add(new Marca() { Id = 3, Nombre = "Marca 3" });

            cbxCategoria.DataSource = categorias;
            cbxCategoria.ValueMember = "Id";
            cbxCategoria.DisplayMember = "Nombre";
            cbxMarca.DataSource = marcas;
            cbxMarca.ValueMember = "Id";
            cbxMarca.DisplayMember = "Nombre";
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
                _images = new List<string>();
                _images.Add("");
            }
            sliderImagenes.InitSlider(ref _images);

        }
    }

}
