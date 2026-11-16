# Arquitectura

## Visión general

Una aplicación Windows Forms que funciona como **lanzador integrado** de los proyectos del curso. Sigue la misma lógica que *Registro Universitario* (INF-5120):

- una ventana `Menu` con un **panel lateral** de botones (`pnlMenu`) y un **panel de contenido** (`pnlContenido`);
- **un UserControl por pantalla**, creado una sola vez y guardado en un campo `readonly`;
- un único método **`Mostrar(UserControl vista, Button activo)`** que quita la vista anterior sin destruirla, pone la nueva y resalta el botón;
- los clics se conectan con **lambdas** en el constructor y las vistas avisan al `Menu` con **eventos `Action<T>`**;
- un solo namespace con llaves y todos los archivos en la raíz del proyecto.

```
┌────────────── Menu ──────────────┬──────────────────── pnlContenido ─────────────────────┐
│ pnlMarca (logo + nombre)         │                                                        │
│ btnMenuInicio ─────────────────► │ ucInicio      (todos los proyectos, búsqueda)          │
│ btnUnidad1 … btnUnidad6 ───────► │ ucUnidad      (vistaUnidad.Cargar(unidad))             │
│                                  │   └ ProyectoSolicitado ─► AbrirProyecto(p)              │
│                                  │        p.CrearVista() ─► ucConsola  (consola)           │
│                                  │                        └► ucFormulario (Windows Forms)  │
│                                  │        VolverSolicitado ─► MostrarUnidad(p.Unidad)       │
│ btnSalir                         │                                                        │
└──────────────────────────────────┴────────────────────────────────────────────────────────┘
```

## Clases

| Archivo | Responsabilidad |
|---|---|
| `Program.cs` | Punto de entrada: abre el `Menu`. |
| `Menu.cs` | Ventana principal. Conecta los botones, guarda las vistas (`vistaUnidad` y un `Dictionary` con la vista de cada proyecto) y las muestra con `Mostrar`. Al cerrarse, cierra las consolas. |
| `ucInicio.cs` | Tabla con todos los proyectos y búsqueda. Evento `ProyectoSolicitado`. |
| `ucUnidad.cs` | Tabla con los proyectos de una unidad (`Cargar(unidad)`). Evento `ProyectoSolicitado`. |
| `ucConsola.cs` | Ejecuta un proyecto de consola dentro de la aplicación. Botones Ejecutar/Reiniciar, Detener y Volver. |
| `ucFormulario.cs` | Muestra el formulario original de un proyecto Windows Forms. Botones Abrir/Reiniciar y Volver. |
| `ProyectoCurso.cs` | Clase **abstracta** con lo común (unidad, nombre, carpeta, conceptos) y los miembros abstractos `Tipo` y `CrearVista()`. |
| `ProyectoConsola.cs` | Hija de `ProyectoCurso`: sabe dónde está su `.exe` y crea un `ucConsola`. |
| `ProyectoFormulario.cs` | Hija de `ProyectoCurso`: sabe crear su formulario y crea un `ucFormulario`. |
| `Proyectos.cs` | Clase estática con la lista de unidades y proyectos, búsqueda y la ubicación de `INF-5130`. |
| `Unidad.cs` | Número y título de una unidad. |
| `Ventanas.cs` | Funciones de `user32.dll` para meter la ventana de la consola dentro del panel. |
| `InformacionAplicacion.cs` | Nombre, asignatura y desarrollador. |

`AbrirProyecto` no pregunta qué tipo de proyecto es: llama a `proyecto.CrearVista()` y cada clase hija devuelve su propia pantalla (polimorfismo).

## Enlace con los proyectos originales

```
INF-5130\
├── LanzadorProyectos\ProyectoIntegradorPOO   ──ProjectReference──►  FormCursoEstudiante, Pedidos      (Windows Forms)
│                                             ──ProjectReference──►  Enlaces\MenuPrincipal.Enlace ──Link──► Prueba\Menu.cs …
│                                             ──ProjectReference (solo compilar)──► Banco, Nomina, … (consola)
└── <carpetas originales sin modificar>
```

- **Compilación:** los `ProjectReference` hacen que al compilar el integrador se compilen también los originales. La ruta de `INF-5130` y la configuración (`Debug`/`Release`) se graban en el ensamblado con `AssemblyMetadata`; `Proyectos` las lee para encontrar cada `.exe`, sin rutas fijas en el código.
- **Consola (`ucConsola`):** inicia el `.exe` con `conhost.exe` (la consola clásica de Windows, que se puede meter en otra ventana), localiza la ventana del programa, le quita los bordes y la convierte en hija de `pnlConsola` (`SetParent`, `MoveWindow`). Los procesos se cierran al pulsar Detener, al cerrar el `Menu` y si la aplicación termina (`ProcessExit`).
- **Windows Forms (`ucFormulario`):** crea el formulario original con `TopLevel = false` y lo coloca en un panel con desplazamiento, sin cambiar su aspecto.
- **`Prueba` (Menu Principal):** su `.csproj` no compila por sí solo (incluye los `.cs` de sus subproyectos y `Program.cs` crea `new Menu()` en vez de `Form1`). `MenuPrincipal.Enlace` compila solo `Menu.cs`, `Menu.Designer.cs` y `Menu.resx` mediante `Link`, sin tocar el original.

## Dependencias externas

Solo la biblioteca estándar de .NET y la API de Windows (`user32.dll`). El proyecto de pruebas usa xUnit, `Microsoft.NET.Test.Sdk` y `coverlet.collector`.
