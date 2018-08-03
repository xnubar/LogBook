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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lBook.View
{
    /// <summary>
    /// Interaction logic for TeacherPageView.xaml
    /// </summary>
    public partial class TeacherPageView : UserControl
    {
        public TeacherPageView()
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
        public RelayCommand ExpandMenu { get; set; }
        
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }
    }
}
