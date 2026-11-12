using ProyectoIntegradorPOO.Models.Unidad4;

namespace ProyectoIntegradorPOO.Tests.Unidad4;

public class HerenciaTests
{
    [Fact]
    public void Motocicleta_HeredaDeVehiculoYUsaConstructorBase()
    {
        Vehiculo vehiculo = new Motocicleta("Yamaha", "FZ 150", 150);

        Assert.IsAssignableFrom<Vehiculo>(vehiculo);
        Assert.Equal("Yamaha", vehiculo.Marca);
        Assert.Contains("Motocicleta", vehiculo.MostrarInformacion());
        Assert.Equal("Cilindrada: 150 cc", ((Motocicleta)vehiculo).MostrarCilindrada());
    }

    [Fact]
    public void MostrarRol_DependeDelTipoReal()
    {
        Persona persona = new Persona("Juan", 30);
        Assert.Equal("Soy una persona.", persona.MostrarRol());

        persona = new EstudianteRol("Raúl", 20);
        Assert.Equal("Soy un estudiante.", persona.MostrarRol());

        persona = new ProfesorRol("Carlos", 45);
        Assert.Equal("Soy un profesor.", persona.MostrarRol());
    }

    [Fact]
    public void Figuras_CalculanSuAreaPolimorficamente()
    {
        List<Figura> figuras = new List<Figura> { new Rectangulo(5, 3), new Circulo(2) };

        Assert.Equal(15, figuras[0].CalcularArea(), 6);
        Assert.Equal(Math.PI * 4, figuras[1].CalcularArea(), 6);
        Assert.True(typeof(Figura).IsAbstract);
    }

    [Fact]
    public void Empleados_CalculanSalarioSegunSuTipo()
    {
        Nomina nomina = new Nomina();
        nomina.Agregar(new EmpleadoFijo("E1", "Ana", 30000m));
        nomina.Agregar(new EmpleadoPorHoras("E2", "Luis", 40m, 250m));
        nomina.Agregar(new EmpleadoComision("E3", "Eva", 15000m, 100000m, 5m));

        Assert.Equal(30000m, nomina.Empleados[0].CalcularSalario());
        Assert.Equal(10000m, nomina.Empleados[1].CalcularSalario());
        Assert.Equal(20000m, nomina.Empleados[2].CalcularSalario());
        Assert.Equal(60000m, nomina.CalcularTotal());
    }

    [Fact]
    public void Nomina_NoPermiteCodigosRepetidos()
    {
        Nomina nomina = new Nomina();
        nomina.Agregar(new EmpleadoFijo("e1", "Ana", 30000m));
        Assert.Throws<InvalidOperationException>(() => nomina.Agregar(new EmpleadoFijo("E1", "Otra", 1000m)));
    }

    [Fact]
    public void Empleados_ValidanSusDatos()
    {
        Assert.Throws<ArgumentException>(() => new EmpleadoFijo("E1", "Ana", 0m));
        Assert.Throws<ArgumentException>(() => new EmpleadoPorHoras("E1", "Ana", -1m, 100m));
        Assert.Throws<ArgumentException>(() => new EmpleadoComision("E1", "Ana", 1000m, 500m, 150m));
    }
}
