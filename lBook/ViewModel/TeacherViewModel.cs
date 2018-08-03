using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace lBook.ViewModel
{
    class TeacherViewModel : ViewModel
    {
        private Visibility buttonOpenMenu;
        public Visibility ButtonOpenMenu
        {
            get { return buttonOpenMenu; }
            set
            {
                buttonOpenMenu = value;
                NotifyPropertyChanged(nameof(ButtonOpenMenu));
            }
        }
        private Visibility buttonCloseMenu;
        public Visibility ButtonCloseMenu
        {
            get { return buttonCloseMenu; }
            set
            {
                buttonCloseMenu = value;
                NotifyPropertyChanged(nameof(ButtonCloseMenu));
            }
        }
        public TeacherViewModel(MainViewModel main)
        {
            Header = "LOGBOOK";
            TeacherPageCommand = new RelayCommand(new Action<object>(TeacherPage));
            LogOut = new RelayCommand(new Action<object>(BackToLoginPage));
            NextGo += main.MainWindowView_NextGo;
        }
        public RelayCommand TeacherPageCommand { get; set; }
        private void TeacherPage(object obj)
        {
            NextGo(Model.ViewType.TeacherPage, new EventArgs());
        }
        public RelayCommand LogOut { get; set; }
        private void BackToLoginPage(object obj)
        {
            NextGo(Model.ViewType.Main, new EventArgs());
        }

        public event EventHandler NextGo;
    }
}
