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
    public partial class FrmCalificacion : Form
    {
        public FrmCalificacion()
        {
            InitializeComponent();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private IServicioCalificacion servicio;
        private List<Calificacion> lista;
        private void FrmCalificacion_Load(object sender, EventArgs e)
        {


            try
            {
                servicio = new ServicioCalificacion();
                lista = servicio.GetCalificacion();
                MostrarDatosEnGrilla();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var calificacion in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, calificacion);
                AgregarFila(r);
            }
        }
        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }
        private void SetearFila(DataGridViewRow r, Calificacion calificacion)
        {
            r.Cells[cmnCalificacion.Index].Value = calificacion.Descripcion;
            r.Tag = calificacion;
        }
        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }
    }
}
