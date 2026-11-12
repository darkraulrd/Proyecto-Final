using System.Globalization;
using ProyectoIntegradorPOO.Exceptions;

namespace ProyectoIntegradorPOO.Services;

/// <summary>
/// UNIDAD 6 — MANEJO DE EXCEPCIONES.
/// Operaciones que pueden fallar y LANZAN (throw) excepciones en lugar de devolver
/// valores "mágicos". El formulario decide cómo mostrarlas con try / catch / finally.
/// </summary>
public static class CalculadoraSegura
{
    /// <summary>Convierte un texto a entero. Lanza ValidacionException si no es válido.</summary>
    public static int ConvertirEntero(string texto, string campo)
    {
        if (string.IsNullOrWhiteSpace(texto))
            throw new ValidacionException(campo, $"El campo {campo} es obligatorio.");

        try
        {
            return int.Parse(texto.Trim(), NumberStyles.Integer, CultureInfo.CurrentCulture);
        }
        catch (FormatException ex)
        {
            throw new ValidacionException(campo, $"'{texto.Trim()}' no es un número entero válido para {campo}.", ex);
        }
        catch (OverflowException ex)
        {
            throw new ValidacionException(campo, $"El valor de {campo} está fuera del rango permitido ({int.MinValue:N0} a {int.MaxValue:N0}).", ex);
        }
    }

    /// <summary>División entera. La división entre cero la detecta .NET (DivideByZeroException).</summary>
    public static int Dividir(int dividendo, int divisor) => dividendo / divisor;

    /// <summary>
    /// Multiplicación verificada: "checked" hace que .NET lance OverflowException
    /// en lugar de dar un resultado incorrecto silenciosamente.
    /// </summary>
    public static int Multiplicar(int a, int b) => checked(a * b);

    /// <summary>Acceso a una posición de un arreglo: puede lanzar IndexOutOfRangeException.</summary>
    public static int ObtenerElemento(int[] arreglo, int posicion) => arreglo[posicion];

    /// <summary>Lee un archivo que puede no existir (FileNotFoundException).</summary>
    public static string LeerArchivo(string ruta) => File.ReadAllText(ruta);

    /// <summary>Regla de negocio propia: lanza la excepción personalizada.</summary>
    public static int ValidarEdad(int edad)
    {
        if (edad < 0)
            throw new ValidacionException("Edad", "La edad no puede ser negativa.");
        if (edad > 120)
            throw new ValidacionException("Edad", "La edad no puede ser mayor de 120 años.");
        return edad;
    }
}
