using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SQLite2
{
    internal class DataAccess
    {
        public async static void InitializeDatabase()
        {
            using (SqliteConnection db =
            new SqliteConnection($"Filename=sqliteSample.db"))
            {
                db.Open();
                String tableCommand = "CREATE TABLE IF NOT " +
                "EXISTS MyTable (Primary_Key INTEGER PRIMARY KEY, " +
                "Text_Entry NVARCHAR(2048) NULL)";
                SqliteCommand createTable = new SqliteCommand(tableCommand, db);
                createTable.ExecuteReader();
            }
        }
        public static void AddData(string inputText)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=sqliteSample.db"))
            {
                db.Open();
                SqliteCommand insertComand = new SqliteCommand();
                insertComand.Connection = db;
                insertComand.CommandText = "INSERT INTO MyTable VALUES(NULL, @Entry)";
                insertComand.Parameters.AddWithValue("@Entry", inputText);
                insertComand.ExecuteReader();
                db.Close();
                
            }
        }

        public static List<string> GetData()
        {
            List<string> entries = new List<string>();
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteSample.db"))
            {
                db.Open();
                SqliteCommand selectComand = new SqliteCommand("SELECT Text_Entry FROM MyTable", db);
                SqliteDataReader query = selectComand.ExecuteReader();
                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                }
                db.Close();
                return entries;
            }
        }

    }
}
