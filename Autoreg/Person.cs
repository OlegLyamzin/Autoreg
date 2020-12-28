using System;
using System.Collections.Generic;
using System.Text;

namespace Autoreg
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string EmailRecovery { get; set; }
        public string DayBirthday { get; set; }
        public int MonthBirthday { get; set; }
        public string YearBirthday { get; set; }
        public int Gender { get; set; }
        
        public Person()
        {

        }
    }
}
