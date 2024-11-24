using System; // Importa el espacio de nombres para funciones básicas
using System.Collections.Generic; // Importa clases para colecciones genéricas
using System.Linq; // Importa clases para LINQ
using System.Numerics; // Importa clases para operaciones matemáticas avanzadas
using System.Text; // Importa clases para manipulación de texto
using System.Threading.Tasks; // Importa clases para tareas asíncronas

namespace Class // Define el espacio de nombres de la clase
{
    public class FlightPlanList // Clase que representa una lista de planes de vuelo
    {
        private List<FlightPlanCart> flights; // Lista que almacena los planes de vuelo

        public FlightPlanList() // Constructor que inicializa la lista de vuelos
        {
            flights = new List<FlightPlanCart>(); // Crea una nueva lista vacía
        }

        public int AddFlightPlan(FlightPlanCart flightPlan) // Añade un nuevo plan de vuelo a la lista
        {
            if (flightPlan == null) // Verifica si el plan de vuelo es nulo
                return -1; // Retorna -1 si es nulo

            flights.Add(flightPlan); // Agrega el plan de vuelo a la lista
            return 0; // Retorna 0 si se agregó correctamente
        }

        public FlightPlanCart GetFlightPlanCart(int index) // Obtiene un plan de vuelo por su índice
        {
            if (index < 0 || index >= flights.Count) // Verifica si el índice es válido
                return null; // Retorna nulo si el índice es inválido

            return flights[index]; // Retorna el plan de vuelo correspondiente al índice
        }

        public List<FlightPlanCart> GetFlightPlans() // Devuelve todos los planes de vuelo en una lista
        {
            List<FlightPlanCart> planes = new List<FlightPlanCart>(); // Crea una nueva lista para almacenar los planes

            for (int i = 0; i < this.GetNumber(); i++) // Itera sobre los índices válidos
            {
                planes.Add(GetFlightPlanCart(i)); // Agrega cada plan a la nueva lista
            }
            return planes; // Retorna la lista completa de planes de vuelo
        }

        public int GetNumber() // Devuelve el número total de planes de vuelo en la lista
        {
            return flights.Count; // Retorna la cantidad de elementos en la lista
        }

        public bool CheckSecurityDistance(FlightPlanCart flightToCheck, int securityDistance) // Verifica si un vuelo cumple con la distancia de seguridad respecto a otros vuelos
        {
            foreach (FlightPlanCart otherFlight in flights) // Itera sobre todos los vuelos en la lista
            {
                if (flightToCheck.GetFlightNumber() == otherFlight.GetFlightNumber()) // Omite el mismo vuelo
                    continue;

                double distance = flightToCheck.GetPlanePosition().DistanceTo(otherFlight.GetPlanePosition()); // Calcula la distancia entre los aviones
                if (distance < 2 * securityDistance - 1) // Verifica si está dentro del rango de seguridad
                    return true; // Retorna true si hay violación de distancia

            }
            return false; // Retorna false si no hay violaciones encontradas
        }

        public double OptimalVelocity(FlightPlanCart flight1, FlightPlanCart flight2, int securityDistance) // Calcula la velocidad óptima para evitar colisiones entre dos vuelos
        {
            const int MAX_ITERATIONS = 5; // Número máximo de iteraciones para encontrar una solución
            const double CONVERGENCE_THRESHOLD = 0.1; // Umbral para determinar convergencia en m/s

            double currentSpeed = flight2.GetSpeed(); // Velocidad actual del segundo vuelo
            double lastSpeed = double.MaxValue; // Inicializa la última velocidad como máxima posible

            for (int iteration = 0; iteration < MAX_ITERATIONS; iteration++) // Realiza iteraciones hasta alcanzar el máximo permitido
            {
                double rx = flight2.GetPlanePosition().GetX() - flight1.GetPlanePosition().GetX();
                double ry = flight2.GetPlanePosition().GetY() - flight1.GetPlanePosition().GetY();

                double v1x = flight1.GetSpeed() * Math.Cos(flight1.GetAngle());
                double v1y = flight1.GetSpeed() * Math.Sin(flight1.GetAngle());
                double v2x = currentSpeed * Math.Cos(flight2.GetAngle());
                double v2y = currentSpeed * Math.Sin(flight2.GetAngle());

                double vx = v2x - v1x;
                double vy = v2y - v1y;

                double topt = -(rx * vx + ry * vy) / (vx * vx + vy * vy);

                if (topt < 0)
                    return -1;

                double cosangle = Math.Cos(flight2.GetAngle());
                double sinangle = Math.Sin(flight2.GetAngle());

                double alpha = topt * topt;
                double beta = 2 * topt * (rx * cosangle + ry * sinangle - topt * (v1x * cosangle + v1y * sinangle));
                double gamma = topt * topt * (v1x * v1x + v1y * v1y) - 2 * topt * (rx * v1x + ry * v1y) + rx * rx + ry * ry - 4 * securityDistance * securityDistance;

                double discriminant = beta * beta - 4 * alpha * gamma;

                if (discriminant < 0)
                    return -1;

                double newSpeed = (-beta - Math.Sqrt(discriminant)) / (2 * alpha);

                if (newSpeed < 0)
                    return -1;

                if (Math.Abs(newSpeed - currentSpeed) < CONVERGENCE_THRESHOLD)
                    return newSpeed;

                lastSpeed = currentSpeed;
                currentSpeed = newSpeed;

                if (iteration > 0 && Math.Abs(currentSpeed - lastSpeed) > Math.Abs(lastSpeed))
                    return (currentSpeed + lastSpeed) / 2;
            }

            return currentSpeed > 0 ? currentSpeed : -1;
        }
    }
}