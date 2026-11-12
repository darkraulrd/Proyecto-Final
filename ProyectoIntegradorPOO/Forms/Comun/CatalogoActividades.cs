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

/// <summary>Descripción de una actividad práctica y cómo crear su formulario.</summary>
public sealed record ActividadInfo(int Unidad, string Nombre, Type TipoFormulario, string Conceptos, string Estado, Func<Form> Crear)
{
    public string Formulario => TipoFormulario.Name;
}

/// <summary>
/// Registro central de unidades y actividades. El menú principal, el panel de navegación
/// y la pantalla de inicio se construyen a partir de esta lista.
/// PARA AGREGAR UNA ACTIVIDAD NUEVA: añadir una línea en Actividades (sin borrar las existentes).
/// </summary>
public static class CatalogoActividades
{
    public const string Completada = "Completada";

    public static IReadOnlyList<UnidadInfo> Unidades { get; } = new List<UnidadInfo>
    {
        new UnidadInfo(2, "Encapsulación"),
        new UnidadInfo(3, "Relaciones entre clases y contenedores"),
        new UnidadInfo(4, "Herencia, polimorfismo y clases abstractas"),
        new UnidadInfo(5, "Polimorfismo y sobrecarga de operadores"),
        new UnidadInfo(6, "Excepciones y persistencia de datos")
    };

    public static IReadOnlyList<ActividadInfo> Actividades { get; } = new List<ActividadInfo>
    {
        // ---------- Unidad 2 ----------
        new ActividadInfo(2, "Cuenta bancaria", typeof(FrmCuentaBancaria),
            "Encapsulación, atributos privados, propiedades de solo lectura, validaciones", Completada,
            () => new FrmCuentaBancaria()),

        // ---------- Unidad 3 ----------
        new ActividadInfo(3, "Relaciones entre clases", typeof(FrmRelacionesClases),
            "Asociación, agregación, composición, List<T>", Completada,
            () => new FrmRelacionesClases()),
        new ActividadInfo(3, "Composición: Pedidos", typeof(FrmComposicionPedido),
            "Composición Pedido ◆— DetallePedido (1..*), List<DetallePedido>", Completada,
            () => new FrmComposicionPedido()),

        // ---------- Unidad 4 ----------
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
        new ActividadInfo(5, "FoodExpress: polimorfismo", typeof(FrmPolimorfismo),
            "Polimorfismo dinámico y estático, variables polimórficas, interfaces, operador +", Completada,
            () => new FrmPolimorfismo()),
        new ActividadInfo(5, "Sobrecarga de operadores", typeof(FrmSobrecargaOperadores),
            "Operadores + - == !=, Equals(), GetHashCode()", Completada,
            () => new FrmSobrecargaOperadores()),

        // ---------- Unidad 6 ----------
        new ActividadInfo(6, "Manejo de excepciones", typeof(FrmManejoExcepciones),
            "try, catch, finally, throw, excepciones personalizadas", Completada,
            () => new FrmManejoExcepciones()),
        new ActividadInfo(6, "Persistencia de datos (JSON)", typeof(FrmPersistenciaDatos),
            "System.Text.Json, repositorio, servicio, CRUD asíncrono", Completada,
            () => new FrmPersistenciaDatos()),
    };

    public static IEnumerable<ActividadInfo> DeUnidad(int unidad) => Actividades.Where(a => a.Unidad == unidad);

    public static UnidadInfo? BuscarUnidad(int numero) => Unidades.FirstOrDefault(u => u.Numero == numero);

    public static ActividadInfo? BuscarPorFormulario(Type tipo) => Actividades.FirstOrDefault(a => a.TipoFormulario == tipo);
}
