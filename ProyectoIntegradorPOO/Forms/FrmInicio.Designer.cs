namespace ProyectoIntegradorPOO.Forms;

partial class FrmInicio
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
        pnlAsignatura = new Panel();
        lblValorAsignatura = new Label();
        lblTituloAsignatura = new Label();
        pnlDesarrollador = new Panel();
        lblValorDesarrollador = new Label();
        lblTituloDesarrollador = new Label();
        pnlActividades = new Panel();
        lblValorActividades = new Label();
        lblTituloActividades = new Label();
        lblListado = new Label();
        dgvActividades = new DataGridView();
        pnlAsignatura.SuspendLayout();
        pnlDesarrollador.SuspendLayout();
        pnlActividades.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvActividades).BeginInit();
        SuspendLayout();
        //
        // pnlAsignatura
        //
        pnlAsignatura.BackColor = Color.White;
        pnlAsignatura.BorderStyle = BorderStyle.FixedSingle;
        pnlAsignatura.Controls.Add(lblValorAsignatura);
        pnlAsignatura.Controls.Add(lblTituloAsignatura);
        pnlAsignatura.Location = new Point(20, 92);
        pnlAsignatura.Name = "pnlAsignatura";
        pnlAsignatura.Size = new Size(320, 120);
        pnlAsignatura.TabIndex = 1;
        //
        // lblValorAsignatura
        //
        lblValorAsignatura.Location = new Point(14, 36);
        lblValorAsignatura.Name = "lblValorAsignatura";
        lblValorAsignatura.Size = new Size(296, 76);
        lblValorAsignatura.TabIndex = 1;
        lblValorAsignatura.Text = "Asignatura";
        //
        // lblTituloAsignatura
        //
        lblTituloAsignatura.AutoSize = true;
        lblTituloAsignatura.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblTituloAsignatura.ForeColor = Color.FromArgb(31, 78, 121);
        lblTituloAsignatura.Location = new Point(12, 10);
        lblTituloAsignatura.Name = "lblTituloAsignatura";
        lblTituloAsignatura.Size = new Size(84, 20);
        lblTituloAsignatura.TabIndex = 0;
        lblTituloAsignatura.Text = "Asignatura";
        //
        // pnlDesarrollador
        //
        pnlDesarrollador.BackColor = Color.White;
        pnlDesarrollador.BorderStyle = BorderStyle.FixedSingle;
        pnlDesarrollador.Controls.Add(lblValorDesarrollador);
        pnlDesarrollador.Controls.Add(lblTituloDesarrollador);
        pnlDesarrollador.Location = new Point(360, 92);
        pnlDesarrollador.Name = "pnlDesarrollador";
        pnlDesarrollador.Size = new Size(320, 120);
        pnlDesarrollador.TabIndex = 2;
        //
        // lblValorDesarrollador
        //
        lblValorDesarrollador.Location = new Point(14, 36);
        lblValorDesarrollador.Name = "lblValorDesarrollador";
        lblValorDesarrollador.Size = new Size(296, 76);
        lblValorDesarrollador.TabIndex = 1;
        lblValorDesarrollador.Text = "Desarrollador";
        //
        // lblTituloDesarrollador
        //
        lblTituloDesarrollador.AutoSize = true;
        lblTituloDesarrollador.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblTituloDesarrollador.ForeColor = Color.FromArgb(31, 78, 121);
        lblTituloDesarrollador.Location = new Point(12, 10);
        lblTituloDesarrollador.Name = "lblTituloDesarrollador";
        lblTituloDesarrollador.Size = new Size(108, 20);
        lblTituloDesarrollador.TabIndex = 0;
        lblTituloDesarrollador.Text = "Desarrollador";
        //
        // pnlActividades
        //
        pnlActividades.BackColor = Color.White;
        pnlActividades.BorderStyle = BorderStyle.FixedSingle;
        pnlActividades.Controls.Add(lblValorActividades);
        pnlActividades.Controls.Add(lblTituloActividades);
        pnlActividades.Location = new Point(700, 92);
        pnlActividades.Name = "pnlActividades";
        pnlActividades.Size = new Size(320, 120);
        pnlActividades.TabIndex = 3;
        //
        // lblValorActividades
        //
        lblValorActividades.Font = new Font("Segoe UI", 10.5F);
        lblValorActividades.Location = new Point(14, 36);
        lblValorActividades.Name = "lblValorActividades";
        lblValorActividades.Size = new Size(296, 76);
        lblValorActividades.TabIndex = 1;
        lblValorActividades.Text = "Actividades";
        //
        // lblTituloActividades
        //
        lblTituloActividades.AutoSize = true;
        lblTituloActividades.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblTituloActividades.ForeColor = Color.FromArgb(31, 78, 121);
        lblTituloActividades.Location = new Point(12, 10);
        lblTituloActividades.Name = "lblTituloActividades";
        lblTituloActividades.Size = new Size(152, 20);
        lblTituloActividades.TabIndex = 0;
        lblTituloActividades.Text = "Progreso del curso";
        //
        // lblListado
        //
        lblListado.AutoSize = true;
        lblListado.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblListado.ForeColor = Color.FromArgb(31, 78, 121);
        lblListado.Location = new Point(18, 228);
        lblListado.Name = "lblListado";
        lblListado.Size = new Size(380, 20);
        lblListado.TabIndex = 4;
        lblListado.Text = "Actividades incorporadas (doble clic para abrir)";
        //
        // dgvActividades
        //
        dgvActividades.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvActividades.Location = new Point(20, 256);
        dgvActividades.Name = "dgvActividades";
        dgvActividades.Size = new Size(1000, 368);
        dgvActividades.TabIndex = 5;
        dgvActividades.CellDoubleClick += dgvActividades_CellDoubleClick;
        //
        // FrmInicio
        //
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1040, 640);
        Controls.Add(dgvActividades);
        Controls.Add(lblListado);
        Controls.Add(pnlActividades);
        Controls.Add(pnlDesarrollador);
        Controls.Add(pnlAsignatura);
        Name = "FrmInicio";
        Text = "Inicio";
        Load += FrmInicio_Load;
        Controls.SetChildIndex(pnlAsignatura, 0);
        Controls.SetChildIndex(pnlDesarrollador, 0);
        Controls.SetChildIndex(pnlActividades, 0);
        Controls.SetChildIndex(lblListado, 0);
        Controls.SetChildIndex(dgvActividades, 0);
        pnlAsignatura.ResumeLayout(false);
        pnlAsignatura.PerformLayout();
        pnlDesarrollador.ResumeLayout(false);
        pnlDesarrollador.PerformLayout();
        pnlActividades.ResumeLayout(false);
        pnlActividades.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvActividades).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Panel pnlAsignatura;
    private Label lblValorAsignatura;
    private Label lblTituloAsignatura;
    private Panel pnlDesarrollador;
    private Label lblValorDesarrollador;
    private Label lblTituloDesarrollador;
    private Panel pnlActividades;
    private Label lblValorActividades;
    private Label lblTituloActividades;
    private Label lblListado;
    private DataGridView dgvActividades;
}
