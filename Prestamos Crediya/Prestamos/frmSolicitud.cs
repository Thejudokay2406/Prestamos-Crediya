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
    public partial class frmSolicitud : Form
    {
        // Variable con la cual se define si el procecimiento 
        // A realizar es Editar, Guardar, Buscar,Eliminar
        private bool Digitar = true;
        public bool Filtro = true;
        private string Campo = "Campo Obligatorio";

        //Variable para Metodo SQL Guardar, Eliminar, Editar, Consultar
        public string Guardar = "";
        public string Editar = "";
        public string Consultar = "";
        public string Eliminar = "";

        //Variable para Captura el Empleado Logueado
        public int IDEmpleado;

        //Variable para Agregar los Detalles a la Base de Datos
        private DataTable DtDetalle_Codeudor = new DataTable();

        //Variables para Llenar La Tabla de Codeudores
        private string Idcodeudor_SQL, Idsolicitud_SQL, Codeudor_SQL, Identificacion_SQL, Empresa_SQL, Cargo_SQL = "";

        //Variables para Eliminar y ejecutar los procedimientos Internos en los paneles Codeudor
        private bool Eliminar_Codeudor = false;

        //********** Variables para la Validacion de las Transacciones en SQL **************************************************

        private string Tran_Codeudor = "";


        // Variables para Generar Codigo de Proveedor
        // Y Consultarlo desde la Base de Datos
        public string Codigo_SQL = "";
        public string Codigo_ID = "";

        private static frmSolicitud _Instancia;

        public static frmSolicitud GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmSolicitud();
            }
            return _Instancia;
        }

        private string Codigo = "";

        //Variables para el Envio de Estados
        private string Solicitud = "";
        public frmSolicitud()
        {
            InitializeComponent();
        }

        private void frmSolicitud_Load(object sender, EventArgs e)
        {
            //Inicio de Clase y Botones
            this.Botones();
            this.Habilitar();
            this.Consulta_CodigoID();
            this.Auto_CodigoID();
            this.CrearTabla();

            //Focus a Texboxt y Combobox
            this.CBParentesco.SelectedIndex = 0;
            this.CBModalidad.SelectedIndex = 0;
            this.CBEstado.SelectedIndex = 0;

            //Ocultacion de Texboxt
            this.TBCodigoID.Visible = false;
            this.TBIdsolicitud.Visible = false;

            //Color para Texboxt Buscar
            this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);
        }
        private void Habilitar()
        {
            //Datos Basicos
            this.TBOrdenDeSolicitud.Enabled = false;
            this.TBOrdenDeSolicitud.BackColor = Color.FromArgb(130, 224, 170);
            this.TBNombres.ReadOnly = false;
            this.TBNombres.BackColor = Color.FromArgb(3, 155, 229);
            this.TBNombres.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBNombres.Text = Campo;
            this.CBEstado.Enabled = true;
            this.CBEstado.BackColor = Color.FromArgb(3, 155, 229);
            this.TBIdentificacion.ReadOnly = false;
            this.TBIdentificacion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBIdentificacion.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBIdentificacion.Text = Campo;
            this.TBValorSolicitado.ReadOnly = false;
            this.TBValorSolicitado.BackColor = Color.FromArgb(3, 155, 229);
            this.TBValorSolicitado.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBValorSolicitado.Text = Campo;
            this.CBModalidad.Enabled = true;
            this.CBModalidad.BackColor = Color.FromArgb(3, 155, 229);
            this.DTFechadesolicitud.Enabled = true;
            this.DTFechadesolicitud.BackColor = Color.FromArgb(3, 155, 229);
            this.DTFechadeprestamo.Enabled = true;
            this.DTFechadeprestamo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDireccion.ReadOnly = false;
            this.TBDireccion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFijo.ReadOnly = false;
            this.TBFijo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBMovil.ReadOnly = false;
            this.TBMovil.BackColor = Color.FromArgb(3, 155, 229);
            this.TBEmpresa.ReadOnly = false;
            this.TBEmpresa.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCargo.ReadOnly = false;
            this.TBCargo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDireccion_Empresa.ReadOnly = false;
            this.TBDireccion_Empresa.BackColor = Color.FromArgb(3, 155, 229);
            this.TBEmpresa_Fijo.ReadOnly = false;
            this.TBEmpresa_Fijo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBEmpresa_Movil.ReadOnly = false;
            this.TBEmpresa_Movil.BackColor = Color.FromArgb(3, 155, 229);
            this.TBSalario.ReadOnly = false;
            this.TBSalario.BackColor = Color.FromArgb(3, 155, 229);
            this.TBOtrosIngresos.ReadOnly = false;
            this.TBOtrosIngresos.BackColor = Color.FromArgb(3, 155, 229);
            this.TBReferencia.ReadOnly = false;
            this.TBReferencia.BackColor = Color.FromArgb(3, 155, 229);
            this.CBParentesco.Enabled = true;
            this.CBParentesco.BackColor = Color.FromArgb(3, 155, 229);
            this.TBReferencia_Direccion.ReadOnly = false;
            this.TBReferencia_Direccion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBReferencia_Fijo.ReadOnly = false;
            this.TBReferencia_Fijo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBReferencia_Movil.ReadOnly = false;
            this.TBReferencia_Movil.BackColor = Color.FromArgb(3, 155, 229);
            this.TBObservacion.ReadOnly = false;
            this.TBObservacion.BackColor = Color.FromArgb(3, 155, 229);

            //Datos Codeudor 01
            this.TBFiltro_Cargo.Enabled = false;
            this.TBFiltro_Cargo.BackColor = Color.FromArgb(130, 224, 170);
            this.TBFiltro_Empresa.Enabled = false;
            this.TBFiltro_Empresa.BackColor = Color.FromArgb(130, 224, 170);
            this.TBBuscar_Codeudor.Enabled = false;
            this.TBBuscar_Codeudor.BackColor = Color.FromArgb(130, 224, 170);
            this.TBBuscar_Codeudor02.Enabled = false;
            this.TBBuscar_Codeudor02.BackColor = Color.FromArgb(130, 224, 170);

            //Imagenes
            this.Foto_Otros.Enabled = true;
            this.Foto_Deudor.Enabled = true;
            this.Foto_Pagare.Enabled = true;
            this.Foto_Codeudor.Enabled = true;
        }


        private void Limpiar_Datos()
        {
            //Datos Basicos
            this.TBOrdenDeSolicitud.Clear();
            this.TBNombres.Clear();
            this.TBNombres.Text = Campo;
            this.TBIdentificacion.Clear();
            this.TBIdentificacion.Text = Campo;
            this.TBValorSolicitado.Clear();
            this.TBValorSolicitado.Text = Campo;
            this.CBModalidad.SelectedItem = 0;
            this.CBModalidad.SelectedItem = 0;
            this.TBDireccion.Clear();
            this.TBFijo.Clear();
            this.TBMovil.Clear();
            this.TBEmpresa.Clear();
            this.TBCargo.Clear();
            this.TBDireccion_Empresa.Clear();
            this.TBEmpresa_Fijo.Clear();
            this.TBEmpresa_Movil.Clear();
            this.TBSalario.Clear();
            this.TBOtrosIngresos.Clear();
            this.TBReferencia.Clear();
            this.CBParentesco.SelectedItem = 0;
            this.TBReferencia_Direccion.Clear();
            this.TBReferencia_Fijo.Clear();
            this.TBReferencia_Movil.Clear();
            this.TBObservacion.Clear();

            //PANEL CODEUDOR
            this.TBFiltro_Cargo.Clear();
            this.TBFiltro_Empresa.Clear();
            this.TBBuscar_Codeudor.Clear();
            this.TBBuscar_Codeudor02.Clear();

            this.DGCodeudor.DataSource = null;
            //this.CBCodeudor.Items.Clear();
        }

        private void Consulta_CodigoID()
        {
            try
            {
                DataTable Datos = Negocio.fSolicitud.CodigoID_Solicitud(this.TBCodigoID.Text);
                //Evaluamos si  existen los Datos
                if (Datos.Rows.Count == 0)
                {
                    Codigo = TBCodigoID.Text;
                    //TBCodigoID.Text = "1";
                    //MessageBox.Show("No se Encontraron Registros en la Base de Datos", "Sistema Instituto Fundecar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //frmAcademico_RegistrarAlumno frm = new frmAcademico_RegistrarAlumno();
                    Codigo = Datos.Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public void Auto_CodigoID()
        {
            //Obtenemos el resultado de la base de datos de
            //La columna Iddatos basicos - Tabla Prestamos.DatosBasicos
            //Procedimiento Almacenado Sistema.CodigoID_Solicitud

            this.TBOrdenDeSolicitud.Text = Codigo;
        }

        private void CrearTabla()
        {
            try
            {
                this.DGCodeudor.DataSource = this.DtDetalle_Codeudor;

                this.DtDetalle_Codeudor.Columns.Add("Idcodeudor", System.Type.GetType("System.Int32"));
                this.DtDetalle_Codeudor.Columns.Add("Idsolictud", System.Type.GetType("System.Int32"));
                this.DtDetalle_Codeudor.Columns.Add("Codeudor", System.Type.GetType("System.String"));
                this.DtDetalle_Codeudor.Columns.Add("Identificación", System.Type.GetType("System.String"));
                this.DtDetalle_Codeudor.Columns.Add("Empresa", System.Type.GetType("System.String"));
                this.DtDetalle_Codeudor.Columns.Add("Cargo", System.Type.GetType("System.String"));

                //Aliniacion de las Celdas de Cada Columna
                this.DGCodeudor.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //SE OCULTAN LAS COLUMNAS 
                this.DGCodeudor.Columns[0].Visible = false;
                this.DGCodeudor.Columns[1].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Validacion_SQL()
        {
            //
            if (DGCodeudor.Rows.Count == 0)
            {
                this.Tran_Codeudor = "1";
            }
            else
            {
                this.Tran_Codeudor = "0";
            }
        }

        private void Botones()
        {
            if (Digitar)
            {
                this.btnGuardar.Enabled = true;
                this.btnGuardar.Text = "Guardar";
                this.btnCancelar.Enabled = false;
            }
            else if (!Digitar)
            {
                this.btnGuardar.Enabled = true;
                this.btnGuardar.Text = "Editar";
                this.btnCancelar.Enabled = true;
            }
        }

        public void setCodeudor(string idcodeudor, string codeudor, string identificacion, string empresa, string cargo)
        {
            this.TBIdcodeudor.Text = idcodeudor;
            this.TBBuscar_Codeudor.Text = codeudor;
            this.TBBuscar_Codeudor02.Text = identificacion;
            this.TBFiltro_Empresa.Text = empresa;
            this.TBFiltro_Cargo.Text = cargo;
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
                //else if (this.CBCodeudor.Text == string.Empty)
                //{
                //    MensajeError("Seleccione el Codeudor de la Solicitud a Registrar");
                //    CBCodeudor.BackColor = Color.FromArgb(250, 235, 215);
                //}

                else
                {

                    //Insertar Foto Pagare
                    System.IO.MemoryStream ms1 = new System.IO.MemoryStream();
                    this.Foto_Pagare.Image.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);

                    byte[] foto_pagare = ms1.GetBuffer();

                    //Insertar Cedula Codeudor
                    System.IO.MemoryStream ms2 = new System.IO.MemoryStream();
                    this.Foto_Codeudor.Image.Save(ms2, System.Drawing.Imaging.ImageFormat.Jpeg);

                    byte[] foto_codeudor = ms2.GetBuffer();

                    //Insertar Foto Cedula Deudor
                    System.IO.MemoryStream ms3 = new System.IO.MemoryStream();
                    this.Foto_Deudor.Image.Save(ms3, System.Drawing.Imaging.ImageFormat.Jpeg);

                    byte[] foto_deudor = ms3.GetBuffer();

                    //Insertar Foto Otros Documentos
                    System.IO.MemoryStream ms4 = new System.IO.MemoryStream();
                    this.Foto_Otros.Image.Save(ms4, System.Drawing.Imaging.ImageFormat.Jpeg);

                    byte[] foto_otros = ms4.GetBuffer();

                    this.Validacion_SQL();


                    if (this.Digitar)
                    {
                        rptaDatosBasicos = fSolicitud.Guardar_DatosBasicos
                            (
                                //DATOS AUXILIARES
                                1,
                                
                                //DATOS BASICOS
                                Convert.ToInt32(this.TBOrdenDeSolicitud.Text), this.TBNombres.Text, this.TBIdentificacion.Text, this.TBValorSolicitado.Text, this.DTFechadesolicitud.Value, this.DTFechadeprestamo.Value, this.CBModalidad.Text, this.TBDireccion.Text, this.TBFijo.Text, this.TBMovil.Text, this.TBEmpresa.Text, this.TBCargo.Text, this.TBDireccion_Empresa.Text, this.TBEmpresa_Fijo.Text, this.TBEmpresa_Movil.Text, this.TBSalario.Text, this.TBOtrosIngresos.Text, this.TBReferencia.Text, this.CBParentesco.Text, this.TBReferencia_Direccion.Text, this.TBReferencia_Fijo.Text, this.TBReferencia_Movil.Text, this.TBObservacion.Text,

                                //IMAGENES
                                foto_pagare,foto_codeudor,foto_deudor,foto_otros,

                                //DETALLE CODEUDOR
                                DtDetalle_Codeudor,

                                 //Variables Para Confirmar el Insertar en la Transaccion en SQL
                                 //Donde esten las Validaciones IF NOT
                                 1,

                                 //Variables para Ordenar Si se Ejecutan o No las Transacciones en SQL
                                 //Si los Datagriview estan vacios seran Iguales a 0 Si Tienen Datos Seran Iguales a 1
                                 Convert.ToInt32(Tran_Codeudor)
                            );
                    }

                    if (rptaDatosBasicos.Equals("OK"))
                    {
                        if (this.Digitar)
                        {
                            this.MensajeOk("La Solicitud de: " + this.TBNombres.Text + " con Codigo: " + this.TBCodigoID.Text + " a Sido Registrada Correctamente");
                        }

                        else
                        {
                            this.MensajeOk("El Registro de La Solicitud de: " + this.TBNombres.Text + " con Codigo: " + this.TBCodigoID.Text + " a Sido Actualizado Correctamente");
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
                        MessageBox.Show("El Usuario Iniciado Actualmente no Contiene Permisos Para Guardar Datos", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                        MessageBox.Show("El Usuario Iniciado Actualmente no Contiene Permisos Para Editar Datos", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                //string rptaDatosBasicos = "";

                ////Datos Basicos
                //if (this.TBIddatosbasicos.Text == string.Empty)
                //{
                //    MensajeError("Por Favor Seleccione la Solicitud a Eliminar");
                //    TBIddatosbasicos.BackColor = Color.FromArgb(250, 235, 215);
                //}

                //else
                //{
                //    if (this.IsEditar)
                //    {
                //        rptaDatosBasicos = fPrestamos_Liquidacion.Eliminar_SolicitudDeCredito
                //            (
                //                Convert.ToInt32(this.TBIddatosbasicos.Text), 0
                //            );
                //    }

                //    if (rptaDatosBasicos.Equals("OK"))
                //    {
                //        if (this.IsEditar)
                //        {
                //            this.MensajeOk("Solicitud Eliminada");
                //        }
                //    }

                //    else
                //    {
                //        this.MensajeError(rptaDatosBasicos);
                //    }

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnAgregar_Codeudor_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.TBBuscar_Codeudor02.Text == String.Empty)
                {
                    this.MensajeError("POR FAVOR ESPECIFIQUE EL CODEUDOR QUE DESEA AGREGAR.");
                }
                else
                {
                    bool agregar = true;
                    foreach (DataRow Fila in DtDetalle_Codeudor.Rows)
                    {
                        if (Convert.ToString(Fila[0]) == TBBuscar_Codeudor02.Text)
                        {
                            this.MensajeError("EL CODEUDOR QUE DESEA AGREGAR YA SE ENCUENTRA EN LA LISTA.");
                            this.TBBuscar_Codeudor.Clear();
                            this.TBBuscar_Codeudor02.Clear();
                            this.TBFiltro_Cargo.Clear();
                            this.TBFiltro_Empresa.Clear();
                        }
                    }

                    if (agregar)
                    {
                        DataRow fila = this.DtDetalle_Codeudor.NewRow();
                        fila["Idcodeudor"] = Convert.ToInt32(this.TBIdcodeudor.Text);
                        fila["Idsolictud"] = Convert.ToInt32(this.TBOrdenDeSolicitud.Text);
                        fila["Codeudor"] = this.TBBuscar_Codeudor.Text;
                        fila["Identificación"] = this.TBBuscar_Codeudor02.Text;
                        fila["Empresa"] = this.TBFiltro_Empresa.Text;
                        fila["Cargo"] = this.TBFiltro_Cargo.Text;
                        this.DtDetalle_Codeudor.Rows.Add(fila);
                    }

                    //
                    this.TBBuscar_Codeudor.Clear();
                    this.TBBuscar_Codeudor02.Clear();
                    this.TBFiltro_Cargo.Clear();
                    this.TBFiltro_Empresa.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEliminar_Codeudor_Click(object sender, EventArgs e)
        {
            try
            {
                if (Eliminar == "1")
                {
                    int Fila = this.DGCodeudor.CurrentCell.RowIndex;
                    DataRow row = this.DtDetalle_Codeudor.Rows[Fila];

                    //Se remueve la fila
                    this.DtDetalle_Codeudor.Rows.Remove(row);
                }
                else
                {
                    MessageBox.Show("Acceso Denegado Para Realizar Eliminaciones en el Sistema", "Crediya - Solicitud Rechazada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MensajeError("Por favor seleccione la Ubicacion que desea Remover del registo");
            }
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            frmFiltro_Codeudor frmFiltro_Codeudor = new frmFiltro_Codeudor();
            frmFiltro_Codeudor.ShowDialog();
        }
        private void Foto_Codeudor_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.Foto_Codeudor.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Foto_Codeudor.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void Foto_Deudor_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.Foto_Deudor.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Foto_Deudor.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void CBEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBEstado.SelectedText == "Proceso")
            {
                this.Solicitud = "1";
            }
            else if (CBEstado.SelectedText == "Estudio")
            {
                this.Solicitud = "2";
            }
        }

        private void frmSolicitud_Activated(object sender, EventArgs e)
        {
            this.TBNombres.Focus();
        }

        private void TBNombres_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBIdentificacion.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //Al precionar la tecla Escape Se Limpiaran los campos de texto 

                    //Llamada de Clase
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
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
                            this.TBNombres.Select();
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
                            this.TBNombres.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBIdentificacion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBValorSolicitado.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //Al precionar la tecla Escape Se Limpiaran los campos de texto 

                    //Llamada de Clase
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
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
                            this.TBIdentificacion.Select();
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
                            this.TBIdentificacion.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBValorSolicitado_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBDireccion.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //Al precionar la tecla Escape Se Limpiaran los campos de texto 

                    //Llamada de Clase
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
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
                            this.TBValorSolicitado.Select();
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
                            this.TBValorSolicitado.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDireccion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBFijo.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //Al precionar la tecla Escape Se Limpiaran los campos de texto 

                    //Llamada de Clase
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
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
                            this.TBDireccion.Select();
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
                            this.TBDireccion.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBFijo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBMovil.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //Al precionar la tecla Escape Se Limpiaran los campos de texto 

                    //Llamada de Clase
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
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
                            this.TBFijo.Select();
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
                            this.TBFijo.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBMovil_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBEmpresa.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //Al precionar la tecla Escape Se Limpiaran los campos de texto 

                    //Llamada de Clase
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
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
                            this.TBMovil.Select();
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
                            this.TBMovil.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBEmpresa_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBCargo.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //Al precionar la tecla Escape Se Limpiaran los campos de texto 

                    //Llamada de Clase
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
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
                            this.TBEmpresa.Select();
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
                            this.TBEmpresa.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCargo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBDireccion_Empresa.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //Al precionar la tecla Escape Se Limpiaran los campos de texto 

                    //Llamada de Clase
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
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
                            this.TBCargo.Select();
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
                            this.TBCargo.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDireccion_Empresa_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBEmpresa_Fijo.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //Al precionar la tecla Escape Se Limpiaran los campos de texto 

                    //Llamada de Clase
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
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
                            this.TBDireccion_Empresa.Select();
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
                            this.TBDireccion_Empresa.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBEmpresa_Fijo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBEmpresa_Movil.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //Al precionar la tecla Escape Se Limpiaran los campos de texto 

                    //Llamada de Clase
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
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
                            this.TBEmpresa_Fijo.Select();
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
                            this.TBEmpresa_Fijo.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBEmpresa_Movil_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBSalario.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //Al precionar la tecla Escape Se Limpiaran los campos de texto 

                    //Llamada de Clase
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
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
                            this.TBEmpresa_Movil.Select();
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
                            this.TBEmpresa_Movil.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBSalario_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBOtrosIngresos.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //Al precionar la tecla Escape Se Limpiaran los campos de texto 

                    //Llamada de Clase
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
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
                            this.TBSalario.Select();
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
                            this.TBSalario.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBOtrosIngresos_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBReferencia.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //Al precionar la tecla Escape Se Limpiaran los campos de texto 

                    //Llamada de Clase
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
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
                            this.TBOtrosIngresos.Select();
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
                            this.TBOtrosIngresos.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBReferencia_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBReferencia_Direccion.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //Al precionar la tecla Escape Se Limpiaran los campos de texto 

                    //Llamada de Clase
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
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
                            this.TBReferencia.Select();
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
                            this.TBReferencia.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBReferencia_Direccion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBReferencia_Fijo.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //Al precionar la tecla Escape Se Limpiaran los campos de texto 

                    //Llamada de Clase
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
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
                            this.TBReferencia_Direccion.Select();
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
                            this.TBReferencia_Direccion.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBReferencia_Fijo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBReferencia_Movil.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //Al precionar la tecla Escape Se Limpiaran los campos de texto 

                    //Llamada de Clase
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
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
                            this.TBReferencia_Fijo.Select();
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
                            this.TBReferencia_Fijo.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBReferencia_Movil_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBObservacion.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //Al precionar la tecla Escape Se Limpiaran los campos de texto 

                    //Llamada de Clase
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
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
                            this.TBReferencia_Movil.Select();
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
                            this.TBReferencia_Movil.Select();
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

                    this.TBNombres.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //Al precionar la tecla Escape Se Limpiaran los campos de texto 

                    //Llamada de Clase
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
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
                            this.TBObservacion.Select();
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
                            this.TBObservacion.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBNombres_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBNombres.Text == Campo)
            {
                this.TBNombres.BackColor = Color.Azure;
                this.TBNombres.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBNombres.Clear();
            }
        }

        private void TBIdentificacion_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBIdentificacion.Text == Campo)
            {
                this.TBIdentificacion.BackColor = Color.Azure;
                this.TBIdentificacion.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBIdentificacion.Clear();
            }
        }

        private void TBValorSolicitado_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBValorSolicitado.Text == Campo)
            {
                this.TBValorSolicitado.BackColor = Color.Azure;
                this.TBValorSolicitado.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBValorSolicitado.Clear();
            }
        }

        private void TBDireccion_Enter(object sender, EventArgs e)
        {
            this.TBDireccion.BackColor = Color.Azure;
        }

        private void TBFijo_Enter(object sender, EventArgs e)
        {
            this.TBFijo.BackColor = Color.Azure;
        }

        private void TBMovil_Enter(object sender, EventArgs e)
        {
            this.TBMovil.BackColor = Color.Azure;
        }

        private void TBEmpresa_Enter(object sender, EventArgs e)
        {
            this.TBEmpresa.BackColor = Color.Azure;
        }

        private void TBCargo_Enter(object sender, EventArgs e)
        {
            this.TBCargo.BackColor = Color.Azure;
        }

        private void TBDireccion_Empresa_Enter(object sender, EventArgs e)
        {
            this.TBDireccion_Empresa.BackColor = Color.Azure;
        }

        private void TBEmpresa_Fijo_Enter(object sender, EventArgs e)
        {
            this.TBEmpresa_Fijo.BackColor = Color.Azure;
        }

        private void TBEmpresa_Movil_Enter(object sender, EventArgs e)
        {
            this.TBEmpresa_Movil.BackColor = Color.Azure;
        }

        private void TBSalario_Enter(object sender, EventArgs e)
        {
            this.TBSalario.BackColor = Color.Azure;
        }

        private void TBOtrosIngresos_Enter(object sender, EventArgs e)
        {
            this.TBOtrosIngresos.BackColor = Color.Azure;
        }

        private void TBReferencia_Enter(object sender, EventArgs e)
        {
            this.TBReferencia.BackColor = Color.Azure;
        }

        private void TBReferencia_Direccion_Enter(object sender, EventArgs e)
        {
            this.TBReferencia_Direccion.BackColor = Color.Azure;
        }

        private void TBReferencia_Fijo_Enter(object sender, EventArgs e)
        {
            this.TBReferencia_Fijo.BackColor = Color.Azure;
        }

        private void TBReferencia_Movil_Enter(object sender, EventArgs e)
        {
            this.TBReferencia_Movil.BackColor = Color.Azure;
        }

        private void TBObservacion_Enter(object sender, EventArgs e)
        {
            this.TBObservacion.BackColor = Color.Azure;
        }

        private void TBNombres_Leave(object sender, EventArgs e)
        {
            if (TBNombres.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBNombres.BackColor = Color.FromArgb(3, 155, 229);
                this.TBNombres.Text = Campo;
                this.TBNombres.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                this.TBNombres.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBIdentificacion_Leave(object sender, EventArgs e)
        {
            if (TBIdentificacion.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBIdentificacion.BackColor = Color.FromArgb(3, 155, 229);
                this.TBIdentificacion.Text = Campo;
                this.TBIdentificacion.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                this.TBIdentificacion.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBValorSolicitado_Leave(object sender, EventArgs e)
        {
            if (TBValorSolicitado.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBValorSolicitado.BackColor = Color.FromArgb(3, 155, 229);
                this.TBValorSolicitado.Text = Campo;
                this.TBValorSolicitado.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                this.TBValorSolicitado.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBDireccion_Leave(object sender, EventArgs e)
        {
            this.TBDireccion.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBFijo_Leave(object sender, EventArgs e)
        {
            this.TBFijo.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBMovil_Leave(object sender, EventArgs e)
        {
            this.TBMovil.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBEmpresa_Leave(object sender, EventArgs e)
        {
            this.TBEmpresa.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCargo_Leave(object sender, EventArgs e)
        {
            this.TBCargo.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDireccion_Empresa_Leave(object sender, EventArgs e)
        {
            this.TBDireccion_Empresa.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBEmpresa_Fijo_Leave(object sender, EventArgs e)
        {
            this.TBEmpresa_Fijo.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBEmpresa_Movil_Leave(object sender, EventArgs e)
        {
            this.TBEmpresa_Movil.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBSalario_Leave(object sender, EventArgs e)
        {
            this.TBSalario.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBOtrosIngresos_Leave(object sender, EventArgs e)
        {
            this.TBOtrosIngresos.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBReferencia_Leave(object sender, EventArgs e)
        {
            this.TBReferencia.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBReferencia_Direccion_Leave(object sender, EventArgs e)
        {
            this.TBReferencia_Direccion.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBReferencia_Fijo_Leave(object sender, EventArgs e)
        {
            this.TBReferencia_Fijo.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBReferencia_Movil_Leave(object sender, EventArgs e)
        {
            this.TBReferencia_Movil.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBObservacion_Leave(object sender, EventArgs e)
        {
            this.TBObservacion.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void Foto_Otros_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.Foto_Otros.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Foto_Otros.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void Foto_Pagare_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.Foto_Pagare.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Foto_Pagare.Image = Image.FromFile(dialog.FileName);
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
                    this.TBIdsolicitud.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Iddatosbasicos"].Value);
                    this.TBOrdenDeSolicitud.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Orden"].Value);
                    this.CBEstado.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Estado"].Value);
                    this.TBNombres.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Solicitante"].Value);
                    this.TBIdentificacion.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Identificacion"].Value);
                    //this.CBCodeudor.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Codeudor"].Value);
                    this.TBValorSolicitado.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Valor"].Value);
                    this.DTFechadesolicitud.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Solicitud"].Value);
                    this.CBModalidad.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Modalidad"].Value);
                    this.DTFechadeprestamo.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Prestamo"].Value);
                    this.TBDireccion.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Direccion"].Value);
                    this.TBMovil.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Movil"].Value);
                    this.TBEmpresa.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Empresa"].Value);
                    this.TBCargo.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Cargo"].Value);
                    this.TBDireccion_Empresa.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Direccion_E"].Value);
                    this.TBEmpresa_Fijo.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Fijo_E"].Value);
                    this.TBEmpresa_Movil.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Movil_E"].Value);
                    this.TBSalario.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Salario"].Value);
                    this.TBOtrosIngresos.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Otros"].Value);
                    this.TBReferencia.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Referencia"].Value);
                    this.CBParentesco.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Parentesco"].Value);
                    this.TBReferencia_Direccion.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Direccion_R"].Value);
                    this.TBReferencia_Fijo.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Fijo_R"].Value);
                    this.TBReferencia_Movil.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Movil_R"].Value);
                    this.TBObservacion.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Observacion"].Value);

                    //
                    this.Limpiar_Datos();

                }
                else
                {
                    MessageBox.Show("El Usuario Iniciado Actualmente no Contiene Permisos Para Actualizar Datos en el Sistema", "Leal Enterprise - 'Acceso Denegado' ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                //if (Consultar == "Si")
                //{
                //    this.DGResultados.DataSource = fPrestamos_Solicitud.Buscar_Solicitud(this.TBBuscar.Text);

                //    //Se ocultan las Columnas
                //    this.DGResultados.Columns[0].Visible = false;
                //    this.DGResultados.Columns[1].Visible = false;
                //    this.DGResultados.Columns[5].Visible = false;
                //    this.DGResultados.Columns[6].Visible = false;
                //    this.DGResultados.Columns[7].Visible = false;
                //    this.DGResultados.Columns[8].Visible = false;
                //    this.DGResultados.Columns[9].Visible = false;
                //    this.DGResultados.Columns[10].Visible = false;
                //    this.DGResultados.Columns[11].Visible = false;
                //    this.DGResultados.Columns[12].Visible = false;
                //    this.DGResultados.Columns[13].Visible = false;
                //    this.DGResultados.Columns[14].Visible = false;
                //    this.DGResultados.Columns[15].Visible = false;
                //    this.DGResultados.Columns[16].Visible = false;
                //    this.DGResultados.Columns[17].Visible = false;
                //    this.DGResultados.Columns[18].Visible = false;
                //    this.DGResultados.Columns[18].Visible = false;
                //    this.DGResultados.Columns[19].Visible = false;
                //    this.DGResultados.Columns[20].Visible = false;
                //    this.DGResultados.Columns[21].Visible = false;
                //    this.DGResultados.Columns[22].Visible = false;
                //    this.DGResultados.Columns[23].Visible = false;
                //    this.DGResultados.Columns[24].Visible = false;
                //    this.DGResultados.Columns[25].Visible = false;

                //    lblTotal.Text = "Datos Registrados: " + Convert.ToString(DGResultados.Rows.Count);
                //}

                //else if (Consultar == "No")
                //{
                //    MessageBox.Show("Acceso Denegado Para Realizar Consultas", "Crediya", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBIdsolicitud_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
