# Sistema Integrador de Programación Orientada a Objetos

Aplicación de escritorio en **C# / Windows Forms** que reúne en una sola ventana los proyectos entregados durante la asignatura **INF-5130 · Programación I** (UASD, período 2026-2). Cada proyecto se abre **tal como fue entregado**, dentro de un UserControl, organizado por unidad.

- **Desarrollador:** Raúl Mena · Matrícula 100758645
- **Solución:** `ProyectoIntegradorPOO.sln`
- **Proyecto principal:** `ProyectoIntegradorPOO`

## Cómo funciona

La ventana `Menu` sigue la misma lógica que el proyecto *Registro Universitario* (INF-5120): un panel lateral con botones y un panel de contenido donde se muestra un UserControl a la vez con `Mostrar(vista, botón)`.

- **Inicio** lista todos los proyectos, con búsqueda.
- **Unidad 1 … 6** lista los proyectos de esa unidad.
- Al abrir un proyecto:
  - los de **consola** se ejecutan en una consola real de Windows dentro de `ucConsola` (con `ReadLine`, `ReadKey`, `Clear` y tildes como al abrirlos por separado), con botones **Ejecutar/Reiniciar** y **Detener**;
  - los **Windows Forms** muestran su formulario original dentro de `ucFormulario`.
- **Volver** regresa a la unidad. Cada proyecto conserva su estado al cambiar de pantalla y las consolas se cierran al salir.

Los proyectos originales viven en sus propias carpetas dentro de `INF-5130` y **no se copian ni se modifican**: la solución los enlaza con referencias de proyecto y los compila junto con el integrador. La lista completa está en [Documentation/ACTIVIDADES.md](Documentation/ACTIVIDADES.md).

## Tecnologías

| Elemento | Uso |
|---|---|
| C# 14 / .NET 10 (`net10.0-windows`) | Lenguaje y plataforma |
| Windows Forms | Interfaz gráfica |
| `conhost.exe` + `user32` (`SetParent`) | Consola real dentro de un UserControl |
| xUnit | Pruebas de la lista de proyectos |
| Git / GitHub | Control de versiones |

## Requisitos

- Windows 10 u 11.
- [.NET SDK 10](https://dotnet.microsoft.com/download) (o Visual Studio 2026 con la carga de trabajo *Desarrollo de escritorio de .NET*).
- La solución debe estar en `INF-5130\LanzadorProyectos`, junto a las carpetas de los proyectos originales. Un clon del repositorio sin esas carpetas no compilará los enlaces.

## Ejecución

Desde Visual Studio: abrir `ProyectoIntegradorPOO.sln`, establecer `ProyectoIntegradorPOO` como proyecto de inicio y presionar **F5** (compila también los proyectos originales).

Desde la terminal, en la carpeta de la solución:

```bash
dotnet run --project ProyectoIntegradorPOO
```

Pruebas:

```bash
dotnet test ProyectoIntegradorPOO.sln
```

## Organización

```
INF-5130/
├── LanzadorProyectos/                    ← esta solución
│   ├── ProyectoIntegradorPOO.sln
│   ├── README.md
│   ├── Documentation/                    ARCHITECTURE.md · CHANGELOG.md · ACTIVIDADES.md
│   ├── Enlaces/MenuPrincipal.Enlace/     Enlace a los archivos del formulario de INF-5130\Prueba
│   ├── ProyectoIntegradorPOO/
│   │   ├── Program.cs                    Abre el Menu
│   │   ├── Menu.cs                       Ventana principal: panel lateral + Mostrar(vista, botón)
│   │   ├── ucInicio.cs                   Todos los proyectos, con búsqueda
│   │   ├── ucUnidad.cs                   Proyectos de una unidad
│   │   ├── ucConsola.cs                  Proyecto de consola dentro de la aplicación
│   │   ├── ucFormulario.cs               Proyecto Windows Forms dentro de la aplicación
│   │   ├── ProyectoCurso.cs              Clase abstracta: ProyectoConsola y ProyectoFormulario
│   │   ├── Proyectos.cs                  Lista de unidades y proyectos enlazados
│   │   ├── Unidad.cs, InformacionAplicacion.cs, Ventanas.cs
│   │   └── Imagenes/, Properties/        Íconos y recursos
│   └── ProyectoIntegradorPOO.Tests/      Pruebas xUnit
├── Prueba/, FormCursoEstudiante/, SistemaVehiculos/, Polimorfismo/, ClasesAbstractas/,
│   Nomina/, Pedidos/, Practica/          ← proyectos originales enlazados (sin modificar)
```

Consulte [Documentation/ARCHITECTURE.md](Documentation/ARCHITECTURE.md) para la arquitectura.

## Cómo enlazar un proyecto nuevo

1. En `ProyectoIntegradorPOO/ProyectoIntegradorPOO.csproj`, agregar un `ProjectReference` a su `.csproj` (con `ReferenceOutputAssembly="false"` si es de consola).
2. En `Proyectos.cs`, agregar una línea `new ProyectoConsola { ... }` o `new ProyectoFormulario { ... }` en su unidad. Inicio y la pantalla de la unidad se actualizan solos.
3. Agregar la carpeta a la prueba `CadaProyectoOriginalEstaEnlazado` y actualizar `Documentation/`.
