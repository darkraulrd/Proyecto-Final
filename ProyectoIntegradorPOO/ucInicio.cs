namespace ProyectoIntegradorPOO
{
    public partial class ucInicio : UserControl
    {
        // Avisa al Menu qué proyecto se quiere abrir
        public event Action<Proyecto> AbrirProyecto;

        public ucInicio()
        {
            InitializeComponent();
        }

        private void ucInicio_Load(object sender, EventArgs e)
        {
            dgvProyectos.AutoGenerateColumns = false;
            dgvProyectos.DataSource = Proyectos.Lista;
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (dgvProyectos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un proyecto de la lista.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Proyecto proyecto = (Proyecto)dgvProyectos.CurrentRow.DataBoundItem;
            AbrirProyecto?.Invoke(proyecto);
        }

        private void dgvProyectos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnAbrir_Click(sender, e);
        }
    }
}
