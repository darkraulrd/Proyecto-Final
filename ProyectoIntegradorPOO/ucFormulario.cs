namespace ProyectoIntegradorPOO
{
    // Muestra el formulario original de un proyecto Windows Forms dentro de la aplicación,
    // con su diseño propio. Si se cierra (por ejemplo con su botón "Salir"), se puede abrir de nuevo.
    public partial class ucFormulario : UserControl
    {
        private ProyectoFormulario? proyecto;
        private Form? formulario;
        private bool yaAbrio;

        // El Menu escucha este aviso y regresa a la unidad
        public event Action? VolverSolicitado;

        public ucFormulario()
        {
            InitializeComponent();

            btnAbrir.Click += (s, e) => Abrir();
            btnVolver.Click += (s, e) => VolverSolicitado?.Invoke();

            // La primera vez que se muestra, el formulario se abre solo
            Load += (s, e) =>
            {
                if (yaAbrio || DesignMode) return;
                yaAbrio = true;
                BeginInvoke(new Action(Abrir));
            };
        }

        public void Cargar(ProyectoFormulario proyecto)
        {
            this.proyecto = proyecto;
            lblTitulo.Text = proyecto.Nombre;
            lblSubtitulo.Text = $"Unidad {proyecto.Unidad} · Windows Forms · {proyecto.UbicacionTexto} · {proyecto.Conceptos}";
        }

        private void Abrir()
        {
            Cerrar();
            if (proyecto?.CrearFormulario == null) return;

            try
            {
                formulario = proyecto.CrearFormulario();
                formulario.TopLevel = false;                     // deja de ser ventana suelta
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Location = new Point(32, 24);
                formulario.FormClosed += Formulario_FormClosed;

                pnlFormulario.Controls.Add(formulario);
                lblAviso.Visible = false;
                formulario.Show();

                lblEstado.Text = $"Formulario {formulario.GetType().FullName} · {formulario.ClientSize.Width} × {formulario.ClientSize.Height}";
                btnAbrir.Text = "Reiniciar";
            }
            catch (Exception ex)
            {
                formulario = null;
                MostrarAviso("No se pudo abrir el formulario.\n\n" + ex.Message);
            }
        }

        private void Formulario_FormClosed(object? sender, FormClosedEventArgs e)
        {
            formulario = null;
            MostrarAviso("El formulario se cerró.\nPulsa «Abrir» para usarlo de nuevo.");
            btnAbrir.Text = "Abrir";
        }

        private void Cerrar()
        {
            if (formulario == null) return;
            formulario.FormClosed -= Formulario_FormClosed;
            formulario.Close();
            formulario.Dispose();
            formulario = null;
        }

        private void MostrarAviso(string texto)
        {
            lblAviso.Text = texto;
            lblAviso.Visible = true;
            lblAviso.BringToFront();
        }
    }
}
