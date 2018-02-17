using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Proyecto_de_prueba
{
    public partial class Marco : Form
    {
        float grosor;
        string cdm;
        public Marco()
        {
            InitializeComponent();
        }
        public float grueso()
        { return grosor; }
        public string color()
        { return cdm; }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                PantallaCarga f1 = new PantallaCarga();
                cdm = comboBox1.SelectedItem.ToString();

                grosor = (float)Convert.ToDouble(textBox2.Text);

                Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Introduzca un número");
            }
            catch (NullReferenceException)
            { MessageBox.Show("Introduzca un color de la lista");}
        }

        private void Marco_Load(object sender, EventArgs e)
        {
            foreach (System.Reflection.PropertyInfo prop in typeof(Color).GetProperties())
            {
                if (prop.PropertyType.FullName == "System.Drawing.Color")
                    comboBox1.Items.Add(prop.Name);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
