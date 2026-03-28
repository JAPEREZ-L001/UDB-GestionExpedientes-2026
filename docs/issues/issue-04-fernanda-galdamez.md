# Issue #4 — Fernanda Galdámez · Frontend Developer

**Asignada a:** Fernanda Galdámez
**Rama:** `feature/frontend-pantallas-principales`
**Archivos:** `FormPrincipal` · `FormListado` · `FormEliminar` · `FormEstadisticas`

> Esta tarea es **independiente**. Josué publica los stubs el día 1, por lo que puedes conectarte desde el inicio. Para estadísticas, Manuel publica `ReportesService` también con stubs. Usa los mocks incluidos en este issue mientras tanto.

---

## Objetivo

Implementar la pantalla principal con el menú de navegación y los formularios de listado, eliminación y estadísticas, con todos sus controles definidos y conexión al backend.

---

## Descripción

### FormPrincipal — Menú de navegación

**Archivo:** `GestionExpedientes/Forms/FormPrincipal.cs`

Este es el formulario raíz de la aplicación — lo abre `Program.cs`. Contiene un botón por cada funcionalidad y crea la instancia del árbol que se comparte con todos los demás formularios.

#### Controles a colocar en el diseñador de VS

| Control | Tipo | Name | Text / Propiedades adicionales |
|---------|------|------|-------------------------------|
| Título | `Label` | `lblTitulo` | Text = `"SISTEMA DE EXPEDIENTES ACADÉMICOS — UDB"`, Font = Bold |
| Botón insertar | `Button` | `btnInsertar` | Text = `"1. Insertar nuevo estudiante"` |
| Botón buscar | `Button` | `btnBuscar` | Text = `"2. Buscar estudiante por carnet"` |
| Botón eliminar | `Button` | `btnEliminar` | Text = `"3. Eliminar estudiante"` |
| Botón listar | `Button` | `btnListar` | Text = `"4. Listar todos los estudiantes"` |
| Botón estadísticas | `Button` | `btnEstadisticas` | Text = `"5. Estadísticas del árbol"` |
| Botón salir | `Button` | `btnSalir` | Text = `"6. Salir"` |

#### Instancia compartida del árbol

```csharp
// Campo en FormPrincipal.cs — el árbol se crea aquí y se pasa a todos los formularios
private ArbolEstudiantes _arbol = new ArbolEstudiantes();
private ReportesService _reportes;

public FormPrincipal()
{
    InitializeComponent();
    _reportes = new ReportesService(_arbol);
}
```

#### Comportamiento de cada botón

```csharp
private void btnInsertar_Click(object sender, EventArgs e)
{
    new FormRegistro(_arbol).ShowDialog();
}

private void btnBuscar_Click(object sender, EventArgs e)
{
    new FormBusqueda(_arbol).ShowDialog();
}

private void btnEliminar_Click(object sender, EventArgs e)
{
    new FormEliminar(_arbol).ShowDialog();
}

private void btnListar_Click(object sender, EventArgs e)
{
    new FormListado(_arbol).ShowDialog();
}

private void btnEstadisticas_Click(object sender, EventArgs e)
{
    new FormEstadisticas(_arbol, _reportes).ShowDialog();
}

private void btnSalir_Click(object sender, EventArgs e)
{
    Application.Exit();
}
```

---

### FormListado — Listar estudiantes ordenados

**Archivo:** `GestionExpedientes/Forms/FormListado.cs`

#### Controles a colocar en el diseñador de VS

| Control | Tipo | Name | Text / Propiedades adicionales |
|---------|------|------|-------------------------------|
| Título | `Label` | `lblTitulo` | Text = `"Listado de Estudiantes"`, Font = Bold |
| Tabla de datos | `DataGridView` | `dgvEstudiantes` | ReadOnly = `true`; columnas: `Carnet`, `Carrera`, `Promedio`, `Créditos`; AutoSizeColumnsMode = `Fill` |
| Botón actualizar | `Button` | `btnActualizar` | Text = `"Actualizar"` |
| Botón volver | `Button` | `btnVolver` | Text = `"Volver"` |

#### Comportamiento

```csharp
private ArbolEstudiantes _arbol;

public FormListado(ArbolEstudiantes arbol)
{
    InitializeComponent();
    _arbol = arbol;
}

private void FormListado_Load(object sender, EventArgs e)
{
    CargarListado();
}

private void btnActualizar_Click(object sender, EventArgs e)
{
    CargarListado();
}

private void CargarListado()
{
    List<Estudiante> lista = _arbol.ListarInOrden();
    dgvEstudiantes.Rows.Clear();

    if (lista.Count == 0)
    {
        // Puedes mostrar un label de "sin resultados" si lo agregas como control
        return;
    }

    foreach (var est in lista)
    {
        dgvEstudiantes.Rows.Add(est.Carnet, est.Carrera, est.Promedio.ToString("F2"), est.Creditos);
    }
}

private void btnVolver_Click(object sender, EventArgs e)
{
    this.Close();
}
```

#### Configurar columnas del DataGridView (en el constructor o en Load)

```csharp
// Agregar esto en el constructor, después de InitializeComponent():
dgvEstudiantes.Columns.Add("Carnet",   "Carnet");
dgvEstudiantes.Columns.Add("Carrera",  "Carrera");
dgvEstudiantes.Columns.Add("Promedio", "Promedio");
dgvEstudiantes.Columns.Add("Creditos", "Créditos");
```

#### Mock para trabajar antes de que el árbol esté listo

```csharp
private List<Estudiante> ListarMock()
{
    return new List<Estudiante>
    {
        new Estudiante { Carnet = 2023001, Carrera = "ISC", Promedio = 8.5, Creditos = 120 },
        new Estudiante { Carnet = 2023002, Carrera = "IMA", Promedio = 7.0, Creditos = 90 },
        new Estudiante { Carnet = 2023003, Carrera = "ISC", Promedio = 9.1, Creditos = 140 },
    };
}
```

---

### FormEliminar — Eliminar estudiante por carnet

**Archivo:** `GestionExpedientes/Forms/FormEliminar.cs`

#### Controles a colocar en el diseñador de VS

| Control | Tipo | Name | Text / Propiedades adicionales |
|---------|------|------|-------------------------------|
| Título | `Label` | `lblTitulo` | Text = `"Eliminar Estudiante"`, Font = Bold |
| Etiqueta carnet | `Label` | `lblCarnet` | Text = `"Carnet a eliminar:"` |
| Campo carnet | `TextBox` | `txtCarnet` | MaxLength = `10` |
| Botón eliminar | `Button` | `btnEliminar` | Text = `"Eliminar"` |
| Botón volver | `Button` | `btnVolver` | Text = `"Volver"` |
| Mensaje de estado | `Label` | `lblMensaje` | Text = `""` |

#### Comportamiento

```csharp
private ArbolEstudiantes _arbol;

public FormEliminar(ArbolEstudiantes arbol)
{
    InitializeComponent();
    _arbol = arbol;
}

private void btnEliminar_Click(object sender, EventArgs e)
{
    if (!int.TryParse(txtCarnet.Text, out int carnet) || carnet <= 0)
    {
        lblMensaje.ForeColor = Color.Red;
        lblMensaje.Text = "Ingrese un carnet válido.";
        return;
    }

    try
    {
        _arbol.Eliminar(carnet);
        lblMensaje.ForeColor = Color.Green;
        lblMensaje.Text = $"Estudiante {carnet} eliminado correctamente.";
        txtCarnet.Clear();
    }
    catch (ArgumentException ex)
    {
        lblMensaje.ForeColor = Color.Red;
        lblMensaje.Text = ex.Message;
    }
}

private void btnVolver_Click(object sender, EventArgs e)
{
    this.Close();
}
```

---

### FormEstadisticas — Estadísticas del árbol

**Archivo:** `GestionExpedientes/Forms/FormEstadisticas.cs`

#### Controles a colocar en el diseñador de VS

| Control | Tipo | Name | Text / Propiedades adicionales |
|---------|------|------|-------------------------------|
| Título | `Label` | `lblTitulo` | Text = `"Estadísticas del Árbol"`, Font = Bold |
| "Total de estudiantes:" | `Label` | `lblTotalTitulo` | Text = `"Total de estudiantes:"` |
| Valor total | `Label` | `lblTotalValor` | Text = `"0"` |
| "Altura del árbol:" | `Label` | `lblAlturaTitulo` | Text = `"Altura del árbol:"` |
| Valor altura | `Label` | `lblAlturaValor` | Text = `"0"` |
| "Estudiantes por carrera:" | `Label` | `lblCarrerasTitulo` | Text = `"Estudiantes por carrera:"` |
| Tabla por carrera | `DataGridView` | `dgvCarreras` | ReadOnly = `true`; columnas: `Carrera`, `Cantidad`; AutoSizeColumnsMode = `Fill` |
| Botón volver | `Button` | `btnVolver` | Text = `"Volver"` |

#### Comportamiento

```csharp
private ArbolEstudiantes _arbol;
private ReportesService _reportes;

public FormEstadisticas(ArbolEstudiantes arbol, ReportesService reportes)
{
    InitializeComponent();
    _arbol = arbol;
    _reportes = reportes;

    dgvCarreras.Columns.Add("Carrera",  "Carrera");
    dgvCarreras.Columns.Add("Cantidad", "Cantidad");
}

private void FormEstadisticas_Load(object sender, EventArgs e)
{
    CargarEstadisticas();
}

private void CargarEstadisticas()
{
    lblTotalValor.Text  = _arbol.ContarEstudiantes().ToString();
    lblAlturaValor.Text = _arbol.AlturaArbol().ToString();

    dgvCarreras.Rows.Clear();
    Dictionary<string, int> stats = _reportes.EstadisticasPorCarrera();
    foreach (var kvp in stats)
    {
        dgvCarreras.Rows.Add(kvp.Key, kvp.Value);
    }
}

private void btnVolver_Click(object sender, EventArgs e)
{
    this.Close();
}
```

#### Mock para trabajar antes de que `ReportesService` esté listo

```csharp
private Dictionary<string, int> EstadisticasMock()
{
    return new Dictionary<string, int>
    {
        { "ISC", 3 },
        { "IMA", 2 },
        { "IME", 1 }
    };
}
```

---

## Criterios de Aceptación

- [ ] `FormPrincipal` abre correctamente cada formulario al presionar cada botón
- [ ] `btnSalir` en `FormPrincipal` cierra la aplicación
- [ ] `FormListado` muestra los estudiantes ordenados ascendentemente por carnet
- [ ] `FormListado` con árbol vacío no lanza excepción (tabla vacía o mensaje)
- [ ] `FormEliminar` valida que el carnet sea un número antes de llamar a `Eliminar()`
- [ ] `FormEliminar` muestra mensaje de error si el carnet no existe
- [ ] `FormEstadisticas` muestra total, altura y tabla por carrera
- [ ] `FormEstadisticas` con árbol vacío muestra 0 en total y altura, tabla vacía
- [ ] Los 3 archivos de cada formulario (`.cs`, `.Designer.cs`, `.resx`) están en el commit
- [ ] El PR documenta las pruebas manuales realizadas

---

## Pruebas Manuales (documentar en el PR)

| Caso | Acción | Resultado esperado |
|------|--------|--------------------|
| Menú funcional | Presionar cada botón del menú | Abre el formulario correcto con `ShowDialog()` |
| Salir | Presionar "Salir" | La aplicación se cierra |
| Listado vacío | Abrir `FormListado` sin insertar estudiantes | Tabla vacía, sin excepción |
| Listado con datos | Insertar 3 estudiantes y abrir `FormListado` | Muestra los 3 ordenados por carnet |
| Actualizar listado | Insertar 1 más y presionar "Actualizar" | Aparece el nuevo estudiante |
| Eliminar existente | Eliminar carnet 2023001 (que existe) | Mensaje verde de confirmación |
| Eliminar no existente | Eliminar carnet 9999999 | Mensaje rojo de error |
| Estadísticas con datos | 3 ISC y 2 IMA insertados | Total = 5, tabla muestra ISC:3, IMA:2 |
| Estadísticas vacío | Sin inserciones | Total = 0, altura = 0, tabla vacía |

---

## Entregables

| Archivo | Descripción |
|---------|-------------|
| `Forms/FormPrincipal.cs` / `.Designer.cs` / `.resx` | Menú principal con navegación |
| `Forms/FormListado.cs` / `.Designer.cs` / `.resx` | Listado con `DataGridView` |
| `Forms/FormEliminar.cs` / `.Designer.cs` / `.resx` | Eliminación con validación |
| `Forms/FormEstadisticas.cs` / `.Designer.cs` / `.resx` | Estadísticas con tabla y labels |
| Prueba manual en el PR | Tabla de casos probados |

---

## Notas

- No hacer merge propio. Abrir PR hacia `develop` y esperar aprobación de Josué.
- Los 3 archivos de cada formulario (`.cs`, `.Designer.cs`, `.resx`) deben incluirse en el commit — VS los genera automáticamente.
- Coordinar con Khaterine para usar los mismos colores, fuentes y tamaño de botones en todos los formularios.
- `FormPrincipal` es el formulario raíz — `Program.cs` debe quedar así: `Application.Run(new FormPrincipal());`

---

## Declaración de Uso de IA (en el PR)

```
## Declaración de uso de IA
- Herramienta utilizada: [Claude / Copilot / Gemini / etc.]
- Qué se generó o apoyó con IA: [descripción breve]
- Revisión humana aplicada: [Sí/No + comentario]
```
