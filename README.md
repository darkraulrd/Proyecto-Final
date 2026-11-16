# Sistema Integrador de Programación Orientada a Objetos

Aplicación de escritorio en **C# / Windows Forms** que reúne en una sola ventana los proyectos entregados durante la asignatura **INF-5130 · Programación I** (UASD, período 2026-2). Cada proyecto se abre **tal como fue entregado**, dentro de un UserControl, organizado por unidad y accesible desde un menú principal.

- **Desarrollador:** Raúl Mena · Matrícula 100758645
- **Solución:** `ProyectoIntegradorPOO.sln`
- **Proyecto principal:** `ProyectoIntegradorPOO`

## Cómo funciona

Los proyectos originales viven en sus propias carpetas dentro de `INF-5130` y **no se copian ni se modifican**: la solución los enlaza con referencias de proyecto y los compila junto con el integrador.

- Los proyectos de **consola** se ejecutan en una consola real de Windows incrustada en `UcConsolaIncrustada`, con el mismo comportamiento que al abrirlos por separado (`ReadLine`, `ReadKey`, `Clear`, tildes). Tienen botones **Ejecutar/Reiniciar** y **Detener**, siguen en ejecución al cambiar de pantalla y se cierran al salir.
- Los proyectos **Windows Forms** muestran su formulario original en `UcFormularioIncrustado`, con su diseño propio. Si se cierran (por ejemplo, con su botón «Salir»), se pueden abrir de nuevo.

La lista completa está en [Documentation/ACTIVIDADES.md](Documentation/ACTIVIDADES.md).

## Tecnologías

| Elemento | Uso |
|---|---|
| C# 14 / .NET 10 (`net10.0-windows`) | Lenguaje y plataforma |
| Windows Forms | Interfaz gráfica |
| `conhost.exe` + `user32` (`SetParent`) | Consola real incrustada en un UserControl |
| xUnit | Pruebas del catálogo de proyectos enlazados |
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
│   ├── ProyectoIntegradorPOO/            Aplicación Windows Forms
│   │   ├── Program.cs
│   │   ├── InformacionAplicacion.cs
│   │   └── Forms/
│   │       ├── FrmPrincipal, FrmInicio, FrmAcercaDe
│   │       ├── Comun/                    Formulario base, tema, navegación, catálogo de proyectos
│   │       └── Originales/               UcConsolaIncrustada, UcFormularioIncrustado, FrmProyectoOriginal
│   └── ProyectoIntegradorPOO.Tests/      Pruebas xUnit
├── Prueba/, FormCursoEstudiante/, SistemaVehiculos/, Polimorfismo/, ClasesAbstractas/,
│   Nomina/, Pedidos/, Practica/          ← proyectos originales enlazados (sin modificar)
```

Consulte [Documentation/ARCHITECTURE.md](Documentation/ARCHITECTURE.md) para la arquitectura.

## Cómo enlazar un proyecto nuevo

1. En `ProyectoIntegradorPOO/ProyectoIntegradorPOO.csproj`, agregar un `ProjectReference` a su `.csproj` (con `ReferenceOutputAssembly="false"` si es de consola).
2. En `Forms/Comun/CatalogoActividades.cs`, agregar una línea `Consola(...)` o `Formulario(...)` en su unidad. El menú, el panel lateral y la pantalla de inicio se actualizan solos.
3. Agregar la carpeta a la prueba `CadaProyectoOriginalEstaEnlazado` y actualizar `Documentation/`.
