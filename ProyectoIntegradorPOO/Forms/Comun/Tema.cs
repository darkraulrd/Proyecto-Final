namespace ProyectoIntegradorPOO.Forms.Comun;

/// <summary>
/// Identidad visual común de toda la aplicación. Los formularios solo colocan los controles
/// en el diseñador; los colores y estilos se aplican aquí en un solo lugar.
/// Botones: la propiedad Tag decide el color ("exito", "peligro", "secundario"; vacío = primario).
/// </summary>
public static class Tema
{
    public static readonly Color Primario = Color.FromArgb(31, 78, 121);
    public static readonly Color PrimarioClaro = Color.FromArgb(46, 134, 193);
    public static readonly Color Navegacion = Color.FromArgb(23, 42, 69);
    public static readonly Color NavegacionActiva = Color.FromArgb(46, 134, 193);
    public static readonly Color Fondo = Color.FromArgb(244, 246, 249);
    public static readonly Color Superficie = Color.White;
    public static readonly Color Texto = Color.FromArgb(33, 37, 41);
    public static readonly Color TextoSecundario = Color.FromArgb(108, 117, 125);
    public static readonly Color Exito = Color.FromArgb(30, 132, 73);
    public static readonly Color Peligro = Color.FromArgb(192, 57, 43);
    public static readonly Color Secundario = Color.FromArgb(108, 117, 125);
    public static readonly Color FilaAlterna = Color.FromArgb(234, 242, 248);

    public static readonly Font Fuente = new Font("Segoe UI", 9.75F);
    public static readonly Font FuenteNegrita = new Font("Segoe UI", 9.75F, FontStyle.Bold);
    public static readonly Font FuenteMonoespaciada = new Font("Consolas", 10F);

    /// <summary>Recorre el árbol de controles y aplica el estilo según el tipo de control.</summary>
    public static void Aplicar(Control raiz)
    {
        foreach (Control control in raiz.Controls)
        {
            switch (control)
            {
                case Button boton:
                    EstilizarBoton(boton);
                    break;
                case DataGridView tabla:
                    EstilizarTabla(tabla);
                    break;
                case GroupBox grupo:
                    EstilizarGrupo(grupo);
                    break;
            }

            Aplicar(control);
        }
    }

    public static void EstilizarBoton(Button boton)
    {
        Color color = (boton.Tag as string) switch
        {
            "exito" => Exito,
            "peligro" => Peligro,
            "secundario" => Secundario,
            _ => Primario
        };

        boton.FlatStyle = FlatStyle.Flat;
        boton.FlatAppearance.BorderSize = 0;
        boton.FlatAppearance.MouseOverBackColor = ControlPaint.Light(color, 0.25f);
        boton.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(color, 0.05f);
        boton.BackColor = color;
        boton.ForeColor = Color.White;
        boton.Font = FuenteNegrita;
        boton.Cursor = Cursors.Hand;
        boton.UseVisualStyleBackColor = false;
    }

    public static void EstilizarTabla(DataGridView tabla)
    {
        tabla.BackgroundColor = Superficie;
        tabla.BorderStyle = BorderStyle.FixedSingle;
        tabla.EnableHeadersVisualStyles = false;
        tabla.ColumnHeadersDefaultCellStyle.BackColor = Primario;
        tabla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        tabla.ColumnHeadersDefaultCellStyle.Font = FuenteNegrita;
        tabla.ColumnHeadersDefaultCellStyle.SelectionBackColor = Primario;
        tabla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        tabla.ColumnHeadersHeight = 34;
        tabla.DefaultCellStyle.Font = Fuente;
        tabla.DefaultCellStyle.ForeColor = Texto;
        tabla.DefaultCellStyle.SelectionBackColor = PrimarioClaro;
        tabla.DefaultCellStyle.SelectionForeColor = Color.White;
        tabla.AlternatingRowsDefaultCellStyle.BackColor = FilaAlterna;
        tabla.RowTemplate.Height = 28;
        tabla.RowHeadersVisible = false;
        tabla.AllowUserToAddRows = false;
        tabla.AllowUserToDeleteRows = false;
        tabla.AllowUserToResizeRows = false;
        tabla.ReadOnly = true;
        tabla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        tabla.GridColor = Color.FromArgb(222, 226, 230);
    }

    /// <summary>
    /// Título del grupo en negrita y color primario, sin que su contenido herede esos cambios:
    /// solo se restauran los hijos que usaban la fuente/color heredados del grupo
    /// (un TextBox con fuente Consolas, por ejemplo, la conserva).
    /// </summary>
    private static void EstilizarGrupo(GroupBox grupo)
    {
        List<Control> heredanFuente = grupo.Controls.Cast<Control>().Where(h => h.Font.Equals(grupo.Font)).ToList();
        List<Control> heredanColor = grupo.Controls.Cast<Control>().Where(h => h.ForeColor == grupo.ForeColor).ToList();

        grupo.ForeColor = Primario;
        grupo.Font = FuenteNegrita;

        foreach (Control hijo in heredanFuente)
            hijo.Font = Fuente;
        foreach (Control hijo in heredanColor)
            hijo.ForeColor = Texto;
    }
}
