using System;
using SQLite;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CoMiSzkodzi.Databases
{
    public static class DatabaseConnection
    {
        public static SQLiteAsyncConnection Connection;
        public static void InitializeDatabase()
        {
            string docs = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string datebasePathway = Path.Combine(docs, "FoodDatabase.db");
            Connection = new SQLiteAsyncConnection(datebasePathway);
        }
        
    }

}
