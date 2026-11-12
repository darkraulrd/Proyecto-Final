namespace ProyectoIntegradorPOO.Exceptions;

/// <summary>
/// UNIDAD 6 — EXCEPCIÓN PERSONALIZADA.
/// Envuelve los errores técnicos de lectura/escritura (IOException, JsonException,
/// UnauthorizedAccessException...) en un mensaje comprensible para el usuario.
/// La excepción original se conserva en InnerException para diagnóstico.
/// </summary>
public class PersistenciaException : Exception
{
    public PersistenciaException(string mensaje, Exception causa) : base(mensaje, causa) { }
}

/// <summary>Se lanza cuando se intenta registrar un elemento con un identificador ya existente.</summary>
public class RegistroDuplicadoException : Exception
{
    public RegistroDuplicadoException(string id)
        : base($"Ya existe un registro con el identificador '{id}'.")
    {
        Id = id;
    }

    public string Id { get; }
}
