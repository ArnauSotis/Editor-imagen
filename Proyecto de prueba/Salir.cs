using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gestiondata;
using System.IO;

namespace Proyecto_de_prueba
{
    public partial class Salir : Form
    {
        DBGestion db = new DBGestion("C:\\Users\\Arnau\\Desktop\\PROYECTOPP\\ProyectoDB\\MyDatabase.sdf");
        Bitmap Bitmap;
        public void SetBitmap(Bitmap a)
        { 
            this.Bitmap = a;
        }

        public Salir()
        {
            InitializeComponent();
        }

        private void Salir_Load(object sender, EventArgs e)
        { }
        

        private void button1_Click_1(object sender, EventArgs e)
        {
            db.OpenDB();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PPM|*.ppm";
            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                pictureBox1.Image = (Image)Bitmap;
                pictureBox1.Image.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                int a = db.AñadirImagen(Path.GetFileNameWithoutExtension(sfd.FileName), Path.GetExtension(sfd.FileName), Convert.ToInt32(new System.IO.FileInfo(sfd.FileName).Length));


                MessageBox.Show("Imagen guardada correctamente");
            }
            else
                MessageBox.Show("Error de carga");
            db.closeDB();
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}