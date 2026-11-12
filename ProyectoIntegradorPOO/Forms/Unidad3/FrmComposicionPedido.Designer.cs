namespace ProyectoIntegradorPOO.Forms.Unidad3;

partial class FrmComposicionPedido
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Código generado por el Diseñador de Windows Forms

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        grpPedido = new GroupBox();
        lblPedidoActual = new Label();
        btnNuevoPedido = new Button();
        btnCrearPedido = new Button();
        txtCliente = new TextBox();
        lblCliente = new Label();
        grpDetalle = new GroupBox();
        btnQuitarDetalle = new Button();
        btnAgregarDetalle = new Button();
        txtPrecio = new TextBox();
        lblPrecio = new Label();
        nudCantidad = new NumericUpDown();
        lblCantidad = new Label();
        txtProducto = new TextBox();
        lblProducto = new Label();
        dgvDetalles = new DataGridView();
        lblTotal = new Label();
        lblExplicacion = new Label();
        errorProvider = new ErrorProvider(components);
        grpPedido.SuspendLayout();
        grpDetalle.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
        ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
        SuspendLayout();
        //
        // grpPedido
        //
        grpPedido.Controls.Add(lblPedidoActual);
        grpPedido.Controls.Add(btnNuevoPedido);
        grpPedido.Controls.Add(btnCrearPedido);
        grpPedido.Controls.Add(txtCliente);
        grpPedido.Controls.Add(lblCliente);
        grpPedido.Location = new Point(20, 92);
        grpPedido.Name = "grpPedido";
        grpPedido.Size = new Size(360, 150);
        grpPedido.TabIndex = 1;
        grpPedido.TabStop = false;
        grpPedido.Text = "Pedido";
        //
        // lblCliente
        //
        lblCliente.AutoSize = true;
        lblCliente.Location = new Point(14, 33);
        lblCliente.Name = "lblCliente";
        lblCliente.Size = new Size(51, 17);
        lblCliente.Text = "Cliente:";
        //
        // txtCliente
        //
        txtCliente.Location = new Point(100, 30);
        txtCliente.MaxLength = 80;
        txtCliente.Name = "txtCliente";
        txtCliente.Size = new Size(240, 25);
        txtCliente.TabIndex = 0;
        //
        // btnCrearPedido
        //
        btnCrearPedido.Location = new Point(100, 66);
        btnCrearPedido.Name = "btnCrearPedido";
        btnCrearPedido.Size = new Size(116, 34);
        btnCrearPedido.TabIndex = 1;
        btnCrearPedido.Tag = "exito";
        btnCrearPedido.Text = "Crear pedido";
        btnCrearPedido.Click += btnCrearPedido_Click;
        //
        // btnNuevoPedido
        //
        btnNuevoPedido.Location = new Point(224, 66);
        btnNuevoPedido.Name = "btnNuevoPedido";
        btnNuevoPedido.Size = new Size(116, 34);
        btnNuevoPedido.TabIndex = 2;
        btnNuevoPedido.Tag = "secundario";
        btnNuevoPedido.Text = "Nuevo pedido";
        btnNuevoPedido.Click += btnNuevoPedido_Click;
        //
        // lblPedidoActual
        //
        lblPedidoActual.Location = new Point(14, 110);
        lblPedidoActual.Name = "lblPedidoActual";
        lblPedidoActual.Size = new Size(330, 30);
        lblPedidoActual.Text = "Pedido actual";
        //
        // grpDetalle
        //
        grpDetalle.Controls.Add(btnQuitarDetalle);
        grpDetalle.Controls.Add(btnAgregarDetalle);
        grpDetalle.Controls.Add(txtPrecio);
        grpDetalle.Controls.Add(lblPrecio);
        grpDetalle.Controls.Add(nudCantidad);
        grpDetalle.Controls.Add(lblCantidad);
        grpDetalle.Controls.Add(txtProducto);
        grpDetalle.Controls.Add(lblProducto);
        grpDetalle.Location = new Point(20, 252);
        grpDetalle.Name = "grpDetalle";
        grpDetalle.Size = new Size(360, 200);
        grpDetalle.TabIndex = 2;
        grpDetalle.TabStop = false;
        grpDetalle.Text = "Agregar detalle al pedido";
        //
        // lblProducto
        //
        lblProducto.AutoSize = true;
        lblProducto.Location = new Point(14, 33);
        lblProducto.Name = "lblProducto";
        lblProducto.Size = new Size(63, 17);
        lblProducto.Text = "Producto:";
        //
        // txtProducto
        //
        txtProducto.Location = new Point(100, 30);
        txtProducto.MaxLength = 60;
        txtProducto.Name = "txtProducto";
        txtProducto.Size = new Size(240, 25);
        txtProducto.TabIndex = 0;
        //
        // lblCantidad
        //
        lblCantidad.AutoSize = true;
        lblCantidad.Location = new Point(14, 67);
        lblCantidad.Name = "lblCantidad";
        lblCantidad.Size = new Size(63, 17);
        lblCantidad.Text = "Cantidad:";
        //
        // nudCantidad
        //
        nudCantidad.Location = new Point(100, 64);
        nudCantidad.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
        nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudCantidad.Name = "nudCantidad";
        nudCantidad.Size = new Size(90, 25);
        nudCantidad.TabIndex = 1;
        nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
        //
        // lblPrecio
        //
        lblPrecio.AutoSize = true;
        lblPrecio.Location = new Point(14, 101);
        lblPrecio.Name = "lblPrecio";
        lblPrecio.Size = new Size(77, 17);
        lblPrecio.Text = "Precio (RD$):";
        //
        // txtPrecio
        //
        txtPrecio.Location = new Point(100, 98);
        txtPrecio.Name = "txtPrecio";
        txtPrecio.PlaceholderText = "0.00";
        txtPrecio.Size = new Size(120, 25);
        txtPrecio.TabIndex = 2;
        txtPrecio.TextAlign = HorizontalAlignment.Right;
        //
        // btnAgregarDetalle
        //
        btnAgregarDetalle.Location = new Point(100, 140);
        btnAgregarDetalle.Name = "btnAgregarDetalle";
        btnAgregarDetalle.Size = new Size(116, 34);
        btnAgregarDetalle.TabIndex = 3;
        btnAgregarDetalle.Tag = "exito";
        btnAgregarDetalle.Text = "Agregar";
        btnAgregarDetalle.Click += btnAgregarDetalle_Click;
        //
        // btnQuitarDetalle
        //
        btnQuitarDetalle.Location = new Point(224, 140);
        btnQuitarDetalle.Name = "btnQuitarDetalle";
        btnQuitarDetalle.Size = new Size(116, 34);
        btnQuitarDetalle.TabIndex = 4;
        btnQuitarDetalle.Tag = "peligro";
        btnQuitarDetalle.Text = "Quitar";
        btnQuitarDetalle.Click += btnQuitarDetalle_Click;
        //
        // dgvDetalles
        //
        dgvDetalles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvDetalles.Location = new Point(400, 100);
        dgvDetalles.Name = "dgvDetalles";
        dgvDetalles.Size = new Size(620, 420);
        dgvDetalles.TabIndex = 3;
        //
        // lblTotal
        //
        lblTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lblTotal.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
        lblTotal.ForeColor = Color.FromArgb(31, 78, 121);
        lblTotal.Location = new Point(400, 528);
        lblTotal.Name = "lblTotal";
        lblTotal.Size = new Size(620, 34);
        lblTotal.TabIndex = 4;
        lblTotal.Text = "Total: RD$ 0.00";
        lblTotal.TextAlign = ContentAlignment.MiddleRight;
        //
        // lblExplicacion
        //
        lblExplicacion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lblExplicacion.ForeColor = Color.FromArgb(108, 117, 125);
        lblExplicacion.Location = new Point(20, 570);
        lblExplicacion.Name = "lblExplicacion";
        lblExplicacion.Size = new Size(1000, 56);
        lblExplicacion.TabIndex = 5;
        lblExplicacion.Text = "Composición: el constructor de DetallePedido es internal y solo Pedido.AgregarDetalle() lo invoca. Un detalle no puede existir fuera de su pedido: al descartar el pedido, sus detalles se pierden con él. El total se calcula recorriendo la List<DetallePedido>.";
        //
        // errorProvider
        //
        errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        errorProvider.ContainerControl = this;
        //
        // FrmComposicionPedido
        //
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1040, 640);
        Controls.Add(lblExplicacion);
        Controls.Add(lblTotal);
        Controls.Add(dgvDetalles);
        Controls.Add(grpDetalle);
        Controls.Add(grpPedido);
        Name = "FrmComposicionPedido";
        Text = "Composición: Pedidos";
        grpPedido.ResumeLayout(false);
        grpPedido.PerformLayout();
        grpDetalle.ResumeLayout(false);
        grpDetalle.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
        ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox grpPedido;
    private Label lblPedidoActual;
    private Button btnNuevoPedido;
    private Button btnCrearPedido;
    private TextBox txtCliente;
    private Label lblCliente;
    private GroupBox grpDetalle;
    private Button btnQuitarDetalle;
    private Button btnAgregarDetalle;
    private TextBox txtPrecio;
    private Label lblPrecio;
    private NumericUpDown nudCantidad;
    private Label lblCantidad;
    private TextBox txtProducto;
    private Label lblProducto;
    private DataGridView dgvDetalles;
    private Label lblTotal;
    private Label lblExplicacion;
    private ErrorProvider errorProvider;
}
