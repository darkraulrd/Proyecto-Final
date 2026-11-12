namespace ProyectoIntegradorPOO.Forms.Comun;

partial class FrmActividadBase
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
        pnlEncabezado = new Panel();
        lblConceptos = new Label();
        lblTitulo = new Label();
        pnlLinea = new Panel();
        pnlEncabezado.SuspendLayout();
        SuspendLayout();
        //
        // pnlEncabezado
        //
        pnlEncabezado.BackColor = Color.White;
        pnlEncabezado.Controls.Add(lblConceptos);
        pnlEncabezado.Controls.Add(lblTitulo);
        pnlEncabezado.Controls.Add(pnlLinea);
        pnlEncabezado.Dock = DockStyle.Top;
        pnlEncabezado.Location = new Point(0, 0);
        pnlEncabezado.Name = "pnlEncabezado";
        pnlEncabezado.Size = new Size(1040, 78);
        pnlEncabezado.TabIndex = 0;
        //
        // lblConceptos
        //
        lblConceptos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        lblConceptos.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic);
        lblConceptos.ForeColor = Color.FromArgb(108, 117, 125);
        lblConceptos.Location = new Point(22, 46);
        lblConceptos.Name = "lblConceptos";
        lblConceptos.Size = new Size(996, 22);
        lblConceptos.TabIndex = 1;
        lblConceptos.Text = "Conceptos POO aplicados";
        //
        // lblTitulo
        //
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.FromArgb(31, 78, 121);
        lblTitulo.Location = new Point(18, 10);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(210, 30);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Título de la actividad";
        //
        // pnlLinea
        //
        pnlLinea.BackColor = Color.FromArgb(46, 134, 193);
        pnlLinea.Dock = DockStyle.Bottom;
        pnlLinea.Location = new Point(0, 75);
        pnlLinea.Name = "pnlLinea";
        pnlLinea.Size = new Size(1040, 3);
        pnlLinea.TabIndex = 2;
        //
        // FrmActividadBase
        //
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoScroll = true;
        BackColor = Color.FromArgb(244, 246, 249);
        ClientSize = new Size(1040, 640);
        Controls.Add(pnlEncabezado);
        Font = new Font("Segoe UI", 9.75F);
        Name = "FrmActividadBase";
        Text = "Actividad";
        pnlEncabezado.ResumeLayout(false);
        pnlEncabezado.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlEncabezado;
    private Label lblConceptos;
    private Label lblTitulo;
    private Panel pnlLinea;
}
