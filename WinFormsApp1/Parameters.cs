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
    public partial class Parameters : Form
    {
        // Variables para almacenar los valores de tiempo de ciclo y distancia de seguridad.
        int tiempoCiclo = 0;
        int SecDist;

        public Parameters()
        {
            InitializeComponent();
        }

        // Devuelve el tiempo de ciclo introducido.
        public int dameTiempo()
        {
            return tiempoCiclo;
        }

        // Devuelve la distancia de seguridad introducida.
        public int dameDist()
        {
            return SecDist;
        }

        private void AceptarBoton2_Click(object sender, EventArgs e)
        {
            // Evento al pulsar el botón "Aceptar".
            try
            {
                // Verifica y guarda los valores si son válidos.
                if (Convert.ToInt32(DistanciaSeguridad.Text) > 0 && Convert.ToInt32(TiempoCiclo.Text) >= 0)
                {
                    SecDist = Convert.ToInt16(DistanciaSeguridad.Text);
                    tiempoCiclo = Convert.ToInt16(TiempoCiclo.Text);

                    // Muestra un mensaje de confirmación.
                    MessageBox.Show("Data successfully loaded");

                    // Cierra el formulario.
                    Close();
                }
                else
                {
                    // Muestra un mensaje si los datos son incorrectos.
                    MessageBox.Show("Incorrect Data");
                }
            }
            catch (Exception)
            {
                // Manejo de errores: muestra un mensaje si ocurre un problema.
                MessageBox.Show("Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Restaura valores predeterminados.
            DistanciaSeguridad.Text = "10";
            TiempoCiclo.Text = "1";
        }
    }
}
