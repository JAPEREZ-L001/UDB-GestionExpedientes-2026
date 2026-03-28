# Sistema de Gestión de Expedientes Académicos

Proyecto de laboratorio — Programación de Estructuras de Datos, **Universidad Don Bosco**, 2026.

## Repositorio

**GitHub:** [https://github.com/JAPEREZ-L001/UDB-GestionExpedientes-2026](https://github.com/JAPEREZ-L001/UDB-GestionExpedientes-2026)

- Rama **`main`**: versión estable para revisión y entrega.
- Rama **`develop`**: integración continua del equipo (PRs).

## Equipo

| Miembro           | Rol             |
|-------------------|-----------------|
| Josué López       | Líder / Backend |
| Manuel Cáceres    | Backend         |
| Khaterine Salazar | Frontend        |
| Fernanda Galdámez | Frontend        |

## Stack

- C# / .NET Framework 4.7.2
- Windows Forms (WinForms)
- Árbol **AVL** (inserción, eliminación con balanceo, búsqueda O(log n))
- Servicio de reportes: estadísticas por carrera y resumen del árbol

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
│   ├── ArbolEstudiantes.cs  — Árbol AVL: insertar, buscar, eliminar, listar in-orden, altura, conteo
│   └── ReportesService.cs   — Estadísticas por carrera y resumen (total | altura)
└── Forms/
    ├── FormPrincipal.cs     — Menú principal
    ├── FormRegistro.cs      — Registrar estudiante
    ├── FormBusqueda.cs      — Buscar por carnet
    ├── FormListado.cs       — Listado ordenado por carnet
    ├── FormEliminar.cs      — Eliminar por carnet
    └── FormEstadisticas.cs  — Totales, altura y tabla por carrera
```

## Documentación del curso

En el repositorio, carpeta `docs/`:

- `docs/init/Desafio_2_lab_PED.md` — Enunciado del desafío
- `docs/init/Plan_de_Trabajo_Equipo.md` — Plan y convenciones del equipo
- `docs/issues/` — Issues por miembro

## Flujo de trabajo (equipo)

- Las ramas **`feature/*`** se integran en **`develop`** mediante Pull Requests.
- La rama **`main`** concentra la versión acordada para entrega o revisión final (según acuerdo del líder).

## Licencia y uso académico

Proyecto académico — UDB. Uso según las políticas del curso y la declaración de uso de IA indicada en la documentación del equipo.
