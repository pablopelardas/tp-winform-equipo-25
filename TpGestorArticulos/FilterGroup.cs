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


namespace TpGestorArticulos
{
    public partial class FilterGroup : UserControl
    {
        private List<Filtro> filtros = new List<Filtro>();
        public FilterGroup()
        {
            InitializeComponent();
        }

        private void btnAgregarFiltro_Click(object sender, EventArgs e)
        {
            // agregar un nuevo filtro
            // 1. crear un nuevo filtro
            // 2. agregarlo a la lista de filtros
            // 3. agregarlo al panel
            // 4. actualizar el panel

            // 1. crear un nuevo filtro
            Filtro filtro = new Filtro();
            
            // 2. agregarlo a la lista de filtros
            filtros.Add(filtro);

            // crear controles para el filtro
            Label lblCampo = new Label();
            lblCampo.Text = "Campo";
            lblCampo.Location = new Point(0, 0);
            lblCampo.ForeColor = Color.White;
            lblCampo.AutoSize = true;
            lblCampo.Location = new Point(
                lblCampo0.Location.X,
                               lblCampo0.Location.Y + (filtros.Count * 30)
                                              );
            this.Controls.Add(lblCampo);


        }
    }
}
