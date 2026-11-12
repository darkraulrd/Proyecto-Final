using System.Globalization;
using ProyectoIntegradorPOO.Forms.Comun;
using ProyectoIntegradorPOO.Models.Unidad4;

namespace ProyectoIntegradorPOO.Forms.Unidad4;

/// <summary>
/// UNIDAD 4 — Nómina con jerarquía abstracta Empleado.
/// La lista guarda referencias Empleado y CalcularSalario() responde distinto según el tipo real.
/// </summary>
public partial class FrmNomina : FrmActividadBase
{
    private const int TipoFijo = 0;
    private const int TipoPorHoras = 1;
    private const int TipoComision = 2;

    private readonly Nomina nomina = new Nomina();

    public FrmNomina()
    {
        InitializeComponent();
        TituloActividad = "Unidad 4 · Nómina de empleados";
        ConceptosActividad = "Clase abstracta Empleado · EmpleadoFijo, EmpleadoPorHoras y EmpleadoComision · constructores base · abstract, virtual y override.";
        cmbTipo.Items.AddRange(new object[] { "Empleado fijo", "Empleado por horas", "Empleado por comisión" });
        cmbTipo.SelectedIndex = TipoFijo;
    }

    private void cmbTipo_SelectedIndexChanged(object? sender, EventArgs e)
    {
        // Cada tipo de empleado necesita datos distintos para calcular su salario.
        (string, string?, string?) etiquetas = cmbTipo.SelectedIndex switch
        {
            TipoPorHoras => ("Horas trabajadas:", "Tarifa por hora:", null),
            TipoComision => ("Salario base:", "Ventas del mes:", "% de comisión:"),
            _ => ("Salario mensual:", null, null)
        };

        ConfigurarCampo(lblCampo1, txtCampo1, etiquetas.Item1);
        ConfigurarCampo(lblCampo2, txtCampo2, etiquetas.Item2);
        ConfigurarCampo(lblCampo3, txtCampo3, etiquetas.Item3);
    }

    private static void ConfigurarCampo(Label etiqueta, TextBox caja, string? texto)
    {
        etiqueta.Visible = caja.Visible = texto is not null;
        etiqueta.Text = texto ?? "";
        caja.Clear();
    }

    private void btnAgregar_Click(object? sender, EventArgs e)
    {
        try
        {
            Empleado empleado = CrearEmpleado();
            nomina.Agregar(empleado);
            RefrescarTabla();
            LimpiarCampos();
            Escribir($"Agregado → {empleado.Detalle()}");
        }
        catch (FormatException ex)
        {
            Mensajes.Advertencia(ex.Message);
        }
        catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
        {
            Mensajes.Advertencia(ex.Message);
        }
    }

    /// <summary>Fábrica: según el tipo elegido crea la clase derivada, pero devuelve la referencia base.</summary>
    private Empleado CrearEmpleado() => cmbTipo.SelectedIndex switch
    {
        TipoPorHoras => new EmpleadoPorHoras(txtCodigo.Text, txtNombre.Text, Leer(txtCampo1, lblCampo1), Leer(txtCampo2, lblCampo2)),
        TipoComision => new EmpleadoComision(txtCodigo.Text, txtNombre.Text, Leer(txtCampo1, lblCampo1), Leer(txtCampo2, lblCampo2), Leer(txtCampo3, lblCampo3)),
        _ => new EmpleadoFijo(txtCodigo.Text, txtNombre.Text, Leer(txtCampo1, lblCampo1))
    };

    private static decimal Leer(TextBox caja, Label etiqueta)
    {
        string texto = caja.Text.Trim();
        if (decimal.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal valor) ||
            decimal.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, out valor))
            return valor;

        caja.Focus();
        throw new FormatException($"El campo «{etiqueta.Text.TrimEnd(':')}» debe ser un número.");
    }

    private void btnEliminar_Click(object? sender, EventArgs e)
    {
        if (dgvEmpleados.CurrentRow is null || dgvEmpleados.CurrentRow.Index >= nomina.Empleados.Count)
        {
            Mensajes.Advertencia("Seleccione el empleado que desea eliminar.");
            return;
        }

        Empleado empleado = nomina.Empleados[dgvEmpleados.CurrentRow.Index];
        if (!Mensajes.Confirmar($"¿Eliminar a {empleado.Nombre} ({empleado.Codigo})?")) return;

        nomina.Eliminar(empleado.Codigo);
        RefrescarTabla();
    }

    private void btnCalcular_Click(object? sender, EventArgs e)
    {
        if (nomina.Empleados.Count == 0)
        {
            Mensajes.Advertencia("Agregue al menos un empleado.");
            return;
        }

        txtTraza.Clear();
        Escribir("foreach (Empleado empleado in nomina.Empleados)  →  empleado.CalcularSalario()");
        foreach (Empleado empleado in nomina.Empleados)
            Escribir($"   {empleado.GetType().Name,-17} {empleado.Nombre,-22} = RD$ {empleado.CalcularSalario(),12:N2}");
        Escribir($"   {"TOTAL",-40} = RD$ {nomina.CalcularTotal(),12:N2}");
    }

    private void RefrescarTabla()
    {
        dgvEmpleados.DataSource = nomina.Empleados
            .Select(emp => new
            {
                Código = emp.Codigo,
                Nombre = emp.Nombre,
                Tipo = emp.TipoEmpleado,
                Clase = emp.GetType().Name,
                Detalle = emp.Detalle(),
                Salario = $"RD$ {emp.CalcularSalario():N2}"
            })
            .ToList();

        if (dgvEmpleados.Columns.Count > 0)
            dgvEmpleados.Columns["Detalle"]!.FillWeight = 220;

        lblTotal.Text = $"Total de la nómina: RD$ {nomina.CalcularTotal():N2}   ({nomina.Empleados.Count} empleado(s))";
    }

    private void LimpiarCampos()
    {
        txtCodigo.Clear();
        txtNombre.Clear();
        txtCampo1.Clear();
        txtCampo2.Clear();
        txtCampo3.Clear();
        txtCodigo.Focus();
    }

    private void Escribir(string linea) => txtTraza.AppendText(linea + Environment.NewLine);
}
