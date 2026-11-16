namespace ProyectoIntegradorPOO
{
    partial class ucFormulario
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
            btnAbrir = new Button();
            btnVolver = new Button();
            pnlFormulario = new Panel();
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
            // btnAbrir
            //
            btnAbrir.Location = new Point(22, 75);
            btnAbrir.Name = "btnAbrir";
            btnAbrir.Size = new Size(110, 30);
            btnAbrir.TabIndex = 2;
            btnAbrir.Text = "Abrir de nuevo";
            btnAbrir.UseVisualStyleBackColor = true;
            btnAbrir.Click += btnAbrir_Click;
            //
            // btnVolver
            //
            btnVolver.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnVolver.Location = new Point(772, 75);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(110, 30);
            btnVolver.TabIndex = 3;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            //
            // pnlFormulario
            //
            pnlFormulario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlFormulario.AutoScroll = true;
            pnlFormulario.BorderStyle = BorderStyle.Fixed3D;
            pnlFormulario.Location = new Point(22, 115);
            pnlFormulario.Name = "pnlFormulario";
            pnlFormulario.Size = new Size(860, 495);
            pnlFormulario.TabIndex = 4;
            //
            // ucFormulario
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlFormulario);
            Controls.Add(btnVolver);
            Controls.Add(btnAbrir);
            Controls.Add(lblDatos);
            Controls.Add(lblTitulo);
            Name = "ucFormulario";
            Size = new Size(905, 625);
            Load += ucFormulario_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblDatos;
        private Button btnAbrir;
        private Button btnVolver;
        private Panel pnlFormulario;
    }
}
