namespace ProyectoIntegradorPOO.Models.Unidad3;

/// <summary>
/// Línea de un pedido. Su constructor es internal: solo Pedido puede crearla (COMPOSICIÓN).
/// </summary>
public class DetallePedido
{
    internal DetallePedido(string producto, int cantidad, decimal precio)
    {
        if (string.IsNullOrWhiteSpace(producto))
            throw new ArgumentException("El nombre del producto es obligatorio.");
        if (cantidad <= 0)
            throw new ArgumentException("La cantidad debe ser un valor positivo.");
        if (precio <= 0)
            throw new ArgumentException("El precio debe ser mayor que cero.");

        Producto = producto.Trim();
        Cantidad = cantidad;
        Precio = precio;
    }

    public string Producto { get; }
    public int Cantidad { get; }
    public decimal Precio { get; }

    public decimal CalcularTotal() => Cantidad * Precio;
}
