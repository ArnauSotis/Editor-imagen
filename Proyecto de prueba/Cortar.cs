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
    public partial class Cortar : Form
    {
        int X, Y, Ancho, Alto, AnchoInicial, AltoInicial;
        public Cortar()
        {
            InitializeComponent();
        }
        public int SetCortarX()
        { return X; }
        public int SetCortarY()
        { return Y; }
        public int SetCortarAncho()
        { return Ancho; }
        public int SetCortarAlto()
        { return Alto; }

        public void SetBmpHeight(int a)
        { AltoInicial = a; }
        public void SetBmpWidth(int a)
        { AnchoInicial = a; }
        private void Cortar_Load(object sender, EventArgs e)
        {
            textBox2.Text = AnchoInicial.ToString();
            textBox4.Text = AltoInicial.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                X = Convert.ToInt32(textBox1.Text);
                Y = Convert.ToInt32(textBox3.Text);
                Alto = Convert.ToInt32(textBox2.Text);
                Ancho = Convert.ToInt32(textBox4.Text);
            }
            catch (FormatException)
            { MessageBox.Show("Solo se aceptan números enteros"); }


            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

