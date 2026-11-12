using ProyectoIntegradorPOO.Interfaces;

namespace ProyectoIntegradorPOO.Models.Unidad5;

public enum TipoServicio
{
    Local,
    Domicilio,
    ParaLlevar,
    Combinado
}

/// <summary>
/// FoodExpress — clase base ABSTRACTA de todos los pedidos (Laboratorio Unidad 5).
///  - Polimorfismo dinámico: cada tipo de pedido sobrescribe CalcularCargoAdicional().
///  - Polimorfismo estático: tres sobrecargas de AgregarDetalle().
///  - Sobrecarga de operadores: pedido + pedido = pedido combinado.
///  - Interfaces: implementa ICalculable.
/// </summary>
public abstract class PedidoBase : ICalculable
{
    private static int ultimoNumero;
    private readonly List<DetalleComida> detalles = new List<DetalleComida>();

    protected PedidoBase(string cliente)
    {
        if (string.IsNullOrWhiteSpace(cliente))
            throw new ArgumentException("El nombre del cliente no puede estar vacío.");

        Cliente = cliente.Trim();
        Numero = ++ultimoNumero;
    }

    public int Numero { get; }
    public string Cliente { get; }
    public IReadOnlyList<DetalleComida> Detalles => detalles.AsReadOnly();

    // ----- Miembros abstractos: cada derivada decide -----
    public abstract TipoServicio Servicio { get; }
    public abstract string NombreCargo { get; }
    public abstract Importe CalcularCargoAdicional();

    // Virtual con valor por defecto: solo el pedido a domicilio la sobrescribe.
    public virtual string Direccion => "";

    // ----- Polimorfismo estático: sobrecarga de AgregarDetalle -----

    /// <summary>1) Con un detalle ya creado. Si el producto ya existe con el mismo precio, acumula la cantidad.</summary>
    public void AgregarDetalle(DetalleComida detalle)
    {
        ArgumentNullException.ThrowIfNull(detalle);

        int posicion = detalles.FindIndex(d =>
            d.Producto.Equals(detalle.Producto, StringComparison.OrdinalIgnoreCase) && d.Precio == detalle.Precio);

        if (posicion < 0)
        {
            detalles.Add(detalle);
            return;
        }

        DetalleComida existente = detalles[posicion];
        detalles[posicion] = new DetalleComida(existente.Producto, existente.Cantidad + detalle.Cantidad, existente.Precio);
    }

    /// <summary>2) Con producto, cantidad y precio sueltos (producto personalizado).</summary>
    public void AgregarDetalle(string producto, int cantidad, decimal precio) =>
        AgregarDetalle(new DetalleComida(producto, cantidad, precio));

    /// <summary>3) Con un producto del menú y la cantidad.</summary>
    public void AgregarDetalle(ItemMenu item, int cantidad)
    {
        ArgumentNullException.ThrowIfNull(item);
        AgregarDetalle(item.Nombre, cantidad, item.Precio);
    }

    public void QuitarDetalle(int posicion)
    {
        if (posicion < 0 || posicion >= detalles.Count)
            throw new ArgumentOutOfRangeException(nameof(posicion), "Ese producto no está en el pedido.");
        detalles.RemoveAt(posicion);
    }

    /// <summary>Suma de las líneas usando el operador + de Importe.</summary>
    public Importe Subtotal()
    {
        Importe total = Importe.Cero;
        foreach (DetalleComida detalle in detalles)
            total += detalle.CalcularImporte();
        return total;
    }

    public Importe Total() => Subtotal() + CalcularCargoAdicional();

    // ----- ICalculable -----
    public string Descripcion => $"Pedido #{Numero} ({ServicioTexto(Servicio)}) — {Cliente}";
    public Importe CalcularImporte() => Total();

    /// <summary>
    /// Sobrecarga del operador + : combina dos pedidos en uno nuevo cuyo total es la suma
    /// de los totales originales (los detalles se unen y los cargos se suman).
    /// </summary>
    public static PedidoBase operator +(PedidoBase a, PedidoBase b)
    {
        ArgumentNullException.ThrowIfNull(a);
        ArgumentNullException.ThrowIfNull(b);
        if (ReferenceEquals(a, b))
            throw new InvalidOperationException("No se puede combinar un pedido consigo mismo.");

        string cliente = a.Cliente.Equals(b.Cliente, StringComparison.OrdinalIgnoreCase) ? a.Cliente : $"{a.Cliente} y {b.Cliente}";
        PedidoCombinado combinado = new PedidoCombinado(cliente, a.CalcularCargoAdicional() + b.CalcularCargoAdicional(), a.Numero, b.Numero);

        foreach (DetalleComida detalle in a.Detalles.Concat(b.Detalles))
            combinado.AgregarDetalle(detalle.Producto, detalle.Cantidad, detalle.Precio);

        return combinado;
    }

    /// <summary>Fábrica: crea el tipo concreto según el servicio elegido (devuelve la referencia base).</summary>
    public static PedidoBase Crear(TipoServicio servicio, string cliente, string direccion) => servicio switch
    {
        TipoServicio.Local => new PedidoLocal(cliente),
        TipoServicio.Domicilio => new PedidoDomicilio(cliente, direccion),
        TipoServicio.ParaLlevar => new PedidoParaLlevar(cliente),
        _ => throw new ArgumentException("Tipo de servicio no válido para un pedido nuevo.", nameof(servicio))
    };

    public static string ServicioTexto(TipoServicio servicio) => servicio switch
    {
        TipoServicio.Local => "Local",
        TipoServicio.Domicilio => "Domicilio",
        TipoServicio.ParaLlevar => "Para llevar",
        TipoServicio.Combinado => "Combinado",
        _ => servicio.ToString()
    };
}

/// <summary>Para comer en el local: 10 % de propina sobre el subtotal.</summary>
public class PedidoLocal : PedidoBase
{
    public const decimal PorcentajePropina = 0.10m;

    public PedidoLocal(string cliente) : base(cliente) { }

    public override TipoServicio Servicio => TipoServicio.Local;
    public override string NombreCargo => "Propina (10 %)";

    public override Importe CalcularCargoAdicional() =>
        new Importe(Math.Round(Subtotal().Monto * PorcentajePropina, 2, MidpointRounding.AwayFromZero));
}

/// <summary>A domicilio: cargo fijo de entrega y dirección obligatoria.</summary>
public class PedidoDomicilio : PedidoBase
{
    public const decimal CargoEntrega = 150m;
    private readonly string direccion;

    public PedidoDomicilio(string cliente, string direccion) : base(cliente)
    {
        if (string.IsNullOrWhiteSpace(direccion))
            throw new ArgumentException("La dirección de entrega es obligatoria para un pedido a domicilio.");
        this.direccion = direccion.Trim();
    }

    public override TipoServicio Servicio => TipoServicio.Domicilio;
    public override string NombreCargo => "Cargo por domicilio";
    public override string Direccion => direccion;

    public override Importe CalcularCargoAdicional() => new Importe(CargoEntrega);
}

/// <summary>Para llevar: cargo fijo de empaque.</summary>
public class PedidoParaLlevar : PedidoBase
{
    public const decimal CargoEmpaque = 25m;

    public PedidoParaLlevar(string cliente) : base(cliente) { }

    public override TipoServicio Servicio => TipoServicio.ParaLlevar;
    public override string NombreCargo => "Empaque";

    public override Importe CalcularCargoAdicional() => new Importe(CargoEmpaque);
}

/// <summary>Resultado de "pedidoA + pedidoB": conserva la suma de los cargos originales.</summary>
public class PedidoCombinado : PedidoBase
{
    private readonly Importe cargosCombinados;

    internal PedidoCombinado(string cliente, Importe cargosCombinados, int numeroA, int numeroB) : base(cliente)
    {
        this.cargosCombinados = cargosCombinados;
        Origen = $"#{numeroA} + #{numeroB}";
    }

    public string Origen { get; }

    public override TipoServicio Servicio => TipoServicio.Combinado;
    public override string NombreCargo => $"Cargos combinados ({Origen})";

    public override Importe CalcularCargoAdicional() => cargosCombinados;
}
