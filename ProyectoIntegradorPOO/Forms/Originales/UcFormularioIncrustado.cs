using System.ComponentModel;

namespace ProyectoIntegradorPOO.Forms.Originales;

/// <summary>
/// UserControl que muestra el formulario ORIGINAL de un proyecto Windows Forms dentro de la
/// aplicación, con su tamaño y diseño exactos. Si el formulario se cierra (por ejemplo con su
/// propio botón «Salir»), permite volver a abrirlo.
/// </summary>
public partial class UcFormularioIncrustado : UserControl
{
    private Form? formulario;
    private bool abiertoAutomaticamente;

    public UcFormularioIncrustado()
    {
        InitializeComponent();
    }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Func<Form>? CrearFormulario { get; set; }

    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Descripcion { get; set; } = "";

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (!abiertoAutomaticamente && !DesignMode)
        {
            abiertoAutomaticamente = true;
            BeginInvoke(new Action(Abrir));
        }
    }

    private void btnReabrir_Click(object? sender, EventArgs e) => Abrir();

    public void Abrir()
    {
        Cerrar();
        if (CrearFormulario is null) return;

        try
        {
            formulario = CrearFormulario();
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.None;
            formulario.Location = new Point(16, 16);
            formulario.FormClosed += Formulario_FormClosed;

            pnlFormulario.Controls.Add(formulario);
            lblAviso.Visible = false;
            formulario.Show();

            lblEstado.Text = $"{Descripcion} · formulario {formulario.GetType().FullName} · {formulario.ClientSize.Width} × {formulario.ClientSize.Height}";
            btnReabrir.Text = "Reiniciar";
        }
        catch (Exception ex)
        {
            formulario = null;
            MostrarAviso($"No se pudo abrir el formulario original.\n\n{ex.Message}");
        }
    }

    private void Formulario_FormClosed(object? sender, FormClosedEventArgs e)
    {
        formulario = null;
        MostrarAviso("El formulario original se cerró.\nPulsa «Abrir de nuevo» para volver a usarlo.");
        btnReabrir.Text = "Abrir de nuevo";
    }

    private void Cerrar()
    {
        if (formulario is null) return;
        formulario.FormClosed -= Formulario_FormClosed;
        formulario.Close();
        formulario.Dispose();
        formulario = null;
    }

    private void MostrarAviso(string texto)
    {
        lblAviso.Text = texto;
        lblAviso.Visible = true;
        lblAviso.BringToFront();
    }
}
