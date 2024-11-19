namespace WinFormsApp1
{
    partial class Guardar
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
            Name = new Label();
            textBox1 = new TextBox();
            button1Guardar = new Button();
            SuspendLayout();
            // 
            // Name
            // 
            Name.AutoSize = true;
            Name.Location = new Point(42, 51);
            Name.Name = "Name";
            Name.Size = new Size(112, 15);
            Name.TabIndex = 0;
            Name.Text = "Nombre del archivo";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(171, 48);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
            // 
            // button1Guardar
            // 
            button1Guardar.Location = new Point(94, 93);
            button1Guardar.Name = "button1Guardar";
            button1Guardar.Size = new Size(130, 23);
            button1Guardar.TabIndex = 2;
            button1Guardar.Text = "Guardar simulación";
            button1Guardar.UseVisualStyleBackColor = true;
            button1Guardar.Click += button1Guardar_Click;
            // 
            // Guardar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(337, 182);
            Controls.Add(button1Guardar);
            Controls.Add(textBox1);
            Controls.Add(Name);
            Name = "Guardar";
            Text = "Guardar simulación";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Name;
        private TextBox textBox1;
        private Button button1Guardar;
    }
}