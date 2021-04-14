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
using VideoClubEntidades.DTOs.Empleado;

namespace VideoClub.Windows
{
    public partial class FrmEmpleados : Form
    {
        public FrmEmpleados()
        {
            InitializeComponent();
        }

        private IServicioEmpleados _servicio;
        private List<EmpleadoListDto> _lista;


        private void FrmEmpleados_Load(object sender, EventArgs e)
        {

            try
            {
                _servicio = new ServicioEmpleados();
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
            foreach (var empleadoListDto in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, empleadoListDto);
                AgregarFila(r);
            }
        }

        private void SetearFila(DataGridViewRow r, EmpleadoListDto empleadoListDto)
        {
            r.Cells[cmnNombre.Index].Value = empleadoListDto.Nombre;
            r.Cells[cmnApellido.Index].Value = empleadoListDto.Apellido;
            r.Cells[cmnLocalidad.Index].Value = empleadoListDto.Localidad;
            r.Cells[cmnProvincia.Index].Value = empleadoListDto.Provincia;
            r.Tag = empleadoListDto;
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
