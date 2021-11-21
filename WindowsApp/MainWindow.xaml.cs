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
    }
}

