namespace ProyectoIntegradorPOO
{
    // Muestra el formulario de un proyecto de Windows Forms dentro del programa
    public partial class ucFormulario : UserControl
    {
        private Proyecto proyecto;
        private Form formulario;

        // Avisa al Menu que se quiere volver a la unidad
        public event Action Volver;

        public ucFormulario()
        {
            InitializeComponent();
        }

        public void Cargar(Proyecto p)
        {
            proyecto = p;
            lblTitulo.Text = p.Nombre;
            lblDatos.Text = "Unidad " + p.Unidad + "  |  Windows Forms  |  INF-5130\\" + p.Carpeta + "  |  " + p.Conceptos;
        }

        private void ucFormulario_Load(object sender, EventArgs e)
        {
            AbrirFormulario();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            AbrirFormulario();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Volver?.Invoke();
        }

        private void AbrirFormulario()
        {
            if (proyecto.AbrirAparte)
            {
                AbrirEnOtraVentana();
                return;
            }

            // Si ya había uno abierto, se cierra primero
            if (formulario != null)
            {
                formulario.Close();
                formulario = null;
            }

            try
            {
                formulario = proyecto.CrearFormulario();
                formulario.TopLevel = false;   // para que pueda ir dentro del panel
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Location = new Point(0, 0);
                pnlFormulario.Controls.Add(formulario);
                formulario.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el formulario.\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Para formularios grandes: se abren en su propia ventana, con su tamaño original
        private void AbrirEnOtraVentana()
        {
            // Si la ventana ya está abierta, solo se trae al frente (no se abre otra)
            if (formulario != null && !formulario.IsDisposed)
            {
                formulario.WindowState = FormWindowState.Normal;
                formulario.Activate();
                return;
            }

            try
            {
                formulario = proyecto.CrearFormulario();
                formulario.StartPosition = FormStartPosition.CenterScreen;
                formulario.FormClosed += (s, e) => formulario = null;
                formulario.Show(ParentForm);   // se cierra junto con el programa
            }
            catch (Exception ex)
            {
                formulario = null;
                MessageBox.Show("No se pudo abrir el formulario.\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // En el panel solo queda un aviso
            if (pnlFormulario.Controls.Count == 0)
            {
                Label aviso = new Label();
                aviso.AutoSize = true;
                aviso.Location = new Point(15, 15);
                aviso.Text = "Este proyecto es más grande que el espacio disponible, por eso se abre en su propia ventana.\n" +
                             "Si la cerró, pulse \"Abrir ventana\" para abrirla otra vez.";
                pnlFormulario.Controls.Add(aviso);
            }
            btnAbrir.Text = "Abrir ventana";
        }
    }
}
