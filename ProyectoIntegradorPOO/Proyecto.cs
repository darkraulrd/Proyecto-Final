namespace ProyectoIntegradorPOO
{
    // Un proyecto que hice en el curso. Está en su propia carpeta dentro de INF-5130.
    public class Proyecto
    {
        public int Unidad { get; set; }
        public string Nombre { get; set; } = "";
        public string Carpeta { get; set; } = "";       // carpeta dentro de INF-5130
        public string Conceptos { get; set; } = "";
        public bool EsConsola { get; set; }

        // Solo para los de consola: nombre del .exe
        public string Ejecutable { get; set; } = "";

        // Solo para los de Windows Forms: crea el formulario principal
        public Func<Form> CrearFormulario { get; set; }

        // Para formularios muy grandes: se abren en su propia ventana en vez de dentro del programa
        public bool AbrirAparte { get; set; }

        public string Tipo
        {
            get
            {
                if (EsConsola) return "Consola";
                return "Windows Forms";
            }
        }

        public string RutaCarpeta
        {
            get { return Path.Combine(Proyectos.CarpetaCurso, Carpeta); }
        }

        public string RutaEjecutable
        {
            get { return Path.Combine(RutaCarpeta, "bin", Proyectos.Configuracion, "net10.0", Ejecutable + ".exe"); }
        }

        // Así se ve en el ListBox
        public override string ToString()
        {
            return Nombre + " (" + Tipo + ")";
        }
    }
}
