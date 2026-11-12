namespace ProyectoIntegradorPOO.Interfaces;

/// <summary>Toda entidad que se guarda en un repositorio debe tener un identificador único.</summary>
public interface IEntidad
{
    string Id { get; }
}

/// <summary>
/// UNIDAD 6 — Contrato de persistencia. El servicio y el formulario dependen de esta
/// interfaz, no de "archivos JSON": se podría cambiar a otra forma de guardar
/// sin tocar la lógica de negocio (por ejemplo, un repositorio en memoria para pruebas).
/// </summary>
public interface IRepositorio<T> where T : IEntidad
{
    string Ubicacion { get; }

    bool ExisteAlmacen();

    Task<List<T>> ObtenerTodosAsync();

    Task<T?> ObtenerPorIdAsync(string id);

    Task AgregarAsync(T entidad);

    Task ActualizarAsync(T entidad);

    Task<bool> EliminarAsync(string id);
}
