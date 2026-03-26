using GestionExpedientes.Models;
using GestionExpedientes.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GestionExpedientes.Forms
{
    public partial class FormListado : Form
    {
        private readonly ArbolEstudiantes _arbol;

        public FormListado(ArbolEstudiantes arbol)
        {
            InitializeComponent();
            _arbol = arbol;
            dgvEstudiantes.Columns.Add("Carnet", "Carnet");
            dgvEstudiantes.Columns.Add("Carrera", "Carrera");
            dgvEstudiantes.Columns.Add("Promedio", "Promedio");
            dgvEstudiantes.Columns.Add("Creditos", "Créditos");
        }

        private void FormListado_Load(object sender, EventArgs e)
        {
            CargarListado();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarListado();
        }
        private void CargarListado()
        {
            List<Estudiante> lista = ListarMock();
            dgvEstudiantes.Rows.Clear();

            if (lista.Count == 0)
            {
                return;
            }
            foreach (var est in lista)
            {
                dgvEstudiantes.Rows.Add(est.Carnet, est.Carrera, est.Promedio.ToString("F2"), est.Creditos);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private List<Estudiante> ListarMock()
        {
            return new List<Estudiante>
    {
        new Estudiante { Carnet = 2023001, Carrera = "ISC", Promedio = 8.5, Creditos = 120 },
        new Estudiante { Carnet = 2023002, Carrera = "IMA", Promedio = 7.0, Creditos = 90 },
        new Estudiante { Carnet = 2023003, Carrera = "ISC", Promedio = 9.1, Creditos = 140 },
        new Estudiante { Carnet = 2023004, Carrera = "IMA", Promedio = 10, Creditos = 155 },
            };
        }
    }
}
