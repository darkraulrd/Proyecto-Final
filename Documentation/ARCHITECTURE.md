# Arquitectura

## Visión general

Una aplicación Windows Forms que funciona como **lanzador integrado**: no reimplementa las prácticas del curso, sino que enlaza los proyectos originales de `INF-5130` y los muestra dentro de su ventana mediante dos UserControls.

```
┌──────────────────────────────── FrmPrincipal ────────────────────────────────┐
│ MenuStrip (Inicio · Unidad 1…6 · Acerca de · Salir)                           │
│ Panel lateral ──► NavegadorActividades ──► FrmInicio                          │
│                        │                └─► FrmProyectoOriginal (uno por proyecto)
│                        │                        ├─ UcConsolaIncrustada   (consola)
│ CatalogoActividades ───┘                        └─ UcFormularioIncrustado (Windows Forms)
└──────────────────────────────────────────────────────────────────────────────┘
```

## Estructura de carpetas y responsabilidades

| Carpeta / archivo | Responsabilidad |
|---|---|
| `Program.cs` | Punto de entrada. Configura la aplicación y un manejador global de errores no controlados. |
| `InformacionAplicacion.cs` | Datos generales: nombre, versión, asignatura, desarrollador. |
| `Forms/FrmPrincipal` | Centro de navegación: `MenuStrip` por unidades, panel lateral, encabezado, área de contenido y barra de estado. |
| `Forms/FrmInicio` | Bienvenida, datos de la asignatura y tabla de proyectos (doble clic abre el proyecto). |
| `Forms/FrmAcercaDe` | Ventana modal con información del proyecto. |
| `Forms/Comun/FrmActividadBase` | Formulario base: encabezado (título y conceptos) y estilo común. |
| `Forms/Comun/CatalogoActividades` | Registro central de unidades y proyectos enlazados (`Consola(...)` / `Formulario(...)`). |
| `Forms/Comun/NavegadorActividades` | Muestra pantallas dentro del área de contenido; crea **una sola instancia** por clave y la reutiliza. |
| `Forms/Comun/Tema`, `Mensajes` | Colores, fuentes, estilo de controles y cuadros de diálogo comunes. |
| `Forms/Originales/ProyectoOriginal` | Datos de un proyecto original (carpeta, tipo, ejecutable o fábrica de formulario) y `UbicacionProyectos`. |
| `Forms/Originales/FrmProyectoOriginal` | Pantalla que aloja el UserControl adecuado para cada proyecto. |
| `Forms/Originales/UcConsolaIncrustada` | Ejecuta un `.exe` de consola en una consola real incrustada. |
| `Forms/Originales/UcFormularioIncrustado` | Muestra el formulario de un proyecto Windows Forms. |
| `..\Enlaces\MenuPrincipal.Enlace` | Proyecto que enlaza (Link) los archivos del formulario de `INF-5130\Prueba`. |

## Navegación

1. `FrmPrincipal` construye los submenús de cada unidad y los botones del panel lateral recorriendo `CatalogoActividades.Actividades`.
2. Al elegir un proyecto se llama a `NavegadorActividades.Mostrar(clave, crear)`, con clave `FrmProyectoOriginal:<carpeta>`.
3. Si la pantalla ya existe se muestra de nuevo (conserva su estado, incluida una consola en ejecución); si no, se crea, se incrusta (`TopLevel = false`, `Dock = Fill`) y se guarda en un diccionario.
4. El evento `FormularioMostrado` actualiza el indicador de unidad, la barra de estado y resalta el botón activo.

## Enlace con los proyectos originales

```
INF-5130\
├── LanzadorProyectos\ProyectoIntegradorPOO   ──ProjectReference──►  FormCursoEstudiante, Pedidos      (Windows Forms)
│                                             ──ProjectReference──►  Enlaces\MenuPrincipal.Enlace ──Link──► Prueba\Menu.cs …
│                                             ──ProjectReference (solo compilar)──► Banco, Nomina, … (consola)
└── <carpetas originales sin modificar>
```

- **Compilación:** los `ProjectReference` hacen que al compilar el integrador se compilen también los originales. La ruta de `INF-5130` y la configuración (`Debug`/`Release`) se graban en el ensamblado con `AssemblyMetadata`; `UbicacionProyectos` las lee para encontrar cada `.exe`, sin rutas fijas en el código.
- **Consola (`UcConsolaIncrustada`):** inicia el `.exe` con `conhost.exe` (la consola clásica de Windows, que admite incrustarse), localiza la ventana del proceso, le quita los bordes y la convierte en ventana hija del panel (`SetParent`, `MoveWindow`). Como es una consola real, `ReadLine`, `ReadKey`, `Clear` y las tildes funcionan igual que fuera del integrador. Los procesos se cierran al pulsar Detener, al destruir el control, y al salir de la aplicación (`ApplicationExit` y `ProcessExit`).
- **Windows Forms (`UcFormularioIncrustado`):** crea el formulario original con `TopLevel = false` y lo coloca en un panel con desplazamiento. `Tema.Aplicar` no entra en formularios incrustados, así conservan su aspecto.
- **`Prueba` (Menu Principal):** su `.csproj` no compila por sí solo (incluye los `.cs` de sus subproyectos y `Program.cs` crea `new Menu()` en vez de `Form1`). `MenuPrincipal.Enlace` compila solo `Menu.cs`, `Menu.Designer.cs` y `Menu.resx` mediante `Link`, sin tocar el original.

## Dependencias externas

Solo la biblioteca estándar de .NET y la API de Windows (`user32.dll`). El proyecto de pruebas usa xUnit, `Microsoft.NET.Test.Sdk` y `coverlet.collector`.
