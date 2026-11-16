using System;
using System.Windows.Forms;

namespace ProyectoIntegradorPOO
{
    // Proyecto Windows Forms: su formulario original se muestra dentro de ucFormulario
    public class ProyectoFormulario : ProyectoCurso
    {
        // Crea el formulario principal del proyecto (por ejemplo: () => new Pedidos.Menu())
        public Func<Form>? CrearFormulario { get; init; }

        public override string Tipo => "Windows Forms";

        public override UserControl CrearVista()
        {
            var vista = new ucFormulario();
            vista.Cargar(this);
            return vista;
        }
    }
}
