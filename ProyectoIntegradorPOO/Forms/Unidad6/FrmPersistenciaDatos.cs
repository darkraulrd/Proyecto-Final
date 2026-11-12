using System.Diagnostics;
using ProyectoIntegradorPOO.Exceptions;
using ProyectoIntegradorPOO.Forms.Comun;
using ProyectoIntegradorPOO.Models.Unidad6;
using ProyectoIntegradorPOO.Repositories;
using ProyectoIntegradorPOO.Services;

namespace ProyectoIntegradorPOO.Forms.Unidad6;

/// <summary>
/// UNIDAD 6 — Persistencia en JSON. Capas:
///   Formulario  →  ServicioEstudiantes (validación)  →  IRepositorio  →  RepositorioJson (archivo)
/// El formulario no lee ni escribe archivos: solo llama al servicio y muestra resultados.
/// </summary>
public partial class FrmPersistenciaDatos : FrmActividadBase
{
    public const string NombreArchivo = "estudiantes.json";

    private readonly ServicioEstudiantes servicio;
    private List<EstudianteRegistro> estudiantes = new List<EstudianteRegistro>();

    public FrmPersistenciaDatos()
    {
        InitializeComponent();
        TituloActividad = "Unidad 6 · Persistencia de datos en JSON";
        ConceptosActividad = "System.Text.Json · IRepositorio<T> y RepositorioJson<T> · servicio de negocio · CRUD asíncrono (async/await) · manejo de errores de E/S";

        string ruta = Path.Combine(InformacionAplicacion.CarpetaDatos, NombreArchivo);
        servicio = new ServicioEstudiantes(new RepositorioJson<EstudianteRegistro>(ruta));

        cmbCarrera.Items.AddRange(new object[]
        {
            "Licenciatura en Informática", "Ingeniería de Software", "Ingeniería en Sistemas",
            "Ingeniería Electrónica", "Matemática", "Contabilidad", "Administración de Empresas"
        });
    }

    private async void FrmPersistenciaDatos_Load(object? sender, EventArgs e) => await CargarAsync();

    // ---------------- Operaciones CRUD ----------------

    private async void btnGuardar_Click(object? sender, EventArgs e) =>
        await EjecutarAsync("Guardar", async () =>
        {
            EstudianteRegistro nuevo = await servicio.RegistrarAsync(txtMatricula.Text, txtNombre.Text, cmbCarrera.Text, txtEdad.Text, txtIndice.Text);
            await CargarAsync(nuevo.Matricula);
            LimpiarCampos();
            return $"Estudiante {nuevo.Nombre} guardado en el archivo JSON.";
        });

    private async void btnActualizar_Click(object? sender, EventArgs e) =>
        await EjecutarAsync("Actualizar", async () =>
        {
            EstudianteRegistro actualizado = await servicio.ActualizarAsync(txtMatricula.Text, txtNombre.Text, cmbCarrera.Text, txtEdad.Text, txtIndice.Text);
            await CargarAsync(actualizado.Matricula);
            return $"Datos de {actualizado.Nombre} actualizados.";
        });

    private async void btnEliminar_Click(object? sender, EventArgs e)
    {
        string matricula = txtMatricula.Text.Trim();
        if (matricula.Length > 0 && !Mensajes.Confirmar($"¿Eliminar del archivo al estudiante con matrícula {matricula}?"))
            return;

        await EjecutarAsync("Eliminar", async () =>
        {
            await servicio.EliminarAsync(matricula);
            await CargarAsync();
            LimpiarCampos();
            return $"Estudiante {matricula} eliminado del archivo.";
        });
    }

    private async void btnRecargar_Click(object? sender, EventArgs e) => await CargarAsync();

    private void btnLimpiar_Click(object? sender, EventArgs e) => LimpiarCampos();

    private void btnAbrirCarpeta_Click(object? sender, EventArgs e)
    {
        try
        {
            Directory.CreateDirectory(InformacionAplicacion.CarpetaDatos);
            Process.Start(new ProcessStartInfo("explorer.exe", $"\"{InformacionAplicacion.CarpetaDatos}\"") { UseShellExecute = true });
        }
        catch (Exception ex)
        {
            Mensajes.Error($"No se pudo abrir la carpeta de datos.\n\n{ex.Message}");
        }
    }

    // ---------------- Infraestructura ----------------

    /// <summary>
    /// Ejecuta una operación del servicio y traduce cada tipo de excepción a un mensaje claro.
    /// Los botones se deshabilitan mientras dura la operación y se habilitan en el finally.
    /// </summary>
    private async Task EjecutarAsync(string operacion, Func<Task<string>> accion)
    {
        errorProvider.Clear();
        HabilitarBotones(false);
        try
        {
            string mensaje = await accion();
            lblEstado.ForeColor = Tema.Exito;
            lblEstado.Text = "✔ " + mensaje;
        }
        catch (ValidacionException ex)
        {
            MarcarCampo(ex.Campo, ex.Message);
            Mensajes.Advertencia(ex.Message, $"{operacion}: dato no válido");
        }
        catch (RegistroDuplicadoException ex)
        {
            errorProvider.SetError(txtMatricula, ex.Message);
            Mensajes.Advertencia($"{ex.Message}\nUse «Actualizar» para modificar sus datos.", $"{operacion}: matrícula repetida");
        }
        catch (PersistenciaException ex)
        {
            lblEstado.ForeColor = Tema.Peligro;
            lblEstado.Text = "✖ Error de archivo: " + ex.InnerException?.GetType().Name;
            Mensajes.Error($"{ex.Message}\n\nDetalle técnico: {ex.InnerException?.Message}", $"{operacion}: error de persistencia");
        }
        catch (Exception ex)
        {
            lblEstado.ForeColor = Tema.Peligro;
            lblEstado.Text = "✖ Error inesperado";
            Mensajes.Error(ex.Message, $"{operacion}: error inesperado");
        }
        finally
        {
            HabilitarBotones(true);
            ActualizarInfoArchivo();
        }
    }

    private async Task CargarAsync(string? seleccionar = null)
    {
        try
        {
            estudiantes = await servicio.ListarAsync();
            MostrarEstudiantes(seleccionar);
        }
        catch (PersistenciaException ex)
        {
            estudiantes = new List<EstudianteRegistro>();
            MostrarEstudiantes();
            Mensajes.Error($"{ex.Message}\n\nDetalle técnico: {ex.InnerException?.Message}", "Error al leer los datos");
        }
        finally
        {
            ActualizarInfoArchivo();
        }
    }

    private void MostrarEstudiantes(string? seleccionar = null)
    {
        string filtro = txtBuscar.Text.Trim();
        List<EstudianteRegistro> visibles = estudiantes
            .Where(e => filtro.Length == 0 ||
                        e.Matricula.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                        e.Nombre.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                        e.Carrera.Contains(filtro, StringComparison.OrdinalIgnoreCase))
            .OrderBy(e => e.Nombre)
            .ToList();

        dgvEstudiantes.DataSource = visibles
            .Select(e => new
            {
                Matrícula = e.Matricula,
                Nombre = e.Nombre,
                Carrera = e.Carrera,
                Edad = e.Edad,
                Índice = e.Indice.ToString("0.00"),
                Registro = e.FechaRegistro.ToString("dd/MM/yyyy HH:mm")
            })
            .ToList();

        lblConteo.Text = $"Mostrando {visibles.Count} de {estudiantes.Count} estudiante(s) guardado(s).";

        if (seleccionar is null) return;
        foreach (DataGridViewRow fila in dgvEstudiantes.Rows)
        {
            if (string.Equals(fila.Cells[0].Value as string, seleccionar, StringComparison.OrdinalIgnoreCase))
            {
                fila.Selected = true;
                dgvEstudiantes.CurrentCell = fila.Cells[0];
                break;
            }
        }
    }

    private void dgvEstudiantes_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        string? matricula = dgvEstudiantes.Rows[e.RowIndex].Cells[0].Value as string;
        EstudianteRegistro? estudiante = estudiantes.FirstOrDefault(x => x.Matricula == matricula);
        if (estudiante is null) return;

        txtMatricula.Text = estudiante.Matricula;
        txtNombre.Text = estudiante.Nombre;
        cmbCarrera.Text = estudiante.Carrera;
        txtEdad.Text = estudiante.Edad.ToString();
        txtIndice.Text = estudiante.Indice.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
        errorProvider.Clear();
    }

    private void txtBuscar_TextChanged(object? sender, EventArgs e) => MostrarEstudiantes();

    private void ActualizarInfoArchivo()
    {
        bool existe = servicio.ExisteArchivo();
        lblRuta.Text = servicio.Ubicacion;
        lblExiste.Text = existe ? "✔ El archivo existe" : "○ El archivo todavía no existe (se crea al guardar)";
        lblExiste.ForeColor = existe ? Tema.Exito : Tema.TextoSecundario;
    }

    private void MarcarCampo(string campo, string mensaje)
    {
        Control? control = campo switch
        {
            "Matricula" => txtMatricula,
            "Nombre" => txtNombre,
            "Carrera" => cmbCarrera,
            "Edad" => txtEdad,
            "Indice" => txtIndice,
            _ => null
        };

        if (control is null) return;
        errorProvider.SetError(control, mensaje);
        control.Focus();
    }

    private void HabilitarBotones(bool habilitar)
    {
        btnGuardar.Enabled = btnActualizar.Enabled = btnEliminar.Enabled = btnRecargar.Enabled = habilitar;
        UseWaitCursor = !habilitar;
    }

    private void LimpiarCampos()
    {
        txtMatricula.Clear();
        txtNombre.Clear();
        cmbCarrera.Text = "";
        txtEdad.Clear();
        txtIndice.Clear();
        errorProvider.Clear();
        txtMatricula.Focus();
    }
}
