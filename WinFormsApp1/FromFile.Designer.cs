namespace WinFormsApp1
{
    partial class FromFile
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
            textBoxNombreArchivotxt = new TextBox();
            buttoncargar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 45);
            label1.Name = "label1";
            label1.Size = new Size(112, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre del archivo";
            // 
            // textBoxNombreArchivotxt
            // 
            textBoxNombreArchivotxt.Location = new Point(160, 42);
            textBoxNombreArchivotxt.Name = "textBoxNombreArchivotxt";
            textBoxNombreArchivotxt.Size = new Size(95, 23);
            textBoxNombreArchivotxt.TabIndex = 2;
            // 
            // buttoncargar
            // 
            buttoncargar.Location = new Point(171, 81);
            buttoncargar.Name = "buttoncargar";
            buttoncargar.Size = new Size(75, 23);
            buttoncargar.TabIndex = 3;
            buttoncargar.Text = "Cargar";
            buttoncargar.UseVisualStyleBackColor = true;
            buttoncargar.Click += buttoncargar_Click;
            // 
            // FromFile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(327, 170);
            Controls.Add(buttoncargar);
            Controls.Add(textBoxNombreArchivotxt);
            Controls.Add(label1);
            Name = "FromFile";
            Text = "Cargar FlightPlan";
            Load += FromFile_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxNombreArchivotxt;
        private Button buttoncargar;
    }
}