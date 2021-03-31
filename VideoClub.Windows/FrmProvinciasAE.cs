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
    public partial class FrmProvinciasAE : Form
    {
        public FrmProvinciasAE()
        {
            InitializeComponent();
        }
        private Provincia provincia;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (provincia != null)
            {
                ProvinciaTextBox.Text = provincia.NombreProvincia;
            }
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        internal Provincia GetProvincia()
        {
            return provincia;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (provincia == null)
                {
                    provincia = new Provincia();
                }

                provincia.NombreProvincia = ProvinciaTextBox.Text.Trim();
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            if (string.IsNullOrEmpty(ProvinciaTextBox.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(ProvinciaTextBox, "Debe ingresar una provincia");
            }

            return valido;
        }

        internal void SetProvincia(Provincia provincia)
        {
            this.provincia = provincia;
        }
    }
}
