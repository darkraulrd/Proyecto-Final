namespace ProyectoIntegradorPOO
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlMenu = new Panel();
            btnSalir = new Button();
            grpUnidades = new GroupBox();
            btnUnidad6 = new Button();
            btnUnidad5 = new Button();
            btnUnidad4 = new Button();
            btnUnidad3 = new Button();
            btnUnidad2 = new Button();
            btnUnidad1 = new Button();
            btnInicio = new Button();
            pnlContenido = new Panel();
            pnlMenu.SuspendLayout();
            grpUnidades.SuspendLayout();
            SuspendLayout();
            //
            // pnlMenu
            //
            pnlMenu.Controls.Add(btnSalir);
            pnlMenu.Controls.Add(grpUnidades);
            pnlMenu.Controls.Add(btnInicio);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(190, 650);
            pnlMenu.TabIndex = 0;
            //
            // btnSalir
            //
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSalir.Location = new Point(12, 600);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(165, 35);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            //
            // grpUnidades
            //
            grpUnidades.Controls.Add(btnUnidad6);
            grpUnidades.Controls.Add(btnUnidad5);
            grpUnidades.Controls.Add(btnUnidad4);
            grpUnidades.Controls.Add(btnUnidad3);
            grpUnidades.Controls.Add(btnUnidad2);
            grpUnidades.Controls.Add(btnUnidad1);
            grpUnidades.Location = new Point(12, 60);
            grpUnidades.Name = "grpUnidades";
            grpUnidades.Size = new Size(165, 280);
            grpUnidades.TabIndex = 1;
            grpUnidades.TabStop = false;
            grpUnidades.Text = "Unidades";
            //
            // btnUnidad6
            //
            btnUnidad6.Location = new Point(10, 230);
            btnUnidad6.Name = "btnUnidad6";
            btnUnidad6.Size = new Size(145, 35);
            btnUnidad6.TabIndex = 5;
            btnUnidad6.Text = "Unidad 6";
            btnUnidad6.UseVisualStyleBackColor = true;
            btnUnidad6.Click += btnUnidad6_Click;
            //
            // btnUnidad5
            //
            btnUnidad5.Location = new Point(10, 189);
            btnUnidad5.Name = "btnUnidad5";
            btnUnidad5.Size = new Size(145, 35);
            btnUnidad5.TabIndex = 4;
            btnUnidad5.Text = "Unidad 5";
            btnUnidad5.UseVisualStyleBackColor = true;
            btnUnidad5.Click += btnUnidad5_Click;
            //
            // btnUnidad4
            //
            btnUnidad4.Location = new Point(10, 148);
            btnUnidad4.Name = "btnUnidad4";
            btnUnidad4.Size = new Size(145, 35);
            btnUnidad4.TabIndex = 3;
            btnUnidad4.Text = "Unidad 4";
            btnUnidad4.UseVisualStyleBackColor = true;
            btnUnidad4.Click += btnUnidad4_Click;
            //
            // btnUnidad3
            //
            btnUnidad3.Location = new Point(10, 107);
            btnUnidad3.Name = "btnUnidad3";
            btnUnidad3.Size = new Size(145, 35);
            btnUnidad3.TabIndex = 2;
            btnUnidad3.Text = "Unidad 3";
            btnUnidad3.UseVisualStyleBackColor = true;
            btnUnidad3.Click += btnUnidad3_Click;
            //
            // btnUnidad2
            //
            btnUnidad2.Location = new Point(10, 66);
            btnUnidad2.Name = "btnUnidad2";
            btnUnidad2.Size = new Size(145, 35);
            btnUnidad2.TabIndex = 1;
            btnUnidad2.Text = "Unidad 2";
            btnUnidad2.UseVisualStyleBackColor = true;
            btnUnidad2.Click += btnUnidad2_Click;
            //
            // btnUnidad1
            //
            btnUnidad1.Location = new Point(10, 25);
            btnUnidad1.Name = "btnUnidad1";
            btnUnidad1.Size = new Size(145, 35);
            btnUnidad1.TabIndex = 0;
            btnUnidad1.Text = "Unidad 1";
            btnUnidad1.UseVisualStyleBackColor = true;
            btnUnidad1.Click += btnUnidad1_Click;
            //
            // btnInicio
            //
            btnInicio.Location = new Point(12, 12);
            btnInicio.Name = "btnInicio";
            btnInicio.Size = new Size(165, 35);
            btnInicio.TabIndex = 0;
            btnInicio.Text = "Inicio";
            btnInicio.UseVisualStyleBackColor = true;
            btnInicio.Click += btnInicio_Click;
            //
            // pnlContenido
            //
            pnlContenido.BorderStyle = BorderStyle.Fixed3D;
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.Location = new Point(190, 0);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Size = new Size(910, 650);
            pnlContenido.TabIndex = 1;
            //
            // Menu
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 650);
            Controls.Add(pnlContenido);
            Controls.Add(pnlMenu);
            MinimumSize = new Size(900, 600);
            Name = "Menu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Proyecto Final - INF-5130 Programación I";
            FormClosing += Menu_FormClosing;
            pnlMenu.ResumeLayout(false);
            grpUnidades.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMenu;
        private Button btnInicio;
        private GroupBox grpUnidades;
        private Button btnUnidad1;
        private Button btnUnidad2;
        private Button btnUnidad3;
        private Button btnUnidad4;
        private Button btnUnidad5;
        private Button btnUnidad6;
        private Button btnSalir;
        private Panel pnlContenido;
    }
}
