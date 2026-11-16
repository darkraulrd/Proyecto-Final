namespace ProyectoIntegradorPOO
{
    public partial class ucUnidad : UserControl
    {
        // El Menu escucha este aviso y abre el proyecto
        public event Action<ProyectoCurso>? ProyectoSolicitado;

        public ucUnidad()
        {
            InitializeComponent();

            dgvProyectos.AutoGenerateColumns = false;
            dgvProyectos.CellContentClick += (s, e) =>
            {
                if (e.RowIndex >= 0 && dgvProyectos.Columns[e.ColumnIndex].Name == "Abrir")
                    Solicitar(e.RowIndex);
            };
            dgvProyectos.CellDoubleClick += (s, e) => Solicitar(e.RowIndex);

            // Al terminar de cargar la tabla, ninguna fila queda marcada
            dgvProyectos.DataBindingComplete += (s, e) =>
            {
                dgvProyectos.ClearSelection();
                dgvProyectos.CurrentCell = null;
            };
        }

        // Muestra los proyectos de la unidad elegida en el menú
        public void Cargar(Unidad unidad)
        {
            var proyectos = Proyectos.DeUnidad(unidad.Numero);

            lblTitulo.Text = unidad.TituloCompleto;
            dgvProyectos.DataSource = proyectos;
            dgvProyectos.ClearSelection();
            lblTotal.Text = $"{proyectos.Count} " + (proyectos.Count == 1 ? "proyecto" : "proyectos");
        }

        private void Solicitar(int fila)
        {
            if (fila < 0) return;
            if (dgvProyectos.Rows[fila].DataBoundItem is not ProyectoCurso proyecto) return;
            ProyectoSolicitado?.Invoke(proyecto);
        }
    }
}
