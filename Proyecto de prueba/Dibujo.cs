using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Gestiondata;
using System.Data.OleDb;
using System.IO;

namespace Proyecto_de_prueba
{
    public partial class Dibujo : Form
    {
        DBGestion db = new DBGestion("C:\\Users\\Arnau\\Desktop\\PROYECTOPP\\ProyectoDB\\MyDatabase.sdf");
        Bitmap bmpScreenshot;
        Graphics gfxScreenshot;

        Graphics paint;
        Pen myPen;
        Point fp = new Point(0, 0);
        Point ep = new Point(0, 0);
        Color ColorFondo;
        int k = 0;
        int Counter = 0;
        string cdm;
        public Dibujo()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            myPen.Color = pictureBox3.BackColor;
            pictureBox2.BackColor = pictureBox3.BackColor;
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            myPen.Color = pictureBox18.BackColor;
            pictureBox2.BackColor = pictureBox18.BackColor;
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            myPen.Color = pictureBox17.BackColor;
            pictureBox2.BackColor = pictureBox17.BackColor;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            myPen.Color = pictureBox4.BackColor;
            pictureBox2.BackColor = pictureBox4.BackColor;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            myPen.Color = pictureBox5.BackColor;
            pictureBox2.BackColor = pictureBox5.BackColor;
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            myPen.Color = pictureBox16.BackColor;
            pictureBox2.BackColor = pictureBox16.BackColor;
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            myPen.Color = pictureBox15.BackColor;
            pictureBox2.BackColor = pictureBox15.BackColor;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            myPen.Color = pictureBox6.BackColor;
            pictureBox2.BackColor = pictureBox6.BackColor;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            myPen.Color = pictureBox7.BackColor;
            pictureBox2.BackColor = pictureBox7.BackColor;
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            myPen.Color = pictureBox14.BackColor;
            pictureBox2.BackColor = pictureBox14.BackColor;
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            myPen.Color = pictureBox13.BackColor;
            pictureBox2.BackColor = pictureBox13.BackColor;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            myPen.Color = pictureBox8.BackColor;
            pictureBox2.BackColor = pictureBox8.BackColor;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            myPen.Color = pictureBox9.BackColor;
            pictureBox2.BackColor = pictureBox9.BackColor;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            myPen.Color = pictureBox12.BackColor;
            pictureBox2.BackColor = pictureBox12.BackColor;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            myPen.Color = pictureBox11.BackColor;
            pictureBox2.BackColor = pictureBox11.BackColor;
        }

        private void Dibujo_MouseUp(object sender, MouseEventArgs e)
        {
            k = 0;
        }

        private void Dibujo_MouseMove(object sender, MouseEventArgs e)
        {
            if (k == 1)
            {
                fp = e.Location;
                paint = this.CreateGraphics();
                paint.DrawLine(myPen, ep, fp);
            }
            ep = fp;
        }

        private void Dibujo_MouseDown(object sender, MouseEventArgs e)
        {
            ep = e.Location;
            if (e.Button == MouseButtons.Left)
            { k = 1; }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guardarImagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
           
        }

        private void Dibujo_Load(object sender, EventArgs e)
        {
           
           myPen = new Pen(Color.Black, 1);
           foreach (System.Reflection.PropertyInfo prop in typeof(Color).GetProperties())
           {
               if (prop.PropertyType.FullName == "System.Drawing.Color")
                   comboBox1.Items.Add(prop.Name);
           }
        }

        private void guardarImagenToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            db.OpenDB();

            var bmpScreenshot = new Bitmap(ClientSize.Width+40,
                                  ClientSize.Height-50,
                                  PixelFormat.Format32bppArgb);

            // Crea los gráficos del Bitmap.
            var gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            //Marca los puntos laterales
            gfxScreenshot.CopyFromScreen(Location.X,
                                        Location.Y,
                                        0,
                                        0,
                                        Screen.PrimaryScreen.Bounds.Size,
                                        CopyPixelOperation.SourceCopy);

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JPEG|*.jpeg";
            
            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                bmpScreenshot.Save(sfd.FileName, ImageFormat.Png);
                int a = db.AñadirImagen(Path.GetFileNameWithoutExtension(sfd.FileName), Path.GetExtension(sfd.FileName), Convert.ToInt32(new System.IO.FileInfo(sfd.FileName).Length));


                MessageBox.Show("Imagen guardada en formato jpeg");
            }
            db.closeDB();
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {

            if (k == 1)
            {
                fp = e.Location;
                paint = this.CreateGraphics();
                paint.DrawLine(myPen, ep, fp);
            }
            ep = fp;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            k = 0;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ep = e.Location;
            if (e.Button == MouseButtons.Left)
            { k = 1; }
        }

        private void limpiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paint.Clear(Color.White);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Counter++;
            if (Counter > 5)
                Counter = 5;
            Color a = myPen.Color;
            if(Counter==1)
            {myPen=new Pen(a,2);
           
            }
             if(Counter==2)
            {myPen=new Pen(a,4);}
            
             if(Counter==3)
            {myPen=new Pen(a,8);
          
            }
             if(Counter==4)
            {myPen=new Pen(a,16);
           
            }
             if(Counter==5)
            {myPen=new Pen(a,32);
            
            }
              

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Counter--;
            if (Counter < 0)
                Counter = 0;
            Color a = myPen.Color;
            if (Counter ==0)
            {myPen=new Pen(a,1);}
            if (Counter == 1)
            {
                myPen = new Pen(a, 2);

            }
            if (Counter == 2)
            { myPen = new Pen(a, 4); }

            if (Counter == 3)
            {
                myPen = new Pen(a, 8);

            }
            if (Counter == 4)
            {
                myPen = new Pen(a, 16);

            }
              
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cdm = comboBox1.SelectedItem.ToString();
            ColorFondo = ColorTranslator.FromHtml(cdm);
            BackColor = ColorFondo;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            paint.Clear(ColorFondo);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            myPen.Color = ColorFondo;
            pictureBox2.BackColor = ColorFondo;
        }
    }
}
