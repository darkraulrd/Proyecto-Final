using System.ComponentModel;

namespace ProyectoIntegradorPOO
{
    public partial class ucInicio : UserControl
    {
        // El Menu escucha este aviso y abre el proyecto
        public event Action<ProyectoCurso>? ProyectoSolicitado;

        public ucInicio()
        {
            InitializeComponent();

            dgvProyectos.AutoGenerateColumns = false;
            dgvProyectos.CellContentClick += dgvProyectos_CellContentClick;
            dgvProyectos.CellDoubleClick += (s, e) => Solicitar(e.RowIndex);

            btnBuscar.Click += (s, e) => Recargar();
            txtBuscar.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    Recargar();
                }
            };

            VisibleChanged += (s, e) => { if (Visible) Recargar(); };
        }

        public void Recargar()
        {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            var proyectos = Proyectos.Buscar(txtBuscar.Text.Trim());

            dgvProyectos.DataSource = proyectos;
            dgvProyectos.ClearSelection();

            lblSubtitulo.Text = $"{InformacionAplicacion.Asignatura} · {InformacionAplicacion.Desarrollador} ({InformacionAplicacion.Matricula}) · " +
                                "Elige un proyecto para abrirlo aquí mismo.";
            lblTotal.Text = $"{proyectos.Count} " +
                (proyectos.Count == 1 ? "proyecto enlazado" : "proyectos enlazados") +
                $"  ·  {Proyectos.Unidades.Count} unidades";
        }

        private void dgvProyectos_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvProyectos.Columns[e.ColumnIndex].Name != "Abrir") return;
            Solicitar(e.RowIndex);
        }

        private void Solicitar(int fila)
        {
            if (fila < 0) return;
            if (dgvProyectos.Rows[fila].DataBoundItem is not ProyectoCurso proyecto) return;
            ProyectoSolicitado?.Invoke(proyecto);
        }
    }
}
