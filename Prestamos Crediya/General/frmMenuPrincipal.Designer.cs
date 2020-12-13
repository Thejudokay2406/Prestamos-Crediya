
namespace Prestamos_Crediya
{
    partial class frmMenuPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuPrincipal));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.prestamosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codeudorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liquidacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solicitudToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consignaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codeudorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.datosBasicosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prestamosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modalidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licenciamientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equiposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.TSUsuarioLogueado = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.TSEmpleadoRegistrado = new System.Windows.Forms.ToolStripLabel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prestamosToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.sistemaToolStripMenuItem,
            this.sQLToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(737, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "MenuStrip";
            // 
            // prestamosToolStripMenuItem
            // 
            this.prestamosToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.prestamosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.codeudorToolStripMenuItem,
            this.liquidacionToolStripMenuItem,
            this.solicitudToolStripMenuItem,
            this.consignaciónToolStripMenuItem});
            this.prestamosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.prestamosToolStripMenuItem.Name = "prestamosToolStripMenuItem";
            this.prestamosToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.prestamosToolStripMenuItem.Text = "Prestamos";
            // 
            // codeudorToolStripMenuItem
            // 
            this.codeudorToolStripMenuItem.Name = "codeudorToolStripMenuItem";
            this.codeudorToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.codeudorToolStripMenuItem.Text = "Codeudor";
            this.codeudorToolStripMenuItem.Click += new System.EventHandler(this.codeudorToolStripMenuItem_Click);
            // 
            // liquidacionToolStripMenuItem
            // 
            this.liquidacionToolStripMenuItem.Name = "liquidacionToolStripMenuItem";
            this.liquidacionToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.liquidacionToolStripMenuItem.Text = "Liquidación";
            // 
            // solicitudToolStripMenuItem
            // 
            this.solicitudToolStripMenuItem.Name = "solicitudToolStripMenuItem";
            this.solicitudToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.solicitudToolStripMenuItem.Text = "Solicitud";
            this.solicitudToolStripMenuItem.Click += new System.EventHandler(this.solicitudToolStripMenuItem_Click);
            // 
            // consignaciónToolStripMenuItem
            // 
            this.consignaciónToolStripMenuItem.Name = "consignaciónToolStripMenuItem";
            this.consignaciónToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.consignaciónToolStripMenuItem.Text = "Consignación";
            this.consignaciónToolStripMenuItem.Click += new System.EventHandler(this.consignaciónToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.codeudorToolStripMenuItem1,
            this.prestamosToolStripMenuItem1});
            this.reportesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // codeudorToolStripMenuItem1
            // 
            this.codeudorToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.datosBasicosToolStripMenuItem,
            this.listaToolStripMenuItem});
            this.codeudorToolStripMenuItem1.Name = "codeudorToolStripMenuItem1";
            this.codeudorToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.codeudorToolStripMenuItem1.Text = "Codeudor";
            // 
            // datosBasicosToolStripMenuItem
            // 
            this.datosBasicosToolStripMenuItem.Name = "datosBasicosToolStripMenuItem";
            this.datosBasicosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.datosBasicosToolStripMenuItem.Text = "Datos Basicos";
            // 
            // listaToolStripMenuItem
            // 
            this.listaToolStripMenuItem.Name = "listaToolStripMenuItem";
            this.listaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.listaToolStripMenuItem.Text = "Lista";
            // 
            // prestamosToolStripMenuItem1
            // 
            this.prestamosToolStripMenuItem1.Name = "prestamosToolStripMenuItem1";
            this.prestamosToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.prestamosToolStripMenuItem1.Text = "Solicitud de Creditos";
            // 
            // sistemaToolStripMenuItem
            // 
            this.sistemaToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.sistemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuracionToolStripMenuItem,
            this.usuariosToolStripMenuItem});
            this.sistemaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            this.sistemaToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.sistemaToolStripMenuItem.Text = "Sistema";
            // 
            // configuracionToolStripMenuItem
            // 
            this.configuracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modalidadToolStripMenuItem,
            this.licenciamientoToolStripMenuItem,
            this.equiposToolStripMenuItem});
            this.configuracionToolStripMenuItem.Name = "configuracionToolStripMenuItem";
            this.configuracionToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.configuracionToolStripMenuItem.Text = "Configuracion";
            // 
            // modalidadToolStripMenuItem
            // 
            this.modalidadToolStripMenuItem.Name = "modalidadToolStripMenuItem";
            this.modalidadToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.modalidadToolStripMenuItem.Text = "Modalidad";
            // 
            // licenciamientoToolStripMenuItem
            // 
            this.licenciamientoToolStripMenuItem.Name = "licenciamientoToolStripMenuItem";
            this.licenciamientoToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.licenciamientoToolStripMenuItem.Text = "Licenciamiento";
            // 
            // equiposToolStripMenuItem
            // 
            this.equiposToolStripMenuItem.Name = "equiposToolStripMenuItem";
            this.equiposToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.equiposToolStripMenuItem.Text = "Equipos";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // sQLToolStripMenuItem
            // 
            this.sQLToolStripMenuItem.Name = "sQLToolStripMenuItem";
            this.sQLToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.sQLToolStripMenuItem.Text = "SQL";
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripLabel3,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.TSUsuarioLogueado,
            this.toolStripSeparator2,
            this.toolStripLabel4,
            this.TSEmpleadoRegistrado});
            this.toolStrip.Location = new System.Drawing.Point(0, 362);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(737, 25);
            this.toolStrip.TabIndex = 5;
            this.toolStrip.Text = "ToolStrip";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(95, 22);
            this.toolStripLabel1.Text = "Crediya V. 1.0";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(351, 22);
            this.toolStripLabel3.Text = ", Un Producto Diseñado y Desarrollado por Leal Ingenieria SAS";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(65, 22);
            this.toolStripLabel2.Text = "Usuario: ";
            // 
            // TSUsuarioLogueado
            // 
            this.TSUsuarioLogueado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSUsuarioLogueado.Name = "TSUsuarioLogueado";
            this.TSUsuarioLogueado.Size = new System.Drawing.Size(19, 22);
            this.TSUsuarioLogueado.Text = "---";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(72, 22);
            this.toolStripLabel4.Text = "Empleado";
            // 
            // TSEmpleadoRegistrado
            // 
            this.TSEmpleadoRegistrado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSEmpleadoRegistrado.Name = "TSEmpleadoRegistrado";
            this.TSEmpleadoRegistrado.Size = new System.Drawing.Size(19, 22);
            this.TSEmpleadoRegistrado.Text = "---";
            // 
            // frmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Prestamos_Crediya.Properties.Resources.Crediya_Fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(737, 387);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crediya - MenuPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMenuPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.frmMenuPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem prestamosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem codeudorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liquidacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solicitudToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem codeudorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem datosBasicosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prestamosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modalidadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem licenciamientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equiposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sQLToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        public System.Windows.Forms.ToolStripLabel TSUsuarioLogueado;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripLabel TSEmpleadoRegistrado;
        private System.Windows.Forms.ToolStripMenuItem consignaciónToolStripMenuItem;
    }
}



