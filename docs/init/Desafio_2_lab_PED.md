Universidad Don Bosco
Facultad de Ingeniería
Programación con estructura de datos

**Segundo Desafío Práctico**
Sistema de Gestión de Pedidos - Restaurante Express

---

**INSTRUCCIONES GENERALES**

Duración: 5 dias

Fecha de defensa: (24 de marzo del 2026)

Formato: Grupos de máximo 3 estudiantes

Entrega: Proyecto comprimido (.zip) + PDF en aula virtual

Contenidos autorizados: Guías 6 y 7

---

ENUNCIADO

SISTEMA DE GESTIÓN DE EXPEDIENTES ACADÉMICOS

1. Planteamiento del Problema

La Universidad Don Bosco necesita un sistema para gestionar los expedientes académicos de sus estudiantes. Actualmente, los registros se manejan en listas desordenadas, lo que provoca que las búsquedas de estudiantes sean lentas y poco eficientes.

Se le ha contratado para desarrollar un prototipo de sistema de gestión de expedientes que permita organizar a los estudiantes por su número de carnet (valor numérico único). El sistema debe ser capaz de:

- Registrar nuevos estudiantes con su información básica.
- Buscar estudiantes por número de carnet de forma rápida.
- Eliminar estudiantes que hayan egresado o se hayan retirado.
- Listar estudiantes en orden ascendente por carnet.
- Generar reportes estadísticos sobre la distribución de estudiantes.

Requerimiento especial: El director de registro académico ha notado que las búsquedas se vuelven lentas cuando se insertan carnets consecutivos (ej: 2023001, 2023002, 2023003...). Necesita una solución que mantenga la eficiencia incluso en estos casos críticos.

2. Información del Estudiante

Complete la siguiente información en la parte superior del código:

```
// =============================================
// EXAMEN DE LABORATORIO - ESTRUCTURAS DE DATOS
// =============================================
// Estudiante: [Nombre completo]
// Carnet: [Número de carnet]
// Fecha: [Fecha de entrega]
// Tipo de Árbol Implementado: [ABB / AVL / Otro(especificar)]
// =============================================
```

---

3. Especificaciones Técnicas

3.1 Clase Estudiante

Debe crear una clase Estudiante con los siguientes atributos:

| Atributo | Tipo   | Descripción                                        |
|----------|--------|----------------------------------------------------|
| Carnet   | int    | Número único de identificación (valor de búsqueda) |
| Carrera  | string | Carrera que cursa (ISC, IME, IMA, etc.)            |
| Promedio | double | Promedio acumulado                                 |
| Creditos | int    | Número de créditos aprobados                       |

3.2 Clase NodoArbol

Debe crear una clase NodoArbol que contenga:

- Un objeto de tipo Estudiante
- Punteros a hijo izquierdo y derecho
- (Para AVL) Factor de balance o altura

3.3 Clase ArbolEstudiantes

Debe implementar una clase ArbolEstudiantes que contenga los métodos:

| Método                   | Descripción                                       |
|--------------------------|---------------------------------------------------|
| Insertar(Estudiante est) | Agrega un nuevo estudiante al árbol por su carnet |
| Buscar(int carnet)       | Retorna el estudiante encontrado o null           |
| Eliminar(int carnet)     | Elimina un estudiante del árbol                   |
| ListarInOrden()          | Retorna lista de estudiantes ordenados por carnet |
| AlturaArbol()            | Retorna la altura total del árbol                 |
| ContarEstudiantes()      | Retorna la cantidad total de estudiantes          |
| EstadisticasPorCarrera() | Retorna conteo de estudiantes por carrera         |

3.4 Interfaz de Usuario

Debe crear una aplicación con las siguientes opciones:

```
=========================================
SISTEMA DE EXPEDIENTES ACADÉMICOS - UDB
=========================================
1. Insertar nuevo estudiante
2. Buscar estudiante por carnet
3. Eliminar estudiante
4. Listar todos los estudiantes (ordenados)
5. Mostrar estadísticas del árbol
6. Visualizar árbol (opcional - gráfico)
7. Comparar rendimiento (opcional)
8. Salir
=========================================
Seleccione una opción:
```

---

4. Indicaciones según Contenidos de las Guías

Si implementa la solución usando Árbol Binario de Búsqueda (ABB) estándar:

| Aspecto     | Indicación                                                                                                        |
|-------------|-------------------------------------------------------------------------------------------------------------------|
| Inserción   | Implemente inserción recursiva comparando por número de carnet. Los menores a la izquierda, mayores a la derecha. |
| Eliminación | Implemente los 3 casos: nodo hoja, nodo con un hijo, nodo con dos hijos.                                          |
| Recorrido   | Use In-Orden para listar estudiantes ordenados por carnet.                                                        |

Si implementa la solución usando Árbol AVL (recomendado para mejor rendimiento):

| Aspecto                  | Indicación                                                                 |
|--------------------------|----------------------------------------------------------------------------|
| Factor de Balanceo       | Cada nodo debe almacenar su altura. Calcule FB = altura(izq) - altura(der) |
| Rotaciones               | Implemente las 4 rotaciones: RSI, RSD, RDI, RDD según corresponda         |
| Eliminación con Balanceo | Elimine como en ABB, luego verifique y corrija balance hacia arriba        |

Aplicando Otros Tipos de Árboles

Otras opciones para mejorar el rendimiento, puede implementar:

**Árbol Roji-Negro (Red-Black Tree)**

| Aspecto        | Descripción                                                                    |
|----------------|--------------------------------------------------------------------------------|
| Concepto       | Árbol binario balanceado donde cada nodo tiene un color (rojo/negro)           |
| Ventaja        | Menos rotaciones que AVL, más eficiente en inserciones y eliminaciones         |
| Implementación | Requiere manejo de colores y casos de rebalanceo (tío rojo/negro)              |

**Árbol-B (B-Tree)**

| Aspecto        | Descripción                                                             |
|----------------|-------------------------------------------------------------------------|
| Concepto       | Árbol de búsqueda donde cada nodo puede tener M hijos y M-1 claves     |
| Ventaja        | Ideal para gran volumen de datos, menor altura                          |
| Implementación | Cada nodo contiene múltiples carnets y punteros a hijos                 |

Portada del código

```
// =============================================
// EXAMEN DE LABORATORIO - ESTRUCTURAS DE DATOS
// =============================================
// Título: Sistema de Gestión de Expedientes
// Tipo de Árbol: [ABB / AVL / Roji-Negro / Árbol-B]
// Justificación: [Breve explicación de por qué eligió
// este tipo de árbol para el problema]
// declaración uso de IA
// =============================================
```

---

Bonus (10 puntos extra)

Implemente una función de visualización gráfica del árbol que muestre:

- La estructura jerárquica (nodos y conexiones)
- El factor de balanceo de cada nodo (si es AVL)
- El color de cada nodo (si es Roji-Negro)
- Los múltiples valores por nodo (si es Árbol-B)

---

**RÚBRICA DE EVALUACIÓN**

| CRITERIO | DESTACADO (9-10) | COMPETENTE (7-8) | BÁSICO (6-0) |
|----------|------------------|------------------|--------------|
| IMPLEMENTACIÓN DEL ÁRBOL | Implementa correctamente la estructura del árbol elegido (ABB, AVL u otro). Nodos con todos los atributos necesarios. Punteros manejados sin errores. Clase Estudiante completa con encapsulamiento al 100% | Implementa el árbol pero con errores menores en la estructura de nodos o en el manejo de punteros. Clase Estudiante básica funcional todo en un 80% | Implementación incorrecta o incompleta del árbol. Nodos mal definidos. Clase Estudiante ausente o muy deficiente funcional en menos del 80% |
| OPERACIONES FUNDAMENTALES | Inserta, busca, elimina y lista estudiantes correctamente en todos los casos. Eliminación maneja los 3 casos (hoja, 1 hijo, 2 hijos). Búsqueda eficiente y con mensajes claros. Funciona en un 100% | Las operaciones funcionan pero fallan en casos específicos (ej: eliminación de nodo con 2 hijos). Búsqueda básica sin mensajes claros. Funciona en un 80% | Una o más operaciones no funcionan o funcionan incorrectamente. Errores graves en la lógica. Funciona en menos del 80% |
| MANEJO DE CASOS DEGRADANTES | El sistema mantiene eficiencia (O(log n)) incluso con inserciones consecutivas (1,2,3,4,5,6,7). Altura del árbol se mantiene baja. Demuestra claramente la ventaja del árbol balanceado. Funciona en un 100% | El sistema funciona pero se degrada parcialmente con secuencias ordenadas. Altura crece más de lo esperado pero aún funcional. Funciona en un 80% | El árbol se convierte en una lista lineal. Búsquedas se vuelven lentas (O(n)). No hay evidencia de balanceo. Funciona en menos del 80% |
| IMPLEMENTACIÓN DE CARACTERÍSTICAS ESPECIALES (SEGÚN TIPO DE ÁRBOL) | [Para AVL]: Calcula y muestra FB correctamente en un 100%. Implementa las 4 rotaciones. Detecta automáticamente cuándo aplicarlas. [Para otros]: Implementa todas las características propias del árbol elegido correctamente. | Implementa algunas rotaciones pero no todas. FB se calcula pero no se actualiza correctamente. O características parciales del árbol elegido. | No implementa las características especiales del árbol elegido. FB ausente o incorrecto. Rotaciones no implementadas. |
| INTERFAZ Y DOCUMENTACIÓN | Menú completo e intuitivo. Manejo de errores con try-catch. Mensajes claros al usuario. Código comentado en secciones clave. Variables con nombres descriptivos. Incluye portada requerida. Contesta correctamente todas las preguntas en un 100% | Menú funcional pero básico. Manejo de errores mínimo. Código con pocos comentarios. Portada incompleta. Contesta correctamente todas las preguntas en un 80% | Interfaz confusa o inexistente. Sin manejo de errores. Código sin comentarios, ilegible. Sin portada. Contesta menos del 80% |
