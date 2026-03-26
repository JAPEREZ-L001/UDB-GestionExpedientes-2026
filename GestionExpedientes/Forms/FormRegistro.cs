using GestionExpedientes.Models;
using GestionExpedientes.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Validación de campos
            if (string.IsNullOrWhiteSpace(txtCarnet.Text))
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "El carnet es obligatorio.";
                return;
            }
            if (!int.TryParse(txtCarnet.Text, out int carnet) || carnet <= 0)
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "El carnet debe ser un número positivo.";
                return;
            }
            if (cmbCarrera.SelectedIndex == -1)
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "Seleccione una carrera.";
                return;
            }
            if (!double.TryParse(txtPromedio.Text, out double promedio) || promedio < 0 || promedio > 10)
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "El promedio debe estar entre 0.0 y 10.0.";
                return;
            }
            if (!int.TryParse(txtCreditos.Text, out int creditos) || creditos < 0)
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "Los créditos deben ser un número entero mayor o igual a 0.";
                return;
            }

            //Crear el objeto
            try
            {
                var est = new Estudiante
                {
                    Carnet = carnet,
                    Carrera = cmbCarrera.SelectedItem.ToString(),
                    Promedio = promedio,
                    Creditos = creditos
                };
                _arbol.Insertar(est);
                lblMensaje.ForeColor = Color.Green;
                lblMensaje.Text = "Estudiante registrado correctamente.";
                LimpiarCampos();
            }
            catch (ArgumentException ex)
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = ex.Message;
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarCampos()
        {
            txtCarnet.Clear();
            cmbCarrera.SelectedIndex = -1;
            txtPromedio.Clear();
            txtCreditos.Clear();
            lblMensaje.Text = "";
        }

    }
}
