using System;
using System.Windows.Forms;
using VideoClubEntidades.DTOs.Localidad;
using VideoClubEntidades.Entidades;

namespace VideoClub.Windows
{
    public partial class FrmLocalidadesAE : Form
    {
        public FrmLocalidadesAE()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.Helper.CargarDatosComboProvincias(ref ProvinciasComboBox);
            if (localidad!=null)
            {
                LocalidadTextBox.Text = localidad.NombreLocalidad;
                ProvinciasComboBox.SelectedValue = localidad.ProvinciaId;
            }
        }

        private LocalidadEditDto localidad;

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (ValidadDatos())
            {
                if (localidad == null)
                {
                    localidad = new LocalidadEditDto();
                }

                localidad.NombreLocalidad = LocalidadTextBox.Text;
                localidad.ProvinciaId = ((Provincia)ProvinciasComboBox.SelectedItem).ProvinciaId;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidadDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(LocalidadTextBox.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(LocalidadTextBox, "Debe ingresar una localidad");
            }

            if (ProvinciasComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(ProvinciasComboBox, "Debe seleccionar una provincia");
            }

            return valido;
        }

        public void SetLocalidad(LocalidadEditDto localidad)
        {
            this.localidad = localidad;
        }
        public LocalidadEditDto GetLocalidad()
        {
            return localidad;
        }
    }
}
