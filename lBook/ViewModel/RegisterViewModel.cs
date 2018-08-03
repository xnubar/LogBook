using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lBook.ViewModel
{
    class RegisterViewModel : ViewModel
    {
        public RegisterViewModel(MainViewModel main)
        {
            Header = "Register";
            BackToMainWindow = new RelayCommand(new Action<object>(BackToLoginPage));
            NextGo += main.MainWindowView_NextGo;
        }
        #region Command for back to LogIn page
        public RelayCommand BackToMainWindow { get; set; }
        public void BackToLoginPage(object obj)
        {
            NextGo(Model.ViewType.Main, new EventArgs());
        }
        #endregion
        public event EventHandler NextGo;


    }
}
