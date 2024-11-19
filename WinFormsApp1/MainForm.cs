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
    public partial class MainForm : Form
    {
        FlightPlanList miLista = new FlightPlanList();
        int tiempoCiclo;
        int distSeg;
        public MainForm()
        {
            InitializeComponent();
        }

        private void introducirFlightPlansToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void introducirDistanciaDeSeguridadYTiempoDeCicloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Crea y abre el forms de introducir distancia de seguridad y tiempo de ciclo
            Parameters DSTC = new Parameters();
            DSTC.ShowDialog();
            tiempoCiclo = DSTC.dameTiempo();
            distSeg = DSTC.dameDist();

        }

        private void simularToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/Info1-DanielBryanArnauDavid/TerrorSim/",
                UseShellExecute = true
            });
        }

        private void openSimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Simulator simulacion = new Simulator();
            simulacion.setData(miLista, tiempoCiclo, distSeg);
            simulacion.ShowDialog();
        }

        private void flightPlanPairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Crea y abre el forms de introducir flightplans
            InsertFP IFP = new InsertFP();
            miLista = IFP.getLista();
            IFP.ShowDialog();
        }

        private void fromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FromFile Fp = new FromFile();
            miLista = Fp.getLista();
            Fp.ShowDialog();
        }
    }
}
