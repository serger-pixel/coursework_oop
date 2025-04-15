using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursework_oop
{
    public class Tenant
    {
        public long Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public long AppartamentNumb { get; set; }
        public double Rent { get; set; }
        public double Electricity { get; set; }
        public double Utilities { get; set; }

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

    static class Regs
    {
        public const String names = @"^[A-Z][a-z]*$";

        public const String cost = @"^(?: [1 - 9]\d*|0)(?:\,\d+)?$";

        public const String flatNumb = @"^(?:[1-9]\d*|0)$";
    }
}
