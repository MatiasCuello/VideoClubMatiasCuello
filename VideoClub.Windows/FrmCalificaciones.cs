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
    public partial class FrmCalificaciones : Form
    {
        public FrmCalificaciones()
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

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmCalificacionesAE frm = new FrmCalificacionesAE();
            frm.Text = "Agregar Calificacion";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Calificacion calificacion = frm.GetCalificacion();
                    if (!servicio.Existe(calificacion))
                    {
                        servicio.Guardar(calificacion);
                        var r = ConstruirFila();
                        SetearFila(r, calificacion);
                        AgregarFila(r);
                        MessageBox.Show("Registro agregado", "Mensaje",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Registro duplicado... Alta denegada", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
                catch (Exception exception)
                {

                    MessageBox.Show(exception.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                Calificacion calificacion = (Calificacion)r.Tag;
                Calificacion calificacionAux = (Calificacion)calificacion.Clone();
                FrmCalificacionesAE frm = new FrmCalificacionesAE();
                frm.Text = "Editar Calificacion";
                frm.SetCalificacion(calificacion);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        calificacion = frm.GetCalificacion();

                        if (!servicio.Existe(calificacion))
                        {
                            servicio.Guardar(calificacion);
                            SetearFila(r, calificacion);
                            MessageBox.Show("Registro editado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            SetearFila(r, calificacionAux);
                            MessageBox.Show("Registro ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    catch (Exception exception)
                    {
                        SetearFila(r, calificacionAux);
                        MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                Calificacion calificacion = (Calificacion)r.Tag;

                DialogResult dr = MessageBox.Show($"¿Desea eliminar el registro seleccionado: {calificacion.Descripcion}?",
                    "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        servicio.Borrar(calificacion.CalificacionId);
                        dgvDatos.Rows.Remove(r);
                        MessageBox.Show("Registro eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
    }
}
