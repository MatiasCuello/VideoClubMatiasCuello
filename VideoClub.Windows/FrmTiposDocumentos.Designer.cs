
namespace VideoClub.Windows
{
    partial class FrmTiposDocumentos
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.cmnTiposDocumentos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsbCerrar = new System.Windows.Forms.ToolStripButton();
            this.tspTipoDocumentos = new System.Windows.Forms.ToolStrip();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.tspTipoDocumentos.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDatos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 396);
            this.panel1.TabIndex = 9;
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnTiposDocumentos});
            this.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatos.Location = new System.Drawing.Point(0, 0);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(800, 396);
            this.dgvDatos.TabIndex = 0;
            // 
            // cmnTiposDocumentos
            // 
            this.cmnTiposDocumentos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnTiposDocumentos.HeaderText = "Tipos de Documentos";
            this.cmnTiposDocumentos.Name = "cmnTiposDocumentos";
            this.cmnTiposDocumentos.ReadOnly = true;
            // 
            // tsbCerrar
            // 
            this.tsbCerrar.Image = global::VideoClub.Windows.Properties.Resources.Salir;
            this.tsbCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCerrar.Name = "tsbCerrar";
            this.tsbCerrar.Size = new System.Drawing.Size(43, 51);
            this.tsbCerrar.Text = "Cerrar";
            this.tsbCerrar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.tsbCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbCerrar.Click += new System.EventHandler(this.tsbCerrar_Click);
            // 
            // tspTipoDocumentos
            // 
            this.tspTipoDocumentos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCerrar});
            this.tspTipoDocumentos.Location = new System.Drawing.Point(0, 0);
            this.tspTipoDocumentos.Name = "tspTipoDocumentos";
            this.tspTipoDocumentos.Size = new System.Drawing.Size(800, 54);
            this.tspTipoDocumentos.TabIndex = 8;
            this.tspTipoDocumentos.Text = "toolStrip1";
            // 
            // FrmTiposDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tspTipoDocumentos);
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "FrmTiposDocumentos";
            this.Text = "FrmTiposDocumentos";
            this.Load += new System.EventHandler(this.FrmTiposDocumentos_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.tspTipoDocumentos.ResumeLayout(false);
            this.tspTipoDocumentos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnTiposDocumentos;
        private System.Windows.Forms.ToolStripButton tsbCerrar;
        private System.Windows.Forms.ToolStrip tspTipoDocumentos;
    }
}