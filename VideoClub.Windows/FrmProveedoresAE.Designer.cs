
namespace VideoClub.Windows
{
    partial class FrmProveedoresAE
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
            this.RazonSocialTextBox = new System.Windows.Forms.TextBox();
            this.lblRazonSocial = new System.Windows.Forms.Label();
            this.CuitTextBox = new System.Windows.Forms.TextBox();
            this.lblCuit = new System.Windows.Forms.Label();
            this.ProvinciasComboBox = new System.Windows.Forms.ComboBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.LocalidadesComboBox = new System.Windows.Forms.ComboBox();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.CorreoTextBox = new System.Windows.Forms.TextBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.TelefonoFijoTextBox = new System.Windows.Forms.TextBox();
            this.lblTelefonoFijo = new System.Windows.Forms.Label();
            this.lblPersonaContacto = new System.Windows.Forms.Label();
            this.PersonaContactoTextBox = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.DireccionTextBox = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.TelefonoMovilTextBox = new System.Windows.Forms.TextBox();
            this.lblTelefonoMovil = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // RazonSocialTextBox
            // 
            this.RazonSocialTextBox.Location = new System.Drawing.Point(83, 36);
            this.RazonSocialTextBox.MaxLength = 100;
            this.RazonSocialTextBox.Name = "RazonSocialTextBox";
            this.RazonSocialTextBox.Size = new System.Drawing.Size(506, 20);
            this.RazonSocialTextBox.TabIndex = 0;
            // 
            // lblRazonSocial
            // 
            this.lblRazonSocial.AutoSize = true;
            this.lblRazonSocial.Location = new System.Drawing.Point(293, 20);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Size = new System.Drawing.Size(73, 13);
            this.lblRazonSocial.TabIndex = 143;
            this.lblRazonSocial.Text = "Razon Social:";
            // 
            // CuitTextBox
            // 
            this.CuitTextBox.Location = new System.Drawing.Point(83, 75);
            this.CuitTextBox.MaxLength = 13;
            this.CuitTextBox.Name = "CuitTextBox";
            this.CuitTextBox.Size = new System.Drawing.Size(250, 20);
            this.CuitTextBox.TabIndex = 1;
            // 
            // lblCuit
            // 
            this.lblCuit.AutoSize = true;
            this.lblCuit.Location = new System.Drawing.Point(180, 59);
            this.lblCuit.Name = "lblCuit";
            this.lblCuit.Size = new System.Drawing.Size(35, 13);
            this.lblCuit.TabIndex = 143;
            this.lblCuit.Text = "CUIT:";
            // 
            // ProvinciasComboBox
            // 
            this.ProvinciasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProvinciasComboBox.FormattingEnabled = true;
            this.ProvinciasComboBox.Location = new System.Drawing.Point(83, 153);
            this.ProvinciasComboBox.Name = "ProvinciasComboBox";
            this.ProvinciasComboBox.Size = new System.Drawing.Size(250, 21);
            this.ProvinciasComboBox.TabIndex = 4;
            this.ProvinciasComboBox.SelectedIndexChanged += new System.EventHandler(this.ProvinciasComboBox_SelectedIndexChanged);
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(428, 137);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(56, 13);
            this.lblLocalidad.TabIndex = 148;
            this.lblLocalidad.Text = "Localidad:";
            // 
            // LocalidadesComboBox
            // 
            this.LocalidadesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LocalidadesComboBox.FormattingEnabled = true;
            this.LocalidadesComboBox.Location = new System.Drawing.Point(339, 153);
            this.LocalidadesComboBox.Name = "LocalidadesComboBox";
            this.LocalidadesComboBox.Size = new System.Drawing.Size(250, 21);
            this.LocalidadesComboBox.TabIndex = 5;
            // 
            // lblProvincia
            // 
            this.lblProvincia.AutoSize = true;
            this.lblProvincia.Location = new System.Drawing.Point(174, 137);
            this.lblProvincia.Name = "lblProvincia";
            this.lblProvincia.Size = new System.Drawing.Size(54, 13);
            this.lblProvincia.TabIndex = 146;
            this.lblProvincia.Text = "Provincia:";
            // 
            // CorreoTextBox
            // 
            this.CorreoTextBox.Location = new System.Drawing.Point(83, 232);
            this.CorreoTextBox.MaxLength = 150;
            this.CorreoTextBox.Name = "CorreoTextBox";
            this.CorreoTextBox.Size = new System.Drawing.Size(509, 20);
            this.CorreoTextBox.TabIndex = 7;
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Location = new System.Drawing.Point(293, 216);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(97, 13);
            this.lblCorreo.TabIndex = 150;
            this.lblCorreo.Text = "Correo Electronico:";
            // 
            // TelefonoFijoTextBox
            // 
            this.TelefonoFijoTextBox.Location = new System.Drawing.Point(83, 193);
            this.TelefonoFijoTextBox.MaxLength = 20;
            this.TelefonoFijoTextBox.Name = "TelefonoFijoTextBox";
            this.TelefonoFijoTextBox.Size = new System.Drawing.Size(250, 20);
            this.TelefonoFijoTextBox.TabIndex = 6;
            // 
            // lblTelefonoFijo
            // 
            this.lblTelefonoFijo.AutoSize = true;
            this.lblTelefonoFijo.Location = new System.Drawing.Point(180, 177);
            this.lblTelefonoFijo.Name = "lblTelefonoFijo";
            this.lblTelefonoFijo.Size = new System.Drawing.Size(71, 13);
            this.lblTelefonoFijo.TabIndex = 152;
            this.lblTelefonoFijo.Text = "Teléfono Fijo:";
            // 
            // lblPersonaContacto
            // 
            this.lblPersonaContacto.AutoSize = true;
            this.lblPersonaContacto.Location = new System.Drawing.Point(412, 59);
            this.lblPersonaContacto.Name = "lblPersonaContacto";
            this.lblPersonaContacto.Size = new System.Drawing.Size(112, 13);
            this.lblPersonaContacto.TabIndex = 143;
            this.lblPersonaContacto.Text = "Persona De Contacto:";
            // 
            // PersonaContactoTextBox
            // 
            this.PersonaContactoTextBox.Location = new System.Drawing.Point(339, 75);
            this.PersonaContactoTextBox.MaxLength = 100;
            this.PersonaContactoTextBox.Name = "PersonaContactoTextBox";
            this.PersonaContactoTextBox.Size = new System.Drawing.Size(250, 20);
            this.PersonaContactoTextBox.TabIndex = 2;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(293, 98);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(55, 13);
            this.lblDireccion.TabIndex = 143;
            this.lblDireccion.Text = "Direccion:";
            // 
            // DireccionTextBox
            // 
            this.DireccionTextBox.Location = new System.Drawing.Point(83, 114);
            this.DireccionTextBox.MaxLength = 100;
            this.DireccionTextBox.Name = "DireccionTextBox";
            this.DireccionTextBox.Size = new System.Drawing.Size(506, 20);
            this.DireccionTextBox.TabIndex = 3;
            // 
            // CancelButton
            // 
            this.CancelButton.Image = global::VideoClub.Windows.Properties.Resources.Cancelar;
            this.CancelButton.Location = new System.Drawing.Point(415, 281);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(94, 64);
            this.CancelButton.TabIndex = 9;
            this.CancelButton.Text = "Cancelar";
            this.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Image = global::VideoClub.Windows.Properties.Resources.OK;
            this.OkButton.Location = new System.Drawing.Point(162, 281);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(94, 64);
            this.OkButton.TabIndex = 8;
            this.OkButton.Text = "OK";
            this.OkButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // TelefonoMovilTextBox
            // 
            this.TelefonoMovilTextBox.Location = new System.Drawing.Point(339, 193);
            this.TelefonoMovilTextBox.MaxLength = 20;
            this.TelefonoMovilTextBox.Name = "TelefonoMovilTextBox";
            this.TelefonoMovilTextBox.Size = new System.Drawing.Size(250, 20);
            this.TelefonoMovilTextBox.TabIndex = 6;
            // 
            // lblTelefonoMovil
            // 
            this.lblTelefonoMovil.AutoSize = true;
            this.lblTelefonoMovil.Location = new System.Drawing.Point(428, 177);
            this.lblTelefonoMovil.Name = "lblTelefonoMovil";
            this.lblTelefonoMovil.Size = new System.Drawing.Size(80, 13);
            this.lblTelefonoMovil.TabIndex = 152;
            this.lblTelefonoMovil.Text = "Teléfono Movil:";
            // 
            // FrmProveedoresAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.ControlBox = false;
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.CorreoTextBox);
            this.Controls.Add(this.lblCorreo);
            this.Controls.Add(this.TelefonoMovilTextBox);
            this.Controls.Add(this.TelefonoFijoTextBox);
            this.Controls.Add(this.lblTelefonoMovil);
            this.Controls.Add(this.lblTelefonoFijo);
            this.Controls.Add(this.ProvinciasComboBox);
            this.Controls.Add(this.lblLocalidad);
            this.Controls.Add(this.LocalidadesComboBox);
            this.Controls.Add(this.lblProvincia);
            this.Controls.Add(this.PersonaContactoTextBox);
            this.Controls.Add(this.CuitTextBox);
            this.Controls.Add(this.lblPersonaContacto);
            this.Controls.Add(this.DireccionTextBox);
            this.Controls.Add(this.RazonSocialTextBox);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.lblCuit);
            this.Controls.Add(this.lblRazonSocial);
            this.MaximumSize = new System.Drawing.Size(700, 400);
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "FrmProveedoresAE";
            this.Text = "FmProveedoresAE";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox RazonSocialTextBox;
        private System.Windows.Forms.Label lblRazonSocial;
        private System.Windows.Forms.TextBox CuitTextBox;
        private System.Windows.Forms.Label lblCuit;
        private System.Windows.Forms.ComboBox ProvinciasComboBox;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.ComboBox LocalidadesComboBox;
        private System.Windows.Forms.Label lblProvincia;
        private System.Windows.Forms.TextBox CorreoTextBox;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox TelefonoFijoTextBox;
        private System.Windows.Forms.Label lblTelefonoFijo;
        private System.Windows.Forms.Label lblPersonaContacto;
        private System.Windows.Forms.TextBox PersonaContactoTextBox;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox DireccionTextBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox TelefonoMovilTextBox;
        private System.Windows.Forms.Label lblTelefonoMovil;
    }
}