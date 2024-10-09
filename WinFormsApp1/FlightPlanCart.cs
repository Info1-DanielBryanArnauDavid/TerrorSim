using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class FlightPlanCart
    {
        private string flightNumber;
        private WaypointCart origin;
        private WaypointCart destination;
        private double distance;
        private double speed;
        private WaypointCart plane;

        public FlightPlanCart(string flightNumber, WaypointCart origin, WaypointCart destination, double speed)
        {
            this.flightNumber = flightNumber;
            this.origin = origin;
            this.destination = destination;
            this.distance = origin.DistanceTo(destination);
            this.speed = speed;
            this.plane = new WaypointCart(origin.GetX(), origin.GetY());
        }

        public string GetFlightNumber() { return flightNumber; }
        public WaypointCart GetOrigin() { return origin; }
        public WaypointCart GetDestination() { return destination; }
        public double GetDistance() { return distance; }
        public double GetSpeed() { return speed; }
        public void SetSpeed(double speed) { this.speed = speed; }
        public void SetOrigin(WaypointCart origin) { this.origin = origin; }
        public void SetDestination(WaypointCart destination) { this.destination = destination; }
        public WaypointCart GetPlanePosition() { return plane; }
        public void SetPlanePosition(WaypointCart newPosition) { this.plane = newPosition; }

        public void Restart()
        {
            this.plane = new WaypointCart(origin.GetX(), origin.GetY());
        }

        public bool HasArrived()
        {
            return this.plane.GetX() == this.destination.GetX() && this.plane.GetY() == this.destination.GetY();
        }

        public void MovePlane(double dx, double dy, double time)
        {
            double distanceMoved = Math.Sqrt(dx * dx + dy * dy);
            double actualTime = distanceMoved / speed;
            if (actualTime <= time)
            {
                plane.Move(dx, dy);
            }
            else
            {
                double factor = time / actualTime;
                plane.Move(dx * factor, dy * factor);
            }
        }

        public static double Distance(FlightPlanCart plan)
        {
            return plan.GetOrigin().DistanceTo(plan.GetDestination());
        }
    }
}

