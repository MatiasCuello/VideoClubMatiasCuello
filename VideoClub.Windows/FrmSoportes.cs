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
    public partial class FrmSoportes : Form
    {
        public FrmSoportes()
        {
            InitializeComponent();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private IServicioSoporte servicio;
        private List<Soporte> lista;
        private void FrmSoportes_Load(object sender, EventArgs e)
        {

            try
            {
                servicio = new ServicioSoporte();
                lista = servicio.GetSoporte();
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
            foreach (var soporte in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, soporte);
                AgregarFila(r);
            }
        }
        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }
        private void SetearFila(DataGridViewRow r, Soporte soporte)
        {
            r.Cells[cmnSoporte.Index].Value = soporte.Descripcion;
            r.Tag = soporte;
        }
        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmSoportesAE frm = new FrmSoportesAE();
            frm.Text = "Agregar Soporte";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Soporte soporte = frm.GetSoporte();
                    if (!servicio.Existe(soporte))
                    {
                        servicio.Guardar(soporte);
                        var r = ConstruirFila();
                        SetearFila(r, soporte);
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
                Soporte soporte = (Soporte)r.Tag;
                Soporte soporteoAux = (Soporte)soporte.Clone();
                FrmSoportesAE frm = new FrmSoportesAE();
                frm.Text = "Editar Soporte";
                frm.SetSoporte(soporte);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        soporte = frm.GetSoporte();

                        if (!servicio.Existe(soporte))
                        {
                            servicio.Guardar(soporte);
                            SetearFila(r, soporte);
                            MessageBox.Show("Registro editado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            SetearFila(r, soporteoAux);
                            MessageBox.Show("Registro ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    catch (Exception exception)
                    {
                        SetearFila(r, soporteoAux);
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
                Soporte soporte = (Soporte)r.Tag;

                DialogResult dr = MessageBox.Show($"¿Desea eliminar el registro seleccionado: {soporte.Descripcion}?",
                    "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        servicio.Borrar(soporte.SoporteId);
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
