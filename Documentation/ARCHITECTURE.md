# Arquitectura

## Visión general

Una aplicación Windows Forms clásica que abre, dentro de su ventana, los proyectos hechos en el curso. Usa controles con su estilo normal de Windows (botones, `GroupBox`, `DataGridView`, `ListBox`) y una estructura sencilla:

- una ventana `Menu` con botones a la izquierda (`pnlMenu`) y un panel a la derecha (`pnlContenido`);
- un UserControl por pantalla; el `Menu` los guarda en variables y los muestra con `Mostrar(vista)`;
- los botones llaman a sus métodos `_Click` (conectados en el diseñador) y las pantallas avisan al `Menu` con eventos (`AbrirProyecto`, `Volver`).

```
┌──────── Menu ────────┬──────────────── pnlContenido ─────────────────┐
│ [Inicio] ──────────► │ ucInicio      (DataGridView con todos)        │
│ ┌ Unidades ┐         │                                               │
│ │[Unidad 1]│ ──────► │ ucUnidad      (ListBox con los de la unidad)  │
│ │   ...    │         │   └ AbrirProyecto ─► Menu.AbrirProyecto(p)    │
│ │[Unidad 6]│         │        si p.EsConsola ─► ucConsola            │
│ └──────────┘         │        si no          ─► ucFormulario         │
│ [Salir]              │        Volver ─► MostrarUnidad(p.Unidad)      │
└──────────────────────┴───────────────────────────────────────────────┘
```

## Archivos

| Archivo | Qué hace |
|---|---|
| `Program.cs` | Abre el `Menu`. |
| `Menu.cs` | Ventana principal. Muestra las pantallas, abre los proyectos y, al salir, cierra las consolas. |
| `ucInicio.cs` | Tabla (`DataGridView`) con todos los proyectos y botón **Abrir proyecto**. |
| `ucUnidad.cs` | `ListBox` con los proyectos de una unidad, su detalle y botón **Abrir proyecto**. |
| `ucConsola.cs` | Abre el `.exe` de un proyecto de consola y lo pone dentro de su panel. Botones **Ejecutar**, **Detener** y **Volver**. |
| `ucFormulario.cs` | Abre el formulario de un proyecto Windows Forms dentro de su panel. Botones **Abrir de nuevo** y **Volver**. |
| `Proyecto.cs` | Datos de un proyecto: unidad, nombre, carpeta, conceptos, si es de consola, ejecutable o formulario. |
| `Proyectos.cs` | Lista de unidades y proyectos (`Lista`, `DeUnidad`) y la ubicación de la carpeta `INF-5130`. |

## Enlace con los proyectos originales

```
INF-5130\
├── LanzadorProyectos\ProyectoIntegradorPOO   ──ProjectReference──►  FormCursoEstudiante, Pedidos      (Windows Forms)
│                                             ──ProjectReference──►  Enlaces\MenuPrincipal.Enlace ──Link──► Prueba\Menu.cs …
│                                             ──ProjectReference (solo compilar)──► Banco, Nomina, … (consola)
└── <carpetas originales sin modificar>
```

- **Compilación:** los `ProjectReference` hacen que al compilar el integrador se compilen también los originales. La ruta de `INF-5130` y la configuración (`Debug`/`Release`) se guardan en el programa con `AssemblyMetadata`; `Proyectos` las lee para encontrar cada `.exe`.
- **Consola (`ucConsola`):** abre el `.exe` con `conhost.exe` (la consola clásica de Windows), busca la ventana del programa y con `SetWindowLong`, `SetParent` y `MoveWindow` (de `user32.dll`) la pone dentro de `pnlConsola`, sin bordes. Como es una consola de verdad, `ReadLine`, `ReadKey`, `Clear` y las tildes funcionan igual. Las consolas se cierran con **Detener** y al salir del programa.
- **Windows Forms (`ucFormulario`):** crea el formulario original con `TopLevel = false` y lo agrega a `pnlFormulario`, sin cambiar su aspecto.
- **`Prueba` (Menu Principal):** su `.csproj` no compila por sí solo (incluye los `.cs` de sus subproyectos y `Program.cs` crea `new Menu()` en vez de `Form1`). `MenuPrincipal.Enlace` compila solo `Menu.cs`, `Menu.Designer.cs` y `Menu.resx` mediante `Link`, sin tocar el original.

## Dependencias externas

Solo .NET y la API de Windows (`user32.dll`). El proyecto de pruebas usa xUnit.
