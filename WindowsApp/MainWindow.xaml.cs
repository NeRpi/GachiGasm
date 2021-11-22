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
using DAL.Entities;

namespace WindowsApp
{
    public partial class MainWindow : Window
    {
        private const int pageSize = 20;
        public int currentPage = 1;

        private readonly MangaManager _manager;
        private IQueryable<Manga> _currentPageItems;

        public MainWindow()
        {
            InitializeComponent();

            _manager = new();
            _currentPageItems = _manager.GetAll();

            TryShowItems(1);
        }

        public bool TryShowItems(int page)
        {
            if (page > Math.Ceiling(_currentPageItems.Count() / (pageSize + 0.0)) || page < 1)
                return false;

            ShowMangas(_currentPageItems, page);

            return true;
        }

        public void ShowMangas(IEnumerable<Manga> mangas, int page)
        {
            mangas = mangas.Skip(pageSize * (page - 1)).Take(pageSize);
            mangaview.Children.Clear();
            foreach (var manga in mangas)
            {
                ManBlock man = new(manga);
                mangaview.Children.Add(man);
            }
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

        private void TypeMangi(object sender, RoutedEventArgs e)
        {
            string type = (sender as RadioButton).Content.ToString();
            _currentPageItems = _manager.GetAll().Where(item => item.Type == type);
            ShowMangas(_currentPageItems, 1);
        }

        private void ShowAll(object sender, RoutedEventArgs e)
        {
            _currentPageItems = _manager.GetAll();
            TryShowItems(1);
        }
    }
}

