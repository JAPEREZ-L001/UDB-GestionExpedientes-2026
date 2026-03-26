# Issue #2 — Manuel Cáceres · Backend Developer

**Asignado a:** Manuel Cáceres
**Rama:** `feature/backend-reportes`
**Archivo principal:** `GestionExpedientes/Services/ReportesService.cs`

> Esta tarea es **completamente independiente** del Issue #1. Manuel trabaja en su propio archivo desde el día 1. No es necesario esperar a que Josué termine el árbol para comenzar.

---

## Objetivo

Implementar `ReportesService.cs` — una clase de servicio que consulta el árbol de estudiantes y genera estadísticas y reportes. Al trabajar en un archivo separado, esta tarea no genera conflictos con el trabajo de Josué.

---

## Descripción

### 1. Crear `ReportesService.cs` desde el día 1

Josué creará el archivo vacío con el namespace correcto. Manuel debe tomar ese archivo y completarlo con la implementación real.

**Firma completa de la clase:**

```csharp
// Services/ReportesService.cs
using System;
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

        // Retorna un diccionario con la cantidad de estudiantes por carrera
        // Ejemplo: { "ISC": 5, "IMA": 3, "IME": 2 }
        public Dictionary<string, int> EstadisticasPorCarrera()
        {
            throw new NotImplementedException();
        }

        // Retorna un texto con el resumen del árbol
        // Ejemplo: "Total: 10 estudiantes | Altura: 4"
        public string ResumenArbol()
        {
            throw new NotImplementedException();
        }
    }
}
```

---

### 2. Implementación de `EstadisticasPorCarrera()`

Lógica esperada:
1. Llamar a `_arbol.ListarInOrden()` para obtener todos los estudiantes
2. Recorrer la lista y agrupar por el campo `Carrera`
3. Retornar el diccionario con el conteo

```csharp
// Ejemplo del resultado esperado con 3 ISC y 2 IMA:
// { "ISC": 3, "IMA": 2 }
```

**Firmas de métodos que consumes del árbol:**
```csharp
// Desde ArbolEstudiantes.cs (Josué)
List<Estudiante> ListarInOrden()    // retorna lista ordenada por carnet
int ContarEstudiantes()             // retorna total de nodos
int AlturaArbol()                   // retorna altura del árbol
```

---

### 3. Implementación de `ResumenArbol()`

Lógica esperada:
1. Llamar a `_arbol.ContarEstudiantes()` para obtener el total
2. Llamar a `_arbol.AlturaArbol()` para obtener la altura
3. Retornar una cadena formateada

```csharp
// Ejemplo del resultado:
// "Total: 10 estudiantes | Altura: 4"
```

---

### 4. Cómo trabajar de forma independiente desde el día 1

Mientras los métodos de `ArbolEstudiantes` sean stubs (retornan vacío o 0), `ReportesService` funcionará pero retornará resultados vacíos. Esto es correcto y esperado — el sistema no falla.

Para probar tu código antes de que Josué termine, usa datos simulados:

```csharp
// En FormEstadisticas.cs (Fernanda), para pruebas antes de integrar:
private List<Estudiante> ObtenerDatosMock()
{
    return new List<Estudiante>
    {
        new Estudiante { Carnet = 2023001, Carrera = "ISC", Promedio = 8.5, Creditos = 120 },
        new Estudiante { Carnet = 2023002, Carrera = "IMA", Promedio = 7.0, Creditos = 90 },
        new Estudiante { Carnet = 2023003, Carrera = "ISC", Promedio = 9.0, Creditos = 140 },
    };
}
```

---

### 5. Cómo se usa `ReportesService` desde el frontend

Fernanda consumirá `ReportesService` en `FormEstadisticas`. Este es el contrato que debe respetar:

```csharp
// En FormEstadisticas.cs:
private ReportesService _reportes;

// Al abrir el formulario (se pasa el árbol desde FormPrincipal):
_reportes = new ReportesService(arbol);

// Para llenar los labels y la tabla:
lblTotalValor.Text = arbol.ContarEstudiantes().ToString();
lblAlturaValor.Text = arbol.AlturaArbol().ToString();

Dictionary<string, int> stats = _reportes.EstadisticasPorCarrera();
// stats se carga en dgvCarreras
```

---

## Criterios de Aceptación

- [ ] `ReportesService.cs` compila sin errores desde el día 1
- [ ] `EstadisticasPorCarrera()` retorna el conteo correcto agrupado por carrera
- [ ] `EstadisticasPorCarrera()` retorna diccionario vacío si el árbol está vacío (sin lanzar excepción)
- [ ] `ResumenArbol()` retorna el string con el formato correcto: `"Total: X estudiantes | Altura: Y"`
- [ ] El código no lanza excepciones no controladas con árbol vacío
- [ ] El PR documenta las pruebas manuales realizadas

---

## Pruebas Manuales (documentar en el PR)

| Caso | Datos de entrada | Resultado esperado |
|------|------------------|--------------------|
| Árbol con 3 ISC y 2 IMA | Insertar 5 estudiantes con esas carreras | `{ "ISC": 3, "IMA": 2 }` |
| Árbol vacío | Sin inserciones | Diccionario vacío, sin excepción |
| ResumenArbol con 10 estudiantes y altura 4 | Árbol con 10 nodos | `"Total: 10 estudiantes | Altura: 4"` |
| Carrera nueva no vista antes | Insertar un ICC | `{ ..., "ICC": 1 }` |

---

## Entregables

| Archivo | Descripción |
|---------|-------------|
| `Services/ReportesService.cs` | Clase con `EstadisticasPorCarrera()` y `ResumenArbol()` implementados |
| Prueba manual en el PR | Tabla de casos probados con resultados |

---

## Notas

- No modificar `ArbolEstudiantes.cs` — ese archivo es responsabilidad de Josué.
- Si necesitas un método adicional del árbol que no está en los contratos, comunicarlo a Josué con tiempo.
- Seguir los estándares de código: `PascalCase` para métodos, `camelCase` para variables locales, `_camelCase` para campos privados.

---

## Declaración de Uso de IA (en el PR)

```
## Declaración de uso de IA
- Herramienta utilizada: [Claude / Copilot / Gemini / etc.]
- Qué se generó o apoyó con IA: [descripción breve]
- Revisión humana aplicada: [Sí/No + comentario]
```

---

## Actualización de Coordinación (2026-03-26)

Se agrega esta actualización para alinear el trabajo de backend-reportes con los cambios recientes integrados en `develop`:

- `FormEstadisticas` ya se encuentra integrado con `ReportesService` para consumir `EstadisticasPorCarrera()` en la carga de la tabla por carrera.
- El método `EstadisticasPorCarrera()` ya existe en `Services/ReportesService.cs` y está siendo utilizado por frontend.
- Para cierre completo del issue, mantener como pendiente explícito `ResumenArbol()` con el formato definido: `"Total: X estudiantes | Altura: Y"`.

### Implicación para la rama `feature/backend-reportes`

- Continuar el desarrollo sobre la versión actual de `develop`.
- Evitar romper el contrato consumido por frontend:
  - `Dictionary<string, int> EstadisticasPorCarrera()`
- Completar y validar `ResumenArbol()` como parte del entregable final del issue.

### Estado verificado en código (2026-03-26)

Verificación directa en `GestionExpedientes/Services/ReportesService.cs`:

- `EstadisticasPorCarrera()` está implementado.
- La implementación actual:
  - consume `_arbol.ListarInOrden()`,
  - agrupa por `Carrera`,
  - y retorna `Dictionary<string, int>` (case-insensitive con `StringComparer.OrdinalIgnoreCase`).

Pendiente funcional para completar el issue:

- Implementar `ResumenArbol()` según criterio: `"Total: X estudiantes | Altura: Y"`.
