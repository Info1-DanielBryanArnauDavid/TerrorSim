﻿using System;
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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void introducirFlightPlansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IntroducirFlightPlans IFP = new IntroducirFlightPlans();
            IFP.ShowDialog();   
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private void introducirDistanciaDeSeguridadYTiempoDeCicloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DistanciaSeguridadTiempoCiclo DSTC = new DistanciaSeguridadTiempoCiclo();
            DSTC.ShowDialog();
        }
    }
}