namespace ProyectoIntegradorPOO.Forms.Unidad4;

partial class FrmNomina
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
        grpEmpleado = new GroupBox();
        btnCalcular = new Button();
        btnEliminar = new Button();
        btnAgregar = new Button();
        txtCampo3 = new TextBox();
        lblCampo3 = new Label();
        txtCampo2 = new TextBox();
        lblCampo2 = new Label();
        txtCampo1 = new TextBox();
        lblCampo1 = new Label();
        txtNombre = new TextBox();
        lblNombre = new Label();
        txtCodigo = new TextBox();
        lblCodigo = new Label();
        cmbTipo = new ComboBox();
        lblTipo = new Label();
        dgvEmpleados = new DataGridView();
        lblTotal = new Label();
        txtTraza = new TextBox();
        lblJerarquia = new Label();
        grpEmpleado.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvEmpleados).BeginInit();
        SuspendLayout();
        //
        // grpEmpleado
        //
        grpEmpleado.Controls.Add(btnCalcular);
        grpEmpleado.Controls.Add(btnEliminar);
        grpEmpleado.Controls.Add(btnAgregar);
        grpEmpleado.Controls.Add(txtCampo3);
        grpEmpleado.Controls.Add(lblCampo3);
        grpEmpleado.Controls.Add(txtCampo2);
        grpEmpleado.Controls.Add(lblCampo2);
        grpEmpleado.Controls.Add(txtCampo1);
        grpEmpleado.Controls.Add(lblCampo1);
        grpEmpleado.Controls.Add(txtNombre);
        grpEmpleado.Controls.Add(lblNombre);
        grpEmpleado.Controls.Add(txtCodigo);
        grpEmpleado.Controls.Add(lblCodigo);
        grpEmpleado.Controls.Add(cmbTipo);
        grpEmpleado.Controls.Add(lblTipo);
        grpEmpleado.Location = new Point(20, 92);
        grpEmpleado.Name = "grpEmpleado";
        grpEmpleado.Size = new Size(380, 340);
        grpEmpleado.TabIndex = 1;
        grpEmpleado.TabStop = false;
        grpEmpleado.Text = "Registrar empleado";
        //
        // lblTipo
        //
        lblTipo.AutoSize = true;
        lblTipo.Location = new Point(16, 33);
        lblTipo.Name = "lblTipo";
        lblTipo.Size = new Size(36, 17);
        lblTipo.Text = "Tipo:";
        //
        // cmbTipo
        //
        cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbTipo.Location = new Point(140, 30);
        cmbTipo.Name = "cmbTipo";
        cmbTipo.Size = new Size(220, 25);
        cmbTipo.TabIndex = 0;
        cmbTipo.SelectedIndexChanged += cmbTipo_SelectedIndexChanged;
        //
        // lblCodigo
        //
        lblCodigo.AutoSize = true;
        lblCodigo.Location = new Point(16, 67);
        lblCodigo.Name = "lblCodigo";
        lblCodigo.Size = new Size(52, 17);
        lblCodigo.Text = "Código:";
        //
        // txtCodigo
        //
        txtCodigo.CharacterCasing = CharacterCasing.Upper;
        txtCodigo.Location = new Point(140, 64);
        txtCodigo.MaxLength = 10;
        txtCodigo.Name = "txtCodigo";
        txtCodigo.PlaceholderText = "E001";
        txtCodigo.Size = new Size(220, 25);
        txtCodigo.TabIndex = 1;
        //
        // lblNombre
        //
        lblNombre.AutoSize = true;
        lblNombre.Location = new Point(16, 101);
        lblNombre.Name = "lblNombre";
        lblNombre.Size = new Size(59, 17);
        lblNombre.Text = "Nombre:";
        //
        // txtNombre
        //
        txtNombre.Location = new Point(140, 98);
        txtNombre.MaxLength = 60;
        txtNombre.Name = "txtNombre";
        txtNombre.Size = new Size(220, 25);
        txtNombre.TabIndex = 2;
        //
        // lblCampo1
        //
        lblCampo1.AutoSize = true;
        lblCampo1.Location = new Point(16, 135);
        lblCampo1.Name = "lblCampo1";
        lblCampo1.Size = new Size(105, 17);
        lblCampo1.Text = "Salario mensual:";
        //
        // txtCampo1
        //
        txtCampo1.Location = new Point(140, 132);
        txtCampo1.Name = "txtCampo1";
        txtCampo1.Size = new Size(220, 25);
        txtCampo1.TabIndex = 3;
        txtCampo1.TextAlign = HorizontalAlignment.Right;
        //
        // lblCampo2
        //
        lblCampo2.AutoSize = true;
        lblCampo2.Location = new Point(16, 169);
        lblCampo2.Name = "lblCampo2";
        lblCampo2.Size = new Size(60, 17);
        lblCampo2.Text = "Campo 2:";
        //
        // txtCampo2
        //
        txtCampo2.Location = new Point(140, 166);
        txtCampo2.Name = "txtCampo2";
        txtCampo2.Size = new Size(220, 25);
        txtCampo2.TabIndex = 4;
        txtCampo2.TextAlign = HorizontalAlignment.Right;
        //
        // lblCampo3
        //
        lblCampo3.AutoSize = true;
        lblCampo3.Location = new Point(16, 203);
        lblCampo3.Name = "lblCampo3";
        lblCampo3.Size = new Size(60, 17);
        lblCampo3.Text = "Campo 3:";
        //
        // txtCampo3
        //
        txtCampo3.Location = new Point(140, 200);
        txtCampo3.Name = "txtCampo3";
        txtCampo3.Size = new Size(220, 25);
        txtCampo3.TabIndex = 5;
        txtCampo3.TextAlign = HorizontalAlignment.Right;
        //
        // btnAgregar
        //
        btnAgregar.Location = new Point(16, 244);
        btnAgregar.Name = "btnAgregar";
        btnAgregar.Size = new Size(168, 36);
        btnAgregar.TabIndex = 6;
        btnAgregar.Tag = "exito";
        btnAgregar.Text = "Agregar empleado";
        btnAgregar.Click += btnAgregar_Click;
        //
        // btnEliminar
        //
        btnEliminar.Location = new Point(192, 244);
        btnEliminar.Name = "btnEliminar";
        btnEliminar.Size = new Size(168, 36);
        btnEliminar.TabIndex = 7;
        btnEliminar.Tag = "peligro";
        btnEliminar.Text = "Eliminar seleccionado";
        btnEliminar.Click += btnEliminar_Click;
        //
        // btnCalcular
        //
        btnCalcular.Location = new Point(16, 288);
        btnCalcular.Name = "btnCalcular";
        btnCalcular.Size = new Size(344, 36);
        btnCalcular.TabIndex = 8;
        btnCalcular.Text = "Calcular nómina (polimorfismo)";
        btnCalcular.Click += btnCalcular_Click;
        //
        // lblJerarquia
        //
        lblJerarquia.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        lblJerarquia.BackColor = Color.White;
        lblJerarquia.BorderStyle = BorderStyle.FixedSingle;
        lblJerarquia.Font = new Font("Consolas", 9F);
        lblJerarquia.Location = new Point(20, 442);
        lblJerarquia.Name = "lblJerarquia";
        lblJerarquia.Padding = new Padding(8);
        lblJerarquia.Size = new Size(380, 182);
        lblJerarquia.TabIndex = 2;
        lblJerarquia.Text = "abstract class Empleado\r\n  + Codigo, Nombre\r\n  + abstract CalcularSalario()\r\n  + virtual Detalle()\r\n      ▲\r\n      ├── EmpleadoFijo      : SalarioMensual\r\n      ├── EmpleadoPorHoras  : Horas × Tarifa\r\n      └── EmpleadoComision  : Base + % Ventas\r\n\r\nCada derivada llama a base(codigo, nombre).";
        //
        // dgvEmpleados
        //
        dgvEmpleados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvEmpleados.Location = new Point(420, 92);
        dgvEmpleados.Name = "dgvEmpleados";
        dgvEmpleados.Size = new Size(600, 350);
        dgvEmpleados.TabIndex = 3;
        //
        // lblTotal
        //
        lblTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lblTotal.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblTotal.ForeColor = Color.FromArgb(31, 78, 121);
        lblTotal.Location = new Point(420, 448);
        lblTotal.Name = "lblTotal";
        lblTotal.Size = new Size(600, 30);
        lblTotal.TabIndex = 4;
        lblTotal.Text = "Total de la nómina: RD$ 0.00";
        lblTotal.TextAlign = ContentAlignment.MiddleRight;
        //
        // txtTraza
        //
        txtTraza.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        txtTraza.BackColor = Color.FromArgb(30, 30, 30);
        txtTraza.Font = new Font("Consolas", 9.5F);
        txtTraza.ForeColor = Color.FromArgb(220, 220, 220);
        txtTraza.Location = new Point(420, 484);
        txtTraza.Multiline = true;
        txtTraza.Name = "txtTraza";
        txtTraza.ReadOnly = true;
        txtTraza.ScrollBars = ScrollBars.Both;
        txtTraza.Size = new Size(600, 140);
        txtTraza.TabIndex = 5;
        txtTraza.WordWrap = false;
        //
        // FrmNomina
        //
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1040, 640);
        Controls.Add(txtTraza);
        Controls.Add(lblTotal);
        Controls.Add(dgvEmpleados);
        Controls.Add(lblJerarquia);
        Controls.Add(grpEmpleado);
        Name = "FrmNomina";
        Text = "Nómina de empleados";
        grpEmpleado.ResumeLayout(false);
        grpEmpleado.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvEmpleados).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private GroupBox grpEmpleado;
    private Button btnCalcular;
    private Button btnEliminar;
    private Button btnAgregar;
    private TextBox txtCampo3;
    private Label lblCampo3;
    private TextBox txtCampo2;
    private Label lblCampo2;
    private TextBox txtCampo1;
    private Label lblCampo1;
    private TextBox txtNombre;
    private Label lblNombre;
    private TextBox txtCodigo;
    private Label lblCodigo;
    private ComboBox cmbTipo;
    private Label lblTipo;
    private DataGridView dgvEmpleados;
    private Label lblTotal;
    private TextBox txtTraza;
    private Label lblJerarquia;
}
