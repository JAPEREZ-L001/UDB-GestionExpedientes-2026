// =============================================
// EXAMEN DE LABORATORIO - ESTRUCTURAS DE DATOS
// =============================================
// Curso: Programación con Estructuras de Datos — PED104 — G01L
// Integrantes:
//   - Josué Adonaí Pérez López — PL250205
//   - Manuel Enrique Cáceres Mejía — CM250371
//   - Katherinne Ayleen Salazar Guerra — SG250348
//   - Fernanda Guadalupe Hernández Galdámez — HG251382
// Fecha de entrega: 24 de marzo de 2026
// Tipo de Árbol Implementado: AVL
// ---------------------------------------------
// Título: Sistema de Gestión de Expedientes Académicos
// Tipo de Árbol: AVL
// Justificación: Los carnets consecutivos dejan un ABB degenerado en O(n);
// el AVL mantiene altura O(log n) con rotaciones automáticas (RSI, RSD, RDI, RDD).
// Declaración uso de IA: GitHub Copilot ayudó exclusivamente a elaborar la planificación del trabajo
// y los templates/archivos guía dentro de docs/ (p. ej. plantillas, tutoriales, issues de referencia).
// El código de la aplicación (incl. árbol AVL y formularios) fue desarrollado y revisado por el equipo
// sin asistencia de IA.
// =============================================

using System;
using System.Collections.Generic;
using GestionExpedientes.Models;

namespace GestionExpedientes.Services
{
    public class ArbolEstudiantes
    {
        private NodoArbol _raiz;

        /// <summary>
        /// Acceso solo para visualización educativa del árbol (factor de balance, dibujo).
        /// </summary>
        public NodoArbol ObtenerRaiz()
        {
            return _raiz;
        }

        /// <summary>
        /// FB = altura(izq) − altura(der), según guía AVL del desafío.
        /// </summary>
        public int ObtenerFactorBalance(NodoArbol nodo)
        {
            return FactorBalance(nodo);
        }

        /// <summary>
        /// Conteo de estudiantes agrupados por carrera (requisito sección 3.3 del desafío).
        /// </summary>
        public Dictionary<string, int> EstadisticasPorCarrera()
        {
            var estudiantes = ListarInOrden();
            var stats = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (var estudiante in estudiantes)
            {
                var carrera = string.IsNullOrWhiteSpace(estudiante.Carrera)
                    ? "SIN_CARRERA"
                    : estudiante.Carrera.Trim();

                if (!stats.ContainsKey(carrera))
                    stats[carrera] = 0;

                stats[carrera]++;
            }

            return stats;
        }

        public void Insertar(Estudiante est)
        {
            if (Buscar(est.Carnet) != null)
                throw new ArgumentException($"El carnet {est.Carnet} ya está registrado.");

            _raiz = InsertarRecursivo(_raiz, est);
        }

        public Estudiante Buscar(int carnet)
        {
            return BuscarRecursivo(_raiz, carnet);
        }

        public void Eliminar(int carnet)
        {
            if (Buscar(carnet) == null)
                throw new ArgumentException($"El carnet {carnet} no existe en el árbol.");

            _raiz = EliminarRecursivo(_raiz, carnet);
        }

        public List<Estudiante> ListarInOrden()
        {
            var lista = new List<Estudiante>();
            InOrdenRecursivo(_raiz, lista);
            return lista;
        }

        public int AlturaArbol()
        {
            return ObtenerAltura(_raiz);
        }

        public int ContarEstudiantes()
        {
            return ContarRecursivo(_raiz);
        }

        // ============================
        // Métodos privados — AVL core
        // ============================

        private int ObtenerAltura(NodoArbol nodo)
        {
            if (nodo == null) return 0;
            return nodo.Altura;
        }

        private int FactorBalance(NodoArbol nodo)
        {
            if (nodo == null) return 0;
            return ObtenerAltura(nodo.Izquierdo) - ObtenerAltura(nodo.Derecho);
        }

        private void ActualizarAltura(NodoArbol nodo)
        {
            nodo.Altura = 1 + Math.Max(ObtenerAltura(nodo.Izquierdo), ObtenerAltura(nodo.Derecho));
        }

        private NodoArbol RotarDerecha(NodoArbol y)
        {
            NodoArbol x = y.Izquierdo;
            NodoArbol t2 = x.Derecho;

            x.Derecho = y;
            y.Izquierdo = t2;

            ActualizarAltura(y);
            ActualizarAltura(x);

            return x;
        }

        private NodoArbol RotarIzquierda(NodoArbol x)
        {
            NodoArbol y = x.Derecho;
            NodoArbol t2 = y.Izquierdo;

            y.Izquierdo = x;
            x.Derecho = t2;

            ActualizarAltura(x);
            ActualizarAltura(y);

            return y;
        }

        private NodoArbol Balancear(NodoArbol nodo)
        {
            ActualizarAltura(nodo);
            int balance = FactorBalance(nodo);

            // Izquierda-Izquierda
            if (balance > 1 && FactorBalance(nodo.Izquierdo) >= 0)
                return RotarDerecha(nodo);

            // Izquierda-Derecha
            if (balance > 1 && FactorBalance(nodo.Izquierdo) < 0)
            {
                nodo.Izquierdo = RotarIzquierda(nodo.Izquierdo);
                return RotarDerecha(nodo);
            }

            // Derecha-Derecha
            if (balance < -1 && FactorBalance(nodo.Derecho) <= 0)
                return RotarIzquierda(nodo);

            // Derecha-Izquierda
            if (balance < -1 && FactorBalance(nodo.Derecho) > 0)
            {
                nodo.Derecho = RotarDerecha(nodo.Derecho);
                return RotarIzquierda(nodo);
            }

            return nodo;
        }

        // ============================
        // Inserción AVL
        // ============================

        private NodoArbol InsertarRecursivo(NodoArbol nodo, Estudiante est)
        {
            if (nodo == null)
                return new NodoArbol(est);

            if (est.Carnet < nodo.Dato.Carnet)
                nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, est);
            else
                nodo.Derecho = InsertarRecursivo(nodo.Derecho, est);

            return Balancear(nodo);
        }

        // ============================
        // Búsqueda
        // ============================

        private Estudiante BuscarRecursivo(NodoArbol nodo, int carnet)
        {
            if (nodo == null)
                return null;

            if (carnet == nodo.Dato.Carnet)
                return nodo.Dato;

            if (carnet < nodo.Dato.Carnet)
                return BuscarRecursivo(nodo.Izquierdo, carnet);

            return BuscarRecursivo(nodo.Derecho, carnet);
        }

        // ============================
        // Eliminación AVL (3 casos)
        // ============================

        private NodoArbol EliminarRecursivo(NodoArbol nodo, int carnet)
        {
            if (nodo == null)
                return null;

            if (carnet < nodo.Dato.Carnet)
            {
                nodo.Izquierdo = EliminarRecursivo(nodo.Izquierdo, carnet);
            }
            else if (carnet > nodo.Dato.Carnet)
            {
                nodo.Derecho = EliminarRecursivo(nodo.Derecho, carnet);
            }
            else
            {
                // Caso 1: nodo hoja
                if (nodo.Izquierdo == null && nodo.Derecho == null)
                    return null;

                // Caso 2: un solo hijo
                if (nodo.Izquierdo == null)
                    return nodo.Derecho;
                if (nodo.Derecho == null)
                    return nodo.Izquierdo;

                // Caso 3: dos hijos — sucesor inorden (menor del subárbol derecho)
                NodoArbol sucesor = ObtenerMinimo(nodo.Derecho);
                nodo.Dato = sucesor.Dato;
                nodo.Derecho = EliminarRecursivo(nodo.Derecho, sucesor.Dato.Carnet);
            }

            return Balancear(nodo);
        }

        private NodoArbol ObtenerMinimo(NodoArbol nodo)
        {
            while (nodo.Izquierdo != null)
                nodo = nodo.Izquierdo;
            return nodo;
        }

        // ============================
        // Recorridos y conteo
        // ============================

        private void InOrdenRecursivo(NodoArbol nodo, List<Estudiante> lista)
        {
            if (nodo == null) return;
            InOrdenRecursivo(nodo.Izquierdo, lista);
            lista.Add(nodo.Dato);
            InOrdenRecursivo(nodo.Derecho, lista);
        }

        private int ContarRecursivo(NodoArbol nodo)
        {
            if (nodo == null) return 0;
            return 1 + ContarRecursivo(nodo.Izquierdo) + ContarRecursivo(nodo.Derecho);
        }
    }
}
