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
    public partial class InsertarTexto : Form
    {
        bool Cancelarlo = false;
        float textfuentetamaño;
        int x, y;
        string texto, textfuente, textfuenteestilo, textcolor1;
        public bool Cancelar()
        { return Cancelarlo; }
        public float SetTextFuenteTamaño()
        { return textfuentetamaño; }
        public int SetX()
        { return x; }
        public int SetY()
        { return y; }
        public string SetTexto()
        { return texto; }
        public string SetTextFuente()
        { return textfuente; }
        public string SetTextFuenteEstilo()
        { return textfuenteestilo; }
        public string SetTextColor1()
        { return textcolor1; }

        public InsertarTexto()
        {
            InitializeComponent();
        }

        private void InsertarTexto_Load(object sender, EventArgs e)
        {
            // Carga las fuentes
            foreach (FontFamily ff in FontFamily.Families)
            {
                cmbFonts.Items.Add(ff.Name);
            }
            // Carga el tamaño de la fuente
            for (int i = 5; i <= 75; i += 5)
            {
                cmbFontSize.Items.Add(i);
            }
            // Carga el estilo de la fuente
            cmbFontStyles.Items.Add("Bold");
            cmbFontStyles.Items.Add("Italic");
            cmbFontStyles.Items.Add("Regular");
            cmbFontStyles.Items.Add("Strikeout");
            cmbFontStyles.Items.Add("Underline");
            // Carga los colores
            Type type = typeof(System.Drawing.Color);
            System.Reflection.PropertyInfo[] propertyInfo = type.GetProperties();
            for (int i = 0; i < propertyInfo.Length; i++)
            {
                if (propertyInfo[i].Name != "Transparent"
                    && propertyInfo[i].Name != "R"
                    && propertyInfo[i].Name != "G"
                    && propertyInfo[i].Name != "B"
                    && propertyInfo[i].Name != "A"
                    && propertyInfo[i].Name != "IsKnownColor"
                    && propertyInfo[i].Name != "IsEmpty"
                    && propertyInfo[i].Name != "IsNamedColor"
                    && propertyInfo[i].Name != "IsSystemColor"
                    && propertyInfo[i].Name != "Name")
                {
                    cmbColors1.Items.Add(propertyInfo[i].Name);
                   
                }
            }

        }

       
      
        private void btnOK_Click(Object sender, EventArgs e)
        { 

        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            //Cuando clickas aceptar
            try
            {
                x = Convert.ToInt32(txtX.Text);
                y = Convert.ToInt32(txtY.Text);
                texto = txtText.Text;
                textfuente = cmbFonts.SelectedItem.ToString();
                textfuentetamaño = Convert.ToInt32(cmbFontSize.SelectedItem);


                textfuenteestilo = cmbFontStyles.SelectedItem.ToString();
                textcolor1 = cmbColors1.SelectedItem.ToString();
                Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Introduzca los valores correctos");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Introduzca los valores");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
            Cancelarlo = true;
        }
    }
}
