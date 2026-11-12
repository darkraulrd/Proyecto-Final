using System.Drawing.Drawing2D;
using ProyectoIntegradorPOO.Forms.Comun;
using ProyectoIntegradorPOO.Models.Unidad5;

namespace ProyectoIntegradorPOO.Forms.Unidad5;

/// <summary>UNIDAD 5 — Sobrecarga de operadores con la clase Vector2D.</summary>
public partial class FrmSobrecargaOperadores : FrmActividadBase
{
    private static readonly Color ColorA = Color.FromArgb(46, 134, 193);
    private static readonly Color ColorB = Color.FromArgb(30, 132, 73);
    private static readonly Color ColorResultado = Color.FromArgb(211, 84, 0);

    private Vector2D? resultado;
    private string operacionResultado = "";

    public FrmSobrecargaOperadores()
    {
        InitializeComponent();
        TituloActividad = "Unidad 5 · Sobrecarga de operadores — Vector2D";
        ConceptosActividad = "operator +, operator -, operator ==, operator != · Equals() y GetHashCode() coherentes con la igualdad por valor.";
    }

    private Vector2D VectorA => new Vector2D((double)nudAx.Value, (double)nudAy.Value);
    private Vector2D VectorB => new Vector2D((double)nudBx.Value, (double)nudBy.Value);

    private void btnSumar_Click(object? sender, EventArgs e)
    {
        Vector2D a = VectorA, b = VectorB;
        MostrarResultado(a + b, "A + B");
        Escribir($"A + B  =  {a} + {b}  =  {resultado}   (X: {a.X} + {b.X},  Y: {a.Y} + {b.Y})");
    }

    private void btnRestar_Click(object? sender, EventArgs e)
    {
        Vector2D a = VectorA, b = VectorB;
        MostrarResultado(a - b, "A − B");
        Escribir($"A − B  =  {a} − {b}  =  {resultado}   (X: {a.X} − {b.X},  Y: {a.Y} − {b.Y})");
    }

    private void btnIgual_Click(object? sender, EventArgs e)
    {
        Vector2D a = VectorA, b = VectorB;
        Escribir($"A == B  →  {a} == {b}  →  {a == b}");
        Escribir($"   (ReferenceEquals(A, B) = {ReferenceEquals(a, b)}: son objetos distintos, pero == compara valores)");
    }

    private void btnDistinto_Click(object? sender, EventArgs e)
    {
        Vector2D a = VectorA, b = VectorB;
        Escribir($"A != B  →  {a} != {b}  →  {a != b}");
    }

    private void btnEquals_Click(object? sender, EventArgs e)
    {
        Vector2D a = VectorA, b = VectorB;
        HashSet<Vector2D> conjunto = new HashSet<Vector2D> { a, b };

        Escribir($"A.Equals(B) = {a.Equals(b)}   ·   A.GetHashCode() = {a.GetHashCode()}   ·   B.GetHashCode() = {b.GetHashCode()}");
        Escribir($"   HashSet<Vector2D> {{ A, B }} contiene {conjunto.Count} elemento(s) " +
                 (conjunto.Count == 1 ? "→ los reconoce como el MISMO vector." : "→ son vectores diferentes."));
    }

    private void btnLimpiar_Click(object? sender, EventArgs e)
    {
        resultado = null;
        operacionResultado = "";
        txtResultados.Clear();
        picPlano.Invalidate();
    }

    private void nudVector_ValueChanged(object? sender, EventArgs e)
    {
        resultado = null;
        operacionResultado = "";
        picPlano.Invalidate();
    }

    private void MostrarResultado(Vector2D vector, string operacion)
    {
        resultado = vector;
        operacionResultado = operacion;
        lblResultado.Text = $"{operacion} = {vector}    ·    |{operacion}| = {vector.Magnitud:N2}";
        picPlano.Invalidate();
    }

    private void Escribir(string linea) => txtResultados.AppendText(linea + Environment.NewLine);

    // ---------------- Dibujo del plano cartesiano ----------------

    private void picPlano_Paint(object? sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        Vector2D a = VectorA, b = VectorB;
        List<Vector2D> visibles = new List<Vector2D> { a, b };
        if (resultado is not null) visibles.Add(resultado);

        // Escala automática para que todos los vectores quepan en el plano.
        double maximo = Math.Max(1, visibles.Max(v => Math.Max(Math.Abs(v.X), Math.Abs(v.Y))));
        float escala = (float)((Math.Min(picPlano.Width, picPlano.Height) / 2.0 - 30) / maximo);
        PointF origen = new PointF(picPlano.Width / 2f, picPlano.Height / 2f);

        using Pen ejes = new Pen(Color.FromArgb(200, 200, 200), 1);
        g.DrawLine(ejes, 0, origen.Y, picPlano.Width, origen.Y);
        g.DrawLine(ejes, origen.X, 0, origen.X, picPlano.Height);
        TextRenderer.DrawText(g, "X", Tema.Fuente, new Point(picPlano.Width - 18, (int)origen.Y + 2), Tema.TextoSecundario);
        TextRenderer.DrawText(g, "Y", Tema.Fuente, new Point((int)origen.X + 4, 2), Tema.TextoSecundario);

        DibujarVector(g, origen, escala, a, ColorA, "A");
        DibujarVector(g, origen, escala, b, ColorB, "B");
        if (resultado is not null)
            DibujarVector(g, origen, escala, resultado, ColorResultado, operacionResultado);
    }

    private static void DibujarVector(Graphics g, PointF origen, float escala, Vector2D vector, Color color, string etiqueta)
    {
        PointF destino = new PointF(origen.X + (float)vector.X * escala, origen.Y - (float)vector.Y * escala);
        using Pen lapiz = new Pen(color, 3) { CustomEndCap = new AdjustableArrowCap(5, 5) };
        g.DrawLine(lapiz, origen, destino);
        TextRenderer.DrawText(g, $"{etiqueta} {vector}", Tema.FuenteNegrita, Point.Round(new PointF(destino.X + 6, destino.Y - 18)), color);
    }

    private void picPlano_Resize(object? sender, EventArgs e) => picPlano.Invalidate();
}
