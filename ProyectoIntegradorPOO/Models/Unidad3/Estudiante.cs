namespace ProyectoIntegradorPOO.Models.Unidad3;

/// <summary>
/// Estudiante de la institución. Existe de forma independiente a los cursos:
/// un curso solo guarda una referencia a él (AGREGACIÓN).
/// </summary>
public class Estudiante
{
    private string nombre = "";
    private string matricula = "";
    private int edad;

    public Estudiante(string nombre, string matricula, int edad)
    {
        Nombre = nombre;
        Matricula = matricula;
        Edad = edad;
    }

    public string Nombre
    {
        get => nombre;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El nombre del estudiante es obligatorio.");
            nombre = value.Trim();
        }
    }

    public string Matricula
    {
        get => matricula;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("La matrícula del estudiante es obligatoria.");
            matricula = value.Trim();
        }
    }

    public int Edad
    {
        get => edad;
        private set
        {
            if (value <= 0 || value > 120)
                throw new ArgumentException("La edad debe estar entre 1 y 120 años.");
            edad = value;
        }
    }

    public override string ToString() => $"{Matricula} - {Nombre}";
}
