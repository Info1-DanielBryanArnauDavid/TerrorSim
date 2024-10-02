using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrorSim
{
    internal class Waypoint
    {
        private double latitude;
        private double longitude;
        private double altitude;

        //radio tierra
        private const double EarthRadiusKm = 6371.0;

        //constructor, hemos añadido la altitud por un posible interés de aportar algo más al proyecto final si está dentro de las posibilidades
        public Waypoint(double latitude, double longitude, double altitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
            this.altitude = altitude;
        }

        //lo dejamos mas limpio asi
        public double DameLatitude() { return latitude; }
        public double DameLongitude() { return longitude; }
        public double DameAltitude() { return altitude; }
        public void SetLatitude(double latitude) { this.latitude = latitude; }
        public void SetLongitude(double longitude) { this.longitude = longitude; }
        public void SetAltitude(double altitude) { this.altitude = altitude; }

        //haversine y sus cosas
        public double GeodesicDistance(Waypoint other)
        {
            double lat1 = DegreesToRadians(this.latitude);
            double lon1 = DegreesToRadians(this.longitude);
            double lat2 = DegreesToRadians(other.DameLatitude());
            double lon2 = DegreesToRadians(other.DameLongitude());

            double dLat = lat2 - lat1;
            double dLon = lon2 - lon1;

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return EarthRadiusKm * c;
        }

        //trataremos al avion como otro waypoint, pero se podra mover jeje
        public void Mover(int incLat, int incLon, double time, double speed)
        {
            double distance = speed * time;
            double angularDistance = distance / EarthRadiusKm;

            double latRad = DegreesToRadians(this.latitude);
            double lonRad = DegreesToRadians(this.longitude);

            latRad += angularDistance * incLat;
            lonRad += angularDistance * incLon;

            this.latitude = RadiansToDegrees(latRad);
            this.longitude = RadiansToDegrees(lonRad);
        }
        //usamos static para no tener que llamar a un objeto para usarla
        private static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }
        private static double RadiansToDegrees(double radians)
        {
            return radians * 180.0 / Math.PI;
        }
    }
}
