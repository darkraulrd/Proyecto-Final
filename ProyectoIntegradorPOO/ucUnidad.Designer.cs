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
            lblTitulo = new Label();
            lblProyectos = new Label();
            lstProyectos = new ListBox();
            grpDetalle = new GroupBox();
            lblConceptos = new Label();
            lblConceptosTitulo = new Label();
            lblCarpeta = new Label();
            lblCarpetaTitulo = new Label();
            lblTipo = new Label();
            lblTipoTitulo = new Label();
            btnAbrir = new Button();
            grpDetalle.SuspendLayout();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(77, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Unidad";
            //
            // lblProyectos
            //
            lblProyectos.AutoSize = true;
            lblProyectos.Location = new Point(22, 60);
            lblProyectos.Name = "lblProyectos";
            lblProyectos.Size = new Size(61, 15);
            lblProyectos.TabIndex = 1;
            lblProyectos.Text = "Proyectos:";
            //
            // lstProyectos
            //
            lstProyectos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lstProyectos.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstProyectos.FormattingEnabled = true;
            lstProyectos.IntegralHeight = false;
            lstProyectos.ItemHeight = 20;
            lstProyectos.Location = new Point(22, 80);
            lstProyectos.Name = "lstProyectos";
            lstProyectos.Size = new Size(320, 480);
            lstProyectos.TabIndex = 2;
            lstProyectos.SelectedIndexChanged += lstProyectos_SelectedIndexChanged;
            lstProyectos.DoubleClick += lstProyectos_DoubleClick;
            //
            // grpDetalle
            //
            grpDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpDetalle.Controls.Add(lblConceptos);
            grpDetalle.Controls.Add(lblConceptosTitulo);
            grpDetalle.Controls.Add(lblCarpeta);
            grpDetalle.Controls.Add(lblCarpetaTitulo);
            grpDetalle.Controls.Add(lblTipo);
            grpDetalle.Controls.Add(lblTipoTitulo);
            grpDetalle.Location = new Point(362, 74);
            grpDetalle.Name = "grpDetalle";
            grpDetalle.Size = new Size(520, 200);
            grpDetalle.TabIndex = 3;
            grpDetalle.TabStop = false;
            grpDetalle.Text = "Detalle del proyecto";
            //
            // lblConceptos
            //
            lblConceptos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblConceptos.Location = new Point(100, 95);
            lblConceptos.Name = "lblConceptos";
            lblConceptos.Size = new Size(400, 90);
            lblConceptos.TabIndex = 5;
            lblConceptos.Text = "-";
            //
            // lblConceptosTitulo
            //
            lblConceptosTitulo.AutoSize = true;
            lblConceptosTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblConceptosTitulo.Location = new Point(15, 95);
            lblConceptosTitulo.Name = "lblConceptosTitulo";
            lblConceptosTitulo.Size = new Size(68, 15);
            lblConceptosTitulo.TabIndex = 4;
            lblConceptosTitulo.Text = "Conceptos:";
            //
            // lblCarpeta
            //
            lblCarpeta.AutoSize = true;
            lblCarpeta.Location = new Point(100, 62);
            lblCarpeta.Name = "lblCarpeta";
            lblCarpeta.Size = new Size(12, 15);
            lblCarpeta.TabIndex = 3;
            lblCarpeta.Text = "-";
            //
            // lblCarpetaTitulo
            //
            lblCarpetaTitulo.AutoSize = true;
            lblCarpetaTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCarpetaTitulo.Location = new Point(15, 62);
            lblCarpetaTitulo.Name = "lblCarpetaTitulo";
            lblCarpetaTitulo.Size = new Size(53, 15);
            lblCarpetaTitulo.TabIndex = 2;
            lblCarpetaTitulo.Text = "Carpeta:";
            //
            // lblTipo
            //
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(100, 30);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(12, 15);
            lblTipo.TabIndex = 1;
            lblTipo.Text = "-";
            //
            // lblTipoTitulo
            //
            lblTipoTitulo.AutoSize = true;
            lblTipoTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTipoTitulo.Location = new Point(15, 30);
            lblTipoTitulo.Name = "lblTipoTitulo";
            lblTipoTitulo.Size = new Size(35, 15);
            lblTipoTitulo.TabIndex = 0;
            lblTipoTitulo.Text = "Tipo:";
            //
            // btnAbrir
            //
            btnAbrir.Location = new Point(362, 290);
            btnAbrir.Name = "btnAbrir";
            btnAbrir.Size = new Size(130, 35);
            btnAbrir.TabIndex = 4;
            btnAbrir.Text = "Abrir proyecto";
            btnAbrir.UseVisualStyleBackColor = true;
            btnAbrir.Click += btnAbrir_Click;
            //
            // ucUnidad
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnAbrir);
            Controls.Add(grpDetalle);
            Controls.Add(lstProyectos);
            Controls.Add(lblProyectos);
            Controls.Add(lblTitulo);
            Name = "ucUnidad";
            Size = new Size(905, 625);
            grpDetalle.ResumeLayout(false);
            grpDetalle.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblProyectos;
        private ListBox lstProyectos;
        private GroupBox grpDetalle;
        private Label lblConceptos;
        private Label lblConceptosTitulo;
        private Label lblCarpeta;
        private Label lblCarpetaTitulo;
        private Label lblTipo;
        private Label lblTipoTitulo;
        private Button btnAbrir;
    }
}
