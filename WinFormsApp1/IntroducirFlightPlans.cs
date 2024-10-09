namespace WinFormsApp1
{
    public partial class IntroducirFlightPlans : Form
    {
        public IntroducirFlightPlans()
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
                WaypointCart Destination1 = new WaypointCart(Convert.ToDouble(FP1Xo.Text), Convert.ToDouble(FP1Yf.Text));

                WaypointCart Origen2 = new WaypointCart(Convert.ToDouble(FP1Xo.Text), Convert.ToDouble(FP2Yo.Text));
                WaypointCart Destination2 = new WaypointCart(Convert.ToDouble(FP1Xo.Text), Convert.ToDouble(FP2Yf.Text));

                //Creamos los 2 flightplans ya con todos los elementos
                FlightPlanCart FP1 = new FlightPlanCart(FP1Number.Text, Origen1, Destination1, Convert.ToDouble(FP1Speed.Text));
                FlightPlanCart FP2 = new FlightPlanCart(FP2Number.Text, Origen2, Destination2, Convert.ToDouble(FP2Speed.Text));

                //Abre un forms que confirma que todo se ha guardado bien
                DatosGuardados Dg = new DatosGuardados();
                Dg.ShowDialog();

                //Cierra el forms al pulsar "aceptar"
                Close();
            }

            //En caso de error:
            catch (Exception)             
            {
                //Abre un forms que avisa de un error
                Error fallo = new Error(); 
                fallo.ShowDialog();
            }
        }
    }
}
