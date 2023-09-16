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
            this.lblNombreAux.Location = new System.Drawing.Point(22, 57);
            this.lblNombreAux.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreAux.Name = "lblNombreAux";
            this.lblNombreAux.Size = new System.Drawing.Size(44, 13);
            this.lblNombreAux.TabIndex = 1;
            this.lblNombreAux.Text = "Nombre";
            // 
            // txtNombreAux
            // 
            this.txtNombreAux.Location = new System.Drawing.Point(88, 54);
            this.txtNombreAux.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombreAux.Name = "txtNombreAux";
            this.txtNombreAux.Size = new System.Drawing.Size(132, 20);
            this.txtNombreAux.TabIndex = 2;
            // 
            // btnGuardarAux
            // 
            this.btnGuardarAux.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnGuardarAux.Location = new System.Drawing.Point(164, 98);
            this.btnGuardarAux.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardarAux.Name = "btnGuardarAux";
            this.btnGuardarAux.Size = new System.Drawing.Size(68, 27);
            this.btnGuardarAux.TabIndex = 3;
            this.btnGuardarAux.Text = "Guardar";
            this.btnGuardarAux.UseVisualStyleBackColor = true;
            this.btnGuardarAux.Click += new System.EventHandler(this.btnGuardarAux_Click);
            // 
            // lblTituloAux
            // 
            this.lblTituloAux.AutoSize = true;
            this.lblTituloAux.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloAux.Location = new System.Drawing.Point(22, 15);
            this.lblTituloAux.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTituloAux.Name = "lblTituloAux";
            this.lblTituloAux.Size = new System.Drawing.Size(49, 17);
            this.lblTituloAux.TabIndex = 0;
            this.lblTituloAux.Text = "Titulo";
            // 
            // frmMrcCtgAux
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(250, 147);
            this.Controls.Add(this.btnGuardarAux);
            this.Controls.Add(this.txtNombreAux);
            this.Controls.Add(this.lblNombreAux);
            this.Controls.Add(this.lblTituloAux);
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(266, 186);
            this.MinimumSize = new System.Drawing.Size(266, 186);
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