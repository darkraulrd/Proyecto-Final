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
    }
}
