namespace WinFormsApp1
{
    partial class IntroducirFlightPlans
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            FP1Number = new TextBox();
            FP2Number = new TextBox();
            FP2Speed = new TextBox();
            FP1Speed = new TextBox();
            label2 = new Label();
            FP2Yf = new TextBox();
            FP1Yf = new TextBox();
            label3 = new Label();
            FP2Xf = new TextBox();
            FP1Xf = new TextBox();
            label4 = new Label();
            FP2Yo = new TextBox();
            FP1Yo = new TextBox();
            label5 = new Label();
            FP2Xo = new TextBox();
            FP1Xo = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            AceptarBoton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 100);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 0;
            label1.Text = "Flight Number";
            label1.Click += label1_Click;
            // 
            // FP1Number
            // 
            FP1Number.Location = new Point(160, 97);
            FP1Number.Name = "FP1Number";
            FP1Number.Size = new Size(100, 23);
            FP1Number.TabIndex = 1;
            FP1Number.TextChanged += textBox1_TextChanged;
            // 
            // FP2Number
            // 
            FP2Number.Location = new Point(282, 97);
            FP2Number.Name = "FP2Number";
            FP2Number.Size = new Size(100, 23);
            FP2Number.TabIndex = 2;
            // 
            // FP2Speed
            // 
            FP2Speed.Location = new Point(282, 244);
            FP2Speed.Name = "FP2Speed";
            FP2Speed.Size = new Size(100, 23);
            FP2Speed.TabIndex = 5;
            // 
            // FP1Speed
            // 
            FP1Speed.Location = new Point(160, 244);
            FP1Speed.Name = "FP1Speed";
            FP1Speed.Size = new Size(100, 23);
            FP1Speed.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(84, 247);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 3;
            label2.Text = "Speed";
            label2.Click += label2_Click;
            // 
            // FP2Yf
            // 
            FP2Yf.Location = new Point(282, 215);
            FP2Yf.Name = "FP2Yf";
            FP2Yf.Size = new Size(100, 23);
            FP2Yf.TabIndex = 8;
            // 
            // FP1Yf
            // 
            FP1Yf.Location = new Point(160, 215);
            FP1Yf.Name = "FP1Yf";
            FP1Yf.Size = new Size(100, 23);
            FP1Yf.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(105, 218);
            label3.Name = "label3";
            label3.Size = new Size(18, 15);
            label3.TabIndex = 6;
            label3.Text = "Yf";
            // 
            // FP2Xf
            // 
            FP2Xf.Location = new Point(282, 184);
            FP2Xf.Name = "FP2Xf";
            FP2Xf.Size = new Size(100, 23);
            FP2Xf.TabIndex = 11;
            // 
            // FP1Xf
            // 
            FP1Xf.Location = new Point(160, 184);
            FP1Xf.Name = "FP1Xf";
            FP1Xf.Size = new Size(100, 23);
            FP1Xf.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(105, 187);
            label4.Name = "label4";
            label4.Size = new Size(18, 15);
            label4.TabIndex = 9;
            label4.Text = "Xf";
            // 
            // FP2Yo
            // 
            FP2Yo.Location = new Point(282, 155);
            FP2Yo.Name = "FP2Yo";
            FP2Yo.Size = new Size(100, 23);
            FP2Yo.TabIndex = 14;
            // 
            // FP1Yo
            // 
            FP1Yo.Location = new Point(160, 155);
            FP1Yo.Name = "FP1Yo";
            FP1Yo.Size = new Size(100, 23);
            FP1Yo.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(105, 158);
            label5.Name = "label5";
            label5.Size = new Size(20, 15);
            label5.TabIndex = 12;
            label5.Text = "Yo";
            // 
            // FP2Xo
            // 
            FP2Xo.Location = new Point(282, 126);
            FP2Xo.Name = "FP2Xo";
            FP2Xo.Size = new Size(100, 23);
            FP2Xo.TabIndex = 17;
            // 
            // FP1Xo
            // 
            FP1Xo.Location = new Point(160, 126);
            FP1Xo.Name = "FP1Xo";
            FP1Xo.Size = new Size(100, 23);
            FP1Xo.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(105, 129);
            label6.Name = "label6";
            label6.Size = new Size(21, 15);
            label6.TabIndex = 15;
            label6.Text = "Xo";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(297, 60);
            label7.Name = "label7";
            label7.Size = new Size(72, 15);
            label7.TabIndex = 18;
            label7.Text = "Flight Plan 2";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(173, 60);
            label8.Name = "label8";
            label8.Size = new Size(72, 15);
            label8.TabIndex = 19;
            label8.Text = "Flight Plan 1";
            // 
            // AceptarBoton
            // 
            AceptarBoton.Location = new Point(234, 295);
            AceptarBoton.Name = "AceptarBoton";
            AceptarBoton.Size = new Size(75, 23);
            AceptarBoton.TabIndex = 20;
            AceptarBoton.Text = "Aceptar";
            AceptarBoton.UseVisualStyleBackColor = true;
            AceptarBoton.Click += AceptarBoton_Click;
            // 
            // IntroducirFlightPlans
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(518, 365);
            Controls.Add(AceptarBoton);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(FP2Xo);
            Controls.Add(FP1Xo);
            Controls.Add(label6);
            Controls.Add(FP2Yo);
            Controls.Add(FP1Yo);
            Controls.Add(label5);
            Controls.Add(FP2Xf);
            Controls.Add(FP1Xf);
            Controls.Add(label4);
            Controls.Add(FP2Yf);
            Controls.Add(FP1Yf);
            Controls.Add(label3);
            Controls.Add(FP2Speed);
            Controls.Add(FP1Speed);
            Controls.Add(label2);
            Controls.Add(FP2Number);
            Controls.Add(FP1Number);
            Controls.Add(label1);
            Name = "IntroducirFlightPlans";
            Text = "Introducir Flight Plans";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox FP1Number;
        private TextBox FP2Number;
        private TextBox FP2Speed;
        private TextBox FP1Speed;
        private Label label2;
        private TextBox FP2Yf;
        private TextBox FP1Yf;
        private Label label3;
        private TextBox FP2Xf;
        private TextBox FP1Xf;
        private Label label4;
        private TextBox FP2Yo;
        private TextBox FP1Yo;
        private Label label5;
        private TextBox FP2Xo;
        private TextBox FP1Xo;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button AceptarBoton;
    }
}
