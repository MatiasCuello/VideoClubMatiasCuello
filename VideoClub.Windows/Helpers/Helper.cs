using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoClub.Servicios.Servicios;
using VideoClub.Servicios.Servicios.Facades;
using VideoClubEntidades.DTOs.Localidad;
using VideoClubEntidades.Entidades;

namespace VideoClub.Windows.Helper
{
    public class Helper
    {
        public static void CargarDatosComboTipoDocumento(ref ComboBox comboBox)
        {
            IServicioTipoDocumento servicioTipoDocumento = new ServicioTipoDocumento();
            var lista = servicioTipoDocumento.GetTipoDocumento();
            var defaultTipoDocumento = new TipoDocumento
            {
                TipoDocumentoId = 0,
                Descripcion = "Seleccionar Tipo"
            };
            lista.Insert(0, defaultTipoDocumento);
            comboBox.DataSource = lista;
            comboBox.ValueMember = "TipoDocumentoId";
            comboBox.DisplayMember = "Descripcion";
            comboBox.SelectedIndex = 0;

        }
        public static void CargarDatosComboProvincias(ref ComboBox comboBox)
        {
            IServicioProvincia servicioProvincia = new ServicioProvincia();
            var lista = servicioProvincia.GetProvincia();
            var defaultProvincia = new Provincia
            {
                ProvinciaId = 0,
                NombreProvincia = "Seleccionar Provincia"
            };
            lista.Insert(0, defaultProvincia);
            comboBox.DataSource = lista;
            comboBox.ValueMember = "ProvinciaId";
            comboBox.DisplayMember = "NombreProvincia";
            comboBox.SelectedIndex = 0;

        }


        internal static void CargarDatosComboLocalidades(ref ComboBox comboBox, Provincia provincia)
        {
            IServicioLocalidades servicioLocalidades = new ServicioLocalidades();
            var lista = servicioLocalidades.GetLista(provincia);
            var defaultLocalidad = new LocalidadListDto
            {
                LocalidadId = 0,
                NombreLocalidad = "Seleccionar Localidad"
            };
            lista.Insert(0, defaultLocalidad);
            comboBox.DataSource = lista;
            comboBox.ValueMember = "LocalidadId";
            comboBox.DisplayMember = "NombreLocalidad";
            comboBox.SelectedIndex = 0;

        }

    }
}
