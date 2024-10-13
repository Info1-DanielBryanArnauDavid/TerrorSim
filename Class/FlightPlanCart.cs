using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    public class FlightPlanCart
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

        public double GetAngle()
        {
            double x = Convert.ToInt32(GetDestination().GetX()) - Convert.ToInt32(GetOrigin().GetX());
            double y = Convert.ToInt32(GetDestination().GetY()) - Convert.ToInt32(GetOrigin().GetY());
            double angle = Math.Atan2(y, x);
            return angle;
        }

        public void Restart()
        {
            this.plane = new WaypointCart(origin.GetX(), origin.GetY());
        }

        public bool HasArrived()
        {
            return this.plane.GetX() == this.destination.GetX() && this.plane.GetY() == this.destination.GetY();
        }

        public void MovePlane(double dx, double dy)
        {
                double newX = plane.GetX() + dx;
                double newY = plane.GetY() + dy;

                // Check if the new position overshoots the destination
                if (new WaypointCart(newX, newY).DistanceTo(destination) > plane.DistanceTo(destination))
                {
                    // If it overshoots, snap to the destination
                    plane.SetX(destination.GetX());
                    plane.SetY(destination.GetY());
                }
                else
                {
                    plane.Move(dx, dy);
                
            }
        }

            public static double Distance(FlightPlanCart plan)
        {
            return plan.GetOrigin().DistanceTo(plan.GetDestination());
        }
    }
}

