using lBook.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace lBook.ViewModel
{
     class ForgotPasswordViewModel : ViewModel
    {

        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string SentCode { get; set; }
        public string PasswordForRecovering { get; set; }
        public string Code { get; set; }
        public event EventHandler NextGo;
        #region Code Confirmation StackPanel
        /// <summary>
        /// Making stackPanel visible/invisible which is container for code confirmation
        /// </summary>
        private Visibility _showStackPanel;
        public Visibility CodeConfirmation
        {
            get { return _showStackPanel; }
            set
            {
                if (!Equals(_showStackPanel, value))
                {
                    _showStackPanel = value;
                    NotifyPropertyChanged(nameof(CodeConfirmation));
                }
            }
        }
        public RelayCommand SendEmail { get; set; }
        public void SendConfirmationEmail(object obj)
        {
            try
            {
                if (!Email.Equals("admin@gmail.com") && !Regex.IsMatch(Email,
                "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$"))
                {
                    throw new Exception("EMAIL FORMAT ISN'T CORRECT");
                }
                if (!TeacherDAO.Instance.FindByEmail(Email))
                {
                    throw new Exception("USER WITH THIS EMAIL DOES NOT EXIST");
                }
                SentCode = lBook.Password.RecoverPassword(Email);
                CodeConfirmation = Visibility.Visible;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region New Password StackPanel
        /// <summary>
        /// Making stackPanel visible/invisible which is container for new password
        /// </summary>
        private Visibility _passwordStackPanel;
        public Visibility PasswordStackPanel
        {
            get { return _passwordStackPanel; }
            set
            {
                if (!Equals(_passwordStackPanel, value))
                {
                    _passwordStackPanel = value;
                    NotifyPropertyChanged(nameof(PasswordStackPanel));
                }
            }
        }
        public RelayCommand SendCode { get; set; }
        public void SendConfirmationCode(object obj)
        {
            try
            {
                if (!Code.Equals(SentCode))
                {
                    PasswordStackPanel = Visibility.Collapsed;
                    throw new Exception("CODE IS NOT COMPATIBLE");
                }
                PasswordStackPanel = Visibility.Visible;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region Re Password StackPanel
        /// <summary>
        /// Making stackPanel visible/invisible which is container for re password
        /// </summary>
        private Visibility _rePasswordStackPanel;
        public Visibility RePasswordStackPanel
        {
            get { return _rePasswordStackPanel; }
            set
            {
                if (!Equals(_rePasswordStackPanel, value))
                {
                    _rePasswordStackPanel = value;
                    NotifyPropertyChanged(nameof(RePasswordStackPanel));
                }
            }
        }
        public RelayCommand NewPasswordCommand { get; set; }
        public void NewRePassword(object obj)
        {
            try
            {
                if (!lBook.Password.PasswordChecker(Password))
                {
                    RePasswordStackPanel = Visibility.Collapsed;
                    throw new Exception("Your password must contain at least one uppercase letter, symbol and a digit.Example: Password1 * ");
                }
                RePasswordStackPanel = Visibility.Visible;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region SUBMIT
        /// <summary>
        /// Making submit button visible/invisible which changes password
        /// </summary>
        private Visibility submitBtn;
        public Visibility SubmitButton
        {
            get { return submitBtn; }
            set
            {
                if (!Equals(submitBtn, value))
                {
                    submitBtn = value;
                    NotifyPropertyChanged(nameof(SubmitButton));
                }
            }
        }
        public RelayCommand SubmitCommand { get; set; }
        public void EnableSubmitBtn(object obj)
        {
            try
            {
                if (!RePassword.Equals(Password))
                {
                    SubmitButton = Visibility.Collapsed;
                    throw new Exception("YOUR PASSWORDS AREN'T COMPATIBLE");
                }
                SubmitButton = Visibility.Visible;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion


        #region CHANGE PASSWORD
        /// <summary>
        /// Making stackPanel visible/invisible which is container for new password
        /// </summary>
        private Visibility changePassword;
        public Visibility ChangePassword
        {
            get { return changePassword; }
            set
            {
                if (!Equals(changePassword, value))
                {
                    changePassword = value;
                    NotifyPropertyChanged(nameof(ChangePassword));
                }
            }
        }
        public RelayCommand ChangePasswordCommand { get; set; }
        public void EditPassword(object obj)
        {
            if (lBook.Password.EditPasswordByEmail(Email) == Role.Teacher)
            {
                TeacherDAO.Instance.EditPassword(Email, Password);
                MessageBoxResult result = MessageBox.Show($"Password of the user with this email- {Email} is changed SUCCESSFULLY", "INFORMATION", MessageBoxButton.OK, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    NextGo(Model.ViewType.Main, new EventArgs());
                }
            }

        }
        #endregion

        #region Command for back to main window
        public RelayCommand BackToMainWindow { get; set; }
        public void BackToLoginPage(object obj)
        {
            NextGo(Model.ViewType.Main, new EventArgs());
        }
        #endregion

        public ForgotPasswordViewModel(MainViewModel main)
        {
            Header = "RECOVERING PASSWORD";
            BackToMainWindow = new RelayCommand(new Action<object>(BackToLoginPage));
            SendEmail = new RelayCommand(new Action<object>(SendConfirmationEmail));
            SendCode = new RelayCommand(new Action<object>(SendConfirmationCode));
            NewPasswordCommand = new RelayCommand(new Action<object>(NewRePassword));
            SubmitCommand = new RelayCommand(new Action<object>(EnableSubmitBtn));
            ChangePasswordCommand = new RelayCommand(new Action<object>(EditPassword));
            NextGo += main.MainWindowView_NextGo;
            CodeConfirmation = Visibility.Collapsed;
            PasswordStackPanel = Visibility.Collapsed;
            RePasswordStackPanel = Visibility.Collapsed;
            SubmitButton = Visibility.Collapsed;
            ChangePassword = Visibility.Collapsed;
        }

    }
}
