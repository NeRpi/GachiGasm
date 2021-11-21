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
        private readonly MangaManager mangaManager;
        public MainWindow()
        {
            InitializeComponent();
            
            mangaManager = new MangaManager();
            int page = 1;
            int pageSize = 10;
            
            foreach (var manga in mangaManager.GetAll().Skip(pageSize * (page - 1)).Take(pageSize))
            {
                ManBlock manBlock = new();
                manBlock.Image.ImageSource = new BitmapImage(new Uri(manga?.ImageSrc, UriKind.Absolute));
                manBlock.Name.Text = manga.Name;

                foreach (var genre in manga.Genres)
                {
                    manBlock.Genres.Text += genre.Name + " ";
                }

                manBlock.Star.Text = manga.Rating?.ToString();
                mangaView.Children.Add(manBlock);
            }
        }
    }
}
