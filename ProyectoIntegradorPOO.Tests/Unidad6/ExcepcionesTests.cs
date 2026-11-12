using ProyectoIntegradorPOO.Exceptions;
using ProyectoIntegradorPOO.Services;

namespace ProyectoIntegradorPOO.Tests.Unidad6;

public class ExcepcionesTests
{
    [Fact]
    public void ConvertirEntero_TextoInvalidoLanzaValidacionConInner()
    {
        ValidacionException ex = Assert.Throws<ValidacionException>(() => CalculadoraSegura.ConvertirEntero("abc", "A"));
        Assert.Equal("A", ex.Campo);
        Assert.IsType<FormatException>(ex.InnerException);
    }

    [Fact]
    public void ConvertirEntero_FueraDeRangoLanzaValidacionConOverflow()
    {
        ValidacionException ex = Assert.Throws<ValidacionException>(() => CalculadoraSegura.ConvertirEntero("99999999999", "B"));
        Assert.IsType<OverflowException>(ex.InnerException);
    }

    [Fact]
    public void Dividir_EntreCeroLanzaDivideByZero()
    {
        Assert.Throws<DivideByZeroException>(() => CalculadoraSegura.Dividir(10, 0));
        Assert.Equal(5, CalculadoraSegura.Dividir(10, 2));
    }

    [Fact]
    public void Multiplicar_DesbordamientoLanzaOverflow()
    {
        Assert.Throws<OverflowException>(() => CalculadoraSegura.Multiplicar(int.MaxValue, 2));
    }

    [Fact]
    public void ObtenerElemento_IndiceInvalidoLanzaIndexOutOfRange()
    {
        Assert.Throws<IndexOutOfRangeException>(() => CalculadoraSegura.ObtenerElemento(new[] { 1, 2 }, 5));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(121)]
    public void ValidarEdad_FueraDeRangoLanzaExcepcionPersonalizada(int edad)
    {
        Assert.Throws<ValidacionException>(() => CalculadoraSegura.ValidarEdad(edad));
    }

    [Fact]
    public void LeerArchivo_InexistenteLanzaFileNotFound()
    {
        string ruta = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N") + ".txt");
        Assert.Throws<FileNotFoundException>(() => CalculadoraSegura.LeerArchivo(ruta));
    }
}
