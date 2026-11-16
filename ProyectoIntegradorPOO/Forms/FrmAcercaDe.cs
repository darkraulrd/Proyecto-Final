using ProyectoIntegradorPOO.Forms.Comun;

namespace ProyectoIntegradorPOO.Forms;

/// <summary>Ventana modal con la información del proyecto.</summary>
public partial class FrmAcercaDe : Form
{
    public FrmAcercaDe()
    {
        InitializeComponent();
    }

    private void FrmAcercaDe_Load(object? sender, EventArgs e)
    {
        Tema.EstilizarBoton(btnAceptar);
        lblNombre.Text = InformacionAplicacion.Nombre;
        lblDetalle.Text =
            $"Versión {InformacionAplicacion.Version}\n\n" +
            $"{InformacionAplicacion.Asignatura}\n{InformacionAplicacion.Institucion}\nPeríodo {InformacionAplicacion.Periodo}\n\n" +
            $"Desarrollador: {InformacionAplicacion.Desarrollador}\nMatrícula: {InformacionAplicacion.Matricula}\n\n" +
            "Tecnologías: C# · .NET 10 · Windows Forms · xUnit · Git";
    }
}
