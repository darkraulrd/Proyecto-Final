using ProyectoIntegradorPOO.Interfaces;

namespace ProyectoIntegradorPOO.Models.Unidad5;

/// <summary>Un producto del menú FoodExpress con su precio (RD$).</summary>
public sealed record ItemMenu(string Nombre, decimal Precio)
{
    public override string ToString() => $"{Nombre} — RD$ {Precio:N2}";
}

/// <summary>Menú disponible para pedir.</summary>
public static class Catalogo
{
    public static IReadOnlyList<ItemMenu> Items { get; } = new List<ItemMenu>
    {
        new ItemMenu("Hamburguesa", 350m),
        new ItemMenu("Pizza", 600m),
        new ItemMenu("Papas fritas", 150m),
        new ItemMenu("Refresco", 80m),
        new ItemMenu("Jugo natural", 120m)
    };
}

/// <summary>Línea de un pedido FoodExpress. Implementa ICalculable.</summary>
public sealed class DetalleComida : ICalculable
{
    public const int CantidadMaxima = 99;

    public DetalleComida(string producto, int cantidad, decimal precio)
    {
        if (string.IsNullOrWhiteSpace(producto))
            throw new ArgumentException("El nombre del producto no puede estar vacío.");
        if (cantidad <= 0 || cantidad > CantidadMaxima)
            throw new ArgumentException($"La cantidad debe estar entre 1 y {CantidadMaxima}.");
        if (precio <= 0)
            throw new ArgumentException("El precio debe ser mayor que cero.");

        Producto = producto.Trim();
        Cantidad = cantidad;
        Precio = precio;
    }

    public string Producto { get; }
    public int Cantidad { get; }
    public decimal Precio { get; }

    public string Descripcion => $"{Cantidad} × {Producto}";

    public Importe CalcularImporte() => new Importe(Cantidad * Precio);
}
