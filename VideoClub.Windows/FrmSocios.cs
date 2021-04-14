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
using VideoClubEntidades.DTOs;

namespace VideoClub.Windows
{
    public partial class FrmSocios : Form
    {
        public FrmSocios()
        {
            InitializeComponent();
        }
        private IServicioSocios _servicio;
        private List<SocioListDto> _lista;
        private void FrmSocios_Load(object sender, EventArgs e)
        {
            try
            {
                _servicio = new ServicioSocios();
                _lista = _servicio.GetLista();
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var socioListDto in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, socioListDto);
                AgregarFila(r);
            }
        }

        private void SetearFila(DataGridViewRow r, SocioListDto socioListDto)
        {
            r.Cells[cmnNombre.Index].Value = socioListDto.Nombre;
            r.Cells[cmnApellido.Index].Value = socioListDto.Apellido;
            r.Cells[cmnLocalidad.Index].Value = socioListDto.Localidad;
            r.Cells[cmnProvincia.Index].Value = socioListDto.Provincia;

            r.Tag = socioListDto;
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
