using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Class; // Clase externa para gestión de usuarios.
using System.Globalization;

namespace WinFormsApp1
{
    public partial class Bonjour : Form
    {
        int count = 0; // Contador usado para animaciones.
        GestionUsuarios MisUsuarios = new GestionUsuarios(); // Gestión de usuarios.

        public Bonjour()
        {
            InitializeComponent(); // Inicializa componentes del formulario.
            StyleForm(); // Aplica estilos personalizados al formulario.
        }

        private void StyleForm()
        {
            // Configura la ventana.
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            // Crea etiquetas para el título y subtítulo.
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
                Font = new Font("Segoe UI", 12),
                ForeColor = Color.FromArgb(51, 51, 51),
                AutoSize = true,
                Location = new Point(50, 90)
            };

            // Añade etiquetas al formulario.
            this.Controls.Add(titleLabel);
            this.Controls.Add(secondaryLabel);

            // Aplica estilos a los controles.
            StyleTextBox(textBox1, "Username");
            StyleTextBox(textBox2, "Password");
            StyleLabel(label1, "Username");
            StyleLabel(label2, "Password");
            StyleLoginButton(button1);
            StyleSignUpButton(button2);
            StyleCheckBox(checkBox1);

            // Posiciona controles.
            textBox1.Location = new Point(77, 168);
            textBox2.Location = new Point(77, 226);
            label1.Location = new Point(77, 148);
            label2.Location = new Point(77, 206);
            button1.Location = new Point(77, 290);
            checkBox1.Location = new Point(77, 255);
            button2.Location = new Point(77, 340);

            // Configura imagen (si existe).
            if (pictureBox1 != null)
            {
                pictureBox1.Size = new Size(300, 200);
                pictureBox1.Location = new Point(400, 120);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        // Estiliza cuadros de texto.
        private void StyleTextBox(TextBox textBox, string placeholder)
        {
            textBox.Size = new Size(250, 30);
            textBox.Font = new Font("Segoe UI", 10);
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.BackColor = Color.FromArgb(245, 245, 245);
            textBox.Padding = new Padding(5);
        }

        // Estiliza etiquetas.
        private void StyleLabel(Label label, string text)
        {
            label.Text = text;
            label.Font = new Font("Segoe UI", 9);
            label.ForeColor = Color.FromArgb(102, 102, 102);
            label.AutoSize = true;
        }

        // Configura el botón de inicio de sesión.
        private void StyleLoginButton(Button button)
        {
            button.Size = new Size(250, 40);
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = Color.FromArgb(0, 120, 212);
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI", 10);
            button.Text = "Log In";
            button.Cursor = Cursors.Hand;
            button.FlatAppearance.BorderSize = 0;
        }

        // Configura el botón de registro.
        private void StyleSignUpButton(Button button)
        {
            button.Size = new Size(250, 40);
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = Color.White;
            button.ForeColor = Color.FromArgb(0, 120, 212);
            button.Font = new Font("Segoe UI", 10);
            button.Text = "Create Account";
            button.Cursor = Cursors.Hand;
            button.FlatAppearance.BorderColor = Color.FromArgb(0, 120, 212);
            button.FlatAppearance.BorderSize = 1;
        }

        // Configura el checkbox para mostrar contraseña.
        private void StyleCheckBox(CheckBox checkBox)
        {
            checkBox.Text = "Show password";
            checkBox.Font = new Font("Segoe UI", 9);
            checkBox.ForeColor = Color.FromArgb(102, 102, 102);
        }

        // Acción del botón de inicio de sesión.
        private void button1_Click(object sender, EventArgs e)
        {
            // Verifica si el usuario y contraseña son correctos.
            if (MisUsuarios.ComprovarSiElUsuarioiContraseñaExiste(textBox1.Text, textBox2.Text) == 1)
            {
                MainForm inicio = new MainForm(); // Abre el formulario principal.
                inicio.ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("Incorrect Username/Password"); // Mensaje de error.
                return;
            }
        }

        // Carga inicial del formulario.
        private void Bonjour_Load(object sender, EventArgs e)
        {
            timer1.Interval = 40; // Configura el temporizador para animaciones.
            timer1.Enabled = true;

            // Configura cuadros de texto y placeholders.
            textBox1.PlaceholderText = "Enter username";
            textBox2.PlaceholderText = "Enter password";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Properties.Resources.bell_v_22_rotor_animation;

            // Configura el ícono de la aplicación.
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            // Inicializa los usuarios.
            MisUsuarios.Iniciar();
            MisUsuarios.CrearBaseDeUsuarios();

            // Configura cultura para toda la aplicación.
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
        }

        // Acción del botón de registro.
        private void button2_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro(); // Abre el formulario de registro.
            registro.SetGestionUsuarios(MisUsuarios); // Pasa la gestión de usuarios al formulario.
            registro.ShowDialog();
        }

        // Acción del checkbox de mostrar/ocultar contraseña.
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0'; // Muestra la contraseña.
            }
            else
            {
                textBox2.PasswordChar = '*'; // Oculta la contraseña.
            }
        }

        // Evento del temporizador para animar la imagen.
        private void timer1_Tick(object sender, EventArgs e)
        {
            count++; // Incrementa el contador.
            double x = 350 + Math.Sin(count + 2); // Calcula nueva posición X.
            double y = 150 + Math.Cos(count); // Calcula nueva posición Y.
            pictureBox1.Location = new Point((int)x, (int)y); // Actualiza la posición de la imagen.
        }

        // Acción al hacer clic en la imagen.
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Hide(); // Oculta el formulario actual.
            MainForm inicio = new MainForm(); // Abre el formulario principal.
            inicio.ShowDialog();
            this.Show(); // Vuelve a mostrar el formulario actual al cerrar el principal.
        }
    }
}
