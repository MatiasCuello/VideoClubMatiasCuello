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
using VideoClubEntidades.DTOs.Proveedor;

namespace VideoClub.Windows
{
    public partial class FrmProveedores : Form
    {
        public FrmProveedores()
        {
            InitializeComponent();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private IServicioProveedor _servicio;
        private List<ProveedorListDto> _lista;
        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            try
            {
                _servicio = new ServicioProveedor();
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
            foreach (var proveedorListDto in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, proveedorListDto);
                AgregarFila(r);
            }
        }

        private void SetearFila(DataGridViewRow r, ProveedorListDto proveedorListDto)
        {
            r.Cells[cmnRazonSocial.Index].Value = proveedorListDto.RazonSocial;
            r.Cells[cmnCUIT.Index].Value = proveedorListDto.CUIT;
            r.Cells[cmnLocalidad.Index].Value = proveedorListDto.Localidad;
            r.Cells[cmnProvincia.Index].Value = proveedorListDto.Provincia;

            r.Tag = proveedorListDto;
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

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            
        }
    }
}
