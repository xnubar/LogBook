using lBook.Model;
using lBook.View;
using lBook.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

namespace lBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();    
            this.DataContext = new MainViewModel();
            if (TeacherDAO.Instance.Teachers.Count == 0 || File.Exists("Teachers.xml"))
            {
                XML.Instance.Deserialize(TeacherDAO.Instance.Teachers, "Teachers.xml").ForEach(x => TeacherDAO.Instance.Teachers.Add(x));
                // xml.Deserialize(productController.GetProductList(), "Products.xml").ForEach(x => productController.GetProductList().Add(x));
                //if (File.Exists("MostPopularProducts.xml"))
                //{
                //    xml.Deserialize(_MostPopularProducts.GetPopularProducts(), "MostPopularProducts.xml").ForEach(x => productController.GetProductList().Add(x));
                //}
            }

            }
        }
}
