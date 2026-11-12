using System.ComponentModel;

namespace ProyectoIntegradorPOO.Forms.Comun;

/// <summary>
/// Formulario base de todas las actividades (HERENCIA aplicada a la propia interfaz):
/// aporta el encabezado con título y conceptos, el color de fondo y el estilo común.
/// Cada actividad hereda de él y solo agrega sus propios controles.
/// </summary>
public partial class FrmActividadBase : Form
{
    public FrmActividadBase()
    {
        InitializeComponent();
    }

    [Category("Actividad"), Description("Título que aparece en el encabezado."), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string TituloActividad
    {
        get => lblTitulo.Text;
        set => lblTitulo.Text = value;
    }

    [Category("Actividad"), Description("Conceptos de POO que demuestra la actividad."), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string ConceptosActividad
    {
        get => lblConceptos.Text;
        set => lblConceptos.Text = value;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (!DesignMode)
            Tema.Aplicar(this);
    }
}
