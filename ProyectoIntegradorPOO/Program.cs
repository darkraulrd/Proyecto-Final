using ProyectoIntegradorPOO.Forms;
using ProyectoIntegradorPOO.Forms.Comun;

namespace ProyectoIntegradorPOO;

static class Program
{
    /// <summary>Punto de entrada de la aplicación.</summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        // Último recurso: cualquier excepción no controlada se informa sin cerrar la aplicación.
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        Application.ThreadException += (_, e) =>
            Mensajes.Error($"Ocurrió un error inesperado:\n\n{e.Exception.Message}", "Error inesperado");

        Application.Run(new FrmPrincipal());
    }
}
