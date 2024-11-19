
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
            label1.Location = new Point(72, 45);
            label1.Name = "label1";
            label1.Size = new Size(138, 15);
            label1.TabIndex = 0;
            label1.Text = "Se ha producido un error";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(63, 60);
            label2.Name = "label2";
            label2.Size = new Size(160, 15);
            label2.TabIndex = 1;
            label2.Text = "por favor inténtalo de nuevo.";
            label2.Click += label2_Click;
            // 
            // ReintentarBoton
            // 
            ReintentarBoton.Location = new Point(100, 89);
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
            ClientSize = new Size(291, 146);
            Controls.Add(ReintentarBoton);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Error";
            Text = "Error";
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