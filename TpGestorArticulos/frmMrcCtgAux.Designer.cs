namespace TpGestorArticulos
{
    partial class frmMrcCtgAux
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
            this.lblNombreAux = new System.Windows.Forms.Label();
            this.txtNombreAux = new System.Windows.Forms.TextBox();
            this.btnGuardarAux = new System.Windows.Forms.Button();
            this.lblTituloAux = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNombreAux
            // 
            this.lblNombreAux.AutoSize = true;
            this.lblNombreAux.Location = new System.Drawing.Point(29, 70);
            this.lblNombreAux.Name = "lblNombreAux";
            this.lblNombreAux.Size = new System.Drawing.Size(56, 16);
            this.lblNombreAux.TabIndex = 1;
            this.lblNombreAux.Text = "Nombre";
            // 
            // txtNombreAux
            // 
            this.txtNombreAux.Location = new System.Drawing.Point(117, 67);
            this.txtNombreAux.Name = "txtNombreAux";
            this.txtNombreAux.Size = new System.Drawing.Size(175, 22);
            this.txtNombreAux.TabIndex = 2;
            // 
            // btnGuardarAux
            // 
            this.btnGuardarAux.Location = new System.Drawing.Point(219, 120);
            this.btnGuardarAux.Name = "btnGuardarAux";
            this.btnGuardarAux.Size = new System.Drawing.Size(91, 33);
            this.btnGuardarAux.TabIndex = 3;
            this.btnGuardarAux.Text = "Guardar";
            this.btnGuardarAux.UseVisualStyleBackColor = true;
            this.btnGuardarAux.Click += new System.EventHandler(this.btnGuardarAux_Click);
            // 
            // lblTituloAux
            // 
            this.lblTituloAux.AutoSize = true;
            this.lblTituloAux.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloAux.Location = new System.Drawing.Point(29, 18);
            this.lblTituloAux.Name = "lblTituloAux";
            this.lblTituloAux.Size = new System.Drawing.Size(56, 20);
            this.lblTituloAux.TabIndex = 0;
            this.lblTituloAux.Text = "Titulo";
            // 
            // frmMrcCtgAux
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 173);
            this.Controls.Add(this.btnGuardarAux);
            this.Controls.Add(this.txtNombreAux);
            this.Controls.Add(this.lblNombreAux);
            this.Controls.Add(this.lblTituloAux);
            this.MaximumSize = new System.Drawing.Size(350, 220);
            this.MinimumSize = new System.Drawing.Size(350, 220);
            this.Name = "frmMrcCtgAux";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNombreAux;
        private System.Windows.Forms.TextBox txtNombreAux;
        private System.Windows.Forms.Button btnGuardarAux;
        private System.Windows.Forms.Label lblTituloAux;
    }
}