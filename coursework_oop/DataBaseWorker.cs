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
        

        public DataBaseWorker(string path)
        {
            Connection = new SqliteConnection("DataSource=" + path);

            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
            {
                Connection.Open();
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
            }
            else
            {
                Connection.Open();
            }

        }

        public void add(Tenant person) 
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

        public void delete(Tenant person)
        {
            SqliteCommand deleteCommand = new SqliteCommand();
            deleteCommand.Connection = Connection;
            deleteCommand.CommandText = $@"
            DELETE FROM {tableName}
                WHERE {Fields.ID} = {person.Id};";
            deleteCommand.ExecuteNonQuery();
        }

        public void update(Tenant person)
        {
            SqliteCommand updateCommand = new SqliteCommand();
            updateCommand.Connection = Connection;
            updateCommand.CommandText = $@"
            UPDATE tenants SET
                {Fields.LAST_NAME} {person.LastName},
                {Fields.FIRST_NAME} {person.FirstName},
                {Fields.APPARTAMENT_NUMB} {person.AppartamentNumb},
                {Fields.RENT} {person.Rent},
                {Fields.ELECTRICITY}  {person.Electricity},
                {Fields.UTILITIES} {person.Utilities}
                WHERE {Fields.ID} = {person.Id};";
            updateCommand.ExecuteNonQuery();
        }

        public Tenant select(int id)
        {
            SqliteCommand selectCommand = new SqliteCommand();
            selectCommand.Connection = Connection;
            selectCommand.CommandText = $@"
                SELECT {Fields.ID}, {Fields.LAST_NAME}, {Fields.FIRST_NAME}, {Fields.APPARTAMENT_NUMB}, {Fields.RENT}, {Fields.ELECTRICITY}, {Fields.UTILITIES}
                FROM tenants
                    WHERE {Fields.ID} = {id};
            ";
            SqliteDataReader reader = selectCommand.ExecuteReader();
            return new Tenant((int)reader[Fields.ID], (string)reader[Fields.LAST_NAME], (string)reader[Fields.FIRST_NAME], (int)reader[Fields.APPARTAMENT_NUMB],
            (decimal)reader[Fields.RENT], (decimal)reader[Fields.ELECTRICITY], (decimal)reader[Fields.UTILITIES]);
        }
    }
}
