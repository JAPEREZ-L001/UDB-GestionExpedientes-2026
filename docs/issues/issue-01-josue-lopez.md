# Issue #1 — Josué López · Líder / Backend

**Asignado a:** Josué López
**Rama:** `feature/backend-arquitectura-base`
**Repositorio:** `UDB-GestionExpedientes-2026`

---

## Objetivo

Crear el repositorio, configurar la solución de Visual Studio con la arquitectura correcta, implementar los modelos base y el árbol AVL completo, y publicar todos los stubs necesarios desde el **día 1** para que el resto del equipo pueda trabajar en paralelo sin esperar.

---

## Descripción

### 1. Setup del repositorio y la solución (día 1 — primero que todo)

**En GitHub:**
1. Crear el repositorio con nombre exacto: `UDB-GestionExpedientes-2026`
2. Inicializarlo con `README.md`
3. Crear la rama `develop` desde `main`
4. Compartir el enlace con el equipo

**En Visual Studio:**
1. Crear nueva solución: `File > New > Project > Windows Forms App (.NET Framework)`
2. Nombre de la solución y proyecto: `GestionExpedientes`
3. Framework: `.NET Framework 4.7.2`
4. Dentro del proyecto, crear manualmente las carpetas: `Models/`, `Services/`, `Forms/`
5. Mover los formularios generados por VS a la carpeta `Forms/`

La estructura resultante debe ser:

```
UDB-GestionExpedientes-2026/
├── .gitignore
├── README.md
├── GestionExpedientes.sln
└── GestionExpedientes/
    ├── GestionExpedientes.csproj
    ├── Program.cs
    ├── app.config
    ├── Properties/
    │   └── AssemblyInfo.cs
    ├── Models/
    │   ├── Estudiante.cs
    │   └── NodoArbol.cs
    ├── Services/
    │   ├── ArbolEstudiantes.cs
    │   └── ReportesService.cs     ← archivo vacío que Manuel llenará
    └── Forms/
        ├── FormPrincipal.cs / .Designer.cs / .resx
        ├── FormRegistro.cs / .Designer.cs / .resx
        ├── FormBusqueda.cs / .Designer.cs / .resx
        ├── FormListado.cs / .Designer.cs / .resx
        ├── FormEliminar.cs / .Designer.cs / .resx
        └── FormEstadisticas.cs / .Designer.cs / .resx
```

**`.gitignore` mínimo:**
```
bin/
obj/
.vs/
*.user
*.suo
*.suo
*.cache
```

---

### 2. Modelos base (día 1 — publicar junto con los stubs)

**`Models/Estudiante.cs`**
```csharp
namespace GestionExpedientes.Models
{
    public class Estudiante
    {
        public int Carnet { get; set; }
        public string Carrera { get; set; }
        public double Promedio { get; set; }
        public int Creditos { get; set; }
    }
}
```

**`Models/NodoArbol.cs`**
```csharp
namespace GestionExpedientes.Models
{
    public class NodoArbol
    {
        public Estudiante Dato { get; set; }
        public NodoArbol Izquierdo { get; set; }
        public NodoArbol Derecho { get; set; }
        public int Altura { get; set; }

        public NodoArbol(Estudiante dato)
        {
            Dato = dato;
            Izquierdo = null;
            Derecho = null;
            Altura = 1;
        }
    }
}
```

---

### 3. Stubs de `ArbolEstudiantes` (día 1 — publicar antes del mediodía)

Publicar estos stubs en `develop` para que Khaterine, Fernanda y Manuel puedan conectarse sin esperar la implementación real:

```csharp
// Services/ArbolEstudiantes.cs
using System.Collections.Generic;
using GestionExpedientes.Models;

namespace GestionExpedientes.Services
{
    public class ArbolEstudiantes
    {
        private NodoArbol _raiz;

        public void Insertar(Estudiante est)        { }
        public Estudiante Buscar(int carnet)        { return null; }
        public void Eliminar(int carnet)            { }
        public List<Estudiante> ListarInOrden()     { return new List<Estudiante>(); }
        public int AlturaArbol()                    { return 0; }
        public int ContarEstudiantes()              { return 0; }
    }
}
```

---

### 4. Implementación del árbol AVL (días 2–4)

Reemplazar los stubs con la lógica real del árbol. Se recomienda **AVL** por el requerimiento de carnets consecutivos.

**Métodos a implementar:**

| Método | Descripción | Complejidad objetivo |
|--------|-------------|---------------------|
| `Insertar(Estudiante est)` | Agrega al árbol por carnet, lanza `ArgumentException` si ya existe | O(log n) |
| `Buscar(int carnet)` | Retorna el estudiante o `null` si no existe | O(log n) |
| `Eliminar(int carnet)` | Elimina el nodo (3 casos), lanza `ArgumentException` si no existe | O(log n) |
| `ListarInOrden()` | Recorrido izq–raíz–der, retorna lista ordenada por carnet | O(n) |
| `AlturaArbol()` | Altura total desde la raíz | O(1) si se guarda en el nodo |
| `ContarEstudiantes()` | Conteo recursivo de todos los nodos | O(n) |

**Para AVL, implementar adicionalmente:**
- `private int ObtenerAltura(NodoArbol nodo)`
- `private int FactorBalance(NodoArbol nodo)`
- `private NodoArbol RotarDerecha(NodoArbol nodo)`
- `private NodoArbol RotarIzquierda(NodoArbol nodo)`
- `private NodoArbol Balancear(NodoArbol nodo)`

**Portada obligatoria del código:**
```csharp
// =============================================
// EXAMEN DE LABORATORIO - ESTRUCTURAS DE DATOS
// =============================================
// Título: Sistema de Gestión de Expedientes
// Tipo de Árbol: AVL
// Justificación: Mantiene balance O(log n) con inserciones consecutivas
// Declaración IA: [Herramienta usada y qué generó]
// =============================================
```

---

### 5. Crear archivo vacío `ReportesService.cs` (día 1)

Crear el archivo con el namespace correcto para que Manuel pueda empezar a trabajar en su rama sin conflictos:

```csharp
// Services/ReportesService.cs
using System.Collections.Generic;
using GestionExpedientes.Models;

namespace GestionExpedientes.Services
{
    public class ReportesService
    {
        private readonly ArbolEstudiantes _arbol;

        public ReportesService(ArbolEstudiantes arbol)
        {
            _arbol = arbol;
        }
    }
}
```

---

### 6. Crear formularios vacíos (día 1)

Crear todos los formularios con nombre correcto para que Khaterine y Fernanda puedan crear sus ramas y trabajar en ellos. Solo deben existir como formularios vacíos en la solución:

- `Forms/FormPrincipal.cs`
- `Forms/FormRegistro.cs`
- `Forms/FormBusqueda.cs`
- `Forms/FormListado.cs`
- `Forms/FormEliminar.cs`
- `Forms/FormEstadisticas.cs`

---

### 7. Responsabilidades de liderazgo

- Revisar y aprobar todos los PRs del equipo hacia `develop`
- Resolver bloqueos técnicos
- Hacer merge de `develop` → `main` como entrega final
- Mantener el repositorio organizado (eliminar ramas fusionadas)

---

## Criterios de Aceptación

- [ ] Repositorio `UDB-GestionExpedientes-2026` creado en GitHub con ramas `main` y `develop`
- [ ] Solución `GestionExpedientes.sln` compila sin errores desde el día 1
- [ ] `Estudiante.cs` y `NodoArbol.cs` con firmas exactas publicadas en `develop`
- [ ] Stubs de `ArbolEstudiantes` publicados antes del mediodía del día 1
- [ ] Archivo `ReportesService.cs` vacío (con namespace) disponible para Manuel
- [ ] Formularios vacíos creados en la solución para Khaterine y Fernanda
- [ ] Árbol AVL implementado completo (Insertar con rotaciones, Buscar, Eliminar 3 casos, ListarInOrden)
- [ ] El árbol mantiene O(log n) con carnets consecutivos (2023001, 2023002, ..., 2023007 → altura ≤ 3)
- [ ] Portada del código incluida con tipo de árbol y justificación
- [ ] PRs del equipo revisados y aprobados
- [ ] Merge final a `main` realizado antes de la entrega

---

## Entregables

| Archivo | Descripción |
|---------|-------------|
| `GestionExpedientes.sln` | Solución con estructura de proyecto correcta |
| `Models/Estudiante.cs` | Clase de dominio con propiedades |
| `Models/NodoArbol.cs` | Nodo con punteros y altura |
| `Services/ArbolEstudiantes.cs` | Árbol AVL completo |
| `Services/ReportesService.cs` | Archivo vacío con namespace (para Manuel) |
| Formularios vacíos | Los 6 formularios creados en la solución |
| `README.md` | Descripción del proyecto e instrucciones |

---

## Declaración de Uso de IA (en el PR)

```
## Declaración de uso de IA
- Herramienta utilizada: [Claude / Copilot / Gemini / etc.]
- Qué se generó o apoyó con IA: [descripción breve]
- Revisión humana aplicada: [Sí/No + comentario]
```
