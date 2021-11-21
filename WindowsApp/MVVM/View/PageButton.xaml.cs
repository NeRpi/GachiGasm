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
using BLL.Services;
using WindowsApp;

namespace WindowsApp.MVVM.View
{
    public partial class PageButton : UserControl
    {
        static int currentPage = 1;
        public PageButton()
        {
            InitializeComponent();
        }

        private void ShowNextPage(object sender, RoutedEventArgs e)
        {
            currentPage++;
            var mainWindow = Application.Current.MainWindow as MainWindow;

            currentPage = mainWindow.TryShowItems(currentPage) ? currentPage : currentPage - 1;
        }
        
        private void ShowPrevPage(object sender, RoutedEventArgs e)
        {
            if (currentPage <= 1)
            {
                return;
            }

            currentPage--;
            var mainWindow = Application.Current.MainWindow as MainWindow;

            currentPage = mainWindow.TryShowItems(currentPage) ? currentPage : currentPage + 1;
        }
    }
}
