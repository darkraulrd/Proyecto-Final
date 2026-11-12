namespace ProyectoIntegradorPOO.Models.Unidad2;

/// <summary>
/// UNIDAD 2 — ENCAPSULACIÓN.
/// Representa una cuenta bancaria. Los datos internos (titular, número y saldo)
/// son atributos privados: desde fuera solo se pueden LEER mediante propiedades,
/// y el saldo únicamente cambia a través de los métodos Depositar y Retirar,
/// que aplican las reglas de negocio.
/// </summary>
public class CuentaBancaria
{
    public const int LongitudNumeroCuenta = 10;

    // ----- Atributos privados: nadie fuera de la clase puede modificarlos -----
    private readonly string titular;
    private readonly string numeroCuenta;
    private decimal saldo;
    private readonly List<Movimiento> movimientos = new List<Movimiento>();

    public CuentaBancaria(string titular, string numeroCuenta)
    {
        if (string.IsNullOrWhiteSpace(titular))
            throw new ArgumentException("El nombre del titular es obligatorio.", nameof(titular));

        if (string.IsNullOrWhiteSpace(numeroCuenta))
            throw new ArgumentException("El número de cuenta es obligatorio.", nameof(numeroCuenta));

        numeroCuenta = numeroCuenta.Trim();
        if (numeroCuenta.Length != LongitudNumeroCuenta || !numeroCuenta.All(char.IsDigit))
            throw new ArgumentException($"El número de cuenta debe tener exactamente {LongitudNumeroCuenta} dígitos.", nameof(numeroCuenta));

        this.titular = titular.Trim();
        this.numeroCuenta = numeroCuenta;
        saldo = 0m;
    }

    // ----- Propiedades públicas de solo lectura (no tienen set) -----
    public string Titular => titular;
    public string NumeroCuenta => numeroCuenta;
    public decimal Saldo => saldo;

    // Se expone una vista de solo lectura: el formulario no puede agregar ni borrar movimientos.
    public IReadOnlyList<Movimiento> Movimientos => movimientos.AsReadOnly();

    public void Depositar(decimal monto)
    {
        if (monto <= 0)
            throw new ArgumentException("El monto a depositar debe ser mayor que cero.", nameof(monto));

        saldo += monto;
        movimientos.Add(new Movimiento(DateTime.Now, TipoMovimiento.Deposito, monto, saldo));
    }

    public void Retirar(decimal monto)
    {
        if (monto <= 0)
            throw new ArgumentException("El monto a retirar debe ser mayor que cero.", nameof(monto));

        if (monto > saldo)
            throw new InvalidOperationException($"Fondos insuficientes. Saldo disponible: {saldo:N2}.");

        saldo -= monto;
        movimientos.Add(new Movimiento(DateTime.Now, TipoMovimiento.Retiro, monto, saldo));
    }

    public decimal ConsultarSaldo()
    {
        movimientos.Add(new Movimiento(DateTime.Now, TipoMovimiento.Consulta, 0m, saldo));
        return saldo;
    }
}

public enum TipoMovimiento
{
    Deposito,
    Retiro,
    Consulta
}

/// <summary>Registro inmutable de una operación realizada sobre la cuenta.</summary>
public sealed record Movimiento(DateTime Fecha, TipoMovimiento Tipo, decimal Monto, decimal SaldoResultante);
