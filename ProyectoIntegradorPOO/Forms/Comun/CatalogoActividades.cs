using ProyectoIntegradorPOO.Forms.Originales;

namespace ProyectoIntegradorPOO.Forms.Comun;

/// <summary>Unidad temática de la asignatura.</summary>
public sealed record UnidadInfo(int Numero, string Titulo)
{
    public string TituloCompleto => $"Unidad {Numero} — {Titulo}";
}

/// <summary>Una actividad del curso: un proyecto original enlazado y cómo crear su pantalla.</summary>
public sealed record ActividadInfo(int Unidad, string Nombre, string Conceptos, ProyectoOriginal Original, Func<Form> Crear)
{
    /// <summary>Identifica la pantalla en el navegador (todas comparten FrmProyectoOriginal).</summary>
    public string Clave => $"{nameof(FrmProyectoOriginal)}:{Original.Carpeta}";

    public string Origen => $"INF-5130\\{Original.Carpeta}";

    public string Tipo => Original.Tipo == TipoProyectoOriginal.Consola ? "Consola" : "Windows Forms";
}

/// <summary>
/// Registro central de unidades y proyectos originales enlazados. El menú principal, el panel
/// de navegación y la pantalla de inicio se construyen a partir de esta lista.
/// PARA ENLAZAR UN PROYECTO NUEVO: añadir su ProjectReference en el .csproj y una línea aquí.
/// </summary>
public static class CatalogoActividades
{
    public static IReadOnlyList<UnidadInfo> Unidades { get; } = new List<UnidadInfo>
    {
        new UnidadInfo(1, "Introducción a la programación"),
        new UnidadInfo(2, "Encapsulación"),
        new UnidadInfo(3, "Relaciones entre clases y contenedores"),
        new UnidadInfo(4, "Herencia, polimorfismo y clases abstractas"),
        new UnidadInfo(5, "Polimorfismo y sobrecarga de operadores"),
        new UnidadInfo(6, "Excepciones y persistencia de datos")
    };

    public static IReadOnlyList<ActividadInfo> Actividades { get; } = new List<ActividadInfo>
    {
        // ---------- Unidad 1 ----------
        Consola(1, "MiPrimerPrograma", @"Prueba\RM_100758645_U1", "MiPrimerPrograma",
            "Entrada y salida por consola, variables, conversión de tipos"),
        Formulario(1, "Menu Principal", "Prueba", () => new Prueba.Form1(),
            "Primer formulario Windows Forms con MenuStrip"),

        // ---------- Unidad 2 ----------
        Consola(2, "Banco", @"Prueba\RM_100758645_U2\Banco", "Banco",
            "Encapsulación: clase Cuenta con saldo de solo lectura desde fuera"),

        // ---------- Unidad 3 ----------
        Formulario(3, "FormCursoEstudiante", "FormCursoEstudiante", () => new FormCursoEstudiante.Form1(),
            "Agregación Curso ◇— Estudiante (1..*), List<Estudiante>"),
        Consola(3, "Alquiler de vehiculos", @"Practica\Alquiler de vehiculos", "Alquiler de vehiculos",
            "Clases y contenedor List<Vehiculo> administrado por Gestion"),

        // ---------- Unidad 4 ----------
        Consola(4, "SistemaVehiculos", "SistemaVehiculos", "SistemaVehiculos",
            "Lab 4.1: herencia Vehiculo → Motocicleta y base(...)"),
        Consola(4, "Polimorfismo", "Polimorfismo", "Polimorfismo",
            "Lab 4.2: virtual / override con Persona, Estudiante y Profesor"),
        Consola(4, "ClasesAbstractas", "ClasesAbstractas", "ClasesAbstractas",
            "Lab 4.3: clase abstracta Figura con Rectangulo y Circulo"),
        Consola(4, "Nomina", "Nomina", "Nomina",
            "Herencia Empleado → Programador, Diseñador con CalcularPago() sobrescrito"),

        // ---------- Unidad 5 ----------
        Formulario(5, "Pedidos (FoodExpress)", "Pedidos", () => new Pedidos.Menu(),
            "Polimorfismo dinámico y estático, operador +, UserControls, persistencia JSON"),

        // ---------- Unidad 6 ----------
        Consola(6, "Tryparse", @"Practica\Tryparse", "Tryparse",
            "try / catch (FormatException, DivideByZeroException) / finally"),
    };

    public static IEnumerable<ActividadInfo> DeUnidad(int unidad) => Actividades.Where(a => a.Unidad == unidad);

    public static UnidadInfo? BuscarUnidad(int numero) => Unidades.FirstOrDefault(u => u.Numero == numero);

    public static ActividadInfo? BuscarPorClave(string clave) => Actividades.FirstOrDefault(a => a.Clave == clave);

    // ---------- Fábricas ----------

    private static ActividadInfo Consola(int unidad, string nombre, string carpeta, string ensamblado, string conceptos) =>
        Crear(unidad, conceptos, new ProyectoOriginal(nombre, carpeta, TipoProyectoOriginal.Consola, Ensamblado: ensamblado));

    private static ActividadInfo Formulario(int unidad, string nombre, string carpeta, Func<Form> crear, string conceptos) =>
        Crear(unidad, conceptos, new ProyectoOriginal(nombre, carpeta, TipoProyectoOriginal.WindowsForms, CrearFormulario: crear));

    private static ActividadInfo Crear(int unidad, string conceptos, ProyectoOriginal proyecto) =>
        new ActividadInfo(unidad, proyecto.Nombre, conceptos, proyecto,
            () => new FrmProyectoOriginal(proyecto, unidad, conceptos));
}
