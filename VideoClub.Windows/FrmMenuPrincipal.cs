using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoClub.Windows
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FrmProvincias frm = new FrmProvincias();
            frm.ShowDialog(this);
        }

        private void SoportesButton_Click(object sender, EventArgs e)
        {
            FrmSoportes frm = new FrmSoportes();
            frm.ShowDialog(this);
        }

        private void EstadosButton_Click(object sender, EventArgs e)
        {
            FrmEstados frm = new FrmEstados();
            frm.ShowDialog(this);
        }
       

        private void CalificacionesButton_Click(object sender, EventArgs e)
        {
            FrmCalificaciones frm = new FrmCalificaciones();
            frm.ShowDialog(this);
        }

        private void GenerosButton_Click_1(object sender, EventArgs e)
        {
            FrmGeneros frm = new FrmGeneros();
            frm.ShowDialog(this);
        }

        private void LocalidadesButton_Click(object sender, EventArgs e)
        {
            FrmLocalidades frm = new FrmLocalidades();
            frm.ShowDialog(this);
        }

        private void SociosButton_Click(object sender, EventArgs e)
        {
            FrmSocios frm = new FrmSocios();
            frm.ShowDialog(this);
        }

        private void EmpleadosButton_Click(object sender, EventArgs e)
        {
            FrmEmpleados frm = new FrmEmpleados();
            frm.ShowDialog(this);
        }

        private void ProveedoresButton_Click(object sender, EventArgs e)
        {
            FrmProveedores frm = new FrmProveedores();
            frm.ShowDialog(this);
        }

        private void TiposDocumentosButton_Click(object sender, EventArgs e)
        {
            FrmTiposDocumentos frm = new FrmTiposDocumentos();
            frm.ShowDialog(this);
        }
    }
}
