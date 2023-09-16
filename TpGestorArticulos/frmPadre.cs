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
    public partial class frmPadre : Form
    {
        FrmPrincipal frmPrincipal = new FrmPrincipal();
        public frmPadre()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            frmPrincipal.MdiParent = this;
            frmPrincipal.OnDetailOpen += new EventHandler(frmPrincipal_OnDetailOpen);
            frmPrincipal.onEditorOpen += new EventHandler(frmPrincipal_OnEditorOpen);
            frmPrincipal.Show();
        }

        private void frmPadre_Load(object sender, EventArgs e)
        {
            fixPrincipal();
        }

        private void fixPrincipal(bool reload=false)
        {
            frmPrincipal.WindowState = FormWindowState.Maximized;
            if (reload)
            {
                frmPrincipal.cargarListaDB();
            }
        }

        private void frmPadre_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void frmPrincipal_OnDetailOpen(object sender, EventArgs e)
        {
            CustomEventArgs args = (CustomEventArgs)e;
            frmDetalle frmDetalle = new frmDetalle(args.Articulo);
            frmDetalle.MdiParent = this;
            frmDetalle.Show();
            frmDetalle.WindowState = FormWindowState.Maximized;
            frmDetalle.FormClosed += new FormClosedEventHandler(frmCloseWithoutChange);
        }
        private void frmPrincipal_OnEditorOpen(object sender, EventArgs e)
        {
            CustomEventArgs args = (CustomEventArgs)e;
            frmEditor editor = new frmEditor();
            frmEditor frmEditor = args.Articulo != null ? new frmEditor(args.Articulo) : new frmEditor();
            frmEditor.MdiParent = this;
            frmEditor.Show();
            frmEditor.WindowState = FormWindowState.Maximized;
            frmEditor.FormClosed += new FormClosedEventHandler(frmCloseWithChange);
        }
        private void frmCloseWithoutChange(object sender, FormClosedEventArgs e)
        {
            fixPrincipal();
            
        }
        private void frmCloseWithChange(object sender, FormClosedEventArgs e)
        {
            fixPrincipal(true);
        }

    }
}
