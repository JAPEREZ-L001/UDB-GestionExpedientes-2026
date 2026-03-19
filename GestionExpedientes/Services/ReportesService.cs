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
    }
}
