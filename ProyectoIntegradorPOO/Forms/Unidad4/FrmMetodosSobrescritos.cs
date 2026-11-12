using ProyectoIntegradorPOO.Forms.Comun;
using ProyectoIntegradorPOO.Models.Unidad4;

namespace ProyectoIntegradorPOO.Forms.Unidad4;

/// <summary>UNIDAD 4 — Laboratorio 4.2: virtual, override y variable polimórfica de tipo Persona.</summary>
public partial class FrmMetodosSobrescritos : FrmActividadBase
{
    // Todas las referencias son del tipo BASE Persona.
    private readonly List<Persona> personas = new List<Persona>();

    public FrmMetodosSobrescritos()
    {
        InitializeComponent();
        TituloActividad = "Unidad 4 · Lab 4.2 — Polimorfismo y métodos sobrescritos";
        ConceptosActividad = "Persona.MostrarRol() es virtual; Estudiante y Profesor lo sobrescriben con override. La variable es de tipo Persona.";
        txtPreguntas.Text = string.Join(Environment.NewLine + Environment.NewLine, new[]
        {
            "1. virtual: indica que el método tiene una implementación que las clases derivadas PUEDEN reemplazar.",
            "2. override: reemplaza en la clase derivada el método virtual heredado.",
            "3. Estudiante y Profesor pueden usar MostrarRol() porque lo heredan de Persona.",
            "4. La variable persona es de tipo Persona (la clase base).",
            "5. El polimorfismo está en «persona.MostrarRol()»: la misma llamada sobre una variable Persona.",
            "6. Se ejecuta un método distinto porque C# decide en tiempo de ejecución según el tipo REAL del objeto (enlace dinámico), no según el tipo de la variable."
        });
    }

    private void btnAsignar_Click(object? sender, EventArgs e)
    {
        try
        {
            // Variable polimórfica: una sola variable de tipo Persona para los tres tipos de objeto.
            Persona persona;

            if (rbEstudiante.Checked)
                persona = new EstudianteRol(txtNombre.Text, (int)nudEdad.Value);
            else if (rbProfesor.Checked)
                persona = new ProfesorRol(txtNombre.Text, (int)nudEdad.Value);
            else
                persona = new Persona(txtNombre.Text, (int)nudEdad.Value);

            personas.Add(persona);
            Escribir($"Persona persona = new {persona.GetType().Name}(\"{persona.Nombre}\", {persona.Edad});");
            Escribir($"persona.MostrarRol()  →  \"{persona.MostrarRol()}\"");
            Escribir("");

            RefrescarTabla();
            txtNombre.Clear();
            txtNombre.Focus();
        }
        catch (ArgumentException ex)
        {
            Mensajes.Advertencia(ex.Message);
        }
    }

    private void btnRecorrer_Click(object? sender, EventArgs e)
    {
        if (personas.Count == 0)
        {
            Mensajes.Advertencia("Primero cree algunas personas.");
            return;
        }

        Escribir("foreach (Persona p in personas) p.MostrarRol();");
        foreach (Persona p in personas)
            Escribir($"   [{p.GetType().Name,-13}] {p.Nombre,-20} → {p.MostrarRol()}");
        Escribir("");
    }

    private void btnLimpiar_Click(object? sender, EventArgs e)
    {
        personas.Clear();
        txtSalida.Clear();
        RefrescarTabla();
    }

    private void RefrescarTabla()
    {
        dgvPersonas.DataSource = personas
            .Select(p => new
            {
                Nombre = p.Nombre,
                Edad = p.Edad,
                TipoVariable = nameof(Persona),
                TipoReal = p.GetType().Name,
                MostrarRol = p.MostrarRol()
            })
            .ToList();
    }

    private void Escribir(string linea) => txtSalida.AppendText(linea + Environment.NewLine);
}
