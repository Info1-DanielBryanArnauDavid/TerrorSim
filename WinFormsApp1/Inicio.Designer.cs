namespace WinFormsApp1
{
    partial class Inicio
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
            introducirDistanciaDeSeguridadYTiempoDeCicloToolStripMenuItem = new ToolStripMenuItem();
            simularToolStripMenuItem = new ToolStripMenuItem();
            linkLabel1 = new LinkLabel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { opcionesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(481, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            opcionesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { introducirFlightPlansToolStripMenuItem, introducirDistanciaDeSeguridadYTiempoDeCicloToolStripMenuItem, simularToolStripMenuItem });
            opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            opcionesToolStripMenuItem.Size = new Size(69, 20);
            opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // introducirFlightPlansToolStripMenuItem
            // 
            introducirFlightPlansToolStripMenuItem.Name = "introducirFlightPlansToolStripMenuItem";
            introducirFlightPlansToolStripMenuItem.Size = new Size(190, 22);
            introducirFlightPlansToolStripMenuItem.Text = "Introducir Flight Plans";
            introducirFlightPlansToolStripMenuItem.Click += introducirFlightPlansToolStripMenuItem_Click;
            // 
            // introducirDistanciaDeSeguridadYTiempoDeCicloToolStripMenuItem
            // 
            introducirDistanciaDeSeguridadYTiempoDeCicloToolStripMenuItem.Name = "introducirDistanciaDeSeguridadYTiempoDeCicloToolStripMenuItem";
            introducirDistanciaDeSeguridadYTiempoDeCicloToolStripMenuItem.Size = new Size(190, 22);
            introducirDistanciaDeSeguridadYTiempoDeCicloToolStripMenuItem.Text = "Parámetros";
            introducirDistanciaDeSeguridadYTiempoDeCicloToolStripMenuItem.Click += introducirDistanciaDeSeguridadYTiempoDeCicloToolStripMenuItem_Click;
            // 
            // simularToolStripMenuItem
            // 
            simularToolStripMenuItem.Name = "simularToolStripMenuItem";
            simularToolStripMenuItem.Size = new Size(190, 22);
            simularToolStripMenuItem.Text = "Simular";
            simularToolStripMenuItem.Click += simularToolStripMenuItem_Click;
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
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(481, 294);
            Controls.Add(linkLabel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Inicio";
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
        private ToolStripMenuItem simularToolStripMenuItem;
        private LinkLabel linkLabel1;
    }
}