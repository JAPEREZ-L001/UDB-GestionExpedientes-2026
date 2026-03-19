using System;
using System.Windows.Forms;
using GestionExpedientes.Services;

namespace GestionExpedientes.Forms
{
    public partial class FormEstadisticas : Form
    {
        private readonly ArbolEstudiantes _arbol;
        private readonly ReportesService _reportes;

        public FormEstadisticas(ArbolEstudiantes arbol, ReportesService reportes)
        {
            InitializeComponent();
            _arbol = arbol;
            _reportes = reportes;
        }
    }
}
