using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    public class FlightPlan
    {
        private string flightNumber;
        private List<Waypoint> waypoints;
        private double totalDistance;
        private double speed;
        private Waypoint avion;

        public FlightPlan(string flightNumber, List<Waypoint> waypoints, double speed)
        {
            this.flightNumber = flightNumber;
            this.waypoints = waypoints;
            this.speed = speed;
            this.avion = new Waypoint(waypoints[0].DameLatitude(), waypoints[0].DameLongitude(), waypoints[0].DameAltitude());
            CalculateTotalDistance();
        }

        private void CalculateTotalDistance()
        {
            totalDistance = 0;
            for (int i = 0; i < waypoints.Count - 1; i++)
            {
                totalDistance += waypoints[i].GeodesicDistance(waypoints[i + 1]);
            }
        }

        public string DameFlightNumber()
        {
            return flightNumber;
        }

        public Waypoint DameWaypoint(int index)
        {
            return waypoints[index];
        }

        public double DameDistance()
        {
            return totalDistance;
        }

        public double DameSpeed()
        {
            return speed;
        }

        public void PonSpeed(double speed)
        {
            this.speed = speed;
        }

        public void AgregarWaypoint(Waypoint waypoint)
        {
            waypoints.Add(waypoint);
            CalculateTotalDistance();
        }

        public void RemoverWaypoint(int index)
        {
            if (index >= 0 && index < waypoints.Count)
            {
                waypoints.RemoveAt(index);
                CalculateTotalDistance();
            }
        }

        public Waypoint DameWaypointAvion()
        {
            return this.avion;
        }

        public void PonWaypointAvion(Waypoint newPosition)
        {
            this.avion = newPosition;
        }

        public void Restart()
        {
            this.avion.SetAltitude(waypoints[0].DameAltitude());
            this.avion.SetLongitude(waypoints[0].DameLongitude());
            this.avion.SetLatitude(waypoints[0].DameLatitude());
        }

        public Boolean hasArrived()
        {
            Waypoint finalWaypoint = waypoints.Last();
            return this.avion.DameLatitude() == finalWaypoint.DameLatitude() &&
                   this.avion.DameLongitude() == finalWaypoint.DameLongitude();
        }

        public void MoverAvion(int incLat, int incLon, double time, double speed)
        {
            avion.Mover(incLat, incLon, time, speed);
        }

        public static double Distance(FlightPlan plan)
        {
            return plan.DameDistance();
        }
    }
}

