using System.Text.Encodings.Web;
using System.Text.Json;
using ProyectoIntegradorPOO.Exceptions;
using ProyectoIntegradorPOO.Interfaces;

namespace ProyectoIntegradorPOO.Repositories;

/// <summary>
/// UNIDAD 6 — Repositorio genérico que guarda una lista de entidades en un archivo JSON
/// usando System.Text.Json. Es la ÚNICA clase que toca el disco.
/// Cada operación lee el archivo, aplica el cambio y lo vuelve a escribir de forma segura
/// (primero en un archivo temporal y luego lo reemplaza) para no corromper los datos.
/// </summary>
public class RepositorioJson<T> : IRepositorio<T> where T : class, IEntidad
{
    private static readonly JsonSerializerOptions Opciones = new JsonSerializerOptions
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping // conserva tildes y ñ legibles
    };

    private readonly string rutaArchivo;

    public RepositorioJson(string rutaArchivo)
    {
        if (string.IsNullOrWhiteSpace(rutaArchivo))
            throw new ArgumentException("Debe indicar la ruta del archivo.", nameof(rutaArchivo));
        this.rutaArchivo = Path.GetFullPath(rutaArchivo);
    }

    public string Ubicacion => rutaArchivo;

    public bool ExisteAlmacen() => File.Exists(rutaArchivo);

    public async Task<List<T>> ObtenerTodosAsync()
    {
        if (!ExisteAlmacen())
            return new List<T>();

        try
        {
            await using FileStream lectura = File.OpenRead(rutaArchivo);
            if (lectura.Length == 0)
                return new List<T>();

            return await JsonSerializer.DeserializeAsync<List<T>>(lectura, Opciones) ?? new List<T>();
        }
        catch (JsonException ex)
        {
            throw new PersistenciaException($"El archivo de datos está dañado y no se pudo leer:\n{rutaArchivo}", ex);
        }
        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
        {
            throw new PersistenciaException($"No se pudo leer el archivo de datos:\n{rutaArchivo}", ex);
        }
    }

    public async Task<T?> ObtenerPorIdAsync(string id)
    {
        List<T> todos = await ObtenerTodosAsync();
        return todos.FirstOrDefault(e => MismoId(e.Id, id));
    }

    public async Task AgregarAsync(T entidad)
    {
        ArgumentNullException.ThrowIfNull(entidad);
        List<T> todos = await ObtenerTodosAsync();

        if (todos.Any(e => MismoId(e.Id, entidad.Id)))
            throw new RegistroDuplicadoException(entidad.Id);

        todos.Add(entidad);
        await GuardarAsync(todos);
    }

    public async Task ActualizarAsync(T entidad)
    {
        ArgumentNullException.ThrowIfNull(entidad);
        List<T> todos = await ObtenerTodosAsync();

        int posicion = todos.FindIndex(e => MismoId(e.Id, entidad.Id));
        if (posicion < 0)
            throw new KeyNotFoundException($"No existe un registro con el identificador '{entidad.Id}'.");

        todos[posicion] = entidad;
        await GuardarAsync(todos);
    }

    public async Task<bool> EliminarAsync(string id)
    {
        List<T> todos = await ObtenerTodosAsync();
        if (todos.RemoveAll(e => MismoId(e.Id, id)) == 0)
            return false;

        await GuardarAsync(todos);
        return true;
    }

    private async Task GuardarAsync(List<T> entidades)
    {
        string temporal = rutaArchivo + ".tmp";
        try
        {
            string? carpeta = Path.GetDirectoryName(rutaArchivo);
            if (!string.IsNullOrEmpty(carpeta))
                Directory.CreateDirectory(carpeta);

            await using (FileStream escritura = File.Create(temporal))
            {
                await JsonSerializer.SerializeAsync(escritura, entidades, Opciones);
            }

            File.Move(temporal, rutaArchivo, overwrite: true);
        }
        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
        {
            throw new PersistenciaException($"No se pudo guardar el archivo de datos:\n{rutaArchivo}", ex);
        }
        finally
        {
            // Si algo falló a mitad de camino, no se deja basura en la carpeta.
            if (File.Exists(temporal))
                File.Delete(temporal);
        }
    }

    private static bool MismoId(string a, string b) => string.Equals(a, b?.Trim(), StringComparison.OrdinalIgnoreCase);
}
