namespace ProyectoIntegradorPOO.Models.Unidad4;

/// <summary>
/// Laboratorio 4.1 — HERENCIA Y CONSTRUCTORES. Clase base.
/// </summary>
public class Vehiculo
{
    public Vehiculo(string marca, string modelo)
    {
        if (string.IsNullOrWhiteSpace(marca))
            throw new ArgumentException("La marca es obligatoria.");
        if (string.IsNullOrWhiteSpace(modelo))
            throw new ArgumentException("El modelo es obligatorio.");

        Marca = marca.Trim();
        Modelo = modelo.Trim();
    }

    public string Marca { get; }
    public string Modelo { get; }

    // protected: lo ven las clases derivadas, pero no el formulario.
    protected string TipoVehiculo { get; init; } = "Vehículo";

    public string MostrarInformacion() =>
        $"Tipo: {TipoVehiculo}{Environment.NewLine}Marca: {Marca}{Environment.NewLine}Modelo: {Modelo}";
}

/// <summary>
/// Clase derivada: "Motocicleta : Vehiculo" significa que Motocicleta ES UN Vehiculo
/// y hereda Marca, Modelo y MostrarInformacion().
/// </summary>
public class Motocicleta : Vehiculo
{
    // base(marca, modelo) llama primero al constructor de Vehiculo para inicializar lo heredado.
    public Motocicleta(string marca, string modelo, int cilindrada) : base(marca, modelo)
    {
        if (cilindrada <= 0)
            throw new ArgumentException("La cilindrada debe ser mayor que cero.");

        Cilindrada = cilindrada;
        TipoVehiculo = "Motocicleta";
    }

    public int Cilindrada { get; }

    public string MostrarCilindrada() => $"Cilindrada: {Cilindrada} cc";
}
