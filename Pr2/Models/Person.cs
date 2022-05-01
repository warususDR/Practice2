using System;
using System.Threading.Tasks;
using PracticeDateHandling.Tools;

namespace PracticeDateHandling.Models
{
    class Person
    {
        //properties

        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthday;

        //constructors
        public Person(string name, string surname, string email, DateTime birthday)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Birthday = birthday;
        }
        public Person(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }
        public Person(string name, string surname, DateTime birthday)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday;
        }
        public Person() { }
        //getters setters
        public string Name
        {
            get { return _name; }
            set
            {
                Utilities.CheckName(value);
                _name = value;
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                Utilities.CheckName(value);
                _surname = value;
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                Utilities.IsValidEmail(value);
                _email = value;
            }
        }

        public DateTime Birthday
        {
            get { return _birthday; }
            set
            {
                Utilities.CheckBirthday(value);
                _birthday = value;
            }
        }
        public string SunSign
        {
            get { return Utilities.ZodiacAsync(Birthday).Result; }
        }

        public string ChineseSign
        {
            get { return Utilities.ChineseZodiacAsync(Birthday).Result; }
        }

        public bool  IsAdult
        {
            get
            {
                var age = Utilities.getAgeAsync(Birthday).Result;
                return age >= 18; 
            }
        }

        public bool IsBirthday
        {
            get { return Birthday.Day == DateTime.Now.Day && Birthday.Month == DateTime.Now.Month; }
        }
    }
}
