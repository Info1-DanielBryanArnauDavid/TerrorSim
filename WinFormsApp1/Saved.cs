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
    public partial class Saved : Form
    {
        public Saved()
        {
            InitializeComponent();
        }
        private void CerrarBoton_Click(object sender, EventArgs e)
        {
            //Cuando pulsas cerrar, se cierra obviamente
            Close();
        }

        private void DatosGuardados_Load(object sender, EventArgs e)
        {

        }
    }
}
