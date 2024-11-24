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
        string mode = string.Empty;
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

            this.Hide();
            if (mode == "simple")
            {
                Simulator simulacion = new Simulator();
                simulacion.setData(miLista, tiempoCiclo, distSeg);
                simulacion.ShowDialog();
            }
            else
            {
                ComplexSimulation simulacion1 = new ComplexSimulation();
                simulacion1.setData(miLista, tiempoCiclo, distSeg);
                simulacion1.ShowDialog();
            }
            this.Show();
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
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string archivo = openFileDialog.FileName;
                    try
                    {
                        StreamReader sr = new StreamReader(archivo);
                        string linea;

                        while ((linea = sr.ReadLine()) != null)
                        {
                            string[] trozos = linea.Split(" ");
                            string ID = trozos[0];
                            WaypointCart O = new WaypointCart(Convert.ToDouble(trozos[1]), Convert.ToDouble(trozos[2]));
                            WaypointCart D = new WaypointCart(Convert.ToDouble(trozos[3]), Convert.ToDouble(trozos[4]));
                            if (Convert.ToDouble(trozos[5]) > 0)
                            {
                                double S = Convert.ToDouble(trozos[5]);
                                FlightPlanCart FP = new FlightPlanCart(ID, O, D, S);
                                miLista.AddFlightPlan(FP);
                            }
                            else { MessageBox.Show("Error: 0 or Negative velocities, won't be taken into account"); }
                        }
                        MessageBox.Show("Data saved correctly");
                    }
                    catch (FileNotFoundException)
                    {
                        ;
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Wrong format");
                    }
                    catch
                    {
                        MessageBox.Show("rip");
                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            opcionesToolStripMenuItem.Visible = true;
            simulatorToolStripMenuItem.Visible=true;
            button1.Visible=false;
            button2.Visible=false;
            linkLabel1.Visible=false;
            mode = "simple";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            opcionesToolStripMenuItem.Visible = true;
            simulatorToolStripMenuItem.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            linkLabel1.Visible = false;
            mode = "complex";
        }
    }
}
