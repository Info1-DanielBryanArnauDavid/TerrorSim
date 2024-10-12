using Class;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class SimulacionVuelo : Form
    {

        FlightPlanList miLista = new FlightPlanList();
        int tiempoCiclo;
        PictureBox[] vuelos = new PictureBox[100];
        int numPics = 0;


        public SimulacionVuelo()
        {
            InitializeComponent();
            miPanel.Paint += MiPanel_Paint;
            hoverInfoLabel.AutoSize = true;
            hoverInfoLabel.BackColor = Color.White;
            hoverInfoLabel.ForeColor = Color.Black;
            hoverInfoLabel.BorderStyle = BorderStyle.FixedSingle;
            hoverInfoLabel.Visible = false;  // Initially hidden
            miPanel.Controls.Add(hoverInfoLabel);
        }

        public void setData(FlightPlanList f, int c)
        {
            miLista = f;
            tiempoCiclo = c;
        }

        private void MiPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen dottedPen = new Pen(Color.Green, 1))
            {
                dottedPen.DashStyle = DashStyle.Dot;

                for (int i = 0; i < miLista.GetNumber(); i++)
                {
                    FlightPlanCart flight = miLista.GetFlightPlanCart(i);
                    WaypointCart origin = flight.GetOrigin();
                    WaypointCart destination = flight.GetDestination();

                    // Draw dotted line from origin to destination
                    g.DrawLine(dottedPen,
                        new Point((int)origin.GetX(), (int)origin.GetY()),
                        new Point((int)destination.GetX(), (int)destination.GetY()));
                }
            }

        }
        //Visualizar los vuelos
        private void Simulacion_Load(object sender, EventArgs e)
        {

        }

        private void SimulacionVuelo_Load_1(object sender, EventArgs e)
        {
            for (int i = 0; i < miLista.GetNumber(); i++)
            {
                PictureBox p = new PictureBox();
                PictureBox a = new PictureBox();
                PictureBox v = new PictureBox();
                FlightPlanCart f = miLista.GetFlightPlanCart(i);
                //Configuración PictureBox
                p.Size = new Size(5, 5);
                p.BackColor = Color.Red;
                p.Location = new Point(Convert.ToInt32(miLista.GetFlightPlanCart(i).GetOrigin().GetX()), Convert.ToInt32(miLista.GetFlightPlanCart(i).GetOrigin().GetY()));
                a.Size = new Size(5, 5);
                a.BackColor = Color.Blue;
                a.Location = new Point(Convert.ToInt32(miLista.GetFlightPlanCart(i).GetDestination().GetX()), Convert.ToInt32(miLista.GetFlightPlanCart(i).GetDestination().GetY()));
                v.Size = new Size(5, 5);
                v.BackColor = Color.Black;
                v.Location = new Point(Convert.ToInt16(miLista.GetFlightPlanCart(i).GetPlanePosition().GetX()), Convert.ToInt16(miLista.GetFlightPlanCart(i).GetPlanePosition().GetY()));
                v.MouseMove += (s, ev) => ShowPlaneInfoAtMouse(f, ev);
                v.MouseLeave += (s, ev) => HidePlaneInfo();
                vuelos[numPics] = v;
                numPics++;
                miPanel.Controls.Add(v);
                miPanel.Controls.Add(p);
                miPanel.Controls.Add(a);



            }

        }
        private void ShowPlaneInfoAtMouse(FlightPlanCart flight, MouseEventArgs e)
        {
            // Prepare the flight information
            string flightInfo = $"Name: {flight.GetFlightNumber()}\n"+
                                $"Origin: ({flight.GetOrigin().GetX()}, {flight.GetOrigin().GetY()})\n" +
                                $"Dest: ({flight.GetDestination().GetX()}, {flight.GetDestination().GetY()})\n" +
                                $"Pos: ({Math.Round(flight.GetPlanePosition().GetX(),1)}, {Math.Round(flight.GetPlanePosition().GetY(),1)})\n" +
                                $"Speed: {flight.GetSpeed()}";

            hoverInfoLabel.Text = flightInfo;

            // Get the mouse position relative to the panel (not just the PictureBox)
            Point cursorPositionInPanel = miPanel.PointToClient(Cursor.Position);

            // Set the label position slightly offset from the cursor to avoid overlapping
            hoverInfoLabel.Location = new Point(cursorPositionInPanel.X, cursorPositionInPanel.Y);

            // Show the label
            hoverInfoLabel.Visible = true;
        }

        // Hide the label when the mouse leaves the PictureBox
        private void HidePlaneInfo()
        {
            hoverInfoLabel.Visible = false;
        }

        private void miPanel_Click(object sender, EventArgs e){}
        private void miPanel_MouseMove(object sender, EventArgs e){}
        private void miPanel_MouseLeave(object sender, MouseEventArgs e){}
        private void miPanel_CursorChanged(object sender, EventArgs e){}
        private void miPanel_MouseMove_1(object sender, MouseEventArgs e){}
        private void miPanel_MouseLeave_1(object sender, EventArgs e){}
        private void button1_Click(object sender, EventArgs e)
        {

            //mover manualmente
            for (int i = 0; i < miLista.GetNumber(); i++)
            {

                double x = Convert.ToInt32(miLista.GetFlightPlanCart(i).GetDestination().GetX()) - Convert.ToInt32(miLista.GetFlightPlanCart(i).GetOrigin().GetX());
                double y = Convert.ToInt32(miLista.GetFlightPlanCart(i).GetDestination().GetY()) - Convert.ToInt32(miLista.GetFlightPlanCart(i).GetOrigin().GetY());
                double angle = Math.Atan2(y, x);
                double inc = miLista.GetFlightPlanCart(i).GetSpeed() * Convert.ToDouble(tiempoCiclo);
                double dx = inc * Math.Cos(angle);
                double dy = inc * Math.Sin(angle);
                miLista.GetFlightPlanCart(i).MovePlane(dx, dy);
                vuelos[i].Location = new Point(Convert.ToInt32(miLista.GetFlightPlanCart(i).GetPlanePosition().GetX()), Convert.ToInt32(miLista.GetFlightPlanCart(i).GetPlanePosition().GetY()));
            }
            miPanel.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e){}
        private void label3_Paint(object sender, PaintEventArgs e){}
        private void button1_Click_1(object sender, EventArgs e){}
        private void timer1_Tick(object sender, EventArgs e){}
        private void label2_Click(object sender, EventArgs e){}
        private void MiPanel_Click_1(object sender, EventArgs e){}
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            for (int i = 0; i < miLista.GetNumber(); i++)
            {

                double x = Convert.ToInt32(miLista.GetFlightPlanCart(i).GetDestination().GetX()) - Convert.ToInt32(miLista.GetFlightPlanCart(i).GetOrigin().GetX());
                double y = Convert.ToInt32(miLista.GetFlightPlanCart(i).GetDestination().GetY()) - Convert.ToInt32(miLista.GetFlightPlanCart(i).GetOrigin().GetY());
                double angle = Math.Atan2(y, x);
                double inc = miLista.GetFlightPlanCart(i).GetSpeed() * Convert.ToDouble(tiempoCiclo);
                double dx = inc * Math.Cos(angle);
                double dy = inc * Math.Sin(angle);
                miLista.GetFlightPlanCart(i).MovePlane(dx, dy);
                vuelos[i].Location = new Point(Convert.ToInt32(miLista.GetFlightPlanCart(i).GetPlanePosition().GetX()), Convert.ToInt32(miLista.GetFlightPlanCart(i).GetPlanePosition().GetY()));

            }
            miPanel.Invalidate();
        }

        private void SimulacionVuelo_Load_(object sender, EventArgs e)
        {}
        private void button2_Click_1(object sender, EventArgs e)
        {
            //mover auto
            timer1.Interval = 1000;
            if (timer1.Enabled)
            {
                timer1.Stop();
                button2.Text = "Auto";
            }
            else
            {
                ;
                timer1.Start();
                button2.Text = "Stop";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < miLista.GetNumber(); i++)
            {
                miLista.GetFlightPlanCart(i).Restart();
                vuelos[i].Location = new Point(Convert.ToInt32(miLista.GetFlightPlanCart(i).GetPlanePosition().GetX()), Convert.ToInt32(miLista.GetFlightPlanCart(i).GetPlanePosition().GetY()));

            }
        }

        private void miPanel_MouseHover(object sender, EventArgs e){}
        private void miPanel_MouseMove(object sender, MouseEventArgs e)
        {
            label2.Text = "X= " + e.X + "Y= " + e.Y;
        }

        private void miPanel_MouseLeave(object sender, EventArgs e)
        {
            label2.Text = "Out of bounds";
        }
    }
}