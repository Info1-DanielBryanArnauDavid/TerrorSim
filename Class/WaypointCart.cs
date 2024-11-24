using System; // Importa el espacio de nombres para funciones básicas
using System.Collections.Generic; // Importa clases para colecciones genéricas
using System.Linq; // Importa clases para LINQ
using System.Text; // Importa clases para manipulación de texto
using System.Threading.Tasks; // Importa clases para tareas asíncronas

namespace Class // Define el espacio de nombres de la clase
{
    public class WaypointCart // Clase que representa un punto en un espacio cartesiano
    {
        private double x; // Coordenada X del punto
        private double y; // Coordenada Y del punto

        public WaypointCart(double x, double y) // Constructor que inicializa las coordenadas del punto
        {
            this.x = x; // Establece la coordenada X
            this.y = y; // Establece la coordenada Y
        }

        // Métodos para obtener las coordenadas X e Y
        public double GetX() { return x; }
        public double GetY() { return y; }

        // Métodos para establecer las coordenadas X e Y
        public void SetX(double x) { this.x = x; }
        public void SetY(double y) { this.y = y; }

        // Calcula la distancia entre este punto y otro WaypointCart usando la fórmula de distancia euclidiana
        public double DistanceTo(WaypointCart other)
        {
            double dx = this.x - other.x; // Diferencia en X
            double dy = this.y - other.y; // Diferencia en Y
            return Math.Sqrt(dx * dx + dy * dy); // Retorna la distancia calculada
        }

        // Mueve el punto según los desplazamientos dados (dx, dy)
        public void Move(double dx, double dy)
        {
            this.x += dx; // Actualiza la coordenada X
            this.y += dy; // Actualiza la coordenada Y
        }
    }
}