namespace ProyectoIntegradorPOO.Forms.Unidad6;

partial class FrmManejoExcepciones
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
        grpEntrada = new GroupBox();
        txtValorB = new TextBox();
        lblValorB = new Label();
        txtValorA = new TextBox();
        lblValorA = new Label();
        grpPruebas = new GroupBox();
        btnRelanzar = new Button();
        btnLeerArchivo = new Button();
        btnValidarEdad = new Button();
        btnIndice = new Button();
        btnMultiplicar = new Button();
        btnDividir = new Button();
        pnlMensaje = new Panel();
        lblMensaje = new Label();
        lblContadores = new Label();
        lblLeyenda = new Label();
        rtbTraza = new RichTextBox();
        btnLimpiarTraza = new Button();
        errorProvider = new ErrorProvider(components);
        grpEntrada.SuspendLayout();
        grpPruebas.SuspendLayout();
        pnlMensaje.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
        SuspendLayout();
        //
        // grpEntrada
        //
        grpEntrada.Controls.Add(txtValorB);
        grpEntrada.Controls.Add(lblValorB);
        grpEntrada.Controls.Add(txtValorA);
        grpEntrada.Controls.Add(lblValorA);
        grpEntrada.Location = new Point(20, 92);
        grpEntrada.Name = "grpEntrada";
        grpEntrada.Size = new Size(400, 104);
        grpEntrada.TabIndex = 1;
        grpEntrada.TabStop = false;
        grpEntrada.Text = "Datos de entrada (escriba valores válidos o inválidos)";
        //
        // lblValorA
        //
        lblValorA.AutoSize = true;
        lblValorA.Location = new Point(14, 33);
        lblValorA.Name = "lblValorA";
        lblValorA.Size = new Size(57, 17);
        lblValorA.Text = "Valor A:";
        //
        // txtValorA
        //
        txtValorA.Location = new Point(90, 30);
        txtValorA.Name = "txtValorA";
        txtValorA.Size = new Size(280, 25);
        txtValorA.TabIndex = 0;
        txtValorA.Text = "100";
        //
        // lblValorB
        //
        lblValorB.AutoSize = true;
        lblValorB.Location = new Point(14, 67);
        lblValorB.Name = "lblValorB";
        lblValorB.Size = new Size(56, 17);
        lblValorB.Text = "Valor B:";
        //
        // txtValorB
        //
        txtValorB.Location = new Point(90, 64);
        txtValorB.Name = "txtValorB";
        txtValorB.Size = new Size(280, 25);
        txtValorB.TabIndex = 1;
        txtValorB.Text = "0";
        //
        // grpPruebas
        //
        grpPruebas.Controls.Add(btnRelanzar);
        grpPruebas.Controls.Add(btnLeerArchivo);
        grpPruebas.Controls.Add(btnValidarEdad);
        grpPruebas.Controls.Add(btnIndice);
        grpPruebas.Controls.Add(btnMultiplicar);
        grpPruebas.Controls.Add(btnDividir);
        grpPruebas.Location = new Point(20, 204);
        grpPruebas.Name = "grpPruebas";
        grpPruebas.Size = new Size(400, 192);
        grpPruebas.TabIndex = 2;
        grpPruebas.TabStop = false;
        grpPruebas.Text = "Operaciones que pueden fallar";
        //
        // btnDividir
        //
        btnDividir.Location = new Point(14, 30);
        btnDividir.Name = "btnDividir";
        btnDividir.Size = new Size(180, 46);
        btnDividir.TabIndex = 0;
        btnDividir.Text = "Dividir A ÷ B";
        btnDividir.Click += btnDividir_Click;
        //
        // btnMultiplicar
        //
        btnMultiplicar.Location = new Point(204, 30);
        btnMultiplicar.Name = "btnMultiplicar";
        btnMultiplicar.Size = new Size(180, 46);
        btnMultiplicar.TabIndex = 1;
        btnMultiplicar.Text = "Multiplicar A × B (checked)";
        btnMultiplicar.Click += btnMultiplicar_Click;
        //
        // btnIndice
        //
        btnIndice.Location = new Point(14, 84);
        btnIndice.Name = "btnIndice";
        btnIndice.Size = new Size(180, 46);
        btnIndice.TabIndex = 2;
        btnIndice.Text = "Leer arreglo[B] (5 elementos)";
        btnIndice.Click += btnIndice_Click;
        //
        // btnValidarEdad
        //
        btnValidarEdad.Location = new Point(204, 84);
        btnValidarEdad.Name = "btnValidarEdad";
        btnValidarEdad.Size = new Size(180, 46);
        btnValidarEdad.TabIndex = 3;
        btnValidarEdad.Text = "Validar A como edad (excepción propia)";
        btnValidarEdad.Click += btnValidarEdad_Click;
        //
        // btnLeerArchivo
        //
        btnLeerArchivo.Location = new Point(14, 138);
        btnLeerArchivo.Name = "btnLeerArchivo";
        btnLeerArchivo.Size = new Size(180, 46);
        btnLeerArchivo.TabIndex = 4;
        btnLeerArchivo.Text = "Leer archivo inexistente";
        btnLeerArchivo.Click += btnLeerArchivo_Click;
        //
        // btnRelanzar
        //
        btnRelanzar.Location = new Point(204, 138);
        btnRelanzar.Name = "btnRelanzar";
        btnRelanzar.Size = new Size(180, 46);
        btnRelanzar.TabIndex = 5;
        btnRelanzar.Tag = "secundario";
        btnRelanzar.Text = "Convertir A y relanzar (throw;)";
        btnRelanzar.Click += btnRelanzar_Click;
        //
        // pnlMensaje
        //
        pnlMensaje.BackColor = Color.White;
        pnlMensaje.BorderStyle = BorderStyle.FixedSingle;
        pnlMensaje.Controls.Add(lblMensaje);
        pnlMensaje.Location = new Point(20, 406);
        pnlMensaje.Name = "pnlMensaje";
        pnlMensaje.Size = new Size(400, 80);
        pnlMensaje.TabIndex = 3;
        //
        // lblMensaje
        //
        lblMensaje.Dock = DockStyle.Fill;
        lblMensaje.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        lblMensaje.Location = new Point(0, 0);
        lblMensaje.Name = "lblMensaje";
        lblMensaje.Padding = new Padding(10);
        lblMensaje.Size = new Size(398, 78);
        lblMensaje.TabIndex = 0;
        lblMensaje.Text = "El mensaje para el usuario aparecerá aquí.";
        //
        // lblContadores
        //
        lblContadores.Location = new Point(20, 492);
        lblContadores.Name = "lblContadores";
        lblContadores.Size = new Size(400, 22);
        lblContadores.TabIndex = 4;
        lblContadores.Text = "Operaciones ejecutadas: 0   ·   Errores controlados: 0";
        //
        // lblLeyenda
        //
        lblLeyenda.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        lblLeyenda.ForeColor = Color.FromArgb(108, 117, 125);
        lblLeyenda.Location = new Point(20, 518);
        lblLeyenda.Name = "lblLeyenda";
        lblLeyenda.Size = new Size(400, 106);
        lblLeyenda.TabIndex = 5;
        lblLeyenda.Text = "Pruebe: B = 0 (división), A = abc (formato), A = 99999 y B = 99999 (desbordamiento), B = 7 (índice), A = 150 (edad). La traza muestra en azul el try, en rojo el catch que atrapó el error y en verde el finally, que se ejecuta siempre.";
        //
        // rtbTraza
        //
        rtbTraza.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        rtbTraza.BackColor = Color.White;
        rtbTraza.Font = new Font("Consolas", 10F);
        rtbTraza.Location = new Point(440, 92);
        rtbTraza.Name = "rtbTraza";
        rtbTraza.ReadOnly = true;
        rtbTraza.Size = new Size(580, 490);
        rtbTraza.TabIndex = 6;
        rtbTraza.Text = "";
        rtbTraza.WordWrap = false;
        //
        // btnLimpiarTraza
        //
        btnLimpiarTraza.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnLimpiarTraza.Location = new Point(880, 590);
        btnLimpiarTraza.Name = "btnLimpiarTraza";
        btnLimpiarTraza.Size = new Size(140, 34);
        btnLimpiarTraza.TabIndex = 7;
        btnLimpiarTraza.Tag = "secundario";
        btnLimpiarTraza.Text = "Limpiar traza";
        btnLimpiarTraza.Click += btnLimpiarTraza_Click;
        //
        // errorProvider
        //
        errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        errorProvider.ContainerControl = this;
        //
        // FrmManejoExcepciones
        //
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1040, 640);
        Controls.Add(btnLimpiarTraza);
        Controls.Add(rtbTraza);
        Controls.Add(lblLeyenda);
        Controls.Add(lblContadores);
        Controls.Add(pnlMensaje);
        Controls.Add(grpPruebas);
        Controls.Add(grpEntrada);
        Name = "FrmManejoExcepciones";
        Text = "Manejo de excepciones";
        grpEntrada.ResumeLayout(false);
        grpEntrada.PerformLayout();
        grpPruebas.ResumeLayout(false);
        pnlMensaje.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox grpEntrada;
    private TextBox txtValorB;
    private Label lblValorB;
    private TextBox txtValorA;
    private Label lblValorA;
    private GroupBox grpPruebas;
    private Button btnRelanzar;
    private Button btnLeerArchivo;
    private Button btnValidarEdad;
    private Button btnIndice;
    private Button btnMultiplicar;
    private Button btnDividir;
    private Panel pnlMensaje;
    private Label lblMensaje;
    private Label lblContadores;
    private Label lblLeyenda;
    private RichTextBox rtbTraza;
    private Button btnLimpiarTraza;
    private ErrorProvider errorProvider;
}
