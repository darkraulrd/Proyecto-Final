namespace ProyectoIntegradorPOO.Forms.Comun;

/// <summary>
/// Mecanismo de navegación reutilizable: muestra formularios dentro de un panel contenedor.
/// Cada pantalla se identifica con una clave y se crea UNA sola vez; después se reutiliza
/// (no se abren instancias duplicadas y su trabajo se conserva al cambiar de pantalla).
/// </summary>
public sealed class NavegadorActividades
{
    private readonly Control contenedor;
    private readonly Dictionary<string, Form> abiertos = new Dictionary<string, Form>();

    public NavegadorActividades(Control contenedor)
    {
        this.contenedor = contenedor ?? throw new ArgumentNullException(nameof(contenedor));
    }

    public Form? Actual { get; private set; }

    public string? ClaveActual { get; private set; }

    /// <summary>Se dispara cada vez que cambia la pantalla visible; envía su clave.</summary>
    public event EventHandler<string>? FormularioMostrado;

    public Form Mostrar(string clave, Func<Form> crear)
    {
        if (!abiertos.TryGetValue(clave, out Form? formulario) || formulario.IsDisposed)
        {
            formulario = crear();
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            // Nunca se encoge por debajo de su tamaño de diseño: si la ventana es pequeña,
            // el contenedor muestra barras de desplazamiento en lugar de encimar controles.
            formulario.MinimumSize = formulario.ClientSize;
            formulario.Dock = DockStyle.Fill;
            contenedor.Controls.Add(formulario);
            abiertos[clave] = formulario;
        }

        if (!ReferenceEquals(Actual, formulario))
            Actual?.Hide();

        formulario.Show();
        formulario.BringToFront();
        Actual = formulario;
        ClaveActual = clave;
        FormularioMostrado?.Invoke(this, clave);
        return formulario;
    }

    public T Mostrar<T>() where T : Form, new() => (T)Mostrar(typeof(T).Name, () => new T());
}
