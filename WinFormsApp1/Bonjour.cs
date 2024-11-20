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
namespace WinFormsApp1
{
    public partial class Bonjour : Form
    {
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
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            MisUsuarios.Iniciar();
            MisUsuarios.CrearBaseDeUsuarios();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            registro.SetGestionUsuarios(MisUsuarios);
            registro.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
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
    }
}
