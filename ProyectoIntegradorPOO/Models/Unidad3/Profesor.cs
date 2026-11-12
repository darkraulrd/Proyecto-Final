namespace ProyectoIntegradorPOO.Models.Unidad3;

/// <summary>
/// Profesor que imparte cursos. Un curso CONOCE a su profesor (ASOCIACIÓN):
/// ambos objetos viven por separado y un profesor puede impartir varios cursos.
/// </summary>
public class Profesor
{
    public Profesor(string nombre, string especialidad)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre del profesor es obligatorio.");
        if (string.IsNullOrWhiteSpace(especialidad))
            throw new ArgumentException("La especialidad del profesor es obligatoria.");

        Nombre = nombre.Trim();
        Especialidad = especialidad.Trim();
    }

    public string Nombre { get; }
    public string Especialidad { get; }

    public override string ToString() => $"{Nombre} ({Especialidad})";
}
