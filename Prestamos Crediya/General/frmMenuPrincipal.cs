using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prestamos_Crediya
{
    public partial class frmMenuPrincipal : Form
    {
        public string Idempleado = "";
        public string Empleado = "";
        //public string Cede = "";
        //public string BaseDeDatos = "";

        public string UsuarioLogueado = "";

        //Menu Principal
        public string Menu_Prestamos = "";
        public string Menu_Sistema = "";
        public string Menu_Reportes = "";

        //Permisos de Operacion Que Vienen de la Base de Datos

        public string SQL_Guardar = "";
        public string SQL_Editar = "";
        public string SQL_Eliminar = "";
        public string SQL_Consultar = "";

        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {
            this.GestionDeUsuarios();

            //this.datosBasicosToolStripMenuItem.Enabled = false;
        }
        private void GestionDeUsuarios()
        {
            //Barra de Tareas
            this.TSEmpleadoRegistrado.Text = Empleado;
            this.TSUsuarioLogueado.Text = UsuarioLogueado;

            //Menu
            if (Menu_Prestamos == "Si")
            {
                this.prestamosToolStripMenuItem.Enabled = true;
            }
            if (Menu_Prestamos == "No")
            {
                this.prestamosToolStripMenuItem.Enabled = false;
            }

            if (Menu_Sistema == "Si")
            {
                this.sistemaToolStripMenuItem.Enabled = true;
            }
            if (Menu_Sistema == "No")
            {
                this.sistemaToolStripMenuItem.Enabled = false;
            }

            if (Menu_Reportes == "Si")
            {
                this.reportesToolStripMenuItem.Enabled = true;
            }
            if (Menu_Reportes == "No")
            {
                this.reportesToolStripMenuItem.Enabled = false;
            }

        }

        private void codeudorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCodeudor frmCodeudor = new frmCodeudor();
            frmCodeudor.MdiParent = this;
            frmCodeudor.Show(); ;

            frmCodeudor.Guardar = Convert.ToString(this.SQL_Guardar);
            frmCodeudor.Editar = Convert.ToString(this.SQL_Editar);
            frmCodeudor.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmCodeudor.Consultar = Convert.ToString(this.SQL_Consultar);
            //frmCodeudor.Imprimir = Convert.ToString(this.SQL_Imprimir);
        }

        private void frmMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void solicitudToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSolicitud frmSolicitud = frmSolicitud.GetInstancia();
            frmSolicitud.MdiParent = this;
            frmSolicitud.Show();

            frmSolicitud.Guardar = Convert.ToString(this.SQL_Guardar);
            frmSolicitud.Editar = Convert.ToString(this.SQL_Editar);
            frmSolicitud.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmSolicitud.Consultar = Convert.ToString(this.SQL_Consultar);
        }

        private void consignaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsignacion frmConsignacion = frmConsignacion.GetInstancia();
            frmConsignacion.MdiParent = this;
            frmConsignacion.Show();

            frmConsignacion.Guardar = Convert.ToString(this.SQL_Guardar);
            frmConsignacion.Editar = Convert.ToString(this.SQL_Editar);
            frmConsignacion.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmConsignacion.Consultar = Convert.ToString(this.SQL_Consultar);
        }

        private void gastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGastos frmGastos = new frmGastos();
            frmGastos.MdiParent = this;
            frmGastos.Show();

            frmGastos.Guardar = Convert.ToString(this.SQL_Guardar);
            frmGastos.Editar = Convert.ToString(this.SQL_Editar);
            frmGastos.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmGastos.Consultar = Convert.ToString(this.SQL_Consultar);
        }
    }
}
