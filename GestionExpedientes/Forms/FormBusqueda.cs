using System;
using System.Windows.Forms;
using GestionExpedientes.Services;

namespace GestionExpedientes.Forms
{
    public partial class FormBusqueda : Form
    {
        private readonly ArbolEstudiantes _arbol;

        public FormBusqueda(ArbolEstudiantes arbol)
        {
            InitializeComponent();
            _arbol = arbol;
        }
    }
}
