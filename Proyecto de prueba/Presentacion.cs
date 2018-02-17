using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Timers;
using System.IO;
using System.Reflection;
using Proyecto_de_prueba.Properties;

namespace Proyecto_de_prueba
{
    public partial class Presentacion : Form
    {
        string[] ruta;
        int posicionImag = 0, totalImg = 0;
        int k = 0;

    public Presentacion()
    {
        InitializeComponent();
    }

   
    private void cargarImágenesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        posicionImag = 0;
        openFileDialog.Filter = "JPEG|*.jpeg|PPM|*.ppm|PNG|*.png|JPG|*.jpg|BMP|*.bmp";
        openFileDialog.Multiselect = true;
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            totalImg = openFileDialog.FileNames.Length;
            ruta = new string[totalImg];
            for (int i = 0; i < totalImg; i++)
            {
                ruta[i] = openFileDialog.FileNames[i];
            }
            pictureBox1.Image = Image.FromFile(ruta[posicionImag]);
            
            
            if (totalImg > 1)
            {
                button2.Enabled = true;
                button3.Enabled = true;
                Añadirtiempo.Enabled = true;
                button5.Enabled = true;
            }
        }
    }

    private void Presentacion_Load(object sender, EventArgs e)
    {

        button1.Enabled = false;
        button2.Enabled = false;
        button3.Enabled = false;
        button4.Enabled = false;
        MásRápido.Enabled = false;
        Máslento.Enabled = false;
        Añadirtiempo.Enabled = false;
        button5.Enabled = false;
        button6.Enabled = false;
        
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        try
        {
            posicionImag++;
            pictureBox1.Image = Image.FromFile(ruta[posicionImag]);
        }
        catch (IndexOutOfRangeException)
        {
            timer1.Stop();
            button4.Enabled = true;
            button2.Enabled = true;
       
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        try
        {
            posicionImag++;
            pictureBox1.Image = Image.FromFile(ruta[posicionImag]);
            button4.Enabled = true;
            if (posicionImag == (totalImg - 1))
                button2.Enabled = false;
        }
        catch(IndexOutOfRangeException)
        { MessageBox.Show("No hay más imágenes"); }
        
    }

    private void button4_Click(object sender, EventArgs e)
    {
        try
        {
            posicionImag--;
            pictureBox1.Image = Image.FromFile(ruta[posicionImag]);
            button2.Enabled = true;
            if (posicionImag == 0)
                button4.Enabled = false;
        }
        catch (IndexOutOfRangeException)
        { MessageBox.Show("No hay más imágenes"); }
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {

    }

    private void button3_Click(object sender, EventArgs e)
    {
        timer1.Stop();
    }

    private void Añadirtiempo_Click(object sender, EventArgs e)
    {
        Tiempo t = new Tiempo();
        t.ShowDialog();
        timer1.Start();
        int g = t.SetTime();
        if (g > 0)
        {
            
            timer1.Interval = t.SetTime();
            k = t.SetTime();
            button6.Enabled = true;
            MásRápido.Enabled = true;
            Máslento.Enabled = true;
            button2.Enabled = false;
            button4.Enabled = false;
        }
        else
            timer1.Stop();
    }

    private void MásRápido_Click(object sender, EventArgs e)
    {
        timer1.Interval = timer1.Interval * 1 / 2;
    }

    private void Máslento_Click(object sender, EventArgs e)
    {
        timer1.Interval = timer1.Interval * 2;
    }

    private void button5_Click(object sender, EventArgs e)
    {
        posicionImag = 0;
        
        pictureBox1.Image = Image.FromFile(ruta[posicionImag]);
        button2.Enabled = true;

            

    }

    private void button6_Click(object sender, EventArgs e)
    {
        if (timer1.Interval > 0) 
            timer1.Interval = k;
        timer1.Start();
    }
    }

    
}