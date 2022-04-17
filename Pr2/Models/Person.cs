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
            _name = name;
            _surname = surname;
            _email = email;
            _birthday = birthday;
        }
        public Person(string name, string surname, string email)
        {
            _name = name;
            _surname = surname;
            _email = email;
        }
        public Person(string name, string surname, DateTime birthday)
        {
            _name = name;
            _surname = surname;
            _birthday = birthday;
        }
        public Person() { }
        //getters setters
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
            }
        }

        public DateTime Birthday
        {
            get { return _birthday; }
            set
            {
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
