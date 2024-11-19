namespace WinFormsApp1
{
    partial class MainForm
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
            menuStrip1 = new MenuStrip();
            opcionesToolStripMenuItem = new ToolStripMenuItem();
            introducirFlightPlansToolStripMenuItem = new ToolStripMenuItem();
            fromFileToolStripMenuItem = new ToolStripMenuItem();
            flightPlanPairToolStripMenuItem = new ToolStripMenuItem();
            introducirDistanciaDeSeguridadYTiempoDeCicloToolStripMenuItem = new ToolStripMenuItem();
            simulatorToolStripMenuItem = new ToolStripMenuItem();
            openSimToolStripMenuItem = new ToolStripMenuItem();
            linkLabel1 = new LinkLabel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { opcionesToolStripMenuItem, simulatorToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(481, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            opcionesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { introducirFlightPlansToolStripMenuItem, introducirDistanciaDeSeguridadYTiempoDeCicloToolStripMenuItem });
            opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            opcionesToolStripMenuItem.Size = new Size(41, 20);
            opcionesToolStripMenuItem.Text = "Add";
            // 
            // introducirFlightPlansToolStripMenuItem
            // 
            introducirFlightPlansToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { fromFileToolStripMenuItem, flightPlanPairToolStripMenuItem });
            introducirFlightPlansToolStripMenuItem.Name = "introducirFlightPlansToolStripMenuItem";
            introducirFlightPlansToolStripMenuItem.Size = new Size(180, 22);
            introducirFlightPlansToolStripMenuItem.Text = "Insert Flight Plans";
            introducirFlightPlansToolStripMenuItem.Click += introducirFlightPlansToolStripMenuItem_Click;
            // 
            // fromFileToolStripMenuItem
            // 
            fromFileToolStripMenuItem.Name = "fromFileToolStripMenuItem";
            fromFileToolStripMenuItem.Size = new Size(180, 22);
            fromFileToolStripMenuItem.Text = "From File";
            fromFileToolStripMenuItem.Click += fromFileToolStripMenuItem_Click;
            // 
            // flightPlanPairToolStripMenuItem
            // 
            flightPlanPairToolStripMenuItem.Name = "flightPlanPairToolStripMenuItem";
            flightPlanPairToolStripMenuItem.Size = new Size(180, 22);
            flightPlanPairToolStripMenuItem.Text = "Flight Plan Pair";
            flightPlanPairToolStripMenuItem.Click += flightPlanPairToolStripMenuItem_Click;
            // 
            // introducirDistanciaDeSeguridadYTiempoDeCicloToolStripMenuItem
            // 
            introducirDistanciaDeSeguridadYTiempoDeCicloToolStripMenuItem.Name = "introducirDistanciaDeSeguridadYTiempoDeCicloToolStripMenuItem";
            introducirDistanciaDeSeguridadYTiempoDeCicloToolStripMenuItem.Size = new Size(180, 22);
            introducirDistanciaDeSeguridadYTiempoDeCicloToolStripMenuItem.Text = "Parameters";
            introducirDistanciaDeSeguridadYTiempoDeCicloToolStripMenuItem.Click += introducirDistanciaDeSeguridadYTiempoDeCicloToolStripMenuItem_Click;
            // 
            // simulatorToolStripMenuItem
            // 
            simulatorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openSimToolStripMenuItem });
            simulatorToolStripMenuItem.Name = "simulatorToolStripMenuItem";
            simulatorToolStripMenuItem.Size = new Size(70, 20);
            simulatorToolStripMenuItem.Text = "Simulator";
            // 
            // openSimToolStripMenuItem
            // 
            openSimToolStripMenuItem.Name = "openSimToolStripMenuItem";
            openSimToolStripMenuItem.Size = new Size(126, 22);
            openSimToolStripMenuItem.Text = "Open Sim";
            openSimToolStripMenuItem.Click += openSimToolStripMenuItem_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(162, 139);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(104, 15);
            linkLabel1.TabIndex = 1;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Bienvenido, cotilla";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(481, 294);
            Controls.Add(linkLabel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Inicio";
            Load += Inicio_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem opcionesToolStripMenuItem;
        private ToolStripMenuItem introducirFlightPlansToolStripMenuItem;
        private ToolStripMenuItem introducirDistanciaDeSeguridadYTiempoDeCicloToolStripMenuItem;
        private LinkLabel linkLabel1;
        private ToolStripMenuItem simulatorToolStripMenuItem;
        private ToolStripMenuItem openSimToolStripMenuItem;
        private ToolStripMenuItem fromFileToolStripMenuItem;
        private ToolStripMenuItem flightPlanPairToolStripMenuItem;
    }
}