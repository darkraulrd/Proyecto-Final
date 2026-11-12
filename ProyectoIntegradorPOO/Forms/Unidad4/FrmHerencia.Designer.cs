namespace ProyectoIntegradorPOO.Forms.Unidad4;

partial class FrmHerencia
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
        grpVehiculo = new GroupBox();
        btnCrear = new Button();
        nudCilindrada = new NumericUpDown();
        lblCilindrada = new Label();
        txtModelo = new TextBox();
        lblModelo = new Label();
        txtMarca = new TextBox();
        lblMarca = new Label();
        rbMotocicleta = new RadioButton();
        rbVehiculo = new RadioButton();
        grpResultado = new GroupBox();
        txtResultado = new TextBox();
        dgvVehiculos = new DataGridView();
        grpPreguntas = new GroupBox();
        txtConceptos = new TextBox();
        grpVehiculo.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudCilindrada).BeginInit();
        grpResultado.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvVehiculos).BeginInit();
        grpPreguntas.SuspendLayout();
        SuspendLayout();
        //
        // grpVehiculo
        //
        grpVehiculo.Controls.Add(btnCrear);
        grpVehiculo.Controls.Add(nudCilindrada);
        grpVehiculo.Controls.Add(lblCilindrada);
        grpVehiculo.Controls.Add(txtModelo);
        grpVehiculo.Controls.Add(lblModelo);
        grpVehiculo.Controls.Add(txtMarca);
        grpVehiculo.Controls.Add(lblMarca);
        grpVehiculo.Controls.Add(rbMotocicleta);
        grpVehiculo.Controls.Add(rbVehiculo);
        grpVehiculo.Location = new Point(20, 92);
        grpVehiculo.Name = "grpVehiculo";
        grpVehiculo.Size = new Size(380, 250);
        grpVehiculo.TabIndex = 1;
        grpVehiculo.TabStop = false;
        grpVehiculo.Text = "Crear objeto";
        //
        // rbVehiculo
        //
        rbVehiculo.AutoSize = true;
        rbVehiculo.Checked = true;
        rbVehiculo.Location = new Point(16, 30);
        rbVehiculo.Name = "rbVehiculo";
        rbVehiculo.Size = new Size(160, 21);
        rbVehiculo.TabIndex = 0;
        rbVehiculo.TabStop = true;
        rbVehiculo.Text = "Vehiculo (clase base)";
        rbVehiculo.CheckedChanged += rbTipo_CheckedChanged;
        //
        // rbMotocicleta
        //
        rbMotocicleta.AutoSize = true;
        rbMotocicleta.Location = new Point(16, 56);
        rbMotocicleta.Name = "rbMotocicleta";
        rbMotocicleta.Size = new Size(200, 21);
        rbMotocicleta.TabIndex = 1;
        rbMotocicleta.Text = "Motocicleta (clase derivada)";
        rbMotocicleta.CheckedChanged += rbTipo_CheckedChanged;
        //
        // lblMarca
        //
        lblMarca.AutoSize = true;
        lblMarca.Location = new Point(16, 95);
        lblMarca.Name = "lblMarca";
        lblMarca.Size = new Size(46, 17);
        lblMarca.Text = "Marca:";
        //
        // txtMarca
        //
        txtMarca.Location = new Point(110, 92);
        txtMarca.MaxLength = 40;
        txtMarca.Name = "txtMarca";
        txtMarca.PlaceholderText = "Yamaha";
        txtMarca.Size = new Size(250, 25);
        txtMarca.TabIndex = 2;
        //
        // lblModelo
        //
        lblModelo.AutoSize = true;
        lblModelo.Location = new Point(16, 129);
        lblModelo.Name = "lblModelo";
        lblModelo.Size = new Size(55, 17);
        lblModelo.Text = "Modelo:";
        //
        // txtModelo
        //
        txtModelo.Location = new Point(110, 126);
        txtModelo.MaxLength = 40;
        txtModelo.Name = "txtModelo";
        txtModelo.PlaceholderText = "FZ 150";
        txtModelo.Size = new Size(250, 25);
        txtModelo.TabIndex = 3;
        //
        // lblCilindrada
        //
        lblCilindrada.AutoSize = true;
        lblCilindrada.Location = new Point(16, 163);
        lblCilindrada.Name = "lblCilindrada";
        lblCilindrada.Size = new Size(90, 17);
        lblCilindrada.Text = "Cilindrada (cc):";
        //
        // nudCilindrada
        //
        nudCilindrada.Location = new Point(110, 160);
        nudCilindrada.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
        nudCilindrada.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
        nudCilindrada.Increment = new decimal(new int[] { 25, 0, 0, 0 });
        nudCilindrada.Name = "nudCilindrada";
        nudCilindrada.Size = new Size(100, 25);
        nudCilindrada.TabIndex = 4;
        nudCilindrada.Value = new decimal(new int[] { 150, 0, 0, 0 });
        //
        // btnCrear
        //
        btnCrear.Location = new Point(110, 200);
        btnCrear.Name = "btnCrear";
        btnCrear.Size = new Size(250, 36);
        btnCrear.TabIndex = 5;
        btnCrear.Tag = "exito";
        btnCrear.Text = "Crear objeto";
        btnCrear.Click += btnCrear_Click;
        //
        // grpResultado
        //
        grpResultado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        grpResultado.Controls.Add(txtResultado);
        grpResultado.Location = new Point(420, 92);
        grpResultado.Name = "grpResultado";
        grpResultado.Padding = new Padding(10);
        grpResultado.Size = new Size(600, 250);
        grpResultado.TabIndex = 2;
        grpResultado.TabStop = false;
        grpResultado.Text = "Resultado de MostrarInformacion() y MostrarCilindrada()";
        //
        // txtResultado
        //
        txtResultado.BackColor = Color.White;
        txtResultado.Dock = DockStyle.Fill;
        txtResultado.Font = new Font("Consolas", 10F);
        txtResultado.Multiline = true;
        txtResultado.Name = "txtResultado";
        txtResultado.ReadOnly = true;
        txtResultado.ScrollBars = ScrollBars.Vertical;
        txtResultado.TabIndex = 0;
        //
        // dgvVehiculos
        //
        dgvVehiculos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvVehiculos.Location = new Point(420, 354);
        dgvVehiculos.Name = "dgvVehiculos";
        dgvVehiculos.Size = new Size(600, 270);
        dgvVehiculos.TabIndex = 3;
        dgvVehiculos.SelectionChanged += dgvVehiculos_SelectionChanged;
        //
        // grpPreguntas
        //
        grpPreguntas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        grpPreguntas.Controls.Add(txtConceptos);
        grpPreguntas.Location = new Point(20, 350);
        grpPreguntas.Name = "grpPreguntas";
        grpPreguntas.Padding = new Padding(10);
        grpPreguntas.Size = new Size(380, 274);
        grpPreguntas.TabIndex = 4;
        grpPreguntas.TabStop = false;
        grpPreguntas.Text = "Preguntas del laboratorio";
        //
        // txtConceptos
        //
        txtConceptos.BackColor = Color.White;
        txtConceptos.BorderStyle = BorderStyle.None;
        txtConceptos.Dock = DockStyle.Fill;
        txtConceptos.Multiline = true;
        txtConceptos.Name = "txtConceptos";
        txtConceptos.ReadOnly = true;
        txtConceptos.ScrollBars = ScrollBars.Vertical;
        txtConceptos.TabIndex = 0;
        //
        // FrmHerencia
        //
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1040, 640);
        Controls.Add(grpPreguntas);
        Controls.Add(dgvVehiculos);
        Controls.Add(grpResultado);
        Controls.Add(grpVehiculo);
        Name = "FrmHerencia";
        Text = "Herencia y constructores";
        grpVehiculo.ResumeLayout(false);
        grpVehiculo.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudCilindrada).EndInit();
        grpResultado.ResumeLayout(false);
        grpResultado.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvVehiculos).EndInit();
        grpPreguntas.ResumeLayout(false);
        grpPreguntas.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox grpVehiculo;
    private Button btnCrear;
    private NumericUpDown nudCilindrada;
    private Label lblCilindrada;
    private TextBox txtModelo;
    private Label lblModelo;
    private TextBox txtMarca;
    private Label lblMarca;
    private RadioButton rbMotocicleta;
    private RadioButton rbVehiculo;
    private GroupBox grpResultado;
    private TextBox txtResultado;
    private DataGridView dgvVehiculos;
    private GroupBox grpPreguntas;
    private TextBox txtConceptos;
}
