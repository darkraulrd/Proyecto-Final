using ProyectoIntegradorPOO.Models.Unidad5;

namespace ProyectoIntegradorPOO.Interfaces;

/// <summary>
/// UNIDAD 5 — POLIMORFISMO MEDIANTE INTERFACES.
/// Contrato común para "cualquier cosa a la que se le pueda calcular un importe".
/// Lo implementan clases que NO están relacionadas por herencia (DetalleComida y PedidoBase),
/// y el formulario las trata a todas como ICalculable.
/// </summary>
public interface ICalculable
{
    string Descripcion { get; }

    Importe CalcularImporte();
}
