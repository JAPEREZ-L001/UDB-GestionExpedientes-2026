// =============================================
// EXAMEN DE LABORATORIO - ESTRUCTURAS DE DATOS
// =============================================
// Título: Sistema de Gestión de Expedientes
// Tipo de Árbol: AVL
// Justificación: Mantiene balance O(log n) con inserciones consecutivas
// Declaración IA: [Herramienta usada y qué generó]
// =============================================

using System;
using System.Collections.Generic;
using GestionExpedientes.Models;

namespace GestionExpedientes.Services
{
    public class ArbolEstudiantes
    {
        private NodoArbol _raiz;

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
