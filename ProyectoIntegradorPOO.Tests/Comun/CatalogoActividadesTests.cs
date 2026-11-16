using ProyectoIntegradorPOO.Forms.Comun;
using ProyectoIntegradorPOO.Forms.Originales;

namespace ProyectoIntegradorPOO.Tests.Comun;

/// <summary>Protege la regla de conservación: cada unidad tiene actividades y ninguna pantalla se repite.</summary>
public class CatalogoActividadesTests
{
    [Fact]
    public void CadaUnidadTieneAlMenosUnaActividad()
    {
        foreach (UnidadInfo unidad in CatalogoActividades.Unidades)
            Assert.NotEmpty(CatalogoActividades.DeUnidad(unidad.Numero));
    }

    [Fact]
    public void LasClavesNoSeRepitenYLasPantallasHeredanDeLaBase()
    {
        List<string> claves = CatalogoActividades.Actividades.Select(a => a.Clave).ToList();
        Assert.Equal(claves.Count, claves.Distinct().Count());
        Assert.All(CatalogoActividades.Actividades, a =>
            Assert.True(typeof(FrmActividadBase).IsAssignableFrom(a.TipoFormulario), $"{a.Formulario} debe heredar de FrmActividadBase"));
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

    [Theory]
    [InlineData(@"Prueba\RM_100758645_U1")]
    [InlineData("Prueba")]
    [InlineData(@"Prueba\RM_100758645_U2\Banco")]
    [InlineData("FormCursoEstudiante")]
    [InlineData(@"Practica\Alquiler de vehiculos")]
    [InlineData("SistemaVehiculos")]
    [InlineData("Polimorfismo")]
    [InlineData("ClasesAbstractas")]
    [InlineData("Nomina")]
    [InlineData("Pedidos")]
    [InlineData(@"Practica\Tryparse")]
    public void CadaProyectoOriginalEstaEnlazado(string carpeta)
    {
        Assert.Contains(CatalogoActividades.Originales, a => a.Original!.Carpeta == carpeta);
    }

    [Fact]
    public void LosProyectosOriginalesExistenYLosDeConsolaEstanCompilados()
    {
        foreach (ActividadInfo actividad in CatalogoActividades.Originales)
        {
            ProyectoOriginal proyecto = actividad.Original!;
            Assert.True(Directory.Exists(proyecto.RutaCarpeta), $"No existe la carpeta {proyecto.RutaCarpeta}");

            if (proyecto.Tipo == TipoProyectoOriginal.Consola)
                Assert.True(File.Exists(proyecto.RutaEjecutable), $"No se compiló {proyecto.RutaEjecutable}");
            else
                Assert.NotNull(proyecto.CrearFormulario);
        }
    }
}
