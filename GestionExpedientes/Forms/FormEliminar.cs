using GestionExpedientes.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCarnet.Text, out int carnet) || carnet <= 0)
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "Ingrese un carnet válido.";
                return;
            }

            try
            {
                _arbol.Eliminar(carnet);
                lblMensaje.ForeColor = Color.Green;
                lblMensaje.Text = $"Estudiante {carnet} eliminado correctamente.";
                txtCarnet.Clear();
            }
            catch (ArgumentException ex)
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = ex.Message;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
