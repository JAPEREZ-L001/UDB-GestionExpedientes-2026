using System;
using System.Windows.Forms;
using GestionExpedientes.Services;

namespace GestionExpedientes.Forms
{
    public partial class FormPrincipal : Form
    {
        private ArbolEstudiantes _arbol = new ArbolEstudiantes();
        private ReportesService _reportes;

        public FormPrincipal()
        {
            InitializeComponent();
            _reportes = new ReportesService(_arbol);
        }
    }
}
