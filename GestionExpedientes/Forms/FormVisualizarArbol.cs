using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GestionExpedientes.Models;
using GestionExpedientes.Services;

namespace GestionExpedientes.Forms
{
    /// <summary>
    /// Bonus / opción 6 del desafío: visualización gráfica con factor de balance (AVL).
    /// </summary>
    public partial class FormVisualizarArbol : Form
    {
        private readonly ArbolEstudiantes _arbol;

        public FormVisualizarArbol(ArbolEstudiantes arbol)
        {
            _arbol = arbol;
            InitializeComponent();
            panelArbol.Resize += (s, e) => panelArbol.Invalidate();
        }

        private void FormVisualizarArbol_Load(object sender, EventArgs e)
        {
            lblMensaje.Text = _arbol.ObtenerRaiz() == null
                ? "No hay datos: registre estudiantes para ver el árbol."
                : "Nodos: carnet y FB (factor de balance = h(izq) − h(der)).";
        }

        private void panelArbol_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(panelArbol.BackColor);

            NodoArbol raiz = _arbol.ObtenerRaiz();
            if (raiz == null)
                return;

            float w = Math.Max(100, panelArbol.ClientSize.Width - 40);
            DibujarNodo(g, raiz, 20, 20 + w, 35, _arbol);
        }

        private static void DibujarNodo(Graphics g, NodoArbol n, float minX, float maxX, float y, ArbolEstudiantes arbol)
        {
            if (n == null)
                return;

            float x = (minX + maxX) / 2f;
            float childY = y + 58;
            float leftCx = n.Izquierdo != null ? (minX + x) / 2f : x;
            float rightCx = n.Derecho != null ? (x + maxX) / 2f : x;

            using (var penLinea = new Pen(Color.DimGray, 1.5f))
            {
                if (n.Izquierdo != null)
                {
                    g.DrawLine(penLinea, x, y + 20, leftCx, childY - 20);
                    DibujarNodo(g, n.Izquierdo, minX, x, childY, arbol);
                }

                if (n.Derecho != null)
                {
                    g.DrawLine(penLinea, x, y + 20, rightCx, childY - 20);
                    DibujarNodo(g, n.Derecho, x, maxX, childY, arbol);
                }
            }

            int fb = arbol.ObtenerFactorBalance(n);
            using (var font = new Font("Segoe UI", 8f, FontStyle.Regular))
            using (var brushRelleno = new SolidBrush(Color.LightCyan))
            using (var penBorde = new Pen(Color.DarkBlue, 1.2f))
            {
                const float ancho = 62f;
                const float alto = 40f;
                float left = x - ancho / 2f;
                float top = y - 20f;
                g.FillEllipse(brushRelleno, left, top, ancho, alto);
                g.DrawEllipse(penBorde, left, top, ancho, alto);
                g.DrawString(n.Dato.Carnet.ToString(), font, Brushes.Black, left + 6, top + 4);
                g.DrawString("FB=" + fb, font, Brushes.DarkBlue, left + 6, top + 20);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
