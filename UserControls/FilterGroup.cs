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
        private ComboBox initCboCampo = new ComboBox();
        private ComboBox initCboCriterio = new ComboBox();
        private Label initLblClave = new Label();
        private TextBox initTxtClave = new TextBox();
        private Button initBtnEliminarFiltro = new Button();
        private List<Articulo> _articulos;
        private List<Articulo> _articulosSinFiltrar;
        private DataGridView _dataGridView;
        private List<string> campos = new List<string>();
        public FilterGroup()
        {
            InitializeComponent();
            initCboCampo.Location = new Point(18, 19);
            initCboCampo.Size = new Size(121, 21);
            initCboCampo.DropDownStyle = ComboBoxStyle.DropDownList;

            initCboCriterio.Location =  new Point(161, 19);
            initCboCriterio.Size = new Size(121, 21);
            initCboCriterio.DropDownStyle = ComboBoxStyle.DropDownList;

            initLblClave.Location = new Point(307, 24);
            initLblClave.Size = new Size(40, 13);
            initLblClave.Text = "Clave:";
            initLblClave.ForeColor = Color.White;

            initTxtClave.Location = new Point(353, 19);
            initTxtClave.Size = new Size(120, 20);

            initBtnEliminarFiltro.Location = new Point(496, 19);
            initBtnEliminarFiltro.Size = new Size(23, 23);
            initBtnEliminarFiltro.Text = "X";
            initBtnEliminarFiltro.BackColor = Color.Red;
            initBtnEliminarFiltro.ForeColor = Color.White;
            initBtnEliminarFiltro.FlatStyle = FlatStyle.Flat;
            initBtnEliminarFiltro.Click += new EventHandler(btnEliminarFiltro_Click);

        }

        public void Init(List<Articulo> articulos, DataGridView dataGridView)
        {
            _articulos = articulos;
            _articulosSinFiltrar = new List<Articulo>(articulos);
            _dataGridView = dataGridView;
            // Cargar los campos de los filtros
            foreach (DataGridViewColumn col in _dataGridView.Columns)
            {
                campos.Add(col.Name);
            }

        }

        private void btnEliminarFiltro_Click(object sender, EventArgs e)
        {
            // remove the filter from the list
            // and remove the controls from the form
            Button btn = (Button)sender;
            string id = btn.Name.Replace("btnEliminarFiltro", "");
            Filtro filtro = filtros.Find(x => x.Id == id);
            filtros.Remove(filtro);
            this.Controls.RemoveByKey("cboCampo" + id);
            this.Controls.RemoveByKey("cboCriterio" + id);
            this.Controls.RemoveByKey("lblClave" + id);
            this.Controls.RemoveByKey("txtClave" + id);
            this.Controls.RemoveByKey("btnEliminarFiltro" + id);

            // reposition the controls
            foreach (Control control in this.Controls)
            {
                if (control.Location.Y > btn.Location.Y)
                {
                    control.Location = new Point(control.Location.X, control.Location.Y - 30);
                }
            }

            btnAgregarFiltro.Location = new Point(btnAgregarFiltro.Location.X, btnAgregarFiltro.Location.Y - 30);

            
        }

        private void btnAgregarFiltro_Click(object sender, EventArgs e)
        {

            Filtro filtro = new Filtro();
            filtro.Id = Guid.NewGuid().ToString();

            
            filtros.Add(filtro);
            int index = filtros.Count - 1;

            ComboBox cboCampo = new ComboBox();
            cboCampo.Location = new Point(initCboCampo.Location.X, initCboCampo.Location.Y + (index * 30));
            cboCampo.Size = initCboCampo.Size;
            cboCampo.DropDownStyle = initCboCampo.DropDownStyle;
            cboCampo.Name = "cboCampo" + filtro.Id;
            this.Controls.Add(cboCampo);
            cboCampo.Items.AddRange(campos.ToArray());

            ComboBox cboCriterio = new ComboBox();
            cboCriterio.Location = new Point(initCboCriterio.Location.X, initCboCriterio.Location.Y + (index * 30));
            cboCriterio.Size = initCboCriterio.Size;
            cboCriterio.DropDownStyle = initCboCriterio.DropDownStyle;
            cboCriterio.Name = "cboCriterio" + filtro.Id;
            this.Controls.Add(cboCriterio);

            Label lblClave = new Label();
            lblClave.Location = new Point(initLblClave.Location.X, initLblClave.Location.Y + (index * 30));
            lblClave.Size = initLblClave.Size;
            lblClave.Text = initLblClave.Text;
            lblClave.Name = "lblClave" + filtro.Id;
            lblClave.ForeColor = initLblClave.ForeColor;
            this.Controls.Add(lblClave);

            TextBox txtClave = new TextBox();
            txtClave.Location = new Point(initTxtClave.Location.X, initTxtClave.Location.Y + (index * 30));
            txtClave.Size = initTxtClave.Size;
            txtClave.Name = "txtClave" + filtro.Id;
            this.Controls.Add(txtClave);

            Button btnEliminarFiltro = new Button();
            btnEliminarFiltro.Location = new Point(initBtnEliminarFiltro.Location.X, initBtnEliminarFiltro.Location.Y + (index * 30));
            btnEliminarFiltro.Size = initBtnEliminarFiltro.Size;
            btnEliminarFiltro.Text = initBtnEliminarFiltro.Text;
            btnEliminarFiltro.Name = "btnEliminarFiltro" + filtro.Id;
            btnEliminarFiltro.Click += new EventHandler(btnEliminarFiltro_Click);
            btnEliminarFiltro.BackColor = initBtnEliminarFiltro.BackColor;
            btnEliminarFiltro.ForeColor = initBtnEliminarFiltro.ForeColor;
            btnEliminarFiltro.FlatStyle = initBtnEliminarFiltro.FlatStyle;
            this.Controls.Add(btnEliminarFiltro);

            btnAgregarFiltro.Location = new Point(btnAgregarFiltro.Location.X, btnAgregarFiltro.Location.Y + 30);

            cboCampo.BringToFront();
            cboCriterio.BringToFront();
            lblClave.BringToFront();
            txtClave.BringToFront();
            btnEliminarFiltro.BringToFront();

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
