using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursework_oop
{
    class Tenant
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int AppartamentNumb { get; set; }
        public decimal Rent { get; set; }
        public decimal Electricity { get; set; }
        public decimal Utilities { get; set; }

        public Tenant(int id, string lastName, string firstName, int appartamentNumb, decimal rent, decimal electricity, decimal utilities)
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

    static class Regs
    {
        public const String names = @"^[A-Z][a-z]*$";

        public const String cost = @"^(?: [1 - 9]\d*|0)(?:\,\d+)?$";

        public const String flatNumb = @"^(?:[1-9]\d*|0)$";
    }
}
