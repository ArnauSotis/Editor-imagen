using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proyecto_de_prueba
{
    public partial class Iluminacion : Form
    {
        int valor;
        
        public Iluminacion()
        {
            InitializeComponent();
        }

        public int SetValor()
        {
            return valor;
        
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int valor2 = Convert.ToInt32(textBox1.Text);
                if (valor > 255)
                    MessageBox.Show("El valor debe estar entre -255 y 255");
                if (valor < -255)
                    MessageBox.Show("El valor debe estar entre -255 y 255");
                else
                    valor = valor2;
                this.Close();
            }
            catch (FormatException)
            { MessageBox.Show("Añada un número"); }
        }

        private void Iluminacion_Load(object sender, EventArgs e)
        {

        }

    }
}
