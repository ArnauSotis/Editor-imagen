 using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Text;
 using System.Data.OleDb;
 using System.Data;
namespace Gestion
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

        public int openDB()
        {
            try
            {
                cnx = new OleDbConnection(cnxStr);
                cnx.Open();
            }
            catch (OleDbException)
            {
                return 1;
            }
            return 0;
        }
        // Close the connection with the database
        public void closeDB()
        {
            if (cnx != null)
            {
                cnx.Close();
                cnx = null;
            }
        }

    }
}
