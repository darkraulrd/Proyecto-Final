namespace ProyectoIntegradorPOO.Models.Unidad3;

/// <summary>
/// Departamento académico. Relación de COMPOSICIÓN con Curso:
/// el departamento CREA sus cursos (el constructor de Curso es internal) y es su dueño.
/// Un curso no existe sin su departamento; al cerrar el departamento sus cursos desaparecen.
/// </summary>
public class Departamento
{
    private readonly List<Curso> cursos = new List<Curso>();

    public Departamento(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre del departamento es obligatorio.");
        Nombre = nombre.Trim();
    }

    public string Nombre { get; }

    public IReadOnlyList<Curso> Cursos => cursos.AsReadOnly();

    /// <summary>El único lugar donde nace un Curso: dentro de su departamento.</summary>
    public Curso CrearCurso(string codigo, string nombre, int creditos)
    {
        if (cursos.Any(c => c.Codigo.Equals(codigo?.Trim(), StringComparison.OrdinalIgnoreCase)))
            throw new InvalidOperationException($"Ya existe un curso con el código {codigo?.Trim().ToUpperInvariant()}.");

        Curso curso = new Curso(codigo!, nombre, creditos, this);
        cursos.Add(curso);
        return curso;
    }

    public bool EliminarCurso(Curso curso) => cursos.Remove(curso);

    /// <summary>Cierra el departamento: al ser dueño de los cursos, los elimina todos.</summary>
    public void Cerrar() => cursos.Clear();

    public override string ToString() => Nombre;
}
