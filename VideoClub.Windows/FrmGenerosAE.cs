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
    public partial class FrmGenerosAE : Form
    {
        public FrmGenerosAE()
        {
            InitializeComponent();
        }

        Genero genero;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (genero != null)
            {
                GeneroTextBox.Text = genero.Descripcion;
            }
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = DialogResult.Cancel;
        }

        internal Genero GetGenero()
        {
            return genero;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (genero == null)
                {
                    genero = new Genero();
                }

                genero.Descripcion = GeneroTextBox.Text.Trim();
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            if (string.IsNullOrEmpty(GeneroTextBox.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(GeneroTextBox, "Debe ingresar un genero");
            }

            return valido;
        }

        internal void SetEstado(Genero genero)
        {
            this.genero = genero;
        }

        private void CancelButton_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

