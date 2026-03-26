using GestionExpedientes.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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

            dgvCarreras.Columns.Add("Carrera", "Carrera");
            dgvCarreras.Columns.Add("Cantidad", "Cantidad");
        }

        private void FormEstadisticas_Load(object sender, EventArgs e)
        {
            CargarEstadisticas();
        }

        private void CargarEstadisticas()
        {
            lblTotalValor.Text = _arbol.ContarEstudiantes().ToString();
            lblAlturaValor.Text = _arbol.AlturaArbol().ToString();

            dgvCarreras.Rows.Clear();
            Dictionary<string, int> stats = _reportes.EstadisticasPorCarrera();
            // Dictionary<string, int> stats = EstadisticasMock();

            foreach (var kvp in stats)
            {
                dgvCarreras.Rows.Add(kvp.Key, kvp.Value);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // private Dictionary<string, int> EstadisticasMock()
        // {
        //     return new Dictionary<string, int>
        //     {
        //         { "ISC", 3 },
        //         { "IMA", 2 },
        //         { "IME", 1 }
        //     };
        // }
    }
}
