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
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { opcionesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(675, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            opcionesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { introducirFlightPlansToolStripMenuItem, introducirDistanciaDeSeguridadYTiempoDeCicloToolStripMenuItem });
            opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            opcionesToolStripMenuItem.Size = new Size(69, 20);
            opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // introducirFlightPlansToolStripMenuItem
            // 
            introducirFlightPlansToolStripMenuItem.Name = "introducirFlightPlansToolStripMenuItem";
            introducirFlightPlansToolStripMenuItem.Size = new Size(342, 22);
            introducirFlightPlansToolStripMenuItem.Text = "Introducir Flight Plans";
            introducirFlightPlansToolStripMenuItem.Click += introducirFlightPlansToolStripMenuItem_Click;
            // 
            // introducirDistanciaDeSeguridadYTiempoDeCicloToolStripMenuItem
            // 
            introducirDistanciaDeSeguridadYTiempoDeCicloToolStripMenuItem.Name = "introducirDistanciaDeSeguridadYTiempoDeCicloToolStripMenuItem";
            introducirDistanciaDeSeguridadYTiempoDeCicloToolStripMenuItem.Size = new Size(342, 22);
            introducirDistanciaDeSeguridadYTiempoDeCicloToolStripMenuItem.Text = "Establecer distancia de seguridad y tiempo de ciclo";
            introducirDistanciaDeSeguridadYTiempoDeCicloToolStripMenuItem.Click += introducirDistanciaDeSeguridadYTiempoDeCicloToolStripMenuItem_Click;
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(675, 418);
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
    }
}