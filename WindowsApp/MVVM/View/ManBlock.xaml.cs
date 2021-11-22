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
        public ManBlock(Manga manga)
        {
            InitializeComponent();
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
    }
}
