using System.Globalization;
using ProyectoIntegradorPOO.Forms.Comun;
using ProyectoIntegradorPOO.Models.Unidad2;

namespace ProyectoIntegradorPOO.Forms.Unidad2;

/// <summary>
/// UNIDAD 2 — Cuenta bancaria. El formulario solo recoge datos y muestra resultados:
/// toda modificación del saldo pasa por los métodos de CuentaBancaria.
/// </summary>
public partial class FrmCuentaBancaria : FrmActividadBase
{
    private CuentaBancaria? cuenta;

    public FrmCuentaBancaria()
    {
        InitializeComponent();
        TituloActividad = "Unidad 2 · Cuenta bancaria";
        ConceptosActividad = "Encapsulación: atributos privados, propiedades de solo lectura y métodos que protegen las reglas del saldo.";
        ActualizarEstadoControles();
    }

    private void btnAbrirCuenta_Click(object? sender, EventArgs e)
    {
        errorProvider.Clear();

        if (string.IsNullOrWhiteSpace(txtTitular.Text))
        {
            errorProvider.SetError(txtTitular, "El titular es obligatorio.");
            txtTitular.Focus();
            return;
        }

        try
        {
            cuenta = new CuentaBancaria(txtTitular.Text, txtNumeroCuenta.Text);
            ActualizarEstadoControles();
            MostrarDatosCuenta();
            txtMonto.Focus();
        }
        catch (ArgumentException ex)
        {
            Control campo = ex.ParamName == "titular" ? txtTitular : txtNumeroCuenta;
            errorProvider.SetError(campo, ex.Message);
            Mensajes.Advertencia(ex.Message);
        }
    }

    private void btnNuevaCuenta_Click(object? sender, EventArgs e)
    {
        if (cuenta is not null && !Mensajes.Confirmar("Se cerrará la cuenta actual y su historial. ¿Continuar?"))
            return;

        cuenta = null;
        txtTitular.Clear();
        txtNumeroCuenta.Clear();
        txtMonto.Clear();
        errorProvider.Clear();
        ActualizarEstadoControles();
        MostrarDatosCuenta();
        txtTitular.Focus();
    }

    private void btnDepositar_Click(object? sender, EventArgs e) =>
        EjecutarOperacion(monto => cuenta!.Depositar(monto), "Depósito realizado");

    private void btnRetirar_Click(object? sender, EventArgs e) =>
        EjecutarOperacion(monto => cuenta!.Retirar(monto), "Retiro realizado");

    private void btnConsultarSaldo_Click(object? sender, EventArgs e)
    {
        if (cuenta is null) return;

        decimal saldo = cuenta.ConsultarSaldo();
        MostrarDatosCuenta();
        Mensajes.Informacion($"Titular: {cuenta.Titular}\nCuenta: {cuenta.NumeroCuenta}\n\nSaldo disponible: RD$ {saldo:N2}", "Consulta de saldo");
    }

    private void btnDemostracion_Click(object? sender, EventArgs e)
    {
        Mensajes.Informacion(
            "El formulario NO puede modificar el saldo directamente.\n\n" +
            "    cuenta.Saldo = 1000000;   // Error CS0200: la propiedad es de solo lectura\n" +
            "    cuenta.saldo = 1000000;   // Error CS0122: 'saldo' es privado\n\n" +
            "La única forma de cambiarlo es mediante los métodos públicos:\n" +
            "    cuenta.Depositar(monto);  → valida que el monto sea mayor que cero\n" +
            "    cuenta.Retirar(monto);    → valida que haya fondos suficientes\n\n" +
            "Así la clase protege su información interna y garantiza que el saldo nunca sea inválido.",
            "¿Cómo se protege el saldo?");
    }

    /// <summary>Valida el monto escrito y ejecuta la operación indicada sobre la cuenta.</summary>
    private void EjecutarOperacion(Action<decimal> operacion, string titulo)
    {
        if (cuenta is null) return;
        errorProvider.SetError(txtMonto, "");

        if (!IntentarLeerMonto(out decimal monto))
        {
            errorProvider.SetError(txtMonto, "Escriba un monto numérico válido.");
            Mensajes.Advertencia("Escriba un monto numérico válido (por ejemplo: 1500.50).");
            txtMonto.Focus();
            return;
        }

        try
        {
            operacion(monto);
            MostrarDatosCuenta();
            txtMonto.Clear();
            Mensajes.Exito($"{titulo} por RD$ {monto:N2}.\nNuevo saldo: RD$ {cuenta.Saldo:N2}");
        }
        catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
        {
            // Las reglas de negocio las decide la clase; aquí solo se informa al usuario.
            errorProvider.SetError(txtMonto, ex.Message);
            Mensajes.Advertencia(ex.Message, "Operación no permitida");
        }
        txtMonto.Focus();
    }

    private bool IntentarLeerMonto(out decimal monto)
    {
        string texto = txtMonto.Text.Trim();
        return decimal.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, out monto)
            || decimal.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, out monto);
    }

    private void MostrarDatosCuenta()
    {
        if (cuenta is null)
        {
            lblSaldo.Text = "RD$ 0.00";
            lblCuentaActiva.Text = "No hay una cuenta abierta.";
            dgvMovimientos.DataSource = null;
            return;
        }

        lblSaldo.Text = $"RD$ {cuenta.Saldo:N2}";
        lblCuentaActiva.Text = $"{cuenta.Titular} · Cuenta {cuenta.NumeroCuenta}";

        dgvMovimientos.DataSource = cuenta.Movimientos
            .Reverse()
            .Select(m => new
            {
                Fecha = m.Fecha.ToString("dd/MM/yyyy HH:mm:ss"),
                Operación = m.Tipo switch
                {
                    TipoMovimiento.Deposito => "Depósito",
                    TipoMovimiento.Retiro => "Retiro",
                    _ => "Consulta de saldo"
                },
                Monto = m.Tipo == TipoMovimiento.Consulta ? "—" : $"RD$ {m.Monto:N2}",
                Saldo = $"RD$ {m.SaldoResultante:N2}"
            })
            .ToList();
    }

    private void ActualizarEstadoControles()
    {
        bool abierta = cuenta is not null;
        txtTitular.ReadOnly = abierta;
        txtNumeroCuenta.ReadOnly = abierta;
        btnAbrirCuenta.Enabled = !abierta;
        grpOperaciones.Enabled = abierta;
    }

    private void txtMonto_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            btnDepositar.PerformClick();
        }
    }
}
