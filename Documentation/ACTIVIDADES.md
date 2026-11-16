# Proyectos del curso

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

## No enlazados

- `LanzadorProyectos_respaldo`: proyecto vacío que ocupaba antes la carpeta `LanzadorProyectos`.
- `SistemaVehiculos_practica_anterior`: no tiene `.csproj`.
- Archivos `.zip` de entregas.

## Observaciones

- `Prueba\Menu Principal.csproj` no compila por sí solo: incluye los `.cs` de sus subcarpetas (que son proyectos aparte) y su `Program.cs` crea `new Menu()` aunque el formulario se llama `Form1`. El integrador lo enlaza mediante `Enlaces\MenuPrincipal.Enlace`, que compila solo los archivos del formulario sin modificar el original.
