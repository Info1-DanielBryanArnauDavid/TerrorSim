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
        FlightPlanCart[] miLista = new FlightPlanCart[10];
        int number = 0;
        public FlightPlanList()
        {
            FlightPlan[] miLista = new FlightPlan[10];
        }
        public int AddFlightPlan(FlightPlanCart flightPlanCart)
        {
            if (number == 10)
            {
                return -1;
            }
            else
            {
                miLista[number] = flightPlanCart;
                number++;
                return 0;
            }
        }

        public FlightPlanCart GetFlightPlanCart(int i)
        {
            if (i < 0 || i > 10)
            {
                return null;
            }
            else
            {
                return miLista[i];
            }
        }

        public int GetNumber()
        {
            return number;
        }
    }
}
