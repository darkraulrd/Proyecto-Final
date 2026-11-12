using System.Globalization;
using ProyectoIntegradorPOO.Forms.Comun;
using ProyectoIntegradorPOO.Interfaces;
using ProyectoIntegradorPOO.Models.Unidad5;

namespace ProyectoIntegradorPOO.Forms.Unidad5;

/// <summary>
/// UNIDAD 5 — FoodExpress: pedidos y entregas (Laboratorio de polimorfismo y sobrecarga).
///  Ejercicio 1: polimorfismo dinámico (PedidoBase abstracta + 3 derivadas con override).
///  Ejercicio 2: variables polimórficas (PedidoBase pedidoActual, List&lt;PedidoBase&gt;).
///  Ejercicio 3: polimorfismo estático (3 sobrecargas de AgregarDetalle).
///  Ejercicio 4: sobrecarga del operador + (pedido + pedido).
///  Ejercicio 5: polimorfismo con interfaces (ICalculable).
/// </summary>
public partial class FrmPolimorfismo : FrmActividadBase
{
    private readonly List<PedidoBase> pedidos = new List<PedidoBase>();

    // Variable polimórfica: puede contener un PedidoLocal, PedidoDomicilio o PedidoParaLlevar.
    private PedidoBase? pedidoActual;

    public FrmPolimorfismo()
    {
        InitializeComponent();
        TituloActividad = "Unidad 5 · FoodExpress — Polimorfismo";
        ConceptosActividad = "Polimorfismo dinámico (override) · variables polimórficas · sobrecarga de métodos · operador + · interfaz ICalculable";

        cmbServicio.Items.AddRange(new object[]
        {
            $"Local (propina {PedidoLocal.PorcentajePropina:P0})",
            $"Domicilio (entrega RD$ {PedidoDomicilio.CargoEntrega:N2})",
            $"Para llevar (empaque RD$ {PedidoParaLlevar.CargoEmpaque:N2})"
        });
        cmbServicio.SelectedIndex = 0;

        foreach (ItemMenu item in Catalogo.Items)
            cmbMenu.Items.Add(item);
        cmbMenu.SelectedIndex = 0;

        ActualizarEstado();
    }

    private TipoServicio ServicioElegido => cmbServicio.SelectedIndex switch
    {
        1 => TipoServicio.Domicilio,
        2 => TipoServicio.ParaLlevar,
        _ => TipoServicio.Local
    };

    private void cmbServicio_SelectedIndexChanged(object? sender, EventArgs e)
    {
        bool domicilio = ServicioElegido == TipoServicio.Domicilio;
        txtDireccion.Enabled = domicilio;
        lblDireccion.Enabled = domicilio;
        if (!domicilio) txtDireccion.Clear();
    }

    // ---------------- Pedido en construcción ----------------

    private void btnIniciarPedido_Click(object? sender, EventArgs e)
    {
        try
        {
            // La fábrica devuelve el tipo concreto, pero lo guardamos en una referencia base.
            pedidoActual = PedidoBase.Crear(ServicioElegido, txtCliente.Text, txtDireccion.Text);
            Escribir($"PedidoBase pedido = PedidoBase.Crear(...)  →  objeto real: {pedidoActual.GetType().Name}");
            ActualizarEstado();
            RefrescarPedidoActual();
        }
        catch (ArgumentException ex)
        {
            Mensajes.Advertencia(ex.Message);
        }
    }

    private void btnCancelarPedido_Click(object? sender, EventArgs e)
    {
        pedidoActual = null;
        ActualizarEstado();
        RefrescarPedidoActual();
    }

    private void btnAgregarMenu_Click(object? sender, EventArgs e)
    {
        if (pedidoActual is null || cmbMenu.SelectedItem is not ItemMenu item) return;

        Ejecutar(() =>
        {
            pedidoActual.AgregarDetalle(item, (int)nudCantidad.Value);           // sobrecarga 3
            Escribir($"AgregarDetalle(ItemMenu, int)  →  {nudCantidad.Value} × {item.Nombre}");
            RefrescarPedidoActual();
        });
    }

    private void btnAgregarPersonalizado_Click(object? sender, EventArgs e)
    {
        if (pedidoActual is null) return;

        string textoPrecio = txtPrecioPersonalizado.Text.Trim();
        if (!decimal.TryParse(textoPrecio, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal precio) &&
            !decimal.TryParse(textoPrecio, NumberStyles.Number, CultureInfo.InvariantCulture, out precio))
        {
            Mensajes.Advertencia("Escriba un precio numérico válido para el producto personalizado.");
            return;
        }

        Ejecutar(() =>
        {
            pedidoActual.AgregarDetalle(txtProductoPersonalizado.Text, (int)nudCantidad.Value, precio);   // sobrecarga 2
            Escribir($"AgregarDetalle(string, int, decimal)  →  {nudCantidad.Value} × {txtProductoPersonalizado.Text.Trim()} a RD$ {precio:N2}");
            txtProductoPersonalizado.Clear();
            txtPrecioPersonalizado.Clear();
            RefrescarPedidoActual();
        });
    }

    private void btnQuitarProducto_Click(object? sender, EventArgs e)
    {
        if (pedidoActual is null || dgvDetalles.CurrentRow is null) return;
        Ejecutar(() =>
        {
            pedidoActual.QuitarDetalle(dgvDetalles.CurrentRow.Index);
            RefrescarPedidoActual();
        });
    }

    private void btnRegistrarPedido_Click(object? sender, EventArgs e)
    {
        if (pedidoActual is null) return;
        if (pedidoActual.Detalles.Count == 0)
        {
            Mensajes.Advertencia("Agregue al menos un producto antes de registrar el pedido.");
            return;
        }

        pedidos.Add(pedidoActual);
        Escribir($"Registrado {pedidoActual.Descripcion}: {pedidoActual.NombreCargo} = {pedidoActual.CalcularCargoAdicional()}  ·  Total = {pedidoActual.Total()}");
        pedidoActual = null;
        txtCliente.Clear();
        txtDireccion.Clear();
        ActualizarEstado();
        RefrescarPedidoActual();
        RefrescarPedidos();
    }

    // ---------------- Pedidos registrados ----------------

    private void btnCombinar_Click(object? sender, EventArgs e)
    {
        List<PedidoBase> seleccionados = dgvPedidos.SelectedRows
            .Cast<DataGridViewRow>()
            .OrderBy(f => f.Index)
            .Select(f => pedidos[f.Index])
            .ToList();

        if (seleccionados.Count != 2)
        {
            Mensajes.Advertencia("Seleccione exactamente DOS pedidos (Ctrl + clic) para combinarlos con el operador +.");
            return;
        }

        Ejecutar(() =>
        {
            PedidoBase a = seleccionados[0];
            PedidoBase b = seleccionados[1];
            PedidoBase combinado = a + b;   // sobrecarga del operador +

            pedidos.Add(combinado);
            Escribir($"pedido#{a.Numero} + pedido#{b.Numero}  →  {combinado.Descripcion}");
            Escribir($"   {a.Total()} + {b.Total()} = {combinado.Total()}");
            RefrescarPedidos();
        });
    }

    private void btnRecorrerCalculables_Click(object? sender, EventArgs e)
    {
        // Polimorfismo mediante interfaz: objetos de clases no relacionadas tratados como ICalculable.
        List<ICalculable> calculables = new List<ICalculable>();
        foreach (PedidoBase pedido in pedidos)
        {
            calculables.Add(pedido);
            calculables.AddRange(pedido.Detalles);
        }

        if (calculables.Count == 0)
        {
            Mensajes.Advertencia("Registre al menos un pedido.");
            return;
        }

        Escribir("foreach (ICalculable c in calculables)  →  c.CalcularImporte()");
        foreach (ICalculable calculable in calculables)
        {
            string sangria = calculable is DetalleComida ? "      " : "   ";
            Escribir($"{sangria}[{calculable.GetType().Name}] {calculable.Descripcion} = {calculable.CalcularImporte()}");
        }
    }

    private void btnEliminarPedido_Click(object? sender, EventArgs e)
    {
        if (dgvPedidos.CurrentRow is null || dgvPedidos.CurrentRow.Index >= pedidos.Count) return;
        PedidoBase pedido = pedidos[dgvPedidos.CurrentRow.Index];
        if (!Mensajes.Confirmar($"¿Eliminar {pedido.Descripcion}?")) return;

        pedidos.Remove(pedido);
        RefrescarPedidos();
    }

    // ---------------- Presentación ----------------

    private void RefrescarPedidoActual()
    {
        if (pedidoActual is null)
        {
            dgvDetalles.DataSource = null;
            lblResumen.Text = "Inicie un pedido para agregar productos.";
            return;
        }

        dgvDetalles.DataSource = pedidoActual.Detalles
            .Select(d => new
            {
                Producto = d.Producto,
                Cantidad = d.Cantidad,
                Precio = $"RD$ {d.Precio:N2}",
                Importe = d.CalcularImporte().ToString()
            })
            .ToList();

        // CalcularCargoAdicional() es polimórfico: cada tipo de pedido lo calcula diferente.
        lblResumen.Text =
            $"Pedido #{pedidoActual.Numero} · {pedidoActual.GetType().Name} · {pedidoActual.Cliente}\n" +
            $"Subtotal {pedidoActual.Subtotal()}  +  {pedidoActual.NombreCargo} {pedidoActual.CalcularCargoAdicional()}  =  Total {pedidoActual.Total()}";
    }

    private void RefrescarPedidos()
    {
        dgvPedidos.DataSource = pedidos
            .Select(p => new
            {
                Número = p.Numero,
                Cliente = p.Cliente,
                Servicio = PedidoBase.ServicioTexto(p.Servicio),
                Clase = p.GetType().Name,
                Cargo = p.NombreCargo,
                Subtotal = p.Subtotal().ToString(),
                Adicional = p.CalcularCargoAdicional().ToString(),
                Total = p.Total().ToString()
            })
            .ToList();

        dgvPedidos.MultiSelect = true;
        lblTotalGeneral.Text = $"Pedidos: {pedidos.Count}";
    }

    private void ActualizarEstado()
    {
        bool activo = pedidoActual is not null;
        grpCliente.Enabled = !activo;
        grpProductos.Enabled = activo;
        btnRegistrarPedido.Enabled = activo;
        btnCancelarPedido.Enabled = activo;
    }

    private void Escribir(string linea) => txtSalida.AppendText(linea + Environment.NewLine);

    private static void Ejecutar(Action accion)
    {
        try
        {
            accion();
        }
        catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
        {
            Mensajes.Advertencia(ex.Message);
        }
    }
}
