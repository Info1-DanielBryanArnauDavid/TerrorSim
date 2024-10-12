using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Class;

namespace WinFormsApp1
{
    public partial class Inicio : Form
    {
        FlightPlanList miLista = new FlightPlanList();
        int tiempoCiclo;
        public Inicio()
        {
            InitializeComponent();
        }

        private void introducirFlightPlansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Crea y abre el forms de introducir flightplans
            IntroducirFlightPlans IFP = new IntroducirFlightPlans();
            miLista = IFP.getLista();
            IFP.ShowDialog();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private void introducirDistanciaDeSeguridadYTiempoDeCicloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Crea y abre el forms de introducir distancia de seguridad y tiempo de ciclo
            DistanciaSeguridadTiempoCiclo DSTC = new DistanciaSeguridadTiempoCiclo();
            DSTC.ShowDialog();
            tiempoCiclo = DSTC.dameTiempo();
        }

        private void simularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SimulacionVuelo simulacion = new SimulacionVuelo();
            simulacion.setData(miLista, tiempoCiclo);
            simulacion.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/Info1-DanielBryanArnauDavid/TerrorSim/",
                UseShellExecute = true
            });
        }
    }
}
