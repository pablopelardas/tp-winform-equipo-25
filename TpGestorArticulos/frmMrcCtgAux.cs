﻿using System;
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

            //falta validar
            if(elemCtg == true)
            {
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                if(idAux == -1)
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
        }

        public void modificarTitulo(string titulo)
        {
            lblTituloAux.Text = titulo;
        }
    }
}
