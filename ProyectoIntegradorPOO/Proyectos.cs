using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ProyectoIntegradorPOO
{
    // Lista de unidades y de proyectos enlazados.
    // PARA ENLAZAR UN PROYECTO NUEVO: agregar su ProjectReference en el .csproj y una línea en Lista.
    public static class Proyectos
    {
        // Carpeta INF-5130 y configuración (Debug/Release): las escribe MSBuild al compilar
        public static readonly string CarpetaCurso = LeerDato("CarpetaCurso") ?? AppContext.BaseDirectory;
        public static readonly string Configuracion = LeerDato("Configuracion") ?? "Debug";

        public static readonly List<Unidad> Unidades = new List<Unidad>
        {
            new Unidad(1, "Introducción a la programación"),
            new Unidad(2, "Encapsulación"),
            new Unidad(3, "Relaciones entre clases y contenedores"),
            new Unidad(4, "Herencia, polimorfismo y clases abstractas"),
            new Unidad(5, "Polimorfismo y sobrecarga de operadores"),
            new Unidad(6, "Excepciones y persistencia de datos")
        };

        public static readonly List<ProyectoCurso> Lista = new List<ProyectoCurso>
        {
            // Unidad 1
            new ProyectoConsola { Unidad = 1, Nombre = "MiPrimerPrograma", Carpeta = @"Prueba\RM_100758645_U1", Ejecutable = "MiPrimerPrograma",
                Conceptos = "Entrada y salida por consola, variables, conversión de tipos" },
            new ProyectoFormulario { Unidad = 1, Nombre = "Menu Principal", Carpeta = "Prueba", CrearFormulario = () => new Prueba.Form1(),
                Conceptos = "Primer formulario Windows Forms con MenuStrip" },

            // Unidad 2
            new ProyectoConsola { Unidad = 2, Nombre = "Banco", Carpeta = @"Prueba\RM_100758645_U2\Banco", Ejecutable = "Banco",
                Conceptos = "Encapsulación: clase Cuenta con saldo de solo lectura desde fuera" },

            // Unidad 3
            new ProyectoFormulario { Unidad = 3, Nombre = "FormCursoEstudiante", Carpeta = "FormCursoEstudiante", CrearFormulario = () => new FormCursoEstudiante.Form1(),
                Conceptos = "Agregación Curso ◇— Estudiante (1..*), List<Estudiante>" },
            new ProyectoConsola { Unidad = 3, Nombre = "Alquiler de vehiculos", Carpeta = @"Practica\Alquiler de vehiculos", Ejecutable = "Alquiler de vehiculos",
                Conceptos = "Clases y contenedor List<Vehiculo> administrado por Gestion" },

            // Unidad 4
            new ProyectoConsola { Unidad = 4, Nombre = "SistemaVehiculos", Carpeta = "SistemaVehiculos", Ejecutable = "SistemaVehiculos",
                Conceptos = "Lab 4.1: herencia Vehiculo → Motocicleta y base(...)" },
            new ProyectoConsola { Unidad = 4, Nombre = "Polimorfismo", Carpeta = "Polimorfismo", Ejecutable = "Polimorfismo",
                Conceptos = "Lab 4.2: virtual / override con Persona, Estudiante y Profesor" },
            new ProyectoConsola { Unidad = 4, Nombre = "ClasesAbstractas", Carpeta = "ClasesAbstractas", Ejecutable = "ClasesAbstractas",
                Conceptos = "Lab 4.3: clase abstracta Figura con Rectangulo y Circulo" },
            new ProyectoConsola { Unidad = 4, Nombre = "Nomina", Carpeta = "Nomina", Ejecutable = "Nomina",
                Conceptos = "Herencia Empleado → Programador, Diseñador con CalcularPago() sobrescrito" },

            // Unidad 5
            new ProyectoFormulario { Unidad = 5, Nombre = "Pedidos (FoodExpress)", Carpeta = "Pedidos", CrearFormulario = () => new Pedidos.Menu(),
                Conceptos = "Polimorfismo dinámico y estático, operador +, UserControls, persistencia JSON" },

            // Unidad 6
            new ProyectoConsola { Unidad = 6, Nombre = "Tryparse", Carpeta = @"Practica\Tryparse", Ejecutable = "Tryparse",
                Conceptos = "try / catch (FormatException, DivideByZeroException) / finally" },
        };

        public static List<ProyectoCurso> DeUnidad(int numero) =>
            Lista.Where(p => p.Unidad == numero).ToList();

        public static Unidad BuscarUnidad(int numero) =>
            Unidades.First(u => u.Numero == numero);

        // Busca por nombre, carpeta o conceptos (vacío = todos)
        public static List<ProyectoCurso> Buscar(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return Lista.ToList();

            return Lista.Where(p =>
                    p.Nombre.Contains(texto, StringComparison.OrdinalIgnoreCase) ||
                    p.Carpeta.Contains(texto, StringComparison.OrdinalIgnoreCase) ||
                    p.Conceptos.Contains(texto, StringComparison.OrdinalIgnoreCase) ||
                    p.Tipo.Contains(texto, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        private static string? LeerDato(string clave) =>
            typeof(Proyectos).Assembly
                .GetCustomAttributes<AssemblyMetadataAttribute>()
                .FirstOrDefault(a => a.Key == clave)?.Value;
    }
}
