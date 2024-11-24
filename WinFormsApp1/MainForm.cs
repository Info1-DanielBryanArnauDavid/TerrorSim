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
        // Lista de planes de vuelo
        FlightPlanList miLista = new FlightPlanList();
        int tiempoCiclo; // Tiempo de ciclo
        int distSeg;     // Distancia de seguridad
        string mode = string.Empty; // Modo de simulación (simple o complejo)

        public MainForm()
        {
            InitializeComponent();
        }

        private void introducirFlightPlansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Método vacío (para futuras implementaciones)
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            // Establece el icono del formulario
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void introducirDistanciaDeSeguridadYTiempoDeCicloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abre el formulario para configurar distancia de seguridad y tiempo de ciclo
            Parameters DSTC = new Parameters();
            DSTC.ShowDialog();

            // Obtiene los valores ingresados desde el formulario
            tiempoCiclo = DSTC.dameTiempo();
            distSeg = DSTC.dameDist();
        }

        private void simularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Método vacío (para futuras implementaciones)
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Abre un enlace a la página de GitHub del proyecto
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/Info1-DanielBryanArnauDavid/TerrorSim/",
                UseShellExecute = true
            });
        }

        private void openSimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Oculta el formulario principal mientras se ejecuta la simulación
            this.Hide();

            if (mode == "simple")
            {
                // Simulación en modo simple
                Simulator simulacion = new Simulator();
                simulacion.setData(miLista, tiempoCiclo, distSeg);
                simulacion.ShowDialog();
            }
            else
            {
                // Simulación en modo complejo
                ComplexSimulation simulacion1 = new ComplexSimulation();
                simulacion1.setData(miLista, tiempoCiclo, distSeg);
                simulacion1.ShowDialog();
            }

            // Vuelve a mostrar el formulario principal después de la simulación
            this.Show();
        }

        private void flightPlanPairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abre el formulario para introducir planes de vuelo
            InsertFP IFP = new InsertFP();

            // Obtiene la lista de planes de vuelo desde el formulario
            miLista = IFP.getLista();
            IFP.ShowDialog();
        }

        private void fromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abre un cuadro de diálogo para seleccionar un archivo
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string archivo = openFileDialog.FileName;

                    try
                    {
                        // Lee el archivo línea por línea
                        StreamReader sr = new StreamReader(archivo);
                        string linea;

                        while ((linea = sr.ReadLine()) != null)
                        {
                            // Divide cada línea en sus componentes
                            string[] trozos = linea.Split(" ");
                            string ID = trozos[0];
                            WaypointCart O = new WaypointCart(Convert.ToDouble(trozos[1]), Convert.ToDouble(trozos[2]));
                            WaypointCart D = new WaypointCart(Convert.ToDouble(trozos[3]), Convert.ToDouble(trozos[4]));

                            // Valida que la velocidad sea mayor a 0
                            if (Convert.ToDouble(trozos[5]) > 0)
                            {
                                double S = Convert.ToDouble(trozos[5]);
                                FlightPlanCart FP = new FlightPlanCart(ID, O, D, S);
                                miLista.AddFlightPlan(FP); // Añade el plan de vuelo a la lista
                            }
                            else
                            {
                                MessageBox.Show("Error: 0 or Negative velocities, won't be taken into account");
                            }
                        }

                        // Notifica al usuario que los datos se han guardado correctamente
                        MessageBox.Show("Data saved correctly");
                    }
                    catch (FileNotFoundException)
                    {
                        // Error al no encontrar el archivo (sin mensaje explícito)
                    }
                    catch (FormatException)
                    {
                        // Error por formato incorrecto
                        MessageBox.Show("Wrong format");
                    }
                    catch
                    {
                        // Error genérico
                        MessageBox.Show("rip");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Configura la aplicación en modo "simple"
            opcionesToolStripMenuItem.Visible = true;
            simulatorToolStripMenuItem.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            linkLabel1.Visible = false;
            mode = "simple";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Configura la aplicación en modo "complex"
            opcionesToolStripMenuItem.Visible = true;
            simulatorToolStripMenuItem.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            linkLabel1.Visible = false;
            mode = "complex";
        }
    }
}
