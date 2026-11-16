namespace ProyectoIntegradorPOO
{
    partial class ucUnidad
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlBarraColor = new Panel();
            pnlCabecera = new Panel();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            pnlCuerpo = new Panel();
            lblTotal = new Label();
            dgvProyectos = new DataGridView();
            Nombre = new DataGridViewTextBoxColumn();
            Tipo = new DataGridViewTextBoxColumn();
            UbicacionTexto = new DataGridViewTextBoxColumn();
            Conceptos = new DataGridViewTextBoxColumn();
            Abrir = new DataGridViewLinkColumn();
            pnlCabecera.SuspendLayout();
            pnlCuerpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProyectos).BeginInit();
            SuspendLayout();
            //
            // pnlBarraColor
            //
            pnlBarraColor.BackColor = Color.FromArgb(37, 99, 235);
            pnlBarraColor.Dock = DockStyle.Top;
            pnlBarraColor.Location = new Point(0, 0);
            pnlBarraColor.Name = "pnlBarraColor";
            pnlBarraColor.Size = new Size(880, 4);
            pnlBarraColor.TabIndex = 0;
            //
            // pnlCabecera
            //
            pnlCabecera.BackColor = Color.FromArgb(219, 234, 254);
            pnlCabecera.Controls.Add(lblSubtitulo);
            pnlCabecera.Controls.Add(lblTitulo);
            pnlCabecera.Dock = DockStyle.Top;
            pnlCabecera.Location = new Point(0, 4);
            pnlCabecera.Name = "pnlCabecera";
            pnlCabecera.Size = new Size(880, 98);
            pnlCabecera.TabIndex = 1;
            //
            // lblSubtitulo
            //
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.BackColor = Color.Transparent;
            lblSubtitulo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitulo.ForeColor = Color.FromArgb(75, 85, 99);
            lblSubtitulo.Location = new Point(32, 59);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(320, 17);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Proyectos de esta unidad. Elige uno para abrirlo.";
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(37, 99, 235);
            lblTitulo.Location = new Point(32, 24);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(97, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Unidad";
            //
            // pnlCuerpo
            //
            pnlCuerpo.Controls.Add(lblTotal);
            pnlCuerpo.Controls.Add(dgvProyectos);
            pnlCuerpo.Dock = DockStyle.Fill;
            pnlCuerpo.Location = new Point(0, 102);
            pnlCuerpo.Name = "pnlCuerpo";
            pnlCuerpo.Size = new Size(880, 578);
            pnlCuerpo.TabIndex = 2;
            //
            // lblTotal
            //
            lblTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTotal.AutoSize = true;
            lblTotal.ForeColor = Color.FromArgb(100, 116, 139);
            lblTotal.Location = new Point(32, 532);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(70, 15);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "0 proyectos";
            //
            // dgvProyectos
            //
            dgvProyectos.AllowUserToAddRows = false;
            dgvProyectos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(219, 234, 254);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(248, 250, 252);
            dgvProyectos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvProyectos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProyectos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProyectos.BackgroundColor = Color.White;
            dgvProyectos.BorderStyle = BorderStyle.None;
            dgvProyectos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(219, 234, 254);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(37, 99, 235);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvProyectos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvProyectos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProyectos.Columns.AddRange(new DataGridViewColumn[] { Nombre, Tipo, UbicacionTexto, Conceptos, Abrir });
            dgvProyectos.EnableHeadersVisualStyles = false;
            dgvProyectos.Location = new Point(32, 32);
            dgvProyectos.MultiSelect = false;
            dgvProyectos.Name = "dgvProyectos";
            dgvProyectos.ReadOnly = true;
            dgvProyectos.RowHeadersVisible = false;
            dgvProyectos.RowTemplate.Height = 38;
            dgvProyectos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProyectos.Size = new Size(816, 490);
            dgvProyectos.TabIndex = 0;
            //
            // Nombre
            //
            Nombre.DataPropertyName = "Nombre";
            Nombre.FillWeight = 110F;
            Nombre.HeaderText = "Proyecto";
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            //
            // Tipo
            //
            Tipo.DataPropertyName = "Tipo";
            Tipo.FillWeight = 70F;
            Tipo.HeaderText = "Tipo";
            Tipo.Name = "Tipo";
            Tipo.ReadOnly = true;
            //
            // UbicacionTexto
            //
            UbicacionTexto.DataPropertyName = "UbicacionTexto";
            UbicacionTexto.FillWeight = 130F;
            UbicacionTexto.HeaderText = "Carpeta";
            UbicacionTexto.Name = "UbicacionTexto";
            UbicacionTexto.ReadOnly = true;
            //
            // Conceptos
            //
            Conceptos.DataPropertyName = "Conceptos";
            Conceptos.FillWeight = 200F;
            Conceptos.HeaderText = "Conceptos";
            Conceptos.Name = "Conceptos";
            Conceptos.ReadOnly = true;
            //
            // Abrir
            //
            Abrir.ActiveLinkColor = Color.FromArgb(21, 128, 61);
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Abrir.DefaultCellStyle = dataGridViewCellStyle3;
            Abrir.FillWeight = 50F;
            Abrir.HeaderText = "Abrir";
            Abrir.LinkColor = Color.FromArgb(21, 128, 61);
            Abrir.Name = "Abrir";
            Abrir.ReadOnly = true;
            Abrir.Text = "Abrir";
            Abrir.UseColumnTextForLinkValue = true;
            Abrir.VisitedLinkColor = Color.FromArgb(21, 128, 61);
            //
            // ucUnidad
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 251);
            Controls.Add(pnlCuerpo);
            Controls.Add(pnlCabecera);
            Controls.Add(pnlBarraColor);
            Name = "ucUnidad";
            Size = new Size(880, 680);
            pnlCabecera.ResumeLayout(false);
            pnlCabecera.PerformLayout();
            pnlCuerpo.ResumeLayout(false);
            pnlCuerpo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProyectos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlBarraColor;
        private Panel pnlCabecera;
        private Label lblSubtitulo;
        private Label lblTitulo;
        private Panel pnlCuerpo;
        private Label lblTotal;
        private DataGridView dgvProyectos;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Tipo;
        private DataGridViewTextBoxColumn UbicacionTexto;
        private DataGridViewTextBoxColumn Conceptos;
        private DataGridViewLinkColumn Abrir;
    }
}
