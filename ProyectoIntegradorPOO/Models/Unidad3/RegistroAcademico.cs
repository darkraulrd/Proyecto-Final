namespace ProyectoIntegradorPOO.Models.Unidad3;

/// <summary>
/// Contenedor de objetos de la actividad: agrupa las colecciones List&lt;T&gt; de estudiantes
/// y profesores registrados, y el departamento con sus cursos.
/// Así el formulario no guarda listas ni reglas propias: solo llama a estos métodos.
/// </summary>
public class RegistroAcademico
{
    private readonly List<Estudiante> estudiantes = new List<Estudiante>();
    private readonly List<Profesor> profesores = new List<Profesor>();

    public RegistroAcademico(string nombreDepartamento)
    {
        Departamento = new Departamento(nombreDepartamento);
    }

    public Departamento Departamento { get; }
    public IReadOnlyList<Estudiante> Estudiantes => estudiantes.AsReadOnly();
    public IReadOnlyList<Profesor> Profesores => profesores.AsReadOnly();

    public Estudiante RegistrarEstudiante(string nombre, string matricula, int edad)
    {
        if (estudiantes.Any(e => e.Matricula.Equals(matricula?.Trim(), StringComparison.OrdinalIgnoreCase)))
            throw new InvalidOperationException($"Ya existe un estudiante con la matrícula {matricula?.Trim()}.");

        Estudiante estudiante = new Estudiante(nombre, matricula!, edad);
        estudiantes.Add(estudiante);
        return estudiante;
    }

    public Profesor RegistrarProfesor(string nombre, string especialidad)
    {
        Profesor profesor = new Profesor(nombre, especialidad);
        profesores.Add(profesor);
        return profesor;
    }

    /// <summary>Cursos en los que está inscrito un estudiante (la agregación vista desde el otro lado).</summary>
    public IEnumerable<Curso> CursosDe(Estudiante estudiante) =>
        Departamento.Cursos.Where(c => c.Estudiantes.Contains(estudiante));
}
