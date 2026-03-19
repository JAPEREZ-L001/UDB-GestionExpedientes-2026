using System;
using System.Windows.Forms;
using GestionExpedientes.Services;

namespace GestionExpedientes.Forms
{
    public partial class FormRegistro : Form
    {
        private readonly ArbolEstudiantes _arbol;

        public FormRegistro(ArbolEstudiantes arbol)
        {
            InitializeComponent();
            _arbol = arbol;
        }
    }
}
