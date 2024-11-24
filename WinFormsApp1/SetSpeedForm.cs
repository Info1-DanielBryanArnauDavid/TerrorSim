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
    public partial class SetSpeedForm : Form
    {
        // Variable para almacenar la velocidad
        double speed;

        // Constructor del formulario
        public SetSpeedForm()
        {
            InitializeComponent();
        }

        // Método público para obtener la velocidad ingresada
        public double getData()
        {
            return speed;
        }

        // Método público para establecer una velocidad inicial
        public void setData(double spd)
        {
            speed = spd;
        }

        // Evento que se ejecuta al cargar el formulario
        private void SetSpeedForm_Load(object sender, EventArgs e)
        {
            // Muestra la velocidad actual en el cuadro de texto
            textBox1.Text = speed.ToString();
        }

        // Evento del botón "Aceptar"
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Intenta convertir el texto ingresado a un número y valida que sea positivo
                if (Convert.ToDouble(textBox1.Text) > 0)
                {
                    // Si es válido, se actualiza la velocidad y se cierra el formulario
                    speed = Convert.ToDouble(textBox1.Text);
                    Close();
                }
                else
                {
                    // Si el número es 0 o negativo, muestra un mensaje de error
                    MessageBox.Show("No se puede añadir esa velocidad");
                }
            }
            catch (FormatException)
            {
                // Captura errores de formato al convertir el texto a número y muestra un mensaje de error
                MessageBox.Show("No se puede añadir esa velocidad");
            }
        }

        // Evento que se dispara al cambiar el texto en el cuadro de texto
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // No tiene implementación en este caso
        }
    }
}
