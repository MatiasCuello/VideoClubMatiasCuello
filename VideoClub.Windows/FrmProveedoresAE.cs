using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoClubEntidades.DTOs.Proveedor;

namespace VideoClub.Windows
{
    public partial class FrmProveedoresAE : Form
    {
        public FrmProveedoresAE()
        {
            InitializeComponent();
        }
        private ProveedorEditDto proveedorDto;

        public ProveedorEditDto GetProveedor()
        {
            return proveedorDto;
        }

        protected override void OnLoad(EventArgs e)
        {
            //base.OnLoad(e);
            //Helper.Helper.CargarDatosComboProvincias(ref ProvinciasComboBox);
            //if (proveedorDto == null) return;
            //RazonSocialTextBox.Text = proveedorDto.RazonSocial;
            //CuitTextBox.Text = proveedorDto.CUIT;
            //PersonaContactoTextBox.Text = proveedorDto.PersonaDeContacto;
            //DireccionTextBox.Text = proveedorDto.Direccion;
            //TelefonoTextBox.Text = proveedorDto.Telefono;
            //CorreoTextBox.Text = proveedorDto.Email;
            //LocalidadesComboBox.SelectedValue = proveedorDto.Provincia.ProvinciaId;
            //Helper.Helper.CargarDatosComboLocalidades(ref ProvinciasComboBox, proveedorDto.Provincia);
            //ProvinciasComboBox.SelectedValue = proveedorDto.Localidad.LocalidadId;
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FrmProveedoresAE_Load(object sender, EventArgs e)
        {

        }
    }
}
