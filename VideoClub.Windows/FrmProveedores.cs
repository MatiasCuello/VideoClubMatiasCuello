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

        private IServicioProveedor _servicio;
        private List<ProveedorListDto> _lista;
        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }


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
            r.Cells[cmnCUIT.Index].Value = proveedorListDto.CUIT;
            r.Cells[cmnRazonSocial.Index].Value = proveedorListDto.RazonSocial;
            r.Cells[cmnDireccion.Index].Value = proveedorListDto.Direccion;
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
            FrmProveedoresAE frm = new FrmProveedoresAE();
            frm.Text = "Agregar Proveedor";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                try
                {
                    ProveedorEditDto proveedorEditDto = frm.GetProveedor();
                    if (_servicio.Existe(proveedorEditDto))
                    {
                        MessageBox.Show("Registro Repetido", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    _servicio.Guardar(proveedorEditDto);
                    DataGridViewRow r = ConstruirFila();
                    ProveedorListDto proveedorListDto = new ProveedorListDto
                    {
                        ProveedorId = proveedorEditDto.ProveedorId,
                        RazonSocial = proveedorEditDto.RazonSocial,
                        CUIT=proveedorEditDto.CUIT,
                        Direccion=proveedorEditDto.Direccion,
                        Provincia = proveedorEditDto.Provincia.NombreProvincia,
                        Localidad = proveedorEditDto.Localidad.NombreLocalidad,
                    };
                    SetearFila(r, proveedorListDto);
                    AgregarFila(r);
                    MessageBox.Show("Registro Agregado", "Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }


    }
}
