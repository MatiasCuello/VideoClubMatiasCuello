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
    public partial class FrmProvincias : Form
    {
        public FrmProvincias()
        {
            InitializeComponent();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private IServicioProvincia servicio;
        private List<Provincia> lista;
        private void FrmProvincias_Load(object sender, EventArgs e)
        {

            try
            {
                servicio = new ServicioProvincia();
                lista = servicio.GetProvincia();
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
            foreach (var provincia in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, provincia);
                AgregarFila(r);
            }
        }
        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }
        private void SetearFila(DataGridViewRow r, Provincia provincia)
        {
            r.Cells[cmnProvincia.Index].Value = provincia.NombreProvincia;
            r.Tag = provincia;
        }
        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmProvinciasAE frm = new FrmProvinciasAE();
            frm.Text = "Agregar Provincia";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Provincia provincia = frm.GetProvincia();
                    if (!servicio.Existe(provincia))
                    {
                        servicio.Guardar(provincia);
                        var r = ConstruirFila();
                        SetearFila(r, provincia);
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
                Provincia provincia = (Provincia)r.Tag;
                Provincia provinciaAux = (Provincia)provincia.Clone();
                FrmProvinciasAE frm = new FrmProvinciasAE();
                frm.Text = "Editar Provincia";
                frm.SetProvincia(provincia);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        provincia = frm.GetProvincia();

                        if (!servicio.Existe(provincia))
                        {
                            servicio.Guardar(provincia);
                            SetearFila(r, provincia);
                            MessageBox.Show("Registro editado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            SetearFila(r, provinciaAux);
                            MessageBox.Show("Registro ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    catch (Exception exception)
                    {
                        SetearFila(r, provinciaAux);
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
                Provincia provincia = (Provincia)r.Tag;

                DialogResult dr = MessageBox.Show($"¿Desea eliminar el registro seleccionado: {provincia.NombreProvincia}?",
                    "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        servicio.Borrar(provincia.ProvinciaId);
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
