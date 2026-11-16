using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ProyectoIntegradorPOO.Forms.Comun;

namespace ProyectoIntegradorPOO.Forms.Originales;

/// <summary>
/// UserControl que ejecuta un programa de consola ORIGINAL dentro de la aplicación.
/// Abre el .exe en una consola real de Windows (conhost) y coloca su ventana dentro de
/// pnlConsola, de modo que Console.ReadLine, ReadKey, Clear y las tildes funcionan igual
/// que al ejecutarlo por separado.
/// </summary>
public partial class UcConsolaIncrustada : UserControl
{
    private static readonly string ConHost = Path.Combine(Environment.SystemDirectory, "conhost.exe");
    private static readonly List<Process> ProgramasAbiertos = new List<Process>();

    private Process? programa;
    private IntPtr ventanaConsola;
    private bool iniciadoAutomaticamente;
    private bool iniciando;

    static UcConsolaIncrustada()
    {
        // Al cerrar la aplicación (de forma normal o no) no deben quedar consolas huérfanas.
        Application.ApplicationExit += (_, _) => TerminarTodos();
        AppDomain.CurrentDomain.ProcessExit += (_, _) => TerminarTodos();
    }

    /// <summary>Cierra todos los programas de consola abiertos por el integrador.</summary>
    public static void TerminarTodos()
    {
        foreach (Process proceso in ProgramasAbiertos.ToList())
            Terminar(proceso);
        ProgramasAbiertos.Clear();
    }

    public UcConsolaIncrustada()
    {
        InitializeComponent();
    }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string RutaEjecutable { get; set; } = "";

    public bool EnEjecucion => programa is { HasExited: false };

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        // La primera vez que se muestra, el programa arranca solo.
        if (!iniciadoAutomaticamente && !DesignMode)
        {
            iniciadoAutomaticamente = true;
            BeginInvoke(new Action(async () => await EjecutarAsync()));
        }
    }

    private async void btnEjecutar_Click(object? sender, EventArgs e) => await EjecutarAsync();

    private void btnDetener_Click(object? sender, EventArgs e)
    {
        Detener();
        MostrarAviso("Programa detenido. Pulsa «Ejecutar» para iniciarlo de nuevo.");
        ActualizarBotones();
    }

    public async Task EjecutarAsync()
    {
        if (iniciando) return;
        iniciando = true;
        Detener();
        ActualizarBotones();

        try
        {
            if (!File.Exists(RutaEjecutable))
            {
                MostrarAviso($"No se encontró el ejecutable del proyecto original:\n{RutaEjecutable}\n\n" +
                             "Compile la solución completa (Compilar → Compilar solución) y vuelva a intentarlo.");
                lblEstado.Text = "Ejecutable no encontrado";
                return;
            }

            MostrarAviso("Iniciando el programa original…");
            lblEstado.Text = Path.GetFileName(RutaEjecutable);

            Process? encontrado = await IniciarEnConsolaAsync(RutaEjecutable);
            if (encontrado is null)
            {
                MostrarAviso("No se pudo obtener la ventana de la consola. Pulsa «Ejecutar» para intentarlo de nuevo.");
                return;
            }

            programa = encontrado;
            ProgramasAbiertos.Add(programa);
            programa.EnableRaisingEvents = true;
            programa.Exited += Programa_Exited;

            Incrustar(programa.MainWindowHandle);
            lblEstado.Text = $"{Path.GetFileName(RutaEjecutable)} en ejecución · haz clic en la consola para escribir";
        }
        catch (Exception ex)
        {
            MostrarAviso($"No se pudo ejecutar el programa original.\n\n{ex.Message}");
        }
        finally
        {
            iniciando = false;
            ActualizarBotones();
        }
    }

    /// <summary>
    /// Inicia el programa con conhost (la consola clásica de Windows, que sí permite
    /// incrustarse) y espera a que aparezca la ventana del proceso hijo.
    /// </summary>
    private static async Task<Process?> IniciarEnConsolaAsync(string rutaExe)
    {
        DateTime inicio = DateTime.Now.AddSeconds(-1);
        string nombreProceso = Path.GetFileNameWithoutExtension(rutaExe);

        Process? consola = Process.Start(new ProcessStartInfo(ConHost, $"\"{rutaExe}\"")
        {
            UseShellExecute = true,
            WorkingDirectory = Path.GetDirectoryName(rutaExe)!,
            WindowStyle = ProcessWindowStyle.Minimized   // evita que la consola aparezca suelta un instante
        });

        for (int intento = 0; intento < 80; intento++)
        {
            await Task.Delay(100);
            foreach (Process candidato in Process.GetProcessesByName(nombreProceso))
            {
                if (ProgramasAbiertos.Any(p => p.Id == candidato.Id) || !IniciadoDespuesDe(candidato, inicio))
                    continue;

                candidato.Refresh();
                if (candidato.MainWindowHandle != IntPtr.Zero)
                    return candidato;
            }
        }

        if (consola is not null) Terminar(consola);
        return null;
    }

    private static bool IniciadoDespuesDe(Process proceso, DateTime inicio)
    {
        try { return proceso.StartTime >= inicio; }
        catch (Exception ex) when (ex is Win32Exception || ex is InvalidOperationException) { return false; }
    }

    private void Incrustar(IntPtr ventana)
    {
        ventanaConsola = ventana;

        // La ventana de la consola pasa a ser hija del panel: sin barra de título ni bordes.
        long estilo = (long)ApiVentanas.GetWindowLongPtr(ventana, ApiVentanas.GWL_STYLE);
        estilo &= ~(ApiVentanas.WS_CAPTION | ApiVentanas.WS_THICKFRAME | ApiVentanas.WS_SYSMENU |
                    ApiVentanas.WS_MINIMIZEBOX | ApiVentanas.WS_MAXIMIZEBOX | ApiVentanas.WS_POPUP);
        estilo |= ApiVentanas.WS_CHILD;
        ApiVentanas.SetWindowLongPtr(ventana, ApiVentanas.GWL_STYLE, (IntPtr)estilo);

        ApiVentanas.SetParent(ventana, pnlConsola.Handle);
        ApiVentanas.ShowWindow(ventana, ApiVentanas.SW_SHOWNORMAL);
        lblAviso.Visible = false;
        AjustarTamano();
    }

    private void AjustarTamano()
    {
        if (ventanaConsola != IntPtr.Zero)
            ApiVentanas.MoveWindow(ventanaConsola, 0, 0, pnlConsola.ClientSize.Width, pnlConsola.ClientSize.Height, true);
    }

    private void pnlConsola_Resize(object? sender, EventArgs e) => AjustarTamano();

    private void Programa_Exited(object? sender, EventArgs e)
    {
        if (IsDisposed || !IsHandleCreated) return;
        BeginInvoke(new Action(() =>
        {
            int codigo = 0;
            try { codigo = programa?.ExitCode ?? 0; } catch (InvalidOperationException) { }
            LiberarPrograma();
            MostrarAviso($"El programa terminó (código de salida {codigo}).\nPulsa «Ejecutar» para iniciarlo de nuevo.");
            lblEstado.Text = "Programa finalizado";
            ActualizarBotones();
        }));
    }

    public void Detener()
    {
        if (programa is not null)
        {
            programa.Exited -= Programa_Exited;
            Terminar(programa);
        }
        LiberarPrograma();
    }

    private void LiberarPrograma()
    {
        if (programa is not null)
        {
            ProgramasAbiertos.Remove(programa);
            programa.Dispose();
        }
        programa = null;
        ventanaConsola = IntPtr.Zero;
    }

    private static void Terminar(Process proceso)
    {
        try
        {
            if (!proceso.HasExited)
                proceso.Kill(entireProcessTree: true);
        }
        catch (Exception ex) when (ex is InvalidOperationException || ex is Win32Exception)
        {
            // El proceso ya había terminado.
        }
    }

    private void MostrarAviso(string texto)
    {
        lblAviso.Text = texto;
        lblAviso.Visible = true;
    }

    private void ActualizarBotones()
    {
        btnEjecutar.Enabled = !iniciando;
        btnEjecutar.Text = EnEjecucion ? "Reiniciar" : "Ejecutar";
        btnDetener.Enabled = EnEjecucion;
    }

    /// <summary>Funciones de Windows (user32) para incrustar una ventana de otro proceso.</summary>
    private static class ApiVentanas
    {
        public const int GWL_STYLE = -16;
        public const long WS_CHILD = 0x40000000L;
        public const long WS_POPUP = 0x80000000L;
        public const long WS_CAPTION = 0x00C00000L;
        public const long WS_THICKFRAME = 0x00040000L;
        public const long WS_SYSMENU = 0x00080000L;
        public const long WS_MINIMIZEBOX = 0x00020000L;
        public const long WS_MAXIMIZEBOX = 0x00010000L;
        public const int SW_SHOWNORMAL = 1;

        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtrW")]
        public static extern IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtrW")]
        public static extern IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int ancho, int alto, bool repintar);
    }
}
