using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ImagenLib;
using System.Drawing;
using Proyecto_de_prueba;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


namespace ImagenLib
{
    public class Imagen
    {
        public Pixel[,] datos;
        public int ancho, alto;
        public string id;
        public int niveles;


        //Carga el Bitmap
        public Bitmap GetBitmap()
        {
            Bitmap bmp = new Bitmap(this.ancho, this.alto);

            for (int i = 0; i < this.alto; i++)
            {
                for (int j = 0; j < this.ancho; j++)
                {
                    Pixel a = this.datos[i, j];

                    bmp.SetPixel(j, i, Color.FromArgb(a.GetR(), a.GetG(), a.GetB()));

                }


            }


            return bmp;
        }

        //Constructor de la img bmp
        public Imagen(Bitmap bmp)
        {

            this.alto = bmp.Height;
            this.ancho = bmp.Width;
            this.id = "P3";
            this.niveles = 255;
            this.datos = new Pixel[bmp.Height, bmp.Width];
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    Color c = bmp.GetPixel(j, i);
                    this.datos[i, j] = new Pixel(c.R, c.G, c.B);
                }


            }

        }

        //Constructor de la img
        public Imagen(int a, int c, string t, int n, Pixel[,] p)
        {
            this.alto = a;
            this.ancho = c;
            this.id = t;
            this.niveles = n;
            this.datos = new Pixel[a, c];
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    this.datos[i, j] = p[i, j].ObtenerCopia();
                }
            }
        }

        public int GetAncho()
        { return this.ancho; }

        public void SetAncho(int ancho)
        { this.ancho = ancho; }

        public int GetAlto()
        { return this.alto; }

        public void SetAlto(int alto)
        { this.alto = alto; }

        public string GetId()
        { return this.id; }

        public void SetId(string id)
        { this.id = id; }

        public int GetValorMax()
        { return this.niveles; }

        public void SetValorMax(int valorMaximo)
        { this.niveles = valorMaximo; }

        public void MostrarCabecera()
        {
            Console.Write(this.id + "    ");
        }

        //Muestra los bits en pantalla
        public void MostrarMatriz()
        {
            for (int i = 0; i < this.alto; i++)
                for (int j = 0; j < this.ancho; j++)
                {
                    Console.Write(this.datos[i, j].GetR() + "    ");
                    Console.Write(this.datos[i, j].GetG() + "    ");
                    Console.WriteLine(this.datos[i, j].GetB() + "    ");
                }

        }
        //Cambia el color de los bytes
        public void CambiarColor(int fila, int columna, byte a, byte b, byte c)
        {
            datos[fila, columna].SetColorR(a);
            datos[fila, columna].SetColorG(b);
            datos[fila, columna].SetColorB(c);
        }

        //Gira la imagen
        public void VoltearImagen()
        {
            Pixel temp;
            this.ancho = this.ancho % 2;
            for (int i = 0; i < this.ancho; i++)
                for (int j = 0; j < this.alto; j++)
                {
                    temp = this.datos[i, j];
                    this.datos[i, j] = this.datos[j, i];
                    this.datos[j, i] = temp;
                }
        }

        //Carga la imagen
        public int CargarImagen(String nombreFichero)
        {try
            {
            String[] AltoyAncho = new String[2];
            String Linea;
            Pixel a;
            int b;
            String[] RGB = new String[100000];
            StreamReader q;
            
                q = new StreamReader(nombreFichero);
           

            this.SetId(q.ReadLine());

            Linea = q.ReadLine();

            AltoyAncho = Linea.Split(' ');

            this.SetAncho(Convert.ToInt32(AltoyAncho[0]));

            this.SetAlto(Convert.ToInt32(AltoyAncho[1]));

            this.SetValorMax(Convert.ToInt32(q.ReadLine()));
 
            this.datos = new Pixel[alto, ancho];

            for (int i = 0; i < alto; i++)
            {
                Linea = q.ReadLine();
                RGB = Linea.Split(' ');
                b = 0;
                for (int j = 0; j < ancho; j++)
                {
                    a = new Pixel();
                    a.SetColorR(Convert.ToByte(RGB[b])); b++;
                    a.SetColorB(Convert.ToByte(RGB[b])); b++;
                    a.SetColorG(Convert.ToByte(RGB[b])); b++;
                    this.datos[i, j] = a;

                }
            }
            q.Close();
            return 0;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Fichero no encontrado.");
                return -1;
            }

        }

        //Pasa la imagen a blanco y negro analizando cada bit y transformandolo a un espectro de blanco-negro
        public void SetEscalagris()
        {
            for (int i = 0; i < alto; i++)
            {
                for (int j = 0; j < ancho; j++)
                {
                    byte gris = (byte)(.299 * this.datos[i, j].GetR() + .587 * this.datos[i, j].GetG() + .114 * this.datos[i, j].GetB());

                    this.datos[i, j].CambiarColor(gris, gris, gris);
                }
            }
        }

        //Cambia los valores de bytes para aumentarlos o reducirlos
        public void Intensidad(byte intensidad, int posicion)
        {
            if (posicion == 1)
            {
                for (int i = 0; i < alto; i++)
                {
                    for (int j = 0; j < ancho; j++)
                    {
                        datos[i, j].SetColorR(intensidad);
                    }
                }
            }
            if (posicion == 2)
            {
                for (int i = 0; i < alto; i++)
                {
                    for (int j = 0; j < ancho; j++)
                    {
                        datos[i, j].SetColorG(intensidad);
                    }
                }
            }
            if (posicion == 3)
            {
                for (int i = 0; i < alto; i++)
                {
                    for (int j = 0; j < ancho; j++)
                    {
                        datos[i, j].SetColorB(intensidad);
                    }
                }
            }

        }
        
        //Guarda la imagen en un fichero
        public void GuardarImagen(String nombreFichero)
        {
            StreamWriter q = new StreamWriter(nombreFichero);
            q.WriteLine(this.id);
            q.Write(this.ancho);
            q.Write(' ');
            q.WriteLine(this.alto);
            q.WriteLine(this.niveles);
            for (int i = 0; i < this.alto; i++)
            {
                for (int j = 0; j < this.ancho; j++)
                {
                    q.Write(this.datos[i, j].GetR()); q.Write(' ');
                    q.Write(this.datos[i, j].GetG()); q.Write(' ');
                    q.Write(this.datos[i, j].GetB()); q.Write(' ');
                }
                q.WriteLine();
            }
            q.Close();

        }

        //Modifica los pixeles seleccionados
        public void ModificaPixel(int fila, int columna, byte r, byte g, byte b)
        {
            datos[fila, columna].SetColorR(r);
            datos[fila, columna].SetColorG(g);
           datos[fila, columna].SetColorB(b);
        }

        //Devuelve la imagen
        public Imagen Copyimg()
        {
            Imagen I = new Imagen(this.alto, this.ancho, this.id, this.niveles, this.datos);
            return I;
        }

        //Añade un marco a la imagen
        public void Marco(string color, float grosor)
        {
            Color c = ColorTranslator.FromHtml(color);
            int anchomarco = Convert.ToInt32(ancho - grosor);
            int altomarco = Convert.ToInt32(alto - grosor);


            // Parte de arriba del cuadro
            for (int i = 0; i < grosor; i++)
            {
                for (int j = 0; j < ancho; j++)
                {
                    CambiarColor(i, j, c.R, c.G, c.B);

                }
            }
            // Parte de la izquierda del cuadro
            for (int i = 0; i < alto; i++)
            {
                for (int j = 0; j < grosor; j++)
                {
                    CambiarColor(i, j, c.R, c.G, c.B);

                }
            }
            // Parte de la derecha del cuadro
            for (int i = 0; i < alto; i++)
            {
                for (int j = anchomarco; j < ancho; j++)
                {
                    CambiarColor(i, j, c.R, c.G, c.B);

                }
            }
            // Parte de abajo del cuadro
            for (int i = altomarco; i < alto; i++)
            {
                for (int j = 0; j < ancho; j++)
                {
                    CambiarColor(i, j, c.R, c.G, c.B);

                }
            }
        }

            //Filtra todos los colores menos el rojo
            public void filtrorojo()
        {
            for (int i = 0; i < alto; i++)
            {
                for (int j = 0; j < ancho; j++)
                {
                    CambiarColor(i, j, this.datos[i,j].GetR(), 0, 0);
                }

            }
            
        }
        //Filtra todos los colores menos el azul
            public void filtroazul()
            {
                for (int i = 0; i < alto; i++)
                {
                    for (int j = 0; j < ancho; j++)
                    {
                        CambiarColor(i, j, 0,0,this.datos[i, j].GetB() );
                    }

                }

            }
        //Filtra todos los colores menos el verde
            public void filtroverde()
            {
                for (int i = 0; i < alto; i++)
                {
                    for (int j = 0; j < ancho; j++)
                    {
                        CambiarColor(i, j, 0, this.datos[i, j].GetG(), 0);
                    }

                }

            }
        //Aumenta el grado de iluminación de la imagen
            public void SetIluminacion(int valor)
            {
                for (int i = 0; i < alto; i++)
                {
                    for (int j = 0; j < ancho; j++)
                    {
                        byte valorR, valorG, valorB;

                        if (this.datos[i, j].GetR() + valor > 255)
                            valorR = 255;
                        else if (this.datos[i, j].GetR() + valor < 0)
                            valorR = 0;
                        else
                            valorR = Convert.ToByte(this.datos[i, j].GetR() + valor);
                        if (this.datos[i, j].GetG() + valor > 255)
                            valorG = 255;
                        else if (this.datos[i, j].GetG() + valor < 0)
                            valorG = 0;
                        else
                            valorG = Convert.ToByte(this.datos[i, j].GetG() + valor);
                        if (this.datos[i, j].GetB() + valor > 255)
                            valorB = 255;
                        else if (this.datos[i, j].GetB() + valor < 0)
                            valorB = 0;
                        else
                            valorB = Convert.ToByte(this.datos[i, j].GetB() + valor);

                             

                        this.datos[i, j].CambiarColor(valorR, valorG, valorB);


                    }
                }
            }
        //Invierte los colores (255-x)
            public void Invertir()
            {

                for (int i = 0; i < alto; i++)
                {
                    for (int j = 0; j < ancho; j++)
                    {
                        byte a = Convert.ToByte(255 - this.datos[i, j].GetR());
                        byte b = Convert.ToByte(255 - this.datos[i, j].GetG());
                        byte c = Convert.ToByte(255 - this.datos[i, j].GetB());
                        this.datos[i,j].CambiarColor(a, b, c);
                    }
                }
            }
        
            public Rectangle RectanguloImagen(int x, int y, int anchos, int altos)
            {
                // Devuelve el rectángulo que hay que crear para la imagen
                if (x + anchos > this.ancho)
                    this.ancho = this.ancho - x;
                if (y + altos > this.alto)
                   this.alto = this.alto - y;
                Rectangle rect = new Rectangle(x, y, ancho, alto);
                return rect;
            }
           
    }
}


        
       



