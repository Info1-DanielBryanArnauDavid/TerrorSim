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
        double speed;
        public SetSpeedForm()
        {
            InitializeComponent();
        }

        public double getData()
        {
            return speed;
        }

        public void setData(double spd) { speed = spd; }

        private void SetSpeedForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = speed.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (Convert.ToDouble(textBox1.Text) > 0)
                {
                    speed = Convert.ToDouble(textBox1.Text);
                    Close();
                }
                else { MessageBox.Show("No se puede añadir esa velocidad"); }
            }
            catch (FormatException)
            {
                MessageBox.Show("No se puede añadir esa velocidad");
            }
        }
    }
}
