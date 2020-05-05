using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Windows.Controls;
using System.Windows;
using System.Data.SqlClient;

namespace prjSQLite
{
    class SqlDB
    {
        public static SQLiteConnection sqlconn = new SQLiteConnection("Data Source=.\\dbVerwaltung.db");
        public static SQLiteCommand sqlcmd;
        public static DataTable sqlDt = new DataTable();
        public static DataSet DS = new DataSet();
        public static SQLiteDataAdapter DA;

        
        public static DataTable LoadData()
        {
            sqlDt.Clear();
            sqlconn.Open();
            sqlcmd = sqlconn.CreateCommand();
            sqlcmd.CommandText = "SELECT * FROM Kunden";
            using (DA = new SQLiteDataAdapter(sqlcmd.CommandText, sqlconn))
            {
                DA.Fill(sqlDt);
                sqlconn.Close();
                return sqlDt;
            }        
        }

        public static void AddData(params string[] arrParam)
        {
            try
            {
                sqlconn.Open();
                sqlcmd = sqlconn.CreateCommand();
                sqlcmd.CommandText = "INSERT INTO Kunden (Vorname, Nachname, Strasse, PLZ, Ort)" +
                                     "VALUES (@newVorname, @newNachname, @newStrasse, @newPLZ, @newOrt)";
                sqlcmd.Parameters.AddWithValue("@newVorname", arrParam[0]);
                sqlcmd.Parameters.AddWithValue("@newNachname", arrParam[1]);
                sqlcmd.Parameters.AddWithValue("@newStrasse", arrParam[2]);
                sqlcmd.Parameters.AddWithValue("@newPLZ", arrParam[3]);
                sqlcmd.Parameters.AddWithValue("@newOrt", arrParam[4]);
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }
}

        public static void Update(params string[] arrParam)
        {
            //try
            //{
                sqlconn.Open();
                sqlcmd = sqlconn.CreateCommand();
                sqlcmd.CommandText = "UPDATE Kunden set Vorname=@newVorname, Nachname=@newNachname, " +
                                     "Strasse=@newStrasse, PLZ=@newPLZ, Ort=@newOrt " +
                                     "WHERE KundeID=@ID";
                sqlcmd.Parameters.AddWithValue("@ID", arrParam[0]);
                sqlcmd.Parameters.AddWithValue("@newVorname", arrParam[1]);
                sqlcmd.Parameters.AddWithValue("@newNachname", arrParam[2]);
                sqlcmd.Parameters.AddWithValue("@newStrasse", arrParam[3]);
                sqlcmd.Parameters.AddWithValue("@newPLZ", arrParam[4]);
                sqlcmd.Parameters.AddWithValue("@newOrt", arrParam[5]);
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            //}
}



    }
}
