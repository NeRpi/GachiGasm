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
using WindowsApp.MVVM.View;
using BLL.Services;

namespace WindowsApp
{
    public partial class MainWindow : Window
    {
        private const int pageSize = 20;
        int currentPage = 1;

        private readonly MangaManager _manager;
        public MainWindow()
        {
            InitializeComponent();

            _manager = new();

            TryShowItems(1);
        }

        public bool TryShowItems(int page)
        {
            if (page > _manager.GetAll().Count() / pageSize || page < 1)
                return false;

            mangaview.Children.Clear();

            foreach (var manga in _manager.GetAll().Skip(pageSize * (page - 1)).Take(pageSize))
            {
                ManBlock man = new();
                man.Image.ImageSource = new BitmapImage(new Uri(manga?.ImageSrc, UriKind.Absolute));
                man.Name.Text = manga.Name;
                man.Star.Text = manga.Rating.ToString();
                mangaview.Children.Add(man);
            }
            return true;
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

