// =============================================
// EXAMEN DE LABORATORIO - ESTRUCTURAS DE DATOS
// =============================================
// Curso: Programación con Estructuras de Datos — PED104 — G01L
// Universidad Don Bosco — 2026
// Integrantes:
//   - Josué Adonaí Pérez López — PL250205 (Líder / Backend)
//   - Manuel Enrique Cáceres Mejía — CM250371 (Backend)
//   - Katherinne Ayleen Salazar Guerra — SG250348 (Frontend)
//   - Fernanda Guadalupe Hernández Galdámez — HG251382 (Frontend)
// Fecha de entrega: 24 de marzo de 2026
// Tipo de Árbol Implementado: AVL
// ---------------------------------------------
// Título: Sistema de Gestión de Expedientes Académicos — UDB
// Tipo de Árbol: AVL
// Justificación: ver portada extendida en Services/ArbolEstudiantes.cs
// Declaración uso de IA: GitHub Copilot ayudó exclusivamente a la planificación y a los templates en docs/;
// el código fuente lo desarrolló y revisó el equipo (detalle en Services/ArbolEstudiantes.cs).
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
