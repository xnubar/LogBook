using lBook.Model;
using lBook.Model.Admin;
using System;
using System.IO;
using System.Windows;

namespace lBook.ViewModel
{
    class LoginViewModel : ViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public LoginViewModel(MainViewModel main)
        {

            SignUpCommand = new RelayCommand(new Action<object>(Register));
            SignInCommand = new RelayCommand(new Action<object>(TeacherPage));
            ForgotPassword = new RelayCommand(new Action<object>(RecoverPassword));
            NextGo += main.MainWindowView_NextGo;
        }
        #region Recovering Password
        public RelayCommand ForgotPassword { get; set; }
        public void RecoverPassword(object obj)
        {
            NextGo(Model.ViewType.ForgotPassword, new EventArgs());
        }
        #endregion

        #region Sign Up Command
        public RelayCommand SignUpCommand { get; set; }
        public void Register(object obj)
        {
            NextGo(Model.ViewType.Register, new EventArgs());
        }
        #endregion

        #region Sign In Command
        public RelayCommand SignInCommand { get; set; }
        public void TeacherPage(object obj)
        {
            if (TeacherDAO.Instance.Teachers.Count == 0 || File.Exists("Teachers.xml"))
            {
                XML.Instance.Deserialize(TeacherDAO.Instance.Teachers, "Teachers.xml").ForEach(x => TeacherDAO.Instance.Teachers.Add(x));
                // xml.Deserialize(productController.GetProductList(), "Products.xml").ForEach(x => productController.GetProductList().Add(x));
                //if (File.Exists("MostPopularProducts.xml"))
                //{
                //    xml.Deserialize(_MostPopularProducts.GetPopularProducts(), "MostPopularProducts.xml").ForEach(x => productController.GetProductList().Add(x));
                //}

                try
                {
                    if (TeacherService.Instance.Login(Username, Password))
                    {

                        NextGo(ViewType.TeacherPage, new EventArgs());
                        return;
                    }
                    else if (AdminService.Instance.Login(Username, Password))
                    {
                        NextGo(ViewType.AdminPage, new EventArgs());
                        return;
                    }
                    else
                    {
                        NextGo(ViewType.StudentPage, new EventArgs());
                        return;
                    }
                }
                catch (Exception ex)
                {
                    if (String.IsNullOrEmpty(Username) || (String.IsNullOrEmpty(Password)))
                    {
                        MessageBox.Show("USERNAME AND PASSWORD MUST BE FILLED", "WARNING", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, "WARNING", MessageBoxButton.OK, MessageBoxImage.Warning);

                    }
                }
            }
        }
        #endregion

        public event EventHandler NextGo;
    }
}
