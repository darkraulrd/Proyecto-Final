using System.Text.Json.Serialization;
using ProyectoIntegradorPOO.Interfaces;

namespace ProyectoIntegradorPOO.Models.Unidad6;

/// <summary>
/// Registro de estudiante que se guarda en JSON. Es un objeto de datos sencillo:
/// las reglas de validación viven en ServicioEstudiantes.
/// </summary>
public class EstudianteRegistro : IEntidad
{
    public string Matricula { get; set; } = "";
    public string Nombre { get; set; } = "";
    public string Carrera { get; set; } = "";
    public int Edad { get; set; }
    public decimal Indice { get; set; }
    public DateTime FechaRegistro { get; set; } = DateTime.Now;

    // El identificador del repositorio es la matrícula; no se repite en el JSON.
    [JsonIgnore]
    public string Id => Matricula;
}
