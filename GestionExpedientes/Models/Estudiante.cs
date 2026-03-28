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
