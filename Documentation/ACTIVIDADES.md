# Actividades incorporadas

| Unidad | Actividad | Formulario | Clases involucradas | Conceptos POO aplicados | Estado |
|---|---|---|---|---|---|
| 2 | Cuenta bancaria | `FrmCuentaBancaria` | `CuentaBancaria`, `Movimiento`, `TipoMovimiento` | Encapsulación, atributos privados, propiedades de solo lectura, validaciones en métodos | Completada |
| 3 | Relaciones entre clases (estudiantes y cursos) | `FrmRelacionesClases` | `Estudiante`, `Profesor`, `Curso`, `Departamento`, `RegistroAcademico` | Asociación, agregación (1..*), composición, `List<T>`, `DataGridView`, `TreeView` | Completada |
| 3 | Composición: Pedidos (laboratorio) | `FrmComposicionPedido` | `Pedido`, `DetallePedido` | Composición (rombo lleno, 1..*), `List<DetallePedido>`, encapsulación | Completada |
| 4 | Lab 4.1 — Herencia y constructores | `FrmHerencia` | `Vehiculo`, `Motocicleta` | Herencia, clase base/derivada, `base(...)`, `protected` | Completada |
| 4 | Lab 4.2 — Polimorfismo y métodos sobrescritos | `FrmMetodosSobrescritos` | `Persona`, `EstudianteRol`, `ProfesorRol` | `virtual`, `override`, variable polimórfica | Completada |
| 4 | Lab 4.3 — Clases abstractas y polimorfismo | `FrmClasesAbstractas` | `Figura`, `Rectangulo`, `Circulo` | Clase y métodos abstractos, polimorfismo, dibujo con GDI+ | Completada |
| 4 | Nómina de empleados | `FrmNomina` | `Empleado`, `EmpleadoFijo`, `EmpleadoPorHoras`, `EmpleadoComision`, `Nomina` | Jerarquía abstracta, constructores base, `abstract`/`virtual`/`override`, polimorfismo | Completada |
| 5 | FoodExpress: pedidos y entregas | `FrmPolimorfismo` | `PedidoBase`, `PedidoLocal`, `PedidoDomicilio`, `PedidoParaLlevar`, `PedidoCombinado`, `DetalleComida`, `ItemMenu`, `Importe`, `ICalculable` | Polimorfismo dinámico, variables polimórficas, sobrecarga de métodos, operador `+`, interfaces | Completada |
| 5 | Sobrecarga de operadores | `FrmSobrecargaOperadores` | `Vector2D` | Operadores `+ - == !=`, `Equals`, `GetHashCode`, `IEquatable<T>` | Completada |
| 6 | Manejo de excepciones | `FrmManejoExcepciones` | `CalculadoraSegura`, `ValidacionException` | `try`, `catch` específicos y general, `finally`, `throw`, `throw;`, `InnerException`, excepciones personalizadas | Completada |
| 6 | Persistencia de datos (JSON) | `FrmPersistenciaDatos` | `EstudianteRegistro`, `ServicioEstudiantes`, `IRepositorio<T>`, `RepositorioJson<T>`, `PersistenciaException`, `RegistroDuplicadoException` | Serialización con `System.Text.Json`, repositorio, servicio, CRUD asíncrono, interfaces genéricas | Completada |

## Origen de cada actividad

Las actividades se basan en los laboratorios ya entregados en la carpeta del curso (`INF-5130`), que se conservan intactos como respaldo:

| Carpeta original | Actividad integrada |
|---|---|
| `Prueba/RM_100758645_U2/Banco` (consola) | Cuenta bancaria (U2) |
| `FormCursoEstudiante` (Windows Forms, agregación) | Relaciones entre clases (U3) |
| `Pedidos` — clases `Pedido` / `Detalle_pedido` | Composición: Pedidos (U3) |
| `SistemaVehiculos` (Lab 4.1) | Herencia y constructores (U4) |
| `Polimorfismo` (Lab 4.2) | Métodos sobrescritos (U4) |
| `ClasesAbstractas` (Lab 4.3) | Clases abstractas (U4) |
| `Nomina` | Nómina de empleados (U4, ampliada a la jerarquía abstracta) |
| `Pedidos` — FoodExpress (U5) | FoodExpress: polimorfismo (U5) |
