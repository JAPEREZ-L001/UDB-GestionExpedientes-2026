# Issue #3 — Khaterine Salazar · Frontend Developer

**Asignada a:** Khaterine Salazar
**Rama:** `feature/frontend-registro-busqueda`
**Archivos:** `GestionExpedientes/Forms/FormRegistro.cs` · `GestionExpedientes/Forms/FormBusqueda.cs`

> Esta tarea es **independiente**. Josué publica los stubs de `ArbolEstudiantes` el día 1, por lo que puedes conectarte desde el inicio. Mientras los stubs estén vacíos, usa los mocks incluidos en este issue.

---

## Objetivo

Implementar los formularios `FormRegistro` y `FormBusqueda` con todos sus controles, validaciones y conexión al backend.

---

## Descripción

### FormRegistro — Registrar nuevo estudiante

**Archivo:** `GestionExpedientes/Forms/FormRegistro.cs`

#### Controles a colocar en el diseñador de VS

| Control | Tipo | Name (propiedad Name en VS) | Text / Propiedades adicionales |
|---------|------|-----------------------------|-------------------------------|
| Título | `Label` | `lblTitulo` | Text = `"Registrar Estudiante"`, Font = Bold |
| Etiqueta carnet | `Label` | `lblCarnet` | Text = `"Carnet:"` |
| Campo carnet | `TextBox` | `txtCarnet` | MaxLength = `10` |
| Etiqueta carrera | `Label` | `lblCarrera` | Text = `"Carrera:"` |
| Lista de carreras | `ComboBox` | `cmbCarrera` | Items: `ISC`, `IME`, `IMA`, `ICC`; DropDownStyle = `DropDownList` |
| Etiqueta promedio | `Label` | `lblPromedio` | Text = `"Promedio:"` |
| Campo promedio | `TextBox` | `txtPromedio` | MaxLength = `5` |
| Etiqueta créditos | `Label` | `lblCreditos` | Text = `"Créditos:"` |
| Campo créditos | `TextBox` | `txtCreditos` | MaxLength = `4` |
| Botón registrar | `Button` | `btnRegistrar` | Text = `"Registrar"` |
| Botón limpiar | `Button` | `btnLimpiar` | Text = `"Limpiar"` |
| Botón volver | `Button` | `btnVolver` | Text = `"Volver"` |
| Mensaje de estado | `Label` | `lblMensaje` | Text = `""` (se asigna en runtime), ForeColor cambia según error/éxito |

#### Comportamiento del botón `btnRegistrar`

```csharp
private void btnRegistrar_Click(object sender, EventArgs e)
{
    // 1. Validar campos
    if (string.IsNullOrWhiteSpace(txtCarnet.Text))
    {
        lblMensaje.ForeColor = Color.Red;
        lblMensaje.Text = "El carnet es obligatorio.";
        return;
    }
    if (!int.TryParse(txtCarnet.Text, out int carnet) || carnet <= 0)
    {
        lblMensaje.ForeColor = Color.Red;
        lblMensaje.Text = "El carnet debe ser un número positivo.";
        return;
    }
    if (cmbCarrera.SelectedIndex == -1)
    {
        lblMensaje.ForeColor = Color.Red;
        lblMensaje.Text = "Seleccione una carrera.";
        return;
    }
    if (!double.TryParse(txtPromedio.Text, out double promedio) || promedio < 0 || promedio > 10)
    {
        lblMensaje.ForeColor = Color.Red;
        lblMensaje.Text = "El promedio debe estar entre 0.0 y 10.0.";
        return;
    }
    if (!int.TryParse(txtCreditos.Text, out int creditos) || creditos < 0)
    {
        lblMensaje.ForeColor = Color.Red;
        lblMensaje.Text = "Los créditos deben ser un número entero mayor o igual a 0.";
        return;
    }

    // 2. Crear el objeto y llamar al backend
    try
    {
        var est = new Estudiante
        {
            Carnet = carnet,
            Carrera = cmbCarrera.SelectedItem.ToString(),
            Promedio = promedio,
            Creditos = creditos
        };
        _arbol.Insertar(est);
        lblMensaje.ForeColor = Color.Green;
        lblMensaje.Text = "Estudiante registrado correctamente.";
        LimpiarCampos();
    }
    catch (ArgumentException ex)
    {
        lblMensaje.ForeColor = Color.Red;
        lblMensaje.Text = ex.Message;
    }
}
```

#### Comportamiento del botón `btnLimpiar`

```csharp
private void btnLimpiar_Click(object sender, EventArgs e)
{
    LimpiarCampos();
}

private void LimpiarCampos()
{
    txtCarnet.Clear();
    cmbCarrera.SelectedIndex = -1;
    txtPromedio.Clear();
    txtCreditos.Clear();
    lblMensaje.Text = "";
}
```

#### Comportamiento del botón `btnVolver`

```csharp
private void btnVolver_Click(object sender, EventArgs e)
{
    this.Close();
}
```

#### Cómo recibe el árbol este formulario

El árbol se pasa desde `FormPrincipal` al abrir el formulario:

```csharp
// En FormRegistro.cs — campo y constructor
private ArbolEstudiantes _arbol;

public FormRegistro(ArbolEstudiantes arbol)
{
    InitializeComponent();
    _arbol = arbol;
}
```

#### Mock para trabajar antes de que el árbol esté listo

```csharp
// Usar temporalmente hasta que _arbol.Insertar() esté implementado
private void InsertarMock(Estudiante est)
{
    // Simula éxito sin hacer nada
    lblMensaje.ForeColor = Color.Green;
    lblMensaje.Text = $"[MOCK] Estudiante {est.Carnet} registrado.";
}
```

---

### FormBusqueda — Buscar estudiante por carnet

**Archivo:** `GestionExpedientes/Forms/FormBusqueda.cs`

#### Controles a colocar en el diseñador de VS

| Control | Tipo | Name | Text / Propiedades adicionales |
|---------|------|------|-------------------------------|
| Título | `Label` | `lblTitulo` | Text = `"Buscar Estudiante"`, Font = Bold |
| Etiqueta carnet | `Label` | `lblCarnet` | Text = `"Carnet:"` |
| Campo de búsqueda | `TextBox` | `txtCarnet` | MaxLength = `10` |
| Botón buscar | `Button` | `btnBuscar` | Text = `"Buscar"` |
| Botón limpiar | `Button` | `btnLimpiar` | Text = `"Limpiar"` |
| Botón volver | `Button` | `btnVolver` | Text = `"Volver"` |
| Contenedor resultado | `GroupBox` | `grpResultado` | Text = `"Datos del Estudiante"` |
| Label carnet resultado | `Label` | `lblResCarnet` | Text = `"—"` |
| Label carrera resultado | `Label` | `lblResCarrera` | Text = `"—"` |
| Label promedio resultado | `Label` | `lblResPromedio` | Text = `"—"` |
| Label créditos resultado | `Label` | `lblResCreditos` | Text = `"—"` |
| Mensaje de estado | `Label` | `lblMensaje` | Text = `""` |

#### Comportamiento del botón `btnBuscar`

```csharp
private void btnBuscar_Click(object sender, EventArgs e)
{
    if (!int.TryParse(txtCarnet.Text, out int carnet) || carnet <= 0)
    {
        lblMensaje.ForeColor = Color.Red;
        lblMensaje.Text = "Ingrese un carnet válido.";
        LimpiarResultado();
        return;
    }

    Estudiante resultado = _arbol.Buscar(carnet);

    if (resultado == null)
    {
        lblMensaje.ForeColor = Color.OrangeRed;
        lblMensaje.Text = "Estudiante no encontrado.";
        LimpiarResultado();
    }
    else
    {
        lblMensaje.Text = "";
        lblResCarnet.Text   = resultado.Carnet.ToString();
        lblResCarrera.Text  = resultado.Carrera;
        lblResPromedio.Text = resultado.Promedio.ToString("F2");
        lblResCreditos.Text = resultado.Creditos.ToString();
    }
}

private void LimpiarResultado()
{
    lblResCarnet.Text   = "—";
    lblResCarrera.Text  = "—";
    lblResPromedio.Text = "—";
    lblResCreditos.Text = "—";
}
```

#### Comportamiento del botón `btnLimpiar`

```csharp
private void btnLimpiar_Click(object sender, EventArgs e)
{
    txtCarnet.Clear();
    lblMensaje.Text = "";
    LimpiarResultado();
}
```

#### Constructor (recibe el árbol desde FormPrincipal)

```csharp
private ArbolEstudiantes _arbol;

public FormBusqueda(ArbolEstudiantes arbol)
{
    InitializeComponent();
    _arbol = arbol;
}
```

#### Mock para trabajar antes de que el árbol esté listo

```csharp
private Estudiante BuscarMock(int carnet)
{
    if (carnet == 2023001)
        return new Estudiante { Carnet = 2023001, Carrera = "ISC", Promedio = 8.5, Creditos = 120 };
    return null;
}
```

---

## Criterios de Aceptación

- [ ] `FormRegistro` compila y abre desde `FormPrincipal` sin errores
- [ ] `FormBusqueda` compila y abre desde `FormPrincipal` sin errores
- [ ] `btnRegistrar` valida todos los campos antes de llamar a `Insertar()`
- [ ] Si el carnet ya existe, `lblMensaje` muestra el error sin lanzar excepción no controlada
- [ ] Si el carnet está vacío o no es número, `lblMensaje` muestra el mensaje correcto
- [ ] `btnBuscar` muestra los datos del estudiante si existe, o "no encontrado" si no
- [ ] `lblResCarnet`, `lblResCarrera`, `lblResPromedio`, `lblResCreditos` se actualizan correctamente
- [ ] `btnLimpiar` resetea todos los campos en ambos formularios
- [ ] `btnVolver` cierra el formulario en ambos casos
- [ ] El PR documenta las pruebas manuales realizadas

---

## Pruebas Manuales (documentar en el PR)

| Caso | Acción | Resultado esperado |
|------|--------|--------------------|
| Registro válido | Carnet 2023001, ISC, 8.5, 120 → Registrar | `lblMensaje` verde: "Estudiante registrado correctamente." |
| Carnet duplicado | Insertar 2023001 de nuevo | `lblMensaje` rojo con mensaje de error |
| Carnet vacío | Campo vacío → Registrar | `lblMensaje` rojo: "El carnet es obligatorio." |
| Promedio inválido | Promedio = 11.5 → Registrar | `lblMensaje` rojo con error de rango |
| Sin carrera | No seleccionar carrera → Registrar | `lblMensaje` rojo: "Seleccione una carrera." |
| Búsqueda exitosa | Buscar 2023001 (ya insertado) | `grpResultado` muestra los datos del estudiante |
| Búsqueda fallida | Buscar 9999999 | `lblMensaje` naranja: "Estudiante no encontrado." |
| Limpiar registro | Presionar Limpiar en FormRegistro | Todos los campos vacíos, `lblMensaje` vacío |

---

## Entregables

| Archivo | Descripción |
|---------|-------------|
| `Forms/FormRegistro.cs` | Formulario de registro con validaciones y conexión al árbol |
| `Forms/FormRegistro.Designer.cs` | Diseño de controles generado por VS |
| `Forms/FormRegistro.resx` | Recurso de formulario generado por VS |
| `Forms/FormBusqueda.cs` | Formulario de búsqueda con visualización de resultado |
| `Forms/FormBusqueda.Designer.cs` | Diseño de controles generado por VS |
| `Forms/FormBusqueda.resx` | Recurso de formulario generado por VS |
| Prueba manual en el PR | Tabla de casos probados |

---

## Notas

- No hacer merge propio. Abrir PR hacia `develop` y esperar aprobación de Josué.
- Los 3 archivos de cada formulario (`.cs`, `.Designer.cs`, `.resx`) deben incluirse en el commit.
- Coordinar con Fernanda para usar los mismos colores, fuentes y tamaño de botones.

---

## Declaración de Uso de IA (en el PR)

```
## Declaración de uso de IA
- Herramienta utilizada: [Claude / Copilot / Gemini / etc.]
- Qué se generó o apoyó con IA: [descripción breve]
- Revisión humana aplicada: [Sí/No + comentario]
```
