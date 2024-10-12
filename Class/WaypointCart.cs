using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    public class WaypointCart
    {
        private double x;
        private double y;

        public WaypointCart(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        //lo dejamos mas limpio asi
        public double GetX() { return x; }
        public double GetY() { return y; }
        public void SetX(double x) { this.x = x; }
        public void SetY(double y) { this.y = y; }

        //cartesiana y ya
        public double DistanceTo(WaypointCart other)
        {
            double dx = this.x - other.x;
            double dy = this.y - other.y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public void Move(double dx, double dy)
        {
            this.x += dx;
            this.y += dy;
        }
    }
}
