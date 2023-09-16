using Dominio;
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
    public partial class frmDetalle : Form
    {
        private Articulo _articulo;
        public frmDetalle(Articulo articulo)
        {
            InitializeComponent();
            _articulo = articulo;
        }

        private void frmDetalle_Load(object sender, EventArgs e)
        {
            // Carga los datos del articulo en los controles
            lblCodigo.Text = "Cod: " + _articulo.Codigo;
            lblTitulo.Text = _articulo.Nombre;
            rtxtDescripcion.Text = _articulo.Descripcion;
            // short price to 2 decimal places
            lblPrecio.Text = "$ " + _articulo.Precio.ToString("0.00");
            lblCategoria.Text = _articulo.Categoria.Nombre;
            lblMarca.Text = _articulo.Marca.Nombre;
            List<string> images = _articulo.Imagenes;
            if (images.Count == 0)
            {
                images.Add("");
            }
            Slider.InitSlider(images);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
