# Sistema de Gestión de Expedientes Académicos

Proyecto de laboratorio — Programación de Estructuras de Datos, UDB 2026.

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
- Árbol AVL como estructura de datos principal

## Cómo abrir el proyecto

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/JAPEREZ-L001/UDB-GestionExpedientes-2026.git
   ```
2. Abrir `GestionExpedientes.sln` en Visual Studio 2022.
3. Presionar `F5` para compilar y ejecutar.

## Estructura del proyecto

```
GestionExpedientes/
├── Models/
│   ├── Estudiante.cs        — Clase de dominio
│   └── NodoArbol.cs         — Nodo del árbol AVL
├── Services/
│   ├── ArbolEstudiantes.cs  — Árbol AVL completo
│   └── ReportesService.cs   — Estadísticas y reportes
└── Forms/
    ├── FormPrincipal.cs     — Menú principal
    ├── FormRegistro.cs      — Registrar estudiante
    ├── FormBusqueda.cs      — Buscar por carnet
    ├── FormListado.cs       — Listado ordenado
    ├── FormEliminar.cs      — Eliminar estudiante
    └── FormEstadisticas.cs  — Estadísticas del árbol
```

## Flujo de trabajo

- Rama `main`: código estable para entrega
- Rama `develop`: integración del equipo
- Ramas `feature/*`: desarrollo individual
- Todos los PRs van a `develop` y son revisados por Josué
