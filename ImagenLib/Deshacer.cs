using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImagenLib;
using Proyecto_de_prueba;

namespace Proyecto_de_prueba
{ 
    public class Deshacer //antes de modificar la imgen ya sea voltear o recortar o lo que sea. llamo a la clase
    {
        Stack<Imagen> Pila = new Stack<Imagen>();

        public void SaveIMG(Imagen I) //funcion que va metiendo en la pila todos los pasos o procedimentos
        {
            Imagen i = I.Copyimg();
            Pila.Push(i);
        }
        public Imagen RecuIMG() //funcion que devuelve el ultimo movimiento/procediemnto/paso.
        {
            if (Pila.Count > 0)
                return Pila.Pop();
            else
                return null;

        }
        public void VaciarIMG() //funcion que vacia completamente la papelera.
        {
            Pila.Clear();
        }
    }
}
