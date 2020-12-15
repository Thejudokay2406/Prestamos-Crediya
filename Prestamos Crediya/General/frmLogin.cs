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
    public partial class frmLogin : Form
    {
        //Variables para detectar Informacion del PC - Nombre, Numero de HDD y Mac
        private string Equipo_SQL = "";
        private string HDD_SQL = "";
        private string MacSeguridad_SQL = "";

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.Reloj.Enabled = true;
            this.lblHora.Text = DateTime.Now.ToString();
            this.TBUsuario.Focus();

            this.TBUsuario.ReadOnly = false;
            this.TBUsuario.BackColor = Color.FromArgb(3, 155, 229);
            this.TBContraseña.ReadOnly = false;
            this.TBContraseña.BackColor = Color.FromArgb(3, 155, 229);

            this.lblHora.ReadOnly = true;
            this.lblHora.BackColor = Color.FromArgb(255, 255, 255);

            this.textBox1.ReadOnly = true;
            this.textBox1.BackColor = Color.FromArgb(255, 255, 255);
            this.textBox2.ReadOnly = true;
            this.textBox2.BackColor = Color.FromArgb(255, 255, 255);

            //Datos de Seguridad
            this.Seguridad_SQL();
        }

        private void Seguridad_SQL()
        {
            try
            {
                //Se capturan los valores del computador donde esta iniciado
                this.HDD_SQL = Informacion_Computer.Serial_HDD();
                this.MacSeguridad_SQL = Informacion_Computer.MAC_Address();
                this.Equipo_SQL = Informacion_Computer.Nombre_PC();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TBUsuario.Text == "Tecnologia" && TBContraseña.Text == "SQL")
                {
                    frmEquipos frmEquipos = new frmEquipos();
                    //
                    frmEquipos.ShowDialog();
                }
                else
                {
                    DataTable Datos = Negocio.fUsuario.Login_SQL(this.TBUsuario.Text, this.TBContraseña.Text);
                    //Evaluamos si  existen los Datos
                    if (Datos.Rows.Count == 0)
                    {
                        MessageBox.Show("Acceso Denegado al Sistema, Usuario o Contraseña Incorrecto. Si el Problema Persiste Contacte al Area de Sistemas", "Crediya v1.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        frmMenuPrincipal frm = new frmMenuPrincipal();
                        frm.Idempleado = Datos.Rows[0][0].ToString();
                        frm.Empleado = Datos.Rows[0][1].ToString();
                        frm.UsuarioLogueado = Datos.Rows[0][2].ToString();

                        frm.SQL_Guardar = Datos.Rows[0][4].ToString();
                        frm.SQL_Editar = Datos.Rows[0][5].ToString();
                        frm.SQL_Eliminar = Datos.Rows[0][6].ToString();
                        frm.SQL_Consultar = Datos.Rows[0][7].ToString();

                        frm.Menu_Prestamos = Datos.Rows[0][8].ToString();
                        frm.Menu_Reportes = Datos.Rows[0][10].ToString();
                        frm.Menu_Sistema = Datos.Rows[0][11].ToString();

                        frm.Show();
                        this.Hide();
                    }
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBContraseña_Enter(object sender, EventArgs e)
        {
            this.TBContraseña.BackColor = Color.Azure;
        }

        private void TBUsuario_Enter(object sender, EventArgs e)
        {
            this.TBUsuario.BackColor = Color.Azure;
        }

        private void TBUsuario_Leave(object sender, EventArgs e)
        {
            this.TBUsuario.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBContraseña_Leave(object sender, EventArgs e)
        {
            this.TBContraseña.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    if (this.TBContraseña.Text == string.Empty)
                    {
                        this.TBUsuario.Focus();
                    }
                    else
                    {
                        if (TBUsuario.Text == "Tecnologia" && TBContraseña.Text == "SQL")
                        {
                            frmEquipos frmEquipos = new frmEquipos();
                            //
                            frmEquipos.ShowDialog();
                        }
                        else
                        {
                            DataTable Datos_Seguridad = Negocio.fEquipos.Seguridad_SQL(Equipo_SQL, HDD_SQL, MacSeguridad_SQL);
                            //Evaluamos si  existen los Datos
                            if (Datos_Seguridad.Rows.Count == 0)
                            {
                                MessageBox.Show("Niveles de Seguridad no Cumplidos", "Crediya - Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                ////<<<<<<----- Al pasar las pruebas de seguridad se procede a verificar los usuarios ingresados

                                DataTable Datos = Negocio.fUsuario.Login_SQL(this.TBUsuario.Text, this.TBContraseña.Text);
                                //Evaluamos si  existen los Datos
                                if (Datos.Rows.Count == 0)
                                {
                                    MessageBox.Show("Acceso Denegado al Sistema, Usuario o Contraseña Incorrecto. Si el Problema Persiste Contacte al Area de Sistemas", "Crediya", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    frmMenuPrincipal frm = new frmMenuPrincipal();
                                    frm.Idempleado = Datos.Rows[0][0].ToString();
                                    frm.Empleado = Datos.Rows[0][1].ToString();
                                    frm.UsuarioLogueado = Datos.Rows[0][2].ToString();

                                    frm.SQL_Guardar = Datos.Rows[0][4].ToString();
                                    frm.SQL_Editar = Datos.Rows[0][5].ToString();
                                    frm.SQL_Eliminar = Datos.Rows[0][6].ToString();
                                    frm.SQL_Consultar = Datos.Rows[0][7].ToString();

                                    frm.Menu_Prestamos = Datos.Rows[0][8].ToString();
                                    frm.Menu_Reportes = Datos.Rows[0][10].ToString();
                                    frm.Menu_Sistema = Datos.Rows[0][11].ToString();

                                    frm.Show();
                                    this.Hide();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBUsuario_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void TBUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                this.TBContraseña.Select();
            }
        }

        private void frmLogin_Activated(object sender, EventArgs e)
        {
            this.TBUsuario.Focus();
        }
    }
}
