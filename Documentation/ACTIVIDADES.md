# Actividades incorporadas

## Proyectos originales enlazados

Los proyectos entregados durante el curso se muestran **tal como están**, dentro de un UserControl, desde su propia carpeta en `INF-5130`. No se copian ni se modifican: si se cambia un original, el integrador muestra el cambio al compilar.

| Unidad | Proyecto | Carpeta (en `INF-5130`) | Tipo | Se muestra con | Conceptos |
|---|---|---|---|---|---|
| 1 | MiPrimerPrograma | `Prueba\RM_100758645_U1` | Consola | `UcConsolaIncrustada` | Entrada y salida por consola, conversión de tipos |
| 1 | Menu Principal | `Prueba` | Windows Forms | `UcFormularioIncrustado` (vía `Enlaces\MenuPrincipal.Enlace`) | Primer formulario con `MenuStrip` |
| 2 | Banco | `Prueba\RM_100758645_U2\Banco` | Consola | `UcConsolaIncrustada` | Encapsulación |
| 3 | FormCursoEstudiante | `FormCursoEstudiante` | Windows Forms | `UcFormularioIncrustado` | Agregación, `List<Estudiante>` |
| 3 | Alquiler de vehiculos | `Practica\Alquiler de vehiculos` | Consola | `UcConsolaIncrustada` | Clases, contenedor `List<Vehiculo>` |
| 4 | SistemaVehiculos (Lab 4.1) | `SistemaVehiculos` | Consola | `UcConsolaIncrustada` | Herencia, `base(...)` |
| 4 | Polimorfismo (Lab 4.2) | `Polimorfismo` | Consola | `UcConsolaIncrustada` | `virtual` / `override` |
| 4 | ClasesAbstractas (Lab 4.3) | `ClasesAbstractas` | Consola | `UcConsolaIncrustada` | Clases abstractas |
| 4 | Nomina | `Nomina` | Consola | `UcConsolaIncrustada` | Herencia, métodos sobrescritos |
| 5 | Pedidos (FoodExpress) | `Pedidos` | Windows Forms | `UcFormularioIncrustado` | Polimorfismo, operador `+`, UserControls, JSON |
| 6 | Tryparse | `Practica\Tryparse` | Consola | `UcConsolaIncrustada` | `try` / `catch` / `finally` |

No se enlazan: `LanzadorProyectos_respaldo` (proyecto vacío), `SistemaVehiculos_practica_anterior` (no tiene `.csproj`) y los archivos `.zip` de entregas.

## Versiones integradas

Versiones de las mismas prácticas desarrolladas dentro del integrador (aparecen en cursiva en el panel lateral, debajo de los originales).

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
