using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoClub.Servicios.Servicios;
using VideoClub.Servicios.Servicios.Facades;
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
            CargarComboProvincias();
            if (localidad!=null)
            {
                LocalidadTextBox.Text = localidad.NombreLocalidad;
                ProvinciasComboBox.SelectedValue = localidad.Provincia.ProvinciaId;
            }
        }

        private void CargarComboProvincias()
        {
            IServicioProvincia servicioProvincia = new ServicioProvincia();
            var lista = servicioProvincia.GetProvincia();
            var defaultProvincia = new Provincia
            {
                ProvinciaId = 0,
                NombreProvincia = "<Seleccione Provincia>"
            };
            lista.Insert(0, defaultProvincia);
            ProvinciasComboBox.DataSource = lista;
            ProvinciasComboBox.ValueMember = "ProvinciaId";
            ProvinciasComboBox.DisplayMember = "NombreProvincia";
            ProvinciasComboBox.SelectedIndex = 0;
        }

        private Localidad localidad;

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
                    localidad = new Localidad();
                }

                localidad.NombreLocalidad = LocalidadTextBox.Text;
                localidad.Provincia = (Provincia)ProvinciasComboBox.SelectedItem;
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

        public void SetLocalidad(Localidad localidad)
        {
            this.localidad = localidad;
        }
        internal Localidad GetLocalidad()
        {
            return localidad;
        }
    }
}
