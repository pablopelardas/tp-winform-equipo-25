using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace TpGestorArticulos
{
    public partial class Slider : UserControl
    {
        private List<string> Images;
        private Dictionary<string, Image> ImageCache = new Dictionary<string, Image>();
        private int CurrentImageIndex = 0;
        private bool isEditMode = false;
        public Slider()
        {
            InitializeComponent();
        }

        public void InitSlider(List<string> images)
        {
            Images = images;
            loadImage();
            btnPrevImagen.Enabled = CurrentImageIndex > 0;
            txtUrlImagen.Visible = false;
            lblUrlImagen.Visible = false;
            btnEliminarImagen.Visible = false;
            txtIndexImagen.Visible = false;
        }
        public void InitSlider(ref List<string> images)
        {
            Images = images;
            isEditMode = true;
            loadImage();
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

        public async void loadImage()
        {
            try
            {
                txtUrlImagen.Text = Images[CurrentImageIndex];
                pbxImagen.Image = await LoadImageAsync(Images[CurrentImageIndex]);
                txtIndexImagen.Text = (CurrentImageIndex + 1).ToString();
                if (pbxImagen.Image == null) throw new Exception();

            }
            catch (Exception)
            {
                //Si ocurre una excepción, mostramos la imagen de error por defecto
                pbxImagen.Load("https://i0.wp.com/casagres.com.ar/wp-content/uploads/2022/09/placeholder.png?ssl=1");
            }
        }

        private void btnPrevImagen_Click(object sender, EventArgs e)
        {
            if (CurrentImageIndex > 0)
            {
                CurrentImageIndex--;
                // Si la imagen actual es la primera, deshabilitamos el boton prev
                if (CurrentImageIndex == 0) btnPrevImagen.Enabled = false;        
                loadImage();
            }
        }

        private void btnNextImagen_Click(object sender, EventArgs e)
        {
            // Si la imagen actual es la ultima y estamos en edit mode, agregamos una imagen 
            if (CurrentImageIndex == Images.Count - 1 && isEditMode)
            {
                if (Images[CurrentImageIndex] == "")
                {
                    MessageBox.Show("Debe cargar la imagen actual para crear una nueva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Images.Add("");
                btnEliminarImagen.Enabled = true;
            }
            CurrentImageIndex++;

            // Si la imagen actual es la ultima y NO estamos en edit mode, deshabilitamos el boton next
            if (CurrentImageIndex == Images.Count - 1 && !isEditMode) btnNextImagen.Enabled = false;
            btnPrevImagen.Enabled = true;
            loadImage();
        }

        private void btnEliminarImagen_Click(object sender, EventArgs e)
        {
            int index = CurrentImageIndex;
            // Eliminamos la imagen actual
            try
            {
                // console log list
                // Si no quedan imagenes, deshabilitamos el boton eliminar
                if (Images.Count == 1)
                {
                    btnEliminarImagen.Enabled = false;
                    // Si estamos en edit mode, limpiamos la imagen actual y el textbox
                    pbxImagen.Image = null;
                    txtUrlImagen.Text = "";
                    btnPrevImagen.Enabled = false;
                }
                // Si la imagen actual es la primera, avanzamos una imagen
                else if (CurrentImageIndex == 0 && Images.Count > 1)
                {
                    Images.RemoveAt(index);
                    loadImage();
                }
                // Si la imagen actual es la ultima, retrocedemos una imagen
                else 
                {
                    CurrentImageIndex-- ;
                    Images.RemoveAt(index);
                }


                loadImage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            // Si estamos en edit mode, actualizamos la lista de imagenes
            if (isEditMode)
            {
                Images[CurrentImageIndex] = txtUrlImagen.Text;
                loadImage();
            }
        }

    }
}
