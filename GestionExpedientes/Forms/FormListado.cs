using System;
using System.Windows.Forms;
using GestionExpedientes.Services;

namespace GestionExpedientes.Forms
{
    public partial class FormListado : Form
    {
        private readonly ArbolEstudiantes _arbol;

        public FormListado(ArbolEstudiantes arbol)
        {
            InitializeComponent();
            _arbol = arbol;
        }
    }
}
