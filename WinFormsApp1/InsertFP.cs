using Class;

namespace WinFormsApp1
{
    public partial class InsertFP : Form
    {
        FlightPlanList lista = new FlightPlanList();

        public void setLista(FlightPlanList lista)
        {
            this.lista = lista;
        }
        public FlightPlanList getLista()
        {
            return lista;
        }

        public InsertFP()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AceptarBoton_Click(object sender, EventArgs e)
        {
            //Cuando le damos al boton Aceptar:

            try
            {
                //Creamos waypoints de origen y destino
                WaypointCart Origen1 = new WaypointCart(Convert.ToDouble(FP1Xo.Text), Convert.ToDouble(FP1Yo.Text));
                WaypointCart Destination1 = new WaypointCart(Convert.ToDouble(FP1Xf.Text), Convert.ToDouble(FP1Yf.Text));

                WaypointCart Origen2 = new WaypointCart(Convert.ToDouble(FP2Xo.Text), Convert.ToDouble(FP2Yo.Text));
                WaypointCart Destination2 = new WaypointCart(Convert.ToDouble(FP2Xf.Text), Convert.ToDouble(FP2Yf.Text));

                //Creamos los 2 flightplans ya con todos los elementos
                if (Convert.ToDouble(FP1Speed.Text) > 0 && Convert.ToDouble(FP2Speed.Text) > 0 && FP1Number.Text != "" && FP2Number.Text != "")
                {
                    FlightPlanCart FP1 = new FlightPlanCart(FP1Number.Text, Origen1, Destination1, Convert.ToDouble(FP1Speed.Text));
                    FlightPlanCart FP2 = new FlightPlanCart(FP2Number.Text, Origen2, Destination2, Convert.ToDouble(FP2Speed.Text));

                    //Añadir FlightPlans a la lista
                    lista.AddFlightPlan(FP1);
                    lista.AddFlightPlan(FP2);

                    //Abre un forms que confirma que todo se ha guardado bien
                    MessageBox.Show("Datos guardados correctamente");

                    //Cierra el forms al pulsar "aceptar"
                    Close();
                }
                else { MessageBox.Show("Datos incorrectos"); }
            }

            //En caso de error:
            catch (Exception)
            {
                //Abre un forms que avisa de un error
                Error fallo = new Error();
                fallo.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FP1Xo.Text = "30";
            FP1Xf.Text = "550";
            FP2Xo.Text = "480";
            FP2Xf.Text = "45";
            FP1Speed.Text = "10";
            FP1Yo.Text = "450";
            FP1Yf.Text = "40";
            FP2Yo.Text = "510";
            FP2Yf.Text = "25";
            FP2Speed.Text = "15";
            FP2Number.Text = "B123";
            FP1Number.Text = "A123";

        }
    }
}
