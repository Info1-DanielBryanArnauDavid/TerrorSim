namespace WinFormsApp1
{
    partial class DistanciaSeguridadTiempoCiclo
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
            label1 = new Label();
            DistanciaSeguridad = new TextBox();
            TiempoCiclo = new TextBox();
            label2 = new Label();
            AceptarBoton2 = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 27);
            label1.Name = "label1";
            label1.Size = new Size(126, 15);
            label1.TabIndex = 0;
            label1.Text = "Distancia de seguridad";
            label1.Click += label1_Click;
            // 
            // DistanciaSeguridad
            // 
            DistanciaSeguridad.Location = new Point(39, 54);
            DistanciaSeguridad.Name = "DistanciaSeguridad";
            DistanciaSeguridad.Size = new Size(126, 23);
            DistanciaSeguridad.TabIndex = 1;
            // 
            // TiempoCiclo
            // 
            TiempoCiclo.Location = new Point(194, 54);
            TiempoCiclo.Name = "TiempoCiclo";
            TiempoCiclo.Size = new Size(126, 23);
            TiempoCiclo.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(210, 27);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 2;
            label2.Text = "Tiempo de ciclo";
            // 
            // AceptarBoton2
            // 
            AceptarBoton2.Location = new Point(143, 93);
            AceptarBoton2.Name = "AceptarBoton2";
            AceptarBoton2.Size = new Size(75, 23);
            AceptarBoton2.TabIndex = 4;
            AceptarBoton2.Text = "Aceptar";
            AceptarBoton2.UseVisualStyleBackColor = true;
            AceptarBoton2.Click += AceptarBoton2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 118);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "Autofill";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // DistanciaSeguridadTiempoCiclo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 153);
            Controls.Add(button1);
            Controls.Add(AceptarBoton2);
            Controls.Add(TiempoCiclo);
            Controls.Add(label2);
            Controls.Add(DistanciaSeguridad);
            Controls.Add(label1);
            Name = "DistanciaSeguridadTiempoCiclo";
            Text = "Distancia de seguridad y tiempo de ciclo";
            Load += DistanciaSeguridadTiempoCiclo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox DistanciaSeguridad;
        private TextBox TiempoCiclo;
        private Label label2;
        private Button AceptarBoton2;
        private Button button1;
    }
}