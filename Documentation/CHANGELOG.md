# Registro de cambios

El formato sigue la idea de [Keep a Changelog](https://keepachangelog.com/es-ES/1.1.0/).

## [1.1.0] — 2026-11-16

### Agregado
- **Proyectos originales enlazados**: los 11 proyectos del curso en `INF-5130` se muestran dentro de la aplicación sin copiarlos ni modificarlos.
  - `UcConsolaIncrustada`: ejecuta un proyecto de consola en una consola real de Windows (`conhost`) incrustada en el control, con botones Ejecutar/Reiniciar y Detener. Las consolas se cierran al salir de la aplicación.
  - `UcFormularioIncrustado`: muestra el formulario de un proyecto Windows Forms con su diseño original; si se cierra, permite abrirlo de nuevo.
  - `FrmProyectoOriginal`: pantalla que aloja cualquiera de los dos controles.
  - `Enlaces\MenuPrincipal.Enlace`: proyecto que enlaza (Link) los archivos del formulario de `Prueba`, cuyo `.csproj` original no compila por sí solo.
- Unidad 1 — Introducción a la programación, en el menú y en el panel lateral.
- Pruebas que verifican que cada proyecto original está enlazado, existe y (si es de consola) está compilado.

### Cambiado
- El navegador identifica cada pantalla con una clave de texto (varias actividades originales comparten el mismo formulario).
- Cada unidad muestra primero los proyectos originales y luego las versiones integradas (en cursiva).
- El tema visual ya no modifica el aspecto de los formularios originales incrustados.

## [1.0.1] — 2026-11-15

### Cambiado
- La solución se trasladó a la carpeta `INF-5130\LanzadorProyectos`. El proyecto vacío que existía allí (`LanzadorProyectos`, con `Form1`) se conservó en `INF-5130\LanzadorProyectos_respaldo`.

## [1.0.0] — 2026-11-12

### Base del proyecto
- Solución `ProyectoIntegradorPOO.sln` con el proyecto Windows Forms `ProyectoIntegradorPOO` (`net10.0-windows`) y el proyecto de pruebas `ProyectoIntegradorPOO.Tests` (xUnit).
- `FrmPrincipal` con `MenuStrip` (Inicio, Unidades 2 a 6, Acerca de, Salir), panel lateral de navegación, encabezado con indicador de unidad, área de contenido y barra de estado con reloj.
- `FrmInicio` (bienvenida y tabla de actividades) y `FrmAcercaDe`.
- `FrmActividadBase`, `Tema`, `Mensajes`, `NavegadorActividades` (una instancia por actividad) y `CatalogoActividades` (registro central de actividades).
- Manejador global de excepciones no controladas en `Program.cs`.

### Unidad 2 — Encapsulación
- `FrmCuentaBancaria` y `CuentaBancaria` (a partir del laboratorio de consola *Banco*): saldo privado de solo lectura, depósitos y retiros validados, historial de operaciones.

### Unidad 3 — Relaciones entre clases y contenedores
- `FrmRelacionesClases`: `Estudiante`, `Profesor`, `Curso`, `Departamento`, `RegistroAcademico` con asociación, agregación, composición y `List<T>` (a partir de *FormCursoEstudiante*).
- `FrmComposicionPedido`: `Pedido` y `DetallePedido` (laboratorio de composición).

### Unidad 4 — Herencia, polimorfismo y clases abstractas
- `FrmHerencia` (Lab 4.1), `FrmMetodosSobrescritos` (Lab 4.2), `FrmClasesAbstractas` (Lab 4.3, con dibujo de figuras) y `FrmNomina` (jerarquía abstracta `Empleado`).

### Unidad 5 — Polimorfismo y sobrecarga de operadores
- `FrmPolimorfismo`: FoodExpress con pedidos polimórficos, sobrecarga de `AgregarDetalle`, operador `+` entre pedidos e interfaz `ICalculable`.
- `FrmSobrecargaOperadores`: `Vector2D` con `+ - == !=`, `Equals` y `GetHashCode`, y plano cartesiano.

### Unidad 6 — Excepciones y persistencia de datos
- `FrmManejoExcepciones`: traza visual de `try / catch / finally`, `throw;` y excepciones personalizadas.
- `FrmPersistenciaDatos`: CRUD asíncrono de estudiantes en JSON mediante `ServicioEstudiantes` → `IRepositorio<T>` → `RepositorioJson<T>`.
- Excepciones `ValidacionException`, `PersistenciaException` y `RegistroDuplicadoException`.

### Pruebas
- 69 pruebas unitarias xUnit sobre las clases de negocio de todas las unidades y sobre el catálogo de actividades.
