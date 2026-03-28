// =============================================
// EXAMEN DE LABORATORIO - ESTRUCTURAS DE DATOS
// =============================================
// Título: Sistema de Gestión de Expedientes Académicos — UDB
// Tipo de árbol: AVL (implementación en Services/ArbolEstudiantes.cs)
// Equipo: Josué López · Manuel Cáceres · Khaterine Salazar · Fernanda Galdámez
// Declaración IA: ver portada en ArbolEstudiantes.cs y declaración por miembro en el PR
// =============================================

using System;
using System.Windows.Forms;
using GestionExpedientes.Forms;

namespace GestionExpedientes
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormPrincipal());
        }
    }
}
