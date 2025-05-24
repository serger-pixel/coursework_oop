using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.IO;
using System.Data;

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

    public class Service
    {

        const string tableName = "tenants";

        public const string pathOfCopy = "./local.db";

        public string Path { get; private set; }

        public void openDataBase(string path, Statuses status)
        {
            closeDataBase();
            if (status == Statuses.NEW)
            {
                createDataBase(path);
            }
            File.Copy(path, pathOfCopy, overwrite: true);
            Path = path;
        }

        private void createDataBase(string path)
        {
            using (var localConnection = new SqliteConnection($"Data Source={path}"))
            {
                localConnection.Open();
                var createTableQuery = $@"
                CREATE TABLE IF NOT EXISTS {tableName} 
                (
                    {Fields.ID} INTEGER PRIMARY KEY AUTOINCREMENT,
                    {Fields.LAST_NAME} TEXT NOT NULL,
                    {Fields.FIRST_NAME} TEXT NOT NULL,
                    {Fields.APPARTAMENT_NUMB} INTEGER NOT NULL,
                    {Fields.RENT} REAL NOT NULL,
                    {Fields.ELECTRICITY} REAL NOT NULL,
                    {Fields.UTILITIES} REAL NOT NULL
                );";

                using (var command = new SqliteCommand(createTableQuery, localConnection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void closeDataBase()
        {
            Path = null;
            File.Delete(pathOfCopy);
        }

        public void deleteDataBase()
        {
            closeDataBase();
            File.Delete(Path);
        }

        public long generateUniqueID()
        {
            string query = $"SELECT MAX({Fields.ID}) FROM {tableName};";
            using (var localConnection = new SqliteConnection($"Data Source={pathOfCopy}"))
            {
                using (var command = new SqliteCommand(query, localConnection))
                {
                    object result = command.ExecuteScalar();

                    if (result == DBNull.Value || result == null)
                    {
                        return 1;
                    }

                    long maxId = Convert.ToInt32(result);
                    return maxId + 1;
                }
            }
        }

        public void addRecord(Tenant person)
        {
            string query = $@"
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
                @id,
                @lastName, 
                @firstName, 
                @appartamentNumb, 
                @rent, 
                @electricity, 
                @utilities
            );";
            using (var localConnection = new SqliteConnection($"Data Source={pathOfCopy}"))
            {
                using (var command = new SqliteCommand(query, localConnection))
                {
                    command.Parameters.AddWithValue("@id", person.Id);
                    command.Parameters.AddWithValue("@lastName", person.LastName);
                    command.Parameters.AddWithValue("@firstName", person.FirstName);
                    command.Parameters.AddWithValue("@appartamentNumb", person.AppartamentNumb);
                    command.Parameters.AddWithValue("@rent", person.Rent);
                    command.Parameters.AddWithValue("@electricity", person.Electricity);
                    command.Parameters.AddWithValue("@utilities", person.Utilities);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void deleteRecord(int id)
        {
            string query = $@"
        DELETE FROM {tableName} 
        WHERE {Fields.ID} = @id;";

            using (var localConnection = new SqliteConnection($"Data Source={pathOfCopy}"))
            {
                localConnection.Open();
                using (var command = new SqliteCommand(query, localConnection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void updateRecord(Tenant person)
        {
            string query = $@"
        UPDATE {tableName} SET
            {Fields.LAST_NAME} = @lastName,
            {Fields.FIRST_NAME} = @firstName,
            {Fields.APPARTAMENT_NUMB} = @appartamentNumb,
            {Fields.RENT} = @rent,
            {Fields.ELECTRICITY} = @electricity,
            {Fields.UTILITIES} = @utilities
        WHERE {Fields.ID} = @id;";

            using (var localConnection = new SqliteConnection($"Data Source={pathOfCopy}"))
            {
                localConnection.Open();
                using (var command = new SqliteCommand(query, localConnection))
                {
                    command.Parameters.AddWithValue("@id", person.Id);
                    command.Parameters.AddWithValue("@lastName", person.LastName);
                    command.Parameters.AddWithValue("@firstName", person.FirstName);
                    command.Parameters.AddWithValue("@appartamentNumb", person.AppartamentNumb);
                    command.Parameters.AddWithValue("@rent", person.Rent);
                    command.Parameters.AddWithValue("@electricity", person.Electricity);
                    command.Parameters.AddWithValue("@utilities", person.Utilities);

                    command.ExecuteNonQuery();
                }
            }
        }

        public Tenant selectRecord(int id)
        {
            string query = $@"
        SELECT 
            {Fields.ID}, 
            {Fields.LAST_NAME}, 
            {Fields.FIRST_NAME}, 
            {Fields.APPARTAMENT_NUMB}, 
            {Fields.RENT}, 
            {Fields.ELECTRICITY}, 
            {Fields.UTILITIES}
        FROM {tableName}
        WHERE {Fields.ID} = @id;";

            using (var localConnection = new SqliteConnection($"Data Source={pathOfCopy}"))
            {
                localConnection.Open();
                using (var command = new SqliteCommand(query, localConnection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Tenant(
                                id: reader.GetInt64(reader.GetOrdinal(Fields.ID)),
                                lastName: reader.GetString(reader.GetOrdinal(Fields.LAST_NAME)),
                                firstName: reader.GetString(reader.GetOrdinal(Fields.FIRST_NAME)),
                                appartamentNumb: reader.GetInt64(reader.GetOrdinal(Fields.APPARTAMENT_NUMB)),
                                rent: reader.GetDouble(reader.GetOrdinal(Fields.RENT)),
                                electricity: reader.GetDouble(reader.GetOrdinal(Fields.ELECTRICITY)),
                                utilities: reader.GetDouble(reader.GetOrdinal(Fields.UTILITIES))
                            );
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public List<Tenant> GetAllTenants()
        {
            var tenants = new List<Tenant>();

            string query = $@"
        SELECT 
            {Fields.ID}, 
            {Fields.LAST_NAME}, 
            {Fields.FIRST_NAME}, 
            {Fields.APPARTAMENT_NUMB}, 
            {Fields.RENT}, 
            {Fields.ELECTRICITY}, 
            {Fields.UTILITIES}
        FROM {tableName};";

            using (var localConnection = new SqliteConnection($"Data Source={pathOfCopy}"))
            {
                localConnection.Open();
                using (var command = new SqliteCommand(query, localConnection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tenants.Add(new Tenant(
                            id: reader.GetInt64(reader.GetOrdinal(Fields.ID)),
                            lastName: reader.GetString(reader.GetOrdinal(Fields.LAST_NAME)),
                            firstName: reader.GetString(reader.GetOrdinal(Fields.FIRST_NAME)),
                            appartamentNumb: reader.GetInt64(reader.GetOrdinal(Fields.APPARTAMENT_NUMB)),
                            rent: reader.GetDouble(reader.GetOrdinal(Fields.RENT)),
                            electricity: reader.GetDouble(reader.GetOrdinal(Fields.ELECTRICITY)),
                            utilities: reader.GetDouble(reader.GetOrdinal(Fields.UTILITIES))
                        ));
                    }
                }
            }

            return tenants;
        }
    }
}