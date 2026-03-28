using System.Collections.Generic;

namespace GestionExpedientes.Services
{
    public class ReportesService
    {
        private readonly ArbolEstudiantes _arbol;

        public ReportesService(ArbolEstudiantes arbol)
        {
            _arbol = arbol;
        }

        public Dictionary<string, int> EstadisticasPorCarrera()
        {
            return _arbol.EstadisticasPorCarrera();
        }

        /// <summary>
        /// Resumen textual del árbol: total de nodos y altura.
        /// Formato acordado: "Total: X estudiantes | Altura: Y"
        /// </summary>
        public string ResumenArbol()
        {
            int total = _arbol.ContarEstudiantes();
            int altura = _arbol.AlturaArbol();
            return $"Total: {total} estudiantes | Altura: {altura}";
        }
    }
}
