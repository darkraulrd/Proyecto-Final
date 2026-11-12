using ProyectoIntegradorPOO.Forms.Comun;

namespace ProyectoIntegradorPOO.Forms;

/// <summary>Pantalla de bienvenida: información de la asignatura y listado de actividades.</summary>
public partial class FrmInicio : FrmActividadBase
{
    public FrmInicio()
    {
        InitializeComponent();
        TituloActividad = "Bienvenido al Sistema Integrador de POO";
        ConceptosActividad = "Seleccione una actividad en el menú superior, en el panel lateral o con doble clic en la tabla.";
    }

    /// <summary>Se dispara cuando el usuario pide abrir una actividad desde la tabla.</summary>
    public event EventHandler<ActividadInfo>? ActividadSolicitada;

    private void FrmInicio_Load(object? sender, EventArgs e)
    {
        lblValorAsignatura.Text = $"{InformacionAplicacion.Asignatura}\n{InformacionAplicacion.Institucion}\nPeríodo {InformacionAplicacion.Periodo}";
        lblValorDesarrollador.Text = $"{InformacionAplicacion.Desarrollador}\nMatrícula: {InformacionAplicacion.Matricula}";
        lblValorActividades.Text = $"{CatalogoActividades.Actividades.Count} actividades\nen {CatalogoActividades.Unidades.Count} unidades";

        dgvActividades.DataSource = CatalogoActividades.Actividades
            .Select(a => new
            {
                Unidad = a.Unidad,
                Actividad = a.Nombre,
                Formulario = a.Formulario,
                Conceptos = a.Conceptos,
                Estado = a.Estado
            })
            .ToList();

        dgvActividades.Columns[0].FillWeight = 35;
        dgvActividades.Columns[1].FillWeight = 110;
        dgvActividades.Columns[2].FillWeight = 95;
        dgvActividades.Columns[3].FillWeight = 210;
        dgvActividades.Columns[4].FillWeight = 55;
    }

    private void dgvActividades_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && e.RowIndex < CatalogoActividades.Actividades.Count)
            ActividadSolicitada?.Invoke(this, CatalogoActividades.Actividades[e.RowIndex]);
    }
}
