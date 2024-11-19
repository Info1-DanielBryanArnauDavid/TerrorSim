﻿using Class;
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

            if (MisUsuarios.ComprovarSiElUsuarioExiste( textBox1.Text, textBox2.Text) == 0)
            {
                MisUsuarios.AñadirUsuario(textBox1.Text, textBox2.Text);
                MessageBox.Show("Usuario registrado correctamente");
                Close();
                return;
            }

            if (MisUsuarios.ComprovarSiElUsuarioExiste(textBox1.Text, textBox2.Text) == 1)
            {
                MessageBox.Show("El usuario ya existe");
                return;
            }
            

        }

        public void SetGestionUsuarios(GestionUsuarios MisUsuarios)
        {
            this.MisUsuarios = MisUsuarios;
        }
    }
}
