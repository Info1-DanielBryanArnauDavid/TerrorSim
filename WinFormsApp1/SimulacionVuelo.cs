using Class;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Reflection;

namespace WinFormsApp1
{
    public partial class SimulacionVuelo : Form
    {
        private Image worldMap;
        private float zoom = 1.0f;
        private PointF panOffset = new PointF(0, 0);
        private bool isPanning = false;
        private Point lastMousePosition;
        private Matrix transformMatrix = new Matrix();
        FlightPlanList miLista = new FlightPlanList();
        int tiempoCiclo;
        int distSeg;
        PictureBox[] vuelos = new PictureBox[100];
        int numPics = 0;
        private List<FlightMarker> flightMarkers = new List<FlightMarker>();

        private class FlightMarker
        {
            public PictureBox Plane { get; set; }
            public PictureBox Origin { get; set; }
            public PictureBox Destination { get; set; }
            public FlightPlanCart FlightPlan { get; set; }

            public void UpdatePositions(Matrix transform)
            {
                PointF[] points = new PointF[] {
                    new PointF((float)FlightPlan.GetPlanePosition().GetX(), (float)FlightPlan.GetPlanePosition().GetY()),
                    new PointF((float)FlightPlan.GetOrigin().GetX(), (float)FlightPlan.GetOrigin().GetY()),
                    new PointF((float)FlightPlan.GetDestination().GetX(), (float)FlightPlan.GetDestination().GetY())
                };

                transform.TransformPoints(points);

                int markerSize = (int)(5 / Math.Sqrt(transform.Elements[0] * transform.Elements[0] +
                                                    transform.Elements[1] * transform.Elements[1]));
                markerSize = Math.Max(3, Math.Min(markerSize, 10)); // Limit size between 3 and 10 pixels

                Plane.Size = new Size(markerSize, markerSize);
                Origin.Size = new Size(markerSize, markerSize);
                Destination.Size = new Size(markerSize, markerSize);

                Plane.Location = Point.Round(points[0]);
                Origin.Location = Point.Round(points[1]);
                Destination.Location = Point.Round(points[2]);

                // Center the markers on their positions
                Plane.Location = new Point(Plane.Location.X - markerSize / 2, Plane.Location.Y - markerSize / 2);
                Origin.Location = new Point(Origin.Location.X - markerSize / 2, Origin.Location.Y - markerSize / 2);
                Destination.Location = new Point(Destination.Location.X - markerSize / 2, Destination.Location.Y - markerSize / 2);
            }
        }
        public SimulacionVuelo()
        {
            InitializeComponent();
            LoadWorldMap();
            SetupMapControls();

            // Enable double buffering using reflection
            typeof(Panel).GetProperty("DoubleBuffered",BindingFlags.Instance | BindingFlags.NonPublic).SetValue(miPanel, true, null);

            miPanel.Paint += MiPanel_Paint;
            hoverInfoLabel.AutoSize = true;
            hoverInfoLabel.ForeColor = Color.Black;
            hoverInfoLabel.BorderStyle = BorderStyle.FixedSingle;
            hoverInfoLabel.Visible = false;
            miPanel.Controls.Add(hoverInfoLabel);
            SetupDataGridView();
        }

        private void UpdateTransformMatrix()
        {
            transformMatrix.Reset();
            transformMatrix.Translate(panOffset.X, panOffset.Y);
            transformMatrix.Scale(zoom, zoom);

            // Update all flight markers with new transform
            foreach (var marker in flightMarkers)
            {
                marker.UpdatePositions(transformMatrix);
            }

            // Force a complete redraw
            miPanel.Invalidate(true);
            miPanel.Update();
        }

        private void LoadWorldMap()
        {
            // Load the world map image
            try
            {
                worldMap = Image.FromFile("C:\\Users\\bolty\\Desktop\\map.tif");
            }
            catch (Exception)
            {
                // Create a placeholder if map image is not found
                worldMap = new Bitmap(2048, 1024);
                using (Graphics g = Graphics.FromImage(worldMap))
                {
                    g.Clear(Color.LightBlue);
                    using (Pen pen = new Pen(Color.DarkGray))
                    {
                        for (int i = 0; i < worldMap.Width; i += 100)
                        {
                            g.DrawLine(pen, i, 0, i, worldMap.Height);
                        }
                        for (int i = 0; i < worldMap.Height; i += 100)
                        {
                            g.DrawLine(pen, 0, i, worldMap.Width, i);
                        }
                    }
                }
            }
        }

        private void SetupMapControls()
        {
            miPanel.MouseWheel += MiPanel_MouseWheel;
            miPanel.MouseDown += MiPanel_MouseDown;
            miPanel.MouseUp += MiPanel_MouseUp;
            miPanel.MouseMove += MiPanel_MouseMove;
        }

        private void MiPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            float oldZoom = zoom;
            if (e.Delta > 0)
                zoom *= 1.2f;
            else
                zoom /= 1.2f;

            // Limit zoom levels
            zoom = Math.Max(0.1f, Math.Min(5.0f, zoom));

            // Adjust pan offset to zoom towards mouse position
            Point mousePos = e.Location;
            panOffset.X = mousePos.X - (mousePos.X - panOffset.X) * (zoom / oldZoom);
            panOffset.Y = mousePos.Y - (mousePos.Y - panOffset.Y) * (zoom / oldZoom);

            UpdateTransformMatrix();
            miPanel.Invalidate();
        }

        private void MiPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isPanning = true;
                lastMousePosition = e.Location;
                miPanel.Cursor = Cursors.Hand;
            }
        }

        private void MiPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isPanning = false;
                miPanel.Cursor = Cursors.Default;
            }
        }

        private void MiPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPanning)
            {
                panOffset.X += e.X - lastMousePosition.X;
                panOffset.Y += e.Y - lastMousePosition.Y;
                lastMousePosition = e.Location;
                UpdateTransformMatrix();
                miPanel.Invalidate();
            }

            // Update coordinates label with transformed coordinates
            PointF worldCoords = TransformScreenToWorld(e.Location);
            label2.Text = $"X= {Math.Round(worldCoords.X, 2)} Y= {Math.Round(worldCoords.Y, 2)}";
        }

        private PointF TransformScreenToWorld(Point screenPoint)
        {
            Matrix inverse = transformMatrix.Clone();
            inverse.Invert();
            PointF[] points = { new PointF(screenPoint.X, screenPoint.Y) };
            inverse.TransformPoints(points);
            return points[0];
        }

        private Point TransformWorldToScreen(PointF worldPoint)
        {
            PointF[] points = { worldPoint };
            transformMatrix.TransformPoints(points);
            return Point.Round(points[0]);
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

            // Clear the entire panel with the background color
            g.Clear(miPanel.BackColor);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            // Save the original transform
            Matrix originalTransform = g.Transform;

            // Apply our transform
            g.Transform = transformMatrix;

            // Draw world map
            g.DrawImage(worldMap, 0, 0, miPanel.Width, miPanel.Height);

            using (Pen dottedPen = new Pen(Color.Green, 1 / zoom))
            {
                dottedPen.DashStyle = DashStyle.Dot;

                // Draw flight paths
                for (int i = 0; i < miLista.GetNumber(); i++)
                {
                    FlightPlanCart flight = miLista.GetFlightPlanCart(i);
                    WaypointCart origin = flight.GetOrigin();
                    WaypointCart destination = flight.GetDestination();

                    g.DrawLine(dottedPen,
                        new PointF((float)origin.GetX(), (float)origin.GetY()),
                        new PointF((float)destination.GetX(), (float)destination.GetY()));
                }
            }

            using (Pen redPen = new Pen(Color.Red, 1 / zoom))
            {
                // Draw security circles using world coordinates
                for (int i = 0; i < miLista.GetNumber(); i++)
                {
                    FlightPlanCart flight = miLista.GetFlightPlanCart(i);
                    float planeX = (float)flight.GetPlanePosition().GetX();
                    float planeY = (float)flight.GetPlanePosition().GetY();

                    RectangleF circleRect = new RectangleF(
                        planeX - distSeg,
                        planeY - distSeg,
                        distSeg * 2,
                        distSeg * 2
                    );

                    g.DrawEllipse(redPen, circleRect);
                }
            }

            // Restore the original transform
            g.Transform = originalTransform;
        }
        //Visualizar los vuelos
        private void Simulacion_Load(object sender, EventArgs e) { }

        private void SimulacionVuelo_Load_1(object sender, EventArgs e)
        {
            flightMarkers.Clear();

            for (int i = 0; i < miLista.GetNumber(); i++)
            {
                FlightPlanCart f = miLista.GetFlightPlanCart(i);

                var marker = new FlightMarker
                {
                    Plane = new PictureBox { BackColor = Color.Black },
                    Origin = new PictureBox { BackColor = Color.Red },
                    Destination = new PictureBox { BackColor = Color.Blue },
                    FlightPlan = f
                };

                // Set up event handlers for the plane marker
                marker.Plane.MouseMove += (s, ev) => ShowPlaneInfoAtMouse(f, ev);
                marker.Plane.MouseLeave += (s, ev) => HidePlaneInfo();

                // Add controls to panel
                miPanel.Controls.Add(marker.Plane);
                miPanel.Controls.Add(marker.Origin);
                miPanel.Controls.Add(marker.Destination);

                flightMarkers.Add(marker);
                vuelos[numPics] = marker.Plane;
                numPics++;
            }

            // Initial position update
            UpdateTransformMatrix();
            UpdateDataGridView();
        }



        private void ShowPlaneInfoAtMouse(FlightPlanCart flight, MouseEventArgs e)
        {
            string flightInfo = $"Name: {flight.GetFlightNumber()}\n" +
                              $"Origin: ({Math.Round(flight.GetOrigin().GetX(), 1)}, {Math.Round(flight.GetOrigin().GetY(), 1)})\n" +
                              $"Dest: ({Math.Round(flight.GetDestination().GetX(), 1)}, {Math.Round(flight.GetDestination().GetY(), 1)})\n" +
                              $"Pos: ({Math.Round(flight.GetPlanePosition().GetX(), 1)}, {Math.Round(flight.GetPlanePosition().GetY(), 1)})\n" +
                              $"Speed: {flight.GetSpeed()}";

            hoverInfoLabel.Text = flightInfo;
            Point cursorPositionInPanel = miPanel.PointToClient(Cursor.Position);
            hoverInfoLabel.Location = cursorPositionInPanel;
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
            // Suspend layout updates
            miPanel.SuspendLayout();

            for (int i = 0; i < miLista.GetNumber(); i++)
            {
                FlightPlanCart flight = miLista.GetFlightPlanCart(i);
                double angle = flight.GetAngle();
                double inc = flight.GetSpeed() * Convert.ToDouble(tiempoCiclo);
                double dx = inc * Math.Cos(angle);
                double dy = inc * Math.Sin(angle);
                flight.MovePlane(dx, dy);
            }

            // Update all marker positions
            UpdateTransformMatrix();
            UpdateDataGridView();

            bool v = CheckSecurityDistance(miLista.GetFlightPlanCart(0));
            label4.Text = v ? "Jodido" : "Guay";

            // Resume layout updates
            miPanel.ResumeLayout(true);
        }

        private void button2_Click(object sender, EventArgs e) { }
        private void label3_Paint(object sender, PaintEventArgs e) { }
        private void button1_Click_1(object sender, EventArgs e) { }
        private void timer1_Tick(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void MiPanel_Click_1(object sender, EventArgs e) { }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            miPanel.SuspendLayout();

            for (int i = 0; i < miLista.GetNumber(); i++)
            {
                FlightPlanCart flight = miLista.GetFlightPlanCart(i);
                double angle = flight.GetAngle();
                double inc = flight.GetSpeed() * Convert.ToDouble(tiempoCiclo);
                double dx = inc * Math.Cos(angle);
                double dy = inc * Math.Sin(angle);
                flight.MovePlane(dx, dy);
            }

            UpdateTransformMatrix();
            UpdateDataGridView();

            bool v = CheckSecurityDistance(miLista.GetFlightPlanCart(0));
            label4.Text = v ? "Jodido" : "Guay";

            miPanel.ResumeLayout(true);
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
            }

            // Update all marker positions
            UpdateTransformMatrix();
            miPanel.Invalidate();

            bool v = CheckSecurityDistance(miLista.GetFlightPlanCart(0));
            label4.Text = v ? "Jodido" : "Guay";

            UpdateDataGridView();
            timer1.Stop();
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
                double beta = 2 * topt * (rx * cosangle + ry * sinangle -
                                         topt * (v1x * cosangle + v1y * sinangle));
                double gamma = topt * topt * (v1x * v1x + v1y * v1y) -
                              2 * topt * (rx * v1x + ry * v1y) +
                              rx * rx + ry * ry -
                              4*distSeg * distSeg;

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
            UpdateTransformMatrix();
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