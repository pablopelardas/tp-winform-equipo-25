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
    public partial class FilterGroup : UserControl
    {
        private List<Filtro> filtros = new List<Filtro>();
        private ComboBox initCboCampo = new ComboBox();
        private ComboBox initCboCriterio = new ComboBox();
        private Label initLblClave = new Label();
        private TextBox initTxtClave = new TextBox();
        private Button initBtnEliminarFiltro = new Button();
        public List<Articulo> ArticulosFiltrados { get; set; }
        private DataGridView _dataGridView;
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
            initBtnEliminarFiltro.BackColor = Color.White;
            initBtnEliminarFiltro.ForeColor = Color.Black;
            initBtnEliminarFiltro.FlatStyle = FlatStyle.Flat;

        }

        public EventHandler OnFilterApplied;
        protected void On_FilterApplied(EventArgs e)
        {
            if (OnFilterApplied != null)
                OnFilterApplied(this, e);
        }

        public EventHandler OnClean;
        protected void On_Clean(EventArgs e)
        {
            if (OnClean != null)
                OnClean(this, e);
        }

        public void Init(List<Articulo> articulos, DataGridView dataGridView)
        {
            ArticulosFiltrados = articulos;
            _dataGridView = dataGridView;
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

            if (btnAgregarFiltro.Visible == false)
            {
                btnAgregarFiltro.Visible = true;
            }

            
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
            cboCampo.SelectedIndexChanged += new EventHandler(cboCampo_SelectedIndexChanged);
            foreach (DataGridViewColumn col in _dataGridView.Columns)
            {
                cboCampo.Items.Add(col.Name);
            }
            this.Controls.Add(cboCampo);
            ComboBox cboCriterio = new ComboBox();
            cboCriterio.Location = new Point(initCboCriterio.Location.X, initCboCriterio.Location.Y + (index * 30));
            cboCriterio.Size = initCboCriterio.Size;
            cboCriterio.DropDownStyle = initCboCriterio.DropDownStyle;
            cboCriterio.Name = "cboCriterio" + filtro.Id;
            cboCriterio.SelectedIndexChanged += new EventHandler(cboCriterio_SelectedIndexChanged);
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
            txtClave.TextChanged += new EventHandler(txtClave_TextChanged);
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

            if (filtros.Count == 5)
            {
                btnAgregarFiltro.Visible = false;
            }

            btnAgregarFiltro.Location = new Point(btnAgregarFiltro.Location.X, btnAgregarFiltro.Location.Y + 30);

            cboCampo.BringToFront();
            cboCriterio.BringToFront();
            lblClave.BringToFront();
            txtClave.BringToFront();
            btnEliminarFiltro.BringToFront();

        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            string id = cbo.Name.Replace("cboCampo", "");
            Filtro filtro = filtros.Find(x => x.Id == id);
            filtro.Campo = cbo.SelectedItem.ToString();

            ComboBox cboCriterio = (ComboBox)this.Controls.Find("cboCriterio" + id, true)[0];
            cboCriterio.Items.Clear();
            cboCriterio.Text = null;
            cboCriterio.Enabled = true;
            filtro.Criterio = null;

            DataGridViewColumn col = _dataGridView.Columns[filtro.Campo];

            if (col.ValueType == typeof(string) || col.ValueType == typeof(Marca) || col.ValueType == typeof(Categoria))
            {
                cboCriterio.Items.AddRange(new string[] { "Contiene", "No contiene", "Empieza con", "Termina con", "Igual a", "Distinto de" });
            }
            else if (col.ValueType == typeof(int) || col.ValueType == typeof(decimal) || col.ValueType == typeof(float))
            {
                cboCriterio.Items.AddRange(new string[] { "Mayor que", "Menor que", "Igual a", "Distinto de" });
            }
            else if (col.ValueType == typeof(bool))
            {
                cboCriterio.Items.AddRange(new string[] { "Igual a" });
            }
            else
            {
                cboCriterio.Enabled = false;
            }

            TextBox txtClave = (TextBox)this.Controls.Find("txtClave" + id, true)[0];
            txtClave.Text = null;
            txtClave.Enabled = true;
            filtro.Valor = null;
            txtClave.KeyPress += new KeyPressEventHandler(textBoxTypeAllowed);

        }
        private void cboCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            string id = cbo.Name.Replace("cboCriterio", "");
            Filtro filtro = filtros.Find(x => x.Id == id);
            filtro.Criterio = cbo.SelectedItem.ToString();
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string id = txt.Name.Replace("txtClave", "");
            Filtro filtro = filtros.Find(x => x.Id == id);
            filtro.Valor = txt.Text;
        }


        private void textBoxTypeAllowed (object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string id = txt.Name.Replace("txtClave", "");
            Filtro filtro = filtros.Find(x => x.Id == id);
            DataGridViewColumn col = _dataGridView.Columns[filtro.Campo];
            if (col.ValueType == typeof(int) || col.ValueType == typeof(decimal) || col.ValueType == typeof(float))
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
            }
            else if (col.ValueType == typeof(bool))
            {
                if (!char.IsControl(e.KeyChar) && e.KeyChar != '0' && e.KeyChar != '1')
                {
                    e.Handled = true;
                }
            }
            else if (col.ValueType == typeof(string) || col.ValueType == typeof(Marca) || col.ValueType == typeof(Categoria))
            {
                if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            List<Filtro> filtrosLista = new List<Filtro>(filtros);
            filtrosLista.RemoveAll(x => x.Campo == null || x.Criterio == null || x.Valor == null);


            ArticulosFiltrados = negocio.Filtrar(filtrosLista);

            On_FilterApplied(EventArgs.Empty);

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            filtros.Clear();
            this.Controls.Clear();
            InitializeComponent();
            On_Clean(EventArgs.Empty);
        }
    }
}
