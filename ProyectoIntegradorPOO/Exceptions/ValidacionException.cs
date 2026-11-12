namespace ProyectoIntegradorPOO.Exceptions;

/// <summary>
/// UNIDAD 6 — EXCEPCIÓN PERSONALIZADA.
/// Se lanza cuando un dato introducido por el usuario no cumple una regla.
/// Guarda el nombre del campo para que la interfaz pueda señalarlo.
/// </summary>
public class ValidacionException : Exception
{
    public ValidacionException(string campo, string mensaje) : base(mensaje)
    {
        Campo = campo;
    }

    public ValidacionException(string campo, string mensaje, Exception causa) : base(mensaje, causa)
    {
        Campo = campo;
    }

    public string Campo { get; }
}
