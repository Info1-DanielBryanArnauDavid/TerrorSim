
namespace WinFormsApp1
{
    partial class Error
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
            label2 = new Label();
            ReintentarBoton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 33);
            label1.Name = "label1";
            label1.Size = new Size(317, 15);
            label1.TabIndex = 0;
            label1.Text = "Ha habido un error al guardar los valores, asegúrate de que";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 50);
            label2.Name = "label2";
            label2.Size = new Size(355, 15);
            label2.TabIndex = 1;
            label2.Text = "no falte ningun valor y de que esten todos escritos correctamente.";
            // 
            // ReintentarBoton
            // 
            ReintentarBoton.Location = new Point(164, 93);
            ReintentarBoton.Name = "ReintentarBoton";
            ReintentarBoton.Size = new Size(75, 23);
            ReintentarBoton.TabIndex = 2;
            ReintentarBoton.Text = "Reintentar";
            ReintentarBoton.UseVisualStyleBackColor = true;
            ReintentarBoton.Click += ReintentarBoton_Click;
            // 
            // Error
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(385, 136);
            Controls.Add(ReintentarBoton);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Error";
            Text = "Ha surgido un error";
            Load += Error_Load;
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Label label1;
        private Label label2;
        private Button ReintentarBoton;
    }
}