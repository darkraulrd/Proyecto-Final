namespace ProyectoIntegradorPOO
{
    partial class ucConsola
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
            lblDatos = new Label();
            btnEjecutar = new Button();
            btnDetener = new Button();
            btnVolver = new Button();
            pnlConsola = new Panel();
            lblEstado = new Label();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(91, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Proyecto";
            //
            // lblDatos
            //
            lblDatos.AutoSize = true;
            lblDatos.Location = new Point(22, 48);
            lblDatos.Name = "lblDatos";
            lblDatos.Size = new Size(12, 15);
            lblDatos.TabIndex = 1;
            lblDatos.Text = "-";
            //
            // btnEjecutar
            //
            btnEjecutar.Location = new Point(22, 75);
            btnEjecutar.Name = "btnEjecutar";
            btnEjecutar.Size = new Size(110, 30);
            btnEjecutar.TabIndex = 2;
            btnEjecutar.Text = "Ejecutar";
            btnEjecutar.UseVisualStyleBackColor = true;
            btnEjecutar.Click += btnEjecutar_Click;
            //
            // btnDetener
            //
            btnDetener.Location = new Point(138, 75);
            btnDetener.Name = "btnDetener";
            btnDetener.Size = new Size(110, 30);
            btnDetener.TabIndex = 3;
            btnDetener.Text = "Detener";
            btnDetener.UseVisualStyleBackColor = true;
            btnDetener.Click += btnDetener_Click;
            //
            // btnVolver
            //
            btnVolver.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnVolver.Location = new Point(772, 75);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(110, 30);
            btnVolver.TabIndex = 4;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            //
            // pnlConsola
            //
            pnlConsola.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlConsola.BackColor = Color.Black;
            pnlConsola.BorderStyle = BorderStyle.Fixed3D;
            pnlConsola.Location = new Point(22, 115);
            pnlConsola.Name = "pnlConsola";
            pnlConsola.Size = new Size(860, 470);
            pnlConsola.TabIndex = 5;
            pnlConsola.Resize += pnlConsola_Resize;
            //
            // lblEstado
            //
            lblEstado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(22, 595);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(170, 15);
            lblEstado.TabIndex = 6;
            lblEstado.Text = "Pulse Ejecutar para iniciarlo.";
            //
            // ucConsola
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblEstado);
            Controls.Add(pnlConsola);
            Controls.Add(btnVolver);
            Controls.Add(btnDetener);
            Controls.Add(btnEjecutar);
            Controls.Add(lblDatos);
            Controls.Add(lblTitulo);
            Name = "ucConsola";
            Size = new Size(905, 625);
            Load += ucConsola_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblDatos;
        private Button btnEjecutar;
        private Button btnDetener;
        private Button btnVolver;
        private Panel pnlConsola;
        private Label lblEstado;
    }
}
