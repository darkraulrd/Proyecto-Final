namespace ProyectoIntegradorPOO.Forms.Unidad4;

partial class FrmClasesAbstractas
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
        grpFigura = new GroupBox();
        btnLimpiar = new Button();
        btnCrearFigura = new Button();
        nudDato2 = new NumericUpDown();
        lblDato2 = new Label();
        nudDato1 = new NumericUpDown();
        lblDato1 = new Label();
        rbCirculo = new RadioButton();
        rbRectangulo = new RadioButton();
        lstFiguras = new ListBox();
        lblLista = new Label();
        picDibujo = new PictureBox();
        lblResultado = new Label();
        txtPreguntas = new TextBox();
        grpFigura.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudDato2).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudDato1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)picDibujo).BeginInit();
        SuspendLayout();
        //
        // grpFigura
        //
        grpFigura.Controls.Add(btnLimpiar);
        grpFigura.Controls.Add(btnCrearFigura);
        grpFigura.Controls.Add(nudDato2);
        grpFigura.Controls.Add(lblDato2);
        grpFigura.Controls.Add(nudDato1);
        grpFigura.Controls.Add(lblDato1);
        grpFigura.Controls.Add(rbCirculo);
        grpFigura.Controls.Add(rbRectangulo);
        grpFigura.Location = new Point(20, 92);
        grpFigura.Name = "grpFigura";
        grpFigura.Size = new Size(330, 220);
        grpFigura.TabIndex = 1;
        grpFigura.TabStop = false;
        grpFigura.Text = "Figura figura = new ...";
        //
        // rbRectangulo
        //
        rbRectangulo.AutoSize = true;
        rbRectangulo.Checked = true;
        rbRectangulo.Location = new Point(16, 30);
        rbRectangulo.Name = "rbRectangulo";
        rbRectangulo.Size = new Size(94, 21);
        rbRectangulo.TabIndex = 0;
        rbRectangulo.TabStop = true;
        rbRectangulo.Text = "Rectángulo";
        rbRectangulo.CheckedChanged += rbTipo_CheckedChanged;
        //
        // rbCirculo
        //
        rbCirculo.AutoSize = true;
        rbCirculo.Location = new Point(150, 30);
        rbCirculo.Name = "rbCirculo";
        rbCirculo.Size = new Size(68, 21);
        rbCirculo.TabIndex = 1;
        rbCirculo.Text = "Círculo";
        rbCirculo.CheckedChanged += rbTipo_CheckedChanged;
        //
        // lblDato1
        //
        lblDato1.AutoSize = true;
        lblDato1.Location = new Point(16, 72);
        lblDato1.Name = "lblDato1";
        lblDato1.Size = new Size(39, 17);
        lblDato1.Text = "Base:";
        //
        // nudDato1
        //
        nudDato1.DecimalPlaces = 2;
        nudDato1.Location = new Point(100, 69);
        nudDato1.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        nudDato1.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
        nudDato1.Name = "nudDato1";
        nudDato1.Size = new Size(120, 25);
        nudDato1.TabIndex = 2;
        nudDato1.Value = new decimal(new int[] { 5, 0, 0, 0 });
        //
        // lblDato2
        //
        lblDato2.AutoSize = true;
        lblDato2.Location = new Point(16, 106);
        lblDato2.Name = "lblDato2";
        lblDato2.Size = new Size(48, 17);
        lblDato2.Text = "Altura:";
        //
        // nudDato2
        //
        nudDato2.DecimalPlaces = 2;
        nudDato2.Location = new Point(100, 103);
        nudDato2.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        nudDato2.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
        nudDato2.Name = "nudDato2";
        nudDato2.Size = new Size(120, 25);
        nudDato2.TabIndex = 3;
        nudDato2.Value = new decimal(new int[] { 3, 0, 0, 0 });
        //
        // btnCrearFigura
        //
        btnCrearFigura.Location = new Point(16, 150);
        btnCrearFigura.Name = "btnCrearFigura";
        btnCrearFigura.Size = new Size(190, 36);
        btnCrearFigura.TabIndex = 4;
        btnCrearFigura.Tag = "exito";
        btnCrearFigura.Text = "Crear figura";
        btnCrearFigura.Click += btnCrearFigura_Click;
        //
        // btnLimpiar
        //
        btnLimpiar.Location = new Point(214, 150);
        btnLimpiar.Name = "btnLimpiar";
        btnLimpiar.Size = new Size(100, 36);
        btnLimpiar.TabIndex = 5;
        btnLimpiar.Tag = "secundario";
        btnLimpiar.Text = "Limpiar";
        btnLimpiar.Click += btnLimpiar_Click;
        //
        // lblLista
        //
        lblLista.AutoSize = true;
        lblLista.Location = new Point(20, 322);
        lblLista.Name = "lblLista";
        lblLista.Size = new Size(160, 17);
        lblLista.TabIndex = 2;
        lblLista.Text = "List<Figura> creadas:";
        //
        // lstFiguras
        //
        lstFiguras.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        lstFiguras.IntegralHeight = false;
        lstFiguras.Location = new Point(20, 344);
        lstFiguras.Name = "lstFiguras";
        lstFiguras.Size = new Size(330, 280);
        lstFiguras.TabIndex = 3;
        lstFiguras.SelectedIndexChanged += lstFiguras_SelectedIndexChanged;
        //
        // picDibujo
        //
        picDibujo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        picDibujo.BackColor = Color.White;
        picDibujo.BorderStyle = BorderStyle.FixedSingle;
        picDibujo.Location = new Point(370, 92);
        picDibujo.Name = "picDibujo";
        picDibujo.Size = new Size(650, 360);
        picDibujo.TabIndex = 4;
        picDibujo.TabStop = false;
        picDibujo.Paint += picDibujo_Paint;
        picDibujo.Resize += picDibujo_Resize;
        //
        // lblResultado
        //
        lblResultado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lblResultado.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblResultado.ForeColor = Color.FromArgb(31, 78, 121);
        lblResultado.Location = new Point(370, 458);
        lblResultado.Name = "lblResultado";
        lblResultado.Size = new Size(650, 30);
        lblResultado.TabIndex = 5;
        lblResultado.Text = "Cree o seleccione una figura para dibujarla.";
        //
        // txtPreguntas
        //
        txtPreguntas.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        txtPreguntas.BackColor = Color.White;
        txtPreguntas.Location = new Point(370, 494);
        txtPreguntas.Multiline = true;
        txtPreguntas.Name = "txtPreguntas";
        txtPreguntas.ReadOnly = true;
        txtPreguntas.ScrollBars = ScrollBars.Vertical;
        txtPreguntas.Size = new Size(650, 130);
        txtPreguntas.TabIndex = 6;
        //
        // FrmClasesAbstractas
        //
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1040, 640);
        Controls.Add(txtPreguntas);
        Controls.Add(lblResultado);
        Controls.Add(picDibujo);
        Controls.Add(lstFiguras);
        Controls.Add(lblLista);
        Controls.Add(grpFigura);
        Name = "FrmClasesAbstractas";
        Text = "Clases abstractas";
        grpFigura.ResumeLayout(false);
        grpFigura.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudDato2).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudDato1).EndInit();
        ((System.ComponentModel.ISupportInitialize)picDibujo).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private GroupBox grpFigura;
    private Button btnLimpiar;
    private Button btnCrearFigura;
    private NumericUpDown nudDato2;
    private Label lblDato2;
    private NumericUpDown nudDato1;
    private Label lblDato1;
    private RadioButton rbCirculo;
    private RadioButton rbRectangulo;
    private ListBox lstFiguras;
    private Label lblLista;
    private PictureBox picDibujo;
    private Label lblResultado;
    private TextBox txtPreguntas;
}
