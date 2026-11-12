namespace ProyectoIntegradorPOO.Forms.Unidad2;

partial class FrmCuentaBancaria
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
        grpDatos = new GroupBox();
        btnNuevaCuenta = new Button();
        btnAbrirCuenta = new Button();
        txtNumeroCuenta = new TextBox();
        lblNumeroCuenta = new Label();
        txtTitular = new TextBox();
        lblTitular = new Label();
        grpOperaciones = new GroupBox();
        btnConsultarSaldo = new Button();
        btnRetirar = new Button();
        btnDepositar = new Button();
        txtMonto = new TextBox();
        lblMonto = new Label();
        pnlSaldo = new Panel();
        lblCuentaActiva = new Label();
        lblSaldo = new Label();
        lblSaldoTitulo = new Label();
        grpHistorial = new GroupBox();
        dgvMovimientos = new DataGridView();
        btnDemostracion = new Button();
        lblExplicacion = new Label();
        errorProvider = new ErrorProvider(components);
        grpDatos.SuspendLayout();
        grpOperaciones.SuspendLayout();
        pnlSaldo.SuspendLayout();
        grpHistorial.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvMovimientos).BeginInit();
        ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
        SuspendLayout();
        //
        // grpDatos
        //
        grpDatos.Controls.Add(btnNuevaCuenta);
        grpDatos.Controls.Add(btnAbrirCuenta);
        grpDatos.Controls.Add(txtNumeroCuenta);
        grpDatos.Controls.Add(lblNumeroCuenta);
        grpDatos.Controls.Add(txtTitular);
        grpDatos.Controls.Add(lblTitular);
        grpDatos.Location = new Point(20, 92);
        grpDatos.Name = "grpDatos";
        grpDatos.Size = new Size(380, 160);
        grpDatos.TabIndex = 1;
        grpDatos.TabStop = false;
        grpDatos.Text = "Datos de la cuenta";
        //
        // lblTitular
        //
        lblTitular.AutoSize = true;
        lblTitular.Location = new Point(16, 34);
        lblTitular.Name = "lblTitular";
        lblTitular.Size = new Size(47, 17);
        lblTitular.TabIndex = 0;
        lblTitular.Text = "Titular:";
        //
        // txtTitular
        //
        txtTitular.Location = new Point(140, 30);
        txtTitular.MaxLength = 80;
        txtTitular.Name = "txtTitular";
        txtTitular.PlaceholderText = "Nombre completo";
        txtTitular.Size = new Size(215, 25);
        txtTitular.TabIndex = 1;
        //
        // lblNumeroCuenta
        //
        lblNumeroCuenta.AutoSize = true;
        lblNumeroCuenta.Location = new Point(16, 70);
        lblNumeroCuenta.Name = "lblNumeroCuenta";
        lblNumeroCuenta.Size = new Size(118, 17);
        lblNumeroCuenta.TabIndex = 2;
        lblNumeroCuenta.Text = "Número de cuenta:";
        //
        // txtNumeroCuenta
        //
        txtNumeroCuenta.Location = new Point(140, 66);
        txtNumeroCuenta.MaxLength = 10;
        txtNumeroCuenta.Name = "txtNumeroCuenta";
        txtNumeroCuenta.PlaceholderText = "10 dígitos";
        txtNumeroCuenta.Size = new Size(215, 25);
        txtNumeroCuenta.TabIndex = 3;
        //
        // btnAbrirCuenta
        //
        btnAbrirCuenta.Location = new Point(140, 106);
        btnAbrirCuenta.Name = "btnAbrirCuenta";
        btnAbrirCuenta.Size = new Size(105, 36);
        btnAbrirCuenta.TabIndex = 4;
        btnAbrirCuenta.Tag = "exito";
        btnAbrirCuenta.Text = "Abrir cuenta";
        btnAbrirCuenta.Click += btnAbrirCuenta_Click;
        //
        // btnNuevaCuenta
        //
        btnNuevaCuenta.Location = new Point(250, 106);
        btnNuevaCuenta.Name = "btnNuevaCuenta";
        btnNuevaCuenta.Size = new Size(105, 36);
        btnNuevaCuenta.TabIndex = 5;
        btnNuevaCuenta.Tag = "secundario";
        btnNuevaCuenta.Text = "Nueva cuenta";
        btnNuevaCuenta.Click += btnNuevaCuenta_Click;
        //
        // grpOperaciones
        //
        grpOperaciones.Controls.Add(btnConsultarSaldo);
        grpOperaciones.Controls.Add(btnRetirar);
        grpOperaciones.Controls.Add(btnDepositar);
        grpOperaciones.Controls.Add(txtMonto);
        grpOperaciones.Controls.Add(lblMonto);
        grpOperaciones.Location = new Point(20, 264);
        grpOperaciones.Name = "grpOperaciones";
        grpOperaciones.Size = new Size(380, 160);
        grpOperaciones.TabIndex = 2;
        grpOperaciones.TabStop = false;
        grpOperaciones.Text = "Operaciones";
        //
        // lblMonto
        //
        lblMonto.AutoSize = true;
        lblMonto.Location = new Point(16, 34);
        lblMonto.Name = "lblMonto";
        lblMonto.Size = new Size(83, 17);
        lblMonto.TabIndex = 0;
        lblMonto.Text = "Monto (RD$):";
        //
        // txtMonto
        //
        txtMonto.Location = new Point(140, 30);
        txtMonto.Name = "txtMonto";
        txtMonto.PlaceholderText = "0.00";
        txtMonto.Size = new Size(215, 25);
        txtMonto.TabIndex = 1;
        txtMonto.TextAlign = HorizontalAlignment.Right;
        txtMonto.KeyDown += txtMonto_KeyDown;
        //
        // btnDepositar
        //
        btnDepositar.Location = new Point(16, 72);
        btnDepositar.Name = "btnDepositar";
        btnDepositar.Size = new Size(165, 36);
        btnDepositar.TabIndex = 2;
        btnDepositar.Tag = "exito";
        btnDepositar.Text = "Depositar";
        btnDepositar.Click += btnDepositar_Click;
        //
        // btnRetirar
        //
        btnRetirar.Location = new Point(190, 72);
        btnRetirar.Name = "btnRetirar";
        btnRetirar.Size = new Size(165, 36);
        btnRetirar.TabIndex = 3;
        btnRetirar.Tag = "peligro";
        btnRetirar.Text = "Retirar";
        btnRetirar.Click += btnRetirar_Click;
        //
        // btnConsultarSaldo
        //
        btnConsultarSaldo.Location = new Point(16, 114);
        btnConsultarSaldo.Name = "btnConsultarSaldo";
        btnConsultarSaldo.Size = new Size(339, 36);
        btnConsultarSaldo.TabIndex = 4;
        btnConsultarSaldo.Text = "Consultar saldo";
        btnConsultarSaldo.Click += btnConsultarSaldo_Click;
        //
        // pnlSaldo
        //
        pnlSaldo.BackColor = Color.FromArgb(31, 78, 121);
        pnlSaldo.Controls.Add(lblCuentaActiva);
        pnlSaldo.Controls.Add(lblSaldo);
        pnlSaldo.Controls.Add(lblSaldoTitulo);
        pnlSaldo.Location = new Point(20, 436);
        pnlSaldo.Name = "pnlSaldo";
        pnlSaldo.Size = new Size(380, 110);
        pnlSaldo.TabIndex = 3;
        //
        // lblSaldoTitulo
        //
        lblSaldoTitulo.AutoSize = true;
        lblSaldoTitulo.ForeColor = Color.FromArgb(214, 234, 248);
        lblSaldoTitulo.Location = new Point(14, 10);
        lblSaldoTitulo.Name = "lblSaldoTitulo";
        lblSaldoTitulo.Size = new Size(104, 17);
        lblSaldoTitulo.TabIndex = 0;
        lblSaldoTitulo.Text = "Saldo disponible";
        //
        // lblSaldo
        //
        lblSaldo.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblSaldo.ForeColor = Color.White;
        lblSaldo.Location = new Point(10, 30);
        lblSaldo.Name = "lblSaldo";
        lblSaldo.Size = new Size(360, 44);
        lblSaldo.TabIndex = 1;
        lblSaldo.Text = "RD$ 0.00";
        //
        // lblCuentaActiva
        //
        lblCuentaActiva.ForeColor = Color.FromArgb(214, 234, 248);
        lblCuentaActiva.Location = new Point(14, 80);
        lblCuentaActiva.Name = "lblCuentaActiva";
        lblCuentaActiva.Size = new Size(356, 22);
        lblCuentaActiva.TabIndex = 2;
        lblCuentaActiva.Text = "No hay una cuenta abierta.";
        //
        // grpHistorial
        //
        grpHistorial.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        grpHistorial.Controls.Add(dgvMovimientos);
        grpHistorial.Location = new Point(420, 92);
        grpHistorial.Name = "grpHistorial";
        grpHistorial.Padding = new Padding(10);
        grpHistorial.Size = new Size(600, 454);
        grpHistorial.TabIndex = 4;
        grpHistorial.TabStop = false;
        grpHistorial.Text = "Operaciones realizadas";
        //
        // dgvMovimientos
        //
        dgvMovimientos.Dock = DockStyle.Fill;
        dgvMovimientos.Location = new Point(10, 28);
        dgvMovimientos.Name = "dgvMovimientos";
        dgvMovimientos.Size = new Size(580, 416);
        dgvMovimientos.TabIndex = 0;
        //
        // btnDemostracion
        //
        btnDemostracion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnDemostracion.Location = new Point(20, 560);
        btnDemostracion.Name = "btnDemostracion";
        btnDemostracion.Size = new Size(380, 36);
        btnDemostracion.TabIndex = 5;
        btnDemostracion.Tag = "secundario";
        btnDemostracion.Text = "¿Puedo cambiar el saldo directamente?";
        btnDemostracion.Click += btnDemostracion_Click;
        //
        // lblExplicacion
        //
        lblExplicacion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lblExplicacion.ForeColor = Color.FromArgb(108, 117, 125);
        lblExplicacion.Location = new Point(420, 556);
        lblExplicacion.Name = "lblExplicacion";
        lblExplicacion.Size = new Size(600, 64);
        lblExplicacion.TabIndex = 6;
        lblExplicacion.Text = "Titular, NumeroCuenta y Saldo son atributos privados expuestos solo con get. El saldo cambia únicamente con Depositar() (monto > 0) y Retirar() (monto ≤ saldo). El historial se expone como IReadOnlyList, así el formulario no puede alterarlo.";
        //
        // errorProvider
        //
        errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        errorProvider.ContainerControl = this;
        //
        // FrmCuentaBancaria
        //
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1040, 640);
        Controls.Add(lblExplicacion);
        Controls.Add(btnDemostracion);
        Controls.Add(grpHistorial);
        Controls.Add(pnlSaldo);
        Controls.Add(grpOperaciones);
        Controls.Add(grpDatos);
        Name = "FrmCuentaBancaria";
        Text = "Cuenta bancaria";
        grpDatos.ResumeLayout(false);
        grpDatos.PerformLayout();
        grpOperaciones.ResumeLayout(false);
        grpOperaciones.PerformLayout();
        pnlSaldo.ResumeLayout(false);
        pnlSaldo.PerformLayout();
        grpHistorial.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvMovimientos).EndInit();
        ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox grpDatos;
    private Button btnNuevaCuenta;
    private Button btnAbrirCuenta;
    private TextBox txtNumeroCuenta;
    private Label lblNumeroCuenta;
    private TextBox txtTitular;
    private Label lblTitular;
    private GroupBox grpOperaciones;
    private Button btnConsultarSaldo;
    private Button btnRetirar;
    private Button btnDepositar;
    private TextBox txtMonto;
    private Label lblMonto;
    private Panel pnlSaldo;
    private Label lblCuentaActiva;
    private Label lblSaldo;
    private Label lblSaldoTitulo;
    private GroupBox grpHistorial;
    private DataGridView dgvMovimientos;
    private Button btnDemostracion;
    private Label lblExplicacion;
    private ErrorProvider errorProvider;
}
