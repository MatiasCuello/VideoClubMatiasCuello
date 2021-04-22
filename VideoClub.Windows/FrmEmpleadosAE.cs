using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoClubEntidades.DTOs.Empleado;
using VideoClubEntidades.DTOs.Localidad;
using VideoClubEntidades.Entidades;

namespace VideoClub.Windows
{
    public partial class FrmEmpleadosAE : Form
    {
        public FrmEmpleadosAE()
        {
            InitializeComponent();
        }
        private EmpleadoEditDto empleadoEditDto;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.Helper.CargarDatosComboProvincias(ref ProvinciasComboBox);
            Helper.Helper.CargarDatosComboTipoDocumento(ref TipoDocumentoComboBox);
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ProvinciasComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProvinciasComboBox.SelectedIndex != 0)
            {
                Provincia provincia = (Provincia)ProvinciasComboBox.SelectedItem;
                Helper.Helper.CargarDatosComboLocalidades(ref LocalidadesComboBox, provincia);
            }
            else
            {
                LocalidadesComboBox.DataSource = null;
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (empleadoEditDto==null)
                {
                    empleadoEditDto = new EmpleadoEditDto();
                }
                empleadoEditDto.Nombre = NombreTextBox.Text;
                empleadoEditDto.Apellido = ApellidoTextBox.Text;
                empleadoEditDto.Direccion = DireccionTextBox.Text;
                empleadoEditDto.TipoDocumento = (TipoDocumento)TipoDocumentoComboBox.SelectedItem;
                empleadoEditDto.Provincia = (Provincia)ProvinciasComboBox.SelectedItem;
                empleadoEditDto.Localidad = (LocalidadListDto)LocalidadesComboBox.SelectedItem;
                DialogResult = DialogResult.OK;
            }
        }

        public bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(NombreTextBox.Text) || string.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(NombreTextBox, "Debe ingresar el nombre del empleado");
            }

            if (string.IsNullOrEmpty(ApellidoTextBox.Text) || string.IsNullOrWhiteSpace(ApellidoTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(NombreTextBox, "Debe ingresar el apellido del empleado");
            }

            if (TipoDocumentoComboBox.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(TipoDocumentoComboBox, "Debe seleccionar el tipo de documento");
            }

            if (string.IsNullOrEmpty(NumDocumentoTextBox.Text) || string.IsNullOrWhiteSpace(NumDocumentoTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(NombreTextBox, "Debe ingresar el numero de documento");
            }

            if (ProvinciasComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(ProvinciasComboBox, "Debe seleccionar una provincia");
            }

            if (LocalidadesComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(LocalidadesComboBox, "Debe seleccionar una localidad");
            }
            return valido;
        }

        public EmpleadoEditDto GetEmpleado()
        {
            return empleadoEditDto;
        }
    }
}
