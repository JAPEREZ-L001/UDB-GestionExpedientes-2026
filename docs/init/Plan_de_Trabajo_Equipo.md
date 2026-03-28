# Plan de Trabajo — Sistema de Gestión de Expedientes Académicos

**Proyecto:** Sistema de Gestión de Expedientes Académicos — UDB
**Repositorio:** `UDB-GestionExpedientes-2026`
**Curso:** Programación con Estructuras de Datos — **PED104 — G01L**
**Líder:** Josué Adonaí Pérez López (PL250205)
**Equipo:** Manuel Enrique Cáceres Mejía (CM250371) · Katherinne Ayleen Salazar Guerra (SG250348) · Fernanda Guadalupe Hernández Galdámez (HG251382)
**Stack:** C# · .NET Framework 4.7.2 · WinForms · Git · GitHub
**Fecha de entrega:** 24 de marzo de 2026

---

## ¿Por dónde empiezo?

**Paso 1 — Lee tu issue.** Tiene todo lo que necesitas hacer: controles, métodos, código de ejemplo y criterios de aceptación.

| Miembro | Carnet | Tu issue |
|---------|--------|----------|
| Josué Adonaí Pérez López | PL250205 | [`issues/issue-01-josue-lopez.md`](../issues/issue-01-josue-lopez.md) |
| Manuel Enrique Cáceres Mejía | CM250371 | [`issues/issue-02-manuel-caceres.md`](../issues/issue-02-manuel-caceres.md) |
| Katherinne Ayleen Salazar Guerra | SG250348 | [`issues/issue-03-khaterine-salazar.md`](../issues/issue-03-khaterine-salazar.md) |
| Fernanda Guadalupe Hernández Galdámez | HG251382 | [`issues/issue-04-fernanda-galdamez.md`](../issues/issue-04-fernanda-galdamez.md) |

**Paso 2 — Configura Git y clona el repo.** Si es tu primera vez: [`tutorials/01-git-desde-cero.md`](../tutorials/01-git-desde-cero.md)

**Paso 3 — Trabaja en tu rama.** Guarda notas en `docs/work/`. Cuando termines, abre un PR usando [`templates/pull-request.md`](../templates/pull-request.md)

**Paso 4 — ¿Algo no te sale?** Revisa [`tutorials/02-problemas-git.md`](../tutorials/02-problemas-git.md) o el ejemplo completo en [`examples/flujo-completo-ejemplo.md`](../examples/flujo-completo-ejemplo.md)

---

## Mapa de la documentación

```
docs/
├── init/
│   ├── Plan_de_Trabajo_Equipo.md   ← estás aquí
│   └── Desafio_2_lab_PED.md        ← enunciado original del desafío
│
├── issues/                          ← tu trabajo está aquí
│   ├── issue-01-josue-lopez.md
│   ├── issue-02-manuel-caceres.md
│   ├── issue-03-khaterine-salazar.md
│   └── issue-04-fernanda-galdamez.md
│
├── tutorials/                       ← si no sabes cómo hacer algo
│   ├── 01-git-desde-cero.md
│   ├── 02-problemas-git.md
│   ├── 03-pr-en-github.md
│   ├── 04-declaracion-ia.md
│   └── 05-como-leer-la-doc.md
│
├── templates/                       ← copia y pega, solo rellena
│   ├── commit.md
│   ├── pull-request.md
│   ├── declaracion-ia.md
│   └── notas-work.md
│
├── examples/                        ← cómo se ve un día de trabajo real
│   └── flujo-completo-ejemplo.md
│
└── work/                            ← tu espacio libre para ensuciarte
    └── README.md
```

---

## Arquitectura del proyecto

```
UDB-GestionExpedientes-2026/
├── .gitignore
├── README.md
├── GestionExpedientes.sln
└── GestionExpedientes/
    ├── GestionExpedientes.csproj
    ├── Program.cs
    ├── Properties/AssemblyInfo.cs
    ├── Models/
    │   ├── Estudiante.cs
    │   └── NodoArbol.cs
    ├── Services/
    │   ├── ArbolEstudiantes.cs      ← Josué
    │   └── ReportesService.cs       ← Manuel
    └── Forms/
        ├── FormPrincipal.cs/.Designer.cs/.resx   ← Fernanda
        ├── FormRegistro.cs/.Designer.cs/.resx    ← Khaterine
        ├── FormBusqueda.cs/.Designer.cs/.resx    ← Khaterine
        ├── FormListado.cs/.Designer.cs/.resx     ← Fernanda
        ├── FormEliminar.cs/.Designer.cs/.resx    ← Fernanda
        └── FormEstadisticas.cs/.Designer.cs/.resx ← Fernanda
```

> Cada form genera 3 archivos automáticamente — los 3 van al repositorio.
> `bin/`, `obj/`, `.vs/` nunca van al repositorio (están en `.gitignore`).

---

## Ramas de trabajo

```
main
└── develop
    ├── feature/backend-arquitectura-base      (Josué)
    ├── feature/backend-reportes               (Manuel)
    ├── feature/frontend-registro-busqueda     (Khaterine)
    └── feature/frontend-pantallas-principales (Fernanda)
```

| Rama        | Quién puede hacer merge      |
|-------------|------------------------------|
| `main`      | Solo Josué (entrega final)   |
| `develop`   | Josué, vía PR aprobado       |
| `feature/*` | Cada desarrollador           |

---

## Contratos de interfaz (lo que el frontend consume)

### `ArbolEstudiantes.cs` — Josué

```csharp
public void Insertar(Estudiante est)
public Estudiante Buscar(int carnet)       // null si no existe
public void Eliminar(int carnet)
public List<Estudiante> ListarInOrden()
public int AlturaArbol()
public int ContarEstudiantes()
```

### `ReportesService.cs` — Manuel

```csharp
public Dictionary<string, int> EstadisticasPorCarrera()  // { "ISC": 5, "IMA": 3 }
public string ResumenArbol()                              // "Total: 10 | Altura: 4"
```

> Si necesitas cambiar una firma, avisa a Josué o Manuel antes de modificar.

---

## Criterios para que un PR sea aprobado

- [ ] Compila sin errores
- [ ] Funcionalidad del issue implementada
- [ ] Pruebas manuales realizadas
- [ ] Sin `bin/`, `obj/`, `.vs/` en el commit
- [ ] Declaración de IA incluida (aunque sea "No usé IA")

---

## Entrega final

| Elemento     | Detalle                                                        |
|--------------|----------------------------------------------------------------|
| Formato      | Proyecto `.zip` + PDF en aula virtual                          |
| Repositorio  | `UDB-GestionExpedientes-2026` en GitHub con historial de PRs   |
| Fecha límite | **24 de marzo de 2026**                                        |
| Portada      | Nombre del equipo, tipo de árbol usado, justificación, IA      |

---

*Versión 4.0 — documento hub, enlaza a toda la documentación del proyecto*
