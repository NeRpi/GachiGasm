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
using DAL.Entities;
using WindowsApp;
using DAL.Repositories;

namespace WindowsApp.MVVM.View
{
    public partial class ManBlock : UserControl
    {
        private Manga _manga = new();
        private MainWindow _mainWindow;
        public ManBlock(Manga manga)
        {
            InitializeComponent();
            _mainWindow = Application.Current.MainWindow as MainWindow;
            _manga = manga;
            Image.ImageSource = new BitmapImage(new Uri(manga?.ImageSrc, UriKind.Absolute));
            Name.Text = manga.Name;
            foreach (var gener in manga.Genres)
                Genres.Text += gener.Name + ' ';
            Star.Text = manga.Rating.ToString();
            Star.IsReadOnly = true;

        }

        private void Deletions(object sender, RoutedEventArgs e)
        {
            MangaManager manager = new();
            manager.DelManga(_manga);
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.TryShowItems(mainWindow.currentPage);
        }

        private void UpdateMode(object sender, RoutedEventArgs e)
        {
            Name.IsReadOnly = !Name.IsReadOnly;
            Star.IsReadOnly= !Star.IsReadOnly;
        }

        private void UpdateItem(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                _manga.Name = Name.Text;
                _manga.Rating = float.Parse(Star.Text);

                _mainWindow.UpdateManga(_manga);
                MessageBox.Show("Updated 1 item");
            }
        }
    }
}
