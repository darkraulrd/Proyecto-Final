namespace ProyectoIntegradorPOO.Forms.Unidad5;

partial class FrmSobrecargaOperadores
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
        grpVectorA = new GroupBox();
        nudAy = new NumericUpDown();
        lblAy = new Label();
        nudAx = new NumericUpDown();
        lblAx = new Label();
        grpVectorB = new GroupBox();
        nudBy = new NumericUpDown();
        lblBy = new Label();
        nudBx = new NumericUpDown();
        lblBx = new Label();
        grpOperaciones = new GroupBox();
        btnLimpiar = new Button();
        btnEquals = new Button();
        btnDistinto = new Button();
        btnIgual = new Button();
        btnRestar = new Button();
        btnSumar = new Button();
        lblNota = new Label();
        picPlano = new PictureBox();
        lblResultado = new Label();
        txtResultados = new TextBox();
        grpVectorA.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudAy).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudAx).BeginInit();
        grpVectorB.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudBy).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudBx).BeginInit();
        grpOperaciones.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)picPlano).BeginInit();
        SuspendLayout();
        //
        // grpVectorA
        //
        grpVectorA.Controls.Add(nudAy);
        grpVectorA.Controls.Add(lblAy);
        grpVectorA.Controls.Add(nudAx);
        grpVectorA.Controls.Add(lblAx);
        grpVectorA.Location = new Point(20, 92);
        grpVectorA.Name = "grpVectorA";
        grpVectorA.Size = new Size(300, 72);
        grpVectorA.TabIndex = 1;
        grpVectorA.TabStop = false;
        grpVectorA.Text = "Vector A";
        //
        // lblAx
        //
        lblAx.AutoSize = true;
        lblAx.Location = new Point(14, 33);
        lblAx.Name = "lblAx";
        lblAx.Size = new Size(19, 17);
        lblAx.Text = "X:";
        //
        // nudAx
        //
        nudAx.DecimalPlaces = 2;
        nudAx.Location = new Point(38, 30);
        nudAx.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        nudAx.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
        nudAx.Name = "nudAx";
        nudAx.Size = new Size(100, 25);
        nudAx.TabIndex = 0;
        nudAx.Value = new decimal(new int[] { 3, 0, 0, 0 });
        nudAx.ValueChanged += nudVector_ValueChanged;
        //
        // lblAy
        //
        lblAy.AutoSize = true;
        lblAy.Location = new Point(156, 33);
        lblAy.Name = "lblAy";
        lblAy.Size = new Size(18, 17);
        lblAy.Text = "Y:";
        //
        // nudAy
        //
        nudAy.DecimalPlaces = 2;
        nudAy.Location = new Point(180, 30);
        nudAy.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        nudAy.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
        nudAy.Name = "nudAy";
        nudAy.Size = new Size(100, 25);
        nudAy.TabIndex = 1;
        nudAy.Value = new decimal(new int[] { 4, 0, 0, 0 });
        nudAy.ValueChanged += nudVector_ValueChanged;
        //
        // grpVectorB
        //
        grpVectorB.Controls.Add(nudBy);
        grpVectorB.Controls.Add(lblBy);
        grpVectorB.Controls.Add(nudBx);
        grpVectorB.Controls.Add(lblBx);
        grpVectorB.Location = new Point(20, 172);
        grpVectorB.Name = "grpVectorB";
        grpVectorB.Size = new Size(300, 72);
        grpVectorB.TabIndex = 2;
        grpVectorB.TabStop = false;
        grpVectorB.Text = "Vector B";
        //
        // lblBx
        //
        lblBx.AutoSize = true;
        lblBx.Location = new Point(14, 33);
        lblBx.Name = "lblBx";
        lblBx.Size = new Size(19, 17);
        lblBx.Text = "X:";
        //
        // nudBx
        //
        nudBx.DecimalPlaces = 2;
        nudBx.Location = new Point(38, 30);
        nudBx.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        nudBx.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
        nudBx.Name = "nudBx";
        nudBx.Size = new Size(100, 25);
        nudBx.TabIndex = 0;
        nudBx.Value = new decimal(new int[] { 2, 0, 0, int.MinValue });
        nudBx.ValueChanged += nudVector_ValueChanged;
        //
        // lblBy
        //
        lblBy.AutoSize = true;
        lblBy.Location = new Point(156, 33);
        lblBy.Name = "lblBy";
        lblBy.Size = new Size(18, 17);
        lblBy.Text = "Y:";
        //
        // nudBy
        //
        nudBy.DecimalPlaces = 2;
        nudBy.Location = new Point(180, 30);
        nudBy.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        nudBy.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
        nudBy.Name = "nudBy";
        nudBy.Size = new Size(100, 25);
        nudBy.TabIndex = 1;
        nudBy.Value = new decimal(new int[] { 1, 0, 0, 0 });
        nudBy.ValueChanged += nudVector_ValueChanged;
        //
        // grpOperaciones
        //
        grpOperaciones.Controls.Add(btnLimpiar);
        grpOperaciones.Controls.Add(btnEquals);
        grpOperaciones.Controls.Add(btnDistinto);
        grpOperaciones.Controls.Add(btnIgual);
        grpOperaciones.Controls.Add(btnRestar);
        grpOperaciones.Controls.Add(btnSumar);
        grpOperaciones.Location = new Point(20, 252);
        grpOperaciones.Name = "grpOperaciones";
        grpOperaciones.Size = new Size(300, 210);
        grpOperaciones.TabIndex = 3;
        grpOperaciones.TabStop = false;
        grpOperaciones.Text = "Operadores sobrecargados";
        //
        // btnSumar
        //
        btnSumar.Location = new Point(14, 30);
        btnSumar.Name = "btnSumar";
        btnSumar.Size = new Size(132, 38);
        btnSumar.TabIndex = 0;
        btnSumar.Text = "A + B";
        btnSumar.Click += btnSumar_Click;
        //
        // btnRestar
        //
        btnRestar.Location = new Point(154, 30);
        btnRestar.Name = "btnRestar";
        btnRestar.Size = new Size(132, 38);
        btnRestar.TabIndex = 1;
        btnRestar.Text = "A − B";
        btnRestar.Click += btnRestar_Click;
        //
        // btnIgual
        //
        btnIgual.Location = new Point(14, 76);
        btnIgual.Name = "btnIgual";
        btnIgual.Size = new Size(132, 38);
        btnIgual.TabIndex = 2;
        btnIgual.Tag = "exito";
        btnIgual.Text = "A == B";
        btnIgual.Click += btnIgual_Click;
        //
        // btnDistinto
        //
        btnDistinto.Location = new Point(154, 76);
        btnDistinto.Name = "btnDistinto";
        btnDistinto.Size = new Size(132, 38);
        btnDistinto.TabIndex = 3;
        btnDistinto.Tag = "exito";
        btnDistinto.Text = "A != B";
        btnDistinto.Click += btnDistinto_Click;
        //
        // btnEquals
        //
        btnEquals.Location = new Point(14, 122);
        btnEquals.Name = "btnEquals";
        btnEquals.Size = new Size(272, 38);
        btnEquals.TabIndex = 4;
        btnEquals.Text = "A.Equals(B) y GetHashCode()";
        btnEquals.Click += btnEquals_Click;
        //
        // btnLimpiar
        //
        btnLimpiar.Location = new Point(14, 166);
        btnLimpiar.Name = "btnLimpiar";
        btnLimpiar.Size = new Size(272, 32);
        btnLimpiar.TabIndex = 5;
        btnLimpiar.Tag = "secundario";
        btnLimpiar.Text = "Limpiar";
        btnLimpiar.Click += btnLimpiar_Click;
        //
        // lblNota
        //
        lblNota.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        lblNota.ForeColor = Color.FromArgb(108, 117, 125);
        lblNota.Location = new Point(20, 470);
        lblNota.Name = "lblNota";
        lblNota.Size = new Size(300, 154);
        lblNota.TabIndex = 4;
        lblNota.Text = "+ y − operan componente a componente y devuelven un vector NUEVO (Vector2D es inmutable). Al sobrecargar == C# exige también !=; Equals() y GetHashCode() se redefinen para que dos vectores con los mismos valores sean iguales también en HashSet y Dictionary.";
        //
        // picPlano
        //
        picPlano.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        picPlano.BackColor = Color.White;
        picPlano.BorderStyle = BorderStyle.FixedSingle;
        picPlano.Location = new Point(340, 92);
        picPlano.Name = "picPlano";
        picPlano.Size = new Size(680, 370);
        picPlano.TabIndex = 5;
        picPlano.TabStop = false;
        picPlano.Paint += picPlano_Paint;
        picPlano.Resize += picPlano_Resize;
        //
        // lblResultado
        //
        lblResultado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lblResultado.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblResultado.ForeColor = Color.FromArgb(211, 84, 0);
        lblResultado.Location = new Point(340, 468);
        lblResultado.Name = "lblResultado";
        lblResultado.Size = new Size(680, 26);
        lblResultado.TabIndex = 6;
        lblResultado.Text = "Elija una operación.";
        //
        // txtResultados
        //
        txtResultados.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        txtResultados.BackColor = Color.FromArgb(30, 30, 30);
        txtResultados.Font = new Font("Consolas", 9.5F);
        txtResultados.ForeColor = Color.FromArgb(220, 220, 220);
        txtResultados.Location = new Point(340, 498);
        txtResultados.Multiline = true;
        txtResultados.Name = "txtResultados";
        txtResultados.ReadOnly = true;
        txtResultados.ScrollBars = ScrollBars.Both;
        txtResultados.Size = new Size(680, 126);
        txtResultados.TabIndex = 7;
        txtResultados.WordWrap = false;
        //
        // FrmSobrecargaOperadores
        //
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1040, 640);
        Controls.Add(txtResultados);
        Controls.Add(lblResultado);
        Controls.Add(picPlano);
        Controls.Add(lblNota);
        Controls.Add(grpOperaciones);
        Controls.Add(grpVectorB);
        Controls.Add(grpVectorA);
        Name = "FrmSobrecargaOperadores";
        Text = "Sobrecarga de operadores";
        grpVectorA.ResumeLayout(false);
        grpVectorA.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudAy).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudAx).EndInit();
        grpVectorB.ResumeLayout(false);
        grpVectorB.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudBy).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudBx).EndInit();
        grpOperaciones.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)picPlano).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private GroupBox grpVectorA;
    private NumericUpDown nudAy;
    private Label lblAy;
    private NumericUpDown nudAx;
    private Label lblAx;
    private GroupBox grpVectorB;
    private NumericUpDown nudBy;
    private Label lblBy;
    private NumericUpDown nudBx;
    private Label lblBx;
    private GroupBox grpOperaciones;
    private Button btnLimpiar;
    private Button btnEquals;
    private Button btnDistinto;
    private Button btnIgual;
    private Button btnRestar;
    private Button btnSumar;
    private Label lblNota;
    private PictureBox picPlano;
    private Label lblResultado;
    private TextBox txtResultados;
}
