using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;

namespace TpGestorArticulos
{
    public partial class frmEditor : Form
    {

        private List<string> Images;
        private Dictionary<string, Image> ImageCache = new Dictionary<string, Image>();
        private int CurrentImageIndex = 0;
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
            // TODO: Verificar si es necesario hacer una copia de la lista de imagenes para evitar que se modifique el articulo original
            Images = articulo.Imagenes;
            // Llenamos el campo url y el picturebox con la primer imagen
            loadImage();
            // Deshabilitamos el boton prev si estamos en la primer imagen
            btnPrevImagen.Enabled = CurrentImageIndex > 0;
        }

        private async Task<Image> LoadImageAsync(string url)
        {
            try
            {
                // Si la imagen ya esta en el cache, la devolvemos
                if (ImageCache.ContainsKey(url))
                {
                    return ImageCache[url];
                }
                // Si no esta en el cache, la descargamos
                using (HttpClient httpclient = new HttpClient())
                {
                    byte[] imageData = await httpclient.GetByteArrayAsync(url);
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        // Creamos una imagen a partir de los datos descargados
                        Image img = Image.FromStream(ms);
                        // Agregamos la imagen al cache
                        ImageCache[url] = img;
                        return img;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        private async void loadImage()
        {
            try
            {
                txtUrlImagen.Text = Images[CurrentImageIndex];
                pbxImagen.Image = await LoadImageAsync(Images[CurrentImageIndex]);
                //Si la imagen no cargó, lanzamos una excepcion
                if (pbxImagen.Image == null) throw new Exception();
                
            }
            catch (Exception)
            {
                //Si ocurre una excepción, mostramos la imagen de error por defecto
                pbxImagen.Load("https://i0.wp.com/casagres.com.ar/wp-content/uploads/2022/09/placeholder.png?ssl=1");
                txtUrlImagen.Text = "";
            }
        }

        private void btnEliminarImagen_Click(object sender, EventArgs e)
        {;
            // Eliminamos la imagen actual
            Images.RemoveAt(CurrentImageIndex);
            // Si no quedan imagenes, deshabilitamos el boton eliminar
            if (Images.Count == 0)
            {
                btnEliminarImagen.Enabled = false;
                // Limpiamos el campo url y el picturebox
                pbxImagen.Image = null;
                txtUrlImagen.Text = "";
            }
            // Si la imagen actual es la ultima, retrocedemos una imagen
            if (CurrentImageIndex == Images.Count)
            {
                CurrentImageIndex--;
            }
            // Si no quedan imagenes, deshabilitamos el boton prev
            if (CurrentImageIndex == 0)
            {
                btnPrevImagen.Enabled = false;
            }
            // Cargamos la imagen actual

            loadImage();
        }

        private void btnNextImagen_Click(object sender, EventArgs e)
        {
            // Si la imagen actual es la ultima, agregamos una imagen
            if (CurrentImageIndex == Images.Count - 1)
            {
                // Si la imagen actual esta vacia, no agregamos una imagen, enviamos un mensaje de error
                if (Images[CurrentImageIndex] == "")
                {
                    MessageBox.Show("Debe cargar la imagen actual para crear una nueva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Images.Add("");
                btnEliminarImagen.Enabled = true;
            }
            // Avanzamos una imagen
            CurrentImageIndex++;
            // Habilitamos el boton prev
            btnPrevImagen.Enabled = true;
            loadImage();
        }

        private void btnPrevImagen_Click(object sender, EventArgs e)
        {
            // Si la imagen actual no es la primera, retrocedemos una imagen
            if (CurrentImageIndex > 0)
            {
                CurrentImageIndex--;
                // Si la imagen actual es la primera, deshabilitamos el boton prev
                if (CurrentImageIndex == 0)
                {
                    btnPrevImagen.Enabled = false;
                }
                // Cargamos la imagen actual
                loadImage();
            }
        }

        private void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            // Actualizamos la url de la imagen actual, si no hay imagenes, no hacemos nada
            try
            {
                Images[CurrentImageIndex] = txtUrlImagen.Text;
            }
            catch (Exception)
            {
                return;   
            }
            
        }
    }

}
