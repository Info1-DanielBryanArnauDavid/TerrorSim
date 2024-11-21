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
    public partial class ComplexSimulation : Form
    {
        FlightPlanList miLista = new FlightPlanList();
        int tiempoCiclo;
        int distSeg;
        List<PictureBox> vuelos = new List<PictureBox>();
        Stack<FlightPlanList> EstadoVuelos = new Stack<FlightPlanList>();
        bool StatusBtn = false;
        double multiplicador = 1;
        int cuentaClicks = 1;
        float opacity = 1;
        FlightPlanCart selec1;
        FlightPlanCart selec2;
        public ComplexSimulation()
        {
            InitializeComponent();
        }

        private void ComplexSimulation_Load(object sender, EventArgs e)
        {

        }

        public FlightPlanList GetmiLista()
        { return this.miLista; }

        public List<PictureBox> Getvuelos()
        {
            return this.vuelos;
        }

        public void setData(FlightPlanList f, int c, int dist)
        {
            miLista = f;
            tiempoCiclo = c;
            distSeg = dist;
        }
    }
}
