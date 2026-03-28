// =============================================
// EXAMEN DE LABORATORIO - ESTRUCTURAS DE DATOS
// Curso: Programación con Estructuras de Datos — PED104 — G01L
// Integrantes: PL250205; CM250371; SG250348; HG251382
// (Josué Pérez; Manuel Cáceres; Katherinne Salazar; Fernanda Hernández Galdámez)
// Fecha de entrega: 24 de marzo de 2026
// Tipo de Árbol Implementado: AVL (estructura principal en ArbolEstudiantes)
// Declaración IA: igual que en Program.cs / ArbolEstudiantes.cs (Copilot solo planificación y docs/templates).
// =============================================

namespace GestionExpedientes.Models
{
    /// <summary>
    /// Estudiante del expediente académico (clave de búsqueda: carnet).
    /// </summary>
    public class Estudiante
    {
        private int _carnet;
        private string _carrera;
        private double _promedio;
        private int _creditos;

        public int Carnet
        {
            get { return _carnet; }
            set { _carnet = value; }
        }

        public string Carrera
        {
            get { return _carrera; }
            set { _carrera = value; }
        }

        public double Promedio
        {
            get { return _promedio; }
            set { _promedio = value; }
        }

        public int Creditos
        {
            get { return _creditos; }
            set { _creditos = value; }
        }
    }
}
