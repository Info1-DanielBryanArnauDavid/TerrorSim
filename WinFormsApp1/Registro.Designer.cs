namespace WinFormsApp1
{
    partial class Registro
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(169, 158);
            label1.Name = "label1";
            label1.Size = new Size(137, 20);
            label1.TabIndex = 0;
            label1.Text = "Nombre de usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(191, 219);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 1;
            label2.Text = "Contraseña";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(142, 294);
            label3.Name = "label3";
            label3.Size = new Size(151, 20);
            label3.TabIndex = 2;
            label3.Text = "Confirmar contraseña";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(315, 155);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(171, 27);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(315, 212);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(171, 27);
            textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(315, 291);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(171, 27);
            textBox3.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(471, 359);
            button1.Name = "button1";
            button1.Size = new Size(156, 32);
            button1.TabIndex = 6;
            button1.Text = "Registrar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(191, 359);
            button2.Name = "button2";
            button2.Size = new Size(115, 32);
            button2.TabIndex = 7;
            button2.Text = "Salir";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // Registro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Registro";
            Text = "Registro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button button1;
        private Button button2;
        private ContextMenuStrip contextMenuStrip1;
    }
}