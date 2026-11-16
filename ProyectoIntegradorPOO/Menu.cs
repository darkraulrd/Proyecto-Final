namespace ProyectoIntegradorPOO
{
    public partial class Menu : Form
    {
        private static readonly Color ColorActivo = Color.FromArgb(37, 99, 235);

        // Una sola pantalla de unidad: se recarga con la unidad elegida
        private readonly ucUnidad vistaUnidad = new ucUnidad();

        // Cada proyecto tiene su propia pantalla; se crea la primera vez y se reutiliza
        // (así una consola sigue en ejecución aunque cambies de pantalla)
        private readonly Dictionary<ProyectoCurso, UserControl> vistasProyecto = new Dictionary<ProyectoCurso, UserControl>();

        private readonly Button[] botonesUnidad;
        private readonly Button[] botones;

        public Menu()
        {
            InitializeComponent();

            botonesUnidad = new[] { btnUnidad1, btnUnidad2, btnUnidad3, btnUnidad4, btnUnidad5, btnUnidad6 };
            botones = new[] { btnMenuInicio }.Concat(botonesUnidad).ToArray();

            btnMenuInicio.Click += (s, e) => Mostrar(ucInicio1, btnMenuInicio);
            for (int i = 0; i < botonesUnidad.Length; i++)
            {
                int numero = i + 1;   // copia para la lambda
                botonesUnidad[i].Click += (s, e) => MostrarUnidad(numero);
            }
            btnSalir.Click += (s, e) => PedirSalir();

            // Desde Inicio o desde una unidad: abrir un proyecto
            ucInicio1.ProyectoSolicitado += AbrirProyecto;
            vistaUnidad.ProyectoSolicitado += AbrirProyecto;

            // Al cerrar, también se cierran las consolas abiertas
            FormClosed += (s, e) =>
            {
                foreach (UserControl vista in vistasProyecto.Values)
                    vista.Dispose();
                ucConsola.TerminarTodas();
            };

            Text = $"{InformacionAplicacion.Nombre} — {InformacionAplicacion.Asignatura}";
            Mostrar(ucInicio1, btnMenuInicio);
        }

        private void MostrarUnidad(int numero)
        {
            vistaUnidad.Cargar(Proyectos.BuscarUnidad(numero));
            Mostrar(vistaUnidad, botonesUnidad[numero - 1]);
        }

        private void AbrirProyecto(ProyectoCurso proyecto)
        {
            if (!vistasProyecto.TryGetValue(proyecto, out UserControl? vista))
            {
                vista = proyecto.CrearVista();   // cada tipo de proyecto crea su pantalla

                // "Volver" regresa a la unidad del proyecto
                if (vista is ucConsola consola) consola.VolverSolicitado += () => MostrarUnidad(proyecto.Unidad);
                if (vista is ucFormulario formulario) formulario.VolverSolicitado += () => MostrarUnidad(proyecto.Unidad);

                vistasProyecto[proyecto] = vista;
            }

            Mostrar(vista, botonesUnidad[proyecto.Unidad - 1]);
        }

        private void Mostrar(UserControl vista, Button activo)
        {
            pnlContenido.Controls.Clear();   // quita la vista anterior sin destruirla
            vista.Dock = DockStyle.Fill;
            pnlContenido.Controls.Add(vista);

            foreach (Button boton in botones)
                boton.BackColor = pnlMenu.BackColor;
            activo.BackColor = ColorActivo;
        }

        private void PedirSalir()
        {
            var respuesta = MessageBox.Show("¿Deseas salir del Sistema Integrador?", "Salir",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
                Close();
        }
    }
}
