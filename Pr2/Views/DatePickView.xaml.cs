using PracticeDateHandling.Tools;
using PracticeDateHandling.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PracticeDateHandling.Views
{
    /// <summary>
    /// Логика взаимодействия для DatePickView.xaml
    /// </summary>
    public partial class DatePickView : UserControl
    {
        private DatePickViewModel _viewModel;
        public DatePickView()
        {
            InitializeComponent();
            DataContext = _viewModel = new DatePickViewModel();
            PickDate.DisplayDateEnd = DateTime.Now;
        }
    }
}

    

