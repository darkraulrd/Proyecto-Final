using System.Globalization;
using ProyectoIntegradorPOO.Exceptions;
using ProyectoIntegradorPOO.Interfaces;
using ProyectoIntegradorPOO.Models.Unidad6;

namespace ProyectoIntegradorPOO.Services;

/// <summary>
/// UNIDAD 6 — Lógica de negocio del registro de estudiantes.
/// Convierte y valida lo que escribe el usuario (lanzando ValidacionException)
/// y delega el almacenamiento en un IRepositorio. No sabe nada de archivos ni de formularios.
/// </summary>
public class ServicioEstudiantes
{
    public const decimal IndiceMaximo = 4.0m;
    private readonly IRepositorio<EstudianteRegistro> repositorio;

    public ServicioEstudiantes(IRepositorio<EstudianteRegistro> repositorio)
    {
        this.repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
    }

    public string Ubicacion => repositorio.Ubicacion;

    public bool ExisteArchivo() => repositorio.ExisteAlmacen();

    public Task<List<EstudianteRegistro>> ListarAsync() => repositorio.ObtenerTodosAsync();

    public async Task<EstudianteRegistro> RegistrarAsync(string matricula, string nombre, string carrera, string edad, string indice)
    {
        EstudianteRegistro estudiante = Construir(matricula, nombre, carrera, edad, indice);
        await repositorio.AgregarAsync(estudiante);
        return estudiante;
    }

    public async Task<EstudianteRegistro> ActualizarAsync(string matricula, string nombre, string carrera, string edad, string indice)
    {
        EstudianteRegistro nuevo = Construir(matricula, nombre, carrera, edad, indice);
        EstudianteRegistro? existente = await repositorio.ObtenerPorIdAsync(nuevo.Matricula)
            ?? throw new ValidacionException("Matricula", $"No existe un estudiante con la matrícula {nuevo.Matricula}.");

        nuevo.FechaRegistro = existente.FechaRegistro; // la fecha original no cambia
        await repositorio.ActualizarAsync(nuevo);
        return nuevo;
    }

    public async Task EliminarAsync(string matricula)
    {
        if (string.IsNullOrWhiteSpace(matricula))
            throw new ValidacionException("Matricula", "Seleccione el estudiante que desea eliminar.");

        if (!await repositorio.EliminarAsync(matricula))
            throw new ValidacionException("Matricula", $"No existe un estudiante con la matrícula {matricula.Trim()}.");
    }

    /// <summary>Valida y convierte los textos del formulario. Lanza ValidacionException con el campo afectado.</summary>
    public static EstudianteRegistro Construir(string matricula, string nombre, string carrera, string edad, string indice)
    {
        matricula = (matricula ?? "").Trim();
        if (matricula.Length == 0)
            throw new ValidacionException("Matricula", "La matrícula es obligatoria.");
        if (!matricula.All(char.IsDigit) || matricula.Length < 6 || matricula.Length > 12)
            throw new ValidacionException("Matricula", "La matrícula debe contener solo dígitos (entre 6 y 12).");

        if (string.IsNullOrWhiteSpace(nombre))
            throw new ValidacionException("Nombre", "El nombre es obligatorio.");
        if (string.IsNullOrWhiteSpace(carrera))
            throw new ValidacionException("Carrera", "La carrera es obligatoria.");

        int edadNumero;
        try
        {
            edadNumero = int.Parse((edad ?? "").Trim(), CultureInfo.CurrentCulture);
        }
        catch (FormatException ex)
        {
            // Se traduce la excepción técnica en una de negocio, conservando la causa.
            throw new ValidacionException("Edad", "La edad debe ser un número entero.", ex);
        }
        catch (OverflowException ex)
        {
            throw new ValidacionException("Edad", "La edad indicada es demasiado grande.", ex);
        }

        if (edadNumero < 15 || edadNumero > 100)
            throw new ValidacionException("Edad", "La edad debe estar entre 15 y 100 años.");

        if (!decimal.TryParse((indice ?? "").Trim().Replace(',', '.'), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal indiceNumero))
            throw new ValidacionException("Indice", "El índice académico debe ser un número (ejemplo: 3.25).");
        if (indiceNumero < 0 || indiceNumero > IndiceMaximo)
            throw new ValidacionException("Indice", $"El índice académico debe estar entre 0 y {IndiceMaximo:0.0}.");

        return new EstudianteRegistro
        {
            Matricula = matricula,
            Nombre = nombre.Trim(),
            Carrera = carrera.Trim(),
            Edad = edadNumero,
            Indice = Math.Round(indiceNumero, 2)
        };
    }
}
