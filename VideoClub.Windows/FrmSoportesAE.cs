using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoClubEntidades.Entidades;

namespace VideoClub.Windows
{
    public partial class FrmSoportesAE : Form
    {
        public FrmSoportesAE()
        {
            InitializeComponent();
        }
        Soporte soporte;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (soporte != null)
            {
                SoporteTextBox.Text = soporte.Descripcion;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        internal Soporte GetSoporte()
        {
            return soporte;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (soporte == null)
                {
                    soporte = new Soporte();
                }

                soporte.Descripcion = SoporteTextBox.Text.Trim();
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            if (string.IsNullOrEmpty(SoporteTextBox.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(SoporteTextBox, "Debe ingresar un soporte");
            }

            return valido;
        }

        internal void SetSoporte(Soporte soporte)
        {
            this.soporte = soporte;
        }
    }
}

