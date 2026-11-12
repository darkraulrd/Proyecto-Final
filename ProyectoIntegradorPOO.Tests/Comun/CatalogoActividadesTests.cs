using ProyectoIntegradorPOO.Forms.Comun;

namespace ProyectoIntegradorPOO.Tests.Comun;

/// <summary>Protege la regla de conservación: cada unidad tiene actividades y ningún formulario se repite.</summary>
public class CatalogoActividadesTests
{
    [Fact]
    public void CadaUnidadTieneAlMenosUnaActividad()
    {
        foreach (UnidadInfo unidad in CatalogoActividades.Unidades)
            Assert.NotEmpty(CatalogoActividades.DeUnidad(unidad.Numero));
    }

    [Fact]
    public void LosFormulariosNoSeRepitenYHeredanDeLaBase()
    {
        List<Type> tipos = CatalogoActividades.Actividades.Select(a => a.TipoFormulario).ToList();
        Assert.Equal(tipos.Count, tipos.Distinct().Count());
        Assert.All(tipos, t => Assert.True(typeof(FrmActividadBase).IsAssignableFrom(t), $"{t.Name} debe heredar de FrmActividadBase"));
        Assert.All(tipos, t => Assert.StartsWith("Frm", t.Name));
    }

    [Theory]
    [InlineData("FrmCuentaBancaria")]
    [InlineData("FrmRelacionesClases")]
    [InlineData("FrmHerencia")]
    [InlineData("FrmClasesAbstractas")]
    [InlineData("FrmPolimorfismo")]
    [InlineData("FrmSobrecargaOperadores")]
    [InlineData("FrmManejoExcepciones")]
    [InlineData("FrmPersistenciaDatos")]
    public void IncluyeLosFormulariosObligatorios(string formulario)
    {
        Assert.Contains(CatalogoActividades.Actividades, a => a.Formulario == formulario);
    }
}
