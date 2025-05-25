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
        public const String strings = @"^[A-Za-zА-Яа-яЁё]+$";

        /// <summary>
        /// Минимальная длина строчки
        /// </summary>
        public const int  minLengthStr = 5;

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
        public const int minUtilities = 100;

        /// <summary>
        /// Максимальная оплата коммнальных услуг
        /// </summary>
        public const int maxUtilities = 1000;

        /// <summary>
        /// Минимальная оплата коммнальных услуг
        /// </summary>
        public const long minId = 1;

        /// <summary>
        /// Максимальная оплата коммнальных услуг
        /// </summary>
        public const long maxId = 1000000;
    }

    /// <summary>
    /// Класс сообщений-ошибок
    /// </summary>
    public static class ErrorMessages
    {
        /// <summary>
        /// Сообщение об ошибке, если значение не является строкой.
        /// </summary>
        public const string notStringError = "Значение должно быть строкой. Строка должна содержать буквы латиницы или" +
            " кириллицы в верхнем или нижнем регистре.";

        /// <summary>
        /// Сообщение об ошибке, если файл с таким именем уже существует.
        /// </summary>
        public const string nameDbError = "База данных с таким именем уже существует";

        /// <summary>
        /// Сообщение об ошибке, если длина строчки меньше минимальной длины.
        /// </summary>
        public const string minLenghtStrError = "Длина строчки должна составлять не менее 5 символов";


        /// <summary>
        /// Сообщение об ошибке, когда пользователя не существует.
        /// </summary>
        public const string userNotExistsError = "Такого пользователя не сущестует.";

        /// <summary>
        /// Сообщение об ошибке, когда пользователь уже существует.
        /// </summary>
        public const string userAlreadyExistsError = "Пользователь с таким ID уже существует.";

        /// <summary>
        /// Сообщение об ошибке, когда превышано максимальное кол-во проживающих в одной квартире.
        /// </summary>
        public const string maxCntPersonError = "Превышано максимальное кол-во жителей в одной квартире";

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
        /// </summary
        public NotStringException() : base(ErrorMessages.notStringError + "\n" + ErrorMessages.minLenghtStrError)
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
        public UserNotExistsException() : base(ErrorMessages.userNotExistsError)
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
        public UserAlreadyExistsException() : base(ErrorMessages.userAlreadyExistsError)
        {
        }
    }

    /// <summary>
    /// Исключение, выбрасываемое, когда файл уже существует.
    /// </summary>
    public class FileAllReadyExits : Exception
    {
        /// <summary>
        /// Конструктор для создания экземпляра FileAllReadyExits с указанным сообщением.
        /// </summary>
        public FileAllReadyExits() : base(ErrorMessages.nameDbError)
        {
        }
    }


    /// <summary>
    /// Исключение, выбрасываемое, когда превышено максимальное количество жителей в одной квартире.
    /// </summary>
    public class MaxCntPersonException : Exception
    {
        /// <summary>
        /// Конструктор, использующий стандартное сообщение об ошибке из ErrorMessages.
        /// </summary>
        public MaxCntPersonException() : base(ErrorMessages.maxCntPersonError)
        {
        }
    }

    /// <summary>
    /// Выбрасывается, если номер квартиры меньше 1 или больше 10000.
    /// </summary>
    public class ApartmentNumberException : Exception
    {
        /// <summary>
        /// Конструктор, использующий стандартное сообщение об ошибке из ErrorMessages.
        /// </summary>
        public ApartmentNumberException() : base(ErrorMessages.apartmentNumberError)
        {
        }
    }

    /// <summary>
    /// Выбрасывается, если сумма аренды меньше 1000 или больше 100000.
    /// </summary>
    public class RentAmountException : Exception
    {
        /// <summary>
        /// Конструктор, использующий стандартное сообщение об ошибке из ErrorMessages.
        /// </summary>
        public RentAmountException() : base(ErrorMessages.rentAmountError)
        {
        }
    }

    /// <summary>
    /// Выбрасывается, если сумма за электричество меньше 100 или больше 1000.
    /// </summary>
    public class ElectricityPaymentException : Exception
    {
        /// <summary>
        /// Конструктор, использующий стандартное сообщение об ошибке из ErrorMessages.
        /// </summary>
        public ElectricityPaymentException() : base(ErrorMessages.electricityPaymentError)
        {
        }
    }

    /// <summary>
    /// Выбрасывается, если сумма за коммунальные услуги меньше 100 или больше 1000.
    /// </summary>
    public class UtilitiesPaymentException : Exception
    {
        /// <summary>
        /// Конструктор, использующий стандартное сообщение об ошибке из ErrorMessages.
        /// </summary>
        public UtilitiesPaymentException() : base(ErrorMessages.utilitiesPaymentError)
        {
        }
    }
}
