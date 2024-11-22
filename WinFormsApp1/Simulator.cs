using Class;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Markup;

namespace WinFormsApp1
{
    public partial class Simulator : Form
    {
        FlightPlanList miLista = new FlightPlanList();
        int tiempoCiclo;
        int distSeg;
        List<PictureBox> vuelos = new List<PictureBox>();
        Stack<FlightPlanList> EstadoVuelos = new Stack<FlightPlanList>();
        bool StatusBtn = false;
        double multiplicador = 1;
        int cuentaClicks = 1;
        float opacity = 1;
        FlightPlanCart selec1;
        FlightPlanCart selec2;

        public Simulator()
        {
            InitializeComponent();
            miPanel.Paint += MiPanel_Paint;
            hoverInfoLabel.AutoSize = true;
            hoverInfoLabel.BackColor = Color.White;
            hoverInfoLabel.ForeColor = Color.Black;
            hoverInfoLabel.BorderStyle = BorderStyle.FixedSingle;
            hoverInfoLabel.Visible = false;
            miPanel.Controls.Add(hoverInfoLabel);
            SetupDataGridView();
        }

        public FlightPlanList GetmiLista()
        { return this.miLista; }

        public List<PictureBox> Getvuelos()
        {
            return this.vuelos;
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

            // Draw flight paths
            using (Pen dottedPen = new Pen(Color.FromArgb(153, 255, 153)))
            {
                dottedPen.DashStyle = DashStyle.Dot;
                for (int i = 0; i < miLista.GetNumber(); i++)
                {
                    FlightPlanCart flight = miLista.GetFlightPlanCart(i);
                    WaypointCart origin = flight.GetOrigin();
                    WaypointCart destination = flight.GetDestination();
                    dottedPen.Color = Color.FromArgb((int)(255 * opacity), Color.Green);
                    g.DrawLine(dottedPen,
                        new Point((int)origin.GetX(), (int)origin.GetY()),
                        new Point((int)destination.GetX(), (int)destination.GetY()));
                }
            }

            bool anyViolation = false;

            // Draw security distance circles and check for violations
            using (Brush fillBrush = new SolidBrush(Color.FromArgb((int)(128 * opacity), Color.Red)))
            using (Pen outlinePen = new Pen(Color.FromArgb((int)(255 * opacity), Color.Red), 1))
            {
                for (int i = 0; i < miLista.GetNumber(); i++)
                {
                    FlightPlanCart flight = miLista.GetFlightPlanCart(i);
                    Point planeCenter = new Point(
                        Convert.ToInt32(flight.GetPlanePosition().GetX()),
                        Convert.ToInt32(flight.GetPlanePosition().GetY())
                    );
                    Rectangle circleRect = new Rectangle(
                        planeCenter.X - distSeg,
                        planeCenter.Y - distSeg,
                        distSeg * 2,
                        distSeg * 2
                    );

                    // Check if this flight violates security distance with any other flight
                    bool violatesSecurityDistance = CheckSecurityDistance(flight);

                    if (violatesSecurityDistance)
                    {
                        g.FillEllipse(fillBrush, circleRect);
                        anyViolation = true;
                    }
                    g.DrawEllipse(outlinePen, circleRect);
                }
            }

            // Update label4 text based on violations
            label4.Text = anyViolation ? "Jodido" : "Guay";

            // Draw plane images
            for (int i = 0; i < vuelos.Count; i++)
            {
                PictureBox planeIcon = vuelos[i];
                g.DrawImage(planeIcon.Image, planeIcon.Bounds);
            }
        }


        private void Simulacion_Load(object sender, EventArgs e) { }


        private void SimulacionVuelo_Load_1(object sender, EventArgs e)
        {
            // Set the application icon
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            for (int i = 0; i < miLista.GetNumber(); i++)
            {
                PictureBox p = new PictureBox();
                PictureBox a = new PictureBox();
                PictureBox v = new PictureBox();
                FlightPlanCart f = miLista.GetFlightPlanCart(i);

                // Configure PictureBox for the plane's origin

                p.Size = new Size(12, 12);
                p.Image = Properties.Resources.origin_marker; // Assuming OriginImage is your standard image for the origin
                p.SizeMode = PictureBoxSizeMode.StretchImage;
                p.Location = new Point(Convert.ToInt32(f.GetOrigin().GetX()) - p.Width / 2, Convert.ToInt32(f.GetOrigin().GetY()) - p.Height / 2);

                // Configure PictureBox for the plane's destination
                a.Size = new Size(12, 12);
                a.Image = Properties.Resources.final_marker; // Assuming DestinationImage is your standard image for the destination
                a.SizeMode = PictureBoxSizeMode.StretchImage;
                a.Location = new Point(Convert.ToInt32(f.GetDestination().GetX()) - a.Width / 2, Convert.ToInt32(f.GetDestination().GetY()) - a.Height / 2);

                // Configure PictureBox for the plane itself
                v.Size = new Size(20, 20); // Increase plane size for better visibility
                v.BackColor = Color.Transparent;
                v.Image = Properties.Resources.plane_icon;
                v.SizeMode = PictureBoxSizeMode.StretchImage;

                // Calculate the plane's initial position
                v.Location = new Point(
                    Convert.ToInt32(f.GetPlanePosition().GetX() - v.Width / 2),
                    Convert.ToInt32(f.GetPlanePosition().GetY() - v.Height / 2)
                );

                // Rotate the plane image based on its trajectory
                float angle = GetPlaneAngle(f.GetOrigin(), f.GetDestination());
                v.Image = RotateImage(v.Image, angle);

                // Add event handlers for hover information
                v.MouseMove += (s, ev) => ShowPlaneInfoAtMouse(f, ev);
                v.MouseLeave += (s, ev) => HidePlaneInfo();

                // Add PictureBoxes to the panel
                vuelos.Add(v);
                miPanel.Controls.Add(v);
                miPanel.Controls.Add(p);
                miPanel.Controls.Add(a);
            }

            UpdateDataGridView();
            InitializeCheckedListBox();
            UpdateFlightHighlight();
        }

        private float GetPlaneAngle(WaypointCart origin, WaypointCart destination)
        {
            double deltaX = destination.GetX() - origin.GetX();
            double deltaY = destination.GetY() - origin.GetY();

            // Handle special cases to avoid division by zero
            if (deltaX == 0)
            {
                return deltaY > 0 ? 180 : 0;
            }

            // Calculate the angle in radians, then convert to degrees
            float angle = (float)(Math.Atan2(deltaY, deltaX) * (180 / Math.PI) + 90);

            return angle;
        }

        // Helper method to rotate an image by a specified angle
        private Image RotateImage(Image image, float angle)
        {
            // Create a new bitmap with the same size as the original image
            Bitmap rotatedImage = new Bitmap(image.Width, image.Height);
            rotatedImage.MakeTransparent(); // Ensure transparency is maintained

            // Create a Graphics object to perform the rotation
            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                g.Clear(Color.Transparent); // Make the entire background transparent
                g.SmoothingMode = SmoothingMode.AntiAlias; // Smooth edges

                // Move the origin of the rotation to the center of the image
                g.TranslateTransform(rotatedImage.Width / 2, rotatedImage.Height / 2);

                // Rotate the image
                g.RotateTransform(angle);

                // Draw the original image, centered on the new rotated canvas
                g.DrawImage(image, new Point(-image.Width / 2, -image.Height / 2));
            }

            return rotatedImage;
        }

        private void InitializeCheckedListBox()
        {
            checkedListBox1.Items.Clear();
            checkedListBox1.CheckOnClick = true;

            // Add flight plans to the CheckedListBox (assuming miLista is a list of FlightPlanCart)
            for (int i = 0; i < miLista.GetNumber(); i++)
            {
                FlightPlanCart flight = miLista.GetFlightPlanCart(i);
                checkedListBox1.Items.Add(flight.GetFlightNumber(), false);  // Add the flight ID to the CheckedListBox
            }

            // Attach the ItemCheck event handler to manage check/uncheck logic
            checkedListBox1.ItemCheck += CheckedListBox1_ItemCheck;
        }
        private void CheckedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Get the count of checked items before this click
            int checkedCount = checkedListBox1.CheckedItems.Count;

            // If the new value is 'Checked' and more than 2 items are checked, prevent the check
            if (e.NewValue == CheckState.Checked && checkedCount >= 2)
            {
                e.NewValue = CheckState.Unchecked;
            }

            // Use BeginInvoke to ensure the checked state is updated before calling UpdateFlightHighlight
            BeginInvoke(new Action(() =>
            {
                UpdateFlightHighlight();
                UpdateSelectedFlights();
            }));
        }

        private void UpdateFlightHighlight()
        {
            for (int i = 0; i < miLista.GetNumber(); i++)
            {
                FlightPlanCart flight = miLista.GetFlightPlanCart(i);
                PictureBox planeIcon = vuelos[i];
                bool isChecked = checkedListBox1.GetItemChecked(i);

                if (isChecked)
                {
                    int highlightSize = 40;
                    Bitmap highlightedPlane = new Bitmap(highlightSize, highlightSize);
                    using (Graphics g = Graphics.FromImage(highlightedPlane))
                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        using (SolidBrush brush = new SolidBrush(Color.FromArgb(70, 255, 255, 0)))
                        {
                            g.FillEllipse(brush, 0, 0, highlightSize, highlightSize);
                        }
                        float angle = GetPlaneAngle(flight.GetOrigin(), flight.GetDestination());
                        Image rotatedPlane = RotateImage(Properties.Resources.plane_icon, angle);
                        g.DrawImage(rotatedPlane, (highlightSize - 15) / 2, (highlightSize - 15) / 2, 15, 15);
                    }
                    planeIcon.Image = highlightedPlane;
                    planeIcon.Size = new Size(highlightSize, highlightSize);
                }
                else
                {
                    float angle = GetPlaneAngle(flight.GetOrigin(), flight.GetDestination());
                    planeIcon.Image = RotateImage(Properties.Resources.plane_icon, angle);
                    planeIcon.Size = new Size(10, 10); // Original size when unchecked
                }

                // Update position based on current size
                planeIcon.Location = new Point(
                    Convert.ToInt32(flight.GetPlanePosition().GetX() - planeIcon.Width / 2),
                    Convert.ToInt32(flight.GetPlanePosition().GetY() - planeIcon.Height / 2)
                );
            }

            miPanel.Invalidate(); // Ensure the panel repaints to show changes
        }
        private void UpdateSelectedFlights()
        {
            selec1 = null;
            selec2 = null;

            if (checkedListBox1.CheckedItems.Count == 2)
            {
                int index1 = checkedListBox1.Items.IndexOf(checkedListBox1.CheckedItems[0]);
                int index2 = checkedListBox1.Items.IndexOf(checkedListBox1.CheckedItems[1]);
                selec1 = miLista.GetFlightPlanCart(index1);
                selec2 = miLista.GetFlightPlanCart(index2);
            }
        }


        private void button4_Click(object sender, EventArgs e) // Predict Collision Button
        {
            // First, update selec1 and selec2 based on the checked items in the CheckedListBox
            UpdateSelectedFlights();

            // Ensure both selec1 and selec2 are selected before proceeding
            if (selec1 != null && selec2 != null)
            {
                // Restart the flight plans and update the locations
                for (int i = 0; i < miLista.GetNumber(); i++)
                {
                    miLista.GetFlightPlanCart(i).Restart();
                    FlightPlanCart flight = miLista.GetFlightPlanCart(i);
                    vuelos[i].Location = new Point(
                     Convert.ToInt32(flight.GetPlanePosition().GetX() - vuelos[i].Width / 2),
                     Convert.ToInt32(flight.GetPlanePosition().GetY()) - vuelos[i].Height / 2
                      );
                }

                // Update opacity for all the items (except the selected ones)

                // Call the collision prediction method
                bool collisionPredicted = PredictCollision(selec1, selec2);

                // Update the UI based on the result of the collision prediction
                if (collisionPredicted)
                {
                    label5.Text = "Posible Accidente";
                    button5.Enabled = true; // Enable the button if a collision is predicted
                }
                else
                {
                    label5.Text = "Seguro";
                    button5.Enabled = false; // Disable the button if no collision is predicted
                }

                // Update the DataGridView and stop the timer
                UpdateDataGridView();
                timer1.Stop();
                miPanel.Invalidate(); // Ensure panel repaint to apply opacity changes
            }
            else
            {
                // If not exactly two flights are selected, show a message
                MessageBox.Show("Please select exactly two flights to check for a collision.");
            }
        }

        private void ShowPlaneInfoAtMouse(FlightPlanCart flight, MouseEventArgs e)
        {
            string flightInfo = $"Name: {flight.GetFlightNumber()}\n" +
                                $"Origin: ({flight.GetOrigin().GetX()}, {flight.GetOrigin().GetY()})\n" +
                                $"Dest: ({flight.GetDestination().GetX()}, {flight.GetDestination().GetY()})\n" +
                                $"Pos: ({Math.Round(flight.GetPlanePosition().GetX(), 1)}, {Math.Round(flight.GetPlanePosition().GetY(), 1)})\n" +
                                $"Speed: {flight.GetSpeed()}";

            hoverInfoLabel.Text = flightInfo;

            // Customize label appearance
            hoverInfoLabel.BackColor = Color.White;
            hoverInfoLabel.BorderStyle = BorderStyle.FixedSingle;
            hoverInfoLabel.ForeColor = Color.Black;

            // Position label slightly offset from cursor
            Point cursorPositionInPanel = miPanel.PointToClient(Cursor.Position);
            hoverInfoLabel.Location = new Point(cursorPositionInPanel.X + 10, cursorPositionInPanel.Y + 10);

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

            if (!StatusBtn)
            {
                int PlanesInDestination = 0;
                FlightPlanList EstadoAnterior = new FlightPlanList();
                for (int i = 0; i < miLista.GetNumber(); i++)
                {
                    WaypointCart Posicion = new WaypointCart(miLista.GetFlightPlanCart(i).GetPlanePosition().GetX(), miLista.GetFlightPlanCart(i).GetPlanePosition().GetY());
                    FlightPlanCart vuelo = new FlightPlanCart(miLista.GetFlightPlanCart(i).GetFlightNumber(), miLista.GetFlightPlanCart(i).GetOrigin(), miLista.GetFlightPlanCart(i).GetDestination(), miLista.GetFlightPlanCart(i).GetSpeed());
                    vuelo.SetPlanePosition(Posicion);
                    EstadoAnterior.AddFlightPlan(vuelo);
                    FlightPlanCart flight = miLista.GetFlightPlanCart(i);
                    flight.MovePlane(flight.GetSpeed() * tiempoCiclo * Math.Cos(flight.GetAngle()), flight.GetSpeed() * tiempoCiclo * Math.Sin(flight.GetAngle()));
                    vuelos[i].Location = new Point(
                     Convert.ToInt32(flight.GetPlanePosition().GetX() - vuelos[i].Width / 2),
                     Convert.ToInt32(flight.GetPlanePosition().GetY()) - vuelos[i].Height / 2
                      );
                    if (flight.GetPlanePosition().GetX() == miLista.GetFlightPlanCart(i).GetDestination().GetX() && flight.GetPlanePosition().GetY() == miLista.GetFlightPlanCart(i).GetDestination().GetY())
                    {
                        PlanesInDestination++;
                    }
                }
                if (PlanesInDestination != miLista.GetNumber())
                {
                    EstadoVuelos.Push(EstadoAnterior);
                }
                else
                {
                    button1.Enabled = false;
                }
                miPanel.Invalidate();
                UpdateDataGridView();
                bool v = CheckSecurityDistance(miLista.GetFlightPlanCart(0));
                button6.Enabled = true;
            }
            else
            {
                if (tiempoCiclo == 0) { tiempoCiclo = 1; }
                timer1.Interval = Convert.ToInt32(1000 / multiplicador) * tiempoCiclo;
                if (timer1.Enabled)
                {
                    button6.Enabled = true;
                    checkBox1.Enabled = true;
                    timer1.Stop();
                    button1.Text = "Avanzar";
                }
                else
                {
                    button6.Enabled = false;
                    checkBox1.Enabled = false;
                    timer1.Start();
                    button1.Text = "Stop";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) // Reset Button
        {
            for (int i = 0; i < miLista.GetNumber(); i++)
            {
                miLista.GetFlightPlanCart(i).Restart();
                FlightPlanCart flight = miLista.GetFlightPlanCart(i);
                vuelos[i].Location = new Point(
                 Convert.ToInt32(flight.GetPlanePosition().GetX() - vuelos[i].Width / 2),
                 Convert.ToInt32(flight.GetPlanePosition().GetY()) - vuelos[i].Height / 2
                  );
            }
            cuentaClicks = 1;
            button8.Text = "x1";
            button1.Text = "Avanzar";
            button6.Text = "Retroceder";
            EstadoVuelos = new Stack<FlightPlanList>();
            bool v = CheckSecurityDistance(miLista.GetFlightPlanCart(0));
            UpdateDataGridView();
            timer1.Stop();
            miPanel.Invalidate();
        }

        private bool PredictCollision(FlightPlanCart flight1, FlightPlanCart flight2)
        {
            double rx = flight2.GetPlanePosition().GetX() - flight1.GetPlanePosition().GetX();
            double ry = flight2.GetPlanePosition().GetY() - flight1.GetPlanePosition().GetY();
            double vx = flight2.GetSpeed() * Math.Cos(flight2.GetAngle()) - flight1.GetSpeed() * Math.Cos(flight1.GetAngle());
            double vy = flight2.GetSpeed() * Math.Sin(flight2.GetAngle()) - flight1.GetSpeed() * Math.Sin(flight1.GetAngle());

            double t = -(rx * vx + ry * vy) / (vx * vx + vy * vy);

            if (t < 0) return false;

            double cx = rx + vx * t;
            double cy = ry + vy * t;

            return (cx * cx + cy * cy < distSeg * 4 * distSeg);
        }

        private double OptVel(FlightPlanCart flight1, FlightPlanCart flight2)
        {
            return miLista.OptimalVelocity(flight1, flight2, distSeg);
        }

        private void flightDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e) // Optimize Speed Button
        {
            double optSpeed = OptVel(selec1, selec2);
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i) && i != vuelos.Count())
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }
            UpdateFlightHighlight();

            if (optSpeed == -1)
            {
                Imposible imp = new Imposible();
                imp.ShowDialog();
            }
            else
            {
                selec1.SetSpeed(Math.Round(optSpeed, 2));
                for (int i = 0; i < miLista.GetNumber(); i++)
                {
                    miLista.GetFlightPlanCart(i).Restart();
                    FlightPlanCart flight = miLista.GetFlightPlanCart(i);
                    vuelos[i].Location = new Point(
                     Convert.ToInt32(flight.GetPlanePosition().GetX() - vuelos[i].Width / 2),
                     Convert.ToInt32(flight.GetPlanePosition().GetY() - vuelos[i].Height / 2));
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            int PlanesInDestination = 0;
            FlightPlanList EstadoAnterior = new FlightPlanList();

            for (int i = 0; i < miLista.GetNumber(); i++)
            {

                WaypointCart Posicion = new WaypointCart(miLista.GetFlightPlanCart(i).GetPlanePosition().GetX(), miLista.GetFlightPlanCart(i).GetPlanePosition().GetY());
                FlightPlanCart vuelo = new FlightPlanCart(miLista.GetFlightPlanCart(i).GetFlightNumber(), miLista.GetFlightPlanCart(i).GetOrigin(), miLista.GetFlightPlanCart(i).GetDestination(), miLista.GetFlightPlanCart(i).GetSpeed());
                vuelo.SetPlanePosition(Posicion);
                EstadoAnterior.AddFlightPlan(vuelo);
                FlightPlanCart flight = miLista.GetFlightPlanCart(i);
                flight.MovePlane(flight.GetSpeed() * tiempoCiclo * Math.Cos(flight.GetAngle()), flight.GetSpeed() * tiempoCiclo * Math.Sin(flight.GetAngle()));
                vuelos[i].Location = new Point(
                 Convert.ToInt32(flight.GetPlanePosition().GetX() - vuelos[i].Width / 2),
                 Convert.ToInt32(flight.GetPlanePosition().GetY() - vuelos[i].Height / 2)
                  );
                if (flight.GetPlanePosition().GetX() == miLista.GetFlightPlanCart(i).GetDestination().GetX() && flight.GetPlanePosition().GetY() == miLista.GetFlightPlanCart(i).GetDestination().GetY())
                {
                    PlanesInDestination++;
                }
            }
            if (PlanesInDestination != miLista.GetNumber())
            {
                EstadoVuelos.Push(EstadoAnterior);
            }
            else
            {
                button1.Enabled = false;
                timer1.Stop();
                button1.Text = "Avanzar";
                button6.Enabled = true;
                checkBox1.Enabled = true;
            }
            EstadoVuelos.Push(EstadoAnterior);
            miPanel.Invalidate();
            UpdateDataGridView();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!StatusBtn)
            {
                button6.Enabled = true;
                button1.Enabled = true;
                timer1.Stop();
                if (EstadoVuelos.Count > 0)
                {
                    miLista = EstadoVuelos.Pop();
                    for (int i = 0; i < miLista.GetNumber(); i++)
                    {
                        FlightPlanCart flight = miLista.GetFlightPlanCart(i);
                        vuelos[i].Location = new Point(Convert.ToInt32(flight.GetPlanePosition().GetX() - vuelos[i].Width / 2),
                     Convert.ToInt32(flight.GetPlanePosition().GetY()) - vuelos[i].Height / 2
                      );
                    }
                    miPanel.Invalidate();
                    UpdateDataGridView();
                }
                else
                {
                    button6.Enabled = false;
                    button1.Enabled = true;
                    checkBox1.Enabled = true;
                }
            }
            else
            {
                timer2.Interval = Convert.ToInt32(1000 / multiplicador) * tiempoCiclo;
                if (timer2.Enabled)
                {
                    button1.Enabled = true;
                    checkBox1.Enabled = true;
                    timer2.Stop();
                    button6.Text = "Retroceder";
                }
                else
                {
                    button1.Enabled = false;
                    checkBox1.Enabled = false;
                    timer2.Start();
                    button6.Text = "Stop";
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Text = "Automático";
                StatusBtn = true;
                button8.Enabled = true;
                button8.Visible = true;
                multiplicador = 1;
                cuentaClicks = 1;
                button8.Text = "x1";
            }
            else
            {
                checkBox1.Text = "Manual";
                timer1.Stop();
                StatusBtn = false;
                button8.Enabled = false;
                button8.Visible = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            if (EstadoVuelos.Count > 0)
            {
                miLista = EstadoVuelos.Pop();
                for (int i = 0; i < miLista.GetNumber(); i++)
                {
                    FlightPlanCart flight = miLista.GetFlightPlanCart(i);
                    vuelos[i].Location = new Point(Convert.ToInt32(flight.GetPlanePosition().GetX()), Convert.ToInt32(flight.GetPlanePosition().GetY()));
                }
                miPanel.Invalidate();
                UpdateDataGridView();
            }
            else
            {
                timer2.Stop();
                button6.Text = "Retroceder";
                button6.Enabled = false;
                button1.Enabled = true;
                checkBox1.Enabled = true;
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            double[] values = [0.5, 1, 2, 4];
            cuentaClicks++;
            if (cuentaClicks == 4)
            {
                cuentaClicks = 0;
            }
            button8.Text = "x" + Convert.ToString(values[cuentaClicks]);
            setMultiplicador(values[cuentaClicks]);
            if (timer1.Enabled)
            {
                timer1.Interval = Convert.ToInt32(1000 / multiplicador) * tiempoCiclo;
            }
            if (timer2.Enabled)
            {
                timer2.Interval = Convert.ToInt32(1000 / multiplicador) * tiempoCiclo;
            }

        }

        public void setMultiplicador(double num)
        {
            multiplicador = num;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string archivo = saveFileDialog.FileName;
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(archivo))
                        {
                            foreach (var flightPlan in miLista.GetFlightPlans()) // Assuming you have a method GetFlightPlans that returns all the flight plans
                            {
                                string ID = flightPlan.GetFlightNumber();
                                WaypointCart origin = flightPlan.GetOrigin();
                                WaypointCart destination = flightPlan.GetDestination();
                                double speed = flightPlan.GetSpeed();

                                // Write the data for each flight plan in a formatted way
                                sw.WriteLine($"{ID} {origin.GetX()} {origin.GetY()} {destination.GetX()} {destination.GetY()} {speed}");
                            }

                            MessageBox.Show("Datos guardados correctamente");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any errors that occur during the file writing process
                        MessageBox.Show($"Error al guardar el archivo: {ex.Message}");
                    }
                }
            }


        }


        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void hoverInfoLabel_Click(object sender, EventArgs e)
        {

        }

    }

}