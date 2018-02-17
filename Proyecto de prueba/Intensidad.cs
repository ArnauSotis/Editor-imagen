using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using ImagenLib;
using System.Windows.Forms;

namespace Proyecto_de_prueba
{
    public partial class Intensidad : Form
    {
        int posicion;
        public Intensidad()
        {
            InitializeComponent();
        }

        public int posiciones()
        { return posicion; }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Intensidad_Load(object sender, EventArgs e)
        {

        }


        public void button1_Click(object sender, EventArgs e)
        {
            try
            {
                PantallaCarga f1 = new PantallaCarga();
                int tb = Convert.ToInt32(textBox1.Text);
                if (tb > 255)
                {
                    MessageBox.Show("Por favor, añada un valor del 0 al 255");
                }


                else
                {
                    byte a = Convert.ToByte(textBox1.Text);

                    if (radioButton1.Checked == true)
                    {
                        posicion = 1;
                        f1.SetIntensidad(a);
                    }
                    else if
                     (radioButton2.Checked == true)
                    {
                        posicion = 2;
                        f1.SetIntensidad(a);
                    }
                    else if (radioButton3.Checked == true)
                    {
                        posicion = 3;
                        f1.SetIntensidad(a);
                    }
                    Close();
                }
            }
            catch (FormatException)
            { MessageBox.Show("Debe introducir un valor en el recuadro"); }
        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

