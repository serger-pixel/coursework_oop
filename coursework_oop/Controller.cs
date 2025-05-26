using System.Text.RegularExpressions;

namespace coursework_oop
{
    /// <summary>
    /// Класс Controller обеспечивает взаимодействие между пользовательским интерфейсом (Form) и бизнес-логикой (Service).
    /// Отвечает за обработку входных данных, валидацию и вызов соответствующих методов сервиса.
    /// </summary>
    public class Controller
    {
        /// <summary>
        /// Сервис.
        /// Включает в себя основную логику.
        /// </summary>
        private Service _service;

        /// <summary>
        /// Инициализирует новый экземпляр класса Controller.
        /// Создает подключение к сервису для работы с базой данных.
        /// </summary>
        public Controller()
        {
            _service = new Service();
        }

        /// <summary>
        /// Открывает указанную базу данных.
        /// Проверяет имя файла на соответствие требованиям при создании новой БД.
        /// </summary>
        /// <param name="path">Путь к файлу базы данных.</param>
        /// <param name="status">Статус открытия: существующая или новая БД.</param>
        public void openDataBase(string path, Statuses status)
        {
            string fileName = Path.GetFileNameWithoutExtension(path);

            if ((!Regex.IsMatch(fileName, RegsAndConsts.strings) ||
                 fileName.Length < RegsAndConsts.minLengthStr) &&
                status == Statuses.NEW)
            {
                throw new NotStringException();
            }

            if (File.Exists(path) && status == Statuses.NEW)
            {
                throw new FileAllReadyExits();
            }

            _service.openDataBase(path, status);
        }

        /// <summary>
        /// Закрывает текущую базу данных.
        /// </summary>
        public void closeDataBase()
        {
            _service.closeDataBase();
        }

        /// <summary>
        /// Удаляет текущую базу данных.
        /// </summary>
        public void deleteDataBase()
        {
            _service.deleteDataBase();
        }

        /// <summary>
        /// Получает список всех арендаторов из БД.
        /// </summary>
        /// <returns>Список арендаторов.</returns>
        public List<Tenant> GetAllTenants()
        {
            return _service.GetAllTenants();
        }

        /// <summary>
        /// Добавляет новую запись арендатора в БД.
        /// Выполняет валидацию имени, проверку уникальности ID и ограничения на количество жильцов.
        /// </summary>
        /// <param name="id">Уникальный идентификатор арендатора.</param>
        /// <param name="firstName">Имя арендатора.</param>
        /// <param name="lastName">Фамилия арендатора.</param>
        /// <param name="apartNumb">Номер квартиры.</param>
        /// <param name="rent">Арендная плата.</param>
        /// <param name="electricity">Платеж за электричество.</param>
        /// <param name="utilities">Коммунальные платежи.</param>
        public void addRecord(long id, string firstName, string lastName, int apartNumb,
           double rent, double electricity, double utilities)
        {
            if (!Regex.IsMatch(firstName, RegsAndConsts.strings) ||
                firstName.Length < RegsAndConsts.minLengthStr)
            {
                throw new NotStringException();
            }

            if (!Regex.IsMatch(lastName, RegsAndConsts.strings) ||
                lastName.Length < RegsAndConsts.minLengthStr)
            {
                throw new NotStringException();
            }

            List<Tenant> allTenants = _service.GetAllTenants();

            foreach (Tenant current in allTenants)
            {
                if (current.Id == id)
                {
                    throw new UserAlreadyExistsException();
                }
            }

            int cnt = 0;
            foreach (Tenant current in allTenants)
            {
                if (current.AppartamentNumb == apartNumb)
                {
                    cnt++;
                }
            }

            if (cnt >= RegsAndConsts.maxCntTenants)
            {
                throw new MaxCntPersonException();
            }

            _service.addRecord(new Tenant(id, firstName, lastName, apartNumb,
                rent, electricity, utilities));
        }

        /// <summary>
        /// Удаляет запись арендатора по его ID.
        /// </summary>
        /// <param name="id">ID арендатора.</param>
        public void deleteRecord(long id)
        {
            _service.deleteRecord(id);
        }

        /// <summary>
        /// Обновляет данные арендатора в БД.
        /// Выполняет валидацию полей, проверку на переполнение и допустимые значения.
        /// </summary>
        /// <param name="id">ID арендатора.</param>
        /// <param name="firstName">Имя арендатора.</param>
        /// <param name="lastName">Фамилия арендатора.</param>
        /// <param name="apartNumb">Номер квартиры.</param>
        /// <param name="rent">Арендная плата.</param>
        /// <param name="electricity">Платеж за электричество.</param>
        /// <param name="utilities">Коммунальные платежи.</param>
        public void updateRecord(string id, string firstName, string lastName, string apartNumb,
           string rent, string electricity, string utilities)
        {
            if (!Regex.IsMatch(firstName, RegsAndConsts.strings) ||
                firstName.Length < RegsAndConsts.minLengthStr)
            {
                throw new NotStringException();
            }

            if (!Regex.IsMatch(lastName, RegsAndConsts.strings) ||
                lastName.Length < RegsAndConsts.minLengthStr)
            {
                throw new NotStringException();
            }

            if (!Regex.IsMatch(apartNumb, RegsAndConsts.ints))
            {
                throw new NotIntException();
            }

            if (!Regex.IsMatch(rent, RegsAndConsts.doubles))
            {
                throw new NotDoubleException();
            }

            if (!Regex.IsMatch(electricity, RegsAndConsts.doubles))
            {
                throw new NotDoubleException();
            }

            if (!Regex.IsMatch(utilities, RegsAndConsts.doubles))
            {
                throw new NotDoubleException();
            }

            List<Tenant> allTenants = _service.GetAllTenants();
            int cnt = 0;

            foreach (Tenant current in allTenants)
            {
                if (current.AppartamentNumb == int.Parse(apartNumb))
                {
                    if (current.Id == long.Parse(id))
                    {
                        continue;
                    }
                    cnt++;
                }
            }

            if (cnt >= RegsAndConsts.maxCntTenants)
            {
                throw new MaxCntPersonException();
            }

            if (int.Parse(apartNumb) < RegsAndConsts.minNumbAppart ||
                int.Parse(apartNumb) > RegsAndConsts.maxNumbAppart)
            {
                throw new ApartmentNumberException();
            }

            if (double.Parse(rent) < RegsAndConsts.minRent ||
                double.Parse(rent) > RegsAndConsts.maxRent)
            {
                throw new RentAmountException();
            }

            if (double.Parse(electricity) < RegsAndConsts.minElectricity ||
                double.Parse(electricity) > RegsAndConsts.maxElectricity)
            {
                throw new ElectricityPaymentException();
            }

            if (double.Parse(utilities) < RegsAndConsts.minUtilities ||
                double.Parse(utilities) > RegsAndConsts.maxUtilities)
            {
                throw new UtilitiesPaymentException();
            }

            _service.updateRecord(new Tenant(long.Parse(id), firstName, lastName, int.Parse(apartNumb),
                double.Parse(rent), double.Parse(electricity), double.Parse(utilities)));
        }

        /// <summary>
        /// Фильтрует арендаторов по заданному критерию и значению.
        /// Проверяет корректность входных данных перед фильтрацией.
        /// </summary>
        /// <param name="crit">Критерий фильтрации: Имя, Фамилия, Номер квартиры и т.д.</param>
        /// <param name="critValue">Значение критерия для фильтрации.</param>
        /// <returns>Отфильтрованный список арендаторов.</returns>
        public List<Tenant> filter(string crit, string critValue)
        {
            List<Tenant> allTenants = _service.GetAllTenants();

            switch (crit)
            {
                case "Имя":
                case "Фамилия":
                    if (!Regex.IsMatch(critValue, RegsAndConsts.strings))
                    {
                        throw new NotStringException();
                    }
                    break;
                case "Номер квартиры":
                    if (!Regex.IsMatch(critValue, RegsAndConsts.ints))
                    {
                        throw new NotIntException();
                    }
                    break;
                case "Аренда":
                case "Электричество":
                case "Коммунальные услуги":
                    if (!Regex.IsMatch(critValue, RegsAndConsts.doubles))
                    {
                        throw new NotDoubleException();
                    }
                    break;
                default:
                    break;
            }

            return _service.getDefiniteTenants(crit, critValue);
        }

        /// <summary>
        /// Сохраняет текущее состояние базы данных.
        /// </summary>
        public void safeDb()
        {
            _service.safeDb();
        }
    }
}