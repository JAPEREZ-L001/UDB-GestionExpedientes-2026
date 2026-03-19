# Ejemplo: Un día de trabajo completo

Este archivo muestra cómo se vería el flujo real de Khaterine trabajando en `FormRegistro`. Úsalo como referencia para comparar con lo que tú estás haciendo.

---

## 1. Khaterine crea su carpeta en `work/`

Crea la carpeta:
```
docs/work/2026-03-19_frontend-registro-busqueda/
```

Dentro crea `notas.md` (usando la plantilla en `docs/templates/notas-work.md`):

```markdown
# Notas — frontend-registro-busqueda
**Fecha:** 2026-03-19
**Feature:** FormRegistro + FormBusqueda

## Objetivo del día
Implementar FormRegistro con todos los controles y validaciones.

## Qué hice
- Coloqué los controles según la tabla del issue #3
- Implementé la validación de carnet (solo números, no vacío)
- Conecté btnRegistrar con _arbol.Insertar()

## Qué falta
- Validar rango de promedio (0–10)
- Probar con carnet duplicado

## Bloqueos
Ninguno por ahora. Los stubs de Josué ya están disponibles.
```

---

## 2. Khaterine trabaja en el código

Edita `Forms/FormRegistro.cs` en Visual Studio. Cuando termina un bloque lógico, hace commit:

```bash
git add GestionExpedientes/Forms/FormRegistro.cs
git commit -m "feat: agregar controles y layout de FormRegistro"
```

Luego implementa las validaciones:

```bash
git add GestionExpedientes/Forms/FormRegistro.cs
git commit -m "feat: agregar validaciones de carnet y promedio en FormRegistro"
```

Conecta el botón con el backend:

```bash
git add GestionExpedientes/Forms/FormRegistro.cs
git commit -m "feat: conectar btnRegistrar con ArbolEstudiantes.Insertar"
```

> Nota: commits pequeños y frecuentes. No un solo commit gigante al final.

---

## 3. Antes de abrir el PR, actualiza con develop

```bash
git checkout develop
git pull origin develop
git checkout feature/frontend-registro-busqueda
git merge develop
git push
```

---

## 4. Khaterine abre el PR en GitHub

Usa la plantilla de `docs/templates/pull-request.md`. El PR queda así:

```
Título: feat: implementar FormRegistro con validaciones

## Qué hace este PR
Agrega el formulario de registro de estudiantes con todos los controles
definidos en el issue #3. Incluye validaciones y conexión con Insertar().

## Issue relacionado
Resuelve Issue #3 (Khaterine Salazar — Frontend)

## Cambios principales
- [x] Forms/FormRegistro.cs — controles, validaciones, evento btnRegistrar
- [x] Forms/FormRegistro.Designer.cs — generado por VS
- [x] Forms/FormRegistro.resx — generado por VS

## Pruebas manuales
| Caso              | Entrada              | Esperado                          | Obtenido  |
|-------------------|----------------------|-----------------------------------|-----------|
| Registro válido   | 2023001, ISC, 8.5, 120 | Mensaje verde de éxito          | Correcto  |
| Carnet vacío      | Campo vacío          | Mensaje rojo "El carnet es..."   | Correcto  |
| Promedio fuera    | 11.5                 | Mensaje rojo de rango            | Correcto  |
| Carnet duplicado  | 2023001 (ya existe)  | Mensaje rojo de error            | Correcto  |

## Declaración de uso de IA
- Herramienta: GitHub Copilot
- Qué generó: el esqueleto del event handler btnRegistrar_Click
- Revisión humana: Sí — se ajustaron los mensajes de error y se agregó validación de promedio

## Checklist
- [x] Compila sin errores
- [x] Pruebas manuales realizadas
- [x] Sin archivos bin/ obj/ .vs/
- [x] git pull origin develop antes del PR
```

---

## 5. Josué revisa y pide un cambio

Josué comenta en el PR:

> "El mensaje de error cuando el carnet ya existe debería decir el número de carnet, ej: 'El carnet 2023001 ya está registrado'."

Khaterine aplica el cambio:

```bash
# edita FormRegistro.cs con el mensaje correcto
git add GestionExpedientes/Forms/FormRegistro.cs
git commit -m "fix: mejorar mensaje de error en carnet duplicado"
git push
```

Responde en el PR: *"Cambio aplicado."*

---

## 6. Josué aprueba y hace merge

El código de Khaterine queda en `develop`. Khaterine actualiza su rama local:

```bash
git checkout develop
git pull origin develop
```

---

## Lo que quedó en `work/` al final

```
docs/work/2026-03-19_frontend-registro-busqueda/
└── notas.md     ← progreso, bloqueos, decisiones del día
```

Eso es todo. La carpeta `work/` no se entrega — es solo para ella.
