namespace TpGestorArticulos
{
    partial class frmMrcCtg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNuevoNombre = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.opcActuales = new System.Windows.Forms.ComboBox();
            this.nuevoNomb = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(58, 29);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(227, 16);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Administrador de Marcas/Categorias";
            // 
            // lblNuevoNombre
            // 
            this.lblNuevoNombre.AutoSize = true;
            this.lblNuevoNombre.Location = new System.Drawing.Point(58, 157);
            this.lblNuevoNombre.Name = "lblNuevoNombre";
            this.lblNuevoNombre.Size = new System.Drawing.Size(99, 16);
            this.lblNuevoNombre.TabIndex = 1;
            this.lblNuevoNombre.Text = "Nuevo Nombre";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(58, 91);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(122, 16);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Marcas/Categorias";
            // 
            // opcActuales
            // 
            this.opcActuales.FormattingEnabled = true;
            this.opcActuales.Location = new System.Drawing.Point(185, 88);
            this.opcActuales.Name = "opcActuales";
            this.opcActuales.Size = new System.Drawing.Size(184, 24);
            this.opcActuales.TabIndex = 3;
            // 
            // nuevoNomb
            // 
            this.nuevoNomb.Location = new System.Drawing.Point(185, 154);
            this.nuevoNomb.Name = "nuevoNomb";
            this.nuevoNomb.Size = new System.Drawing.Size(184, 22);
            this.nuevoNomb.TabIndex = 4;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(433, 259);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(333, 259);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmMrcCtg
            // 
            this.ClientSize = new System.Drawing.Size(535, 301);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.nuevoNomb);
            this.Controls.Add(this.opcActuales);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblNuevoNombre);
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmMrcCtg";
            this.Load += new System.EventHandler(this.frmMrcCtg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNuevoNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.ComboBox opcActuales;
        private System.Windows.Forms.TextBox nuevoNomb;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}