using ProyectoIntegradorPOO.Forms.Comun;
using ProyectoIntegradorPOO.Forms.Originales;

namespace ProyectoIntegradorPOO.Tests.Comun;

/// <summary>Protege la regla de conservación: cada proyecto del curso sigue enlazado y accesible.</summary>
public class CatalogoActividadesTests
{
    [Fact]
    public void CadaUnidadTieneAlMenosUnProyecto()
    {
        foreach (UnidadInfo unidad in CatalogoActividades.Unidades)
            Assert.NotEmpty(CatalogoActividades.DeUnidad(unidad.Numero));
    }

    [Fact]
    public void LasClavesNoSeRepiten()
    {
        List<string> claves = CatalogoActividades.Actividades.Select(a => a.Clave).ToList();
        Assert.Equal(claves.Count, claves.Distinct().Count());
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
        Assert.Contains(CatalogoActividades.Actividades, a => a.Original.Carpeta == carpeta);
    }

    [Fact]
    public void LosProyectosOriginalesExistenYLosDeConsolaEstanCompilados()
    {
        foreach (ActividadInfo actividad in CatalogoActividades.Actividades)
        {
            ProyectoOriginal proyecto = actividad.Original;
            Assert.True(Directory.Exists(proyecto.RutaCarpeta), $"No existe la carpeta {proyecto.RutaCarpeta}");

            if (proyecto.Tipo == TipoProyectoOriginal.Consola)
                Assert.True(File.Exists(proyecto.RutaEjecutable), $"No se compiló {proyecto.RutaEjecutable}");
            else
                Assert.NotNull(proyecto.CrearFormulario);
        }
    }
}
