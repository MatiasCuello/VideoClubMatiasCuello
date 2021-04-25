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
using VideoClubEntidades.DTOs.Pelicula;

namespace VideoClub.Windows
{
    public partial class FrmPeliculas : Form
    {
        public FrmPeliculas()
        {
            InitializeComponent();
        }
        private IServicioPelicula _servicio;
        private List<PeliculaListDto> _lista;

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmPeliculas_Load(object sender, EventArgs e)
        {
            try
            {
                _servicio = new ServicioPelicula();
                _lista = _servicio.GetLista();
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
            foreach (var peliculaListDto in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, peliculaListDto);
                AgregarFila(r);
            }
        }

        private void SetearFila(DataGridViewRow r, PeliculaListDto peliculaListDto)
        {
            r.Cells[cmnTitulo.Index].Value = peliculaListDto.Titulo;
            r.Cells[cmnGenero.Index].Value = peliculaListDto.Genero;
            r.Cells[cmnSoporte.Index].Value = peliculaListDto.Soporte;
            r.Cells[cmnDuracion.Index].Value = peliculaListDto.DuracionEnMinutos;
            r.Cells[cmnActiva.Index].Value = peliculaListDto.Activa;
            r.Cells[cmnAlquilado.Index].Value = peliculaListDto.Alquilado;

            r.Tag = peliculaListDto;
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
    }
}
