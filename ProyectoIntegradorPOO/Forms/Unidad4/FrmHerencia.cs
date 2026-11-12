using ProyectoIntegradorPOO.Forms.Comun;
using ProyectoIntegradorPOO.Models.Unidad4;

namespace ProyectoIntegradorPOO.Forms.Unidad4;

/// <summary>UNIDAD 4 — Laboratorio 4.1: herencia y constructores (Vehiculo → Motocicleta).</summary>
public partial class FrmHerencia : FrmActividadBase
{
    private readonly List<Vehiculo> vehiculos = new List<Vehiculo>();

    public FrmHerencia()
    {
        InitializeComponent();
        TituloActividad = "Unidad 4 · Lab 4.1 — Herencia y constructores";
        ConceptosActividad = "Clase base Vehiculo, clase derivada Motocicleta : Vehiculo, llamada al constructor base(...) y miembros protected.";
        txtConceptos.Text = string.Join(Environment.NewLine + Environment.NewLine, new[]
        {
            "1. ¿Cuál es la clase base?  →  Vehiculo.",
            "2. ¿Cuál es la clase derivada?  →  Motocicleta.",
            "3. ¿Qué significa Motocicleta : Vehiculo?  →  Que Motocicleta hereda de Vehiculo: una motocicleta ES UN vehículo y obtiene sus miembros.",
            "4. ¿Para qué se utiliza base(...)?  →  Para llamar al constructor de Vehiculo e inicializar Marca y Modelo antes de inicializar Cilindrada.",
            "5. ¿Qué heredó Motocicleta de Vehiculo?  →  Las propiedades Marca y Modelo, el método MostrarInformacion() y la propiedad protegida TipoVehiculo."
        });
        ActualizarCampos();
    }

    private void rbTipo_CheckedChanged(object? sender, EventArgs e) => ActualizarCampos();

    private void ActualizarCampos()
    {
        bool esMoto = rbMotocicleta.Checked;
        lblCilindrada.Enabled = esMoto;
        nudCilindrada.Enabled = esMoto;
    }

    private void btnCrear_Click(object? sender, EventArgs e)
    {
        try
        {
            Vehiculo vehiculo = rbMotocicleta.Checked
                ? new Motocicleta(txtMarca.Text, txtModelo.Text, (int)nudCilindrada.Value)
                : new Vehiculo(txtMarca.Text, txtModelo.Text);

            vehiculos.Add(vehiculo);
            MostrarVehiculo(vehiculo);
            RefrescarTabla();
        }
        catch (ArgumentException ex)
        {
            Mensajes.Advertencia(ex.Message);
        }
    }

    private void MostrarVehiculo(Vehiculo vehiculo)
    {
        List<string> lineas = new List<string>
        {
            $"--- {vehiculo.GetType().Name} creado ---",
            vehiculo.MostrarInformacion()           // método heredado de Vehiculo
        };

        if (vehiculo is Motocicleta moto)
        {
            lineas.Add(moto.MostrarCilindrada());   // método propio de la clase derivada
            lineas.Add("");
            lineas.Add("Orden de construcción:");
            lineas.Add("  1) base(marca, modelo) → constructor de Vehiculo");
            lineas.Add("  2) cuerpo del constructor de Motocicleta → Cilindrada");
        }

        txtResultado.Text = string.Join(Environment.NewLine, lineas);
    }

    private void RefrescarTabla()
    {
        dgvVehiculos.DataSource = vehiculos
            .Select(v => new
            {
                Clase = v.GetType().Name,
                Marca = v.Marca,
                Modelo = v.Modelo,
                Cilindrada = v is Motocicleta m ? $"{m.Cilindrada} cc" : "—",
                EsUnVehiculo = v is Vehiculo ? "Sí" : "No"
            })
            .ToList();
    }

    private void dgvVehiculos_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvVehiculos.CurrentRow is { Index: >= 0 } fila && fila.Index < vehiculos.Count)
            MostrarVehiculo(vehiculos[fila.Index]);
    }
}
