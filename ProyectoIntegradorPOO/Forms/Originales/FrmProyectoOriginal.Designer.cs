namespace ProyectoIntegradorPOO.Forms.Originales;

partial class FrmProyectoOriginal
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
        pnlAnfitrion = new Panel();
        SuspendLayout();
        //
        // pnlAnfitrion
        //
        pnlAnfitrion.Dock = DockStyle.Fill;
        pnlAnfitrion.Location = new Point(0, 78);
        pnlAnfitrion.Name = "pnlAnfitrion";
        pnlAnfitrion.Padding = new Padding(0);
        pnlAnfitrion.Size = new Size(1040, 562);
        pnlAnfitrion.TabIndex = 1;
        //
        // FrmProyectoOriginal
        //
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1040, 640);
        Controls.Add(pnlAnfitrion);
        Name = "FrmProyectoOriginal";
        Text = "Proyecto original";
        Controls.SetChildIndex(pnlAnfitrion, 0);
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlAnfitrion;
}
