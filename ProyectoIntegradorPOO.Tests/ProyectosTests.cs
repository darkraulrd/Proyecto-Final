using System.Windows.Forms;

namespace ProyectoIntegradorPOO.Tests
{
    // Protege la regla de conservación: cada proyecto del curso sigue enlazado y se puede abrir
    public class ProyectosTests
    {
        [Fact]
        public void CadaUnidadTieneAlMenosUnProyecto()
        {
            foreach (Unidad unidad in Proyectos.Unidades)
                Assert.NotEmpty(Proyectos.DeUnidad(unidad.Numero));
        }

        [Fact]
        public void LasCarpetasNoSeRepiten()
        {
            var carpetas = Proyectos.Lista.Select(p => p.Carpeta).ToList();
            Assert.Equal(carpetas.Count, carpetas.Distinct().Count());
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
            Assert.Contains(Proyectos.Lista, p => p.Carpeta == carpeta);
        }

        [Fact]
        public void LosProyectosExistenYLosDeConsolaEstanCompilados()
        {
            foreach (ProyectoCurso proyecto in Proyectos.Lista)
            {
                Assert.True(Directory.Exists(proyecto.RutaCarpeta), $"No existe la carpeta {proyecto.RutaCarpeta}");

                if (proyecto is ProyectoConsola consola)
                    Assert.True(File.Exists(consola.RutaEjecutable), $"No se compiló {consola.RutaEjecutable}");
                else if (proyecto is ProyectoFormulario formulario)
                    Assert.NotNull(formulario.CrearFormulario);
            }
        }

        [Fact]
        public void CadaTipoDeProyectoCreaSuPropiaVista()
        {
            // Polimorfismo: la misma llamada CrearVista() devuelve una pantalla distinta según el tipo
            ProyectoCurso consola = Proyectos.Lista.First(p => p is ProyectoConsola);
            ProyectoCurso formulario = Proyectos.Lista.First(p => p is ProyectoFormulario);

            using UserControl vistaConsola = consola.CrearVista();
            using UserControl vistaFormulario = formulario.CrearVista();

            Assert.IsType<ucConsola>(vistaConsola);
            Assert.IsType<ucFormulario>(vistaFormulario);
        }

        [Fact]
        public void BuscarFiltraPorNombreCarpetaYConceptos()
        {
            Assert.Equal(Proyectos.Lista.Count, Proyectos.Buscar("").Count);
            Assert.Contains(Proyectos.Buscar("nomina"), p => p.Nombre == "Nomina");
            Assert.Contains(Proyectos.Buscar("try"), p => p.Nombre == "Tryparse");
            Assert.All(Proyectos.Buscar("Windows Forms"), p => Assert.IsType<ProyectoFormulario>(p));
        }

        [Fact]
        public void UnProyectoSinNombreNoSePuedeCrear()
        {
            Assert.Throws<ArgumentException>(() => new ProyectoConsola { Nombre = " ", Carpeta = "X" });
        }
    }
}
