using System.Globalization;

namespace ProyectoIntegradorPOO.Models.Unidad5;

/// <summary>
/// Vector en el plano con componentes X e Y (inmutable).
/// Sobrecarga de operadores con sentido matemático:
///  +  suma componente a componente,  -  resta componente a componente,
///  == y != comparan los valores (no las referencias).
/// Si se sobrecarga ==, C# exige también != y conviene redefinir Equals y GetHashCode
/// para que el objeto se comporte igual en colecciones (Dictionary, HashSet, Contains...).
/// </summary>
public sealed class Vector2D : IEquatable<Vector2D>
{
    public Vector2D(double x, double y)
    {
        if (double.IsNaN(x) || double.IsNaN(y) || double.IsInfinity(x) || double.IsInfinity(y))
            throw new ArgumentException("Las componentes del vector deben ser números finitos.");
        X = x;
        Y = y;
    }

    public double X { get; }
    public double Y { get; }

    public double Magnitud => Math.Sqrt(X * X + Y * Y);

    public static Vector2D Cero { get; } = new Vector2D(0, 0);

    public static Vector2D operator +(Vector2D a, Vector2D b)
    {
        ArgumentNullException.ThrowIfNull(a);
        ArgumentNullException.ThrowIfNull(b);
        return new Vector2D(a.X + b.X, a.Y + b.Y);
    }

    public static Vector2D operator -(Vector2D a, Vector2D b)
    {
        ArgumentNullException.ThrowIfNull(a);
        ArgumentNullException.ThrowIfNull(b);
        return new Vector2D(a.X - b.X, a.Y - b.Y);
    }

    public static bool operator ==(Vector2D? a, Vector2D? b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        return a.Equals(b);
    }

    public static bool operator !=(Vector2D? a, Vector2D? b) => !(a == b);

    public bool Equals(Vector2D? otro) => otro is not null && X.Equals(otro.X) && Y.Equals(otro.Y);

    public override bool Equals(object? obj) => Equals(obj as Vector2D);

    // Dos vectores iguales DEBEN producir el mismo código hash.
    public override int GetHashCode() => HashCode.Combine(X, Y);

    public override string ToString() =>
        string.Format(CultureInfo.InvariantCulture, "({0:0.##}, {1:0.##})", X, Y);
}
