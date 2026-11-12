using ProyectoIntegradorPOO.Forms.Comun;
using ProyectoIntegradorPOO.Models.Unidad3;

namespace ProyectoIntegradorPOO.Forms.Unidad3;

/// <summary>
/// UNIDAD 3 — Relaciones entre clases (sistema de estudiantes y cursos).
///  Departamento ◆— Curso       (composición: el departamento crea y posee sus cursos)
///  Curso ◇— Estudiante 1..*    (agregación: los estudiantes existen sin el curso)
///  Curso —— Profesor           (asociación: el curso conoce a su profesor)
/// </summary>
public partial class FrmRelacionesClases : FrmActividadBase
{
    private readonly RegistroAcademico registro = new RegistroAcademico("Departamento de Informática");

    public FrmRelacionesClases()
    {
        InitializeComponent();
        TituloActividad = "Unidad 3 · Relaciones entre clases y contenedores";
        ConceptosActividad = "Asociación (Curso → Profesor) · Agregación (Curso ◇ Estudiante) · Composición (Departamento ◆ Curso) · List<T>";
    }

    private void FrmRelacionesClases_Load(object? sender, EventArgs e)
    {
        RefrescarTodo();
    }

    // ---------------- Registro de objetos ----------------

    private void btnRegistrarEstudiante_Click(object? sender, EventArgs e)
    {
        Ejecutar(() =>
        {
            Estudiante estudiante = registro.RegistrarEstudiante(txtNombreEstudiante.Text, txtMatricula.Text, (int)nudEdad.Value);
            txtNombreEstudiante.Clear();
            txtMatricula.Clear();
            txtNombreEstudiante.Focus();
            RefrescarTodo();
            SeleccionarEn(cmbEstudiante, estudiante);
        });
    }

    private void btnRegistrarProfesor_Click(object? sender, EventArgs e)
    {
        Ejecutar(() =>
        {
            Profesor profesor = registro.RegistrarProfesor(txtNombreProfesor.Text, txtEspecialidad.Text);
            txtNombreProfesor.Clear();
            txtEspecialidad.Clear();
            RefrescarTodo();
            SeleccionarEn(cmbProfesor, profesor);
        });
    }

    private void btnCrearCurso_Click(object? sender, EventArgs e)
    {
        Ejecutar(() =>
        {
            // Composición: el curso solo puede nacer a través de su departamento.
            Curso curso = registro.Departamento.CrearCurso(txtCodigoCurso.Text, txtNombreCurso.Text, (int)nudCreditos.Value);

            // Asociación: se enlaza con un profesor que ya existía.
            if (cmbProfesor.SelectedItem is Profesor profesor)
                curso.AsignarProfesor(profesor);

            txtCodigoCurso.Clear();
            txtNombreCurso.Clear();
            RefrescarTodo();
            SeleccionarEn(cmbCurso, curso);
        });
    }

    // ---------------- Inscripción (agregación) ----------------

    private void btnInscribir_Click(object? sender, EventArgs e)
    {
        if (!ObtenerSeleccion(out Curso? curso, out Estudiante? estudiante)) return;

        Ejecutar(() =>
        {
            curso!.InscribirEstudiante(estudiante!);
            RefrescarTodo();
            tabRelaciones.SelectedTab = tabInscritos;
        });
    }

    private void btnRetirar_Click(object? sender, EventArgs e)
    {
        if (!ObtenerSeleccion(out Curso? curso, out Estudiante? estudiante)) return;

        if (!curso!.RetirarEstudiante(estudiante!))
        {
            Mensajes.Advertencia($"{estudiante!.Nombre} no está inscrito en {curso.Codigo}.");
            return;
        }
        RefrescarTodo();
    }

    private void btnEliminarCurso_Click(object? sender, EventArgs e)
    {
        if (cmbCurso.SelectedItem is not Curso curso)
        {
            Mensajes.Advertencia("Seleccione el curso que desea eliminar.");
            return;
        }

        if (!Mensajes.Confirmar($"¿Eliminar el curso {curso}?\n\nComposición: el curso desaparece del departamento.\nAgregación: sus {curso.Estudiantes.Count} estudiante(s) siguen registrados."))
            return;

        registro.Departamento.EliminarCurso(curso);
        RefrescarTodo();
        Mensajes.Informacion($"Curso eliminado. Siguen registrados {registro.Estudiantes.Count} estudiante(s).", "Composición vs. agregación");
    }

    private void cmbCurso_SelectedIndexChanged(object? sender, EventArgs e) => RefrescarInscritos();

    // ---------------- Presentación ----------------

    private void RefrescarTodo()
    {
        object? cursoSeleccionado = cmbCurso.SelectedItem;
        object? estudianteSeleccionado = cmbEstudiante.SelectedItem;
        object? profesorSeleccionado = cmbProfesor.SelectedItem;

        CargarCombo(cmbProfesor, registro.Profesores, profesorSeleccionado);
        CargarCombo(cmbCurso, registro.Departamento.Cursos, cursoSeleccionado);
        CargarCombo(cmbEstudiante, registro.Estudiantes, estudianteSeleccionado);

        dgvEstudiantes.DataSource = registro.Estudiantes
            .Select(e => new
            {
                Matrícula = e.Matricula,
                Nombre = e.Nombre,
                Edad = e.Edad,
                Cursos = string.Join(", ", registro.CursosDe(e).Select(c => c.Codigo))
            })
            .ToList();

        dgvCursos.DataSource = registro.Departamento.Cursos
            .Select(c => new
            {
                Código = c.Codigo,
                Curso = c.Nombre,
                Créditos = c.Creditos,
                Profesor = c.Profesor?.Nombre ?? "(sin asignar)",
                Inscritos = c.Estudiantes.Count,
                Departamento = c.Departamento.Nombre
            })
            .ToList();

        RefrescarInscritos();
        ConstruirMapaDeObjetos();
        lblResumen.Text = $"Estudiantes: {registro.Estudiantes.Count}   ·   Profesores: {registro.Profesores.Count}   ·   Cursos: {registro.Departamento.Cursos.Count}";
    }

    private void RefrescarInscritos()
    {
        if (cmbCurso.SelectedItem is Curso curso)
        {
            tabInscritos.Text = $"Inscritos en {curso.Codigo} (agregación)";
            dgvInscritos.DataSource = curso.Estudiantes
                .Select(e => new { Matrícula = e.Matricula, Nombre = e.Nombre, Edad = e.Edad })
                .ToList();
        }
        else
        {
            tabInscritos.Text = "Inscritos por curso (agregación)";
            dgvInscritos.DataSource = null;
        }
    }

    private void ConstruirMapaDeObjetos()
    {
        tvRelaciones.BeginUpdate();
        tvRelaciones.Nodes.Clear();

        TreeNode raiz = tvRelaciones.Nodes.Add($"🏛 {registro.Departamento.Nombre}  [Departamento]");
        foreach (Curso curso in registro.Departamento.Cursos)
        {
            TreeNode nodoCurso = raiz.Nodes.Add($"◆ {curso}  ({curso.Creditos} créditos)  — composición");
            nodoCurso.Nodes.Add($"— Profesor: {curso.Profesor?.ToString() ?? "(sin asignar)"}  — asociación");

            TreeNode nodoEstudiantes = nodoCurso.Nodes.Add($"◇ Estudiantes inscritos: {curso.Estudiantes.Count}  — agregación");
            foreach (Estudiante estudiante in curso.Estudiantes)
                nodoEstudiantes.Nodes.Add($"{estudiante.Matricula} · {estudiante.Nombre}");
        }

        TreeNode independientes = tvRelaciones.Nodes.Add($"List<Estudiante> registrados (existen por sí mismos): {registro.Estudiantes.Count}");
        foreach (Estudiante estudiante in registro.Estudiantes)
            independientes.Nodes.Add($"{estudiante.Matricula} · {estudiante.Nombre} · {estudiante.Edad} años");

        TreeNode profesores = tvRelaciones.Nodes.Add($"List<Profesor> registrados: {registro.Profesores.Count}");
        foreach (Profesor profesor in registro.Profesores)
            profesores.Nodes.Add(profesor.ToString());

        tvRelaciones.ExpandAll();
        tvRelaciones.EndUpdate();
    }

    private static void CargarCombo<T>(ComboBox combo, IReadOnlyList<T> elementos, object? seleccionPrevia)
    {
        combo.BeginUpdate();
        combo.Items.Clear();
        foreach (T elemento in elementos)
            combo.Items.Add(elemento!);

        if (seleccionPrevia is not null && combo.Items.Contains(seleccionPrevia))
            combo.SelectedItem = seleccionPrevia;
        else if (combo.Items.Count > 0)
            combo.SelectedIndex = 0;
        combo.EndUpdate();
    }

    private static void SeleccionarEn(ComboBox combo, object elemento)
    {
        if (combo.Items.Contains(elemento))
            combo.SelectedItem = elemento;
    }

    private bool ObtenerSeleccion(out Curso? curso, out Estudiante? estudiante)
    {
        curso = cmbCurso.SelectedItem as Curso;
        estudiante = cmbEstudiante.SelectedItem as Estudiante;

        if (curso is null || estudiante is null)
        {
            Mensajes.Advertencia("Debe tener al menos un curso y un estudiante registrados y seleccionados.");
            return false;
        }
        return true;
    }

    /// <summary>Ejecuta una acción mostrando al usuario los errores de validación del modelo.</summary>
    private static void Ejecutar(Action accion)
    {
        try
        {
            accion();
        }
        catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
        {
            Mensajes.Advertencia(ex.Message);
        }
    }
}
