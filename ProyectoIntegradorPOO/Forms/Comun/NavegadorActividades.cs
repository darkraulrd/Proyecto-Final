namespace ProyectoIntegradorPOO.Forms.Comun;

/// <summary>
/// Mecanismo de navegación reutilizable: muestra formularios dentro de un panel contenedor.
/// Cada tipo de formulario se crea UNA sola vez y se reutiliza (no se abren instancias
/// duplicadas y el trabajo de la actividad se conserva al cambiar de pantalla).
/// </summary>
public sealed class NavegadorActividades
{
    private readonly Control contenedor;
    private readonly Dictionary<Type, Form> abiertos = new Dictionary<Type, Form>();

    public NavegadorActividades(Control contenedor)
    {
        this.contenedor = contenedor ?? throw new ArgumentNullException(nameof(contenedor));
    }

    public Form? Actual { get; private set; }

    /// <summary>Se dispara cada vez que cambia el formulario visible.</summary>
    public event EventHandler<Form>? FormularioMostrado;

    public Form Mostrar(Type tipo, Func<Form> crear)
    {
        if (!abiertos.TryGetValue(tipo, out Form? formulario) || formulario.IsDisposed)
        {
            formulario = crear();
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            // Nunca se encoge por debajo de su tamaño de diseño: si la ventana es pequeña,
            // el contenedor muestra barras de desplazamiento en lugar de encimar controles.
            formulario.MinimumSize = formulario.ClientSize;
            formulario.Dock = DockStyle.Fill;
            contenedor.Controls.Add(formulario);
            abiertos[tipo] = formulario;
        }

        if (!ReferenceEquals(Actual, formulario))
            Actual?.Hide();

        formulario.Show();
        formulario.BringToFront();
        Actual = formulario;
        FormularioMostrado?.Invoke(this, formulario);
        return formulario;
    }

    public T Mostrar<T>() where T : Form, new() => (T)Mostrar(typeof(T), () => new T());
}
