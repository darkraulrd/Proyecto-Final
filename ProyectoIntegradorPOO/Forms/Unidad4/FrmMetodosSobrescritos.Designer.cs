namespace ProyectoIntegradorPOO.Forms.Unidad4;

partial class FrmMetodosSobrescritos
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
        grpPersona = new GroupBox();
        btnAsignar = new Button();
        rbProfesor = new RadioButton();
        rbEstudiante = new RadioButton();
        rbPersona = new RadioButton();
        nudEdad = new NumericUpDown();
        lblEdad = new Label();
        txtNombre = new TextBox();
        lblNombre = new Label();
        grpPreguntas = new GroupBox();
        txtPreguntas = new TextBox();
        dgvPersonas = new DataGridView();
        txtSalida = new TextBox();
        btnRecorrer = new Button();
        btnLimpiar = new Button();
        grpPersona.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudEdad).BeginInit();
        grpPreguntas.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvPersonas).BeginInit();
        SuspendLayout();
        //
        // grpPersona
        //
        grpPersona.Controls.Add(btnAsignar);
        grpPersona.Controls.Add(rbProfesor);
        grpPersona.Controls.Add(rbEstudiante);
        grpPersona.Controls.Add(rbPersona);
        grpPersona.Controls.Add(nudEdad);
        grpPersona.Controls.Add(lblEdad);
        grpPersona.Controls.Add(txtNombre);
        grpPersona.Controls.Add(lblNombre);
        grpPersona.Location = new Point(20, 92);
        grpPersona.Name = "grpPersona";
        grpPersona.Size = new Size(380, 230);
        grpPersona.TabIndex = 1;
        grpPersona.TabStop = false;
        grpPersona.Text = "Persona persona = new ...";
        //
        // lblNombre
        //
        lblNombre.AutoSize = true;
        lblNombre.Location = new Point(16, 33);
        lblNombre.Name = "lblNombre";
        lblNombre.Size = new Size(59, 17);
        lblNombre.Text = "Nombre:";
        //
        // txtNombre
        //
        txtNombre.Location = new Point(100, 30);
        txtNombre.MaxLength = 60;
        txtNombre.Name = "txtNombre";
        txtNombre.Size = new Size(260, 25);
        txtNombre.TabIndex = 0;
        //
        // lblEdad
        //
        lblEdad.AutoSize = true;
        lblEdad.Location = new Point(16, 67);
        lblEdad.Name = "lblEdad";
        lblEdad.Size = new Size(38, 17);
        lblEdad.Text = "Edad:";
        //
        // nudEdad
        //
        nudEdad.Location = new Point(100, 64);
        nudEdad.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
        nudEdad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudEdad.Name = "nudEdad";
        nudEdad.Size = new Size(80, 25);
        nudEdad.TabIndex = 1;
        nudEdad.Value = new decimal(new int[] { 20, 0, 0, 0 });
        //
        // rbPersona
        //
        rbPersona.AutoSize = true;
        rbPersona.Location = new Point(100, 100);
        rbPersona.Name = "rbPersona";
        rbPersona.Size = new Size(180, 21);
        rbPersona.TabIndex = 2;
        rbPersona.Text = "Persona (método virtual)";
        //
        // rbEstudiante
        //
        rbEstudiante.AutoSize = true;
        rbEstudiante.Checked = true;
        rbEstudiante.Location = new Point(100, 124);
        rbEstudiante.Name = "rbEstudiante";
        rbEstudiante.Size = new Size(180, 21);
        rbEstudiante.TabIndex = 3;
        rbEstudiante.TabStop = true;
        rbEstudiante.Text = "Estudiante (override)";
        //
        // rbProfesor
        //
        rbProfesor.AutoSize = true;
        rbProfesor.Location = new Point(100, 148);
        rbProfesor.Name = "rbProfesor";
        rbProfesor.Size = new Size(180, 21);
        rbProfesor.TabIndex = 4;
        rbProfesor.Text = "Profesor (override)";
        //
        // btnAsignar
        //
        btnAsignar.Location = new Point(100, 180);
        btnAsignar.Name = "btnAsignar";
        btnAsignar.Size = new Size(260, 36);
        btnAsignar.TabIndex = 5;
        btnAsignar.Tag = "exito";
        btnAsignar.Text = "Crear y llamar MostrarRol()";
        btnAsignar.Click += btnAsignar_Click;
        //
        // grpPreguntas
        //
        grpPreguntas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        grpPreguntas.Controls.Add(txtPreguntas);
        grpPreguntas.Location = new Point(20, 330);
        grpPreguntas.Name = "grpPreguntas";
        grpPreguntas.Padding = new Padding(10);
        grpPreguntas.Size = new Size(380, 294);
        grpPreguntas.TabIndex = 2;
        grpPreguntas.TabStop = false;
        grpPreguntas.Text = "Preguntas del laboratorio";
        //
        // txtPreguntas
        //
        txtPreguntas.BackColor = Color.White;
        txtPreguntas.BorderStyle = BorderStyle.None;
        txtPreguntas.Dock = DockStyle.Fill;
        txtPreguntas.Multiline = true;
        txtPreguntas.Name = "txtPreguntas";
        txtPreguntas.ReadOnly = true;
        txtPreguntas.ScrollBars = ScrollBars.Vertical;
        txtPreguntas.TabIndex = 0;
        //
        // dgvPersonas
        //
        dgvPersonas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        dgvPersonas.Location = new Point(420, 92);
        dgvPersonas.Name = "dgvPersonas";
        dgvPersonas.Size = new Size(600, 230);
        dgvPersonas.TabIndex = 3;
        //
        // txtSalida
        //
        txtSalida.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        txtSalida.BackColor = Color.FromArgb(30, 30, 30);
        txtSalida.Font = new Font("Consolas", 10F);
        txtSalida.ForeColor = Color.FromArgb(220, 220, 220);
        txtSalida.Location = new Point(420, 336);
        txtSalida.Multiline = true;
        txtSalida.Name = "txtSalida";
        txtSalida.ReadOnly = true;
        txtSalida.ScrollBars = ScrollBars.Both;
        txtSalida.Size = new Size(600, 240);
        txtSalida.TabIndex = 4;
        txtSalida.WordWrap = false;
        //
        // btnRecorrer
        //
        btnRecorrer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnRecorrer.Location = new Point(420, 586);
        btnRecorrer.Name = "btnRecorrer";
        btnRecorrer.Size = new Size(340, 36);
        btnRecorrer.TabIndex = 5;
        btnRecorrer.Text = "Recorrer List<Persona> y llamar MostrarRol()";
        btnRecorrer.Click += btnRecorrer_Click;
        //
        // btnLimpiar
        //
        btnLimpiar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnLimpiar.Location = new Point(900, 586);
        btnLimpiar.Name = "btnLimpiar";
        btnLimpiar.Size = new Size(120, 36);
        btnLimpiar.TabIndex = 6;
        btnLimpiar.Tag = "secundario";
        btnLimpiar.Text = "Limpiar";
        btnLimpiar.Click += btnLimpiar_Click;
        //
        // FrmMetodosSobrescritos
        //
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1040, 640);
        Controls.Add(btnLimpiar);
        Controls.Add(btnRecorrer);
        Controls.Add(txtSalida);
        Controls.Add(dgvPersonas);
        Controls.Add(grpPreguntas);
        Controls.Add(grpPersona);
        Name = "FrmMetodosSobrescritos";
        Text = "Métodos sobrescritos";
        grpPersona.ResumeLayout(false);
        grpPersona.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudEdad).EndInit();
        grpPreguntas.ResumeLayout(false);
        grpPreguntas.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvPersonas).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private GroupBox grpPersona;
    private Button btnAsignar;
    private RadioButton rbProfesor;
    private RadioButton rbEstudiante;
    private RadioButton rbPersona;
    private NumericUpDown nudEdad;
    private Label lblEdad;
    private TextBox txtNombre;
    private Label lblNombre;
    private GroupBox grpPreguntas;
    private TextBox txtPreguntas;
    private DataGridView dgvPersonas;
    private TextBox txtSalida;
    private Button btnRecorrer;
    private Button btnLimpiar;
}
