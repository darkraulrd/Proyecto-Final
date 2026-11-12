namespace ProyectoIntegradorPOO.Forms.Unidad5;

partial class FrmPolimorfismo
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
        grpCliente = new GroupBox();
        btnIniciarPedido = new Button();
        txtDireccion = new TextBox();
        lblDireccion = new Label();
        cmbServicio = new ComboBox();
        lblServicio = new Label();
        txtCliente = new TextBox();
        lblCliente = new Label();
        grpProductos = new GroupBox();
        btnAgregarPersonalizado = new Button();
        txtPrecioPersonalizado = new TextBox();
        txtProductoPersonalizado = new TextBox();
        btnAgregarMenu = new Button();
        nudCantidad = new NumericUpDown();
        lblCantidad = new Label();
        cmbMenu = new ComboBox();
        lblMenu = new Label();
        txtSalida = new TextBox();
        dgvDetalles = new DataGridView();
        btnQuitarProducto = new Button();
        btnCancelarPedido = new Button();
        btnRegistrarPedido = new Button();
        lblResumen = new Label();
        lblPedidos = new Label();
        lblTotalGeneral = new Label();
        dgvPedidos = new DataGridView();
        btnCombinar = new Button();
        btnRecorrerCalculables = new Button();
        btnEliminarPedido = new Button();
        grpCliente.SuspendLayout();
        grpProductos.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvPedidos).BeginInit();
        SuspendLayout();
        //
        // grpCliente
        //
        grpCliente.Controls.Add(btnIniciarPedido);
        grpCliente.Controls.Add(txtDireccion);
        grpCliente.Controls.Add(lblDireccion);
        grpCliente.Controls.Add(cmbServicio);
        grpCliente.Controls.Add(lblServicio);
        grpCliente.Controls.Add(txtCliente);
        grpCliente.Controls.Add(lblCliente);
        grpCliente.Location = new Point(20, 92);
        grpCliente.Name = "grpCliente";
        grpCliente.Size = new Size(340, 168);
        grpCliente.TabIndex = 1;
        grpCliente.TabStop = false;
        grpCliente.Text = "1. Nuevo pedido";
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
        txtCliente.Location = new Point(96, 30);
        txtCliente.MaxLength = 60;
        txtCliente.Name = "txtCliente";
        txtCliente.Size = new Size(228, 25);
        txtCliente.TabIndex = 0;
        //
        // lblServicio
        //
        lblServicio.AutoSize = true;
        lblServicio.Location = new Point(14, 66);
        lblServicio.Name = "lblServicio";
        lblServicio.Size = new Size(56, 17);
        lblServicio.Text = "Servicio:";
        //
        // cmbServicio
        //
        cmbServicio.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbServicio.Location = new Point(96, 63);
        cmbServicio.Name = "cmbServicio";
        cmbServicio.Size = new Size(228, 25);
        cmbServicio.TabIndex = 1;
        cmbServicio.SelectedIndexChanged += cmbServicio_SelectedIndexChanged;
        //
        // lblDireccion
        //
        lblDireccion.AutoSize = true;
        lblDireccion.Location = new Point(14, 99);
        lblDireccion.Name = "lblDireccion";
        lblDireccion.Size = new Size(65, 17);
        lblDireccion.Text = "Dirección:";
        //
        // txtDireccion
        //
        txtDireccion.Location = new Point(96, 96);
        txtDireccion.MaxLength = 120;
        txtDireccion.Name = "txtDireccion";
        txtDireccion.Size = new Size(228, 25);
        txtDireccion.TabIndex = 2;
        //
        // btnIniciarPedido
        //
        btnIniciarPedido.Location = new Point(96, 128);
        btnIniciarPedido.Name = "btnIniciarPedido";
        btnIniciarPedido.Size = new Size(228, 32);
        btnIniciarPedido.TabIndex = 3;
        btnIniciarPedido.Tag = "exito";
        btnIniciarPedido.Text = "Iniciar pedido";
        btnIniciarPedido.Click += btnIniciarPedido_Click;
        //
        // grpProductos
        //
        grpProductos.Controls.Add(btnAgregarPersonalizado);
        grpProductos.Controls.Add(txtPrecioPersonalizado);
        grpProductos.Controls.Add(txtProductoPersonalizado);
        grpProductos.Controls.Add(btnAgregarMenu);
        grpProductos.Controls.Add(nudCantidad);
        grpProductos.Controls.Add(lblCantidad);
        grpProductos.Controls.Add(cmbMenu);
        grpProductos.Controls.Add(lblMenu);
        grpProductos.Location = new Point(20, 266);
        grpProductos.Name = "grpProductos";
        grpProductos.Size = new Size(340, 214);
        grpProductos.TabIndex = 2;
        grpProductos.TabStop = false;
        grpProductos.Text = "2. Agregar productos (sobrecarga)";
        //
        // lblMenu
        //
        lblMenu.AutoSize = true;
        lblMenu.Location = new Point(14, 33);
        lblMenu.Name = "lblMenu";
        lblMenu.Size = new Size(43, 17);
        lblMenu.Text = "Menú:";
        //
        // cmbMenu
        //
        cmbMenu.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbMenu.Location = new Point(96, 30);
        cmbMenu.Name = "cmbMenu";
        cmbMenu.Size = new Size(228, 25);
        cmbMenu.TabIndex = 0;
        //
        // lblCantidad
        //
        lblCantidad.AutoSize = true;
        lblCantidad.Location = new Point(14, 66);
        lblCantidad.Name = "lblCantidad";
        lblCantidad.Size = new Size(63, 17);
        lblCantidad.Text = "Cantidad:";
        //
        // nudCantidad
        //
        nudCantidad.Location = new Point(96, 63);
        nudCantidad.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
        nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudCantidad.Name = "nudCantidad";
        nudCantidad.Size = new Size(80, 25);
        nudCantidad.TabIndex = 1;
        nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
        //
        // btnAgregarMenu
        //
        btnAgregarMenu.Location = new Point(14, 96);
        btnAgregarMenu.Name = "btnAgregarMenu";
        btnAgregarMenu.Size = new Size(310, 32);
        btnAgregarMenu.TabIndex = 2;
        btnAgregarMenu.Text = "AgregarDetalle(item, cantidad)";
        btnAgregarMenu.Click += btnAgregarMenu_Click;
        //
        // txtProductoPersonalizado
        //
        txtProductoPersonalizado.Location = new Point(14, 138);
        txtProductoPersonalizado.MaxLength = 40;
        txtProductoPersonalizado.Name = "txtProductoPersonalizado";
        txtProductoPersonalizado.PlaceholderText = "Producto personalizado";
        txtProductoPersonalizado.Size = new Size(200, 25);
        txtProductoPersonalizado.TabIndex = 3;
        //
        // txtPrecioPersonalizado
        //
        txtPrecioPersonalizado.Location = new Point(222, 138);
        txtPrecioPersonalizado.Name = "txtPrecioPersonalizado";
        txtPrecioPersonalizado.PlaceholderText = "Precio";
        txtPrecioPersonalizado.Size = new Size(102, 25);
        txtPrecioPersonalizado.TabIndex = 4;
        txtPrecioPersonalizado.TextAlign = HorizontalAlignment.Right;
        //
        // btnAgregarPersonalizado
        //
        btnAgregarPersonalizado.Location = new Point(14, 170);
        btnAgregarPersonalizado.Name = "btnAgregarPersonalizado";
        btnAgregarPersonalizado.Size = new Size(310, 32);
        btnAgregarPersonalizado.TabIndex = 5;
        btnAgregarPersonalizado.Text = "AgregarDetalle(producto, cantidad, precio)";
        btnAgregarPersonalizado.Click += btnAgregarPersonalizado_Click;
        //
        // txtSalida
        //
        txtSalida.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        txtSalida.BackColor = Color.FromArgb(30, 30, 30);
        txtSalida.Font = new Font("Consolas", 9F);
        txtSalida.ForeColor = Color.FromArgb(220, 220, 220);
        txtSalida.Location = new Point(20, 488);
        txtSalida.Multiline = true;
        txtSalida.Name = "txtSalida";
        txtSalida.ReadOnly = true;
        txtSalida.ScrollBars = ScrollBars.Both;
        txtSalida.Size = new Size(340, 136);
        txtSalida.TabIndex = 3;
        txtSalida.WordWrap = false;
        //
        // dgvDetalles
        //
        dgvDetalles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        dgvDetalles.Location = new Point(380, 92);
        dgvDetalles.Name = "dgvDetalles";
        dgvDetalles.Size = new Size(640, 150);
        dgvDetalles.TabIndex = 4;
        //
        // btnQuitarProducto
        //
        btnQuitarProducto.Location = new Point(380, 248);
        btnQuitarProducto.Name = "btnQuitarProducto";
        btnQuitarProducto.Size = new Size(150, 30);
        btnQuitarProducto.TabIndex = 5;
        btnQuitarProducto.Tag = "peligro";
        btnQuitarProducto.Text = "Quitar producto";
        btnQuitarProducto.Click += btnQuitarProducto_Click;
        //
        // btnCancelarPedido
        //
        btnCancelarPedido.Location = new Point(538, 248);
        btnCancelarPedido.Name = "btnCancelarPedido";
        btnCancelarPedido.Size = new Size(150, 30);
        btnCancelarPedido.TabIndex = 6;
        btnCancelarPedido.Tag = "secundario";
        btnCancelarPedido.Text = "Cancelar pedido";
        btnCancelarPedido.Click += btnCancelarPedido_Click;
        //
        // btnRegistrarPedido
        //
        btnRegistrarPedido.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnRegistrarPedido.Location = new Point(850, 248);
        btnRegistrarPedido.Name = "btnRegistrarPedido";
        btnRegistrarPedido.Size = new Size(170, 30);
        btnRegistrarPedido.TabIndex = 7;
        btnRegistrarPedido.Tag = "exito";
        btnRegistrarPedido.Text = "Registrar pedido";
        btnRegistrarPedido.Click += btnRegistrarPedido_Click;
        //
        // lblResumen
        //
        lblResumen.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        lblResumen.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
        lblResumen.ForeColor = Color.FromArgb(31, 78, 121);
        lblResumen.Location = new Point(380, 284);
        lblResumen.Name = "lblResumen";
        lblResumen.Size = new Size(640, 44);
        lblResumen.TabIndex = 8;
        lblResumen.Text = "Inicie un pedido para agregar productos.";
        //
        // lblPedidos
        //
        lblPedidos.AutoSize = true;
        lblPedidos.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
        lblPedidos.Location = new Point(380, 334);
        lblPedidos.Name = "lblPedidos";
        lblPedidos.Size = new Size(260, 17);
        lblPedidos.TabIndex = 9;
        lblPedidos.Text = "Pedidos registrados — List<PedidoBase>";
        //
        // lblTotalGeneral
        //
        lblTotalGeneral.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblTotalGeneral.ForeColor = Color.FromArgb(108, 117, 125);
        lblTotalGeneral.Location = new Point(820, 334);
        lblTotalGeneral.Name = "lblTotalGeneral";
        lblTotalGeneral.Size = new Size(200, 17);
        lblTotalGeneral.TabIndex = 10;
        lblTotalGeneral.Text = "Pedidos: 0";
        lblTotalGeneral.TextAlign = ContentAlignment.MiddleRight;
        //
        // dgvPedidos
        //
        dgvPedidos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvPedidos.Location = new Point(380, 356);
        dgvPedidos.Name = "dgvPedidos";
        dgvPedidos.Size = new Size(640, 226);
        dgvPedidos.TabIndex = 11;
        //
        // btnCombinar
        //
        btnCombinar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnCombinar.Location = new Point(380, 590);
        btnCombinar.Name = "btnCombinar";
        btnCombinar.Size = new Size(240, 34);
        btnCombinar.TabIndex = 12;
        btnCombinar.Text = "Combinar 2 seleccionados (+)";
        btnCombinar.Click += btnCombinar_Click;
        //
        // btnRecorrerCalculables
        //
        btnRecorrerCalculables.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnRecorrerCalculables.Location = new Point(628, 590);
        btnRecorrerCalculables.Name = "btnRecorrerCalculables";
        btnRecorrerCalculables.Size = new Size(240, 34);
        btnRecorrerCalculables.TabIndex = 13;
        btnRecorrerCalculables.Text = "Recorrer como ICalculable";
        btnRecorrerCalculables.Click += btnRecorrerCalculables_Click;
        //
        // btnEliminarPedido
        //
        btnEliminarPedido.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnEliminarPedido.Location = new Point(900, 590);
        btnEliminarPedido.Name = "btnEliminarPedido";
        btnEliminarPedido.Size = new Size(120, 34);
        btnEliminarPedido.TabIndex = 14;
        btnEliminarPedido.Tag = "peligro";
        btnEliminarPedido.Text = "Eliminar";
        btnEliminarPedido.Click += btnEliminarPedido_Click;
        //
        // FrmPolimorfismo
        //
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1040, 640);
        Controls.Add(btnEliminarPedido);
        Controls.Add(btnRecorrerCalculables);
        Controls.Add(btnCombinar);
        Controls.Add(dgvPedidos);
        Controls.Add(lblTotalGeneral);
        Controls.Add(lblPedidos);
        Controls.Add(lblResumen);
        Controls.Add(btnRegistrarPedido);
        Controls.Add(btnCancelarPedido);
        Controls.Add(btnQuitarProducto);
        Controls.Add(dgvDetalles);
        Controls.Add(txtSalida);
        Controls.Add(grpProductos);
        Controls.Add(grpCliente);
        Name = "FrmPolimorfismo";
        Text = "FoodExpress: polimorfismo";
        grpCliente.ResumeLayout(false);
        grpCliente.PerformLayout();
        grpProductos.ResumeLayout(false);
        grpProductos.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvPedidos).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private GroupBox grpCliente;
    private Button btnIniciarPedido;
    private TextBox txtDireccion;
    private Label lblDireccion;
    private ComboBox cmbServicio;
    private Label lblServicio;
    private TextBox txtCliente;
    private Label lblCliente;
    private GroupBox grpProductos;
    private Button btnAgregarPersonalizado;
    private TextBox txtPrecioPersonalizado;
    private TextBox txtProductoPersonalizado;
    private Button btnAgregarMenu;
    private NumericUpDown nudCantidad;
    private Label lblCantidad;
    private ComboBox cmbMenu;
    private Label lblMenu;
    private TextBox txtSalida;
    private DataGridView dgvDetalles;
    private Button btnQuitarProducto;
    private Button btnCancelarPedido;
    private Button btnRegistrarPedido;
    private Label lblResumen;
    private Label lblPedidos;
    private Label lblTotalGeneral;
    private DataGridView dgvPedidos;
    private Button btnCombinar;
    private Button btnRecorrerCalculables;
    private Button btnEliminarPedido;
}
