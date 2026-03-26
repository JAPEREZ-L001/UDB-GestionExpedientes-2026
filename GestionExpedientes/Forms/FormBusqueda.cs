using GestionExpedientes.Models;
using GestionExpedientes.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCarnet.Text, out int carnet) || carnet <= 0)
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "Ingrese un carnet válido.";
                LimpiarResultado();
                return;
            }

            Estudiante resultado = _arbol.Buscar(carnet);

            if (resultado == null)
            {
                lblMensaje.ForeColor = Color.OrangeRed;
                lblMensaje.Text = "Estudiante no encontrado.";
                LimpiarResultado();
            }
            else
            {
                lblMensaje.Text = "";
                lblResCarnet.Text = resultado.Carnet.ToString();
                lblResCarrera.Text = resultado.Carrera;
                lblResPromedio.Text = resultado.Promedio.ToString("F2");
                lblResCreditos.Text = resultado.Creditos.ToString();
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

            txtCarnet.Clear();
            lblMensaje.Text = "";
            LimpiarResultado();
        }
        private void LimpiarResultado()
        {
            lblResCarnet.Text = "—";
            lblResCarrera.Text = "—";
            lblResPromedio.Text = "—";
            lblResCreditos.Text = "—";
        }


    }
}
