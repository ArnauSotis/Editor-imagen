using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gestiondata;

namespace Proyecto_de_prueba
{
    public partial class DBForm : Form
    {
       
        string dbLocation = "C:\\Users\\Arnau\\Desktop\\PROYECTOPP\\ProyectoDB\\MyDatabase.sdf";
        DBGestion db;

        public DBForm()
        {
            InitializeComponent();
            db = new DBGestion(dbLocation);
            int res = db.OpenDB();
            if (res != 0)
            {
                MessageBox.Show("Error abriendo la base de datos");
            }
        }


        private void DBForm_Load(object sender, EventArgs e)
        {
            DataTable dt = db.getAll();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.OpenDB();
            int a = db.BorrarNombre(textBox1.Text);
            DataTable dt = db.getAll();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            db.closeDB();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            db.OpenDB();
            int a = db.CambiarNombre(textBox3.Text, textBox2.Text);
            DataTable dt = db.getAll();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            db.closeDB();
        }
    }
}
