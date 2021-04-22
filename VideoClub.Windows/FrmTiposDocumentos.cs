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
    public partial class FrmTiposDocumentos : Form
    {
        public FrmTiposDocumentos()
        {
            InitializeComponent();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private IServicioTipoDocumento servicio;
        private List<TipoDocumento> lista;
        private void FrmTiposDocumentos_Load(object sender, EventArgs e)
        {

            try
            {
                servicio = new ServicioTipoDocumento();
                lista = servicio.GetTipoDocumento();
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
            foreach (var documento in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, documento);
                AgregarFila(r);
            }
        }
        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }
        private void SetearFila(DataGridViewRow r, TipoDocumento documento)
        {
            r.Cells[cmnTiposDocumentos.Index].Value = documento.Descripcion;
            r.Tag = documento;
        }
        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }
    }
}
