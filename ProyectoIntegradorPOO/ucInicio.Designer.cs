namespace ProyectoIntegradorPOO
{
    partial class ucInicio
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
            lblTitulo = new Label();
            lblInfo = new Label();
            dgvProyectos = new DataGridView();
            colUnidad = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colTipo = new DataGridViewTextBoxColumn();
            colCarpeta = new DataGridViewTextBoxColumn();
            colConceptos = new DataGridViewTextBoxColumn();
            btnAbrir = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProyectos).BeginInit();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(205, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Proyectos del curso";
            //
            // lblInfo
            //
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(22, 48);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(480, 15);
            lblInfo.TabIndex = 1;
            lblInfo.Text = "INF-5130 Programación I - UASD - Raúl Mena (100758645). Seleccione un proyecto y pulse Abrir.";
            //
            // dgvProyectos
            //
            dgvProyectos.AllowUserToAddRows = false;
            dgvProyectos.AllowUserToDeleteRows = false;
            dgvProyectos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProyectos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProyectos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProyectos.Columns.AddRange(new DataGridViewColumn[] { colUnidad, colNombre, colTipo, colCarpeta, colConceptos });
            dgvProyectos.Location = new Point(22, 80);
            dgvProyectos.MultiSelect = false;
            dgvProyectos.Name = "dgvProyectos";
            dgvProyectos.ReadOnly = true;
            dgvProyectos.RowHeadersVisible = false;
            dgvProyectos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProyectos.Size = new Size(860, 480);
            dgvProyectos.TabIndex = 2;
            dgvProyectos.CellDoubleClick += dgvProyectos_CellDoubleClick;
            //
            // colUnidad
            //
            colUnidad.DataPropertyName = "Unidad";
            colUnidad.FillWeight = 40F;
            colUnidad.HeaderText = "Unidad";
            colUnidad.Name = "colUnidad";
            colUnidad.ReadOnly = true;
            //
            // colNombre
            //
            colNombre.DataPropertyName = "Nombre";
            colNombre.HeaderText = "Proyecto";
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            //
            // colTipo
            //
            colTipo.DataPropertyName = "Tipo";
            colTipo.FillWeight = 70F;
            colTipo.HeaderText = "Tipo";
            colTipo.Name = "colTipo";
            colTipo.ReadOnly = true;
            //
            // colCarpeta
            //
            colCarpeta.DataPropertyName = "Carpeta";
            colCarpeta.HeaderText = "Carpeta";
            colCarpeta.Name = "colCarpeta";
            colCarpeta.ReadOnly = true;
            //
            // colConceptos
            //
            colConceptos.DataPropertyName = "Conceptos";
            colConceptos.FillWeight = 200F;
            colConceptos.HeaderText = "Conceptos";
            colConceptos.Name = "colConceptos";
            colConceptos.ReadOnly = true;
            //
            // btnAbrir
            //
            btnAbrir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAbrir.Location = new Point(752, 575);
            btnAbrir.Name = "btnAbrir";
            btnAbrir.Size = new Size(130, 35);
            btnAbrir.TabIndex = 3;
            btnAbrir.Text = "Abrir proyecto";
            btnAbrir.UseVisualStyleBackColor = true;
            btnAbrir.Click += btnAbrir_Click;
            //
            // ucInicio
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnAbrir);
            Controls.Add(dgvProyectos);
            Controls.Add(lblInfo);
            Controls.Add(lblTitulo);
            Name = "ucInicio";
            Size = new Size(905, 625);
            Load += ucInicio_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProyectos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblInfo;
        private DataGridView dgvProyectos;
        private DataGridViewTextBoxColumn colUnidad;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colTipo;
        private DataGridViewTextBoxColumn colCarpeta;
        private DataGridViewTextBoxColumn colConceptos;
        private Button btnAbrir;
    }
}
