using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using GestionExpedientes.Models;
using GestionExpedientes.Services;

namespace GestionExpedientes.Forms
{
    /// <summary>
    /// Opción 7 del desafío: comparación conceptual y medición simple AVL vs búsqueda lineal.
    /// Usa estructuras temporales; no modifica el árbol de la aplicación principal.
    /// </summary>
    public partial class FormCompararRendimiento : Form
    {
        private const int CantidadInserciones = 4000;
        private const int Busquedas = 2000;

        public FormCompararRendimiento()
        {
            InitializeComponent();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = "Ejecutando…";
            Application.DoEvents();

            var rnd = new Random(42);
            var arbol = new ArbolEstudiantes();
            var lista = new List<Estudiante>(CantidadInserciones);

            for (int i = 1; i <= CantidadInserciones; i++)
            {
                var est = new Estudiante
                {
                    Carnet = 2000000 + i,
                    Carrera = "ISC",
                    Promedio = 7.5,
                    Creditos = 100
                };
                arbol.Insertar(est);
                lista.Add(est);
            }

            int altura = arbol.AlturaArbol();
            int n = arbol.ContarEstudiantes();

            var swArbol = Stopwatch.StartNew();
            for (int k = 0; k < Busquedas; k++)
            {
                int objetivo = 2000001 + rnd.Next(0, CantidadInserciones);
                arbol.Buscar(objetivo);
            }
            swArbol.Stop();

            var swLineal = Stopwatch.StartNew();
            for (int k = 0; k < Busquedas; k++)
            {
                int objetivo = 2000001 + rnd.Next(0, CantidadInserciones);
                BusquedaLineal(lista, objetivo);
            }
            swLineal.Stop();

            lblResultado.Text =
                $"Datos: {n} estudiantes insertados en secuencia (carnets consecutivos).{Environment.NewLine}" +
                $"Altura del AVL tras inserciones: {altura} (típicamente O(log n)).{Environment.NewLine}{Environment.NewLine}" +
                $"Tiempo total {Busquedas} búsquedas en árbol AVL: {swArbol.ElapsedMilliseconds} ms{Environment.NewLine}" +
                $"Tiempo total {Busquedas} búsquedas lineales en lista: {swLineal.ElapsedMilliseconds} ms{Environment.NewLine}{Environment.NewLine}" +
                "Un ABB sin balanceo con claves ordenadas se degrada a altura ~n (lista); " +
                "la búsqueda pasaría a comportarse como O(n) por operación. El AVL evita esa degradación.";
        }

        private static Estudiante BusquedaLineal(List<Estudiante> lista, int carnet)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Carnet == carnet)
                    return lista[i];
            }
            return null;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
