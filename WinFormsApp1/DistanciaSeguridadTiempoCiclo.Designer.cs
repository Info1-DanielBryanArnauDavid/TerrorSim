﻿namespace WinFormsApp1
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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(111, 66);
            label1.Name = "label1";
            label1.Size = new Size(126, 15);
            label1.TabIndex = 0;
            label1.Text = "Distancia de seguridad";
            label1.Click += label1_Click;
            // 
            // DistanciaSeguridad
            // 
            DistanciaSeguridad.Location = new Point(111, 93);
            DistanciaSeguridad.Name = "DistanciaSeguridad";
            DistanciaSeguridad.Size = new Size(126, 23);
            DistanciaSeguridad.TabIndex = 1;
            // 
            // TiempoCiclo
            // 
            TiempoCiclo.Location = new Point(266, 93);
            TiempoCiclo.Name = "TiempoCiclo";
            TiempoCiclo.Size = new Size(126, 23);
            TiempoCiclo.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(282, 66);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 2;
            label2.Text = "Tiempo de ciclo";
            // 
            // AceptarBoton2
            // 
            AceptarBoton2.Location = new Point(215, 132);
            AceptarBoton2.Name = "AceptarBoton2";
            AceptarBoton2.Size = new Size(75, 23);
            AceptarBoton2.TabIndex = 4;
            AceptarBoton2.Text = "Aceptar";
            AceptarBoton2.UseVisualStyleBackColor = true;
            // 
            // DistanciaSeguridadTiempoCiclo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(546, 286);
            Controls.Add(AceptarBoton2);
            Controls.Add(TiempoCiclo);
            Controls.Add(label2);
            Controls.Add(DistanciaSeguridad);
            Controls.Add(label1);
            Name = "DistanciaSeguridadTiempoCiclo";
            Text = "Distancia de seguridad y tiempo de ciclo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox DistanciaSeguridad;
        private TextBox TiempoCiclo;
        private Label label2;
        private Button AceptarBoton2;
    }
}