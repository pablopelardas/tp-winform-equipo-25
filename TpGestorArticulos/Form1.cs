using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TpGestorArticulos;
using Dominio;

namespace App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmEditor editor = new frmEditor();
            // articulo de prueba
            Articulo articulo = new Articulo();
            articulo.Nombre = "Articulo de prueba";
            articulo.Descripcion = "Descripcion de prueba";
            articulo.Precio = 100;
            articulo.Categoria = new Categoria();
            articulo.Categoria.Nombre = "Categoria de prueba";
            articulo.Marca = new Marca();
            articulo.Marca.Nombre = "Marca de prueba";
            articulo.Imagenes = new List<string>
            {
                "https://cdn.hobbyconsolas.com/sites/navi.axelspringer.es/public/media/image/2022/11/mandalorian-grogu-2863719.jpg?tf=3840x",
                "https://images-cdn.9gag.com/photo/aOxr922_700b.jpg",
                "https://preview.redd.it/baby-darth-vader-v0-wr94hicpczka1.jpg?auto=webp&s=6c822a8e9ee3501f389ab4a144c9a360ada60c07"
            };
            //editor.LoadArticulo(articulo); // llamamos al metodo frm
            editor.ShowDialog();
        }
    }
}
