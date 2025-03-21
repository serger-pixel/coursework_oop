using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace coursework_oop
{
    public static class Fields
    {
        public const string ID = "_id";
        public const string LAST_NAME = "_lastName";
        public const string FIRST_NAME = "_firstName";
        public const string APPARTAMENT_NUMB = "_appartamentNumb";
        public const string RENT = "_rent";
        public const string ELECTRICITY = "_electricity";
        public const string UTILITIES = "_utilities";
    }

    public class DataBaseWorker
    {
        private SqliteConnection Connection {  get; set; }
        private SqliteCommand Command { get; set; }
        DataBaseWorker(string connection)
        {
            Connection = new SqliteConnection(connection);
            Command = new SqliteCommand();
            Command.Connection = Connection;
            Command.CommandText = $@"
                CREATE TABLE IF NOT EXISTS tenants (
                    {Fields.ID} INTEGER PRIMARY KEY AUTOINCREMENT,
                    {Fields.LAST_NAME} TEXT NOT NULL,
                    {Fields.FIRST_NAME} TEXT NOT NULL,
                    {Fields.APPARTAMENT_NUMB} INTEGER NOT NULL,
                    {Fields.RENT} REAL NOT NULL,
                    {Fields.ELECTRICITY} REAL NOT NULL,
                    {Fields.UTILITIES} REAL NOT NULL
                );";
        }
    }
}
