using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace lBook.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public string AppPath { get; private set; } = "pack://application:,,,";
        public LoginView()
        {
            InitializeComponent();
            #region Localization
            App.LanguageChanged += Localization.Instance.LanguageChanged;
            CultureInfo currLang = App.Language;
            Localization.Instance.Langs = LangsComboBox;
            LangsComboBox.Items.Clear();
            foreach (var lang in App.Languages)
            {
                ComboBoxItem cBox = new ComboBoxItem();
                cBox.Content = lang.DisplayName;
                cBox.Tag = lang;
                cBox.IsSelected = lang.Equals(currLang);
                cBox.Selected += Localization.Instance.ChangeLanguageClick;
                LangsComboBox.Items.Add(cBox);
            }
            #endregion

        }
        private void ImgShowHide_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            HidePassword();
        }

        private void ImgShowHide_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowPassword();
        }
        private void ImgShowHide_MouseLeave(object sender, MouseEventArgs e)
        {
            HidePassword();
        }
       
        void ShowPassword()
        {
            VisiblePasswordImg.Source = new BitmapImage(new Uri(AppPath + "/Images/visiblePassword.ico"));
            PasswordTxtBox.Visibility = Visibility.Visible;
            txtPasswordbox.Visibility = Visibility.Hidden;
            PasswordTxtBox.Text = txtPasswordbox.Password;
        }
        void HidePassword()
        {
            VisiblePasswordImg.Source = new BitmapImage(new Uri(AppPath + "/Images/invisiblePassword.ico"));
            PasswordTxtBox.Visibility = Visibility.Hidden;
            txtPasswordbox.Visibility = Visibility.Visible;
            txtPasswordbox.Focus();
        }
        private void txtPasswordbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txtPasswordbox.Password.Length > 0)
                VisiblePasswordImg.Visibility = Visibility.Visible;
            else
                VisiblePasswordImg.Visibility = Visibility.Hidden;
        }
    }
}
