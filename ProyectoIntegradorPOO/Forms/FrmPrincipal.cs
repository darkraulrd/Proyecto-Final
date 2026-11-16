using ProyectoIntegradorPOO.Forms.Comun;

namespace ProyectoIntegradorPOO.Forms;

/// <summary>
/// Centro de navegación de la aplicación. El menú de cada unidad y los botones del panel
/// lateral se generan a partir de CatalogoActividades, de modo que agregar una actividad
/// nueva no obliga a modificar ni borrar las opciones existentes.
/// </summary>
public partial class FrmPrincipal : Form
{
    private readonly NavegadorActividades navegador;
    private readonly Dictionary<string, Button> botonesNavegacion = new Dictionary<string, Button>();

    public FrmPrincipal()
    {
        InitializeComponent();
        navegador = new NavegadorActividades(pnlContenido);
        navegador.FormularioMostrado += Navegador_FormularioMostrado;
    }

    private void FrmPrincipal_Load(object? sender, EventArgs e)
    {
        Text = $"{InformacionAplicacion.Nombre} — v{InformacionAplicacion.Version}";
        lblAsignatura.Text = $"{InformacionAplicacion.Asignatura}  ·  {InformacionAplicacion.Institucion}  ·  {InformacionAplicacion.Periodo}";
        lblDesarrollador.Text = $"Desarrollado por:\n{InformacionAplicacion.Desarrollador} · {InformacionAplicacion.Matricula}";

        Tema.EstilizarBoton(btnSalir);
        EstilizarBotonNavegacion(btnInicio);
        btnInicio.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

        ConstruirMenuUnidades();
        ConstruirPanelNavegacion();
        ActualizarReloj();
        temporizadorReloj.Start();

        MostrarInicio();
    }

    // ---------------- Construcción del menú y del panel lateral ----------------

    private void ConstruirMenuUnidades()
    {
        Dictionary<int, ToolStripMenuItem> menus = new Dictionary<int, ToolStripMenuItem>
        {
            [1] = mnuUnidad1,
            [2] = mnuUnidad2,
            [3] = mnuUnidad3,
            [4] = mnuUnidad4,
            [5] = mnuUnidad5,
            [6] = mnuUnidad6
        };

        foreach (ActividadInfo actividad in CatalogoActividades.Actividades)
        {
            if (!menus.TryGetValue(actividad.Unidad, out ToolStripMenuItem? menuUnidad))
                continue;

            ToolStripMenuItem opcion = new ToolStripMenuItem(actividad.Nombre)
            {
                ToolTipText = $"{actividad.Origen} ({actividad.Tipo})\n{actividad.Conceptos}",
                Tag = actividad
            };
            opcion.Click += (_, _) => AbrirActividad(actividad);
            menuUnidad.DropDownItems.Add(opcion);
        }
    }

    private void ConstruirPanelNavegacion()
    {
        flpActividades.SuspendLayout();
        foreach (UnidadInfo unidad in CatalogoActividades.Unidades)
        {
            flpActividades.Controls.Add(new Label
            {
                Text = $"UNIDAD {unidad.Numero} · {unidad.Titulo.ToUpperInvariant()}",
                ForeColor = Color.FromArgb(133, 193, 233),
                Font = new Font("Segoe UI", 7.5F, FontStyle.Bold),
                Size = new Size(204, 30),
                TextAlign = ContentAlignment.BottomLeft,
                Margin = new Padding(4, 8, 0, 2)
            });

            foreach (ActividadInfo actividad in CatalogoActividades.DeUnidad(unidad.Numero))
            {
                Button boton = new Button
                {
                    Text = actividad.Nombre,
                    Size = new Size(204, 32),
                    Margin = new Padding(0, 1, 0, 1),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(12, 0, 0, 0),
                    Tag = actividad
                };
                EstilizarBotonNavegacion(boton);
                boton.Click += (_, _) => AbrirActividad(actividad);
                flpActividades.Controls.Add(boton);
                botonesNavegacion[actividad.Clave] = boton;
            }
        }
        flpActividades.ResumeLayout();
    }

    private static void EstilizarBotonNavegacion(Button boton)
    {
        boton.FlatStyle = FlatStyle.Flat;
        boton.FlatAppearance.BorderSize = 0;
        boton.FlatAppearance.MouseOverBackColor = Color.FromArgb(36, 62, 99);
        boton.BackColor = Tema.Navegacion;
        boton.ForeColor = Color.White;
        boton.Font = new Font("Segoe UI", 9.5F);
        boton.Cursor = Cursors.Hand;
    }

    // ---------------- Navegación ----------------

    private void MostrarInicio()
    {
        navegador.Mostrar(nameof(FrmInicio), () =>
        {
            FrmInicio inicio = new FrmInicio();
            inicio.ActividadSolicitada += (_, actividad) => AbrirActividad(actividad);
            return inicio;
        });
    }

    private void AbrirActividad(ActividadInfo actividad)
    {
        try
        {
            navegador.Mostrar(actividad.Clave, actividad.Crear);
        }
        catch (Exception ex)
        {
            // Si una actividad falla al abrirse, el resto de la aplicación sigue funcionando.
            Mensajes.Error($"No se pudo abrir la actividad \"{actividad.Nombre}\".\n\n{ex.Message}");
        }
    }

    private void Navegador_FormularioMostrado(object? sender, string clave)
    {
        ActividadInfo? actividad = CatalogoActividades.BuscarPorClave(clave);

        if (actividad is null)
        {
            lblUnidadActual.Text = "Inicio";
            lblEstado.Text = "Pantalla de inicio";
        }
        else
        {
            UnidadInfo? unidad = CatalogoActividades.BuscarUnidad(actividad.Unidad);
            lblUnidadActual.Text = unidad?.TituloCompleto ?? $"Unidad {actividad.Unidad}";
            lblEstado.Text = $"Actividad: {actividad.Nombre}  ·  {actividad.Origen}  ·  {actividad.Conceptos}";
        }

        // Resalta el botón de la actividad activa en el panel lateral.
        foreach ((string claveBoton, Button boton) in botonesNavegacion)
            boton.BackColor = claveBoton == clave ? Tema.NavegacionActiva : Tema.Navegacion;
        btnInicio.BackColor = clave == nameof(FrmInicio) ? Tema.NavegacionActiva : Tema.Navegacion;
    }

    // ---------------- Eventos del menú ----------------

    private void mnuInicio_Click(object? sender, EventArgs e) => MostrarInicio();

    private void mnuAcercaDe_Click(object? sender, EventArgs e)
    {
        using FrmAcercaDe acercaDe = new FrmAcercaDe();
        acercaDe.ShowDialog(this);
    }

    private void mnuSalir_Click(object? sender, EventArgs e) => Close();

    private void FrmPrincipal_FormClosing(object? sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing &&
            !Mensajes.Confirmar("¿Desea salir del Sistema Integrador?", "Salir"))
        {
            e.Cancel = true;
        }
    }

    private void temporizadorReloj_Tick(object? sender, EventArgs e) => ActualizarReloj();

    private void ActualizarReloj() => lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy  HH:mm:ss");
}
