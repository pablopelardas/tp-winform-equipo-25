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
        private int _idArticulo = -1;
        public frmEditor()
        {
            InitializeComponent();
        }

        public void LoadArticulo(Articulo articulo)
        {  
            // Llenamos los datos del formulario con los datos del articulo
            txtNombre.Text = articulo.Nombre.Length > 0 ? articulo.Nombre : "";
            rtxtDescripcion.Text = articulo.Descripcion.Length > 0 ? articulo.Descripcion : "";
            txtPrecio.Text = articulo.Precio > 0 ? articulo.Precio.ToString() : "";
            cbxCategoria.SelectedIndex = articulo.Categoria != null ? cbxCategoria.FindStringExact(articulo.Categoria.Nombre) : -1;
            cbxMarca.SelectedIndex = articulo.Marca != null ? cbxMarca.FindStringExact(articulo.Marca.Nombre) : -1;
            // Clonar la lista de imagenes para evitar que se modifique el articulo original
            _images = new List<string>(articulo.Imagenes);
            this.Text = "Modificar Artículo";
            _idArticulo = articulo.Id;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validamos los datos del formulario
            if (ValidarDatos())
            {
                // Creamos un articulo con los datos del formulario
                Articulo articulo = new Articulo();
                try
                {
                    articulo.Nombre = txtNombre.Text;
                    articulo.Descripcion = rtxtDescripcion.Text;
                    articulo.Precio = float.Parse(txtPrecio.Text);
                    articulo.Categoria = (Categoria)cbxCategoria.SelectedItem;
                    articulo.Marca = (Marca)cbxMarca.SelectedItem;
                    articulo.Imagenes = _images;
                    // Guardamos el articulo en la base de datos
                    ArticulosNegocio articulosNegocio = new ArticulosNegocio();
                    if (_idArticulo != -1)
                    {
                        articulo.Id = _idArticulo;
                        articulosNegocio.Modificar(articulo);
                    }
                    else articulosNegocio.Agregar(articulo);
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
            // Validamos que el nombre no este vacio
            try
            {
                if (txtNombre.Text.Length == 0)
                {
                    MessageBox.Show("El nombre no puede estar vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                // Validamos que la descripcion no este vacia
                if (rtxtDescripcion.Text.Length == 0)
                {
                    MessageBox.Show("La descripcion no puede estar vacia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                // Validamos que el precio sea un numero
                if (!float.TryParse(txtPrecio.Text, out float precio))
                {
                    MessageBox.Show("El precio debe ser un numero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                // Validamos que el precio sea mayor a 0
                if (float.Parse(txtPrecio.Text) <= 0)
                {
                    MessageBox.Show("El precio debe ser mayor a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                // Validamos que la categoria no este vacia
                if (cbxCategoria.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar una categoria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                // Validamos que la marca no este vacia
                if (cbxMarca.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar una marca", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
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
            // verificamos si ya hay imagenes cargadas
            if (_images == null)
            {
                _images = new List<string>();
                _images.Add("");
            };
            sliderImagenes.InitSlider(ref _images);
            // Cargamos las categorias y marcas en los combobox
        }
    }

}
