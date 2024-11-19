namespace WinFormsApp1
{
    partial class Error2
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
            BotonReintentar = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // BotonReintentar
            // 
            BotonReintentar.Location = new Point(97, 95);
            BotonReintentar.Name = "BotonReintentar";
            BotonReintentar.Size = new Size(75, 23);
            BotonReintentar.TabIndex = 0;
            BotonReintentar.Text = "Reintentar";
            BotonReintentar.UseVisualStyleBackColor = true;
            BotonReintentar.Click += BotonReintentar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 44);
            label1.Name = "label1";
            label1.Size = new Size(179, 15);
            label1.TabIndex = 1;
            label1.Text = "No se pudo encontrar el archivo.";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(286, 162);
            Controls.Add(label1);
            Controls.Add(BotonReintentar);
            Name = "Form1";
            Text = "Error";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BotonReintentar;
        private Label label1;
    }
}