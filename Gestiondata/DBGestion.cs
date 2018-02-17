using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace Gestiondata
{
    public class DBGestion
    {
        OleDbConnection cnx;
        string providerStr = "Provider=Microsoft.SQLSERVER.CE.OLEDB.3.5;";
        string cnxStr;

        public DBGestion(string dbFileName)
        {
            cnxStr = providerStr + "Data Source=" + dbFileName + ";Persist Security Info=False;";


        }
        public int OpenDB()
        {
            try
            {

                cnx = new OleDbConnection(cnxStr);
                cnx.Open();
            }
            catch (OleDbException)
            {
                return -1;

            }
            return 0;
        }
        public void closeDB()
        {
            if (cnx != null)
            {
                cnx.Close();
                cnx = null;
            }
        }

        public DataTable getAll()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Imagenes";
            OleDbDataAdapter adp = new OleDbDataAdapter(query, cnx);
            adp.Fill(dt);
            return dt;
        }
        public int AñadirImagen(string nombre, string formato, int tamaño)
        {
            string query = "INSERT INTO Imagenes" +
                    " VALUES('" + nombre + "'," + tamaño + ",'" + formato + "')";
            OleDbCommand command = new OleDbCommand(query, cnx);
           int num= command.ExecuteNonQuery();
           return num;

        }
        public int BorrarNombre(string nombre)
        {
            string query = "DELETE FROM Imagenes WHERE Nombre='" + nombre + "'";
            OleDbCommand command = new OleDbCommand(query, cnx);
            int res = command.ExecuteNonQuery();
            return res;
        }

        public int CambiarNombre(string nombrenuevo, string nombreviejo)
        {
            string query = "UPDATE Imagenes" +
                           " SET Nombre='" + nombrenuevo +
                           "' WHERE Nombre='" + nombreviejo + "'";
            OleDbCommand command = new OleDbCommand(query, cnx);
            int g= command.ExecuteNonQuery();
            return g;
        }
    }
}

