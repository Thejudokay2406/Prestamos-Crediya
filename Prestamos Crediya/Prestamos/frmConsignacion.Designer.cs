
namespace Prestamos_Crediya
{
    partial class frmConsignacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsignacion));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAgregar_Abono = new System.Windows.Forms.Button();
            this.TBIdsolicitud = new System.Windows.Forms.TextBox();
            this.TBIdconsignacion = new System.Windows.Forms.TextBox();
            this.TBValorAbono = new System.Windows.Forms.TextBox();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.lblTotal_Consignacion = new System.Windows.Forms.Label();
            this.btnEliminar_Abono = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.DGLista_Abonos = new System.Windows.Forms.DataGridView();
            this.TBObservacion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TBOrdenDeSolicitud = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.TBValorSolicitado = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TBIdentificacion = new System.Windows.Forms.TextBox();
            this.DTFechadesolicitud = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.TBNombres = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.TBBuscar = new System.Windows.Forms.TextBox();
            this.DGResultados = new System.Windows.Forms.DataGridView();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGLista_Abonos)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAgregar_Abono);
            this.groupBox1.Controls.Add(this.TBIdsolicitud);
            this.groupBox1.Controls.Add(this.TBIdconsignacion);
            this.groupBox1.Controls.Add(this.TBValorAbono);
            this.groupBox1.Controls.Add(this.btnExaminar);
            this.groupBox1.Controls.Add(this.lblTotal_Consignacion);
            this.groupBox1.Controls.Add(this.btnEliminar_Abono);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.DGLista_Abonos);
            this.groupBox1.Controls.Add(this.TBObservacion);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TBOrdenDeSolicitud);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.TBValorSolicitado);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TBIdentificacion);
            this.groupBox1.Controls.Add(this.DTFechadesolicitud);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TBNombres);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(660, 369);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro de Consignaciones - Crediya";
            // 
            // btnAgregar_Abono
            // 
            this.btnAgregar_Abono.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar_Abono.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAgregar_Abono.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAgregar_Abono.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnAgregar_Abono.Image = global::Prestamos_Crediya.Botones.btnAgregar;
            this.btnAgregar_Abono.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar_Abono.Location = new System.Drawing.Point(533, 332);
            this.btnAgregar_Abono.Name = "btnAgregar_Abono";
            this.btnAgregar_Abono.Size = new System.Drawing.Size(120, 30);
            this.btnAgregar_Abono.TabIndex = 164;
            this.btnAgregar_Abono.Text = "Agregar Abono";
            this.btnAgregar_Abono.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar_Abono.UseVisualStyleBackColor = true;
            this.btnAgregar_Abono.Click += new System.EventHandler(this.btnAgregar_Abono_Click);
            // 
            // TBIdsolicitud
            // 
            this.TBIdsolicitud.Location = new System.Drawing.Point(387, 128);
            this.TBIdsolicitud.Name = "TBIdsolicitud";
            this.TBIdsolicitud.Size = new System.Drawing.Size(28, 21);
            this.TBIdsolicitud.TabIndex = 163;
            // 
            // TBIdconsignacion
            // 
            this.TBIdconsignacion.Location = new System.Drawing.Point(353, 128);
            this.TBIdconsignacion.Name = "TBIdconsignacion";
            this.TBIdconsignacion.Size = new System.Drawing.Size(28, 21);
            this.TBIdconsignacion.TabIndex = 74;
            this.TBIdconsignacion.TextChanged += new System.EventHandler(this.TBIdconsignacion_TextChanged);
            // 
            // TBValorAbono
            // 
            this.TBValorAbono.Location = new System.Drawing.Point(438, 74);
            this.TBValorAbono.Name = "TBValorAbono";
            this.TBValorAbono.Size = new System.Drawing.Size(215, 21);
            this.TBValorAbono.TabIndex = 162;
            this.TBValorAbono.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBValorAbono_KeyUp);
            // 
            // btnExaminar
            // 
            this.btnExaminar.BackgroundImage = global::Prestamos_Crediya.Botones.btnExaminar;
            this.btnExaminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExaminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExaminar.FlatAppearance.BorderSize = 0;
            this.btnExaminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExaminar.Location = new System.Drawing.Point(308, 20);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(25, 21);
            this.btnExaminar.TabIndex = 161;
            this.btnExaminar.UseVisualStyleBackColor = true;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // lblTotal_Consignacion
            // 
            this.lblTotal_Consignacion.AutoSize = true;
            this.lblTotal_Consignacion.Location = new System.Drawing.Point(6, 131);
            this.lblTotal_Consignacion.Name = "lblTotal_Consignacion";
            this.lblTotal_Consignacion.Size = new System.Drawing.Size(154, 15);
            this.lblTotal_Consignacion.TabIndex = 74;
            this.lblTotal_Consignacion.Text = "Consignaciones en Lista: 0";
            // 
            // btnEliminar_Abono
            // 
            this.btnEliminar_Abono.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar_Abono.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEliminar_Abono.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnEliminar_Abono.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnEliminar_Abono.Image = global::Prestamos_Crediya.Botones.btnEliminar;
            this.btnEliminar_Abono.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar_Abono.Location = new System.Drawing.Point(407, 332);
            this.btnEliminar_Abono.Name = "btnEliminar_Abono";
            this.btnEliminar_Abono.Size = new System.Drawing.Size(120, 30);
            this.btnEliminar_Abono.TabIndex = 70;
            this.btnEliminar_Abono.Text = "Eliminar Abono";
            this.btnEliminar_Abono.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar_Abono.UseVisualStyleBackColor = true;
            this.btnEliminar_Abono.Click += new System.EventHandler(this.btnEliminar_Abono_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::Prestamos_Crediya.Botones.btnCancelar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(135, 332);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 30);
            this.btnCancelar.TabIndex = 68;
            this.btnCancelar.Text = "Cancelar - F9";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(9, 332);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 30);
            this.btnGuardar.TabIndex = 67;
            this.btnGuardar.Text = "Guardar - F10";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // DGLista_Abonos
            // 
            this.DGLista_Abonos.AllowUserToAddRows = false;
            this.DGLista_Abonos.AllowUserToDeleteRows = false;
            this.DGLista_Abonos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGLista_Abonos.BackgroundColor = System.Drawing.Color.White;
            this.DGLista_Abonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGLista_Abonos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DGLista_Abonos.Location = new System.Drawing.Point(9, 155);
            this.DGLista_Abonos.Name = "DGLista_Abonos";
            this.DGLista_Abonos.ReadOnly = true;
            this.DGLista_Abonos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGLista_Abonos.Size = new System.Drawing.Size(644, 171);
            this.DGLista_Abonos.TabIndex = 65;
            this.DGLista_Abonos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGLista_Abonos_CellClick);
            this.DGLista_Abonos.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGLista_Abonos_RowEnter);
            // 
            // TBObservacion
            // 
            this.TBObservacion.Location = new System.Drawing.Point(83, 101);
            this.TBObservacion.Name = "TBObservacion";
            this.TBObservacion.Size = new System.Drawing.Size(570, 21);
            this.TBObservacion.TabIndex = 64;
            this.TBObservacion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBObservacion_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 63;
            this.label3.Text = "Observación";
            // 
            // TBOrdenDeSolicitud
            // 
            this.TBOrdenDeSolicitud.Location = new System.Drawing.Point(83, 20);
            this.TBOrdenDeSolicitud.Name = "TBOrdenDeSolicitud";
            this.TBOrdenDeSolicitud.Size = new System.Drawing.Size(219, 21);
            this.TBOrdenDeSolicitud.TabIndex = 62;
            this.TBOrdenDeSolicitud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBOrdenDeSolicitud.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBOrdenDeSolicitud_KeyUp);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(6, 23);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(46, 15);
            this.label25.TabIndex = 61;
            this.label25.Text = "Codigo";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(339, 77);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(93, 15);
            this.label24.TabIndex = 59;
            this.label24.Text = "Valor del Abono";
            // 
            // TBValorSolicitado
            // 
            this.TBValorSolicitado.Location = new System.Drawing.Point(403, 47);
            this.TBValorSolicitado.Name = "TBValorSolicitado";
            this.TBValorSolicitado.Size = new System.Drawing.Size(250, 21);
            this.TBValorSolicitado.TabIndex = 58;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 57;
            this.label5.Text = "F. Abono";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 56;
            this.label4.Text = "Documento";
            // 
            // TBIdentificacion
            // 
            this.TBIdentificacion.Location = new System.Drawing.Point(83, 47);
            this.TBIdentificacion.Name = "TBIdentificacion";
            this.TBIdentificacion.Size = new System.Drawing.Size(250, 21);
            this.TBIdentificacion.TabIndex = 55;
            // 
            // DTFechadesolicitud
            // 
            this.DTFechadesolicitud.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DTFechadesolicitud.Location = new System.Drawing.Point(83, 74);
            this.DTFechadesolicitud.Name = "DTFechadesolicitud";
            this.DTFechadesolicitud.Size = new System.Drawing.Size(250, 21);
            this.DTFechadesolicitud.TabIndex = 54;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 53;
            this.label2.Text = "Valor";
            // 
            // TBNombres
            // 
            this.TBNombres.Location = new System.Drawing.Point(403, 20);
            this.TBNombres.Name = "TBNombres";
            this.TBNombres.Size = new System.Drawing.Size(250, 21);
            this.TBNombres.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(339, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 51;
            this.label1.Text = "Nombre";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTotal);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.TBBuscar);
            this.groupBox2.Controls.Add(this.DGResultados);
            this.groupBox2.Controls.Add(this.btnImprimir);
            this.groupBox2.Controls.Add(this.btnEliminar);
            this.groupBox2.Location = new System.Drawing.Point(687, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(458, 369);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Consulta de Consignaciones Realizadas - Crediya";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(6, 340);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(121, 15);
            this.lblTotal.TabIndex = 73;
            this.lblTotal.Text = "Datos Registrados: 0";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 23);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(147, 15);
            this.label23.TabIndex = 70;
            this.label23.Text = "Consignación a Consultar";
            // 
            // TBBuscar
            // 
            this.TBBuscar.Location = new System.Drawing.Point(159, 21);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(293, 21);
            this.TBBuscar.TabIndex = 71;
            this.TBBuscar.TextChanged += new System.EventHandler(this.TBBuscar_TextChanged);
            // 
            // DGResultados
            // 
            this.DGResultados.AllowUserToAddRows = false;
            this.DGResultados.AllowUserToDeleteRows = false;
            this.DGResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGResultados.BackgroundColor = System.Drawing.Color.White;
            this.DGResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGResultados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DGResultados.Location = new System.Drawing.Point(6, 48);
            this.DGResultados.Name = "DGResultados";
            this.DGResultados.ReadOnly = true;
            this.DGResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGResultados.Size = new System.Drawing.Size(446, 278);
            this.DGResultados.TabIndex = 72;
            this.DGResultados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGResultados_CellDoubleClick);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnImprimir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnImprimir.Image = global::Prestamos_Crediya.Botones.btnEliminar;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(332, 332);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(120, 30);
            this.btnImprimir.TabIndex = 69;
            this.btnImprimir.Text = "Imprimir - F4";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnEliminar.Image = global::Prestamos_Crediya.Botones.btnEliminar;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(206, 332);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(120, 30);
            this.btnEliminar.TabIndex = 66;
            this.btnEliminar.Text = "Eliminar - F5";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // frmConsignacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1157, 390);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "frmConsignacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prestamos - Consignacion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConsignacion_FormClosing);
            this.Load += new System.EventHandler(this.frmConsignacion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGLista_Abonos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGResultados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TBOrdenDeSolicitud;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox TBValorSolicitado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TBIdentificacion;
        private System.Windows.Forms.DateTimePicker DTFechadesolicitud;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBNombres;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBObservacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DGLista_Abonos;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar_Abono;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox TBBuscar;
        private System.Windows.Forms.DataGridView DGResultados;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotal_Consignacion;
        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.TextBox TBValorAbono;
        private System.Windows.Forms.TextBox TBIdsolicitud;
        private System.Windows.Forms.TextBox TBIdconsignacion;
        private System.Windows.Forms.Button btnAgregar_Abono;
    }
}