namespace ProyectoIntegradorPOO.Forms.Originales;

partial class UcFormularioIncrustado
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

    #region Código generado por el Diseñador de componentes

    private void InitializeComponent()
    {
        pnlBarra = new Panel();
        lblEstado = new Label();
        btnReabrir = new Button();
        pnlFormulario = new Panel();
        lblAviso = new Label();
        pnlBarra.SuspendLayout();
        pnlFormulario.SuspendLayout();
        SuspendLayout();
        //
        // pnlBarra
        //
        pnlBarra.BackColor = Color.White;
        pnlBarra.Controls.Add(lblEstado);
        pnlBarra.Controls.Add(btnReabrir);
        pnlBarra.Dock = DockStyle.Top;
        pnlBarra.Location = new Point(0, 0);
        pnlBarra.Name = "pnlBarra";
        pnlBarra.Padding = new Padding(12, 8, 12, 8);
        pnlBarra.Size = new Size(800, 48);
        pnlBarra.TabIndex = 0;
        //
        // lblEstado
        //
        lblEstado.Dock = DockStyle.Fill;
        lblEstado.ForeColor = Color.FromArgb(108, 117, 125);
        lblEstado.Location = new Point(12, 8);
        lblEstado.Name = "lblEstado";
        lblEstado.Size = new Size(646, 32);
        lblEstado.TabIndex = 1;
        lblEstado.Text = "Formulario del proyecto original";
        lblEstado.TextAlign = ContentAlignment.MiddleLeft;
        //
        // btnReabrir
        //
        btnReabrir.Dock = DockStyle.Right;
        btnReabrir.Location = new Point(658, 8);
        btnReabrir.Name = "btnReabrir";
        btnReabrir.Size = new Size(130, 32);
        btnReabrir.TabIndex = 0;
        btnReabrir.Tag = "exito";
        btnReabrir.Text = "Abrir";
        btnReabrir.Click += btnReabrir_Click;
        //
        // pnlFormulario
        //
        pnlFormulario.AutoScroll = true;
        pnlFormulario.BackColor = Color.FromArgb(244, 246, 249);
        pnlFormulario.Controls.Add(lblAviso);
        pnlFormulario.Dock = DockStyle.Fill;
        pnlFormulario.Location = new Point(0, 48);
        pnlFormulario.Name = "pnlFormulario";
        pnlFormulario.Size = new Size(800, 452);
        pnlFormulario.TabIndex = 1;
        //
        // lblAviso
        //
        lblAviso.Dock = DockStyle.Fill;
        lblAviso.Font = new Font("Segoe UI", 11F);
        lblAviso.ForeColor = Color.FromArgb(108, 117, 125);
        lblAviso.Location = new Point(0, 0);
        lblAviso.Name = "lblAviso";
        lblAviso.Padding = new Padding(24);
        lblAviso.Size = new Size(800, 452);
        lblAviso.TabIndex = 0;
        lblAviso.Text = "Pulsa «Abrir» para mostrar el formulario original.";
        lblAviso.TextAlign = ContentAlignment.MiddleCenter;
        //
        // UcFormularioIncrustado
        //
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(pnlFormulario);
        Controls.Add(pnlBarra);
        Font = new Font("Segoe UI", 9.75F);
        Name = "UcFormularioIncrustado";
        Size = new Size(800, 500);
        pnlBarra.ResumeLayout(false);
        pnlFormulario.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlBarra;
    private Label lblEstado;
    private Button btnReabrir;
    private Panel pnlFormulario;
    private Label lblAviso;
}
