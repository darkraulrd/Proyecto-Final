using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ProyectoIntegradorPOO
{
    // Muestra un proyecto de consola dentro del programa.
    // Se abre el .exe en una consola de Windows y esa ventana se pone dentro de pnlConsola.
    public partial class ucConsola : UserControl
    {
        // Funciones de Windows para meter la ventana de la consola dentro del panel
        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr hijo, IntPtr padre);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr ventana, int indice, int valor);

        [DllImport("user32.dll")]
        private static extern bool MoveWindow(IntPtr ventana, int x, int y, int ancho, int alto, bool repintar);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr ventana, int modo);

        private const int GWL_STYLE = -16;
        private const int WS_CHILD = 0x40000000;
        private const int WS_VISIBLE = 0x10000000;

        // Todas las consolas abiertas, para cerrarlas al salir
        private static List<Process> consolasAbiertas = new List<Process>();

        private Proyecto proyecto;
        private Process programa;
        private IntPtr ventanaConsola = IntPtr.Zero;

        // Avisa al Menu que se quiere volver a la unidad
        public event Action Volver;

        public ucConsola()
        {
            InitializeComponent();
        }

        public void Cargar(Proyecto p)
        {
            proyecto = p;
            lblTitulo.Text = p.Nombre;
            lblDatos.Text = "Unidad " + p.Unidad + "  |  Consola  |  INF-5130\\" + p.Carpeta + "  |  " + p.Conceptos;
        }

        private void ucConsola_Load(object sender, EventArgs e)
        {
            // La primera vez que se abre la pantalla, el programa se ejecuta solo
            Ejecutar();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            Ejecutar();
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            Detener();
            lblEstado.Text = "Programa detenido. Pulse Ejecutar para iniciarlo de nuevo.";
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Volver?.Invoke();
        }

        private void Ejecutar()
        {
            Detener();

            if (!File.Exists(proyecto.RutaEjecutable))
            {
                MessageBox.Show("No se encontró el programa:\n" + proyecto.RutaEjecutable +
                    "\n\nCompile la solución completa e intente de nuevo.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblEstado.Text = "Iniciando...";
            Cursor = Cursors.WaitCursor;

            // conhost es la consola clásica de Windows (esa sí se puede meter dentro de otra ventana)
            DateTime inicio = DateTime.Now.AddSeconds(-1);
            ProcessStartInfo info = new ProcessStartInfo("conhost.exe", "\"" + proyecto.RutaEjecutable + "\"");
            info.UseShellExecute = true;
            info.WorkingDirectory = Path.GetDirectoryName(proyecto.RutaEjecutable);
            info.WindowStyle = ProcessWindowStyle.Minimized;
            Process.Start(info);

            // Esperar (máximo 8 segundos) a que aparezca la ventana del programa
            for (int i = 0; i < 80 && programa == null; i++)
            {
                Thread.Sleep(100);
                Application.DoEvents();
                programa = BuscarPrograma(inicio);
            }

            Cursor = Cursors.Default;

            if (programa == null)
            {
                lblEstado.Text = "No se pudo abrir la consola. Pulse Ejecutar para intentarlo de nuevo.";
                return;
            }

            consolasAbiertas.Add(programa);
            ventanaConsola = programa.MainWindowHandle;

            // Quitar bordes y barra de título, y meterla en el panel
            SetWindowLong(ventanaConsola, GWL_STYLE, WS_CHILD | WS_VISIBLE);
            SetParent(ventanaConsola, pnlConsola.Handle);
            ShowWindow(ventanaConsola, 1);
            AjustarTamano();

            lblEstado.Text = proyecto.Ejecutable + ".exe en ejecución. Haga clic en la consola para escribir.";
        }

        // Busca el proceso que se acaba de abrir y que ya tiene ventana
        private Process BuscarPrograma(DateTime inicio)
        {
            foreach (Process p in Process.GetProcessesByName(proyecto.Ejecutable))
            {
                try
                {
                    bool yaAbierta = consolasAbiertas.Exists(x => x.Id == p.Id);
                    if (p.StartTime >= inicio && !yaAbierta)
                    {
                        p.Refresh();
                        if (p.MainWindowHandle != IntPtr.Zero)
                            return p;
                    }
                }
                catch (Exception)
                {
                    // no se pudo leer ese proceso, se ignora
                }
            }
            return null;
        }

        private void AjustarTamano()
        {
            if (ventanaConsola != IntPtr.Zero)
                MoveWindow(ventanaConsola, 0, 0, pnlConsola.ClientSize.Width, pnlConsola.ClientSize.Height, true);
        }

        private void pnlConsola_Resize(object sender, EventArgs e)
        {
            AjustarTamano();
        }

        private void Detener()
        {
            if (programa != null)
            {
                try
                {
                    if (!programa.HasExited)
                        programa.Kill(true);
                }
                catch (Exception)
                {
                    // ya se había cerrado
                }
                consolasAbiertas.Remove(programa);
                programa = null;
            }
            ventanaConsola = IntPtr.Zero;
        }

        // Se llama al salir del programa
        public static void CerrarTodas()
        {
            foreach (Process p in consolasAbiertas)
            {
                try
                {
                    if (!p.HasExited)
                        p.Kill(true);
                }
                catch (Exception)
                {
                }
            }
            consolasAbiertas.Clear();
        }
    }
}
