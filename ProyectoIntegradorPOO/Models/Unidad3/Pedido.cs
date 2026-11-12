namespace ProyectoIntegradorPOO.Models.Unidad3;

/// <summary>
/// Laboratorio Unidad 3 — COMPOSICIÓN (rombo lleno, multiplicidad 1..*).
/// Un Pedido está compuesto por varios DetallePedido. Los detalles se crean DENTRO del pedido
/// (el constructor de DetallePedido es internal) y no tienen sentido fuera de él:
/// si se elimina el pedido, sus detalles desaparecen con él.
/// </summary>
public class Pedido
{
    private static int contador;
    private readonly List<DetallePedido> detalles = new List<DetallePedido>();

    public Pedido(string cliente)
    {
        if (string.IsNullOrWhiteSpace(cliente))
            throw new ArgumentException("El nombre del cliente no puede estar vacío.");

        contador++;
        Numero = contador;
        Cliente = cliente.Trim();
        Fecha = DateTime.Now;
    }

    public int Numero { get; }
    public string Cliente { get; }
    public DateTime Fecha { get; }
    public IReadOnlyList<DetallePedido> Detalles => detalles.AsReadOnly();

    /// <summary>El pedido fabrica el detalle: el detalle nace y muere con el pedido.</summary>
    public DetallePedido AgregarDetalle(string producto, int cantidad, decimal precio)
    {
        DetallePedido detalle = new DetallePedido(producto, cantidad, precio);
        detalles.Add(detalle);
        return detalle;
    }

    public void QuitarDetalle(int indice)
    {
        if (indice < 0 || indice >= detalles.Count)
            throw new ArgumentOutOfRangeException(nameof(indice), "El detalle seleccionado no existe.");
        detalles.RemoveAt(indice);
    }

    public decimal CalcularTotal() => detalles.Sum(d => d.CalcularTotal());
}
