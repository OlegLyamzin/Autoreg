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
        public string AnswerQuestion { get; internal set; }
        public string City { get; internal set; }

        public Person()
        {
            FirstName = "Милана";
            LastName = "Бершкинская";
            Login = "bershickayamalaniya97";
            Password = "PUDmklkUI9b";
            Email = Login + "@gmail.com";
            EmailRecovery = "bershickayamalaniya97@myrambler.ru";
            DayBirthday = "15";
            MonthBirthday = 2;
            YearBirthday = "1997";
            Gender = 2;
            AnswerQuestion = "357432";
            City = "Санкт-Петербург";


        }

        public override string ToString()
        {
            string person = Email + ":" + Password + ":" + EmailRecovery + ":" + Password;
            return person;
        }
    }
}
