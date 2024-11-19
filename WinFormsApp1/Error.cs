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
    public partial class Error : Form
    {
        public Error()
        {
            InitializeComponent();
        }
        private void ReintentarBoton_Click(object sender, EventArgs e)
        {
            //Se cierra cuando pulsas reintentar, para volver al forms anterior y poder arreglar el error
            Close();
        }

        private void Error_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
