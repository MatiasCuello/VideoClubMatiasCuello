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
    public partial class FrmBuscarLocalidades : Form
    {
        public FrmBuscarLocalidades()
        {
            InitializeComponent();
        }

        private void FrmBuscarLocalidades_Load(object sender, EventArgs e)
        {
            Helper.Helper.CargarDatosComboProvincias(ref ProvinciasComboBox);
        }
        private Provincia provincia;
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                provincia = (Provincia)ProvinciasComboBox.SelectedItem;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (ProvinciasComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(ProvinciasComboBox, "Debe seleccionar una provincia");
            }
            return valido;
        }

        public Provincia GetProvincia()
        {
            return provincia;
        }
    }
}
