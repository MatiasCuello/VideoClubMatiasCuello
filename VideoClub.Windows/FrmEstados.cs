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
    public partial class FrmEstados : Form
    {
        public FrmEstados()
        {
            InitializeComponent();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private IServicioEstado servicio;
        private List<Estado> lista;
        private void FrmEstados_Load(object sender, EventArgs e)
        {

            try
            {
                servicio = new ServicioEstado();
                lista = servicio.GetEstado();
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
            foreach (var estado in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, estado);
                AgregarFila(r);
            }
        }
        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }
        private void SetearFila(DataGridViewRow r, Estado estado)
        {
            r.Cells[cmnEstado.Index].Value = estado.Descripcion;
            r.Tag = estado;
        }
        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmEstadosAE frm = new FrmEstadosAE();
            frm.Text = "Agregar Estado";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Estado estado = frm.GetEstado();
                    if (!servicio.Existe(estado))
                    {
                        servicio.Guardar(estado);
                        var r = ConstruirFila();
                        SetearFila(r, estado);
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
                Estado estado = (Estado)r.Tag;
                Estado estadoAux = (Estado)estado.Clone();
                FrmEstadosAE frm = new FrmEstadosAE();
                frm.Text = "Editar Estado";
                frm.SetEstado(estado);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        estado = frm.GetEstado();

                        if (!servicio.Existe(estado))
                        {
                            servicio.Guardar(estado);
                            SetearFila(r, estado);
                            MessageBox.Show("Registro editado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            SetearFila(r, estadoAux);
                            MessageBox.Show("Registro ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    catch (Exception exception)
                    {
                        SetearFila(r, estadoAux);
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
                Estado estado = (Estado)r.Tag;

                DialogResult dr = MessageBox.Show($"¿Desea eliminar el registro seleccionado: {estado.Descripcion}?",
                    "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        servicio.Borrar(estado.EstadoId);
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
