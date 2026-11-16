using System.IO;
using System.Windows.Forms;

namespace ProyectoIntegradorPOO
{
    // Proyecto de consola: se ejecuta su .exe dentro de ucConsola
    public class ProyectoConsola : ProyectoCurso
    {
        // Nombre del ejecutable sin ".exe" (por defecto, el del .csproj)
        public string Ejecutable { get; init; } = "";

        // El .exe que deja la compilación del proyecto original
        public string RutaEjecutable =>
            Path.Combine(RutaCarpeta, "bin", Proyectos.Configuracion, "net10.0", Ejecutable + ".exe");

        public override string Tipo => "Consola";

        public override UserControl CrearVista()
        {
            var vista = new ucConsola();
            vista.Cargar(this);
            return vista;
        }
    }
}
