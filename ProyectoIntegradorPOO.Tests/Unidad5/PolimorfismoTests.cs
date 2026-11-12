using ProyectoIntegradorPOO.Interfaces;
using ProyectoIntegradorPOO.Models.Unidad5;

namespace ProyectoIntegradorPOO.Tests.Unidad5;

public class PolimorfismoTests
{
    [Fact]
    public void CargoAdicional_DependeDelTipoDePedido()
    {
        PedidoBase local = PedidoBase.Crear(TipoServicio.Local, "Ana", "");
        PedidoBase domicilio = PedidoBase.Crear(TipoServicio.Domicilio, "Ana", "Calle 1");
        PedidoBase llevar = PedidoBase.Crear(TipoServicio.ParaLlevar, "Ana", "");

        foreach (PedidoBase pedido in new[] { local, domicilio, llevar })
            pedido.AgregarDetalle("Pizza", 1, 600m);

        Assert.Equal(60m, local.CalcularCargoAdicional().Monto);
        Assert.Equal(PedidoDomicilio.CargoEntrega, domicilio.CalcularCargoAdicional().Monto);
        Assert.Equal(PedidoParaLlevar.CargoEmpaque, llevar.CalcularCargoAdicional().Monto);
        Assert.Equal(660m, local.Total().Monto);
    }

    [Fact]
    public void Domicilio_ExigeDireccion()
    {
        Assert.Throws<ArgumentException>(() => PedidoBase.Crear(TipoServicio.Domicilio, "Ana", " "));
    }

    [Fact]
    public void AgregarDetalle_SobrecargasAcumulanElMismoProducto()
    {
        PedidoBase pedido = new PedidoParaLlevar("Ana");
        ItemMenu pizza = Catalogo.Items.First(i => i.Nombre == "Pizza");

        pedido.AgregarDetalle(pizza, 1);
        pedido.AgregarDetalle("pizza", 2, pizza.Precio);
        pedido.AgregarDetalle(new DetalleComida("Refresco", 1, 80m));

        Assert.Equal(2, pedido.Detalles.Count);
        Assert.Equal(3, pedido.Detalles[0].Cantidad);
        Assert.Equal(1880m, pedido.Subtotal().Monto);
    }

    [Fact]
    public void OperadorMas_CombinaPedidosSumandoTotales()
    {
        PedidoBase a = new PedidoLocal("Ana");
        a.AgregarDetalle("Pizza", 1, 600m);                 // total 660
        PedidoBase b = new PedidoDomicilio("Luis", "Calle 1");
        b.AgregarDetalle("Hamburguesa", 2, 350m);           // total 850

        PedidoBase combinado = a + b;

        Assert.IsType<PedidoCombinado>(combinado);
        Assert.Equal(a.Total().Monto + b.Total().Monto, combinado.Total().Monto);
        Assert.Equal(2, combinado.Detalles.Count);
        Assert.Throws<InvalidOperationException>(() => a + a);
    }

    [Fact]
    public void Importe_OperadorMasYValidacion()
    {
        Importe total = new Importe(10.5m) + new Importe(4.5m);
        Assert.Equal(15m, total.Monto);
        Assert.Throws<ArgumentException>(() => new Importe(-1m));
    }

    [Fact]
    public void ICalculable_PermiteTratarClasesDistintasPorIgual()
    {
        PedidoBase pedido = new PedidoParaLlevar("Ana");
        pedido.AgregarDetalle("Jugo", 2, 120m);

        List<ICalculable> calculables = new List<ICalculable> { pedido, pedido.Detalles[0] };

        Assert.Equal(265m, calculables[0].CalcularImporte().Monto);
        Assert.Equal(240m, calculables[1].CalcularImporte().Monto);
    }

    [Fact]
    public void Vector2D_SumaYResta()
    {
        Vector2D a = new Vector2D(3, 4);
        Vector2D b = new Vector2D(-2, 1);

        Assert.Equal(new Vector2D(1, 5), a + b);
        Assert.Equal(new Vector2D(5, 3), a - b);
        Assert.Equal(5, a.Magnitud, 6);
    }

    [Fact]
    public void Vector2D_IgualdadPorValorYHashCoherente()
    {
        Vector2D a = new Vector2D(1.5, 2);
        Vector2D b = new Vector2D(1.5, 2);
        Vector2D c = new Vector2D(2, 1.5);

        Assert.False(ReferenceEquals(a, b));
        Assert.True(a == b);
        Assert.False(a != b);
        Assert.True(a != c);
        Assert.True(a.Equals((object)b));
        Assert.Equal(a.GetHashCode(), b.GetHashCode());
        Assert.Single(new HashSet<Vector2D> { a, b });
    }

    [Fact]
    public void Vector2D_ComparacionConNull()
    {
        Vector2D a = new Vector2D(0, 0);
        Vector2D? nulo = null;

        Assert.False(a == nulo);
        Assert.True(a != nulo);
        Assert.True(nulo == null);
        Assert.False(a.Equals(null));
    }
}
