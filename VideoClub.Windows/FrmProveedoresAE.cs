using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoClubEntidades.DTOs.Localidad;
using VideoClubEntidades.DTOs.Proveedor;
using VideoClubEntidades.Entidades;

namespace VideoClub.Windows
{
    public partial class FrmProveedoresAE : Form
    {
        public FrmProveedoresAE()
        {
            InitializeComponent();
        }
        private ProveedorEditDto proveedorDto;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.Helper.CargarDatosComboProvincias(ref ProvinciasComboBox);
            if (proveedorDto == null) return;
            RazonSocialTextBox.Text = proveedorDto.RazonSocial;
            CuitTextBox.Text = proveedorDto.CUIT;
            PersonaContactoTextBox.Text = proveedorDto.PersonaDeContacto;
            DireccionTextBox.Text = proveedorDto.Direccion;
            //TelefonoTextBox.Text = proveedorDto.Telefono;
            //CorreoTextBox.Text = proveedorDto.Correo;
            LocalidadesComboBox.SelectedValue = proveedorDto.Provincia.ProvinciaId;
            Helper.Helper.CargarDatosComboLocalidades(ref ProvinciasComboBox, proveedorDto.Provincia);
            ProvinciasComboBox.SelectedValue = proveedorDto.Localidad.LocalidadId;
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
                if (proveedorDto == null)
                {
                    proveedorDto = new ProveedorEditDto();
                }

                proveedorDto.RazonSocial = RazonSocialTextBox.Text;
                proveedorDto.CUIT = CuitTextBox.Text;
                proveedorDto.PersonaDeContacto = PersonaContactoTextBox.Text;
                proveedorDto.Direccion = DireccionTextBox.Text;
                proveedorDto.Provincia = (Provincia)ProvinciasComboBox.SelectedItem;
                proveedorDto.Localidad = (LocalidadListDto)LocalidadesComboBox.SelectedItem;
                DialogResult = DialogResult.OK;
            }
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(RazonSocialTextBox.Text)
                || string.IsNullOrWhiteSpace(RazonSocialTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(RazonSocialTextBox, "La razon social es requerido");
            }

            if (string.IsNullOrEmpty(CuitTextBox.Text)
                || string.IsNullOrWhiteSpace(CuitTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(CuitTextBox, "El CUIT requerido");
            }

            if (string.IsNullOrEmpty(PersonaContactoTextBox.Text)
                || string.IsNullOrWhiteSpace(PersonaContactoTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(PersonaContactoTextBox, "La persona de contacto es requerida");
            }
            if (string.IsNullOrEmpty(DireccionTextBox.Text)
              || string.IsNullOrWhiteSpace(DireccionTextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(DireccionTextBox, "La direccion es requerida");
            }

            if (ProvinciasComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(ProvinciasComboBox, "La provincia es requerida");
            }

            if (LocalidadesComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(LocalidadesComboBox, "La localidad es requerida");
            }

            return valido;
        }
        public ProveedorEditDto GetProveedor()
        {
            return proveedorDto;
        }

  
    }

}

