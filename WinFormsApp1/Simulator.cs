using Class;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Simulator : Form
    {

        FlightPlanList miLista = new FlightPlanList();
        int tiempoCiclo;
        int distSeg;
        PictureBox[] vuelos = new PictureBox[100];
        int numPics = 0;


        public Simulator()
        {
            InitializeComponent();
            miPanel.Paint += MiPanel_Paint;
            hoverInfoLabel.AutoSize = true;
            hoverInfoLabel.ForeColor = Color.Black;
            hoverInfoLabel.BorderStyle = BorderStyle.FixedSingle;
            hoverInfoLabel.Visible = false;
            miPanel.Controls.Add(hoverInfoLabel);
            SetupDataGridView();
        }

        private void UpdateDataGridView()
        {
            flightDataGridView.Rows.Clear();

            for (int i = 0; i < miLista.GetNumber(); i++)
            {
                FlightPlanCart flight = miLista.GetFlightPlanCart(i);
                flightDataGridView.Rows.Add(
                    flight.GetFlightNumber(),
                    Math.Round(flight.GetOrigin().GetX(), 2),
                    Math.Round(flight.GetOrigin().GetY(), 2),
                    Math.Round(flight.GetDestination().GetX(), 2),
                    Math.Round(flight.GetDestination().GetY(), 2),
                    Math.Round(flight.GetPlanePosition().GetX(), 2),
                    Math.Round(flight.GetPlanePosition().GetY(), 2),
                    flight.GetSpeed()
                );
            }
        }

        private void SetupDataGridView()
        {
            flightDataGridView.Columns.Add("FlightNumber", "Flight Number");
            flightDataGridView.Columns.Add("OriginX", "Origin X");
            flightDataGridView.Columns.Add("OriginY", "Origin Y");
            flightDataGridView.Columns.Add("DestinationX", "Destination X");
            flightDataGridView.Columns.Add("DestinationY", "Destination Y");
            flightDataGridView.Columns.Add("CurrentX", "Current X");
            flightDataGridView.Columns.Add("CurrentY", "Current Y");
            flightDataGridView.Columns.Add("Speed", "Speed");

            this.Controls.Add(flightDataGridView);

        }

        private bool CheckSecurityDistance(FlightPlanCart flightToCheck)
        {
            for (int i = 0; i < miLista.GetNumber(); i++)
            {
                FlightPlanCart otherFlight = miLista.GetFlightPlanCart(i);

                // Skip comparing the flight with itself
                if (flightToCheck.GetFlightNumber() == otherFlight.GetFlightNumber())
                    continue;

                double distance = CalculateDistance(
                    flightToCheck.GetPlanePosition().GetX(),
                    flightToCheck.GetPlanePosition().GetY(),
                    otherFlight.GetPlanePosition().GetX(),
                    otherFlight.GetPlanePosition().GetY()
                );

                if (distance < 2 * distSeg-1)
                {
                    return true;
                }
            }
            return false;
        }

        private double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        public void setData(FlightPlanList f, int c, int dist)
        {
            miLista = f;
            tiempoCiclo = c;
            distSeg = dist;
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
            using (Pen redPen = new Pen(Color.Red, 1))
            {
                for (int i = 0; i < miLista.GetNumber(); i++)
                {
                    Point planePosition = vuelos[i].Location;

                    Rectangle circleRect = new Rectangle(
                        planePosition.X - distSeg,
                        planePosition.Y - distSeg,
                        distSeg * 2,
                        distSeg * 2
                    );

                    g.DrawEllipse(redPen, circleRect);

                }
            }
        }
        //Visualizar los vuelos
        private void Simulacion_Load(object sender, EventArgs e) { }

        private void SimulacionVuelo_Load_1(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
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
            UpdateDataGridView();

        }
        private void ShowPlaneInfoAtMouse(FlightPlanCart flight, MouseEventArgs e)
        {
            // Prepare the flight information
            string flightInfo = $"Name: {flight.GetFlightNumber()}\n" +
                                $"Origin: ({flight.GetOrigin().GetX()}, {flight.GetOrigin().GetY()})\n" +
                                $"Dest: ({flight.GetDestination().GetX()}, {flight.GetDestination().GetY()})\n" +
                                $"Pos: ({Math.Round(flight.GetPlanePosition().GetX(), 1)}, {Math.Round(flight.GetPlanePosition().GetY(), 1)})\n" +
                                $"Speed: {flight.GetSpeed()}";

            hoverInfoLabel.Text = flightInfo;

            Point cursorPositionInPanel = miPanel.PointToClient(Cursor.Position);

            hoverInfoLabel.Location = new Point(cursorPositionInPanel.X, cursorPositionInPanel.Y);

            hoverInfoLabel.Visible = true;
        }

        // Hide the label when the mouse leaves the PictureBox
        private void HidePlaneInfo()
        {
            hoverInfoLabel.Visible = false;
        }

        private void miPanel_Click(object sender, EventArgs e) { }
        private void miPanel_MouseMove(object sender, EventArgs e) { }
        private void miPanel_MouseLeave(object sender, MouseEventArgs e) { }
        private void miPanel_CursorChanged(object sender, EventArgs e) { }
        private void miPanel_MouseMove_1(object sender, MouseEventArgs e) { }
        private void miPanel_MouseLeave_1(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e)
        {

            //mover manualmente
            for (int i = 0; i < miLista.GetNumber(); i++)
            {

                double angle = miLista.GetFlightPlanCart(i).GetAngle();
                double inc = miLista.GetFlightPlanCart(i).GetSpeed() * Convert.ToDouble(tiempoCiclo);
                double dx = inc * Math.Cos(angle);
                double dy = inc * Math.Sin(angle);
                miLista.GetFlightPlanCart(i).MovePlane(dx, dy);
                vuelos[i].Location = new Point(Convert.ToInt32(miLista.GetFlightPlanCart(i).GetPlanePosition().GetX()), Convert.ToInt32(miLista.GetFlightPlanCart(i).GetPlanePosition().GetY()));
            }
            miPanel.Invalidate();
            UpdateDataGridView();
            bool v = CheckSecurityDistance(miLista.GetFlightPlanCart(0));
            if (v)
            {
                label4.Text = "Jodido";
            }
            else
            {
                label4.Text = "Guay";
            }
        }

        private void button2_Click(object sender, EventArgs e) { }
        private void label3_Paint(object sender, PaintEventArgs e) { }
        private void button1_Click_1(object sender, EventArgs e) { }
        private void timer1_Tick(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void MiPanel_Click_1(object sender, EventArgs e) { }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            for (int i = 0; i < miLista.GetNumber(); i++)
            {
                double angle = miLista.GetFlightPlanCart(i).GetAngle();
                double inc = miLista.GetFlightPlanCart(i).GetSpeed() * Convert.ToDouble(tiempoCiclo);
                double dx = inc * Math.Cos(angle);
                double dy = inc * Math.Sin(angle);
                miLista.GetFlightPlanCart(i).MovePlane(dx, dy);
                vuelos[i].Location = new Point(Convert.ToInt32(miLista.GetFlightPlanCart(i).GetPlanePosition().GetX()), Convert.ToInt32(miLista.GetFlightPlanCart(i).GetPlanePosition().GetY()));

            }
            miPanel.Invalidate();
            UpdateDataGridView();
            bool v = CheckSecurityDistance(miLista.GetFlightPlanCart(0));
            if (v)
            {
                label4.Text = "Jodido";
            }
            else
            {
                label4.Text = "Guay";
            }
        }

        private void SimulacionVuelo_Load_(object sender, EventArgs e)
        { }
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
            bool v = CheckSecurityDistance(miLista.GetFlightPlanCart(0));
            if (v)
            {
                label4.Text = "Jodido";
            }
            else
            {
                label4.Text = "Guay";
            }
            UpdateDataGridView();
            timer1.Stop();
            miPanel.Invalidate(); //asi forzamos el repaint
        }

        private void miPanel_MouseHover(object sender, EventArgs e) { }
        private void miPanel_MouseMove(object sender, MouseEventArgs e)
        {
            label2.Text = "X= " + e.X + "Y= " + e.Y;
        }

        private void miPanel_MouseLeave(object sender, EventArgs e)
        {
            label2.Text = "Out of bounds";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //asi no usamos una simulacion otra vez
        private bool PredictCollision()
        {
            for (int i = 0; i < miLista.GetNumber(); i++)
            {
                for (int j = i + 1; j < miLista.GetNumber(); j++)
                {
                    FlightPlanCart flight1 = miLista.GetFlightPlanCart(i);
                    FlightPlanCart flight2 = miLista.GetFlightPlanCart(j);

                    double rx = flight2.GetPlanePosition().GetX() - flight1.GetPlanePosition().GetX();
                    double ry = flight2.GetPlanePosition().GetY() - flight1.GetPlanePosition().GetY();
                    double vx = flight2.GetSpeed() * Math.Cos(flight2.GetAngle()) - flight1.GetSpeed() * Math.Cos(flight1.GetAngle());
                    double vy = flight2.GetSpeed() * Math.Sin(flight2.GetAngle()) - flight1.GetSpeed() * Math.Sin(flight1.GetAngle());

                    //derivada precalculada
                    double t = -(rx * vx + ry * vy) / (vx * vx + vy * vy);

                    if (t < 0) { return false; }

                    double cx = rx + vx * t;
                    double cy = ry + vy * t;

                    if (cx * cx + cy * cy < distSeg *4* distSeg)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private double OptVel(FlightPlanCart flight1, FlightPlanCart flight2)
        {
            const int MAX_ITERATIONS = 5;
            const double CONVERGENCE_THRESHOLD = 0.1; // m/s
            double currentSpeed = flight2.GetSpeed();
            double lastSpeed = double.MaxValue;

            for (int iteration = 0; iteration < MAX_ITERATIONS; iteration++)
            {
                double rx = flight2.GetPlanePosition().GetX() - flight1.GetPlanePosition().GetX();
                double ry = flight2.GetPlanePosition().GetY() - flight1.GetPlanePosition().GetY();

                double v1x = flight1.GetSpeed() * Math.Cos(flight1.GetAngle());
                double v1y = flight1.GetSpeed() * Math.Sin(flight1.GetAngle());
                double v2x = currentSpeed * Math.Cos(flight2.GetAngle());
                double v2y = currentSpeed * Math.Sin(flight2.GetAngle());

                double vx = v2x - v1x;
                double vy = v2y - v1y;

                double topt = -(rx * vx + ry * vy) / (vx * vx + vy * vy);

                if (topt < 0) return -1;

                double cosangle = Math.Cos(flight2.GetAngle());
                double sinangle = Math.Sin(flight2.GetAngle());

                double alpha = topt * topt;
                double beta = 2 * topt * (rx * cosangle + ry * sinangle - topt * (v1x * cosangle + v1y * sinangle));
                double gamma = topt * topt * (v1x * v1x + v1y * v1y) - 2 * topt * (rx * v1x + ry * v1y) + rx * rx + ry * ry - 4*distSeg * distSeg;

                double discriminant = beta * beta - 4 * alpha * gamma;

                if (discriminant < 0) return -1;

                double newSpeed = (-beta - Math.Sqrt(discriminant)) / (2 * alpha);

                if (newSpeed < 0) return -1;

                if (Math.Abs(newSpeed - currentSpeed) < CONVERGENCE_THRESHOLD) //minimo definido para evitar iteraciones de mas

                {
                    return newSpeed;
                }

                lastSpeed = currentSpeed;
                currentSpeed = newSpeed;

                if (iteration > 0 && Math.Abs(currentSpeed - lastSpeed) > Math.Abs(lastSpeed))
                {
                    return (currentSpeed + lastSpeed) / 2;
                }
            }

            return currentSpeed > 0 ? currentSpeed : -1;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < miLista.GetNumber(); i++)
            {
                miLista.GetFlightPlanCart(i).Restart();
                vuelos[i].Location = new Point(Convert.ToInt32(miLista.GetFlightPlanCart(i).GetPlanePosition().GetX()), Convert.ToInt32(miLista.GetFlightPlanCart(i).GetPlanePosition().GetY()));

            }
            bool v = CheckSecurityDistance(miLista.GetFlightPlanCart(0));
            if (v)
            {
                label4.Text = "Jodido";
            }
            else
            {
                label4.Text = "Guay";
            }
            UpdateDataGridView();
            timer1.Stop();
            miPanel.Invalidate();
            bool collisionPredicted = PredictCollision();

            if (collisionPredicted)
            {
                label5.Text = "Posible Accidente";
                button5.Enabled = true;
            }
            else
            {
                label5.Text = "Seguro";
                button5.Enabled = false;
            }
        }

        private void flightDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            double optSpeed = (OptVel(miLista.GetFlightPlanCart(0), miLista.GetFlightPlanCart(1)));

            if (optSpeed == -1)
            {
                Imposible imp = new Imposible();
                imp.ShowDialog();
            }
            else
            {
            miLista.GetFlightPlanCart(1).SetSpeed(Math.Round(optSpeed,2));
            for (int i = 0; i < miLista.GetNumber(); i++)
            {
                miLista.GetFlightPlanCart(i).Restart();
                vuelos[i].Location = new Point(Convert.ToInt32(miLista.GetFlightPlanCart(i).GetPlanePosition().GetX()), Convert.ToInt32(miLista.GetFlightPlanCart(i).GetPlanePosition().GetY()));

            }
            label5.Text = "Seguro";
            button5.Enabled = false;

            UpdateDataGridView();
            timer1.Stop();
            miPanel.Invalidate(); //asi forzamos el repaint
            }

        }

            
        private void flightDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //abrirá un forms de cambios
            if (e.ColumnIndex == 7)
            {
            SetSpeedForm fixSpeed = new SetSpeedForm();
            double speed = Convert.ToDouble(flightDataGridView.CurrentCell.Value);
            fixSpeed.setData(speed);
            fixSpeed.ShowDialog();
            speed = fixSpeed.getData();
            miLista.GetFlightPlanCart(e.RowIndex).SetSpeed(speed);
            UpdateDataGridView();
            }
            
        }
    }
}