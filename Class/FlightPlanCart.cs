using System; // Importa el espacio de nombres para funciones básicas
using System.Collections; // Importa clases para colecciones no genéricas
using System.Collections.Generic; // Importa clases para colecciones genéricas
using System.Linq; // Importa clases para LINQ
using System.Text; // Importa clases para manipulación de texto
using System.Threading.Tasks; // Importa clases para tareas asíncronas

namespace Class // Define el espacio de nombres de la clase
{
    public class FlightPlanCart // Clase que representa un plan de vuelo
    {
        private string flightNumber; // Número del vuelo
        private WaypointCart origin; // Punto de origen del vuelo
        private WaypointCart destination; // Punto de destino del vuelo
        private double distance; // Distancia entre origen y destino
        private double speed; // Velocidad del vuelo
        private WaypointCart plane; // Posición actual del avión

        public FlightPlanCart(string flightNumber, WaypointCart origin, WaypointCart destination, double speed) // Constructor de la clase
        {
            this.flightNumber = flightNumber; // Inicializa el número de vuelo
            this.origin = origin; // Inicializa el origen
            this.destination = destination; // Inicializa el destino
            this.distance = origin.DistanceTo(destination); // Calcula la distancia entre origen y destino
            this.speed = speed; // Inicializa la velocidad
            this.plane = new WaypointCart(origin.GetX(), origin.GetY()); // Establece la posición inicial del avión en el origen
        }

        public string GetFlightNumber() { return flightNumber; } // Devuelve el número de vuelo
        public WaypointCart GetOrigin() { return origin; } // Devuelve el punto de origen
        public WaypointCart GetDestination() { return destination; } // Devuelve el punto de destino
        public double GetDistance() { return distance; } // Devuelve la distancia total del vuelo
        public double GetSpeed() { return speed; } // Devuelve la velocidad del vuelo
        public void SetSpeed(double speed) { this.speed = speed; } // Establece la velocidad del vuelo
        public void SetOrigin(WaypointCart origin) { this.origin = origin; } // Establece un nuevo origen
        public void SetDestination(WaypointCart destination) { this.destination = destination; } // Establece un nuevo destino
        public WaypointCart GetPlanePosition() { return plane; } // Devuelve la posición actual del avión
        public void SetPlanePosition(WaypointCart newPosition) { this.plane = newPosition; } // Establece una nueva posición para el avión

        public double GetAngle() // Calcula y devuelve el ángulo hacia el destino
        {
            double x = destination.GetX() - origin.GetX(); // Diferencia en X entre destino y origen
            double y = destination.GetY() - origin.GetY(); // Diferencia en Y entre destino y origen
            return Math.Atan2(y, x); // Retorna el ángulo en radianes usando atan2 para evitar problemas con los cuadrantes
        }

        public void Restart() // Reinicia la posición del avión al origen
        {
            this.plane = new WaypointCart(origin.GetX(), origin.GetY());
        }

        public bool HasArrived() // Verifica si el avión ha llegado a su destino
        {
            return this.plane.GetX() == this.destination.GetX() && this.plane.GetY() == this.destination.GetY();
        }

        public void MovePlane(double dx, double dy) // Mueve el avión según los desplazamientos dados (dx, dy)
        {
            double newX = plane.GetX() + dx;
            double newY = plane.GetY() + dy;

            // Verifica si la nueva posición sobrepasa el destino
            if (new WaypointCart(newX, newY).DistanceTo(origin) > origin.DistanceTo(destination))
            {
                plane.SetX(destination.GetX());  // Si se sobrepasa, ajusta a la posición del destino 
                plane.SetY(destination.GetY());
            }
            else
            {
                plane.Move(dx, dy);  // Si no se sobrepasa, mueve normalmente 
            }
        }

        public static double Distance(FlightPlanCart plan) // Método estático que calcula la distancia de un plan de vuelo a su destino
        {
            return plan.GetOrigin().DistanceTo(plan.GetDestination());
        }
    }
}