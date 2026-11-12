namespace ProyectoIntegradorPOO.Models.Unidad3;

/// <summary>
/// Curso académico. Muestra dos relaciones:
///  - ASOCIACIÓN con Profesor: el curso guarda una referencia a un profesor que existe aparte.
///  - AGREGACIÓN con Estudiante (1..*): el curso contiene una List&lt;Estudiante&gt;, pero los
///    estudiantes no dependen del curso; si el curso desaparece, los estudiantes siguen existiendo.
/// El curso solo puede crearse desde un Departamento (constructor internal), ver Departamento.cs.
/// </summary>
public class Curso
{
    private readonly List<Estudiante> estudiantes = new List<Estudiante>();

    internal Curso(string codigo, string nombre, int creditos, Departamento departamento)
    {
        if (string.IsNullOrWhiteSpace(codigo))
            throw new ArgumentException("El código del curso es obligatorio.");
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre del curso es obligatorio.");
        if (creditos <= 0 || creditos > 10)
            throw new ArgumentException("Los créditos deben estar entre 1 y 10.");

        Codigo = codigo.Trim().ToUpperInvariant();
        Nombre = nombre.Trim();
        Creditos = creditos;
        Departamento = departamento;
    }

    public string Codigo { get; }
    public string Nombre { get; }
    public int Creditos { get; }
    public Departamento Departamento { get; }

    // Asociación: puede no tener profesor asignado todavía.
    public Profesor? Profesor { get; private set; }

    public IReadOnlyList<Estudiante> Estudiantes => estudiantes.AsReadOnly();

    public void AsignarProfesor(Profesor profesor)
    {
        Profesor = profesor ?? throw new ArgumentNullException(nameof(profesor), "Debe indicar un profesor.");
    }

    public void InscribirEstudiante(Estudiante estudiante)
    {
        ArgumentNullException.ThrowIfNull(estudiante);

        if (estudiantes.Any(e => e.Matricula.Equals(estudiante.Matricula, StringComparison.OrdinalIgnoreCase)))
            throw new InvalidOperationException($"El estudiante {estudiante.Matricula} ya está inscrito en {Codigo}.");

        estudiantes.Add(estudiante);
    }

    public bool RetirarEstudiante(Estudiante estudiante) => estudiantes.Remove(estudiante);

    public override string ToString() => $"{Codigo} - {Nombre}";
}
