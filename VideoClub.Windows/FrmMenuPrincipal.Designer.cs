
namespace VideoClub.Windows
{
    partial class FrmMenuPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.ProvinciasButton = new System.Windows.Forms.Button();
            this.SalirButton = new System.Windows.Forms.Button();
            this.SoportesButton = new System.Windows.Forms.Button();
            this.EstadosButton = new System.Windows.Forms.Button();
            this.CalificacionesButton = new System.Windows.Forms.Button();
            this.GenerosButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProvinciasButton
            // 
            this.ProvinciasButton.Location = new System.Drawing.Point(12, 12);
            this.ProvinciasButton.Name = "ProvinciasButton";
            this.ProvinciasButton.Size = new System.Drawing.Size(97, 23);
            this.ProvinciasButton.TabIndex = 1;
            this.ProvinciasButton.Text = "Provincias";
            this.ProvinciasButton.UseVisualStyleBackColor = true;
            this.ProvinciasButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // SalirButton
            // 
            this.SalirButton.Image = global::VideoClub.Windows.Properties.Resources.Salir;
            this.SalirButton.Location = new System.Drawing.Point(686, 284);
            this.SalirButton.Name = "SalirButton";
            this.SalirButton.Size = new System.Drawing.Size(40, 41);
            this.SalirButton.TabIndex = 0;
            this.SalirButton.UseVisualStyleBackColor = true;
            this.SalirButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // SoportesButton
            // 
            this.SoportesButton.Location = new System.Drawing.Point(12, 41);
            this.SoportesButton.Name = "SoportesButton";
            this.SoportesButton.Size = new System.Drawing.Size(97, 23);
            this.SoportesButton.TabIndex = 2;
            this.SoportesButton.Text = "Soportes";
            this.SoportesButton.UseVisualStyleBackColor = true;
            this.SoportesButton.Click += new System.EventHandler(this.SoportesButton_Click);
            // 
            // EstadosButton
            // 
            this.EstadosButton.Location = new System.Drawing.Point(12, 70);
            this.EstadosButton.Name = "EstadosButton";
            this.EstadosButton.Size = new System.Drawing.Size(97, 23);
            this.EstadosButton.TabIndex = 3;
            this.EstadosButton.Text = "Estados";
            this.EstadosButton.UseVisualStyleBackColor = true;
            this.EstadosButton.Click += new System.EventHandler(this.EstadosButton_Click);
            // 
            // CalificacionesButton
            // 
            this.CalificacionesButton.Location = new System.Drawing.Point(13, 129);
            this.CalificacionesButton.Name = "CalificacionesButton";
            this.CalificacionesButton.Size = new System.Drawing.Size(96, 23);
            this.CalificacionesButton.TabIndex = 4;
            this.CalificacionesButton.Text = "Calificaciones";
            this.CalificacionesButton.UseVisualStyleBackColor = true;
            this.CalificacionesButton.Click += new System.EventHandler(this.CalificacionesButton_Click);
            // 
            // GenerosButton
            // 
            this.GenerosButton.Location = new System.Drawing.Point(12, 100);
            this.GenerosButton.Name = "GenerosButton";
            this.GenerosButton.Size = new System.Drawing.Size(97, 23);
            this.GenerosButton.TabIndex = 5;
            this.GenerosButton.Text = "Generos";
            this.GenerosButton.UseVisualStyleBackColor = true;
            this.GenerosButton.Click += new System.EventHandler(this.GenerosButton_Click_1);
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 337);
            this.ControlBox = false;
            this.Controls.Add(this.GenerosButton);
            this.Controls.Add(this.CalificacionesButton);
            this.Controls.Add(this.EstadosButton);
            this.Controls.Add(this.SoportesButton);
            this.Controls.Add(this.ProvinciasButton);
            this.Controls.Add(this.SalirButton);
            this.Name = "FrmMenuPrincipal";
            this.Text = "Menu Principal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SalirButton;
        private System.Windows.Forms.Button ProvinciasButton;
        private System.Windows.Forms.Button SoportesButton;
        private System.Windows.Forms.Button EstadosButton;
        private System.Windows.Forms.Button CalificacionesButton;
        private System.Windows.Forms.Button GenerosButton;
    }
}

