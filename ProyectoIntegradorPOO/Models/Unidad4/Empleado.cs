namespace ProyectoIntegradorPOO.Models.Unidad4;

/// <summary>
/// Nómina — HERENCIA, CLASE ABSTRACTA y POLIMORFISMO.
/// Empleado define lo común (nombre, código) y obliga a cada tipo de empleado
/// a decir cómo se calcula su salario (método abstracto CalcularSalario).
/// </summary>
public abstract class Empleado
{
    protected Empleado(string codigo, string nombre)
    {
        if (string.IsNullOrWhiteSpace(codigo))
            throw new ArgumentException("El código del empleado es obligatorio.");
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre del empleado es obligatorio.");

        Codigo = codigo.Trim().ToUpperInvariant();
        Nombre = nombre.Trim();
    }

    public string Codigo { get; }
    public string Nombre { get; }

    public abstract string TipoEmpleado { get; }

    /// <summary>Cada derivada lo implementa a su manera: aquí está el polimorfismo.</summary>
    public abstract decimal CalcularSalario();

    /// <summary>Virtual: tiene una versión por defecto que las derivadas amplían con base.Detalle().</summary>
    public virtual string Detalle() => $"{TipoEmpleado}: {Nombre} ({Codigo})";

    // Validación reutilizable por todas las derivadas (protected = solo la familia la usa).
    protected static decimal ValidarNoNegativo(decimal valor, string campo)
    {
        if (valor < 0)
            throw new ArgumentException($"{campo} no puede ser negativo.");
        return valor;
    }
}

/// <summary>Empleado con salario mensual fijo.</summary>
public class EmpleadoFijo : Empleado
{
    public EmpleadoFijo(string codigo, string nombre, decimal salarioMensual) : base(codigo, nombre)
    {
        if (salarioMensual <= 0)
            throw new ArgumentException("El salario mensual debe ser mayor que cero.");
        SalarioMensual = salarioMensual;
    }

    public decimal SalarioMensual { get; }

    public override string TipoEmpleado => "Fijo";

    public override decimal CalcularSalario() => SalarioMensual;

    public override string Detalle() => $"{base.Detalle()} — Salario fijo {SalarioMensual:N2}";
}

/// <summary>Empleado que cobra por hora trabajada.</summary>
public class EmpleadoPorHoras : Empleado
{
    public EmpleadoPorHoras(string codigo, string nombre, decimal horasTrabajadas, decimal tarifaPorHora) : base(codigo, nombre)
    {
        if (tarifaPorHora <= 0)
            throw new ArgumentException("La tarifa por hora debe ser mayor que cero.");
        HorasTrabajadas = ValidarNoNegativo(horasTrabajadas, "Las horas trabajadas");
        TarifaPorHora = tarifaPorHora;
    }

    public decimal HorasTrabajadas { get; }
    public decimal TarifaPorHora { get; }

    public override string TipoEmpleado => "Por horas";

    public override decimal CalcularSalario() => HorasTrabajadas * TarifaPorHora;

    public override string Detalle() => $"{base.Detalle()} — {HorasTrabajadas:N1} h × {TarifaPorHora:N2}";
}

/// <summary>Empleado con salario base más un porcentaje de comisión sobre sus ventas.</summary>
public class EmpleadoComision : Empleado
{
    public EmpleadoComision(string codigo, string nombre, decimal salarioBase, decimal ventas, decimal porcentajeComision) : base(codigo, nombre)
    {
        if (porcentajeComision < 0 || porcentajeComision > 100)
            throw new ArgumentException("El porcentaje de comisión debe estar entre 0 y 100.");
        SalarioBase = ValidarNoNegativo(salarioBase, "El salario base");
        Ventas = ValidarNoNegativo(ventas, "Las ventas");
        PorcentajeComision = porcentajeComision;
    }

    public decimal SalarioBase { get; }
    public decimal Ventas { get; }
    public decimal PorcentajeComision { get; }

    public override string TipoEmpleado => "Comisión";

    public decimal CalcularComision() => Math.Round(Ventas * PorcentajeComision / 100m, 2);

    public override decimal CalcularSalario() => SalarioBase + CalcularComision();

    public override string Detalle() => $"{base.Detalle()} — Base {SalarioBase:N2} + {PorcentajeComision:N1}% de {Ventas:N2}";
}
