namespace ProyectoIntegradorPOO.Tests
{
    // Comprueba que todos los proyectos del curso siguen enlazados
    public class ProyectosTests
    {
        [Fact]
        public void CadaUnidadTieneAlMenosUnProyecto()
        {
            for (int unidad = 1; unidad <= Proyectos.Unidades.Length; unidad++)
                Assert.NotEmpty(Proyectos.DeUnidad(unidad));
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
        public void CadaProyectoEstaEnLaLista(string carpeta)
        {
            Assert.Contains(Proyectos.Lista, p => p.Carpeta == carpeta);
        }

        [Fact]
        public void LasCarpetasExistenYLosDeConsolaEstanCompilados()
        {
            foreach (Proyecto p in Proyectos.Lista)
            {
                Assert.True(Directory.Exists(p.RutaCarpeta), "No existe la carpeta " + p.RutaCarpeta);

                if (p.EsConsola)
                    Assert.True(File.Exists(p.RutaEjecutable), "No se compiló " + p.RutaEjecutable);
                else
                    Assert.NotNull(p.CrearFormulario);
            }
        }

        [Fact]
        public void ElTipoDependeDeSiEsConsola()
        {
            Proyecto consola = new Proyecto { EsConsola = true, Nombre = "A" };
            Proyecto formulario = new Proyecto { EsConsola = false, Nombre = "B" };

            Assert.Equal("Consola", consola.Tipo);
            Assert.Equal("Windows Forms", formulario.Tipo);
            Assert.Equal("A (Consola)", consola.ToString());
        }
    }
}
