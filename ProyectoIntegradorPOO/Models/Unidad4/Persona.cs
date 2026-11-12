namespace ProyectoIntegradorPOO.Models.Unidad4;

/// <summary>
/// Laboratorio 4.2 — POLIMORFISMO Y MÉTODOS SOBRESCRITOS.
/// MostrarRol() es virtual: las clases derivadas pueden reemplazarlo con override.
/// </summary>
public class Persona
{
    public Persona(string nombre, int edad)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre es obligatorio.");
        if (edad <= 0 || edad > 120)
            throw new ArgumentException("La edad debe estar entre 1 y 120 años.");

        Nombre = nombre.Trim();
        Edad = edad;
    }

    public string Nombre { get; }
    public int Edad { get; }

    public virtual string MostrarRol() => "Soy una persona.";
}

public class EstudianteRol : Persona
{
    public EstudianteRol(string nombre, int edad) : base(nombre, edad) { }

    public override string MostrarRol() => "Soy un estudiante.";
}

public class ProfesorRol : Persona
{
    public ProfesorRol(string nombre, int edad) : base(nombre, edad) { }

    public override string MostrarRol() => "Soy un profesor.";
}
