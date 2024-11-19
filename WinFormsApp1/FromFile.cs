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
    public partial class FromFile : Form
    {
        FlightPlanList List = new FlightPlanList();
        public void setLista(FlightPlanList lista)
        {
            this.List = lista;
        }
        public FlightPlanList getLista()
        {
            return List;
        }

        public FromFile()
        {
            InitializeComponent();
        }

        private void FromFile_Load(object sender, EventArgs e)
        {

        }

        private void buttoncargar_Click(object sender, EventArgs e)
        {
            string archivo = textBoxNombreArchivotxt.Text;
            try 
            {
                StreamReader sr = new StreamReader(archivo);
                string linea;
                
                while ((linea = sr.ReadLine())!=null)       //leemos linea por linea y cargamos el archivo en una lista de flightplans
                {
                    string[] trozos = linea.Split(" ");     //Suponemos que el archivo viene asi: ID Ox Oy Dx Dy Speed
                    string ID = trozos[0];
                    WaypointCart O = new WaypointCart(Convert.ToDouble(trozos[1]), Convert.ToDouble(trozos[2]));
                    WaypointCart D = new WaypointCart(Convert.ToDouble(trozos[3]), Convert.ToDouble(trozos[4]));
                    double S = Convert.ToDouble(trozos[5]);
                    FlightPlanCart FP = new FlightPlanCart(ID, O, D, S);    //creamos flightplan
                    List.AddFlightPlan(FP);         //añadimos a la lista
                }
                Saved Dg = new Saved();     //Abre un forms que confirma que todo se ha guardado bien
                Dg.ShowDialog();
                Close();        //Cierra el forms al pulsar "aceptar"
            }
            catch (FileNotFoundException)
            {
                Error2 error = new Error2();
                error.ShowDialog();
            }
            catch (FormatException) 
            {
                Error error = new Error();
                error.ShowDialog();
            }
            catch 
            {
                Error error = new Error();
                error.ShowDialog();
            }
        }
    }
}
