namespace ProyectoIntegradorPOO.Forms;

partial class FrmAcercaDe
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
        pnlBanda = new Panel();
        lblNombre = new Label();
        lblDetalle = new Label();
        btnAceptar = new Button();
        pnlBanda.SuspendLayout();
        SuspendLayout();
        //
        // pnlBanda
        //
        pnlBanda.BackColor = Color.FromArgb(31, 78, 121);
        pnlBanda.Controls.Add(lblNombre);
        pnlBanda.Dock = DockStyle.Top;
        pnlBanda.Location = new Point(0, 0);
        pnlBanda.Name = "pnlBanda";
        pnlBanda.Size = new Size(480, 80);
        pnlBanda.TabIndex = 0;
        //
        // lblNombre
        //
        lblNombre.Dock = DockStyle.Fill;
        lblNombre.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
        lblNombre.ForeColor = Color.White;
        lblNombre.Location = new Point(0, 0);
        lblNombre.Name = "lblNombre";
        lblNombre.Padding = new Padding(16, 0, 16, 0);
        lblNombre.Size = new Size(480, 80);
        lblNombre.TabIndex = 0;
        lblNombre.Text = "Nombre";
        lblNombre.TextAlign = ContentAlignment.MiddleLeft;
        //
        // lblDetalle
        //
        lblDetalle.Location = new Point(18, 94);
        lblDetalle.Name = "lblDetalle";
        lblDetalle.Size = new Size(444, 230);
        lblDetalle.TabIndex = 1;
        lblDetalle.Text = "Detalle";
        //
        // btnAceptar
        //
        btnAceptar.DialogResult = DialogResult.OK;
        btnAceptar.Location = new Point(352, 334);
        btnAceptar.Name = "btnAceptar";
        btnAceptar.Size = new Size(110, 34);
        btnAceptar.TabIndex = 2;
        btnAceptar.Text = "Aceptar";
        //
        // FrmAcercaDe
        //
        AcceptButton = btnAceptar;
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        CancelButton = btnAceptar;
        ClientSize = new Size(480, 384);
        Controls.Add(btnAceptar);
        Controls.Add(lblDetalle);
        Controls.Add(pnlBanda);
        Font = new Font("Segoe UI", 9.75F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FrmAcercaDe";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Acerca de";
        Load += FrmAcercaDe_Load;
        pnlBanda.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlBanda;
    private Label lblNombre;
    private Label lblDetalle;
    private Button btnAceptar;
}
