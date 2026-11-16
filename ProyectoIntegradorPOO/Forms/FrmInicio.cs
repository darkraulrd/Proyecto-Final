using ProyectoIntegradorPOO.Forms.Comun;

namespace ProyectoIntegradorPOO.Forms;

/// <summary>Pantalla de bienvenida: información de la asignatura y listado de actividades.</summary>
public partial class FrmInicio : FrmActividadBase
{
    public FrmInicio()
    {
        InitializeComponent();
        TituloActividad = "Bienvenido al Sistema Integrador de POO";
        ConceptosActividad = "Seleccione un proyecto en el menú superior, en el panel lateral o con doble clic en la tabla.";
    }

    /// <summary>Se dispara cuando el usuario pide abrir un proyecto desde la tabla.</summary>
    public event EventHandler<ActividadInfo>? ActividadSolicitada;

    private void FrmInicio_Load(object? sender, EventArgs e)
    {
        lblValorAsignatura.Text = $"{InformacionAplicacion.Asignatura}\n{InformacionAplicacion.Institucion}\nPeríodo {InformacionAplicacion.Periodo}";
        lblValorDesarrollador.Text = $"{InformacionAplicacion.Desarrollador}\nMatrícula: {InformacionAplicacion.Matricula}";
        lblValorActividades.Text = $"{CatalogoActividades.Actividades.Count} proyectos enlazados\n" +
                                   $"en {CatalogoActividades.Unidades.Count} unidades";

        dgvActividades.DataSource = CatalogoActividades.Actividades
            .Select(a => new
            {
                Unidad = a.Unidad,
                Proyecto = a.Nombre,
                Tipo = a.Tipo,
                Carpeta = a.Origen,
                Conceptos = a.Conceptos
            })
            .ToList();

        dgvActividades.Columns[0].FillWeight = 35;
        dgvActividades.Columns[1].FillWeight = 100;
        dgvActividades.Columns[2].FillWeight = 60;
        dgvActividades.Columns[3].FillWeight = 140;
        dgvActividades.Columns[4].FillWeight = 200;
    }

    private void dgvActividades_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && e.RowIndex < CatalogoActividades.Actividades.Count)
            ActividadSolicitada?.Invoke(this, CatalogoActividades.Actividades[e.RowIndex]);
    }
}
