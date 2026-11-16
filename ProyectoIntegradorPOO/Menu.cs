namespace ProyectoIntegradorPOO
{
    public partial class Menu : Form
    {
        // Las pantallas se crean una sola vez y se reutilizan
        private ucInicio vistaInicio = new ucInicio();
        private ucUnidad vistaUnidad = new ucUnidad();

        // Cada proyecto tiene su propia pantalla (así la consola no se cierra al cambiar de pantalla)
        private Dictionary<Proyecto, UserControl> vistasProyecto = new Dictionary<Proyecto, UserControl>();

        public Menu()
        {
            InitializeComponent();

            vistaInicio.AbrirProyecto += AbrirProyecto;
            vistaUnidad.AbrirProyecto += AbrirProyecto;

            Mostrar(vistaInicio);
        }

        // Pone una pantalla en el panel de la derecha
        private void Mostrar(UserControl vista)
        {
            pnlContenido.Controls.Clear();
            vista.Dock = DockStyle.Fill;
            pnlContenido.Controls.Add(vista);
        }

        private void MostrarUnidad(int unidad)
        {
            vistaUnidad.Cargar(unidad);
            Mostrar(vistaUnidad);
        }

        private void AbrirProyecto(Proyecto proyecto)
        {
            // Si ya se abrió antes, se usa la misma pantalla
            if (vistasProyecto.ContainsKey(proyecto))
            {
                Mostrar(vistasProyecto[proyecto]);
                return;
            }

            if (proyecto.EsConsola)
            {
                ucConsola consola = new ucConsola();
                consola.Cargar(proyecto);
                consola.Volver += () => MostrarUnidad(proyecto.Unidad);
                vistasProyecto.Add(proyecto, consola);
                Mostrar(consola);
            }
            else
            {
                ucFormulario formulario = new ucFormulario();
                formulario.Cargar(proyecto);
                formulario.Volver += () => MostrarUnidad(proyecto.Unidad);
                vistasProyecto.Add(proyecto, formulario);
                Mostrar(formulario);
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            Mostrar(vistaInicio);
        }

        private void btnUnidad1_Click(object sender, EventArgs e)
        {
            MostrarUnidad(1);
        }

        private void btnUnidad2_Click(object sender, EventArgs e)
        {
            MostrarUnidad(2);
        }

        private void btnUnidad3_Click(object sender, EventArgs e)
        {
            MostrarUnidad(3);
        }

        private void btnUnidad4_Click(object sender, EventArgs e)
        {
            MostrarUnidad(4);
        }

        private void btnUnidad5_Click(object sender, EventArgs e)
        {
            MostrarUnidad(5);
        }

        private void btnUnidad6_Click(object sender, EventArgs e)
        {
            MostrarUnidad(6);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea salir del programa?", "Salir",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            // Cierra las consolas que hayan quedado abiertas
            ucConsola.CerrarTodas();
        }
    }
}
