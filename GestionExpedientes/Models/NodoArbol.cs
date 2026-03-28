namespace GestionExpedientes.Models
{
    public class NodoArbol
    {
        public Estudiante Dato { get; set; }
        public NodoArbol Izquierdo { get; set; }
        public NodoArbol Derecho { get; set; }
        public int Altura { get; set; }

        public NodoArbol(Estudiante dato)
        {
            Dato = dato;
            Izquierdo = null;
            Derecho = null;
            Altura = 1;
        }
    }
}
