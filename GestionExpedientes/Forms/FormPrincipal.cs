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

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            new FormRegistro(_arbol).ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            new FormBusqueda(_arbol).ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            new FormEliminar(_arbol).ShowDialog();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            new FormListado(_arbol).ShowDialog();
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            new FormEstadisticas(_arbol, _reportes).ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
