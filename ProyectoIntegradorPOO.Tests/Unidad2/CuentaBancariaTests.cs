using ProyectoIntegradorPOO.Models.Unidad2;

namespace ProyectoIntegradorPOO.Tests.Unidad2;

public class CuentaBancariaTests
{
    private static CuentaBancaria NuevaCuenta() => new CuentaBancaria("Ana Pérez", "1234567890");

    [Fact]
    public void CuentaNueva_IniciaConSaldoCero()
    {
        CuentaBancaria cuenta = NuevaCuenta();
        Assert.Equal(0m, cuenta.Saldo);
        Assert.Equal("Ana Pérez", cuenta.Titular);
        Assert.Equal("1234567890", cuenta.NumeroCuenta);
    }

    [Theory]
    [InlineData("", "1234567890")]
    [InlineData("   ", "1234567890")]
    [InlineData("Ana", "")]
    [InlineData("Ana", "12345")]
    [InlineData("Ana", "12345ABCDE")]
    public void Constructor_RechazaDatosInvalidos(string titular, string numero)
    {
        Assert.Throws<ArgumentException>(() => new CuentaBancaria(titular, numero));
    }

    [Fact]
    public void Depositar_AumentaSaldoYRegistraMovimiento()
    {
        CuentaBancaria cuenta = NuevaCuenta();
        cuenta.Depositar(1500.50m);

        Assert.Equal(1500.50m, cuenta.Saldo);
        Assert.Single(cuenta.Movimientos);
        Assert.Equal(TipoMovimiento.Deposito, cuenta.Movimientos[0].Tipo);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-10)]
    public void Depositar_RechazaMontosNoPositivos(decimal monto)
    {
        CuentaBancaria cuenta = NuevaCuenta();
        Assert.Throws<ArgumentException>(() => cuenta.Depositar(monto));
        Assert.Equal(0m, cuenta.Saldo);
    }

    [Fact]
    public void Retirar_NoPermiteSuperarElSaldo()
    {
        CuentaBancaria cuenta = NuevaCuenta();
        cuenta.Depositar(100m);

        Assert.Throws<InvalidOperationException>(() => cuenta.Retirar(100.01m));
        Assert.Equal(100m, cuenta.Saldo);
    }

    [Fact]
    public void Retirar_DisminuyeElSaldo()
    {
        CuentaBancaria cuenta = NuevaCuenta();
        cuenta.Depositar(500m);
        cuenta.Retirar(200m);

        Assert.Equal(300m, cuenta.Saldo);
        Assert.Equal(300m, cuenta.ConsultarSaldo());
        Assert.Equal(3, cuenta.Movimientos.Count);
    }

    [Fact]
    public void Saldo_NoTieneSetterPublico()
    {
        // Encapsulación: la propiedad Saldo solo se puede leer desde fuera.
        var propiedad = typeof(CuentaBancaria).GetProperty(nameof(CuentaBancaria.Saldo))!;
        Assert.Null(propiedad.GetSetMethod());
    }
}
