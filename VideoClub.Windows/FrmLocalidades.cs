﻿using System;
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
using VideoClubEntidades.DTOs.Localidad;
using VideoClubEntidades.Entidades;

namespace VideoClub.Windows
{
    public partial class FrmLocalidades : Form
    {
        public FrmLocalidades()
        {
            InitializeComponent();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        //private IServicioProvincia _servicioProvincia;
        private IServicioLocalidades servicio;
        private List<LocalidadListDto> lista;
        private void FrmLocalidades_Load(object sender, EventArgs e)
        { 
            servicio = new ServicioLocalidades();
            ActualizarGrilla();

        }
        private void ActualizarGrilla()
        {
            try
            {
                //_servicioProvincia = new ServicioProvincia();
                lista = servicio.GetLista(null);
                MostrarDatosEnGrilla();
            }
            catch (Exception excepcion)
            {
                throw new Exception(excepcion.Message);
    }
}

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var localidadListDto in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, localidadListDto);
                AgregarFila(r);
            }
        }

        private void SetearFila(DataGridViewRow r, LocalidadListDto localidadListDto)
        {
            r.Cells[cmnLocalidades.Index].Value = localidadListDto.NombreLocalidad;
            r.Cells[cmnProvincias.Index].Value = localidadListDto.NombreProvincia;
            r.Tag = localidadListDto;
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
            FrmLocalidadesAE frm = new FrmLocalidadesAE();
            frm.Text = "Agregar Localidad";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    LocalidadEditDto localidadEditDto = frm.GetLocalidad();
                    if (!servicio.Existe(localidadEditDto))
                    {
                        servicio.Guardar(localidadEditDto);
                        LocalidadListDto localidadListDto = new LocalidadListDto
                        {
                            LocalidadId = localidadEditDto.LocalidadId,
                            NombreLocalidad = localidadEditDto.NombreLocalidad,
                           NombreProvincia =localidadEditDto.Provincia.NombreProvincia
                    };
                        DataGridViewRow r = ConstruirFila();
                        SetearFila(r, localidadListDto);
                        AgregarFila(r);
                        MessageBox.Show("Registro agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarGrilla();
                    }
                    else
                    {
                        MessageBox.Show("Registro duplicado... Alta denegada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow r = dgvDatos.SelectedRows[0];
            LocalidadListDto localidadDto = (LocalidadListDto)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea borrar el registro seleccionado: {localidadDto.NombreLocalidad}?",
                        "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }
            try
            {
                servicio.Borrar(localidadDto.LocalidadId);
                dgvDatos.Rows.Remove(r);
                MessageBox.Show("Registro eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow r = dgvDatos.SelectedRows[0];
            LocalidadListDto localidadListDto = (LocalidadListDto)r.Tag;
            LocalidadListDto localidadListDtoAux =localidadListDto.Clone() as LocalidadListDto;
            FrmLocalidadesAE frm = new FrmLocalidadesAE();
            LocalidadEditDto localidadEditDto = servicio.GetLocalidadPorId(localidadListDto.LocalidadId);
            frm.Text = "Editar Localidad";
            frm.SetLocalidad(localidadEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                localidadEditDto = frm.GetLocalidad();
                if (!servicio.Existe(localidadEditDto))
                {
                    servicio.Guardar(localidadEditDto);
                    localidadListDto.LocalidadId = localidadEditDto.LocalidadId;
                    localidadListDto.NombreLocalidad = localidadEditDto.NombreLocalidad;
                    localidadListDto.NombreProvincia = localidadEditDto.Provincia.NombreProvincia;
                    SetearFila(r, localidadListDto);
                    MessageBox.Show("Registro editado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                   SetearFila(r, localidadListDtoAux);
                    MessageBox.Show("Registro duplicado... Alta denegada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exception)
            {
                SetearFila(r, localidadListDtoAux);
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarLocalidades frm = new FrmBuscarLocalidades();
            frm.Text = "Seleccionar Localidad";
            DialogResult dr = frm.ShowDialog(this);
            if (dr==DialogResult.Cancel)
            {
                return;
            }
            else
            {
                try
                {
                    Provincia provincia = frm.GetProvincia();
                    lista = servicio.GetLista(provincia);
                    MostrarDatosEnGrilla();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }


        }
        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }
    }
}


