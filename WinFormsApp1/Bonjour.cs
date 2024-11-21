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
        public Bonjour()
        {
            InitializeComponent();
        }

        GestionUsuarios MisUsuarios = new GestionUsuarios();
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
                MessageBox.Show("Usuario i/o contraseña incorrectos");
                return;
            }
        }

        private void Bonjour_Load(object sender, EventArgs e)
        {
            timer1.Interval = 40;
            timer1.Enabled = true;  
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm inicio = new MainForm();
            inicio.ShowDialog();
            this.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            count++;
            double x=296+Math.Sin(count+2);
            double y=85+Math.Cos(count);
            pictureBox1.Location = new Point((int)x,(int)y);
        }
    }
}
