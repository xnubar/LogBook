using lBook.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace lBook.ViewModel
{
    class MainViewModel : ViewModel
    {
        private ViewModel _currentViewModel;
        private ViewType _viewType;

        public ViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                NotifyPropertyChanged(nameof(Header));
                NotifyPropertyChanged(nameof(CurrentViewModel));
            }
        }
        public MainViewModel()
        {
            try
            {

                CurrentViewModel = new LoginViewModel(this);
                Header = "LOGBOOK";
                _viewType = Model.ViewType.Main;
                NextGo += this.MainWindowView_NextGo;
            }
            catch (Exception)
            {


            }
        }

        public event EventHandler NextGo;

        /// <summary>
        /// Loading pages due to View type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MainWindowView_NextGo(object sender, EventArgs e)
        {

            if ((sender is ViewType) == true)
            {
                if ((ViewType)sender == ViewType.Register)
                {
                    Header = "Register";
                    CurrentViewModel = new RegisterViewModel(this);
                }
                else if ((ViewType)sender == ViewType.TeacherPage)
                {
                    Header = "LOGBOOK";
                    CurrentViewModel = new TeacherViewModel(this);
                }
                else if ((ViewType)sender == ViewType.AdminPage)
                {
                    Header = "LOGBOOK";
                    CurrentViewModel = new AdminViewModel(this);
                }
                else if ((ViewType)sender == ViewType.StudentPage)
                {
                    Header = "LOGBOOK";
                    CurrentViewModel = new StudentViewModel(this);
                }
                else if ((ViewType)sender == ViewType.ForgotPassword)
                {
                    Header = "RECOVERING PASSWORD";
                    CurrentViewModel = new ForgotPasswordViewModel(this);
                }
                else
                {
                    Header = "LOGBOOK";
                    CurrentViewModel = new LoginViewModel(this);
                }
            }
            else
            {
                Header = "LOGBOOK";
            }
        }
    }


}
