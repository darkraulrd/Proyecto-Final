using ProyectoIntegradorPOO.Exceptions;
using ProyectoIntegradorPOO.Forms.Comun;
using ProyectoIntegradorPOO.Services;

namespace ProyectoIntegradorPOO.Forms.Unidad6;

/// <summary>
/// UNIDAD 6 — Manejo de excepciones. Cada botón provoca una situación de error distinta
/// y la traza muestra qué bloques se ejecutan: try → catch (el que corresponda) → finally.
/// </summary>
public partial class FrmManejoExcepciones : FrmActividadBase
{
    private static readonly Color ColorTry = Color.FromArgb(46, 134, 193);
    private static readonly Color ColorCatch = Color.FromArgb(192, 57, 43);
    private static readonly Color ColorFinally = Color.FromArgb(30, 132, 73);
    private static readonly Color ColorThrow = Color.FromArgb(211, 84, 0);

    private readonly int[] arreglo = { 10, 20, 30, 40, 50 };
    private int operacionesEjecutadas;
    private int erroresControlados;

    public FrmManejoExcepciones()
    {
        InitializeComponent();
        TituloActividad = "Unidad 6 · Manejo de excepciones";
        ConceptosActividad = "try · catch (específicos y general) · finally · throw / throw; · excepciones personalizadas (ValidacionException) · validación de entradas";
    }

    // ---------------- Pruebas ----------------

    private void btnDividir_Click(object? sender, EventArgs e) => Ejecutar("División entera A ÷ B", () =>
    {
        int a = CalculadoraSegura.ConvertirEntero(txtValorA.Text, "A");
        int b = CalculadoraSegura.ConvertirEntero(txtValorB.Text, "B");
        return $"{a} ÷ {b} = {CalculadoraSegura.Dividir(a, b)}";
    });

    private void btnMultiplicar_Click(object? sender, EventArgs e) => Ejecutar("Multiplicación verificada (checked)", () =>
    {
        int a = CalculadoraSegura.ConvertirEntero(txtValorA.Text, "A");
        int b = CalculadoraSegura.ConvertirEntero(txtValorB.Text, "B");
        return $"{a:N0} × {b:N0} = {CalculadoraSegura.Multiplicar(a, b):N0}";
    });

    private void btnIndice_Click(object? sender, EventArgs e) => Ejecutar("Acceso a arreglo[B]", () =>
    {
        int posicion = CalculadoraSegura.ConvertirEntero(txtValorB.Text, "B");
        return $"arreglo[{posicion}] = {CalculadoraSegura.ObtenerElemento(arreglo, posicion)}   (arreglo = {{ {string.Join(", ", arreglo)} }})";
    });

    private void btnValidarEdad_Click(object? sender, EventArgs e) => Ejecutar("Validar A como edad (excepción propia)", () =>
    {
        int edad = CalculadoraSegura.ConvertirEntero(txtValorA.Text, "A");
        return $"Edad válida: {CalculadoraSegura.ValidarEdad(edad)} años";
    });

    private void btnLeerArchivo_Click(object? sender, EventArgs e) => Ejecutar("Leer un archivo inexistente", () =>
    {
        string ruta = Path.Combine(Path.GetTempPath(), $"no_existe_{Guid.NewGuid():N}.txt");
        return CalculadoraSegura.LeerArchivo(ruta);
    });

    private void btnRelanzar_Click(object? sender, EventArgs e) => Ejecutar("throw; — capturar, registrar y relanzar", ConvertirYRelanzar);

    /// <summary>
    /// Captura la excepción en un nivel interno, deja constancia y la RELANZA con «throw;»
    /// (conserva la pila original) para que la maneje el nivel superior.
    /// </summary>
    private string ConvertirYRelanzar()
    {
        try
        {
            int valor = CalculadoraSegura.ConvertirEntero(txtValorA.Text, "A");
            return $"Conversión correcta: {valor}";
        }
        catch (ValidacionException ex)
        {
            Traza("  catch interno", $"registra «{ex.Message}» y relanza con throw;", ColorThrow);
            throw;
        }
    }

    // ---------------- Estructura try / catch / finally ----------------

    /// <summary>
    /// Ejecuta una operación con manejo estructurado de errores. Los catch van del más
    /// específico al más general: C# usa el primero cuyo tipo coincida.
    /// </summary>
    private void Ejecutar(string nombre, Func<string> operacion)
    {
        errorProvider.Clear();
        Traza("▶ " + nombre, "", Tema.Texto, negrita: true);
        Traza("  try", "inicia el bloque protegido", ColorTry);

        try
        {
            string resultado = operacion();
            Traza("  ✔ éxito", resultado, ColorFinally);
            MostrarMensaje(resultado, false);
        }
        catch (ValidacionException ex)
        {
            // Excepción personalizada: sabemos exactamente qué campo marcar.
            MarcarCampo(ex.Campo, ex.Message);
            Controlar(ex, "ValidacionException (personalizada)");
        }
        catch (DivideByZeroException ex)
        {
            errorProvider.SetError(txtValorB, "El divisor no puede ser cero.");
            Controlar(ex, "DivideByZeroException", "No es posible dividir entre cero. Cambie el valor de B.");
        }
        catch (OverflowException ex)
        {
            Controlar(ex, "OverflowException", "El resultado es demasiado grande para un entero (int).");
        }
        catch (IndexOutOfRangeException ex)
        {
            errorProvider.SetError(txtValorB, $"Use una posición entre 0 y {arreglo.Length - 1}.");
            Controlar(ex, "IndexOutOfRangeException", $"La posición indicada no existe. El arreglo tiene posiciones de 0 a {arreglo.Length - 1}.");
        }
        catch (FileNotFoundException ex)
        {
            Controlar(ex, "FileNotFoundException", $"El archivo «{Path.GetFileName(ex.FileName)}» no existe.");
        }
        catch (Exception ex)
        {
            // Catch general: último recurso para cualquier error no previsto.
            Controlar(ex, ex.GetType().Name + " (catch general)");
        }
        finally
        {
            // Se ejecuta SIEMPRE, haya error o no: ideal para liberar recursos o actualizar contadores.
            operacionesEjecutadas++;
            Traza("  finally", "se ejecuta siempre", ColorFinally);
            Traza("", "", Tema.Texto);
            lblContadores.Text = $"Operaciones ejecutadas: {operacionesEjecutadas}   ·   Errores controlados: {erroresControlados}";
        }
    }

    private void Controlar(Exception ex, string tipo, string? mensajeUsuario = null)
    {
        erroresControlados++;
        Traza($"  catch {tipo}", ex.Message, ColorCatch);
        if (ex.InnerException is not null)
            Traza("     InnerException", $"{ex.InnerException.GetType().Name}: {ex.InnerException.Message}", ColorCatch);

        MostrarMensaje(mensajeUsuario ?? ex.Message, true);
    }

    private void MarcarCampo(string campo, string mensaje)
    {
        Control? control = campo switch
        {
            "A" or "Edad" => txtValorA,
            "B" => txtValorB,
            _ => null
        };
        if (control is not null)
            errorProvider.SetError(control, mensaje);
    }

    private void MostrarMensaje(string mensaje, bool esError)
    {
        pnlMensaje.BackColor = esError ? Color.FromArgb(250, 219, 216) : Color.FromArgb(212, 239, 223);
        lblMensaje.ForeColor = esError ? ColorCatch : ColorFinally;
        lblMensaje.Text = (esError ? "⚠ " : "✔ ") + mensaje;
    }

    private void Traza(string bloque, string detalle, Color color, bool negrita = false)
    {
        rtbTraza.SelectionStart = rtbTraza.TextLength;
        rtbTraza.SelectionColor = color;
        rtbTraza.SelectionFont = negrita ? Tema.FuenteNegrita : Tema.FuenteMonoespaciada;
        rtbTraza.AppendText(string.IsNullOrEmpty(detalle) ? bloque + Environment.NewLine : $"{bloque,-34} {detalle}{Environment.NewLine}");
        rtbTraza.ScrollToCaret();
    }

    private void btnLimpiarTraza_Click(object? sender, EventArgs e)
    {
        rtbTraza.Clear();
        errorProvider.Clear();
        lblMensaje.Text = "";
        pnlMensaje.BackColor = Color.White;
    }
}
