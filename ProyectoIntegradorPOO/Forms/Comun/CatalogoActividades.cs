using ProyectoIntegradorPOO.Forms.Originales;
using ProyectoIntegradorPOO.Forms.Unidad2;
using ProyectoIntegradorPOO.Forms.Unidad3;
using ProyectoIntegradorPOO.Forms.Unidad4;
using ProyectoIntegradorPOO.Forms.Unidad5;
using ProyectoIntegradorPOO.Forms.Unidad6;

namespace ProyectoIntegradorPOO.Forms.Comun;

/// <summary>Unidad temática de la asignatura.</summary>
public sealed record UnidadInfo(int Numero, string Titulo)
{
    public string TituloCompleto => $"Unidad {Numero} — {Titulo}";
}

/// <summary>Descripción de una actividad práctica y cómo crear su pantalla.</summary>
/// <param name="Original">Proyecto original enlazado; null si es una versión desarrollada dentro del integrador.</param>
public sealed record ActividadInfo(int Unidad, string Nombre, Type TipoFormulario, string Conceptos, string Estado, Func<Form> Crear, ProyectoOriginal? Original = null)
{
    public string Formulario => TipoFormulario.Name;

    public bool EsOriginal => Original is not null;

    /// <summary>Identifica la pantalla en el navegador (varias actividades originales comparten formulario).</summary>
    public string Clave => EsOriginal ? $"{Formulario}:{Original!.Carpeta}" : Formulario;

    public string Origen => EsOriginal ? $"Original · INF-5130\\{Original!.Carpeta}" : "Versión integrada";
}

/// <summary>
/// Registro central de unidades y actividades. El menú principal, el panel de navegación
/// y la pantalla de inicio se construyen a partir de esta lista.
/// PARA AGREGAR UNA ACTIVIDAD NUEVA: añadir una línea en Actividades (sin borrar las existentes).
/// </summary>
public static class CatalogoActividades
{
    public const string Completada = "Completada";
    public const string Enlazado = "Enlazado";

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
        new ActividadInfo(2, "Cuenta bancaria", typeof(FrmCuentaBancaria),
            "Encapsulación, atributos privados, propiedades de solo lectura, validaciones", Completada,
            () => new FrmCuentaBancaria()),

        // ---------- Unidad 3 ----------
        Formulario(3, "FormCursoEstudiante", "FormCursoEstudiante", () => new FormCursoEstudiante.Form1(),
            "Agregación Curso ◇— Estudiante (1..*), List<Estudiante>"),
        Consola(3, "Alquiler de vehiculos", @"Practica\Alquiler de vehiculos", "Alquiler de vehiculos",
            "Clases y contenedor List<Vehiculo> administrado por Gestion"),
        new ActividadInfo(3, "Relaciones entre clases", typeof(FrmRelacionesClases),
            "Asociación, agregación, composición, List<T>", Completada,
            () => new FrmRelacionesClases()),
        new ActividadInfo(3, "Composición: Pedidos", typeof(FrmComposicionPedido),
            "Composición Pedido ◆— DetallePedido (1..*), List<DetallePedido>", Completada,
            () => new FrmComposicionPedido()),

        // ---------- Unidad 4 ----------
        Consola(4, "SistemaVehiculos", "SistemaVehiculos", "SistemaVehiculos",
            "Lab 4.1: herencia Vehiculo → Motocicleta y base(...)"),
        Consola(4, "Polimorfismo", "Polimorfismo", "Polimorfismo",
            "Lab 4.2: virtual / override con Persona, Estudiante y Profesor"),
        Consola(4, "ClasesAbstractas", "ClasesAbstractas", "ClasesAbstractas",
            "Lab 4.3: clase abstracta Figura con Rectangulo y Circulo"),
        Consola(4, "Nomina", "Nomina", "Nomina",
            "Herencia Empleado → Programador, Diseñador con CalcularPago() sobrescrito"),
        new ActividadInfo(4, "4.1 Herencia y constructores", typeof(FrmHerencia),
            "Herencia, clase base/derivada, base(...), protected", Completada,
            () => new FrmHerencia()),
        new ActividadInfo(4, "4.2 Métodos sobrescritos", typeof(FrmMetodosSobrescritos),
            "virtual, override, variable polimórfica", Completada,
            () => new FrmMetodosSobrescritos()),
        new ActividadInfo(4, "4.3 Clases abstractas", typeof(FrmClasesAbstractas),
            "abstract, métodos abstractos, polimorfismo", Completada,
            () => new FrmClasesAbstractas()),
        new ActividadInfo(4, "Nómina de empleados", typeof(FrmNomina),
            "Jerarquía abstracta Empleado, constructores base, virtual/override", Completada,
            () => new FrmNomina()),

        // ---------- Unidad 5 ----------
        Formulario(5, "Pedidos (FoodExpress)", "Pedidos", () => new Pedidos.Menu(),
            "Polimorfismo dinámico y estático, operador +, UserControls, persistencia JSON"),
        new ActividadInfo(5, "FoodExpress: polimorfismo", typeof(FrmPolimorfismo),
            "Polimorfismo dinámico y estático, variables polimórficas, interfaces, operador +", Completada,
            () => new FrmPolimorfismo()),
        new ActividadInfo(5, "Sobrecarga de operadores", typeof(FrmSobrecargaOperadores),
            "Operadores + - == !=, Equals(), GetHashCode()", Completada,
            () => new FrmSobrecargaOperadores()),

        // ---------- Unidad 6 ----------
        Consola(6, "Tryparse", @"Practica\Tryparse", "Tryparse",
            "try / catch (FormatException, DivideByZeroException) / finally"),
        new ActividadInfo(6, "Manejo de excepciones", typeof(FrmManejoExcepciones),
            "try, catch, finally, throw, excepciones personalizadas", Completada,
            () => new FrmManejoExcepciones()),
        new ActividadInfo(6, "Persistencia de datos (JSON)", typeof(FrmPersistenciaDatos),
            "System.Text.Json, repositorio, servicio, CRUD asíncrono", Completada,
            () => new FrmPersistenciaDatos()),
    };

    public static IEnumerable<ActividadInfo> DeUnidad(int unidad) => Actividades.Where(a => a.Unidad == unidad);

    public static IEnumerable<ActividadInfo> Originales => Actividades.Where(a => a.EsOriginal);

    public static UnidadInfo? BuscarUnidad(int numero) => Unidades.FirstOrDefault(u => u.Numero == numero);

    public static ActividadInfo? BuscarPorClave(string clave) => Actividades.FirstOrDefault(a => a.Clave == clave);

    // ---------- Fábricas para los proyectos originales enlazados ----------

    private static ActividadInfo Consola(int unidad, string nombre, string carpeta, string ensamblado, string conceptos)
    {
        ProyectoOriginal proyecto = new ProyectoOriginal(nombre, carpeta, TipoProyectoOriginal.Consola, Ensamblado: ensamblado);
        return Original(unidad, proyecto, conceptos);
    }

    private static ActividadInfo Formulario(int unidad, string nombre, string carpeta, Func<Form> crear, string conceptos)
    {
        ProyectoOriginal proyecto = new ProyectoOriginal(nombre, carpeta, TipoProyectoOriginal.WindowsForms, CrearFormulario: crear);
        return Original(unidad, proyecto, conceptos);
    }

    private static ActividadInfo Original(int unidad, ProyectoOriginal proyecto, string conceptos) =>
        new ActividadInfo(unidad, proyecto.Nombre, typeof(FrmProyectoOriginal), conceptos, Enlazado,
            () => new FrmProyectoOriginal(proyecto, unidad, conceptos), proyecto);
}
