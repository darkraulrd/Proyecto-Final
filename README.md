# Sistema Integrador de Programación Orientada a Objetos

Aplicación de escritorio en **C# / Windows Forms** que reúne, en una sola solución, todas las actividades prácticas de la asignatura **INF-5130 · Programación I** (UASD, período 2026-2). Cada actividad es un formulario propio, organizado por unidad temática y accesible desde un menú principal.

- **Desarrollador:** Raúl Mena · Matrícula 100758645
- **Solución:** `ProyectoIntegradorPOO.sln`
- **Proyecto principal:** `ProyectoIntegradorPOO`

## Proyectos originales enlazados

Además de sus propias actividades, el integrador **enlaza los proyectos entregados durante el curso** (carpetas hermanas dentro de `INF-5130`) y los muestra dentro de la aplicación como UserControls:

- Los proyectos de **consola** se ejecutan en una consola real incrustada (`UcConsolaIncrustada`), con el mismo comportamiento que al abrirlos por separado.
- Los proyectos **Windows Forms** muestran su formulario original (`UcFormularioIncrustado`).

Por eso la solución debe estar dentro de `INF-5130\LanzadorProyectos`, junto a esas carpetas: al compilar, se compilan también los originales. Un clon del repositorio sin esas carpetas no compilará los enlaces. La lista completa está en [Documentation/ACTIVIDADES.md](Documentation/ACTIVIDADES.md).

## Objetivo general

Demostrar la evolución del aprendizaje de la Programación Orientada a Objetos: desde la encapsulación (Unidad 2) hasta el manejo de excepciones y la persistencia de datos (Unidad 6), sin eliminar ni reemplazar las actividades anteriores.

## Tecnologías

| Elemento | Uso |
|---|---|
| C# 14 / .NET 10 (`net10.0-windows`) | Lenguaje y plataforma |
| Windows Forms | Interfaz gráfica |
| System.Text.Json | Persistencia en archivos JSON (Unidad 6) |
| xUnit | Pruebas unitarias de las clases de negocio |
| Git / GitHub | Control de versiones |

## Requisitos

- Windows 10 u 11.
- [.NET SDK 10](https://dotnet.microsoft.com/download) (o Visual Studio 2026 con la carga de trabajo *Desarrollo de escritorio de .NET*).

## Ejecución

Desde Visual Studio: abrir `ProyectoIntegradorPOO.sln`, establecer `ProyectoIntegradorPOO` como proyecto de inicio y presionar **F5**.

Desde la terminal, en la carpeta de la solución:

```bash
dotnet run --project ProyectoIntegradorPOO
```

Pruebas unitarias:

```bash
dotnet test ProyectoIntegradorPOO.sln
```

Los datos de la Unidad 6 se guardan en `%LocalAppData%\ProyectoIntegradorPOO\estudiantes.json` y se conservan al cerrar la aplicación.

## Organización

```
LanzadorProyectos/
├── ProyectoIntegradorPOO.sln
├── README.md
├── Documentation/            ARCHITECTURE.md · CHANGELOG.md · ACTIVIDADES.md
├── Enlaces/MenuPrincipal.Enlace/  Enlace a los archivos del formulario de INF-5130\Prueba
├── ProyectoIntegradorPOO/    Aplicación Windows Forms
│   ├── Program.cs
│   ├── InformacionAplicacion.cs
│   ├── Forms/                FrmPrincipal, FrmInicio, FrmAcercaDe
│   │   ├── Comun/            Formulario base, tema visual, navegación, catálogo de actividades
│   │   ├── Originales/       UcConsolaIncrustada, UcFormularioIncrustado, FrmProyectoOriginal
│   │   └── Unidad2 … Unidad6/  Un formulario por actividad
│   ├── Models/Unidad2 … Unidad6/  Clases del dominio de cada unidad
│   ├── Interfaces/           ICalculable, IEntidad, IRepositorio<T>
│   ├── Services/             ServicioEstudiantes, CalculadoraSegura
│   ├── Repositories/         RepositorioJson<T>
│   └── Exceptions/           ValidacionException, PersistenciaException, RegistroDuplicadoException
└── ProyectoIntegradorPOO.Tests/  Pruebas xUnit por unidad
```

Consulte [Documentation/ACTIVIDADES.md](Documentation/ACTIVIDADES.md) para el listado de actividades y [Documentation/ARCHITECTURE.md](Documentation/ARCHITECTURE.md) para la arquitectura.

## Cómo enlazar otro proyecto original

1. En `ProyectoIntegradorPOO.csproj`, agregar un `ProjectReference` a su `.csproj` (con `ReferenceOutputAssembly="false"` si es de consola).
2. En `Forms/Comun/CatalogoActividades.cs`, agregar una línea `Consola(...)` o `Formulario(...)` en su unidad.

## Cómo agregar una actividad nueva

1. Crear el modelo en `Models/UnidadN/` y, si aplica, servicios o interfaces.
2. Crear el formulario `FrmNombreActividad` en `Forms/UnidadN/` heredando de `FrmActividadBase`.
3. Agregar **una línea** en `Forms/Comun/CatalogoActividades.cs`. El menú, el panel lateral y la pantalla de inicio se actualizan solos.
4. Agregar pruebas en `ProyectoIntegradorPOO.Tests/UnidadN/` y actualizar `Documentation/`.
