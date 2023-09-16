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
            frmPrincipal.Enter += new EventHandler(frmPrincipal_Enter);
            frmPrincipal.Show();
            fixPrincipal();

        }

        private void fixPrincipal(bool reload=false)
        {
            frmPrincipal.WindowState = FormWindowState.Maximized;
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
        }
        private void frmPrincipal_OnEditorOpen(object sender, EventArgs e)
        {
            CustomEventArgs args = (CustomEventArgs)e;
            frmEditor frmEditor = args.Articulo != null ? new frmEditor(args.Articulo) : new frmEditor();
            frmEditor.MdiParent = this;
            frmEditor.Show();
            frmEditor.WindowState = FormWindowState.Maximized;
            frmEditor.FormClosing += new FormClosingEventHandler(frmPrincipal_OnEditorClose);

        }
        private void frmPrincipal_OnEditorClose(object sender, FormClosingEventArgs e)
        {
            frmPrincipal.cargarListaDB();
        }
        private void frmPrincipal_Enter(object sender, EventArgs e)
        {
            fixPrincipal();
            foreach (Form frm in this.MdiChildren)
            {
                // Close all other forms except the main form.

                if (frm is frmDetalle || frm is frmEditor)
                {
                    frm.Close();
                }

            }
            
        }
    }
}
