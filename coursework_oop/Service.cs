using Microsoft.Data.Sqlite;

namespace coursework_oop
{
    /// <summary>
    /// Содержит константы для имен полей таблицы базы данных.
    /// </summary>
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

    /// <summary>
    /// Перечисление, определяющее статус открытия базы данных: новая или существующая.
    /// </summary>
    public enum Statuses
    {
        NEW,
        EXISTING
    }

    /// <summary>
    /// Класс Service обеспечивает прямое взаимодействие с базой данных SQLite.
    /// Реализует операции CRUD и управляет жизненным циклом БД.
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Название таблицы в БД.
        /// </summary>
        private const string tableName = "tenants";

        /// <summary>
        /// Путь к локальной БД.
        /// </summary>
        private string pathOfCopy;

        /// <summary>
        /// Путь к БД.
        /// </summary>
        public string workPath { get; private set; }


        public Service()
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folderName = "coursework_oop";
            string dbName = "local.db";

            string fullworkPath =Path.Combine(appData, folderName);
            if (!Directory.Exists(fullworkPath))
            {
                Directory.CreateDirectory(fullworkPath);
            }

            pathOfCopy = Path.Combine(fullworkPath, dbName);
        }
        /// <summary>
        /// Открывает указанную базу данных.
        /// Если указана как новая — создаёт её.
        /// </summary>
        /// <param name="path">Путь к файлу базы данных.</param>
        /// <param name="status">Статус открытия: существующая или новая БД.</param>
        public void openDataBase(string path, Statuses status)
        {
            if (status == Statuses.NEW)
            {
                createDataBase(path);
            }
            File.Copy(path, pathOfCopy, overwrite: true);
            workPath = path;
        }

        /// <summary>
        /// Создаёт новую базу данных с необходимой структурой.
        /// </summary>
        /// <param name="path">Путь, по которому будет создана БД.</param>
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

        /// <summary>
        /// Закрывает текущую базу данных.
        /// </summary>
        public void closeDataBase()
        {
            workPath = null;
            File.Delete(pathOfCopy);
        }

        /// <summary>
        /// Удаляет физически файл базы данных.
        /// </summary>
        public void deleteDataBase()
        {
            File.Delete(workPath);
            workPath = null;
        }

        /// <summary>
        /// Сохраняет текущее состояние базы данных на диск.
        /// </summary>
        public void safeDb()
        {
            File.Copy(pathOfCopy, workPath, overwrite: true);
        }

        /// <summary>
        /// Добавляет нового арендатора в БД.
        /// </summary>
        /// <param name="person">Объект Tenant с данными арендатора.</param>
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

        /// <summary>
        /// Удаляет запись арендатора по его ID.
        /// </summary>
        /// <param name="id">ID арендатора.</param>
        public void deleteRecord(long id)
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

        /// <summary>
        /// Обновляет данные арендатора в БД.
        /// </summary>
        /// <param name="person">Объект Tenant с обновлёнными данными.</param>
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

        /// <summary>
        /// Возвращает запись арендатора по его ID.
        /// </summary>
        /// <param name="id">ID арендатора.</param>
        /// <returns>Объект Tenant или null, если не найден.</returns>
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

        /// <summary>
        /// Возвращает список всех арендаторов из БД.
        /// </summary>
        /// <returns>Список объектов Tenant.</returns>
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
                {
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
            }
            return tenants;
        }

        /// <summary>
        /// Фильтрует арендаторов по заданному критерию и значению.
        /// </summary>
        /// <param name="crit">Критерий фильтрации: Имя, Фамилия, Номер квартиры и т.д.</param>
        /// <param name="critValue">Значение критерия для фильтрации.</param>
        /// <returns>Отфильтрованный список арендаторов.</returns>
        public List<Tenant> getDefiniteTenants(string crit, string critValue)
        {
            List<Tenant> allTenants = GetAllTenants();
            List<Tenant> definiteTenants = new List<Tenant>();
            critValue = critValue.ToLower();
            switch (crit)
            {
                case "Имя":
                    foreach (var tenant in allTenants)
                    {
                        if (tenant.FirstName.ToString().ToLower().Contains(critValue))
                        {
                            definiteTenants.Add(tenant);
                        }
                    }
                    break;
                case "Фамилия":
                    foreach (var tenant in allTenants)
                    {
                        if (tenant.LastName.ToString().ToLower().Contains(critValue))
                        {
                            definiteTenants.Add(tenant);
                        }
                    }
                    break;
                case "Номер квартиры":
                    foreach (var tenant in allTenants)
                    {
                        if (tenant.AppartamentNumb.ToString().ToLower().Contains(critValue))
                        {
                            definiteTenants.Add(tenant);
                        }
                    }
                    break;
                case "Аренда":
                    foreach (var tenant in allTenants)
                    {
                        if (tenant.Rent.ToString().ToString().ToLower().Contains(critValue))
                        {
                            definiteTenants.Add(tenant);
                        }
                    }
                    break;
                case "Электричество":
                    foreach (var tenant in allTenants)
                    {
                        if (tenant.Electricity.ToString().ToString().ToLower().Contains(critValue))
                        {
                            definiteTenants.Add(tenant);
                        }
                    }
                    break;
                case "Коммунальные услуги":
                    foreach (var tenant in allTenants)
                    {
                        if (tenant.Utilities.ToString().ToString().ToLower().Contains(critValue))
                        {
                            definiteTenants.Add(tenant);
                        }
                    }
                    break;
                default:
                    break;
            }
            return definiteTenants;
        }
    }
}