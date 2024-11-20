using Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        GestionUsuarios MisUsuarios = new GestionUsuarios();

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("La contraseña es diferente");
                return;
            }

            if (MisUsuarios.ComprovarSiElUsuarioExiste(textBox1.Text, textBox2.Text) == 1)
            {
                MessageBox.Show("El usuario ya existe");
                return;
            }
            
            if (textBox1.Text.Length > 20 ||  textBox2.Text.Length > 20)
            {
                MessageBox.Show("Usuario o contraseña demasiado largos");
                return;
            }


            if(textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("No puedes crear un usuario i/o contraseña vacios");
                return;
            }

            if (MisUsuarios.ComprovarSiElUsuarioExiste(textBox1.Text, textBox2.Text) == 0)
            {
                MisUsuarios.AñadirUsuario(textBox1.Text, textBox2.Text);
                MessageBox.Show("Usuario registrado correctamente");
                Close();
                return;
            }
        }

        public void SetGestionUsuarios(GestionUsuarios MisUsuarios)
        {
            this.MisUsuarios = MisUsuarios;
        }
    }
}
