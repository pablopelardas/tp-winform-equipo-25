using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TpGestorArticulos
{
    public partial class Slider : UserControl
    {
        private List<string> _images;
        private Dictionary<string, Image> _imageCache = new Dictionary<string, Image>();
        private int _currentImageIndex = 0;
        private bool _isEditMode = false;

        public bool isInitialized { get; set; }

        public Slider()
        {
            InitializeComponent();
        }

        public void InitSlider(List<string> images)
        {
            _images = images;
            // Desactivo los elementos de la interfaz que no se usan en modo visualización
            btnPrevImagen.Enabled = false;
            txtUrlImagen.Visible = false;
            lblUrlImagen.Visible = false;
            btnEliminarImagen.Visible = false;
            txtIndexImagen.Visible = false;
            updateButtonStatus();
            LoadImage();
        }
        public void InitSlider(ref List<string> images)
        {
            _images = images;
            _isEditMode = true;
            txtUrlImagen.Text = _images[_currentImageIndex];
            updateButtonStatus();
            LoadImage();
        }

        private async Task<Image> LoadImageAsync(string url)
        {
            try
            {
                // Si la imagen ya esta en el cache, la devolvemos
                if (_imageCache.TryGetValue(url, out Image imgFromCache))
                {
                    return imgFromCache;
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
                        _imageCache[url] = img;
                        return img;
                    }
                }

            }
            catch (HttpRequestException ex)
            {
                // Handle the specific exception
                Console.WriteLine($"Error downloading image: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle any other exceptions
                Console.WriteLine($"Error loading image: {ex.Message}");
            }
            return null;
        }
        private void updateButtonStatus()
        {
            if (_currentImageIndex == 0) btnPrevImagen.Enabled = false;
            if (_currentImageIndex > 0) btnPrevImagen.Enabled = true;
            if (_currentImageIndex == _images.Count - 1 && !_isEditMode) btnNextImagen.Enabled = false;
            if (_currentImageIndex == _images.Count - 1 && _isEditMode) btnNextImagen.Enabled = true;
            if (_currentImageIndex < _images.Count - 1) btnNextImagen.Enabled = true;
        }
        public async void LoadImage()
        {
            try
            {
                btnPrevImagen.Enabled = false;
                btnNextImagen.Enabled = false;
                pbxImagen.Image = await LoadImageAsync(_images[_currentImageIndex]);
                txtIndexImagen.Text = (_currentImageIndex + 1).ToString();
                if (pbxImagen.Image == null) throw new Exception();
                updateButtonStatus();


            }
            catch (Exception)
            {
                pbxImagen.Load("https://i0.wp.com/casagres.com.ar/wp-content/uploads/2022/09/placeholder.png?ssl=1");
                updateButtonStatus();
            }
        }

        private void btnPrevImagen_Click(object sender, EventArgs e)
        {
            if (_currentImageIndex > 0)
            {
                _currentImageIndex--;
                txtUrlImagen.Text = _images[_currentImageIndex];
                updateButtonStatus();
                LoadImage();
            }
        }

        private void btnNextImagen_Click(object sender, EventArgs e)
        {
            // indice 0 y no hay mas imagenes
            // indice 0 y hay mas imagenes

            // Si la imagen actual es la ultima y estamos en edit mode, creamos una nueva imagen
            if (_isEditMode)
            {
                if (_currentImageIndex == _images.Count - 1)
                {
                    if (_images[_currentImageIndex] == "")
                    {
                        MessageBox.Show("Debe cargar la imagen actual para crear una nueva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _images.Add("");
                    btnEliminarImagen.Enabled = true;
                }
                    _currentImageIndex++;
                    txtUrlImagen.Text = _images[_currentImageIndex];
            }
            if (!_isEditMode)
            {
                if (_currentImageIndex == _images.Count - 1)
                {
                    return;
                }
                _currentImageIndex++;
                // Si la imagen actual es la ultima, deshabilitamos el boton next
            }
            updateButtonStatus();
            LoadImage();
        }

        private void btnEliminarImagen_Click(object sender, EventArgs e)
        {
            int index = _currentImageIndex;
            // Eliminamos la imagen actual
            try
            {
                if (_images.Count == 1)
                {
                    btnEliminarImagen.Enabled = false;
                    // Si estamos en edit mode, limpiamos la imagen actual y el textbox
                    pbxImagen.Image = null;
                    txtUrlImagen.Text = "";
                }
                // Si la imagen actual es la primera, eliminamos para que la siguiente imagen pase a ser la primera
                else if (_currentImageIndex == 0 && _images.Count > 1)
                {
                    _images.RemoveAt(index);
                }
                // Si la imagen no es la primera, cargamos la imagen anterior y eliminamos la actual
                else
                {
                    _currentImageIndex--;
                    _images.RemoveAt(index);
                }
                txtUrlImagen.Text = _images[_currentImageIndex];
                updateButtonStatus();
                LoadImage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            // Si estamos en edit mode, actualizamos la lista de imagenes
            if (_isEditMode)
            {
                _images[_currentImageIndex] = txtUrlImagen.Text;
                LoadImage();
            }
        }

    }
}
