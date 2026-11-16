using ProyectoIntegradorPOO.Forms.Comun;

namespace ProyectoIntegradorPOO.Forms.Originales;

/// <summary>
/// Pantalla que aloja un proyecto original del curso. Según su tipo, coloca dentro
/// un UcConsolaIncrustada (consola) o un UcFormularioIncrustado (Windows Forms).
/// </summary>
public partial class FrmProyectoOriginal : FrmActividadBase
{
    public FrmProyectoOriginal()
    {
        InitializeComponent();
    }

    public FrmProyectoOriginal(ProyectoOriginal proyecto, int unidad, string conceptos) : this()
    {
        Proyecto = proyecto;
        TituloActividad = $"Unidad {unidad} · {proyecto.Nombre}";
        ConceptosActividad = $"Proyecto original enlazado desde INF-5130\\{proyecto.Carpeta}  ·  {conceptos}";
        Text = proyecto.Nombre;

        Control anfitrion = proyecto.Tipo == TipoProyectoOriginal.Consola
            ? new UcConsolaIncrustada { RutaEjecutable = proyecto.RutaEjecutable }
            : new UcFormularioIncrustado { CrearFormulario = proyecto.CrearFormulario, Descripcion = $"INF-5130\\{proyecto.Carpeta}" };

        anfitrion.Dock = DockStyle.Fill;
        pnlAnfitrion.Controls.Add(anfitrion);
    }

    public ProyectoOriginal? Proyecto { get; }
}
