﻿namespace TpGestorArticulos
{
    partial class Slider
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
            this.btnNextImagen = new System.Windows.Forms.Button();
            this.btnPrevImagen = new System.Windows.Forms.Button();
            this.pbxImagen = new System.Windows.Forms.PictureBox();
            this.btnEliminarImagen = new System.Windows.Forms.Button();
            this.lblUrlImagen = new System.Windows.Forms.Label();
            this.txtUrlImagen = new System.Windows.Forms.TextBox();
            this.txtIndexImagen = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNextImagen
            // 
            this.btnNextImagen.Location = new System.Drawing.Point(537, 107);
            this.btnNextImagen.Name = "btnNextImagen";
            this.btnNextImagen.Size = new System.Drawing.Size(30, 27);
            this.btnNextImagen.TabIndex = 22;
            this.btnNextImagen.Text = "→";
            this.btnNextImagen.UseVisualStyleBackColor = true;
            this.btnNextImagen.Click += new System.EventHandler(this.btnNextImagen_Click);
            // 
            // btnPrevImagen
            // 
            this.btnPrevImagen.Location = new System.Drawing.Point(32, 107);
            this.btnPrevImagen.Name = "btnPrevImagen";
            this.btnPrevImagen.Size = new System.Drawing.Size(30, 27);
            this.btnPrevImagen.TabIndex = 21;
            this.btnPrevImagen.Text = "←";
            this.btnPrevImagen.UseVisualStyleBackColor = true;
            this.btnPrevImagen.Click += new System.EventHandler(this.btnPrevImagen_Click);
            // 
            // pbxImagen
            // 
            this.pbxImagen.Location = new System.Drawing.Point(142, 31);
            this.pbxImagen.Name = "pbxImagen";
            this.pbxImagen.Size = new System.Drawing.Size(315, 187);
            this.pbxImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxImagen.TabIndex = 20;
            this.pbxImagen.TabStop = false;
            // 
            // btnEliminarImagen
            // 
            this.btnEliminarImagen.Location = new System.Drawing.Point(434, 31);
            this.btnEliminarImagen.Name = "btnEliminarImagen";
            this.btnEliminarImagen.Size = new System.Drawing.Size(22, 22);
            this.btnEliminarImagen.TabIndex = 23;
            this.btnEliminarImagen.Text = "✕";
            this.btnEliminarImagen.UseVisualStyleBackColor = true;
            this.btnEliminarImagen.Click += new System.EventHandler(this.btnEliminarImagen_Click);
            // 
            // lblUrlImagen
            // 
            this.lblUrlImagen.AutoSize = true;
            this.lblUrlImagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUrlImagen.Location = new System.Drawing.Point(139, 233);
            this.lblUrlImagen.Name = "lblUrlImagen";
            this.lblUrlImagen.Size = new System.Drawing.Size(34, 16);
            this.lblUrlImagen.TabIndex = 24;
            this.lblUrlImagen.Text = "URL";
            // 
            // txtUrlImagen
            // 
            this.txtUrlImagen.Location = new System.Drawing.Point(142, 252);
            this.txtUrlImagen.Name = "txtUrlImagen";
            this.txtUrlImagen.Size = new System.Drawing.Size(315, 20);
            this.txtUrlImagen.TabIndex = 25;
            this.txtUrlImagen.TextChanged += new System.EventHandler(this.txtUrlImagen_TextChanged);
            // 
            // txtIndexImagen
            // 
            this.txtIndexImagen.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtIndexImagen.Location = new System.Drawing.Point(142, 31);
            this.txtIndexImagen.Name = "txtIndexImagen";
            this.txtIndexImagen.ReadOnly = true;
            this.txtIndexImagen.Size = new System.Drawing.Size(22, 20);
            this.txtIndexImagen.TabIndex = 26;
            this.txtIndexImagen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Slider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtIndexImagen);
            this.Controls.Add(this.txtUrlImagen);
            this.Controls.Add(this.lblUrlImagen);
            this.Controls.Add(this.btnEliminarImagen);
            this.Controls.Add(this.btnNextImagen);
            this.Controls.Add(this.btnPrevImagen);
            this.Controls.Add(this.pbxImagen);
            this.Name = "Slider";
            this.Size = new System.Drawing.Size(595, 306);
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNextImagen;
        private System.Windows.Forms.Button btnPrevImagen;
        private System.Windows.Forms.PictureBox pbxImagen;
        private System.Windows.Forms.Button btnEliminarImagen;
        private System.Windows.Forms.Label lblUrlImagen;
        private System.Windows.Forms.TextBox txtUrlImagen;
        private System.Windows.Forms.TextBox txtIndexImagen;
    }
}