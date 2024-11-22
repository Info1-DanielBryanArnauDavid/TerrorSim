namespace WinFormsApp1
{
    partial class Simulator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            miPanel = new PictureBox();
            button1 = new Button();
            button3 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            toolTip1 = new ToolTip(components);
            hoverInfoLabel = new Label();
            label1 = new Label();
            flightDataGridView = new DataGridView();
            label4 = new Label();
            button4 = new Button();
            label5 = new Label();
            label6 = new Label();
            button5 = new Button();
            button6 = new Button();
            checkBox1 = new CheckBox();
            timer2 = new System.Windows.Forms.Timer(components);
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            button8 = new Button();
            button2 = new Button();
            checkedListBox1 = new CheckedListBox();
            label8 = new Label();
            menuStrip1 = new MenuStrip();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            addFlightPlanToolStripMenuItem = new ToolStripMenuItem();
            addPointToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            zoomInToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)miPanel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)flightDataGridView).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // miPanel
            // 
            miPanel.BorderStyle = BorderStyle.FixedSingle;
            miPanel.Cursor = Cursors.Cross;
            miPanel.Location = new Point(10, 26);
            miPanel.Margin = new Padding(3, 2, 3, 2);
            miPanel.Name = "miPanel";
            miPanel.Size = new Size(1270, 512);
            miPanel.TabIndex = 0;
            miPanel.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(18, 607);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(82, 45);
            button1.TabIndex = 1;
            button1.Text = "Avanzar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(847, 580);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(98, 28);
            button3.TabIndex = 3;
            button3.Text = "Reset";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // hoverInfoLabel
            // 
            hoverInfoLabel.AutoSize = true;
            hoverInfoLabel.Location = new Point(18, 17);
            hoverInfoLabel.Name = "hoverInfoLabel";
            hoverInfoLabel.Size = new Size(38, 15);
            hoverInfoLabel.TabIndex = 5;
            hoverInfoLabel.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(256, 555);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 6;
            label1.Text = "Flight Data";
            // 
            // flightDataGridView
            // 
            flightDataGridView.AllowUserToAddRows = false;
            flightDataGridView.AllowUserToDeleteRows = false;
            flightDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            flightDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            flightDataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            flightDataGridView.Location = new Point(256, 573);
            flightDataGridView.Name = "flightDataGridView";
            flightDataGridView.RowHeadersWidth = 20;
            flightDataGridView.Size = new Size(575, 88);
            flightDataGridView.TabIndex = 8;
            flightDataGridView.CellContentDoubleClick += flightDataGridView_CellContentDoubleClick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(426, 555);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 9;
            label4.Text = "Chuli";
            // 
            // button4
            // 
            button4.Location = new Point(976, 609);
            button4.Name = "button4";
            button4.Size = new Size(82, 36);
            button4.TabIndex = 10;
            button4.Text = "Check";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(960, 555);
            label5.Name = "label5";
            label5.Size = new Size(0, 15);
            label5.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(370, 555);
            label6.Name = "label6";
            label6.Size = new Size(50, 15);
            label6.TabIndex = 12;
            label6.Text = "STATUS";
            // 
            // button5
            // 
            button5.Enabled = false;
            button5.Location = new Point(976, 652);
            button5.Name = "button5";
            button5.Size = new Size(82, 23);
            button5.TabIndex = 14;
            button5.Text = "Fix";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(120, 607);
            button6.Margin = new Padding(3, 2, 3, 2);
            button6.Name = "button6";
            button6.Size = new Size(82, 45);
            button6.TabIndex = 16;
            button6.Text = "Retroceder";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(68, 579);
            checkBox1.Margin = new Padding(3, 2, 3, 2);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(66, 19);
            checkBox1.TabIndex = 17;
            checkBox1.Text = "Manual";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // timer2
            // 
            timer2.Tick += timer2_Tick;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(18, 558);
            label9.Name = "label9";
            label9.Size = new Size(40, 15);
            label9.TabIndex = 18;
            label9.Text = "Move:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(18, 580);
            label10.Name = "label10";
            label10.Size = new Size(41, 15);
            label10.TabIndex = 19;
            label10.Text = "Mode:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(969, 588);
            label11.Name = "label11";
            label11.Size = new Size(89, 15);
            label11.TabIndex = 20;
            label11.Text = "Check for pairs:";
            // 
            // button8
            // 
            button8.Location = new Point(147, 576);
            button8.Margin = new Padding(3, 2, 3, 2);
            button8.Name = "button8";
            button8.Size = new Size(55, 22);
            button8.TabIndex = 21;
            button8.UseVisualStyleBackColor = true;
            button8.Visible = false;
            button8.Click += button8_Click;
            // 
            // button2
            // 
            button2.Location = new Point(847, 613);
            button2.Name = "button2";
            button2.Size = new Size(98, 28);
            button2.TabIndex = 22;
            button2.Text = "Save FlightPlan";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(1096, 555);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(184, 112);
            checkedListBox1.TabIndex = 23;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label8.Location = new Point(976, 573);
            label8.Name = "label8";
            label8.Size = new Size(66, 15);
            label8.TabIndex = 24;
            label8.Text = "Select 2 IDs";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { optionsToolStripMenuItem, viewToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1292, 24);
            menuStrip1.TabIndex = 25;
            menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addFlightPlanToolStripMenuItem, addPointToolStripMenuItem });
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(61, 20);
            optionsToolStripMenuItem.Text = "Options";
            // 
            // addFlightPlanToolStripMenuItem
            // 
            addFlightPlanToolStripMenuItem.Name = "addFlightPlanToolStripMenuItem";
            addFlightPlanToolStripMenuItem.Size = new Size(155, 22);
            addFlightPlanToolStripMenuItem.Text = "Add Flight Plan";
            // 
            // addPointToolStripMenuItem
            // 
            addPointToolStripMenuItem.Name = "addPointToolStripMenuItem";
            addPointToolStripMenuItem.Size = new Size(155, 22);
            addPointToolStripMenuItem.Text = "Add Point";
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { zoomInToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(44, 20);
            viewToolStripMenuItem.Text = "View";
            // 
            // zoomInToolStripMenuItem
            // 
            zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            zoomInToolStripMenuItem.Size = new Size(106, 22);
            zoomInToolStripMenuItem.Text = "Zoom";
            // 
            // Simulator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1292, 687);
            Controls.Add(label8);
            Controls.Add(checkedListBox1);
            Controls.Add(button2);
            Controls.Add(button8);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(checkBox1);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(button4);
            Controls.Add(label4);
            Controls.Add(flightDataGridView);
            Controls.Add(label1);
            Controls.Add(hoverInfoLabel);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(miPanel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Simulator";
            Text = "SimulacionVuelo";
            Load += SimulacionVuelo_Load_1;
            ((System.ComponentModel.ISupportInitialize)miPanel).EndInit();
            ((System.ComponentModel.ISupportInitialize)flightDataGridView).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox miPanel;
        private Button button1;
        private Button button3;
        private System.Windows.Forms.Timer timer1;
        private ToolTip toolTip1;
        private Label hoverInfoLabel;
        private Label label1;
        private DataGridView flightDataGridView;
        private Label label4;
        private Button button4;
        private Label label5;
        private Label label6;
        private Button button5;
        private Button button6;
        private CheckBox checkBox1;
        private System.Windows.Forms.Timer timer2;
        private Label label9;
        private Label label10;
        private Label label11;
        private Button button8;
        private Button button2;
        private CheckedListBox checkedListBox1;
        private Label label8;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem addFlightPlanToolStripMenuItem;
        private ToolStripMenuItem addPointToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem zoomInToolStripMenuItem;
    }
}