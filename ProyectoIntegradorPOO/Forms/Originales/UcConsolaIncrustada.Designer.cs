namespace ProyectoIntegradorPOO.Forms.Originales;

partial class UcConsolaIncrustada
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            Detener();
            components?.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Código generado por el Diseñador de componentes

    private void InitializeComponent()
    {
        pnlBarra = new Panel();
        lblEstado = new Label();
        btnDetener = new Button();
        btnEjecutar = new Button();
        pnlConsola = new Panel();
        lblAviso = new Label();
        pnlBarra.SuspendLayout();
        pnlConsola.SuspendLayout();
        SuspendLayout();
        //
        // pnlBarra
        //
        pnlBarra.BackColor = Color.White;
        pnlBarra.Controls.Add(lblEstado);
        pnlBarra.Controls.Add(btnDetener);
        pnlBarra.Controls.Add(btnEjecutar);
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
        lblEstado.Size = new Size(536, 32);
        lblEstado.TabIndex = 2;
        lblEstado.Text = "Consola del proyecto original";
        lblEstado.TextAlign = ContentAlignment.MiddleLeft;
        //
        // btnDetener
        //
        btnDetener.Dock = DockStyle.Right;
        btnDetener.Location = new Point(548, 8);
        btnDetener.Name = "btnDetener";
        btnDetener.Size = new Size(110, 32);
        btnDetener.TabIndex = 1;
        btnDetener.Tag = "peligro";
        btnDetener.Text = "Detener";
        btnDetener.Click += btnDetener_Click;
        //
        // btnEjecutar
        //
        btnEjecutar.Dock = DockStyle.Right;
        btnEjecutar.Location = new Point(658, 8);
        btnEjecutar.Name = "btnEjecutar";
        btnEjecutar.Size = new Size(130, 32);
        btnEjecutar.TabIndex = 0;
        btnEjecutar.Tag = "exito";
        btnEjecutar.Text = "Ejecutar";
        btnEjecutar.Click += btnEjecutar_Click;
        //
        // pnlConsola
        //
        pnlConsola.BackColor = Color.FromArgb(12, 12, 12);
        pnlConsola.Controls.Add(lblAviso);
        pnlConsola.Dock = DockStyle.Fill;
        pnlConsola.Location = new Point(0, 48);
        pnlConsola.Name = "pnlConsola";
        pnlConsola.Size = new Size(800, 452);
        pnlConsola.TabIndex = 1;
        pnlConsola.Resize += pnlConsola_Resize;
        //
        // lblAviso
        //
        lblAviso.Dock = DockStyle.Fill;
        lblAviso.Font = new Font("Segoe UI", 11F);
        lblAviso.ForeColor = Color.FromArgb(204, 204, 204);
        lblAviso.Location = new Point(0, 0);
        lblAviso.Name = "lblAviso";
        lblAviso.Padding = new Padding(24);
        lblAviso.Size = new Size(800, 452);
        lblAviso.TabIndex = 0;
        lblAviso.Text = "Pulsa «Ejecutar» para iniciar el programa original.";
        lblAviso.TextAlign = ContentAlignment.MiddleCenter;
        //
        // UcConsolaIncrustada
        //
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(pnlConsola);
        Controls.Add(pnlBarra);
        Font = new Font("Segoe UI", 9.75F);
        Name = "UcConsolaIncrustada";
        Size = new Size(800, 500);
        pnlBarra.ResumeLayout(false);
        pnlConsola.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlBarra;
    private Label lblEstado;
    private Button btnDetener;
    private Button btnEjecutar;
    private Panel pnlConsola;
    private Label lblAviso;
}
