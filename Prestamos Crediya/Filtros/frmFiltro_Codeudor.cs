using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Negocio;

namespace Prestamos_Crediya
{
    public partial class frmFiltro_Codeudor : Form
    {
        public frmFiltro_Codeudor()
        {
            InitializeComponent();
        }

        private void frmFiltro_Codeudor_Load(object sender, EventArgs e)
        {
            //
            this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);
        }

        //Mensaje de confirmacion
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Crediya - Solicitud Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        //Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Crediya - Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void DGFiltro_Resultados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                frmSolicitud frmSol = frmSolicitud.GetInstancia();

                //Variables Para Los Filtros
                string idcodeudor, codeudor, documento, empresa, cargo;

                if (frmSol.Filtro)
                {
                    idcodeudor = this.DGFiltro_Resultados.CurrentRow.Cells[0].Value.ToString();
                    codeudor = this.DGFiltro_Resultados.CurrentRow.Cells[1].Value.ToString();
                    documento = this.DGFiltro_Resultados.CurrentRow.Cells[2].Value.ToString();
                    empresa = this.DGFiltro_Resultados.CurrentRow.Cells[3].Value.ToString();
                    cargo = this.DGFiltro_Resultados.CurrentRow.Cells[4].Value.ToString();
                    frmSol.setCodeudor(idcodeudor, codeudor, documento, empresa, cargo);
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TBBuscar.Text != "")
                {
                    this.DGFiltro_Resultados.DataSource = fCodeudor.Buscar(this.TBBuscar.Text, 1);
                    //this.DGFiltro_Resultados.Columns[0].Visible = false;

                    lblTotal.Text = "Datos Registrados: " + Convert.ToString(DGFiltro_Resultados.Rows.Count);
                    this.DGFiltro_Resultados.Enabled = true;
                }
                else
                {

                    //Se Limpian las Filas y Columnas de la tabla
                    this.DGFiltro_Resultados.DataSource = null;
                    this.DGFiltro_Resultados.Enabled = false;
                    this.lblTotal.Text = "Datos Registrados: 0";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
