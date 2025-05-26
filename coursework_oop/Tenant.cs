namespace coursework_oop
{
    /// <summary>
    /// Класс, представляющий арендатора (жильца) с его основными данными.
    /// Содержит информацию о ФИО, номере квартиры и суммах оплаты.
    /// </summary>
    public class Tenant
    {
        /// <summary>
        /// Уникальный идентификатор арендатора.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Фамилия арендатора.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Имя арендатора.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Номер квартиры, в которой проживает арендатор.
        /// </summary>
        public long AppartamentNumb { get; set; }

        /// <summary>
        /// Сумма арендной платы.
        /// </summary>
        public double Rent { get; set; }

        /// <summary>
        /// Сумма за потреблённое электричество.
        /// </summary>
        public double Electricity { get; set; }

        /// <summary>
        /// Сумма коммунальных услуг (например, вода, отопление и т.п.).
        /// </summary>
        public double Utilities { get; set; }

        /// <summary>
        /// Конструктор класса Tenant.
        /// Инициализирует новый экземпляр арендатора с заданными параметрами.
        /// </summary>
        /// <param name="id">Уникальный идентификатор арендатора.</param>
        /// <param name="firstName">Имя арендатора.</param>
        /// <param name="lastName">Фамилия арендатора.</param>
        /// <param name="appartamentNumb">Номер квартиры.</param>
        /// <param name="rent">Сумма аренды.</param>
        /// <param name="electricity">Сумма за электричество.</param>
        /// <param name="utilities">Сумма за коммунальные услуги.</param>
        public Tenant(long id, string firstName, string lastName, long appartamentNumb, double rent, double electricity, double utilities)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            AppartamentNumb = appartamentNumb;
            Rent = rent;
            Electricity = electricity;
            Utilities = utilities;
        }
    }
}