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
    public partial class FrmCalificacionesAE : Form
    {
        public FrmCalificacionesAE()
        {
            InitializeComponent();
        }
        Calificacion calificacion;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (calificacion!=null)
            {
                CalificacionTextBox.Text = calificacion.Descripcion;
            }
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        internal Calificacion GetCalificacion()
        {
            return calificacion;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (calificacion == null)
                {
                    calificacion = new Calificacion();
                }

                calificacion.Descripcion = CalificacionTextBox.Text.Trim();
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            if (string.IsNullOrEmpty(CalificacionTextBox.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(CalificacionTextBox, "Debe ingresar una calificacion");
            }

            return valido;
        }

        internal void SerCalificacion(Calificacion calificacion)
        {
            this.calificacion = calificacion;
        }

        private void lblCalificacion_Click(object sender, EventArgs e)
        {

        }

        internal void SetCalificacion(Calificacion calificacion)
        {
            this.calificacion = calificacion;
        }
    }
}

