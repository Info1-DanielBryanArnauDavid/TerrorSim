using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Class;
using System.Globalization;
namespace WinFormsApp1
{
    public partial class Bonjour : Form
    {
        int count = 0;
        GestionUsuarios MisUsuarios = new GestionUsuarios();
        public Bonjour()
        {
            InitializeComponent();
            StyleForm();
        }
        private void StyleForm()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            Label titleLabel = new Label
            {
                Text = "Welcome to TerrorSim",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(51, 51, 51),
                AutoSize = true,
                Location = new Point(40, 40)
            };
            Label secondaryLabel = new Label
            {
                Text = "The interactive real-time collision simulator",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                ForeColor = Color.FromArgb(51, 51, 51),
                AutoSize = true,
                Location = new Point(50, 90)
            };
            this.Controls.Add(titleLabel);
            this.Controls.Add(secondaryLabel);
            StyleTextBox(textBox1, "Username");
            StyleTextBox(textBox2, "Password");
            StyleLabel(label1, "Username");
            StyleLabel(label2, "Password");
            StyleLoginButton(button1);
            StyleSignUpButton(button2);
            StyleCheckBox(checkBox1);

            textBox1.Location = new Point(77, 168);
            textBox2.Location = new Point(77, 226);
            label1.Location = new Point(77, 148);
            label2.Location = new Point(77, 206);
            button1.Location = new Point(77, 290);
            checkBox1.Location = new Point(77, 255);
            button2.Location = new Point(77, 340);
            if (pictureBox1 != null)
            {
                pictureBox1.Size = new Size(300, 200);
                pictureBox1.Location = new Point(400, 120);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }

        }

        private void StyleTextBox(TextBox textBox, string placeholder)
        {
            textBox.Size = new Size(250, 30);
            textBox.Font = new Font("Segoe UI", 10);
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.BackColor = Color.FromArgb(245, 245, 245);
            textBox.Padding = new Padding(5);
        }

        private void StyleLabel(Label label, string text)
        {
            label.Text = text;
            label.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            label.ForeColor = Color.FromArgb(102, 102, 102);
            label.AutoSize = true;
        }

        private void StyleLoginButton(Button button)
        {
            button.Size = new Size(250, 40);
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = Color.FromArgb(0, 120, 212);
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            button.Text = "Log In";
            button.Cursor = Cursors.Hand;
            button.FlatAppearance.BorderSize = 0;
        }

        private void StyleSignUpButton(Button button)
        {
            button.Size = new Size(250, 40);
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = Color.White;
            button.ForeColor = Color.FromArgb(0, 120, 212);
            button.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            button.Text = "Create Account";
            button.Cursor = Cursors.Hand;
            button.FlatAppearance.BorderColor = Color.FromArgb(0, 120, 212);
            button.FlatAppearance.BorderSize = 1;
        }

        private void StyleCheckBox(CheckBox checkBox)
        {
            checkBox.Text = "Show password";
            checkBox.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            checkBox.ForeColor = Color.FromArgb(102, 102, 102);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (MisUsuarios.ComprovarSiElUsuarioiContraseñaExiste(textBox1.Text, textBox2.Text) == 1)
            {
                MainForm inicio = new MainForm();
                inicio.ShowDialog();
                return;

            }

            else
            {
                MessageBox.Show("Incorrect Username/Password");
                return;
            }
        }

        private void Bonjour_Load(object sender, EventArgs e)
        {
            timer1.Interval = 40;
            timer1.Enabled = true;
            textBox1.PlaceholderText = "Enter username";
            textBox2.PlaceholderText = "Enter password";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Properties.Resources.bell_v_22_rotor_animation;
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            MisUsuarios.Iniciar();
            MisUsuarios.CrearBaseDeUsuarios();
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            registro.SetGestionUsuarios(MisUsuarios);
            registro.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (textBox2.PasswordChar == '*')
                {
                    textBox2.PasswordChar = '\0';
                }

            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            count++;
            double x = 350 + Math.Sin(count + 2);
            double y = 150 + Math.Cos(count);
            pictureBox1.Location = new Point((int)x, (int)y);
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            MainForm inicio = new MainForm();
            inicio.ShowDialog();
            this.Show();
        }
    }
}
