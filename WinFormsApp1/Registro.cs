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

        // Instancia para gestionar usuarios
        GestionUsuarios MisUsuarios = new GestionUsuarios();

        // Evento del botón "Cancelar" para cerrar el formulario
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Evento del botón "Registrar"
        private void button1_Click(object sender, EventArgs e)
        {
            // Verifica si las contraseñas coinciden
            if (textBox2.Text != textBox3.Text)
            {
                label4.Text = "Passwords don't match"; // Mensaje de error
                return;
            }

            // Verifica si el nombre de usuario ya está tomado
            if (MisUsuarios.ComprovarSiElUsuarioExiste(textBox1.Text, textBox2.Text) == 1)
            {
                label4.Text = "Username taken"; // Mensaje de error
                return;
            }

            // Verifica la longitud máxima del nombre de usuario y la contraseña
            if (textBox1.Text.Length > 20 || textBox2.Text.Length > 20)
            {
                label4.Text = "Username or Password incorrect"; // Mensaje de error
                return;
            }

            // Verifica si los campos están vacíos
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                label4.Text = "Empty username/password is not a valid value"; // Mensaje de error
                return;
            }

            // Comprueba si hay espacios en el nombre de usuario
            int i = 0;
            int espaciosU = 0;
            while (i < textBox1.Text.Length)
            {
                if (textBox1.Text[i] == ' ')
                {
                    espaciosU = 1; // Se detectaron espacios
                }
                i++;
            }
            if (espaciosU == 1)
            {
                label4.Text = "No spaces in username"; // Mensaje de error
                return;
            }

            // Comprueba si hay espacios en la contraseña
            int n = 0;
            int espaciosC = 0;
            while (n < textBox2.Text.Length)
            {
                if (textBox2.Text[n] == ' ')
                {
                    espaciosC = 1; // Se detectaron espacios
                }
                n++;
            }
            if (espaciosC == 1)
            {
                label4.Text = "No spaces in password"; // Mensaje de error
                return;
            }

            // Verifica nuevamente si el usuario no existe y lo registra
            if (MisUsuarios.ComprovarSiElUsuarioExiste(textBox1.Text, textBox2.Text) == 0)
            {
                // Añade el usuario al sistema
                MisUsuarios.AñadirUsuario(textBox1.Text, textBox2.Text);

                // Muestra un mensaje de éxito
                MessageBox.Show("User correctly registered");

                // Cierra el formulario después de registrar el usuario
                Close();
                return;
            }
        }

        // Método para asignar una instancia de gestión de usuarios desde otra clase
        public void SetGestionUsuarios(GestionUsuarios MisUsuarios)
        {
            this.MisUsuarios = MisUsuarios;
        }

        private void Registro_Load(object sender, EventArgs e)
        {
            // Evento de carga del formulario (sin implementación adicional)
        }
    }
}
