using System.Reflection;

namespace ProyectoIntegradorPOO
{
    // Lista de todos los proyectos del curso.
    // Para agregar uno nuevo: ponerlo en el .csproj (ProjectReference) y agregarlo aquí.
    public static class Proyectos
    {
        // Carpeta INF-5130 y Debug/Release. Las guarda Visual Studio al compilar (ver el .csproj).
        public static string CarpetaCurso = LeerDato("CarpetaCurso");
        public static string Configuracion = LeerDato("Configuracion");

        public static string[] Unidades =
        {
            "Unidad 1 - Introducción a la programación",
            "Unidad 2 - Encapsulación",
            "Unidad 3 - Relaciones entre clases y contenedores",
            "Unidad 4 - Herencia, polimorfismo y clases abstractas",
            "Unidad 5 - Polimorfismo y sobrecarga de operadores",
            "Unidad 6 - Excepciones y persistencia de datos"
        };

        public static List<Proyecto> Lista = new List<Proyecto>
        {
            // Unidad 1
            new Proyecto { Unidad = 1, Nombre = "MiPrimerPrograma", Carpeta = @"Prueba\RM_100758645_U1", EsConsola = true, Ejecutable = "MiPrimerPrograma",
                Conceptos = "Entrada y salida por consola, variables y conversión de tipos." },
            new Proyecto { Unidad = 1, Nombre = "Menu Principal", Carpeta = "Prueba", CrearFormulario = () => new Prueba.Form1(),
                Conceptos = "Primer formulario de Windows Forms con MenuStrip." },

            // Unidad 2
            new Proyecto { Unidad = 2, Nombre = "Banco", Carpeta = @"Prueba\RM_100758645_U2\Banco", EsConsola = true, Ejecutable = "Banco",
                Conceptos = "Encapsulación: la clase Cuenta protege el saldo." },

            // Unidad 3
            new Proyecto { Unidad = 3, Nombre = "FormCursoEstudiante", Carpeta = "FormCursoEstudiante", CrearFormulario = () => new FormCursoEstudiante.Form1(),
                Conceptos = "Agregación entre Curso y Estudiante usando List<Estudiante>." },
            new Proyecto { Unidad = 3, Nombre = "Alquiler de vehiculos", Carpeta = @"Practica\Alquiler de vehiculos", EsConsola = true, Ejecutable = "Alquiler de vehiculos",
                Conceptos = "Clases y una lista de vehículos manejada por la clase Gestion." },

            // Unidad 4
            new Proyecto { Unidad = 4, Nombre = "SistemaVehiculos", Carpeta = "SistemaVehiculos", EsConsola = true, Ejecutable = "SistemaVehiculos",
                Conceptos = "Lab 4.1: herencia de Vehiculo a Motocicleta y uso de base(...)." },
            new Proyecto { Unidad = 4, Nombre = "Polimorfismo", Carpeta = "Polimorfismo", EsConsola = true, Ejecutable = "Polimorfismo",
                Conceptos = "Lab 4.2: virtual y override con Persona, Estudiante y Profesor." },
            new Proyecto { Unidad = 4, Nombre = "ClasesAbstractas", Carpeta = "ClasesAbstractas", EsConsola = true, Ejecutable = "ClasesAbstractas",
                Conceptos = "Lab 4.3: clase abstracta Figura con Rectangulo y Circulo." },
            new Proyecto { Unidad = 4, Nombre = "Nomina", Carpeta = "Nomina", EsConsola = true, Ejecutable = "Nomina",
                Conceptos = "Herencia: Programador y Diseñador sobrescriben CalcularPago()." },

            // Unidad 5
            // Su ventana mide 1120 x 680 y no cabe dentro del programa: se abre aparte
            new Proyecto { Unidad = 5, Nombre = "Pedidos (FoodExpress)", Carpeta = "Pedidos", CrearFormulario = () => new Pedidos.Menu(), AbrirAparte = true,
                Conceptos = "Polimorfismo, sobrecarga del operador +, UserControls y JSON." },

            // Unidad 6
            new Proyecto { Unidad = 6, Nombre = "Tryparse", Carpeta = @"Practica\Tryparse", EsConsola = true, Ejecutable = "Tryparse",
                Conceptos = "try, catch (FormatException y DivideByZeroException) y finally." },
        };

        // Devuelve los proyectos de una unidad
        public static List<Proyecto> DeUnidad(int unidad)
        {
            List<Proyecto> resultado = new List<Proyecto>();
            foreach (Proyecto p in Lista)
            {
                if (p.Unidad == unidad)
                    resultado.Add(p);
            }
            return resultado;
        }

        private static string LeerDato(string clave)
        {
            foreach (AssemblyMetadataAttribute dato in typeof(Proyectos).Assembly.GetCustomAttributes<AssemblyMetadataAttribute>())
            {
                if (dato.Key == clave && dato.Value != null)
                    return dato.Value;
            }
            return "";
        }
    }
}
