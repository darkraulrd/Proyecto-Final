using System.Globalization;

namespace ProyectoIntegradorPOO.Models.Unidad5;

/// <summary>
/// Cantidad de dinero en pesos dominicanos (RD$), inmutable.
/// Sobrecarga el operador + : sumar dos importes produce un importe nuevo.
/// Tiene sentido en el modelo porque subtotal + cargo = total.
/// </summary>
public sealed class Importe
{
    public Importe(decimal monto)
    {
        if (monto < 0)
            throw new ArgumentException("El importe no puede ser negativo.", nameof(monto));
        Monto = monto;
    }

    public decimal Monto { get; }

    public static Importe Cero { get; } = new Importe(0m);

    public static Importe operator +(Importe a, Importe b)
    {
        ArgumentNullException.ThrowIfNull(a);
        ArgumentNullException.ThrowIfNull(b);
        return new Importe(a.Monto + b.Monto);
    }

    public override string ToString() => "RD$ " + Monto.ToString("N2", CultureInfo.InvariantCulture);
}
