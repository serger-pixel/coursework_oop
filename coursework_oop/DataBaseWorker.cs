using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.IO;

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

        const string tableName = "tenants";
        
        DataBaseWorker(string fileName)
        {
            Connection = new SqliteConnection(fileName);
            Connection.Open();
            if (!File.Exists(fileName))
            {
                SqliteCommand CreateTableCommand = new SqliteCommand();
                CreateTableCommand.Connection = Connection;
                CreateTableCommand.CommandText = $@"
                CREATE TABLE {tableName} 
                (
                    {Fields.ID} INTEGER PRIMARY KEY AUTOINCREMEN,
                    {Fields.LAST_NAME} TEXT NOT NULL,
                    {Fields.FIRST_NAME} TEXT NOT NULL,
                    {Fields.APPARTAMENT_NUMB} INTEGER NOT NULL,
                    {Fields.RENT} REAL NOT NULL,
                    {Fields.ELECTRICITY} REAL NOT NULL,
                    {Fields.UTILITIES} REAL NOT NULL
                );";
            }
        }

        void add(Tenant person) 
        {
            SqliteCommand addCommand = new SqliteCommand();
            addCommand.Connection = Connection;
            addCommand.CommandText = $@"
            INSERT INTO {tableName} 
            (
                {Fields.ID},
                {Fields.LAST_NAME},
                {Fields.FIRST_NAME},
                {Fields.APPARTAMENT_NUMB},
                {Fields.RENT},
                {Fields.ELECTRICITY},
                {Fields.UTILITIES}
            )
            VALUES
            (
                {person.LastName},
                {person.FirstName},
                {person.AppartamentNumb},
                {person.Rent},
                {person.Electricity},
                {person.Utilities}
            );";
            addCommand.ExecuteNonQuery();
        }

        void delete(Tenant person)
        {
            SqliteCommand deleteCommand = new SqliteCommand();
            deleteCommand.Connection = Connection;
            deleteCommand.CommandText = $@"
            DELETE FROM {tableName}
                WHERE {{Fields.{Fields.ID}}} = {person.Id};";
            deleteCommand.ExecuteNonQuery();
        }


    }
}
