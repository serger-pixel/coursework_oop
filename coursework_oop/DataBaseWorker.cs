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

    public enum Statuses
    {
        NEW,
        EXISTING
    }

    public class DataBaseWorker
    {
        private SqliteConnection Connection {  get; set; }

        const string tableName = "tenants";

        public const string pathOfCopy = "./local.db";

        public string Path;
        
        public void openDataBase(string path, Statuses status)
        {
            switch (status)
            {
                case Statuses.NEW:
                    createDataBase(path);
                    break;
                default:
                    break;
            }
            File.Copy(path, pathOfCopy, true);
            Connection = new SqliteConnection("DataSource=" + pathOfCopy);
            Connection.Open();
            Path = path;
        }

        public void createDataBase(string path)
        {
            SqliteConnection localConnection = new SqliteConnection("DataSource=" + path);
            localConnection.Open();
            SqliteCommand createTableCommand = new SqliteCommand();
            createTableCommand.Connection = Connection;
            createTableCommand.CommandText = $@"
                CREATE TABLE {tableName} 
                (
                    {Fields.ID} INTEGER PRIMARY KEY AUTOINCREMENT,
                    {Fields.LAST_NAME} TEXT NOT NULL,
                    {Fields.FIRST_NAME} TEXT NOT NULL,
                    {Fields.APPARTAMENT_NUMB} INTEGER NOT NULL,
                    {Fields.RENT} REAL NOT NULL,
                    {Fields.ELECTRICITY} REAL NOT NULL,
                    {Fields.UTILITIES} REAL NOT NULL
                );";
            createTableCommand.ExecuteNonQuery();
            localConnection.Close();
        }

        public void closeDataBase()
        {
            Connection.Close();
            Connection = null;
            Path = null;
        }

        public void deleteDataBase()
        {
            string temp = Path;
            closeDataBase();
            File.Delete(temp);
        }

        public void addRecord(Tenant person) 
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
                {person.Id},
                '{person.LastName}',
                '{person.FirstName}',
                {person.AppartamentNumb},
                {person.Rent},
                {person.Electricity},
                {person.Utilities}
            );";
            addCommand.ExecuteNonQuery();
        }

        public void deleteRecord(int id)
        {
            SqliteCommand deleteCommand = new SqliteCommand();
            deleteCommand.Connection = Connection;
            deleteCommand.CommandText = $@"
            DELETE FROM {tableName}
                WHERE {Fields.ID} = {id};";
            deleteCommand.ExecuteNonQuery();
        }

        public void updateRecord(Tenant person)
        {
            SqliteCommand updateCommand = new SqliteCommand();
            updateCommand.Connection = Connection;
            updateCommand.CommandText = $@"
            UPDATE tenants SET
                {Fields.LAST_NAME} = {person.LastName},
                {Fields.FIRST_NAME} = '{person.FirstName}',
                {Fields.APPARTAMENT_NUMB} = '{person.AppartamentNumb}',
                {Fields.RENT} = {person.Rent},
                {Fields.ELECTRICITY} = {person.Electricity},
                {Fields.UTILITIES} = {person.Utilities}
                WHERE {Fields.ID} = {person.Id};";
            updateCommand.ExecuteNonQuery();
        }

        public Tenant selectRecord(int id)
        {
            SqliteCommand selectCommand = new SqliteCommand();
            selectCommand.Connection = Connection;
            selectCommand.CommandText = $@"
                SELECT {Fields.ID}, {Fields.LAST_NAME}, {Fields.FIRST_NAME}, {Fields.APPARTAMENT_NUMB}, {Fields.RENT}, {Fields.ELECTRICITY}, {Fields.UTILITIES}
                FROM tenants
                    WHERE {Fields.ID} = {id};
            ";
            SqliteDataReader reader = selectCommand.ExecuteReader();
            reader.Read();
            return new Tenant((long)reader[Fields.ID], (string)reader[Fields.LAST_NAME], (string)reader[Fields.FIRST_NAME], (long)reader[Fields.APPARTAMENT_NUMB],
            (double)reader[Fields.RENT], (double)reader[Fields.ELECTRICITY], (double)reader[Fields.UTILITIES]);
        }

    }
}
