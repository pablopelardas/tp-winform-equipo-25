using System;
using System.Collections.Generic;
using System.Configuration;
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
        private List<OpenFileDialog> _openFileDialogList = null;
        private string _localImagesPath = ConfigurationManager.AppSettings["localImagesPath"];
        
        private int _currentImageIndex = 0;
        private bool _isEditMode = false;


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
            btnImagenLocal.Visible = false;
            LoadImage();
        }
        public void InitSlider(ref List<string> images)
        {
            _images = images;
            _isEditMode = true;
            txtUrlImagen.Text = _images[_currentImageIndex];
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

                // Verificar si la imagen es local
                if (File.Exists(url))
                {
                    Image img = Image.FromFile(url);
                    _imageCache[url] = img;
                    return img;
                }
                // verificar si la url es una url valida
                if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    return null;
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                if (pbxImagen.Image == null)
                {
                    pbxImagen.Load("https://i0.wp.com/casagres.com.ar/wp-content/uploads/2022/09/placeholder.png?ssl=1");
                }
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

        private void btnImagenLocal_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "jpg|*.jpg|png|*.png";
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    _images[_currentImageIndex] = ofd.FileName;
                    txtUrlImagen.Text = ofd.FileName;
                    if (_openFileDialogList == null) _openFileDialogList = new List<OpenFileDialog>();
                    _openFileDialogList.Add(ofd);
                    LoadImage();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void GuardarImagenesLocales()
        {
            _imageCache.Clear();
            if(_openFileDialogList != null)
            {
                if (!Directory.Exists(_localImagesPath))
                {
                    Directory.CreateDirectory(_localImagesPath);
                }
                foreach (OpenFileDialog ofd in _openFileDialogList)
                {
                    int index = _images.FindIndex(x => x == ofd.FileName);
                    if (index == -1) continue;
                    string fileName = Path.GetFileName(ofd.FileName);
                    string filePath = Path.Combine(_localImagesPath, fileName);
                    if (File.Exists(filePath))
                    {
                        string hash = String.Empty;
                        for (int i = 0; i < 5; i++)
                        {
                            hash += ((int)(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() % 1000000)).ToString("X2");
                        }

                        filePath = Path.Combine(_localImagesPath, hash + "_" + fileName);
                    }
                    File.Copy(ofd.FileName, filePath, true);
                    ofd.Dispose();


                    _images[index] = filePath;
                }
            }
        }

        private void btnNextImagen_EnabledChanged(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Enabled == true)
            {
                btn.BackColor = Color.FromArgb(255, 255, 255);
                btn.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0);
                btn.ForeColor = Color.FromArgb(0, 0, 0);
            } else
            {
                btn.BackColor = Color.FromArgb(200, 200, 200);
                btn.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            }
        }
    }
}
