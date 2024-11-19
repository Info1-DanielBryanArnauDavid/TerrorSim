using Class;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Simulator : Form
    {
        FlightPlanList miLista = new FlightPlanList();
        int tiempoCiclo;
        int distSeg;
        List<PictureBox> vuelos = new List<PictureBox>();

        public FlightPlanList GetmiLista()
        { return miLista; }

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

        public void setData(FlightPlanList f, int c, int dist)
        {
            miLista = f;
            tiempoCiclo = c;
            distSeg = dist;
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
            return miLista.CheckSecurityDistance(flightToCheck, distSeg);
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

                    g.DrawLine(dottedPen,
                        new Point((int)origin.GetX(), (int)origin.GetY()),
                        new Point((int)destination.GetX(), (int)destination.GetY()));
                }
            }

            using (Pen redPen = new Pen(Color.Red, 1))
            {
                for (int i = 0; i < vuelos.Count; i++)
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

                // Configure PictureBox
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
                vuelos.Add(v);
                miPanel.Controls.Add(v);
                miPanel.Controls.Add(p);
                miPanel.Controls.Add(a);
            }
            UpdateDataGridView();
        }

        private void ShowPlaneInfoAtMouse(FlightPlanCart flight, MouseEventArgs e)
        {
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

        private void button1_Click(object sender, EventArgs e) // Manual Move Button
        {
            for (int i = 0; i < miLista.GetNumber(); i++)
            {
                FlightPlanCart flight = miLista.GetFlightPlanCart(i);
                flight.MovePlane(flight.GetSpeed() * tiempoCiclo * Math.Cos(flight.GetAngle()), flight.GetSpeed() * tiempoCiclo * Math.Sin(flight.GetAngle()));
                vuelos[i].Location = new Point(Convert.ToInt32(flight.GetPlanePosition().GetX()), Convert.ToInt32(flight.GetPlanePosition().GetY()));
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

        private void button2_Click_1(object sender, EventArgs e) // Auto Move Button
        {
            timer1.Interval = 1000 * tiempoCiclo;
            if (timer1.Enabled)
            {
                timer1.Stop();
                button2.Text = "Auto";
            }
            else
            {
                timer1.Start();
                button2.Text = "Stop";
            }
        }

        private void button3_Click(object sender, EventArgs e) // Reset Button
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
        }

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

                    if (cx * cx + cy * cy < distSeg * 4 * distSeg)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private double OptVel(FlightPlanCart flight1, FlightPlanCart flight2)
        {
            return miLista.OptimalVelocity(flight1, flight2, distSeg);
        }

        private void button4_Click(object sender, EventArgs e) // Predict Collision Button
        {
            for (int i = 0; i < miLista.GetNumber(); i++)
            {
                miLista.GetFlightPlanCart(i).Restart();
                vuelos[i].Location = new Point(Convert.ToInt32(miLista.GetFlightPlanCart(i).GetPlanePosition().GetX()), Convert.ToInt32(miLista.GetFlightPlanCart(i).GetPlanePosition().GetY()));
            }
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
            UpdateDataGridView();
            timer1.Stop();
            miPanel.Invalidate();
        }

        private void flightDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e) // Optimize Speed Button
        {
            double optSpeed = OptVel(miLista.GetFlightPlanCart(0), miLista.GetFlightPlanCart(1));

            if (optSpeed == -1)
            {
                Imposible imp = new Imposible();
                imp.ShowDialog();
            }
            else
            {
                miLista.GetFlightPlanCart(1).SetSpeed(Math.Round(optSpeed, 2));
                for (int i = 0; i < miLista.GetNumber(); i++)
                {
                    miLista.GetFlightPlanCart(i).Restart();
                    vuelos[i].Location = new Point(Convert.ToInt32(miLista.GetFlightPlanCart(i).GetPlanePosition().GetX()), Convert.ToInt32(miLista.GetFlightPlanCart(i).GetPlanePosition().GetY()));
                }
                label5.Text = "Seguro";
                button5.Enabled = false;
                UpdateDataGridView();
                timer1.Stop();
                miPanel.Invalidate();
            }
        }

        private void flightDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
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

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            for (int i = 0; i < miLista.GetNumber(); i++)
            {
                FlightPlanCart flight = miLista.GetFlightPlanCart(i);
                flight.MovePlane(flight.GetSpeed() * tiempoCiclo * Math.Cos(flight.GetAngle()), flight.GetSpeed() * tiempoCiclo * Math.Sin(flight.GetAngle()));
                vuelos[i].Location = new Point(Convert.ToInt32(flight.GetPlanePosition().GetX()), Convert.ToInt32(flight.GetPlanePosition().GetY()));
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void miPanel_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonGuardarSim_Click(object sender, EventArgs e)
        {
            Guardar g = new Guardar(GetmiLista());
            g.ShowDialog();
        }
    }
}