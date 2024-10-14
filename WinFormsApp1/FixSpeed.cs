using Class;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FixSpeed : Form
    {
        FlightPlanList miLista;
        int distSeg;
        double OptV1,OptV2;

        public FixSpeed()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //cambiar velocidad a la optima vuelo 1

        }

        public void setDataFix(FlightPlanList plan, int secdist)
        {
            miLista = plan;
            distSeg = secdist;
        }

        public double GetData() { return distSeg; }
        private void FixSpeed_Load(object sender, EventArgs e)
        {
            string ID = miLista.GetFlightPlanCart(0).GetFlightNumber();
            string ID2 = miLista.GetFlightPlanCart(1).GetFlightNumber();
            button1.Text = ID;
            button2.Text = ID2;
            for (int i = 0; i < miLista.GetNumber(); i++)
            {
                for (int j = i + 1; j < miLista.GetNumber(); j++)
                {
                    FlightPlanCart flight1 = miLista.GetFlightPlanCart(i);
                    FlightPlanCart flight2 = miLista.GetFlightPlanCart(j);

                    double rx = flight2.GetPlanePosition().GetX() - flight1.GetPlanePosition().GetX();
                    double ry = flight2.GetPlanePosition().GetY() - flight1.GetPlanePosition().GetY();
                    double vx = flight2.GetSpeed() * Math.Cos(flight2.GetAngle()) - flight1.GetSpeed() * Math.Cos(flight1.GetAngle());
                    double vy = flight2.GetSpeed() * Math.Sin(flight2.GetAngle()) - flight1.GetSpeed() * Math.Sin(flight1.GetAngle());

                    //derivada precalculada
                    double t = -(rx * vx + ry * vy) / (vx * vx + vy * vy);

                    double OptV1;
                    double OptV2;





                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //cambiar velocidad a la optima vuelo 2
        }
    }
}
