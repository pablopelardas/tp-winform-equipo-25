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
    public partial class frmPadre : Form
    {
        public frmPadre()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void frmPadre_Load(object sender, EventArgs e)
        {
            FrmPrincipal frmPrincipal = new FrmPrincipal();
            frmPrincipal.MdiParent = this;
            frmPrincipal.Show();
            frmPrincipal.WindowState = FormWindowState.Maximized;
        }
    }
}
