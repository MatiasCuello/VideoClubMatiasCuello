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
    public partial class FrmGeneros : Form
    {
        public FrmGeneros()
        {
            InitializeComponent();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private IServicioGenero servicio;
        private List<Genero> lista;
        private void FrmGeneros_Load(object sender, EventArgs e)
        {
            try
            {
                servicio = new ServicioGenero();
                lista = servicio.GetGenero();
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
            foreach (var genero in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, genero);
                AgregarFila(r);
            }
        }
        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }
        private void SetearFila(DataGridViewRow r, Genero genero)
        {
            r.Cells[cmnGenero.Index].Value = genero.Descripcion;
            r.Tag = genero;
        }
        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }
    }
    }

