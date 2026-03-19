using System;
using System.Windows.Forms;
using GestionExpedientes.Services;

namespace GestionExpedientes.Forms
{
    public partial class FormEliminar : Form
    {
        private readonly ArbolEstudiantes _arbol;

        public FormEliminar(ArbolEstudiantes arbol)
        {
            InitializeComponent();
            _arbol = arbol;
        }
    }
}
