namespace TpGestorArticulos
{
    partial class FilterGroup
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAgregarFiltro = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.gbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAgregarFiltro
            // 
            this.btnAgregarFiltro.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnAgregarFiltro.Location = new System.Drawing.Point(17, 19);
            this.btnAgregarFiltro.Name = "btnAgregarFiltro";
            this.btnAgregarFiltro.Size = new System.Drawing.Size(127, 23);
            this.btnAgregarFiltro.TabIndex = 0;
            this.btnAgregarFiltro.Text = "Agregar nuevo filtro";
            this.btnAgregarFiltro.UseVisualStyleBackColor = true;
            this.btnAgregarFiltro.Click += new System.EventHandler(this.btnAgregarFiltro_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnFiltrar.Location = new System.Drawing.Point(442, 169);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(73, 23);
            this.btnFiltrar.TabIndex = 1;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.btnLimpiar);
            this.gbFiltros.Controls.Add(this.btnFiltrar);
            this.gbFiltros.Controls.Add(this.btnAgregarFiltro);
            this.gbFiltros.ForeColor = System.Drawing.SystemColors.Control;
            this.gbFiltros.Location = new System.Drawing.Point(3, 1);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(532, 203);
            this.gbFiltros.TabIndex = 0;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnLimpiar.Location = new System.Drawing.Point(17, 169);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(104, 23);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar Filtros";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // FilterGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.Controls.Add(this.gbFiltros);
            this.Name = "FilterGroup";
            this.Size = new System.Drawing.Size(541, 209);
            this.gbFiltros.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAgregarFiltro;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.Button btnLimpiar;
    }
}
