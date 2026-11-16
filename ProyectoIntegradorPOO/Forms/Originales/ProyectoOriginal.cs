using System.Reflection;

namespace ProyectoIntegradorPOO.Forms.Originales;

public enum TipoProyectoOriginal
{
    Consola,
    WindowsForms
}

/// <summary>
/// Un proyecto entregado durante el curso que vive en su propia carpeta dentro de INF-5130.
/// El integrador no lo copia: lo enlaza y lo muestra dentro de un UserControl.
/// </summary>
/// <param name="Nombre">Nombre visible (el de la carpeta del proyecto).</param>
/// <param name="Carpeta">Carpeta del proyecto, relativa a INF-5130.</param>
/// <param name="Ensamblado">Nombre del ejecutable (sin .exe) para los proyectos de consola.</param>
/// <param name="CrearFormulario">Crea el formulario principal de los proyectos Windows Forms.</param>
public sealed record ProyectoOriginal(string Nombre, string Carpeta, TipoProyectoOriginal Tipo, string Ensamblado = "", Func<Form>? CrearFormulario = null)
{
    public string RutaCarpeta => Path.Combine(UbicacionProyectos.CarpetaCurso, Carpeta);

    /// <summary>Ejecutable que genera la compilación del proyecto original (solo consola).</summary>
    public string RutaEjecutable =>
        Path.Combine(RutaCarpeta, "bin", UbicacionProyectos.Configuracion, "net10.0", Ensamblado + ".exe");
}

/// <summary>
/// Ubicación de la carpeta del curso. El valor lo escribe MSBuild al compilar
/// (AssemblyMetadata en ProyectoIntegradorPOO.csproj), así no hay rutas fijas en el código.
/// </summary>
public static class UbicacionProyectos
{
    public static string CarpetaCurso { get; } = LeerMetadato("CarpetaCurso") ?? AppContext.BaseDirectory;

    public static string Configuracion { get; } = LeerMetadato("Configuracion") ?? "Debug";

    private static string? LeerMetadato(string clave) =>
        typeof(UbicacionProyectos).Assembly
            .GetCustomAttributes<AssemblyMetadataAttribute>()
            .FirstOrDefault(a => a.Key == clave)?.Value;
}
