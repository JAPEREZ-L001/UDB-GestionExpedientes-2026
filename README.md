# Sistema de Gestión de Expedientes Académicos

Proyecto de laboratorio — **Programación con Estructuras de Datos (PED104 — G01L)**, **Universidad Don Bosco**, 2026.

## Repositorio

**GitHub:** [https://github.com/JAPEREZ-L001/UDB-GestionExpedientes-2026](https://github.com/JAPEREZ-L001/UDB-GestionExpedientes-2026)

- Rama **`main`**: versión estable para revisión y entrega.
- Rama **`develop`**: integración continua del equipo (PRs).

## Equipo

| Integrante | Carnet | Rol |
|------------|--------|-----|
| Josué Adonaí Pérez López | PL250205 | Líder / Backend |
| Manuel Enrique Cáceres Mejía | CM250371 | Backend |
| Katherinne Ayleen Salazar Guerra | SG250348 | Frontend |
| Fernanda Guadalupe Hernández Galdámez | HG251382 | Frontend |

## Stack

- C# / .NET Framework 4.7.2
- Windows Forms (WinForms)
- Árbol **AVL** (inserción, eliminación con balanceo, búsqueda O(log n))
- Servicio de reportes: estadísticas por carrera y resumen del árbol
- Menú alineado con el desafío: opciones **1–8** (6 y 7 opcionales: visualización gráfica AVL con FB, comparación de rendimiento)

## Requisitos

- Windows 10/11
- [Visual Studio 2022](https://visualstudio.microsoft.com/) con carga de trabajo **Desarrollo de escritorio de .NET** (incluye MSBuild y .NET Framework 4.7.2)

## Cómo clonar y ejecutar

```bash
git clone https://github.com/JAPEREZ-L001/UDB-GestionExpedientes-2026.git
cd UDB-GestionExpedientes-2026
```

1. Abrir `GestionExpedientes.sln` en Visual Studio 2022.
2. Configuración **Debug** o **Release**.
3. **F5** para compilar y ejecutar.

### Compilar desde la terminal (MSBuild)

```powershell
& "${env:ProgramFiles}\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\MSBuild.exe" GestionExpedientes.sln /p:Configuration=Release
```

(Ajusta la ruta si usas **Community** o **Professional** en lugar de Enterprise.)

## Publicar cambios con GitHub CLI

Requiere [GitHub CLI](https://cli.github.com/) (`gh`) instalado y sesión iniciada (`gh auth login`).

```bash
git add .
git status
git commit -m "Descripción breve del cambio"
git push origin main
```

Para crear un PR hacia `develop` desde una rama de feature:

```bash
git checkout -b feature/mi-cambio
# ... commits ...
git push -u origin feature/mi-cambio
gh pr create --base develop --head feature/mi-cambio --title "Título" --body "Descripción"
```

## Estructura del proyecto

```
GestionExpedientes/
├── Models/
│   ├── Estudiante.cs        — Datos del estudiante (carnet, carrera, promedio, créditos)
│   └── NodoArbol.cs         — Nodo del árbol AVL (altura)
├── Services/
│   ├── ArbolEstudiantes.cs  — AVL + `EstadisticasPorCarrera()` (sección 3.3 del desafío)
│   └── ReportesService.cs   — Delega estadísticas; resumen textual del árbol
└── Forms/
    ├── FormPrincipal.cs     — Menú 1–8 (desafío práctico)
    ├── FormRegistro.cs      — Registrar estudiante
    ├── FormBusqueda.cs      — Buscar por carnet
    ├── FormListado.cs       — Listado ordenado por carnet
    ├── FormEliminar.cs      — Eliminar por carnet
    ├── FormEstadisticas.cs  — Totales, altura y tabla por carrera
    ├── FormVisualizarArbol.cs — Opción 6: gráfico del árbol y factor de balance (AVL)
    └── FormCompararRendimiento.cs — Opción 7: medición AVL vs búsqueda lineal (datos de prueba)
```

## Documentación del curso

En el repositorio, carpeta `docs/`:

- `docs/init/Desafio_2_lab_PED.md` — Enunciado del desafío
- `docs/init/Plan_de_Trabajo_Equipo.md` — Plan y convenciones del equipo
- `docs/issues/` — Issues por miembro

## Flujo de trabajo (equipo)

- Las ramas **`feature/*`** se integran en **`develop`** mediante Pull Requests.
- La rama **`main`** concentra la versión acordada para entrega o revisión final (según acuerdo del líder).

## Declaración de uso de IA

**GitHub Copilot** se utilizó **únicamente** para apoyar la **planificación** del proyecto y la creación de **templates y documentación** dentro de `docs/` (plantillas de PR/commit, tutoriales, issues de referencia, etc.).

El **código de la aplicación** (árbol AVL, WinForms, servicios) fue **desarrollado y revisado por el equipo sin asistencia de IA**. El texto completo figura en la portada de `Services/ArbolEstudiantes.cs` y en `docs/templates/declaracion-ia.md`.

## Licencia y uso académico

Proyecto académico — UDB. Uso según las políticas del curso y la declaración de uso de IA anterior.
