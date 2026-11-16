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
            if (disposing)
            {
                Detener();   // no dejar consolas abiertas
                components?.Dispose();
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
            pnlBarraColor = new Panel();
            pnlCabecera = new Panel();
            btnVolver = new Button();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            pnlBarra = new Panel();
            lblEstado = new Label();
            btnDetener = new Button();
            btnEjecutar = new Button();
            pnlConsola = new Panel();
            lblAviso = new Label();
            pnlCabecera.SuspendLayout();
            pnlBarra.SuspendLayout();
            pnlConsola.SuspendLayout();
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
            pnlCabecera.Controls.Add(btnVolver);
            pnlCabecera.Controls.Add(lblSubtitulo);
            pnlCabecera.Controls.Add(lblTitulo);
            pnlCabecera.Dock = DockStyle.Top;
            pnlCabecera.Location = new Point(0, 4);
            pnlCabecera.Name = "pnlCabecera";
            pnlCabecera.Size = new Size(880, 98);
            pnlCabecera.TabIndex = 1;
            //
            // btnVolver
            //
            btnVolver.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnVolver.BackColor = Color.FromArgb(100, 116, 139);
            btnVolver.Cursor = Cursors.Hand;
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVolver.ForeColor = Color.White;
            btnVolver.Location = new Point(756, 29);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(92, 39);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            //
            // lblSubtitulo
            //
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.BackColor = Color.Transparent;
            lblSubtitulo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitulo.ForeColor = Color.FromArgb(75, 85, 99);
            lblSubtitulo.Location = new Point(32, 59);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(220, 17);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Proyecto de consola original";
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(37, 99, 235);
            lblTitulo.Location = new Point(32, 24);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(108, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Proyecto";
            //
            // pnlBarra
            //
            pnlBarra.BackColor = Color.White;
            pnlBarra.Controls.Add(lblEstado);
            pnlBarra.Controls.Add(btnDetener);
            pnlBarra.Controls.Add(btnEjecutar);
            pnlBarra.Dock = DockStyle.Top;
            pnlBarra.Location = new Point(0, 102);
            pnlBarra.Name = "pnlBarra";
            pnlBarra.Padding = new Padding(32, 8, 32, 8);
            pnlBarra.Size = new Size(880, 56);
            pnlBarra.TabIndex = 2;
            //
            // lblEstado
            //
            lblEstado.Dock = DockStyle.Fill;
            lblEstado.ForeColor = Color.FromArgb(100, 116, 139);
            lblEstado.Location = new Point(32, 8);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(592, 40);
            lblEstado.TabIndex = 2;
            lblEstado.Text = "Consola del proyecto original";
            lblEstado.TextAlign = ContentAlignment.MiddleLeft;
            //
            // btnDetener
            //
            btnDetener.BackColor = Color.FromArgb(220, 38, 38);
            btnDetener.Cursor = Cursors.Hand;
            btnDetener.Dock = DockStyle.Right;
            btnDetener.FlatAppearance.BorderSize = 0;
            btnDetener.FlatStyle = FlatStyle.Flat;
            btnDetener.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDetener.ForeColor = Color.White;
            btnDetener.Location = new Point(624, 8);
            btnDetener.Name = "btnDetener";
            btnDetener.Size = new Size(104, 40);
            btnDetener.TabIndex = 1;
            btnDetener.Text = "Detener";
            btnDetener.UseVisualStyleBackColor = false;
            //
            // btnEjecutar
            //
            btnEjecutar.BackColor = Color.FromArgb(21, 128, 61);
            btnEjecutar.Cursor = Cursors.Hand;
            btnEjecutar.Dock = DockStyle.Right;
            btnEjecutar.FlatAppearance.BorderSize = 0;
            btnEjecutar.FlatStyle = FlatStyle.Flat;
            btnEjecutar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEjecutar.ForeColor = Color.White;
            btnEjecutar.Location = new Point(728, 8);
            btnEjecutar.Name = "btnEjecutar";
            btnEjecutar.Size = new Size(120, 40);
            btnEjecutar.TabIndex = 0;
            btnEjecutar.Text = "Ejecutar";
            btnEjecutar.UseVisualStyleBackColor = false;
            //
            // pnlConsola
            //
            pnlConsola.BackColor = Color.FromArgb(12, 12, 12);
            pnlConsola.Controls.Add(lblAviso);
            pnlConsola.Dock = DockStyle.Fill;
            pnlConsola.Location = new Point(0, 158);
            pnlConsola.Name = "pnlConsola";
            pnlConsola.Size = new Size(880, 522);
            pnlConsola.TabIndex = 3;
            //
            // lblAviso
            //
            lblAviso.Dock = DockStyle.Fill;
            lblAviso.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAviso.ForeColor = Color.FromArgb(203, 213, 225);
            lblAviso.Location = new Point(0, 0);
            lblAviso.Name = "lblAviso";
            lblAviso.Padding = new Padding(24);
            lblAviso.Size = new Size(880, 522);
            lblAviso.TabIndex = 0;
            lblAviso.Text = "Pulsa «Ejecutar» para iniciar el programa.";
            lblAviso.TextAlign = ContentAlignment.MiddleCenter;
            //
            // ucConsola
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 251);
            Controls.Add(pnlConsola);
            Controls.Add(pnlBarra);
            Controls.Add(pnlCabecera);
            Controls.Add(pnlBarraColor);
            Name = "ucConsola";
            Size = new Size(880, 680);
            pnlCabecera.ResumeLayout(false);
            pnlCabecera.PerformLayout();
            pnlBarra.ResumeLayout(false);
            pnlConsola.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlBarraColor;
        private Panel pnlCabecera;
        private Button btnVolver;
        private Label lblSubtitulo;
        private Label lblTitulo;
        private Panel pnlBarra;
        private Label lblEstado;
        private Button btnDetener;
        private Button btnEjecutar;
        private Panel pnlConsola;
        private Label lblAviso;
    }
}
