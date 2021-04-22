
namespace VideoClub.Windows
{
    partial class FrmEmpleadosAE
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
            this.components = new System.ComponentModel.Container();
            this.ProvinciasComboBox = new System.Windows.Forms.ComboBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.LocalidadesComboBox = new System.Windows.Forms.ComboBox();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.DireccionTextBox = new System.Windows.Forms.TextBox();
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblTipoDocumento = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblApellido = new System.Windows.Forms.Label();
            this.ApellidoTextBox = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.lblNumDocumento = new System.Windows.Forms.Label();
            this.NumDocumentoTextBox = new System.Windows.Forms.TextBox();
            this.TipoDocumentoComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ProvinciasComboBox
            // 
            this.ProvinciasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProvinciasComboBox.FormattingEnabled = true;
            this.ProvinciasComboBox.Location = new System.Drawing.Point(81, 213);
            this.ProvinciasComboBox.Name = "ProvinciasComboBox";
            this.ProvinciasComboBox.Size = new System.Drawing.Size(250, 21);
            this.ProvinciasComboBox.TabIndex = 157;
            this.ProvinciasComboBox.SelectedIndexChanged += new System.EventHandler(this.ProvinciasComboBox_SelectedIndexChanged);
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(426, 199);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(56, 13);
            this.lblLocalidad.TabIndex = 168;
            this.lblLocalidad.Text = "Localidad:";
            // 
            // LocalidadesComboBox
            // 
            this.LocalidadesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LocalidadesComboBox.FormattingEnabled = true;
            this.LocalidadesComboBox.Location = new System.Drawing.Point(337, 213);
            this.LocalidadesComboBox.Name = "LocalidadesComboBox";
            this.LocalidadesComboBox.Size = new System.Drawing.Size(250, 21);
            this.LocalidadesComboBox.TabIndex = 158;
            // 
            // lblProvincia
            // 
            this.lblProvincia.AutoSize = true;
            this.lblProvincia.Location = new System.Drawing.Point(172, 197);
            this.lblProvincia.Name = "lblProvincia";
            this.lblProvincia.Size = new System.Drawing.Size(54, 13);
            this.lblProvincia.TabIndex = 167;
            this.lblProvincia.Text = "Provincia:";
            // 
            // DireccionTextBox
            // 
            this.DireccionTextBox.Location = new System.Drawing.Point(81, 161);
            this.DireccionTextBox.MaxLength = 100;
            this.DireccionTextBox.Name = "DireccionTextBox";
            this.DireccionTextBox.Size = new System.Drawing.Size(506, 20);
            this.DireccionTextBox.TabIndex = 156;
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.Location = new System.Drawing.Point(81, 56);
            this.NombreTextBox.MaxLength = 100;
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(250, 20);
            this.NombreTextBox.TabIndex = 153;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(307, 145);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(55, 13);
            this.lblDireccion.TabIndex = 165;
            this.lblDireccion.Text = "Direccion:";
            // 
            // lblTipoDocumento
            // 
            this.lblTipoDocumento.AutoSize = true;
            this.lblTipoDocumento.Location = new System.Drawing.Point(159, 92);
            this.lblTipoDocumento.Name = "lblTipoDocumento";
            this.lblTipoDocumento.Size = new System.Drawing.Size(89, 13);
            this.lblTipoDocumento.TabIndex = 163;
            this.lblTipoDocumento.Text = "Tipo Documento:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(172, 40);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 166;
            this.lblNombre.Text = "Nombre:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(428, 40);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(47, 13);
            this.lblApellido.TabIndex = 166;
            this.lblApellido.Text = "Apellido:";
            // 
            // ApellidoTextBox
            // 
            this.ApellidoTextBox.Location = new System.Drawing.Point(337, 56);
            this.ApellidoTextBox.MaxLength = 100;
            this.ApellidoTextBox.Name = "ApellidoTextBox";
            this.ApellidoTextBox.Size = new System.Drawing.Size(250, 20);
            this.ApellidoTextBox.TabIndex = 153;
            // 
            // CancelButton
            // 
            this.CancelButton.Image = global::VideoClub.Windows.Properties.Resources.Cancelar;
            this.CancelButton.Location = new System.Drawing.Point(415, 280);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(94, 64);
            this.CancelButton.TabIndex = 162;
            this.CancelButton.Text = "Cancelar";
            this.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Image = global::VideoClub.Windows.Properties.Resources.OK;
            this.OkButton.Location = new System.Drawing.Point(162, 280);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(94, 64);
            this.OkButton.TabIndex = 161;
            this.OkButton.Text = "OK";
            this.OkButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // lblNumDocumento
            // 
            this.lblNumDocumento.AutoSize = true;
            this.lblNumDocumento.Location = new System.Drawing.Point(410, 92);
            this.lblNumDocumento.Name = "lblNumDocumento";
            this.lblNumDocumento.Size = new System.Drawing.Size(80, 13);
            this.lblNumDocumento.TabIndex = 164;
            this.lblNumDocumento.Text = "N° Documento:";
            // 
            // NumDocumentoTextBox
            // 
            this.NumDocumentoTextBox.Location = new System.Drawing.Point(337, 108);
            this.NumDocumentoTextBox.MaxLength = 10;
            this.NumDocumentoTextBox.Name = "NumDocumentoTextBox";
            this.NumDocumentoTextBox.Size = new System.Drawing.Size(250, 20);
            this.NumDocumentoTextBox.TabIndex = 155;
            // 
            // TipoDocumentoComboBox
            // 
            this.TipoDocumentoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipoDocumentoComboBox.FormattingEnabled = true;
            this.TipoDocumentoComboBox.Location = new System.Drawing.Point(81, 107);
            this.TipoDocumentoComboBox.Name = "TipoDocumentoComboBox";
            this.TipoDocumentoComboBox.Size = new System.Drawing.Size(250, 21);
            this.TipoDocumentoComboBox.TabIndex = 157;
            // 
            // FrmEmpleadosAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.ControlBox = false;
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.TipoDocumentoComboBox);
            this.Controls.Add(this.ProvinciasComboBox);
            this.Controls.Add(this.lblLocalidad);
            this.Controls.Add(this.LocalidadesComboBox);
            this.Controls.Add(this.lblProvincia);
            this.Controls.Add(this.NumDocumentoTextBox);
            this.Controls.Add(this.lblNumDocumento);
            this.Controls.Add(this.DireccionTextBox);
            this.Controls.Add(this.ApellidoTextBox);
            this.Controls.Add(this.NombreTextBox);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblTipoDocumento);
            this.Controls.Add(this.lblNombre);
            this.Name = "FrmEmpleadosAE";
            this.Text = "FrmEmpleadosAE";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.ComboBox ProvinciasComboBox;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.ComboBox LocalidadesComboBox;
        private System.Windows.Forms.Label lblProvincia;
        private System.Windows.Forms.TextBox DireccionTextBox;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblTipoDocumento;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox ApellidoTextBox;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox NumDocumentoTextBox;
        private System.Windows.Forms.Label lblNumDocumento;
        private System.Windows.Forms.ComboBox TipoDocumentoComboBox;
    }
}