using System.ComponentModel;
using System.Diagnostics;

namespace ProyectoIntegradorPOO
{
    // Ejecuta un proyecto de consola dentro de la aplicación.
    // El .exe se abre en una consola real de Windows (conhost) y su ventana se mete
    // dentro de pnlConsola: así ReadLine, ReadKey, Clear y las tildes funcionan igual
    // que al abrir el proyecto por separado.
    public partial class ucConsola : UserControl
    {
        private static readonly string ConHost = Path.Combine(Environment.SystemDirectory, "conhost.exe");
        private static readonly List<Process> Abiertas = new List<Process>();

        private ProyectoConsola? proyecto;
        private Process? programa;
        private IntPtr ventana;
        private bool iniciando;
        private bool yaArranco;

        // El Menu escucha este aviso y regresa a la unidad
        public event Action? VolverSolicitado;

        static ucConsola()
        {
            // Si el programa termina de cualquier forma, no deben quedar consolas abiertas
            AppDomain.CurrentDomain.ProcessExit += (s, e) => TerminarTodas();
        }

        public ucConsola()
        {
            InitializeComponent();

            btnEjecutar.Click += async (s, e) => await EjecutarAsync();
            btnDetener.Click += (s, e) =>
            {
                Detener();
                MostrarAviso("Programa detenido. Pulsa «Ejecutar» para iniciarlo de nuevo.");
                ActualizarBotones();
            };
            btnVolver.Click += (s, e) => VolverSolicitado?.Invoke();
            pnlConsola.Resize += (s, e) => Ajustar();

            // La primera vez que se muestra, el programa arranca solo
            Load += (s, e) =>
            {
                if (yaArranco || DesignMode) return;
                yaArranco = true;
                BeginInvoke(new Action(async () => await EjecutarAsync()));
            };

            ActualizarBotones();
        }

        public void Cargar(ProyectoConsola proyecto)
        {
            this.proyecto = proyecto;
            lblTitulo.Text = proyecto.Nombre;
            lblSubtitulo.Text = $"Unidad {proyecto.Unidad} · Consola · {proyecto.UbicacionTexto} · {proyecto.Conceptos}";
        }

        public static void TerminarTodas()
        {
            foreach (Process p in Abiertas.ToList())
                Terminar(p);
            Abiertas.Clear();
        }

        private async Task EjecutarAsync()
        {
            if (iniciando || proyecto == null) return;
            iniciando = true;
            Detener();
            ActualizarBotones();

            try
            {
                string ruta = proyecto.RutaEjecutable;
                if (!File.Exists(ruta))
                {
                    MostrarAviso("No se encontró el ejecutable del proyecto:\n" + ruta +
                                 "\n\nCompila la solución completa y vuelve a intentarlo.");
                    lblEstado.Text = "Ejecutable no encontrado";
                    return;
                }

                MostrarAviso("Iniciando " + proyecto.Nombre + "…");
                Process? encontrado = await IniciarAsync(ruta);
                if (encontrado == null)
                {
                    MostrarAviso("No se pudo abrir la consola. Pulsa «Ejecutar» para intentarlo de nuevo.");
                    return;
                }

                programa = encontrado;
                Abiertas.Add(programa);
                programa.EnableRaisingEvents = true;
                programa.Exited += Programa_Exited;

                Incrustar(programa.MainWindowHandle);
                lblEstado.Text = Path.GetFileName(ruta) + " en ejecución · haz clic en la consola para escribir";
            }
            catch (Exception ex)
            {
                MostrarAviso("No se pudo ejecutar el proyecto.\n\n" + ex.Message);
            }
            finally
            {
                iniciando = false;
                ActualizarBotones();
            }
        }

        // Abre el .exe con conhost (la consola clásica, que sí se puede meter en otra ventana)
        // y espera a que aparezca la ventana del programa
        private static async Task<Process?> IniciarAsync(string ruta)
        {
            DateTime inicio = DateTime.Now.AddSeconds(-1);
            string nombre = Path.GetFileNameWithoutExtension(ruta);

            Process? consola = Process.Start(new ProcessStartInfo(ConHost, $"\"{ruta}\"")
            {
                UseShellExecute = true,
                WorkingDirectory = Path.GetDirectoryName(ruta)!,
                WindowStyle = ProcessWindowStyle.Minimized   // que no aparezca suelta un instante
            });

            for (int intento = 0; intento < 80; intento++)
            {
                await Task.Delay(100);
                foreach (Process candidato in Process.GetProcessesByName(nombre))
                {
                    if (Abiertas.Any(p => p.Id == candidato.Id) || !EmpezoDespues(candidato, inicio)) continue;

                    candidato.Refresh();
                    if (candidato.MainWindowHandle != IntPtr.Zero) return candidato;
                }
            }

            if (consola != null) Terminar(consola);
            return null;
        }

        private static bool EmpezoDespues(Process proceso, DateTime inicio)
        {
            try { return proceso.StartTime >= inicio; }
            catch (Exception ex) when (ex is Win32Exception || ex is InvalidOperationException) { return false; }
        }

        // La ventana de la consola pasa a ser hija del panel, sin barra de título ni bordes
        private void Incrustar(IntPtr ventanaConsola)
        {
            ventana = ventanaConsola;

            long estilo = (long)Ventanas.GetWindowLongPtr(ventana, Ventanas.GWL_STYLE);
            estilo &= ~(Ventanas.WS_CAPTION | Ventanas.WS_THICKFRAME | Ventanas.WS_SYSMENU |
                        Ventanas.WS_MINIMIZEBOX | Ventanas.WS_MAXIMIZEBOX | Ventanas.WS_POPUP);
            estilo |= Ventanas.WS_CHILD;
            Ventanas.SetWindowLongPtr(ventana, Ventanas.GWL_STYLE, (IntPtr)estilo);

            Ventanas.SetParent(ventana, pnlConsola.Handle);
            Ventanas.ShowWindow(ventana, Ventanas.SW_SHOWNORMAL);
            lblAviso.Visible = false;
            Ajustar();
        }

        private void Ajustar()
        {
            if (ventana != IntPtr.Zero)
                Ventanas.MoveWindow(ventana, 0, 0, pnlConsola.ClientSize.Width, pnlConsola.ClientSize.Height, true);
        }

        private void Programa_Exited(object? sender, EventArgs e)
        {
            if (IsDisposed || !IsHandleCreated) return;
            BeginInvoke(new Action(() =>
            {
                Liberar();
                MostrarAviso("El programa terminó.\nPulsa «Ejecutar» para iniciarlo de nuevo.");
                lblEstado.Text = "Programa finalizado";
                ActualizarBotones();
            }));
        }

        public void Detener()
        {
            if (programa != null)
            {
                programa.Exited -= Programa_Exited;
                Terminar(programa);
            }
            Liberar();
        }

        private void Liberar()
        {
            if (programa != null)
            {
                Abiertas.Remove(programa);
                programa.Dispose();
            }
            programa = null;
            ventana = IntPtr.Zero;
        }

        private static void Terminar(Process proceso)
        {
            try
            {
                if (!proceso.HasExited) proceso.Kill(entireProcessTree: true);
            }
            catch (Exception ex) when (ex is InvalidOperationException || ex is Win32Exception)
            {
                // ya había terminado
            }
        }

        private void MostrarAviso(string texto)
        {
            lblAviso.Text = texto;
            lblAviso.Visible = true;
        }

        private void ActualizarBotones()
        {
            bool enEjecucion = programa != null && !programa.HasExited;
            btnEjecutar.Enabled = !iniciando;
            btnEjecutar.Text = enEjecucion ? "Reiniciar" : "Ejecutar";
            btnDetener.Enabled = enEjecucion;
        }
    }
}
