using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace FilteringProject.DataAccessLayer
{
    public class SqlLiteDataAccess : IDataAccess
    {
        private string DB_PATH = "okey.db"; // Please make sure that a correct path for given okey.db data file is provided
   
        public List<Dictionary<string, string>> Read()
        {
            List<Dictionary<string, string>> valuesList = new List<Dictionary<string, string>>();
            
            SQLiteConnection sqliteConnection = new SQLiteConnection($"Data Source={Path.GetFullPath(DB_PATH)};");
            sqliteConnection.Open();

            SQLiteCommand command = new SQLiteCommand("SELECT * FROM Tables", sqliteConnection);

            try
            {
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    valuesList.Add(
                        new Dictionary<string, string>
                        {
                        {"id", reader["id"].ToString()},
                        {"pot", reader["pot"].ToString()},
                        {"type", reader["type"].ToString()}
                        }
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please make sure that a correct path for given okey.db data file is provided.");
            }
                      
            sqliteConnection.Close();

            return valuesList;
        }
        
        public void Write()
        {
            //Currently this is an empty method that is open for development.
        }
        public void Update()
        {
            //Currently this is an empty method that is open for development.
        }
        public void Delete()
        {
            //Currently this is an empty method that is open for development.
        }
    }
}