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
        int tiempoCiclo = 0;
        int SecDist;
        public Parameters()
        {
            InitializeComponent();
        }

        public int dameTiempo()
        {
            return tiempoCiclo;
        }

        public int dameDist()
        {
            return SecDist;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AceptarBoton2_Click(object sender, EventArgs e)
        {
            //Cuando le damos al boton Aceptar:

            try
            {
                //Guardamos la info en dos variables nuevas
                SecDist = Convert.ToInt16(DistanciaSeguridad.Text);
                tiempoCiclo = Convert.ToInt16(TiempoCiclo.Text);

                //Abre un forms que confirma que todo se ha guardado bien
                Saved Dg = new Saved();
                Dg.ShowDialog();

                //Cierra el forms al pulsar "aceptar"
                Close();
            }

            //En caso de error:
            catch (Exception)
            {
                //Abre un forms que avisa de un error
                Error fallo = new Error();
                fallo.ShowDialog();
            }

        }

        private void DistanciaSeguridadTiempoCiclo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DistanciaSeguridad.Text = "50";
            TiempoCiclo.Text = "2";
        }
    }
}
