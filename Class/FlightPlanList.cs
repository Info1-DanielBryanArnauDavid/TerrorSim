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
        private List<FlightPlanCart> miLista;

        public FlightPlanList()
        {
            miLista = new List<FlightPlanCart>();
        }

        public int AddFlightPlan(FlightPlanCart flightPlanCart)
        {
            if (flightPlanCart == null)
            {
                return -1;
            }

            miLista.Add(flightPlanCart);
            return 0;
        }

        public FlightPlanCart GetFlightPlanCart(int i)
        {
            if (i < 0 || i >= miLista.Count)
            {
                return null;
            }

            return miLista[i];
        }

        public int GetNumber()
        {
            return miLista.Count;
        }
    }
}