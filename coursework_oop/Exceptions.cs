using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursework_oop
{
    /// <summary>
    /// Класс регулярных выражений
    /// </summary>
    public static class RegsAndConsts
    {
        /// <summary>
        /// Регулярное выражение для строк
        /// </summary>
        public const String strings = @"^([A-Z][a-z][А-Я][а-я])*$";

        /// <summary>
        /// Регулярное выражение для расширения файла
        /// </summary>
        public const String files = @"(.db)$";

        /// <summary>
        /// Регулярное выражение для целых чисел
        /// </summary>
        public const String ints = @"^(?:214748364[0-7]|21474836[0-3][0-9]|214748[0-3][0-9]{2}|2147[0-3][0-9]{3}|21[0-3][0-9]{4}|2[0-0][0-9]{5}|[1-9][0-9]{0,8}|0)$";

        /// <summary>
        /// Регулярное выражение для вещественных чисел
        /// </summary>
        public const String decimals = @"^(\d+(\.\d*)?|\.\d+)([eE][+-]?\d+)?$";

        /// <summary>
        /// Максимальное кол-во проживающих в одной квартире
        /// </summary>
        public const int maxCntTenants = 5;

        /// <summary>
        /// Минимальный номер квартиры
        /// </summary>
        public const int minNumbAppart = 1;

        /// <summary>
        /// Максимальный номер квартиры
        /// </summary>
        public const int maxNumbAppart = 10000;

        /// <summary>
        /// Минимальная оплата аренды
        /// </summary>
        public const int minRent = 1000;

        /// <summary>
        /// Минимальная оплата аренды
        /// </summary>
        public const int maxRent = 100000;

        /// <summary>
        /// Минимальная оплата электричества
        /// </summary>
        public const int minElectricity = 100;

        /// <summary>
        /// Максимальная оплата электричества
        /// </summary>
        public const int maxElectricity = 1000;

        /// <summary>
        /// Минимальная оплата коммнальных услуг
        /// </summary>
        public const int ьштUtilities = 100;

        /// <summary>
        /// Максимальная оплата коммнальных услуг
        /// </summary>
        public const int maxUtilities = 1000;
    }

    /// <summary>
    /// Класс сообщений-ошибок
    /// </summary>
    public static class ErrorMessages
    {
        /// <summary>
        /// Сообщение об ошибке, если значение не является строкой.
        /// </summary>
        public const string NotStringError = "Значение должно быть строкой. Строка должна содержать буквы латиницы или" +
            " кириллицы в верхнем или нижнем регистре.";

        /// <summary>
        /// Сообщение об ошибке, если значение не является целым числом.
        /// </summary>
        public const string NotIntError = "Значение должно быть целым числом.";

        /// <summary>
        /// Сообщение об ошибке, если значение не является десятичным числом.
        /// </summary>
        public const string NotDecimalError = "Значение должно быть десятичным числом.";

        /// <summary>
        /// Сообщение об ошибке, когда пользователя не существует.
        /// </summary>
        public const string UserNotExistsError = "Такого пользователя не сущестует.";


        /// <summary>
        /// Сообщение об ошибке, когда пользователь уже существует.
        /// </summary>
        public const string UserAlreadyExistsError = "Такой пользователь уже существует.";

        /// <summary>
        /// Сообщение об ошибке, когда файл не поддерживается.
        /// </summary>
        public const string NotSupportError = "Данный файл не поддерживатся.";

        /// <summary>
        /// Сообщение об ошибке, когда превышано максимальное кол-во проживающих в одной квартире.
        /// </summary>
        public const string MaxCntPersonError = "Превышано максимальное кол-во жителей";

        /// <summary>
        /// Сообщение об ошибке, возникающей при выходе номера квартиры за допустимый диапазон.
        /// </summary>
        public const string apartmentNumberError = "Номер квартиры должен быть в диапазоне от 1 до 10000.";

        /// <summary>
        /// Сообщение об ошибке, возникающей при выходе суммы аренды за допустимый диапазон.
        /// </summary>
        public const string rentAmountError = "Сумма аренды должна быть в диапазоне от 1000 до 100000.";

        /// <summary>
        /// Сообщение об ошибке, возникающей при выходе оплаты электричества за допустимый диапазон.
        /// </summary>
        public const string electricityPaymentError = "Оплата за электричество должна быть в диапазоне от 100 до 1000.";

        /// <summary>
        /// Сообщение об ошибке, возникающей при выходе суммы коммунальных платежей за допустимый диапазон.
        /// </summary>
        public const string utilitiesPaymentError = "Коммунальные платежи должны быть в диапазоне от 100 до 1000.";

    }

    /// <summary>
    /// Исключение, выбрасываемое, когда ожидается строка, но полученное значение не является строкой.
    /// </summary>
    public class NotStringException : Exception
    {
        /// <summary>
        /// Конструктор для создания экземпляра NotStringException с указанным сообщением.
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        public NotStringException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// Исключение, выбрасываемое, когда ожидается целое число (int), но полученное значение не является целым числом.
    /// </summary>
    public class NotIntException : Exception
    {
        /// <summary>
        /// Конструктор для создания экземпляра NotIntException с указанным сообщением.
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        public NotIntException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// Исключение, выбрасываемое, когда ожидается десятичное число (decimal), но полученное значение не является десятичным числом.
    /// </summary>
    public class NotDecimalException : Exception
    {
        /// <summary>
        /// Конструктор для создания экземпляра NotDecimalException с указанным сообщением.
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        public NotDecimalException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// Исключение, выбрасываемое, когда пользователь не существует.
    /// </summary>
    public class UserNotExistsException : Exception
    {
        /// <summary>
        /// Конструктор для создания экземпляра UserNotExistsException с указанным сообщением.
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        public UserNotExistsException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// Исключение, выбрасываемое, когда пользователь уже существует.
    /// </summary>
    public class UserAlreadyExistsException : Exception
    {
        /// <summary>
        /// Конструктор для создания экземпляра UserAlreadyExistsException с указанным сообщением.
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        public UserAlreadyExistsException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// Исключение, выбрасываемое, когда файл не поддерживает расширение db.
    /// </summary>
    public class NotSupportException : Exception
    {
        /// <summary>
        /// Конструктор для создания экземпляра UserAlreadyExistsException с указанным сообщением.
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        public NotSupportException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// Исключение, выбрасываемое, когда превышано максимальное кол-во жителей в одной квартире.
    /// </summary>
    public class MaxCntPersonException: Exception
    {
        /// <summary>
        /// Конструктор для создания экземпляра UserAlreadyExistsException с указанным сообщением.
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        public MaxCntPersonException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// Выбрасывается, если номер квартиры меньше 1 и больше 100000.
    /// </summary>
    public class ApartmentNumberException : Exception
    {
        public ApartmentNumberException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// Выбрасывается, если сумма аренды меньше 1000 или больше 100000.
    /// </summary>
    public class RentAmountException : Exception
    {
        public RentAmountException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// Выбрасывается, если сумма за электричество меньше 100 или больше 1000.
    /// </summary>
    public class ElectricityPaymentException : Exception
    {
        public ElectricityPaymentException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// Выбрасывается, если сумма за коммунальные услуги меньше 100 или больше 1000.
    /// </summary>
    public class UtilitiesPaymentException : Exception
    {
        public UtilitiesPaymentException(string message) : base(message)
        {
        }
    }
}
