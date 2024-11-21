using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    public class FlightPlanList
    {
        private List<FlightPlanCart> flights;

        public FlightPlanList()
        {
            flights = new List<FlightPlanCart>();
        }

        public int AddFlightPlan(FlightPlanCart flightPlan)
        {
            if (flightPlan == null)
                return -1;

            flights.Add(flightPlan);
            return 0;
        }

        public FlightPlanCart GetFlightPlanCart(int index)
        {
            if (index < 0 || index >= flights.Count)
                return null;

            return flights[index];
        }

        public List<FlightPlanCart> GetFlightPlans()
        {
            List<FlightPlanCart> planes = new List<FlightPlanCart>();

            for (int i = 0; i < this.GetNumber(); i++)
            {
                planes.Add(GetFlightPlanCart(i));
            }
            return planes;
        }

        public int GetNumber()
        {
            return flights.Count;
        }

        public bool CheckSecurityDistance(FlightPlanCart flightToCheck, int securityDistance)
        {
            foreach (FlightPlanCart otherFlight in flights)
            {
                // Skip comparing the flight with itself
                if (flightToCheck.GetFlightNumber() == otherFlight.GetFlightNumber())
                    continue;

                double distance = flightToCheck.GetPlanePosition().DistanceTo(otherFlight.GetPlanePosition());
                if (distance < 2 * securityDistance - 1)
                    return true;
            }
            return false;
        }

        public double OptimalVelocity(FlightPlanCart flight1, FlightPlanCart flight2, int securityDistance)
        {
            const int MAX_ITERATIONS = 5;
            const double CONVERGENCE_THRESHOLD = 0.1; // m/s
            double currentSpeed = flight2.GetSpeed();
            double lastSpeed = double.MaxValue;

            for (int iteration = 0; iteration < MAX_ITERATIONS; iteration++)
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