namespace ProyectoIntegradorPOO
{
    public partial class ucUnidad : UserControl
    {
        // Avisa al Menu qué proyecto se quiere abrir
        public event Action<Proyecto> AbrirProyecto;

        public ucUnidad()
        {
            InitializeComponent();
        }

        // Muestra los proyectos de la unidad que se eligió en el menú
        public void Cargar(int unidad)
        {
            lblTitulo.Text = Proyectos.Unidades[unidad - 1];

            lstProyectos.Items.Clear();
            foreach (Proyecto p in Proyectos.DeUnidad(unidad))
            {
                lstProyectos.Items.Add(p);
            }

            if (lstProyectos.Items.Count > 0)
                lstProyectos.SelectedIndex = 0;
        }

        private void lstProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Proyecto proyecto = lstProyectos.SelectedItem as Proyecto;
            if (proyecto == null) return;

            lblTipo.Text = proyecto.Tipo;
            lblCarpeta.Text = "INF-5130\\" + proyecto.Carpeta;
            lblConceptos.Text = proyecto.Conceptos;
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            Proyecto proyecto = lstProyectos.SelectedItem as Proyecto;
            if (proyecto == null)
            {
                MessageBox.Show("Seleccione un proyecto de la lista.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            AbrirProyecto?.Invoke(proyecto);
        }

        private void lstProyectos_DoubleClick(object sender, EventArgs e)
        {
            btnAbrir_Click(sender, e);
        }
    }
}
