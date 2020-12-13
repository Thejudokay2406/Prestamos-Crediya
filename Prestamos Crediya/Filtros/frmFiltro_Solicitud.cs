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
    public partial class frmFiltro_Solicitud : Form
    {
        public frmFiltro_Solicitud()
        {
            InitializeComponent();
        }

        private void frmFiltro_Solicitud_Load(object sender, EventArgs e)
        {
            //
            this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TBBuscar.Text != "")
                {
                    this.DGFiltro_Resultados.DataSource = fSolicitud.Buscar(1, this.TBBuscar.Text);
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

        private void DGFiltro_Resultados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                frmConsignacion frmCons = frmConsignacion.GetInstancia();

                //Variables Para Los Filtros
                string idsolicitud, orden, codeudor, documento, valor;

                if (frmCons.Filtro)
                {
                    idsolicitud = this.DGFiltro_Resultados.CurrentRow.Cells[0].Value.ToString();
                    orden = this.DGFiltro_Resultados.CurrentRow.Cells[1].Value.ToString();
                    codeudor = this.DGFiltro_Resultados.CurrentRow.Cells[2].Value.ToString();
                    documento = this.DGFiltro_Resultados.CurrentRow.Cells[3].Value.ToString(); 
                    valor = this.DGFiltro_Resultados.CurrentRow.Cells[4].Value.ToString();
                    frmCons.setSolicitud(idsolicitud, orden, codeudor, documento, valor);
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
