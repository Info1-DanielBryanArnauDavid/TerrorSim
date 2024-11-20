using Class;
using System;
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
    public partial class Guardar : Form
    {
        FlightPlanList lista = new FlightPlanList();
        List<PictureBox> vuelos = new List<PictureBox>();

        public Guardar(FlightPlanList lista, List<PictureBox> vuelos)
        {
            InitializeComponent();
            this.lista = lista;
            this.vuelos = vuelos;
        }
        public FlightPlanList GetmiLista()
        { return lista; }

        public List<PictureBox> Getvuelos() {  return vuelos; }

        private void button1Guardar_Click(object sender, EventArgs e)
        {
            string archivo = Name.Text;
            FlightPlanList lista = GetmiLista();
            List<PictureBox> vuelos = Getvuelos();

            Close();
        }
    }
}
