namespace ProyectoIntegradorPOO.Models.Unidad4;

/// <summary>
/// Contenedor de empleados. Guarda referencias del tipo BASE (Empleado):
/// la lista no sabe qué tipo concreto hay dentro y aun así cada objeto
/// calcula su salario con su propio comportamiento.
/// </summary>
public class Nomina
{
    private readonly List<Empleado> empleados = new List<Empleado>();

    public IReadOnlyList<Empleado> Empleados => empleados.AsReadOnly();

    public void Agregar(Empleado empleado)
    {
        ArgumentNullException.ThrowIfNull(empleado);
        if (empleados.Any(e => e.Codigo == empleado.Codigo))
            throw new InvalidOperationException($"Ya existe un empleado con el código {empleado.Codigo}.");
        empleados.Add(empleado);
    }

    public bool Eliminar(string codigo) => empleados.RemoveAll(e => e.Codigo == codigo) > 0;

    // Una sola llamada (CalcularSalario) y cada objeto responde distinto.
    public decimal CalcularTotal() => empleados.Sum(e => e.CalcularSalario());
}
