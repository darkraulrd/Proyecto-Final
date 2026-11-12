namespace ProyectoIntegradorPOO.Forms.Unidad6;

partial class FrmPersistenciaDatos
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
        btnLimpiar = new Button();
        btnEliminar = new Button();
        btnActualizar = new Button();
        btnGuardar = new Button();
        txtIndice = new TextBox();
        lblIndice = new Label();
        txtEdad = new TextBox();
        lblEdad = new Label();
        cmbCarrera = new ComboBox();
        lblCarrera = new Label();
        txtNombre = new TextBox();
        lblNombre = new Label();
        txtMatricula = new TextBox();
        lblMatricula = new Label();
        grpArchivo = new GroupBox();
        btnAbrirCarpeta = new Button();
        btnRecargar = new Button();
        lblExiste = new Label();
        lblRuta = new Label();
        lblRutaTitulo = new Label();
        lblBuscar = new Label();
        txtBuscar = new TextBox();
        dgvEstudiantes = new DataGridView();
        lblConteo = new Label();
        lblEstado = new Label();
        errorProvider = new ErrorProvider(components);
        grpDatos.SuspendLayout();
        grpArchivo.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvEstudiantes).BeginInit();
        ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
        SuspendLayout();
        //
        // grpDatos
        //
        grpDatos.Controls.Add(btnLimpiar);
        grpDatos.Controls.Add(btnEliminar);
        grpDatos.Controls.Add(btnActualizar);
        grpDatos.Controls.Add(btnGuardar);
        grpDatos.Controls.Add(txtIndice);
        grpDatos.Controls.Add(lblIndice);
        grpDatos.Controls.Add(txtEdad);
        grpDatos.Controls.Add(lblEdad);
        grpDatos.Controls.Add(cmbCarrera);
        grpDatos.Controls.Add(lblCarrera);
        grpDatos.Controls.Add(txtNombre);
        grpDatos.Controls.Add(lblNombre);
        grpDatos.Controls.Add(txtMatricula);
        grpDatos.Controls.Add(lblMatricula);
        grpDatos.Location = new Point(20, 92);
        grpDatos.Name = "grpDatos";
        grpDatos.Size = new Size(370, 292);
        grpDatos.TabIndex = 1;
        grpDatos.TabStop = false;
        grpDatos.Text = "Datos del estudiante";
        //
        // lblMatricula
        //
        lblMatricula.AutoSize = true;
        lblMatricula.Location = new Point(14, 33);
        lblMatricula.Name = "lblMatricula";
        lblMatricula.Size = new Size(65, 17);
        lblMatricula.Text = "Matrícula:";
        //
        // txtMatricula
        //
        txtMatricula.Location = new Point(110, 30);
        txtMatricula.MaxLength = 12;
        txtMatricula.Name = "txtMatricula";
        txtMatricula.PlaceholderText = "100123456";
        txtMatricula.Size = new Size(230, 25);
        txtMatricula.TabIndex = 0;
        //
        // lblNombre
        //
        lblNombre.AutoSize = true;
        lblNombre.Location = new Point(14, 67);
        lblNombre.Name = "lblNombre";
        lblNombre.Size = new Size(59, 17);
        lblNombre.Text = "Nombre:";
        //
        // txtNombre
        //
        txtNombre.Location = new Point(110, 64);
        txtNombre.MaxLength = 80;
        txtNombre.Name = "txtNombre";
        txtNombre.Size = new Size(230, 25);
        txtNombre.TabIndex = 1;
        //
        // lblCarrera
        //
        lblCarrera.AutoSize = true;
        lblCarrera.Location = new Point(14, 101);
        lblCarrera.Name = "lblCarrera";
        lblCarrera.Size = new Size(54, 17);
        lblCarrera.Text = "Carrera:";
        //
        // cmbCarrera
        //
        cmbCarrera.Location = new Point(110, 98);
        cmbCarrera.MaxLength = 80;
        cmbCarrera.Name = "cmbCarrera";
        cmbCarrera.Size = new Size(230, 25);
        cmbCarrera.TabIndex = 2;
        //
        // lblEdad
        //
        lblEdad.AutoSize = true;
        lblEdad.Location = new Point(14, 135);
        lblEdad.Name = "lblEdad";
        lblEdad.Size = new Size(38, 17);
        lblEdad.Text = "Edad:";
        //
        // txtEdad
        //
        txtEdad.Location = new Point(110, 132);
        txtEdad.MaxLength = 3;
        txtEdad.Name = "txtEdad";
        txtEdad.Size = new Size(80, 25);
        txtEdad.TabIndex = 3;
        //
        // lblIndice
        //
        lblIndice.AutoSize = true;
        lblIndice.Location = new Point(14, 169);
        lblIndice.Name = "lblIndice";
        lblIndice.Size = new Size(90, 17);
        lblIndice.Text = "Índice (0 - 4):";
        //
        // txtIndice
        //
        txtIndice.Location = new Point(110, 166);
        txtIndice.MaxLength = 5;
        txtIndice.Name = "txtIndice";
        txtIndice.PlaceholderText = "3.25";
        txtIndice.Size = new Size(80, 25);
        txtIndice.TabIndex = 4;
        //
        // btnGuardar
        //
        btnGuardar.Location = new Point(14, 206);
        btnGuardar.Name = "btnGuardar";
        btnGuardar.Size = new Size(165, 34);
        btnGuardar.TabIndex = 5;
        btnGuardar.Tag = "exito";
        btnGuardar.Text = "Guardar nuevo";
        btnGuardar.Click += btnGuardar_Click;
        //
        // btnActualizar
        //
        btnActualizar.Location = new Point(185, 206);
        btnActualizar.Name = "btnActualizar";
        btnActualizar.Size = new Size(165, 34);
        btnActualizar.TabIndex = 6;
        btnActualizar.Text = "Actualizar";
        btnActualizar.Click += btnActualizar_Click;
        //
        // btnEliminar
        //
        btnEliminar.Location = new Point(14, 246);
        btnEliminar.Name = "btnEliminar";
        btnEliminar.Size = new Size(165, 34);
        btnEliminar.TabIndex = 7;
        btnEliminar.Tag = "peligro";
        btnEliminar.Text = "Eliminar";
        btnEliminar.Click += btnEliminar_Click;
        //
        // btnLimpiar
        //
        btnLimpiar.Location = new Point(185, 246);
        btnLimpiar.Name = "btnLimpiar";
        btnLimpiar.Size = new Size(165, 34);
        btnLimpiar.TabIndex = 8;
        btnLimpiar.Tag = "secundario";
        btnLimpiar.Text = "Limpiar campos";
        btnLimpiar.Click += btnLimpiar_Click;
        //
        // grpArchivo
        //
        grpArchivo.Controls.Add(btnAbrirCarpeta);
        grpArchivo.Controls.Add(btnRecargar);
        grpArchivo.Controls.Add(lblExiste);
        grpArchivo.Controls.Add(lblRuta);
        grpArchivo.Controls.Add(lblRutaTitulo);
        grpArchivo.Location = new Point(20, 392);
        grpArchivo.Name = "grpArchivo";
        grpArchivo.Size = new Size(370, 172);
        grpArchivo.TabIndex = 2;
        grpArchivo.TabStop = false;
        grpArchivo.Text = "Archivo JSON";
        //
        // lblRutaTitulo
        //
        lblRutaTitulo.AutoSize = true;
        lblRutaTitulo.Location = new Point(14, 28);
        lblRutaTitulo.Name = "lblRutaTitulo";
        lblRutaTitulo.Size = new Size(36, 17);
        lblRutaTitulo.Text = "Ruta:";
        //
        // lblRuta
        //
        lblRuta.Location = new Point(14, 48);
        lblRuta.Name = "lblRuta";
        lblRuta.Size = new Size(340, 44);
        lblRuta.Text = "-";
        //
        // lblExiste
        //
        lblExiste.Location = new Point(14, 94);
        lblExiste.Name = "lblExiste";
        lblExiste.Size = new Size(340, 22);
        lblExiste.Text = "-";
        //
        // btnRecargar
        //
        btnRecargar.Location = new Point(14, 124);
        btnRecargar.Name = "btnRecargar";
        btnRecargar.Size = new Size(165, 34);
        btnRecargar.TabIndex = 0;
        btnRecargar.Text = "Leer archivo";
        btnRecargar.Click += btnRecargar_Click;
        //
        // btnAbrirCarpeta
        //
        btnAbrirCarpeta.Location = new Point(185, 124);
        btnAbrirCarpeta.Name = "btnAbrirCarpeta";
        btnAbrirCarpeta.Size = new Size(165, 34);
        btnAbrirCarpeta.TabIndex = 1;
        btnAbrirCarpeta.Tag = "secundario";
        btnAbrirCarpeta.Text = "Abrir carpeta";
        btnAbrirCarpeta.Click += btnAbrirCarpeta_Click;
        //
        // lblBuscar
        //
        lblBuscar.AutoSize = true;
        lblBuscar.Location = new Point(410, 98);
        lblBuscar.Name = "lblBuscar";
        lblBuscar.Size = new Size(50, 17);
        lblBuscar.TabIndex = 3;
        lblBuscar.Text = "Buscar:";
        //
        // txtBuscar
        //
        txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtBuscar.Location = new Point(468, 95);
        txtBuscar.Name = "txtBuscar";
        txtBuscar.PlaceholderText = "Matrícula, nombre o carrera";
        txtBuscar.Size = new Size(552, 25);
        txtBuscar.TabIndex = 4;
        txtBuscar.TextChanged += txtBuscar_TextChanged;
        //
        // dgvEstudiantes
        //
        dgvEstudiantes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvEstudiantes.Location = new Point(410, 130);
        dgvEstudiantes.Name = "dgvEstudiantes";
        dgvEstudiantes.Size = new Size(610, 434);
        dgvEstudiantes.TabIndex = 5;
        dgvEstudiantes.CellClick += dgvEstudiantes_CellClick;
        //
        // lblConteo
        //
        lblConteo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lblConteo.ForeColor = Color.FromArgb(108, 117, 125);
        lblConteo.Location = new Point(410, 570);
        lblConteo.Name = "lblConteo";
        lblConteo.Size = new Size(610, 22);
        lblConteo.TabIndex = 6;
        lblConteo.Text = "-";
        //
        // lblEstado
        //
        lblEstado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lblEstado.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
        lblEstado.Location = new Point(20, 600);
        lblEstado.Name = "lblEstado";
        lblEstado.Size = new Size(1000, 24);
        lblEstado.TabIndex = 7;
        lblEstado.Text = "Los datos se guardan en disco y se conservan al cerrar la aplicación.";
        //
        // errorProvider
        //
        errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        errorProvider.ContainerControl = this;
        //
        // FrmPersistenciaDatos
        //
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1040, 640);
        Controls.Add(lblEstado);
        Controls.Add(lblConteo);
        Controls.Add(dgvEstudiantes);
        Controls.Add(txtBuscar);
        Controls.Add(lblBuscar);
        Controls.Add(grpArchivo);
        Controls.Add(grpDatos);
        Name = "FrmPersistenciaDatos";
        Text = "Persistencia de datos";
        Load += FrmPersistenciaDatos_Load;
        grpDatos.ResumeLayout(false);
        grpDatos.PerformLayout();
        grpArchivo.ResumeLayout(false);
        grpArchivo.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvEstudiantes).EndInit();
        ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private GroupBox grpDatos;
    private Button btnLimpiar;
    private Button btnEliminar;
    private Button btnActualizar;
    private Button btnGuardar;
    private TextBox txtIndice;
    private Label lblIndice;
    private TextBox txtEdad;
    private Label lblEdad;
    private ComboBox cmbCarrera;
    private Label lblCarrera;
    private TextBox txtNombre;
    private Label lblNombre;
    private TextBox txtMatricula;
    private Label lblMatricula;
    private GroupBox grpArchivo;
    private Button btnAbrirCarpeta;
    private Button btnRecargar;
    private Label lblExiste;
    private Label lblRuta;
    private Label lblRutaTitulo;
    private Label lblBuscar;
    private TextBox txtBuscar;
    private DataGridView dgvEstudiantes;
    private Label lblConteo;
    private Label lblEstado;
    private ErrorProvider errorProvider;
}
