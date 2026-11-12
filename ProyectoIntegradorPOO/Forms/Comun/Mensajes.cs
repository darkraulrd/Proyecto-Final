namespace ProyectoIntegradorPOO.Forms.Comun;

/// <summary>Cuadros de diálogo con títulos e iconos coherentes en toda la aplicación.</summary>
public static class Mensajes
{
    public static void Informacion(string texto, string titulo = "Información") =>
        MessageBox.Show(texto, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);

    public static void Exito(string texto, string titulo = "Operación realizada") =>
        MessageBox.Show(texto, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);

    public static void Advertencia(string texto, string titulo = "Validación") =>
        MessageBox.Show(texto, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);

    public static void Error(string texto, string titulo = "Error") =>
        MessageBox.Show(texto, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);

    public static bool Confirmar(string texto, string titulo = "Confirmar") =>
        MessageBox.Show(texto, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
}
