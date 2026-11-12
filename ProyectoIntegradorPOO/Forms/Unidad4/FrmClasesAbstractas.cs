using ProyectoIntegradorPOO.Forms.Comun;
using ProyectoIntegradorPOO.Models.Unidad4;

namespace ProyectoIntegradorPOO.Forms.Unidad4;

/// <summary>UNIDAD 4 — Laboratorio 4.3: clase abstracta Figura con Rectangulo y Circulo.</summary>
public partial class FrmClasesAbstractas : FrmActividadBase
{
    private readonly List<Figura> figuras = new List<Figura>();

    public FrmClasesAbstractas()
    {
        InitializeComponent();
        TituloActividad = "Unidad 4 · Lab 4.3 — Clases abstractas y polimorfismo";
        ConceptosActividad = "Figura es abstract con los métodos abstractos CalcularArea() y Dibujar(); Rectangulo y Circulo los implementan con override.";
        txtPreguntas.Text =
            "1. Clase abstracta: clase incompleta que sirve de modelo; define lo común y deja métodos sin implementar.\r\n" +
            "2. No se puede hacer new Figura(...): es abstracta y no sabría calcular su área.\r\n" +
            "3. CalcularArea() abstracto: se declara sin cuerpo y cada derivada está OBLIGADA a implementarlo.\r\n" +
            "4. Las derivadas deben heredar de Figura e implementar con override todos sus métodos abstractos.\r\n" +
            "5. Polimorfismo: «Figura figura» guarda un Rectangulo o un Circulo y figura.CalcularArea() / figura.Dibujar() ejecutan la versión del objeto real.\r\n" +
            "6. Ventaja: el mismo código (lista, dibujo, área) sirve para cualquier figura actual o futura.";
        ActualizarCampos();
    }

    private Figura? FiguraSeleccionada => lstFiguras.SelectedItem as Figura;

    private void rbTipo_CheckedChanged(object? sender, EventArgs e) => ActualizarCampos();

    private void ActualizarCampos()
    {
        bool esRectangulo = rbRectangulo.Checked;
        lblDato1.Text = esRectangulo ? "Base:" : "Radio:";
        lblDato2.Visible = esRectangulo;
        nudDato2.Visible = esRectangulo;
    }

    private void btnCrearFigura_Click(object? sender, EventArgs e)
    {
        try
        {
            // Variable del tipo abstracto: puede referenciar cualquier figura concreta.
            Figura figura = rbRectangulo.Checked
                ? new Rectangulo((double)nudDato1.Value, (double)nudDato2.Value)
                : new Circulo((double)nudDato1.Value);

            figuras.Add(figura);
            lstFiguras.Items.Add(figura);
            lstFiguras.SelectedItem = figura;
        }
        catch (ArgumentException ex)
        {
            Mensajes.Advertencia(ex.Message);
        }
    }

    private void btnLimpiar_Click(object? sender, EventArgs e)
    {
        figuras.Clear();
        lstFiguras.Items.Clear();
        MostrarSeleccion();
    }

    private void lstFiguras_SelectedIndexChanged(object? sender, EventArgs e) => MostrarSeleccion();

    private void MostrarSeleccion()
    {
        Figura? figura = FiguraSeleccionada;
        lblResultado.Text = figura is null
            ? "Cree o seleccione una figura para dibujarla."
            : $"figura.Nombre = \"{figura.Nombre}\"  ·  figura.CalcularArea() = {figura.CalcularArea():N2}  ·  Suma de áreas: {figuras.Sum(f => f.CalcularArea()):N2}";
        picDibujo.Invalidate();
    }

    private void picDibujo_Paint(object? sender, PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        Rectangle area = picDibujo.ClientRectangle;
        area.Inflate(-20, -20);

        if (FiguraSeleccionada is Figura figura)
        {
            // Llamada polimórfica: cada figura sabe dibujarse a sí misma.
            figura.Dibujar(e.Graphics, area);
        }
        else
        {
            TextRenderer.DrawText(e.Graphics, "Área de dibujo", Tema.Fuente, picDibujo.ClientRectangle, Tema.TextoSecundario,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }

    private void picDibujo_Resize(object? sender, EventArgs e) => picDibujo.Invalidate();
}
