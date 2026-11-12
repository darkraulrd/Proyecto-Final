using System.Drawing;

namespace ProyectoIntegradorPOO.Models.Unidad4;

/// <summary>
/// Laboratorio 4.3 — CLASES ABSTRACTAS.
/// Figura es abstract: no se puede hacer "new Figura(...)" porque una figura genérica
/// no sabe calcular su área. Obliga a las derivadas a implementar CalcularArea() y Dibujar().
/// </summary>
public abstract class Figura
{
    protected Figura(string nombre)
    {
        Nombre = nombre;
    }

    public string Nombre { get; }

    public abstract double CalcularArea();

    /// <summary>Dibuja la figura centrada dentro del área indicada (versión gráfica del lab de consola).</summary>
    public abstract void Dibujar(Graphics graficos, Rectangle area);

    public override string ToString() => $"{Nombre} — Área: {CalcularArea():N2}";
}

public class Rectangulo : Figura
{
    public Rectangulo(double ladoBase, double altura) : base("Rectángulo")
    {
        if (ladoBase <= 0 || altura <= 0)
            throw new ArgumentException("La base y la altura deben ser mayores que cero.");
        Base = ladoBase;
        Altura = altura;
    }

    public double Base { get; }
    public double Altura { get; }

    public override double CalcularArea() => Base * Altura;

    public override void Dibujar(Graphics graficos, Rectangle area)
    {
        // Escala proporcional para que el rectángulo quepa en el área de dibujo.
        double escala = Math.Min((area.Width - 20) / Base, (area.Height - 20) / Altura);
        int ancho = (int)(Base * escala);
        int alto = (int)(Altura * escala);
        Rectangle figura = new Rectangle(area.X + (area.Width - ancho) / 2, area.Y + (area.Height - alto) / 2, ancho, alto);

        using SolidBrush relleno = new SolidBrush(Color.FromArgb(120, 46, 134, 193));
        using Pen borde = new Pen(Color.FromArgb(31, 78, 121), 2);
        graficos.FillRectangle(relleno, figura);
        graficos.DrawRectangle(borde, figura);
    }
}

public class Circulo : Figura
{
    public Circulo(double radio) : base("Círculo")
    {
        if (radio <= 0)
            throw new ArgumentException("El radio debe ser mayor que cero.");
        Radio = radio;
    }

    public double Radio { get; }

    public override double CalcularArea() => Math.PI * Math.Pow(Radio, 2);

    public override void Dibujar(Graphics graficos, Rectangle area)
    {
        int diametro = Math.Min(area.Width, area.Height) - 20;
        Rectangle figura = new Rectangle(area.X + (area.Width - diametro) / 2, area.Y + (area.Height - diametro) / 2, diametro, diametro);

        using SolidBrush relleno = new SolidBrush(Color.FromArgb(120, 30, 132, 73));
        using Pen borde = new Pen(Color.FromArgb(20, 90, 50), 2);
        graficos.FillEllipse(relleno, figura);
        graficos.DrawEllipse(borde, figura);
    }
}
