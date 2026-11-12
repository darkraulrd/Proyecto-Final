namespace ProyectoIntegradorPOO.Forms.Unidad3;

partial class FrmRelacionesClases
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
        grpEstudiante = new GroupBox();
        btnRegistrarEstudiante = new Button();
        nudEdad = new NumericUpDown();
        lblEdad = new Label();
        txtMatricula = new TextBox();
        lblMatricula = new Label();
        txtNombreEstudiante = new TextBox();
        lblNombreEstudiante = new Label();
        grpProfesor = new GroupBox();
        btnRegistrarProfesor = new Button();
        txtEspecialidad = new TextBox();
        lblEspecialidad = new Label();
        txtNombreProfesor = new TextBox();
        lblNombreProfesor = new Label();
        grpCurso = new GroupBox();
        btnCrearCurso = new Button();
        cmbProfesor = new ComboBox();
        lblProfesor = new Label();
        nudCreditos = new NumericUpDown();
        lblCreditos = new Label();
        txtNombreCurso = new TextBox();
        lblNombreCurso = new Label();
        txtCodigoCurso = new TextBox();
        lblCodigoCurso = new Label();
        grpInscripcion = new GroupBox();
        btnEliminarCurso = new Button();
        btnRetirar = new Button();
        btnInscribir = new Button();
        cmbEstudiante = new ComboBox();
        lblEstudiante = new Label();
        cmbCurso = new ComboBox();
        lblCurso = new Label();
        tabRelaciones = new TabControl();
        tabEstudiantes = new TabPage();
        dgvEstudiantes = new DataGridView();
        tabCursos = new TabPage();
        dgvCursos = new DataGridView();
        tabInscritos = new TabPage();
        dgvInscritos = new DataGridView();
        tabMapa = new TabPage();
        tvRelaciones = new TreeView();
        lblResumen = new Label();
        grpEstudiante.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudEdad).BeginInit();
        grpProfesor.SuspendLayout();
        grpCurso.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudCreditos).BeginInit();
        grpInscripcion.SuspendLayout();
        tabRelaciones.SuspendLayout();
        tabEstudiantes.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvEstudiantes).BeginInit();
        tabCursos.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvCursos).BeginInit();
        tabInscritos.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvInscritos).BeginInit();
        tabMapa.SuspendLayout();
        SuspendLayout();
        //
        // grpEstudiante
        //
        grpEstudiante.Controls.Add(btnRegistrarEstudiante);
        grpEstudiante.Controls.Add(nudEdad);
        grpEstudiante.Controls.Add(lblEdad);
        grpEstudiante.Controls.Add(txtMatricula);
        grpEstudiante.Controls.Add(lblMatricula);
        grpEstudiante.Controls.Add(txtNombreEstudiante);
        grpEstudiante.Controls.Add(lblNombreEstudiante);
        grpEstudiante.Location = new Point(20, 92);
        grpEstudiante.Name = "grpEstudiante";
        grpEstudiante.Size = new Size(320, 200);
        grpEstudiante.TabIndex = 1;
        grpEstudiante.TabStop = false;
        grpEstudiante.Text = "1. Registrar estudiante";
        //
        // lblNombreEstudiante
        //
        lblNombreEstudiante.AutoSize = true;
        lblNombreEstudiante.Location = new Point(14, 33);
        lblNombreEstudiante.Name = "lblNombreEstudiante";
        lblNombreEstudiante.Size = new Size(59, 17);
        lblNombreEstudiante.Text = "Nombre:";
        //
        // txtNombreEstudiante
        //
        txtNombreEstudiante.Location = new Point(110, 30);
        txtNombreEstudiante.MaxLength = 80;
        txtNombreEstudiante.Name = "txtNombreEstudiante";
        txtNombreEstudiante.Size = new Size(195, 25);
        txtNombreEstudiante.TabIndex = 0;
        //
        // lblMatricula
        //
        lblMatricula.AutoSize = true;
        lblMatricula.Location = new Point(14, 65);
        lblMatricula.Name = "lblMatricula";
        lblMatricula.Size = new Size(65, 17);
        lblMatricula.Text = "Matrícula:";
        //
        // txtMatricula
        //
        txtMatricula.Location = new Point(110, 62);
        txtMatricula.MaxLength = 15;
        txtMatricula.Name = "txtMatricula";
        txtMatricula.Size = new Size(195, 25);
        txtMatricula.TabIndex = 1;
        //
        // lblEdad
        //
        lblEdad.AutoSize = true;
        lblEdad.Location = new Point(14, 97);
        lblEdad.Name = "lblEdad";
        lblEdad.Size = new Size(38, 17);
        lblEdad.Text = "Edad:";
        //
        // nudEdad
        //
        nudEdad.Location = new Point(110, 94);
        nudEdad.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
        nudEdad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudEdad.Name = "nudEdad";
        nudEdad.Size = new Size(80, 25);
        nudEdad.TabIndex = 2;
        nudEdad.Value = new decimal(new int[] { 18, 0, 0, 0 });
        //
        // btnRegistrarEstudiante
        //
        btnRegistrarEstudiante.Location = new Point(110, 140);
        btnRegistrarEstudiante.Name = "btnRegistrarEstudiante";
        btnRegistrarEstudiante.Size = new Size(195, 34);
        btnRegistrarEstudiante.TabIndex = 3;
        btnRegistrarEstudiante.Tag = "exito";
        btnRegistrarEstudiante.Text = "Registrar estudiante";
        btnRegistrarEstudiante.Click += btnRegistrarEstudiante_Click;
        //
        // grpProfesor
        //
        grpProfesor.Controls.Add(btnRegistrarProfesor);
        grpProfesor.Controls.Add(txtEspecialidad);
        grpProfesor.Controls.Add(lblEspecialidad);
        grpProfesor.Controls.Add(txtNombreProfesor);
        grpProfesor.Controls.Add(lblNombreProfesor);
        grpProfesor.Location = new Point(360, 92);
        grpProfesor.Name = "grpProfesor";
        grpProfesor.Size = new Size(320, 200);
        grpProfesor.TabIndex = 2;
        grpProfesor.TabStop = false;
        grpProfesor.Text = "2. Registrar profesor";
        //
        // lblNombreProfesor
        //
        lblNombreProfesor.AutoSize = true;
        lblNombreProfesor.Location = new Point(14, 33);
        lblNombreProfesor.Name = "lblNombreProfesor";
        lblNombreProfesor.Size = new Size(59, 17);
        lblNombreProfesor.Text = "Nombre:";
        //
        // txtNombreProfesor
        //
        txtNombreProfesor.Location = new Point(110, 30);
        txtNombreProfesor.MaxLength = 80;
        txtNombreProfesor.Name = "txtNombreProfesor";
        txtNombreProfesor.Size = new Size(195, 25);
        txtNombreProfesor.TabIndex = 0;
        //
        // lblEspecialidad
        //
        lblEspecialidad.AutoSize = true;
        lblEspecialidad.Location = new Point(14, 65);
        lblEspecialidad.Name = "lblEspecialidad";
        lblEspecialidad.Size = new Size(83, 17);
        lblEspecialidad.Text = "Especialidad:";
        //
        // txtEspecialidad
        //
        txtEspecialidad.Location = new Point(110, 62);
        txtEspecialidad.MaxLength = 60;
        txtEspecialidad.Name = "txtEspecialidad";
        txtEspecialidad.Size = new Size(195, 25);
        txtEspecialidad.TabIndex = 1;
        //
        // btnRegistrarProfesor
        //
        btnRegistrarProfesor.Location = new Point(110, 140);
        btnRegistrarProfesor.Name = "btnRegistrarProfesor";
        btnRegistrarProfesor.Size = new Size(195, 34);
        btnRegistrarProfesor.TabIndex = 2;
        btnRegistrarProfesor.Tag = "exito";
        btnRegistrarProfesor.Text = "Registrar profesor";
        btnRegistrarProfesor.Click += btnRegistrarProfesor_Click;
        //
        // grpCurso
        //
        grpCurso.Controls.Add(btnCrearCurso);
        grpCurso.Controls.Add(cmbProfesor);
        grpCurso.Controls.Add(lblProfesor);
        grpCurso.Controls.Add(nudCreditos);
        grpCurso.Controls.Add(lblCreditos);
        grpCurso.Controls.Add(txtNombreCurso);
        grpCurso.Controls.Add(lblNombreCurso);
        grpCurso.Controls.Add(txtCodigoCurso);
        grpCurso.Controls.Add(lblCodigoCurso);
        grpCurso.Location = new Point(700, 92);
        grpCurso.Name = "grpCurso";
        grpCurso.Size = new Size(320, 200);
        grpCurso.TabIndex = 3;
        grpCurso.TabStop = false;
        grpCurso.Text = "3. Crear curso (departamento)";
        //
        // lblCodigoCurso
        //
        lblCodigoCurso.AutoSize = true;
        lblCodigoCurso.Location = new Point(14, 33);
        lblCodigoCurso.Name = "lblCodigoCurso";
        lblCodigoCurso.Size = new Size(52, 17);
        lblCodigoCurso.Text = "Código:";
        //
        // txtCodigoCurso
        //
        txtCodigoCurso.CharacterCasing = CharacterCasing.Upper;
        txtCodigoCurso.Location = new Point(110, 30);
        txtCodigoCurso.MaxLength = 10;
        txtCodigoCurso.Name = "txtCodigoCurso";
        txtCodigoCurso.PlaceholderText = "INF-5130";
        txtCodigoCurso.Size = new Size(195, 25);
        txtCodigoCurso.TabIndex = 0;
        //
        // lblNombreCurso
        //
        lblNombreCurso.AutoSize = true;
        lblNombreCurso.Location = new Point(14, 65);
        lblNombreCurso.Name = "lblNombreCurso";
        lblNombreCurso.Size = new Size(59, 17);
        lblNombreCurso.Text = "Nombre:";
        //
        // txtNombreCurso
        //
        txtNombreCurso.Location = new Point(110, 62);
        txtNombreCurso.MaxLength = 80;
        txtNombreCurso.Name = "txtNombreCurso";
        txtNombreCurso.Size = new Size(195, 25);
        txtNombreCurso.TabIndex = 1;
        //
        // lblCreditos
        //
        lblCreditos.AutoSize = true;
        lblCreditos.Location = new Point(14, 97);
        lblCreditos.Name = "lblCreditos";
        lblCreditos.Size = new Size(59, 17);
        lblCreditos.Text = "Créditos:";
        //
        // nudCreditos
        //
        nudCreditos.Location = new Point(110, 94);
        nudCreditos.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
        nudCreditos.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudCreditos.Name = "nudCreditos";
        nudCreditos.Size = new Size(80, 25);
        nudCreditos.TabIndex = 2;
        nudCreditos.Value = new decimal(new int[] { 4, 0, 0, 0 });
        //
        // lblProfesor
        //
        lblProfesor.AutoSize = true;
        lblProfesor.Location = new Point(14, 129);
        lblProfesor.Name = "lblProfesor";
        lblProfesor.Size = new Size(60, 17);
        lblProfesor.Text = "Profesor:";
        //
        // cmbProfesor
        //
        cmbProfesor.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbProfesor.Location = new Point(110, 126);
        cmbProfesor.Name = "cmbProfesor";
        cmbProfesor.Size = new Size(195, 25);
        cmbProfesor.TabIndex = 3;
        //
        // btnCrearCurso
        //
        btnCrearCurso.Location = new Point(110, 158);
        btnCrearCurso.Name = "btnCrearCurso";
        btnCrearCurso.Size = new Size(195, 34);
        btnCrearCurso.TabIndex = 4;
        btnCrearCurso.Tag = "exito";
        btnCrearCurso.Text = "Crear curso";
        btnCrearCurso.Click += btnCrearCurso_Click;
        //
        // grpInscripcion
        //
        grpInscripcion.Controls.Add(btnEliminarCurso);
        grpInscripcion.Controls.Add(btnRetirar);
        grpInscripcion.Controls.Add(btnInscribir);
        grpInscripcion.Controls.Add(cmbEstudiante);
        grpInscripcion.Controls.Add(lblEstudiante);
        grpInscripcion.Controls.Add(cmbCurso);
        grpInscripcion.Controls.Add(lblCurso);
        grpInscripcion.Location = new Point(20, 300);
        grpInscripcion.Name = "grpInscripcion";
        grpInscripcion.Size = new Size(1000, 70);
        grpInscripcion.TabIndex = 4;
        grpInscripcion.TabStop = false;
        grpInscripcion.Text = "4. Asignar estudiantes a cursos";
        //
        // lblCurso
        //
        lblCurso.AutoSize = true;
        lblCurso.Location = new Point(14, 32);
        lblCurso.Name = "lblCurso";
        lblCurso.Size = new Size(44, 17);
        lblCurso.Text = "Curso:";
        //
        // cmbCurso
        //
        cmbCurso.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbCurso.Location = new Point(66, 29);
        cmbCurso.Name = "cmbCurso";
        cmbCurso.Size = new Size(220, 25);
        cmbCurso.TabIndex = 0;
        cmbCurso.SelectedIndexChanged += cmbCurso_SelectedIndexChanged;
        //
        // lblEstudiante
        //
        lblEstudiante.AutoSize = true;
        lblEstudiante.Location = new Point(300, 32);
        lblEstudiante.Name = "lblEstudiante";
        lblEstudiante.Size = new Size(71, 17);
        lblEstudiante.Text = "Estudiante:";
        //
        // cmbEstudiante
        //
        cmbEstudiante.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbEstudiante.Location = new Point(378, 29);
        cmbEstudiante.Name = "cmbEstudiante";
        cmbEstudiante.Size = new Size(220, 25);
        cmbEstudiante.TabIndex = 1;
        //
        // btnInscribir
        //
        btnInscribir.Location = new Point(612, 25);
        btnInscribir.Name = "btnInscribir";
        btnInscribir.Size = new Size(120, 32);
        btnInscribir.TabIndex = 2;
        btnInscribir.Tag = "exito";
        btnInscribir.Text = "Inscribir";
        btnInscribir.Click += btnInscribir_Click;
        //
        // btnRetirar
        //
        btnRetirar.Location = new Point(740, 25);
        btnRetirar.Name = "btnRetirar";
        btnRetirar.Size = new Size(120, 32);
        btnRetirar.TabIndex = 3;
        btnRetirar.Tag = "secundario";
        btnRetirar.Text = "Retirar";
        btnRetirar.Click += btnRetirar_Click;
        //
        // btnEliminarCurso
        //
        btnEliminarCurso.Location = new Point(868, 25);
        btnEliminarCurso.Name = "btnEliminarCurso";
        btnEliminarCurso.Size = new Size(120, 32);
        btnEliminarCurso.TabIndex = 4;
        btnEliminarCurso.Tag = "peligro";
        btnEliminarCurso.Text = "Eliminar curso";
        btnEliminarCurso.Click += btnEliminarCurso_Click;
        //
        // tabRelaciones
        //
        tabRelaciones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        tabRelaciones.Controls.Add(tabEstudiantes);
        tabRelaciones.Controls.Add(tabCursos);
        tabRelaciones.Controls.Add(tabInscritos);
        tabRelaciones.Controls.Add(tabMapa);
        tabRelaciones.Location = new Point(20, 380);
        tabRelaciones.Name = "tabRelaciones";
        tabRelaciones.SelectedIndex = 0;
        tabRelaciones.Size = new Size(1000, 222);
        tabRelaciones.TabIndex = 5;
        //
        // tabEstudiantes
        //
        tabEstudiantes.Controls.Add(dgvEstudiantes);
        tabEstudiantes.Name = "tabEstudiantes";
        tabEstudiantes.Padding = new Padding(4);
        tabEstudiantes.Text = "Estudiantes registrados (List<Estudiante>)";
        tabEstudiantes.UseVisualStyleBackColor = true;
        //
        // dgvEstudiantes
        //
        dgvEstudiantes.Dock = DockStyle.Fill;
        dgvEstudiantes.Name = "dgvEstudiantes";
        dgvEstudiantes.TabIndex = 0;
        //
        // tabCursos
        //
        tabCursos.Controls.Add(dgvCursos);
        tabCursos.Name = "tabCursos";
        tabCursos.Padding = new Padding(4);
        tabCursos.Text = "Cursos del departamento (composición)";
        tabCursos.UseVisualStyleBackColor = true;
        //
        // dgvCursos
        //
        dgvCursos.Dock = DockStyle.Fill;
        dgvCursos.Name = "dgvCursos";
        dgvCursos.TabIndex = 0;
        //
        // tabInscritos
        //
        tabInscritos.Controls.Add(dgvInscritos);
        tabInscritos.Name = "tabInscritos";
        tabInscritos.Padding = new Padding(4);
        tabInscritos.Text = "Inscritos por curso (agregación)";
        tabInscritos.UseVisualStyleBackColor = true;
        //
        // dgvInscritos
        //
        dgvInscritos.Dock = DockStyle.Fill;
        dgvInscritos.Name = "dgvInscritos";
        dgvInscritos.TabIndex = 0;
        //
        // tabMapa
        //
        tabMapa.Controls.Add(tvRelaciones);
        tabMapa.Name = "tabMapa";
        tabMapa.Padding = new Padding(4);
        tabMapa.Text = "Mapa de objetos y relaciones";
        tabMapa.UseVisualStyleBackColor = true;
        //
        // tvRelaciones
        //
        tvRelaciones.Dock = DockStyle.Fill;
        tvRelaciones.Font = new Font("Segoe UI", 9.75F);
        tvRelaciones.Name = "tvRelaciones";
        tvRelaciones.TabIndex = 0;
        //
        // lblResumen
        //
        lblResumen.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lblResumen.ForeColor = Color.FromArgb(108, 117, 125);
        lblResumen.Location = new Point(20, 608);
        lblResumen.Name = "lblResumen";
        lblResumen.Size = new Size(1000, 22);
        lblResumen.TabIndex = 6;
        lblResumen.Text = "Resumen";
        //
        // FrmRelacionesClases
        //
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1040, 640);
        Controls.Add(lblResumen);
        Controls.Add(tabRelaciones);
        Controls.Add(grpInscripcion);
        Controls.Add(grpCurso);
        Controls.Add(grpProfesor);
        Controls.Add(grpEstudiante);
        Name = "FrmRelacionesClases";
        Text = "Relaciones entre clases";
        Load += FrmRelacionesClases_Load;
        grpEstudiante.ResumeLayout(false);
        grpEstudiante.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudEdad).EndInit();
        grpProfesor.ResumeLayout(false);
        grpProfesor.PerformLayout();
        grpCurso.ResumeLayout(false);
        grpCurso.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudCreditos).EndInit();
        grpInscripcion.ResumeLayout(false);
        grpInscripcion.PerformLayout();
        tabEstudiantes.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvEstudiantes).EndInit();
        tabCursos.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvCursos).EndInit();
        tabInscritos.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvInscritos).EndInit();
        tabMapa.ResumeLayout(false);
        tabRelaciones.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private GroupBox grpEstudiante;
    private Button btnRegistrarEstudiante;
    private NumericUpDown nudEdad;
    private Label lblEdad;
    private TextBox txtMatricula;
    private Label lblMatricula;
    private TextBox txtNombreEstudiante;
    private Label lblNombreEstudiante;
    private GroupBox grpProfesor;
    private Button btnRegistrarProfesor;
    private TextBox txtEspecialidad;
    private Label lblEspecialidad;
    private TextBox txtNombreProfesor;
    private Label lblNombreProfesor;
    private GroupBox grpCurso;
    private Button btnCrearCurso;
    private ComboBox cmbProfesor;
    private Label lblProfesor;
    private NumericUpDown nudCreditos;
    private Label lblCreditos;
    private TextBox txtNombreCurso;
    private Label lblNombreCurso;
    private TextBox txtCodigoCurso;
    private Label lblCodigoCurso;
    private GroupBox grpInscripcion;
    private Button btnEliminarCurso;
    private Button btnRetirar;
    private Button btnInscribir;
    private ComboBox cmbEstudiante;
    private Label lblEstudiante;
    private ComboBox cmbCurso;
    private Label lblCurso;
    private TabControl tabRelaciones;
    private TabPage tabEstudiantes;
    private DataGridView dgvEstudiantes;
    private TabPage tabCursos;
    private DataGridView dgvCursos;
    private TabPage tabInscritos;
    private DataGridView dgvInscritos;
    private TabPage tabMapa;
    private TreeView tvRelaciones;
    private Label lblResumen;
}
