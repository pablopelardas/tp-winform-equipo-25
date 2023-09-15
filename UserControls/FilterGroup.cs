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

            ComboBox cboCampo = new ComboBox();
            cboCampo.Location = new Point(
                               cboCampo0.Location.X,
                                              cboCampo0.Location.Y + (filtros.Count * 30)
                                                             );
            cboCampo.Size = cboCampo0.Size;
            cboCampo.DataSource = cboCampo0.DataSource;
            cboCampo.DropDownStyle = cboCampo0.DropDownStyle;
            cboCampo.Name = "cboCampo" + filtros.Count;
            this.Controls.Add(cboCampo);

            ComboBox cboCriterio = new ComboBox();
            cboCriterio.Location = new Point(
                                              cboCriterio0.Location.X,
                                                                                           cboCriterio0.Location.Y + (filtros.Count * 30)
                                                                                                                                                       );
            cboCriterio.Size = cboCriterio0.Size;
            cboCriterio.DropDownStyle = cboCriterio0.DropDownStyle;
            cboCriterio.Name = "cboCriterio" + filtros.Count;
            this.Controls.Add(cboCriterio);

            TextBox txtValor = new TextBox();
            txtValor.Location = new Point(txtClave0.Location.X, txtClave0.Location.Y + (filtros.Count * 30));
            txtValor.Size = txtValor.Size;
            txtValor.Name = "txtValor" + filtros.Count;
            this.Controls.Add(txtValor);

            // mover boton agregar para abajo
            btnAgregarFiltro.Location = new Point(
                               btnAgregarFiltro.Location.X,
                                              btnAgregarFiltro.Location.Y + 30
                                                             );
            // 3. agregarlo al panel

            lblCampo.BringToFront();
            cboCampo.BringToFront();
            cboCriterio.BringToFront();
            txtValor.BringToFront();




        }
    }
}
