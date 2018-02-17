using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImagenLib;

namespace ImagenLib
{
    public class Pixel
    {
        byte R;
        byte G;
        byte B;

        public Pixel(byte a, byte b, byte c)
        {
            this.R = a;
            this.G = b;
            this.B = c;
        }
        public Pixel()
        {
            this.R = 0;
            this.G = 0;
            this.B = 0;
        
        }
        
      
        public void SetColorR(byte a)
        {
            this.R = a;
        }
        public void SetColorG(byte b)
        {
            this.G = b;
        }
        public void SetColorB(byte c)
        {
            this.B = c;
        }

        public byte GetR()
        {
            return (this.R);
        }
        public byte GetG()
        {
            return (this.G);
        }
        public byte GetB()
        {
            return (this.B);
        }
        public void SetColorNegroR()
        {
            this.R = 252;
        }
        public void CambiarColor(byte a, byte b, byte c)
        {
            this.R = a;
            this.G = b;
            this.B = c;
        }
        public Pixel ObtenerCopia()
        {
            Pixel p = new Pixel(this.R, this.G, this.B);

            return p;
        }
    }
}
