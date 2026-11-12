# Arquitectura

## Visión general

Una única aplicación Windows Forms organizada en capas sencillas. La regla principal es que **los formularios no contienen reglas de negocio ni acceso a archivos**: recogen datos, llaman a los modelos/servicios y muestran resultados.

```
┌──────────────────────────── Presentación (Forms) ─────────────────────────────┐
│ FrmPrincipal ── NavegadorActividades ──► FrmActividadBase ◄── Frm<Actividad>   │
│        │                                     ▲ (herencia visual)               │
│        └── CatalogoActividades (menú, panel lateral, inicio)                   │
└───────────────┬───────────────────────────────────────────────┬───────────────┘
                │                                               │
        Models/UnidadN (dominio)                    Services (lógica de negocio)
                                                                │ depende de
                                                     Interfaces (IRepositorio<T>)
                                                                │ implementada por
                                                     Repositories (RepositorioJson<T>)
                                                                │
                                                       archivo JSON en disco
Exceptions: ValidacionException · PersistenciaException · RegistroDuplicadoException
```

## Estructura de carpetas y responsabilidades

| Carpeta / archivo | Responsabilidad |
|---|---|
| `Program.cs` | Punto de entrada. Configura la aplicación y un manejador global de errores no controlados. |
| `InformacionAplicacion.cs` | Datos generales: nombre, asignatura, desarrollador, carpeta de datos. |
| `Forms/FrmPrincipal` | Centro de navegación: `MenuStrip` por unidades, panel lateral, encabezado, área de contenido y barra de estado. |
| `Forms/FrmInicio` | Bienvenida, datos de la asignatura y tabla de actividades (doble clic abre la actividad). |
| `Forms/FrmAcercaDe` | Ventana modal con información del proyecto. |
| `Forms/Comun/FrmActividadBase` | Formulario base de todas las actividades: encabezado (título y conceptos POO) y estilo. |
| `Forms/Comun/CatalogoActividades` | Registro central de unidades y actividades. **Único lugar que se toca para agregar una actividad.** |
| `Forms/Comun/NavegadorActividades` | Muestra formularios dentro del panel de contenido; crea **una sola instancia** por tipo y la reutiliza. |
| `Forms/Comun/Tema` | Paleta de colores, fuentes y estilo de botones, tablas y grupos (el `Tag` del botón elige el color). |
| `Forms/Comun/Mensajes` | Cuadros de diálogo coherentes (información, advertencia, error, confirmación). |
| `Forms/UnidadN/` | Un formulario por actividad. |
| `Models/UnidadN/` | Clases del dominio de cada unidad. |
| `Interfaces/` | Contratos: `ICalculable` (U5), `IEntidad` e `IRepositorio<T>` (U6). |
| `Services/` | `ServicioEstudiantes` (validación + CRUD) y `CalculadoraSegura` (operaciones que lanzan excepciones). |
| `Repositories/` | `RepositorioJson<T>`: única clase que lee y escribe archivos. |
| `Exceptions/` | Excepciones personalizadas de la Unidad 6. |

## Navegación

1. `FrmPrincipal` construye los submenús de cada unidad y los botones del panel lateral recorriendo `CatalogoActividades.Actividades`.
2. Al elegir una actividad se llama a `NavegadorActividades.Mostrar(tipo, crear)`.
3. Si el formulario ya existe se muestra de nuevo (conserva su estado); si no, se crea, se incrusta (`TopLevel = false`, `Dock = Fill`) y se guarda en un diccionario.
4. El evento `FormularioMostrado` actualiza el indicador de unidad, la barra de estado y resalta el botón activo.

Cada actividad conserva su tamaño mínimo de diseño; si la ventana es pequeña, el área de contenido muestra barras de desplazamiento.

## Relaciones entre clases por unidad

### Unidad 2 — Encapsulación
- `CuentaBancaria`: atributos privados (`titular`, `numeroCuenta`, `saldo`), propiedades de solo lectura, `Depositar`, `Retirar`, `ConsultarSaldo`. Historial expuesto como `IReadOnlyList<Movimiento>`.

### Unidad 3 — Relaciones
- `Departamento ◆── Curso` (**composición**): el constructor de `Curso` es `internal`; solo `Departamento.CrearCurso()` lo crea.
- `Curso ◇── Estudiante` 1..* (**agregación**): `List<Estudiante>` con referencias a estudiantes que existen por separado.
- `Curso ── Profesor` (**asociación**): el curso guarda una referencia a un profesor existente.
- `RegistroAcademico`: contenedor con `List<Estudiante>`, `List<Profesor>` y el departamento.
- `Pedido ◆── DetallePedido` 1..* (**composición**, laboratorio): `DetallePedido` solo se crea desde `Pedido.AgregarDetalle()`.

### Unidad 4 — Herencia y clases abstractas
- `Vehiculo ◄── Motocicleta` (constructor `base(...)`, miembro `protected`).
- `Persona ◄── EstudianteRol, ProfesorRol` (`virtual` / `override` de `MostrarRol()`).
- `Figura` (abstracta) `◄── Rectangulo, Circulo` (`CalcularArea()` y `Dibujar()` abstractos).
- `Empleado` (abstracta) `◄── EmpleadoFijo, EmpleadoPorHoras, EmpleadoComision`; `Nomina` guarda `List<Empleado>`.

### Unidad 5 — Polimorfismo y sobrecarga
- `PedidoBase` (abstracta, implementa `ICalculable`) `◄── PedidoLocal, PedidoDomicilio, PedidoParaLlevar, PedidoCombinado`.
- `DetalleComida` implementa `ICalculable`; `Importe` sobrecarga `+`.
- `PedidoBase` sobrecarga `AgregarDetalle` (3 versiones) y el operador `+` (combinar pedidos).
- `Vector2D`: operadores `+`, `-`, `==`, `!=`, `Equals`, `GetHashCode`, `IEquatable<Vector2D>`.

### Unidad 6 — Excepciones y persistencia
```
FrmPersistenciaDatos ──► ServicioEstudiantes ──► IRepositorio<EstudianteRegistro>
                                                        ▲
                                              RepositorioJson<EstudianteRegistro> ──► estudiantes.json
```
- `ServicioEstudiantes` valida datos y lanza `ValidacionException` (con el campo afectado) o deja pasar `RegistroDuplicadoException`.
- `RepositorioJson<T>` traduce `IOException`, `UnauthorizedAccessException` y `JsonException` a `PersistenciaException`, escribe con archivo temporal + reemplazo y usa `async/await`.
- `CalculadoraSegura` concentra operaciones que pueden fallar para la demostración de `try / catch / finally / throw`.

## Dependencias externas

Solo la biblioteca estándar de .NET. El proyecto de pruebas usa xUnit, `Microsoft.NET.Test.Sdk` y `coverlet.collector`.
