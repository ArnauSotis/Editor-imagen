using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace Proyecto_de_prueba
{
    public partial class ImagenInfo : Form
    {
        Bitmap a;
        OpenFileDialog b;

        public void SetInformacion(OpenFileDialog b)
        { this.b = b; }

        public ImagenInfo(Bitmap a)
        {
            this.a = a;
            InitializeComponent();
        }

        private void ImagenInfo_Load(object sender, EventArgs e)
        {
            string z = Path.GetFileNameWithoutExtension(b.FileName);
            string y = Path.GetExtension(b.FileName);
           string length = Convert.ToString(new System.IO.FileInfo(b.FileName).Length);
            DateTime data=File.GetLastAccessTimeUtc(b.FileName);
            
            label7.Text = z;
            label8.Text = y;
            label9.Text = b.FileName;
            label10.Text = (a.Width + " x " + a.Height);
            label11.Text = (length+" KB ");
            label12.Text = Convert.ToString(data);
         
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
