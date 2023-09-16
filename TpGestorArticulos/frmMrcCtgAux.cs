using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace TpGestorArticulos
{
    public partial class frmMrcCtgAux : Form
    {
        public frmMrcCtgAux()
        {
            InitializeComponent();
        }
        public int idAux { get; set; }
        public bool elemCtg { get; set; }

        private void btnGuardarAux_Click(object sender, EventArgs e)
        {

            if(validarInput(txtNombreAux.Text))
            {
                if (elemCtg == true)
                {
                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    if (idAux == -1)
                    {
                        Categoria categ = new Categoria();
                        categ.Nombre = txtNombreAux.Text;
                        categoriaNegocio.Agregar(categ);
                    }
                    else
                    {
                        Categoria categ = new Categoria();
                        categ.Id = idAux;
                        categ.Nombre = txtNombreAux.Text;
                        categoriaNegocio.Modificar(categ);
                    }
                }
                else
                {
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    if (idAux == -1)
                    {
                        Marca marca = new Marca();
                        marca.Nombre = txtNombreAux.Text;
                        marcaNegocio.Agregar(marca);
                    }
                    else
                    {
                        Marca marca = new Marca();
                        marca.Id = idAux;
                        marca.Nombre = txtNombreAux.Text;
                        marcaNegocio.Modificar(marca);
                    }
                }

                Close();
            }
        }

        public void modificarTitulo(string titulo)
        {
            if (titulo == "1") lblTituloAux.Text = "Agregar Categoria";
            if (titulo == "2") lblTituloAux.Text = "Agregar Marca";
            if (titulo == "3") lblTituloAux.Text = "Modificar Categoria";
            if (titulo == "4") lblTituloAux.Text = "Modificar Marca";
        }

        private bool validarInput(string txt)
        {
            try
            {
                if (txt.Length == 0)
                {
                    throw new Exception("El nombre no puede estar vacío");
                }
                return true;
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
