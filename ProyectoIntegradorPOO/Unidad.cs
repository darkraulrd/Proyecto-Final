namespace ProyectoIntegradorPOO
{
    public class Unidad
    {
        public Unidad(int numero, string titulo)
        {
            Numero = numero;
            Titulo = titulo;
        }

        public int Numero { get; }
        public string Titulo { get; }

        public string TituloCompleto => $"Unidad {Numero} · {Titulo}";
    }
}
