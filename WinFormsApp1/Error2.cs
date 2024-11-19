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
    public partial class Error2 : Form
    {
        public Error2()
        {
            InitializeComponent();
        }

        private void BotonReintentar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
