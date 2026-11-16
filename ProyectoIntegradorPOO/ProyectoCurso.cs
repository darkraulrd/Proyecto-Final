using System;
using System.IO;
using System.Windows.Forms;

namespace ProyectoIntegradorPOO
{
    // Un proyecto entregado en el curso. Vive en su propia carpeta dentro de INF-5130:
    // aquí no se copia, solo se enlaza y se muestra.
    public abstract class ProyectoCurso
    {
        private string nombre = "";
        private string carpeta = "";

        public int Unidad { get; init; }

        public string Nombre
        {
            get => nombre;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre del proyecto es obligatorio.");
                nombre = value.Trim();
            }
        }

        // Carpeta del proyecto, relativa a INF-5130 (por ejemplo "Nomina")
        public string Carpeta
        {
            get => carpeta;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La carpeta del proyecto es obligatoria.");
                carpeta = value.Trim();
            }
        }

        public string Conceptos { get; init; } = "";

        public string RutaCarpeta => Path.Combine(Proyectos.CarpetaCurso, Carpeta);

        // La tabla usa estos nombres en su DataPropertyName
        public string UbicacionTexto => $"INF-5130\\{Carpeta}";

        // cada hija decide qué tipo es y con qué pantalla se muestra
        public abstract string Tipo { get; }
        public abstract UserControl CrearVista();
    }
}
