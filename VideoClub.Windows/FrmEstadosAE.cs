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
    public partial class FrmEstadosAE : Form
    {
        public FrmEstadosAE()
        {
            InitializeComponent();
        }

        private  Estado estado;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (estado!=null)
            {
                EstadoTextBox.Text = estado.Descripcion;
            }
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        internal Estado GetEstado()
        {
            return estado;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (estado == null)
                {
                    estado = new Estado();
                }

                estado.Descripcion = EstadoTextBox.Text.Trim();
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            if (string.IsNullOrEmpty(EstadoTextBox.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(EstadoTextBox, "Debe ingresar un estado");
            }

            return valido;
        }

        internal void SetEstado(Estado estado)
        {
            this.estado = estado;
        }
    }
}
