using ProyectoIntegradorPOO.Exceptions;
using ProyectoIntegradorPOO.Models.Unidad6;
using ProyectoIntegradorPOO.Repositories;
using ProyectoIntegradorPOO.Services;

namespace ProyectoIntegradorPOO.Tests.Unidad6;

/// <summary>Cada prueba usa su propio archivo temporal, que se borra al terminar.</summary>
public sealed class PersistenciaTests : IDisposable
{
    private readonly string carpeta = Path.Combine(Path.GetTempPath(), "PIPOO_Tests_" + Guid.NewGuid().ToString("N"));
    private string Ruta => Path.Combine(carpeta, "estudiantes.json");

    public void Dispose()
    {
        if (Directory.Exists(carpeta))
            Directory.Delete(carpeta, recursive: true);
    }

    private ServicioEstudiantes NuevoServicio() =>
        new ServicioEstudiantes(new RepositorioJson<EstudianteRegistro>(Ruta));

    [Fact]
    public async Task Crud_CompletoSobreArchivoJson()
    {
        ServicioEstudiantes servicio = NuevoServicio();
        Assert.False(servicio.ExisteArchivo());
        Assert.Empty(await servicio.ListarAsync());

        await servicio.RegistrarAsync("100123456", "José Núñez", "Informática", "21", "3.5");
        Assert.True(servicio.ExisteArchivo());

        await servicio.ActualizarAsync("100123456", "José Núñez", "Ingeniería de Software", "22", "3,75");
        EstudianteRegistro guardado = Assert.Single(await servicio.ListarAsync());
        Assert.Equal("Ingeniería de Software", guardado.Carrera);
        Assert.Equal(22, guardado.Edad);
        Assert.Equal(3.75m, guardado.Indice);

        await servicio.EliminarAsync("100123456");
        Assert.Empty(await servicio.ListarAsync());
    }

    [Fact]
    public async Task Datos_SeConservanEntreInstancias()
    {
        await NuevoServicio().RegistrarAsync("100000001", "Ana", "Matemática", "19", "4");

        // Simula cerrar y volver a abrir la aplicación: un servicio nuevo lee el mismo archivo.
        EstudianteRegistro leido = Assert.Single(await NuevoServicio().ListarAsync());
        Assert.Equal("Ana", leido.Nombre);
        Assert.Contains("Matemática", await File.ReadAllTextAsync(Ruta)); // tildes legibles en el JSON
    }

    [Fact]
    public async Task Registrar_MatriculaDuplicadaLanzaExcepcionPersonalizada()
    {
        ServicioEstudiantes servicio = NuevoServicio();
        await servicio.RegistrarAsync("100000001", "Ana", "Matemática", "19", "4");

        await Assert.ThrowsAsync<RegistroDuplicadoException>(() =>
            servicio.RegistrarAsync("100000001", "Otra", "Matemática", "20", "3"));
    }

    [Theory]
    [InlineData("", "Ana", "Mat", "20", "3", "Matricula")]
    [InlineData("12AB56", "Ana", "Mat", "20", "3", "Matricula")]
    [InlineData("100000001", "", "Mat", "20", "3", "Nombre")]
    [InlineData("100000001", "Ana", "", "20", "3", "Carrera")]
    [InlineData("100000001", "Ana", "Mat", "veinte", "3", "Edad")]
    [InlineData("100000001", "Ana", "Mat", "5", "3", "Edad")]
    [InlineData("100000001", "Ana", "Mat", "20", "4.5", "Indice")]
    [InlineData("100000001", "Ana", "Mat", "20", "x", "Indice")]
    public void Construir_IndicaElCampoInvalido(string matricula, string nombre, string carrera, string edad, string indice, string campo)
    {
        ValidacionException ex = Assert.Throws<ValidacionException>(() =>
            ServicioEstudiantes.Construir(matricula, nombre, carrera, edad, indice));
        Assert.Equal(campo, ex.Campo);
    }

    [Fact]
    public void Construir_ConservaLaExcepcionOriginalComoInner()
    {
        ValidacionException ex = Assert.Throws<ValidacionException>(() =>
            ServicioEstudiantes.Construir("100000001", "Ana", "Mat", "abc", "3"));
        Assert.IsType<FormatException>(ex.InnerException);
    }

    [Fact]
    public async Task ArchivoDanado_LanzaPersistenciaException()
    {
        Directory.CreateDirectory(carpeta);
        await File.WriteAllTextAsync(Ruta, "{ esto no es JSON válido");

        PersistenciaException ex = await Assert.ThrowsAsync<PersistenciaException>(() => NuevoServicio().ListarAsync());
        Assert.NotNull(ex.InnerException);
    }

    [Fact]
    public async Task Eliminar_InexistenteLanzaValidacion()
    {
        await Assert.ThrowsAsync<ValidacionException>(() => NuevoServicio().EliminarAsync("999999"));
    }
}
