using PracticeDateHandling.Models;
using PracticeDateHandling.Tools;
using PracticeDateHandling.Tools.KMA.ProgrammingInCSharp2022.Practice3LoginControlMVVM.Tools;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using PracticeDateHandling.Exceptions;

namespace PracticeDateHandling.ViewModels
{
    class DatePickViewModel : INotifyPropertyChanged
    {
        private Person _user;
        //attributes
        private RelayCommand<object> _submitDateCommand;
        private RelayCommand<object> _cancelCommand;
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthday;
        private string _birthdayMessage;
        private Visibility _isFilled;
        private string _zodiac;
        private string _zodiacChinese;
        private bool _isBirthday;
        private bool _isAdult;
        private string _displayBirthday;
        private bool _isEnabled = true;

        //constructor
        public DatePickViewModel()
        {
            IsFilled = Visibility.Hidden;
        }
        //modifiers for attributes
        public string BirthdayMessage
        {
            get { return _birthdayMessage; }
            set { _birthdayMessage = value;
                OnPropertyChanged("BirthdayMessage");
            }
        }

        public Visibility IsFilled
        {
            get { return _isFilled; }
            set
            {
                _isFilled = value;
                OnPropertyChanged("IsFilled");
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
                OnPropertyChanged("Surname");
            }
        }


        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value;
                OnPropertyChanged("Birthday");
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Zodiac
        {
            get { return _zodiac; }
            set 
            { 
                _zodiac = value;
                OnPropertyChanged("Zodiac");
            }
        }


        public string ZodiacChinese
        {
            get { return _zodiacChinese; }
            set 
            { 
                _zodiacChinese = value;
                OnPropertyChanged("ZodiacChinese");
            }
        }


        public bool IsBirthday
        {
            get { return _isBirthday; }
            set 
            { 
                _isBirthday = value;
                OnPropertyChanged("IsBirthday");
            }
        }


        public bool IsAdult
        {
            get { return _isAdult; }
            set 
            {
                _isAdult = value;
                OnPropertyChanged("IsAdult");
            }
        }

        public string DisplayBirthday
        {
            get { return _displayBirthday; }
            set
            {
                _displayBirthday = value;
                OnPropertyChanged("DisplayBirthday");
            }
        }
        
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set 
            { 
                _isEnabled = value;
                OnPropertyChanged("IsEnabled");
            }
        }

        //buttons
        public RelayCommand<object> SubmitDateCommand
        {
            get
            {
                return _submitDateCommand ??= new RelayCommand<object>(_ => SubmitDateAsync(), canExecute);
            }
        }

        public RelayCommand<object> CancelCommand
        {
            get
            {
                return _cancelCommand ??= new RelayCommand<object>(_ => Environment.Exit(0), canExecuteCancel);
            }
        }
        
        private bool canExecute(object obj)
        {
            return Name != "" && Surname != "" && Email != "" && Birthday != default(DateTime) ;
        }
        private bool canExecuteCancel(object obj)
        {
            return true;
        }
        //submitDate
        private void SubmitDate()
        {
            try
            {
                IsEnabled = false;
                IsFilled = Visibility.Hidden;
                //Time Consumed by Operations simulation 
                Thread.Sleep(500);
                //End of simulation
                _user = new Person(Name, Surname, Email, Birthday);
                BirthdayMessage = "";
                Zodiac = _user.SunSign;
                ZodiacChinese = _user.ChineseSign;
                IsAdult = _user.IsAdult;
                IsBirthday = _user.IsBirthday;
                DisplayBirthday = _user.Birthday.ToString("dd.MM.yyyy");
                if (IsBirthday) BirthdayMessage = "Happy Birthday!";
                IsFilled = Visibility.Visible;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                IsEnabled = true;
            }
        }

        private async void SubmitDateAsync()
        {
            await Task.Run(() => SubmitDate());
        }

        // onPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
