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

        public Dictionary<string, int> EstadisticasPorCarrera()
        {
            var estudiantes = _arbol.ListarInOrden();
            var stats = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (var estudiante in estudiantes)
            {
                var carrera = string.IsNullOrWhiteSpace(estudiante.Carrera) ? "SIN_CARRERA" : estudiante.Carrera.Trim();
                if (!stats.ContainsKey(carrera))
                {
                    stats[carrera] = 0;
                }

                stats[carrera]++;
            }

            return stats;
        }
    }
}
