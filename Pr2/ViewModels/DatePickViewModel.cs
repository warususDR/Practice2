using PracticeDateHandling.Models;
using PracticeDateHandling.Tools;
using PracticeDateHandling.Tools.KMA.ProgrammingInCSharp2022.Practice3LoginControlMVVM.Tools;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace PracticeDateHandling.ViewModels
{
    class DatePickViewModel : INotifyPropertyChanged
    {
        private Person _user = new Person();

        private RelayCommand<object> _submitDateCommand;
        private RelayCommand<object> _cancelCommand;

        private string _birthdayMessage;
        private Visibility _isFilled;
        private string _zodiac;
        private string _zodiacChinese;
        private bool _isBirthday;
        private bool _isAdult;
        private string _displayBirthday;
        private bool _isEnabled = true;
        public DatePickViewModel()
        {
            IsFilled = Visibility.Hidden;
        }

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
                return _user.Name;
            }
            set
            {
                _user.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Surname
        {
            get
            {
                return _user.Surname;
            }
            set
            {
                _user.Surname = value;
                OnPropertyChanged("Surname");
            }
        }


        public DateTime Birthday
        {
            get { return _user.Birthday; }
            set { _user.Birthday = value;
                OnPropertyChanged("Birthday");
            }
        }
        public string Email
        {
            get { return _user.Email; }
            set
            {
                _user.Email = value;
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
        private void SubmitDate()
        {
            try
            {
                IsEnabled = false;
                //Time Consumed by Operations simulation 
                Thread.Sleep(500);
                //End of simulation
                IsFilled = Visibility.Hidden;
                BirthdayMessage = "";
                if (Birthday > DateTime.Now) throw new Exception();
                if (Utilities.getAge(Birthday) > 135) throw new Exception();
                Zodiac = _user.SunSign;
                ZodiacChinese = _user.ChineseSign;
                IsAdult = _user.IsAdult;
                IsBirthday = _user.IsBirthday;
                DisplayBirthday = _user.Birthday.ToString("dd.MM.yyyy");
                if (IsBirthday) BirthdayMessage = "Happy Birthday!";
                IsFilled = Visibility.Visible;
            }
            catch
            {
                MessageBox.Show("Date of birth isn't entered correctly. Please enter it in format d.m.y or choose it from calendar");
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
