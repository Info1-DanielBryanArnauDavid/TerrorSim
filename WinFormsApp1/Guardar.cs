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

        public Guardar(FlightPlanList lista)
        {
            InitializeComponent();
            this.lista = lista;
        }
        public FlightPlanList GetmiLista()
        { return lista; }


        private void button1Guardar_Click(object sender, EventArgs e)
        {
            string archivo = Name.Text;
            FlightPlanList lista = GetmiLista();

        }
    }
}
