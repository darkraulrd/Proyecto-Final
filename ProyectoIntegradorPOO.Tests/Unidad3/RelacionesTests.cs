using ProyectoIntegradorPOO.Models.Unidad3;

namespace ProyectoIntegradorPOO.Tests.Unidad3;

public class RelacionesTests
{
    [Fact]
    public void Departamento_CreaYPoseeSusCursos_Composicion()
    {
        Departamento departamento = new Departamento("Informática");
        Curso curso = departamento.CrearCurso("inf-5130", "Programación I", 4);

        Assert.Same(departamento, curso.Departamento);
        Assert.Equal("INF-5130", curso.Codigo);
        Assert.Contains(curso, departamento.Cursos);

        departamento.Cerrar();
        Assert.Empty(departamento.Cursos);
    }

    [Fact]
    public void Departamento_NoPermiteCodigosDuplicados()
    {
        Departamento departamento = new Departamento("Informática");
        departamento.CrearCurso("INF-1", "Uno", 3);
        Assert.Throws<InvalidOperationException>(() => departamento.CrearCurso("inf-1", "Otro", 3));
    }

    [Fact]
    public void EliminarCurso_NoEliminaEstudiantes_Agregacion()
    {
        RegistroAcademico registro = new RegistroAcademico("Informática");
        Estudiante ana = registro.RegistrarEstudiante("Ana", "100", 20);
        Curso curso = registro.Departamento.CrearCurso("INF-1", "Programación", 4);
        curso.InscribirEstudiante(ana);

        registro.Departamento.EliminarCurso(curso);

        Assert.Empty(registro.Departamento.Cursos);
        Assert.Contains(ana, registro.Estudiantes);
    }

    [Fact]
    public void Curso_NoPermiteInscribirDosVecesAlMismoEstudiante()
    {
        RegistroAcademico registro = new RegistroAcademico("Informática");
        Estudiante ana = registro.RegistrarEstudiante("Ana", "100", 20);
        Curso curso = registro.Departamento.CrearCurso("INF-1", "Programación", 4);

        curso.InscribirEstudiante(ana);
        Assert.Throws<InvalidOperationException>(() => curso.InscribirEstudiante(ana));
    }

    [Fact]
    public void Curso_AsociaUnProfesorExistente_Asociacion()
    {
        RegistroAcademico registro = new RegistroAcademico("Informática");
        Profesor profesor = registro.RegistrarProfesor("Carlos Díaz", "Programación");
        Curso c1 = registro.Departamento.CrearCurso("INF-1", "Programación I", 4);
        Curso c2 = registro.Departamento.CrearCurso("INF-2", "Programación II", 4);

        c1.AsignarProfesor(profesor);
        c2.AsignarProfesor(profesor);

        Assert.Same(c1.Profesor, c2.Profesor);
    }

    [Fact]
    public void Registro_CursosDe_DevuelveLosCursosDelEstudiante()
    {
        RegistroAcademico registro = new RegistroAcademico("Informática");
        Estudiante ana = registro.RegistrarEstudiante("Ana", "100", 20);
        Curso c1 = registro.Departamento.CrearCurso("INF-1", "Uno", 4);
        registro.Departamento.CrearCurso("INF-2", "Dos", 4);
        c1.InscribirEstudiante(ana);

        Assert.Equal(new[] { c1 }, registro.CursosDe(ana));
    }

    [Fact]
    public void Pedido_CalculaTotalDeSusDetalles_Composicion()
    {
        Pedido pedido = new Pedido("Cliente");
        pedido.AgregarDetalle("Pizza", 2, 600m);
        pedido.AgregarDetalle("Refresco", 3, 80m);

        Assert.Equal(1440m, pedido.CalcularTotal());

        pedido.QuitarDetalle(0);
        Assert.Equal(240m, pedido.CalcularTotal());
    }

    [Theory]
    [InlineData("", 1, 10)]
    [InlineData("Pizza", 0, 10)]
    [InlineData("Pizza", 1, 0)]
    public void Pedido_ValidaLosDetalles(string producto, int cantidad, decimal precio)
    {
        Pedido pedido = new Pedido("Cliente");
        Assert.Throws<ArgumentException>(() => pedido.AgregarDetalle(producto, cantidad, precio));
        Assert.Empty(pedido.Detalles);
    }
}
