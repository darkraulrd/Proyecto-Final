using System.Globalization;
using ProyectoIntegradorPOO.Forms.Comun;
using ProyectoIntegradorPOO.Models.Unidad3;

namespace ProyectoIntegradorPOO.Forms.Unidad3;

/// <summary>
/// UNIDAD 3 — Laboratorio de composición: Pedido ◆— DetallePedido (1..*).
/// Los detalles se crean a través del pedido y desaparecen con él.
/// </summary>
public partial class FrmComposicionPedido : FrmActividadBase
{
    private Pedido? pedido;

    public FrmComposicionPedido()
    {
        InitializeComponent();
        TituloActividad = "Unidad 3 · Composición: Pedido y DetallePedido";
        ConceptosActividad = "Composición (rombo lleno, 1..*): el Pedido crea y posee sus detalles en una List<DetallePedido>.";
        ActualizarEstado();
    }

    private void btnCrearPedido_Click(object? sender, EventArgs e)
    {
        errorProvider.Clear();
        try
        {
            pedido = new Pedido(txtCliente.Text);
            ActualizarEstado();
            RefrescarDetalles();
            txtProducto.Focus();
        }
        catch (ArgumentException ex)
        {
            errorProvider.SetError(txtCliente, ex.Message);
            Mensajes.Advertencia(ex.Message);
        }
    }

    private void btnNuevoPedido_Click(object? sender, EventArgs e)
    {
        if (pedido is not null && pedido.Detalles.Count > 0 &&
            !Mensajes.Confirmar($"Al descartar el pedido #{pedido.Numero} también se eliminan sus {pedido.Detalles.Count} detalle(s) (composición). ¿Continuar?"))
            return;

        pedido = null; // Al perder el pedido, sus detalles ya no son accesibles: viven y mueren con él.
        txtCliente.Clear();
        LimpiarDetalle();
        errorProvider.Clear();
        ActualizarEstado();
        RefrescarDetalles();
        txtCliente.Focus();
    }

    private void btnAgregarDetalle_Click(object? sender, EventArgs e)
    {
        if (pedido is null) return;
        errorProvider.Clear();

        if (!decimal.TryParse(txtPrecio.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out decimal precio) &&
            !decimal.TryParse(txtPrecio.Text.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out precio))
        {
            errorProvider.SetError(txtPrecio, "Escriba un precio numérico.");
            Mensajes.Advertencia("Escriba un precio numérico válido.");
            return;
        }

        try
        {
            pedido.AgregarDetalle(txtProducto.Text, (int)nudCantidad.Value, precio);
            LimpiarDetalle();
            RefrescarDetalles();
            txtProducto.Focus();
        }
        catch (ArgumentException ex)
        {
            Mensajes.Advertencia(ex.Message);
        }
    }

    private void btnQuitarDetalle_Click(object? sender, EventArgs e)
    {
        if (pedido is null || dgvDetalles.CurrentRow is null)
        {
            Mensajes.Advertencia("Seleccione el detalle que desea quitar.");
            return;
        }

        pedido.QuitarDetalle(dgvDetalles.CurrentRow.Index);
        RefrescarDetalles();
    }

    private void RefrescarDetalles()
    {
        if (pedido is null)
        {
            dgvDetalles.DataSource = null;
            lblTotal.Text = "Total: RD$ 0.00";
            return;
        }

        dgvDetalles.DataSource = pedido.Detalles
            .Select((d, i) => new
            {
                Línea = i + 1,
                Producto = d.Producto,
                Cantidad = d.Cantidad,
                Precio = $"RD$ {d.Precio:N2}",
                Subtotal = $"RD$ {d.CalcularTotal():N2}"
            })
            .ToList();

        lblTotal.Text = $"Total: RD$ {pedido.CalcularTotal():N2}   ({pedido.Detalles.Count} detalle(s))";
    }

    private void ActualizarEstado()
    {
        bool activo = pedido is not null;
        txtCliente.ReadOnly = activo;
        btnCrearPedido.Enabled = !activo;
        grpDetalle.Enabled = activo;
        lblPedidoActual.Text = activo
            ? $"Pedido #{pedido!.Numero} · {pedido.Cliente} · {pedido.Fecha:dd/MM/yyyy HH:mm}"
            : "Cree un pedido para agregar detalles.";
    }

    private void LimpiarDetalle()
    {
        txtProducto.Clear();
        txtPrecio.Clear();
        nudCantidad.Value = 1;
    }
}
