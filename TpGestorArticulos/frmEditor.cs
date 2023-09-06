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
            //Images = articulo.Imagenes;
            // Clonar la lista de imagenes para evitar que se modifique el articulo original
            Images = new List<string>(articulo.Imagenes);
            // Inicializamos el slider con las imagenes del articulo
            sliderImagenes.InitSlider(ref Images);
        }

    }

}
