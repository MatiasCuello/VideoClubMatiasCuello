
namespace VideoClub.Windows
{
    partial class FrmSoportesAE
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
            this.CancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.SoporteTextBox = new System.Windows.Forms.TextBox();
            this.lblSoportes = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.Image = global::VideoClub.Windows.Properties.Resources.Cancelar;
            this.CancelButton.Location = new System.Drawing.Point(322, 158);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(94, 64);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancelar";
            this.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Image = global::VideoClub.Windows.Properties.Resources.OK;
            this.OkButton.Location = new System.Drawing.Point(69, 158);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(94, 64);
            this.OkButton.TabIndex = 1;
            this.OkButton.Text = "OK";
            this.OkButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // SoporteTextBox
            // 
            this.SoporteTextBox.Location = new System.Drawing.Point(136, 38);
            this.SoporteTextBox.MaxLength = 100;
            this.SoporteTextBox.Name = "SoporteTextBox";
            this.SoporteTextBox.Size = new System.Drawing.Size(280, 20);
            this.SoporteTextBox.TabIndex = 0;
            // 
            // lblSoportes
            // 
            this.lblSoportes.AutoSize = true;
            this.lblSoportes.Location = new System.Drawing.Point(87, 41);
            this.lblSoportes.Name = "lblSoportes";
            this.lblSoportes.Size = new System.Drawing.Size(47, 13);
            this.lblSoportes.TabIndex = 35;
            this.lblSoportes.Text = "Soporte:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmSoportesAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.SoporteTextBox);
            this.Controls.Add(this.lblSoportes);
            this.MaximumSize = new System.Drawing.Size(500, 300);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "FrmSoportesAE";
            this.Text = "FrmSoportesAE";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.TextBox SoporteTextBox;
        private System.Windows.Forms.Label lblSoportes;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}