namespace ProyectoIntegradorPOO.Forms;

partial class FrmPrincipal
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Código generado por el Diseñador de Windows Forms

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        menuPrincipal = new MenuStrip();
        mnuInicio = new ToolStripMenuItem();
        mnuUnidad1 = new ToolStripMenuItem();
        mnuUnidad2 = new ToolStripMenuItem();
        mnuUnidad3 = new ToolStripMenuItem();
        mnuUnidad4 = new ToolStripMenuItem();
        mnuUnidad5 = new ToolStripMenuItem();
        mnuUnidad6 = new ToolStripMenuItem();
        mnuAcercaDe = new ToolStripMenuItem();
        mnuSalir = new ToolStripMenuItem();
        pnlEncabezado = new Panel();
        lblUnidadActual = new Label();
        lblAsignatura = new Label();
        lblTituloAplicacion = new Label();
        pnlNavegacion = new Panel();
        flpActividades = new FlowLayoutPanel();
        pnlPieNavegacion = new Panel();
        btnSalir = new Button();
        lblDesarrollador = new Label();
        btnInicio = new Button();
        pnlContenido = new Panel();
        barraEstado = new StatusStrip();
        lblEstado = new ToolStripStatusLabel();
        lblFecha = new ToolStripStatusLabel();
        temporizadorReloj = new System.Windows.Forms.Timer(components);
        menuPrincipal.SuspendLayout();
        pnlEncabezado.SuspendLayout();
        pnlNavegacion.SuspendLayout();
        pnlPieNavegacion.SuspendLayout();
        barraEstado.SuspendLayout();
        SuspendLayout();
        //
        // menuPrincipal
        //
        menuPrincipal.Font = new Font("Segoe UI", 9F);
        menuPrincipal.LayoutStyle = ToolStripLayoutStyle.Flow;
        menuPrincipal.Items.AddRange(new ToolStripItem[] { mnuInicio, mnuUnidad1, mnuUnidad2, mnuUnidad3, mnuUnidad4, mnuUnidad5, mnuUnidad6, mnuAcercaDe, mnuSalir });
        menuPrincipal.Location = new Point(0, 0);
        menuPrincipal.Name = "menuPrincipal";
        menuPrincipal.Size = new Size(1280, 25);
        menuPrincipal.TabIndex = 0;
        //
        // mnuInicio
        //
        mnuInicio.Name = "mnuInicio";
        mnuInicio.Size = new Size(54, 21);
        mnuInicio.Text = "&Inicio";
        mnuInicio.Click += mnuInicio_Click;
        //
        // mnuUnidad1
        //
        mnuUnidad1.Name = "mnuUnidad1";
        mnuUnidad1.Size = new Size(200, 21);
        mnuUnidad1.Text = "Unidad &1 — Introducción a la programación";
        //
        // mnuUnidad2
        //
        mnuUnidad2.Name = "mnuUnidad2";
        mnuUnidad2.Size = new Size(180, 21);
        mnuUnidad2.Text = "Unidad &2 — Encapsulación";
        //
        // mnuUnidad3
        //
        mnuUnidad3.Name = "mnuUnidad3";
        mnuUnidad3.Size = new Size(300, 21);
        mnuUnidad3.Text = "Unidad &3 — Relaciones entre clases y contenedores";
        //
        // mnuUnidad4
        //
        mnuUnidad4.Name = "mnuUnidad4";
        mnuUnidad4.Size = new Size(320, 21);
        mnuUnidad4.Text = "Unidad &4 — Herencia, polimorfismo y clases abstractas";
        //
        // mnuUnidad5
        //
        mnuUnidad5.Name = "mnuUnidad5";
        mnuUnidad5.Size = new Size(300, 21);
        mnuUnidad5.Text = "Unidad &5 — Polimorfismo y sobrecarga de operadores";
        //
        // mnuUnidad6
        //
        mnuUnidad6.Name = "mnuUnidad6";
        mnuUnidad6.Size = new Size(280, 21);
        mnuUnidad6.Text = "Unidad &6 — Excepciones y persistencia de datos";
        //
        // mnuAcercaDe
        //
        mnuAcercaDe.Name = "mnuAcercaDe";
        mnuAcercaDe.Size = new Size(80, 21);
        mnuAcercaDe.Text = "Acerca &de";
        mnuAcercaDe.Click += mnuAcercaDe_Click;
        //
        // mnuSalir
        //
        mnuSalir.Name = "mnuSalir";
        mnuSalir.Size = new Size(45, 21);
        mnuSalir.Text = "&Salir";
        mnuSalir.Click += mnuSalir_Click;
        //
        // pnlEncabezado
        //
        pnlEncabezado.BackColor = Color.FromArgb(31, 78, 121);
        pnlEncabezado.Controls.Add(lblUnidadActual);
        pnlEncabezado.Controls.Add(lblAsignatura);
        pnlEncabezado.Controls.Add(lblTituloAplicacion);
        pnlEncabezado.Dock = DockStyle.Top;
        pnlEncabezado.Location = new Point(0, 25);
        pnlEncabezado.Name = "pnlEncabezado";
        pnlEncabezado.Size = new Size(1280, 66);
        pnlEncabezado.TabIndex = 1;
        //
        // lblUnidadActual
        //
        lblUnidadActual.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblUnidadActual.BackColor = Color.FromArgb(46, 134, 193);
        lblUnidadActual.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
        lblUnidadActual.ForeColor = Color.White;
        lblUnidadActual.Location = new Point(850, 18);
        lblUnidadActual.Name = "lblUnidadActual";
        lblUnidadActual.Padding = new Padding(8, 0, 8, 0);
        lblUnidadActual.Size = new Size(410, 30);
        lblUnidadActual.TabIndex = 2;
        lblUnidadActual.Text = "Inicio";
        lblUnidadActual.TextAlign = ContentAlignment.MiddleCenter;
        //
        // lblAsignatura
        //
        lblAsignatura.AutoSize = true;
        lblAsignatura.Font = new Font("Segoe UI", 9F);
        lblAsignatura.ForeColor = Color.FromArgb(214, 234, 248);
        lblAsignatura.Location = new Point(20, 40);
        lblAsignatura.Name = "lblAsignatura";
        lblAsignatura.Size = new Size(200, 15);
        lblAsignatura.TabIndex = 1;
        lblAsignatura.Text = "Asignatura";
        //
        // lblTituloAplicacion
        //
        lblTituloAplicacion.AutoSize = true;
        lblTituloAplicacion.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
        lblTituloAplicacion.ForeColor = Color.White;
        lblTituloAplicacion.Location = new Point(18, 8);
        lblTituloAplicacion.Name = "lblTituloAplicacion";
        lblTituloAplicacion.Size = new Size(520, 28);
        lblTituloAplicacion.TabIndex = 0;
        lblTituloAplicacion.Text = "Sistema Integrador de Programación Orientada a Objetos";
        //
        // pnlNavegacion
        //
        pnlNavegacion.BackColor = Color.FromArgb(23, 42, 69);
        pnlNavegacion.Controls.Add(flpActividades);
        pnlNavegacion.Controls.Add(pnlPieNavegacion);
        pnlNavegacion.Controls.Add(btnInicio);
        pnlNavegacion.Dock = DockStyle.Left;
        pnlNavegacion.Location = new Point(0, 91);
        pnlNavegacion.Name = "pnlNavegacion";
        pnlNavegacion.Size = new Size(240, 667);
        pnlNavegacion.TabIndex = 2;
        //
        // flpActividades
        //
        flpActividades.AutoScroll = true;
        flpActividades.Dock = DockStyle.Fill;
        flpActividades.FlowDirection = FlowDirection.TopDown;
        flpActividades.Location = new Point(0, 48);
        flpActividades.Name = "flpActividades";
        flpActividades.Padding = new Padding(6, 4, 0, 4);
        flpActividades.Size = new Size(240, 529);
        flpActividades.TabIndex = 1;
        flpActividades.WrapContents = false;
        //
        // pnlPieNavegacion
        //
        pnlPieNavegacion.Controls.Add(btnSalir);
        pnlPieNavegacion.Controls.Add(lblDesarrollador);
        pnlPieNavegacion.Dock = DockStyle.Bottom;
        pnlPieNavegacion.Location = new Point(0, 577);
        pnlPieNavegacion.Name = "pnlPieNavegacion";
        pnlPieNavegacion.Size = new Size(240, 90);
        pnlPieNavegacion.TabIndex = 2;
        //
        // btnSalir
        //
        btnSalir.Location = new Point(12, 50);
        btnSalir.Name = "btnSalir";
        btnSalir.Size = new Size(216, 32);
        btnSalir.TabIndex = 1;
        btnSalir.Tag = "peligro";
        btnSalir.Text = "Salir de la aplicación";
        btnSalir.Click += mnuSalir_Click;
        //
        // lblDesarrollador
        //
        lblDesarrollador.Font = new Font("Segoe UI", 8.25F);
        lblDesarrollador.ForeColor = Color.FromArgb(173, 181, 189);
        lblDesarrollador.Location = new Point(12, 6);
        lblDesarrollador.Name = "lblDesarrollador";
        lblDesarrollador.Size = new Size(216, 40);
        lblDesarrollador.TabIndex = 0;
        lblDesarrollador.Text = "Desarrollado por";
        //
        // btnInicio
        //
        btnInicio.Dock = DockStyle.Top;
        btnInicio.Location = new Point(0, 0);
        btnInicio.Name = "btnInicio";
        btnInicio.Size = new Size(240, 48);
        btnInicio.TabIndex = 0;
        btnInicio.Text = "⌂  Inicio";
        btnInicio.TextAlign = ContentAlignment.MiddleLeft;
        btnInicio.Padding = new Padding(14, 0, 0, 0);
        btnInicio.Click += mnuInicio_Click;
        //
        // pnlContenido
        //
        pnlContenido.AutoScroll = true;
        pnlContenido.BackColor = Color.FromArgb(244, 246, 249);
        pnlContenido.Dock = DockStyle.Fill;
        pnlContenido.Location = new Point(240, 91);
        pnlContenido.Name = "pnlContenido";
        pnlContenido.Size = new Size(1040, 667);
        pnlContenido.TabIndex = 3;
        //
        // barraEstado
        //
        barraEstado.Items.AddRange(new ToolStripItem[] { lblEstado, lblFecha });
        barraEstado.Location = new Point(0, 758);
        barraEstado.Name = "barraEstado";
        barraEstado.Size = new Size(1280, 22);
        barraEstado.TabIndex = 4;
        //
        // lblEstado
        //
        lblEstado.Name = "lblEstado";
        lblEstado.Size = new Size(1150, 17);
        lblEstado.Spring = true;
        lblEstado.Text = "Listo";
        lblEstado.TextAlign = ContentAlignment.MiddleLeft;
        //
        // lblFecha
        //
        lblFecha.Name = "lblFecha";
        lblFecha.Size = new Size(100, 17);
        lblFecha.Text = "Fecha";
        //
        // temporizadorReloj
        //
        temporizadorReloj.Interval = 1000;
        temporizadorReloj.Tick += temporizadorReloj_Tick;
        //
        // FrmPrincipal
        //
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1280, 780);
        Controls.Add(pnlContenido);
        Controls.Add(pnlNavegacion);
        Controls.Add(pnlEncabezado);
        Controls.Add(barraEstado);
        Controls.Add(menuPrincipal);
        Font = new Font("Segoe UI", 9.75F);
        MainMenuStrip = menuPrincipal;
        MinimumSize = new Size(1024, 700);
        Name = "FrmPrincipal";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Sistema Integrador de Programación Orientada a Objetos";
        WindowState = FormWindowState.Maximized;
        FormClosing += FrmPrincipal_FormClosing;
        Load += FrmPrincipal_Load;
        menuPrincipal.ResumeLayout(false);
        menuPrincipal.PerformLayout();
        pnlEncabezado.ResumeLayout(false);
        pnlEncabezado.PerformLayout();
        pnlNavegacion.ResumeLayout(false);
        pnlPieNavegacion.ResumeLayout(false);
        barraEstado.ResumeLayout(false);
        barraEstado.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private MenuStrip menuPrincipal;
    private ToolStripMenuItem mnuInicio;
    private ToolStripMenuItem mnuUnidad1;
    private ToolStripMenuItem mnuUnidad2;
    private ToolStripMenuItem mnuUnidad3;
    private ToolStripMenuItem mnuUnidad4;
    private ToolStripMenuItem mnuUnidad5;
    private ToolStripMenuItem mnuUnidad6;
    private ToolStripMenuItem mnuAcercaDe;
    private ToolStripMenuItem mnuSalir;
    private Panel pnlEncabezado;
    private Label lblUnidadActual;
    private Label lblAsignatura;
    private Label lblTituloAplicacion;
    private Panel pnlNavegacion;
    private FlowLayoutPanel flpActividades;
    private Panel pnlPieNavegacion;
    private Button btnSalir;
    private Label lblDesarrollador;
    private Button btnInicio;
    private Panel pnlContenido;
    private StatusStrip barraEstado;
    private ToolStripStatusLabel lblEstado;
    private ToolStripStatusLabel lblFecha;
    private System.Windows.Forms.Timer temporizadorReloj;
}
