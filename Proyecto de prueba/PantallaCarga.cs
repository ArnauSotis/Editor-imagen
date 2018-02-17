using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ImagenLib;
using System.Data.OleDb;
using System.IO;
using System.Drawing.Imaging;
using Gestiondata;
using System.Drawing.Drawing2D;

namespace Proyecto_de_prueba
{
    public partial class PantallaCarga : Form 
    {
        DBGestion db = new DBGestion("C:\\Users\\Arnau\\Desktop\\PROYECTOPP\\ProyectoDB\\MyDatabase.sdf");
        Deshacer d = new Deshacer();
        Bitmap bmp;
        Imagen img;
        OpenFileDialog ofd;
      
        byte intensidad;
        float marco;
        string color;
        int pos;
        
        
        public PantallaCarga()
        {
            InitializeComponent();
        }

        public void SetMarco(float marco, string a)
        {

            this.marco = marco;
            this.color = a;

        }

        public void SetIntensidad(byte inten)
        {
            intensidad = inten;
        }
        public void SetColor(int f)
        {
            this.pos = f;

        }

        private void PantallaCarga_Load(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            { AutoScroll = true; }
        }


        public void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\Users\Arnau\Desktop\Imagenes para el proyecto";
            ofd.Filter = "JPEG|*.jpeg|PPM|*.ppm|PNG|*.png|JPG|*.jpg|BMP|*.bmp";
            ofd.Title = "Carga una imagen";


            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string extension = Path.GetExtension(ofd.FileName);
                if (extension == ".ppm")
                {

                    img.CargarImagen(ofd.FileName);
                    bmp = img.GetBitmap();

                }
                else
                {

                    bmp = new Bitmap(ofd.FileName);
                    img = new Imagen(bmp);
                }

                pictureBox1.Image = (Image)bmp;



                pictureBox1.ClientSize = new Size(bmp.Width, bmp.Height);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                informacionToolStripMenuItem1.Enabled = true;
                rotarToolStripMenuItem.Enabled = true;
                invertirToolStripMenuItem.Enabled = true;
                filtrosToolStripMenuItem.Enabled = true;
                deshacerToolStripMenuItem.Enabled = true;
                escalaAGrisesToolStripMenuItem.Enabled = true;
                intensidadDeColorToolStripMenuItem.Enabled = true;
                sakvarToolStripMenuItem.Enabled = true;
                exportarAToolStripMenuItem.Enabled = true;
                AutoScroll = true;
                filtrosToolStripMenuItem.Enabled = true;
                marcoToolStripMenuItem.Enabled = true;
                horizontalToolStripMenuItem1.Enabled = true;
                verticalToolStripMenuItem1.Enabled = true;
                invertirToolStripMenuItem.Enabled = true;
                iluminaciónToolStripMenuItem.Enabled = true;
                cortarToolStripMenuItem.Enabled = true;
                textoToolStripMenuItem.Enabled = true;
            }
        }

        public void sakvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db.OpenDB();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PPM|*.ppm";
            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                img.GuardarImagen(sfd.FileName);

              int a= db.AñadirImagen(Path.GetFileNameWithoutExtension(sfd.FileName), Path.GetExtension(sfd.FileName),Convert.ToInt32(new System.IO.FileInfo(sfd.FileName).Length));

                MessageBox.Show("Imagen guardada correctamente");
            }
            else
                MessageBox.Show("Error de carga");
            db.closeDB();

        }



        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salir salir = new Salir();
            salir.SetBitmap(bmp);
            salir.ShowDialog();
            Close();

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            informacionToolStripMenuItem1.Enabled = false;
            rotarToolStripMenuItem.Enabled = false;
            invertirToolStripMenuItem.Enabled = false;
            filtrosToolStripMenuItem.Enabled = false;
            deshacerToolStripMenuItem.Enabled = false;
            escalaAGrisesToolStripMenuItem.Enabled = false;
            intensidadDeColorToolStripMenuItem.Enabled = false;
            sakvarToolStripMenuItem.Enabled = false;
            exportarAToolStripMenuItem.Enabled = false;
            filtrosToolStripMenuItem.Enabled = false;
            marcoToolStripMenuItem.Enabled = false;
            horizontalToolStripMenuItem1.Enabled = false;
            verticalToolStripMenuItem1.Enabled = false;
            invertirToolStripMenuItem.Enabled = false;
            iluminaciónToolStripMenuItem.Enabled = false;
            cortarToolStripMenuItem.Enabled = false;
            textoToolStripMenuItem.Enabled = false;
           
            int res = db.OpenDB();
            if (res!=0)
            {Console.Error.WriteLine("Incapaz de conectar con la base de datos");
            
            System.Environment.Exit(-1);}

        }


        private void ºToolStripMenuItem_Click(object sender, EventArgs e)
        {
            d.SaveIMG(img);
            bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            this.AutoScroll = true;
            this.Invalidate();
            pictureBox1.Image = (Image)bmp;
            img = new Imagen(bmp);
        }

        private void ºToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            d.SaveIMG(img);
            bmp.RotateFlip(RotateFlipType.Rotate180FlipNone);
            this.AutoScroll = true;
            this.Invalidate();
            pictureBox1.Image = (Image)bmp;
            img = new Imagen(bmp);
        }

        private void ºToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            d.SaveIMG(img);
            bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
            this.AutoScroll = true;
            this.Invalidate();
            pictureBox1.Image = (Image)bmp;
            img = new Imagen(bmp);

        }

        private void deshacerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                bmp = d.RecuIMG().GetBitmap();
                if (bmp != null)
                    pictureBox1.Image = (Image)bmp;
                img = new Imagen(bmp);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No se puede realizar el deshacer ya que no hay más guardados");
            }
        }

        private void informacionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ImagenInfo imgInfo = new ImagenInfo(bmp);
            imgInfo.SetInformacion(ofd);
            imgInfo.Show();
        }

        private void informacionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            d.VaciarIMG();
            pictureBox1.Image = null;
            this.Form1_Load_1(sender, e);
        }

        private void escalaAGrisesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            d.SaveIMG(img);
            img.SetEscalagris();
            bmp = img.GetBitmap();
            pictureBox1.Image = (Image)bmp;
            img = new Imagen(bmp);
        }

        public void intensidadDeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            d.SaveIMG(img);
            Intensidad I1 = new Intensidad();
            I1.ShowDialog();

            img.Intensidad(intensidad, I1.posiciones());
            bmp = img.GetBitmap();
            pictureBox1.Image = (Image)bmp;
            img = new Imagen(bmp);
        }

        private void jPEGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db.OpenDB();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JPEG|*.jpeg";
            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                
                bmp.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                int a = db.AñadirImagen(Path.GetFileNameWithoutExtension(sfd.FileName), Path.GetExtension(sfd.FileName), Convert.ToInt32(new System.IO.FileInfo(sfd.FileName).Length));


                MessageBox.Show("Imagen guardada en formato jpeg");
            }
            db.closeDB();
        }

        private void pNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db.OpenDB();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG|*.png";
            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                bmp.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                int a = db.AñadirImagen(Path.GetFileNameWithoutExtension(sfd.FileName), Path.GetExtension(sfd.FileName), Convert.ToInt32(new System.IO.FileInfo(sfd.FileName).Length));


                MessageBox.Show("Imagen guardada en formato png");
            }
            db.closeDB();
        }

        private void bMPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db.OpenDB();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "BMP|*.bmp";
            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                bmp.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Bmp);

                int a = db.AñadirImagen(Path.GetFileNameWithoutExtension(sfd.FileName), Path.GetExtension(sfd.FileName), Convert.ToInt32(new System.IO.FileInfo(sfd.FileName).Length));

                MessageBox.Show("Imagen guardada en formato bmp");
            }
            db.closeDB();
        }

        private void exportarAToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void marcoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            d.SaveIMG(img);
            Marco m = new Marco();
            m.ShowDialog();
            img.Marco(m.color(), m.grueso());
            bmp = img.GetBitmap();
            pictureBox1.Image = (Image)bmp;
            img = new Imagen(bmp);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void rojoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            d.SaveIMG(img);
            img.filtrorojo();
            bmp = img.GetBitmap();
            pictureBox1.Image = (Image)bmp;
            img = new Imagen(bmp);
        }

        private void azulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            d.SaveIMG(img);
            img.filtroazul();
            bmp = img.GetBitmap();
            pictureBox1.Image = (Image)bmp;
            img = new Imagen(bmp);
        }

        private void verdeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            d.SaveIMG(img);
            img.filtroverde();
            bmp = img.GetBitmap();
            pictureBox1.Image = (Image)bmp;
            img = new Imagen(bmp);
        }

        private void filtrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void iluminaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            d.SaveIMG(img);
            Iluminacion ilu = new Iluminacion();
            ilu.ShowDialog();
            img.SetIluminacion(ilu.SetValor());
            bmp = img.GetBitmap();
            pictureBox1.Image = (Image)bmp;

            img = new Imagen(bmp);
        }
        private void horizontalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            d.SaveIMG(img);
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
            this.AutoScroll = true;
            this.Invalidate();
            pictureBox1.Image = (Image)bmp;
            img = new Imagen(bmp);
        }

        private void verticalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            d.SaveIMG(img);
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
            this.AutoScroll = true;
            this.Invalidate();
            pictureBox1.Image = (Image)bmp;
            img = new Imagen(bmp);
        }

        private void modoPresentaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion p = new Presentacion();
            p.ShowDialog();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Acercade A = new Acercade();
            A.ShowDialog();
        }

        private void baseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBForm dbf = new DBForm();
            dbf.ShowDialog();
        }

        private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            d.SaveIMG(img);
            Cortar cortar = new Cortar();
            cortar.SetBmpWidth(bmp.Width);
            cortar.SetBmpHeight(bmp.Height);
            cortar.ShowDialog();

            bmp=(Bitmap)bmp.Clone(img.RectanguloImagen(cortar.SetCortarX(), cortar.SetCortarY(), bmp.Width, bmp.Height), bmp.PixelFormat);
                pictureBox1.Image = (Image)bmp;
                img = new Imagen(bmp);

            
        }

        private void invertirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            d.SaveIMG(img);
            img.Invertir();
            bmp = img.GetBitmap();
            pictureBox1.Image = (Image)bmp;
            img = new Imagen(bmp);
        }
        private void textoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            d.SaveIMG(img);
            InsertarTexto it = new InsertarTexto();
            Bitmap bmap = (Bitmap)bmp.Clone();
            it.ShowDialog();

            if (it.Cancelar() == false)
            {
                string fontName = it.SetTextFuente(), fontStyle = it.SetTextFuenteEstilo();
                float fontSize = it.SetTextFuenteTamaño();

                if (string.IsNullOrEmpty(fontName))
                    fontName = "Times New Roman";
                if (fontSize.Equals(null))
                    fontSize = Convert.ToInt32(10);
                Font font = new Font(fontName, fontSize);
                if (!string.IsNullOrEmpty(it.SetTextFuenteEstilo()))
                {
                    FontStyle fStyle = FontStyle.Regular;
                    switch (fontStyle.ToLower())
                    {
                        case "bold":
                            fStyle = FontStyle.Bold;
                            break;
                        case "italic":
                            fStyle = FontStyle.Italic;
                            break;
                        case "underline":
                            fStyle = FontStyle.Underline;
                            break;
                        case "strikeout":
                            fStyle = FontStyle.Strikeout;
                            break;

                    }
                    font = new Font(fontName, fontSize, fStyle);
                }

                Color c1 = ColorTranslator.FromHtml(it.SetTextColor1());
                Graphics gr = Graphics.FromImage(bmp);
                int gW = (int)(it.SetTexto().Length * it.SetTextFuenteTamaño());
                gW = gW == 9 ? 10 : gW;
                LinearGradientBrush LGBrush = new LinearGradientBrush(new Rectangle(0, 0, gW, (int)it.SetTextFuenteTamaño()), c1, c1, LinearGradientMode.Vertical);
                gr.DrawString(it.SetTexto(), font, LGBrush, it.SetX(), it.SetY());

                bmp = (Bitmap)bmp.Clone();
                pictureBox1.Image = (Image)bmp;
                img = new Imagen(bmp);
            }

        }

        private void dibujarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Dibujo d = new Dibujo();
            d.ShowDialog();
        }

        
        }
    }



    

