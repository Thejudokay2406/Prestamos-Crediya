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
    public partial class frmConsignacion : Form
    {
        // Variable con la cual se define si el procecimiento 
        // A realizar es Editar, Guardar, Buscar,Eliminar
        private bool Digitar = true;
        public bool Filtro = true;
        private string Campo = "Campo Obligatorio";

        //Variable para Metodo SQL Guardar, Eliminar, Editar, Consultar
        public string Guardar, Editar, Consultar, Eliminar = "";

        //Variables para Eliminar y ejecutar los procedimientos Internos en los paneles
        private bool Eliminar_Consignacion = false;

        //Variable para Captura el Empleado Logueado
        public int IDEmpleado;

        //Variable para Agregar los Detalles a la Base de Datos
        private DataTable DtDetalle_Consignacion = new DataTable();

        //Variables para Llenar los Campos de Texto Segun la Consulta en la Base de Datos
        private string Idsolicitud, Idconsignacion, Nombre, Documento, Valor, Abono, Fecha, Observacion = "";

        // Variables para Generar Codigo de Proveedor
        // Y Consultarlo desde la Base de Datos
        public string Codigo_SQL = "";
        public string Codigo_ID = "";

        private static frmConsignacion _Instancia;

        public static frmConsignacion GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmConsignacion();
            }
            return _Instancia;
        }
        public frmConsignacion()
        {
            InitializeComponent();
        }

        private void frmConsignacion_Load(object sender, EventArgs e)
        {
            //Inicio de Clase y Botones
            this.Botones();
            this.Habilitar();
            this.CrearTabla();

            //Ocultacion de Texboxt
            this.TBIdconsignacion.Visible = false;
            this.TBIdsolicitud.Visible = false;

            //
            this.TBValorAbono.Select();

            //Color para Texboxt Buscar
            this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void Habilitar()
        {
            //Datos Basicos
            this.TBOrdenDeSolicitud.Enabled = false;
            this.TBOrdenDeSolicitud.BackColor = Color.FromArgb(72, 209, 204);
            this.TBNombres.Enabled = false;
            this.TBNombres.BackColor = Color.FromArgb(72, 209, 204);
            this.TBIdentificacion.Enabled = false;
            this.TBIdentificacion.BackColor = Color.FromArgb(72, 209, 204);
            this.TBValorSolicitado.Enabled = false;
            this.TBValorSolicitado.BackColor = Color.FromArgb(72, 209, 204);
            this.DTFechadesolicitud.Enabled = false;
            this.DTFechadesolicitud.BackColor = Color.FromArgb(3, 155, 229);
            this.TBValorAbono.ReadOnly = false;
            this.TBValorAbono.BackColor = Color.FromArgb(3, 155, 229);
            this.TBObservacion.ReadOnly = false;
            this.TBObservacion.BackColor = Color.FromArgb(3, 155, 229);

            //
            this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);
        }


        private void Limpiar_Datos()
        {
            //Datos Basicos
            this.TBOrdenDeSolicitud.Clear();
            this.TBNombres.Clear();
            this.TBIdentificacion.Clear();
            this.TBValorAbono.Clear();
            this.TBValorSolicitado.Clear();
            this.TBObservacion.Clear();

            //
            this.TBBuscar.Clear();
            this.TBIdconsignacion.Clear();
            this.TBIdsolicitud.Clear();

            //FOCUS
            this.TBValorAbono.Select();
        }

        private void CrearTabla()
        {
            try
            {
                this.DGLista_Abonos.DataSource = this.DtDetalle_Consignacion;

                this.DtDetalle_Consignacion.Columns.Add("Orden", System.Type.GetType("System.Int64"));
                this.DtDetalle_Consignacion.Columns.Add("Deudor", System.Type.GetType("System.String"));
                this.DtDetalle_Consignacion.Columns.Add("Identificación", System.Type.GetType("System.Int64"));
                this.DtDetalle_Consignacion.Columns.Add("Valor", System.Type.GetType("System.Int64"));
                this.DtDetalle_Consignacion.Columns.Add("Fecha", System.Type.GetType("System.DateTime"));
                this.DtDetalle_Consignacion.Columns.Add("Abono", System.Type.GetType("System.Int64"));
                this.DtDetalle_Consignacion.Columns.Add("Observación", System.Type.GetType("System.String"));

                //Aliniacion de las Celdas de Cada Columna
                this.DGLista_Abonos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGLista_Abonos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGLista_Abonos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGLista_Abonos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //this.DGLista_Abonos.Columns[0].Visible = false;
                //this.DGDetalle_Codeudor.Columns[1].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Botones()
        {
            if (Digitar)
            {
                this.btnGuardar.Enabled = true;
                this.btnGuardar.Text = "Guardar - F10";
                this.btnCancelar.Enabled = false;
            }
            else if (!Digitar)
            {
                this.btnGuardar.Enabled = true;
                this.btnGuardar.Text = "Editar - F10";
                this.btnCancelar.Enabled = true;
            }
        }

        public void setSolicitud(string idsolicitud,string codigo,string nombre, string documento,string valor)
        {
            this.TBIdsolicitud.Text = idsolicitud;
            this.TBOrdenDeSolicitud.Text = codigo;
            this.TBNombres.Text = nombre;
            this.TBIdentificacion.Text = documento;
            this.TBValorSolicitado.Text = valor;
            //this.TBValorSolicitado.Text = valor;
        }

        private void Actualizar_DetConsignacion()
        {
            this.DGLista_Abonos.DataSource = fConsignacion.Lista_Consignacion(1, Convert.ToInt32(TBOrdenDeSolicitud.Text));
            this.lblTotal_Consignacion.Text = "Consignaciones en Lista: " + Convert.ToString(DGLista_Abonos.Rows.Count);
        }

        private void Guardar_SQL()
        {
            try
            {
                string rptaDatosBasicos = "";

                if (this.TBNombres.Text == string.Empty)
                {
                    MensajeError("Falta ingresar el campo solicitante.");
                    TBNombres.BackColor = Color.FromArgb(250, 235, 215);
                }
                else if (this.TBIdentificacion.Text == string.Empty)
                {
                    MensajeError("Falta ingresar el campo identificación del solicitante.");
                    TBIdentificacion.BackColor = Color.FromArgb(250, 235, 215);
                }
                else if (this.TBValorSolicitado.Text == string.Empty)
                {
                    MensajeError("Falta ingresar el valor solicitado.");
                    TBValorSolicitado.BackColor = Color.FromArgb(250, 235, 215);
                }
                else if (this.TBValorAbono.Text == string.Empty)
                {
                    MensajeError("Falta ingresar el valor del Abono.");
                    TBValorAbono.BackColor = Color.FromArgb(250, 235, 215);
                }

                else
                {
                    if (this.Digitar)
                    {
                        rptaDatosBasicos = fConsignacion.Guardar_DatosBasicos
                            (
                                1, Convert.ToInt32(this.TBOrdenDeSolicitud.Text), this.TBNombres.Text, Convert.ToInt64(this.TBIdentificacion.Text), Convert.ToInt64(this.TBValorSolicitado.Text), Convert.ToInt64(this.TBValorAbono.Text), this.DTFechadesolicitud.Value, this.TBObservacion.Text
                            );
                    }
                    else
                    {
                        rptaDatosBasicos = fConsignacion.Editar_DatosBasicos
                            (
                                2, Convert.ToInt32(this.TBIdconsignacion.Text), Convert.ToInt32(this.TBOrdenDeSolicitud.Text), this.TBNombres.Text, Convert.ToInt64(this.TBIdentificacion.Text), Convert.ToInt64(this.TBValorSolicitado.Text), Convert.ToInt64(this.TBValorAbono.Text), this.DTFechadesolicitud.Value, this.TBObservacion.Text
                            );
                    }

                    if (rptaDatosBasicos.Equals("OK"))
                    {
                        if (this.Digitar)
                        {
                            this.MensajeOk("La Solicitud de: " + this.TBNombres.Text + " con Codigo: " + this.TBOrdenDeSolicitud.Text + " a Sido Registrada Correctamente");
                        }

                        else
                        {
                            this.MensajeOk("El Registro de La Solicitud de: " + this.TBNombres.Text + " con Codigo: " + this.TBOrdenDeSolicitud.Text + " a Sido Actualizado Correctamente");
                        }
                    }

                    else
                    {
                        this.MensajeError(rptaDatosBasicos);
                    }

                    //Llamada de Clase
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //Mensaje de confirmacion
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Crediya", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Crediya - Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Digitar)
                {
                    if (Guardar == "1")
                    {
                        //Metodo Guardar y editar
                        this.Guardar_SQL();
                    }

                    else
                    {
                        MessageBox.Show("El Usuario Iniciado Actualmente no Contiene Permisos Para Guardar Datos", "Crediya", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        //Llamada de Clase
                        this.Digitar = true;
                        this.Botones();
                        this.Limpiar_Datos();
                    }
                }

                else
                {
                    if (Editar == "1")
                    {
                        //Metodo Guardar y editar
                        this.Guardar_SQL();
                    }
                    else
                    {
                        MessageBox.Show("El Usuario Iniciado Actualmente no Contiene Permisos Para Editar Datos", "Crediya", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        //Llamada de Clase
                        this.Digitar = false;
                        this.Limpiar_Datos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnAgregar_Abono_Click(object sender, EventArgs e)
        {
            try
            {
                if (Digitar)
                {
                    if (this.TBOrdenDeSolicitud.Text == String.Empty)
                    {
                        this.MensajeError("POR FAVOR ESPECIFIQUE EL NÚMERO DE ORDEN QUE DESEA AGREGAR A LA LISTA");
                        this.TBOrdenDeSolicitud.Select();
                    }
                    else if (this.TBNombres.Text == String.Empty)
                    {
                        this.MensajeError("POR FAVOR ESPECIFIQUE EL NOMBRE DEL CODEUDOR");
                        this.TBNombres.Select();
                    }
                    else if (this.TBIdentificacion.Text == String.Empty)
                    {
                        this.MensajeError("POR FAVOR ESPECIFIQUE EL NÚMERO DE IDENTIFICACIÓN DEL CODEUDOR");
                        this.TBIdentificacion.Select();
                    }
                    else if (this.TBValorSolicitado.Text == String.Empty)
                    {
                        this.MensajeError("POR FAVOR ESPECIFIQUE EL VALOR INICIAL DEL PRESTAMO");
                        this.TBValorSolicitado.Select();
                    }
                    else if (this.TBValorAbono.Text == String.Empty)
                    {
                        this.MensajeError("POR FAVOR ESPECIFIQUE EL VALOR DEL ABONO QUE DESEA AGREGAR");
                        this.TBValorAbono.Select();
                    }
                    
                    else
                    {
                        DataRow fila = this.DtDetalle_Consignacion.NewRow();
                        fila["Orden"] = Convert.ToInt64(this.TBOrdenDeSolicitud.Text);
                        fila["Deudor"] = this.TBNombres.Text;
                        fila["Identificación"] = Convert.ToInt64(this.TBIdentificacion.Text);
                        fila["Valor"] = Convert.ToInt64(this.TBValorSolicitado.Text);
                        fila["Fecha"] = this.DTFechadesolicitud.Value.ToString("dd-MM-yyyy");
                        fila["Abono"] = Convert.ToInt64(this.TBValorAbono.Text);
                        fila["Observación"] = this.TBObservacion.Text;
                        this.DtDetalle_Consignacion.Rows.Add(fila);

                        //SOLO SE LIMPIA EL CAMPO DE ABONOS POR SI DESEA SEGUIR REGISTRANDO 
                        this.TBValorAbono.Clear();
                    }
                }
                else
                {
                    if (this.TBOrdenDeSolicitud.Text == String.Empty)
                    {
                        this.MensajeError("POR FAVOR ESPECIFIQUE EL NÚMERO DE ORDEN QUE DESEA AGREGAR A LA LISTA");
                        this.TBOrdenDeSolicitud.Select();
                    }
                    else if (this.TBNombres.Text == String.Empty)
                    {
                        this.MensajeError("POR FAVOR ESPECIFIQUE EL NOMBRE DEL CODEUDOR");
                        this.TBNombres.Select();
                    }
                    else if (this.TBIdentificacion.Text == String.Empty)
                    {
                        this.MensajeError("POR FAVOR ESPECIFIQUE EL NÚMERO DE IDENTIFICACIÓN DEL CODEUDOR");
                        this.TBIdentificacion.Select();
                    }
                    else if (this.TBValorSolicitado.Text == String.Empty)
                    {
                        this.MensajeError("POR FAVOR ESPECIFIQUE EL VALOR INICIAL DEL PRESTAMO");
                        this.TBValorSolicitado.Select();
                    }
                    else if (this.TBValorAbono.Text == String.Empty)
                    {
                        this.MensajeError("POR FAVOR ESPECIFIQUE EL VALOR DEL ABONO QUE DESEA AGREGAR");
                        this.TBValorAbono.Select();
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar la Ubicacion del Producto?", "Crediya", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            string rptaDatosBasicos = "";
                            rptaDatosBasicos = fConsignacion.Guardar_Consignacion

                                    (
                                        //Datos Auxiliares
                                        1,

                                        //Datos Basicos
                                        Convert.ToInt64(this.TBOrdenDeSolicitud.Text), this.TBNombres.Text, Convert.ToInt64(this.TBIdentificacion.Text), Convert.ToInt64(this.TBValorSolicitado.Text), Convert.ToInt64(this.TBValorAbono.Text), this.DTFechadesolicitud.Value, this.TBObservacion.Text
                                    );

                            if (rptaDatosBasicos.Equals("OK"))
                            {
                                this.MensajeOk("EL ABONO DEL DEUDOR: " + TBNombres.Text + " CON CODIGO: " + this.TBOrdenDeSolicitud.Text + " A SIDO REGISTRADO EXITOSAMENTE");
                            }

                            else
                            {
                                this.MensajeError(rptaDatosBasicos);
                            }

                            //SOLO SE LIMPIA EL CAMPO DE ABONOS POR SI DESEA SEGUIR REGISTRANDO 
                            this.TBValorAbono.Clear();

                            this.Actualizar_DetConsignacion();
                        }
                        else
                        {
                            this.TBValorAbono.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TBValorAbono_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBObservacion.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Escape))
                {
                    //Al precionar la tecla Escape Se Limpiaran los campos de texto 

                    //Llamada de Clase
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    this.Digitar = true;
                    //this.TBIdproducto.Text = "0";

                    this.Botones();
                    this.Limpiar_Datos();
                    this.CrearTabla();

                    this.TBBuscar.Clear();

                    //Se Limpian las Filas y Columnas de la tabla
                    this.DGResultados.DataSource = null;
                    this.lblTotal.Text = "Datos Registrados: 0";
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Crediya", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Crediya", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBValorAbono.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Crediya", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBValorAbono.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBObservacion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBValorAbono.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Escape))
                {
                    //Al precionar la tecla Escape Se Limpiaran los campos de texto 

                    //Llamada de Clase
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    this.Digitar = true;
                    //this.TBIdproducto.Text = "0";

                    this.Botones();
                    this.Limpiar_Datos();
                    this.CrearTabla();

                    this.TBBuscar.Clear();

                    //Se Limpian las Filas y Columnas de la tabla
                    this.DGResultados.DataSource = null;
                    this.lblTotal.Text = "Datos Registrados: 0";
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Crediya", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Crediya", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBValorAbono.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Crediya", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBValorAbono.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void DGLista_Abonos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Teniendo en cuenta que DataGridView1 es tu DataGridView.
                DataGridViewRow fila = DGLista_Abonos.Rows[e.RowIndex];

                //Pasamos los datos de la celda seleccionada a los texboxt correspondientes
                this.TBOrdenDeSolicitud.Text = Convert.ToString(fila.Cells[0].Value);
                this.TBNombres.Text = Convert.ToString(fila.Cells[1].Value);
                this.TBIdentificacion.Text = Convert.ToString(fila.Cells[2].Value);
                this.TBValorSolicitado.Text = Convert.ToString(fila.Cells[3].Value);
                this.DTFechadesolicitud.Text = Convert.ToString(fila.Cells[4].Value);
                this.TBValorAbono.Text = Convert.ToString(fila.Cells[5].Value);
                this.TBObservacion.Text = Convert.ToString(fila.Cells[6].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void DGLista_Abonos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Teniendo en cuenta que DataGridView1 es tu DataGridView.
                DataGridViewRow fila = DGLista_Abonos.Rows[e.RowIndex];

                //Pasamos los datos de la celda seleccionada a los texboxt correspondientes
                this.TBOrdenDeSolicitud.Text = Convert.ToString(fila.Cells[0].Value);
                this.TBNombres.Text = Convert.ToString(fila.Cells[1].Value);
                this.TBIdentificacion.Text = Convert.ToString(fila.Cells[2].Value);
                this.TBValorSolicitado.Text = Convert.ToString(fila.Cells[3].Value);
                this.DTFechadesolicitud.Text = Convert.ToString(fila.Cells[4].Value);
                this.TBValorAbono.Text = Convert.ToString(fila.Cells[5].Value);
                this.TBObservacion.Text = Convert.ToString(fila.Cells[6].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Digitar = true;
                //this.TBIdproducto.Text = "0";

                this.Botones();
                this.Limpiar_Datos();
                this.CrearTabla();

                this.TBBuscar.Clear();

                //Se Limpian las Filas y Columnas de la tabla
                this.DGResultados.DataSource = null;
                this.lblTotal.Text = "Datos Registrados: 0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEliminar_Abono_Click(object sender, EventArgs e)
        {
            try
            {
                int Fila = this.DGLista_Abonos.CurrentCell.RowIndex;
                DataRow row = this.DtDetalle_Consignacion.Rows[Fila];

                //Se remueve la fila
                this.DtDetalle_Consignacion.Rows.Remove(row);
            }
            catch (Exception ex)
            {
                MensajeError("Por favor seleccione la Consignación que desea Remover del registo");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Eliminar == "1")
                {
                    DialogResult Opcion;
                    string Respuesta = "";
                    int Idconsignacion, Idabono;

                    Opcion = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "Crediya", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion == DialogResult.OK)
                    {
                        if (DGLista_Abonos.SelectedRows.Count > 0)
                        {
                            Idconsignacion = Convert.ToInt32(DGLista_Abonos.CurrentRow.Cells[0].Value.ToString());
                            //Idabono = Convert.ToInt32(DGLista_Abonos.CurrentRow.Cells["Idubicacion"].Value.ToString());
                            Respuesta = Negocio.fConsignacion.Eliminar_Abono(Idconsignacion, 1);
                        }

                        if (Respuesta.Equals("OK"))
                        {
                            this.MensajeOk("Consignación Eliminada Correctamente");
                        }
                        else
                        {
                            this.MensajeError(Respuesta);
                        }
                    }

                    //
                    this.Actualizar_DetConsignacion();
                }
                else
                {
                    MessageBox.Show("Acceso Denegado Para Realizar Eliminaciones en el Sistema", "Crediya - Solicitud Rechazada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            frmFiltro_Solicitud frmFiltro_Solicitud = new frmFiltro_Solicitud();
            frmFiltro_Solicitud.ShowDialog();
        }

        private void TBBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Consultar == "1")
                {
                    if (TBBuscar.Text != "")
                    {
                        this.DGResultados.DataSource = fConsignacion.Buscar(this.TBBuscar.Text, 1);
                        //this.DGResultadoss.Columns[1].Visible = false;

                        lblTotal.Text = "Datos Registrados: " + Convert.ToString(DGResultados.Rows.Count);

                        this.btnEliminar.Enabled = true;
                        this.btnImprimir.Enabled = true;
                        this.DGResultados.Enabled = true;
                    }
                    else
                    {

                        //Se Limpian las Filas y Columnas de la tabla
                        this.DGResultados.DataSource = null;
                        this.DGResultados.Enabled = false;
                        this.lblTotal.Text = "Datos Registrados: 0";

                        this.btnEliminar.Enabled = false;
                        this.btnImprimir.Enabled = false;
                    }
                }

                else
                {
                    MessageBox.Show("EL USUARIO INICIADO NO CONTIENE PERMISOS PARA REALIZAR CONSULTAS.", "CREDIYA - 'ACCESO DENEGADO' ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void DGResultados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Digitar = false;

                if (Editar == "1")
                {
                    //
                    this.TBIdconsignacion.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells[0].Value);
                    this.TBOrdenDeSolicitud.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells[1].Value);
                    this.TBNombres.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells[2].Value);
                    this.TBIdentificacion.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells[3].Value);
                    this.TBValorSolicitado.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells[4].Value);
                    this.DTFechadesolicitud.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells[5].Value);
                    this.TBObservacion.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells[6].Value);

                    //
                    this.Limpiar_Datos();

                }
                else
                {
                    MessageBox.Show("El Usuario Iniciado Actualmente no Contiene Permisos Para Actualizar Datos en el Sistema", "Crediya - 'Acceso Denegado' ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBOrdenDeSolicitud_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void frmConsignacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void TBIdconsignacion_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable Datos = Negocio.fConsignacion.Buscar(this.TBIdconsignacion.Text, 4);
                //Evaluamos si  existen los Datos
                if (Datos.Rows.Count == 0)
                {
                    MessageBox.Show("Acceso Denegado al Sistema, Usuario o Contraseña Incorrecto. Si el Problema Persiste Contacte al Area de Sistemas", "Crediya v1.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.Idconsignacion = Datos.Rows[0][0].ToString();
                    this.Idsolicitud = Datos.Rows[0][1].ToString();

                    this.Nombre = Datos.Rows[0][2].ToString();
                    this.Documento = Datos.Rows[0][3].ToString();
                    this.Valor = Datos.Rows[0][4].ToString();
                    this.Abono = Datos.Rows[0][5].ToString();
                    this.Fecha = Datos.Rows[0][6].ToString();
                    this.Observacion = Datos.Rows[0][7].ToString();;

                    //Se procede a llenar los campos de texto
                    this.TBIdconsignacion.Text = Idconsignacion;
                    this.TBIdsolicitud.Text = Idsolicitud;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
