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

namespace WindowsApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            for (int i = 0; i < 10; i++) {
                ManBlock man = new();
                man.Image.ImageSource = new BitmapImage(new Uri("https://staticrm.rmr.rocks/uploads/pics/01/71/113_o.jpg", UriKind.Absolute));
                man.Name.Text = "Стальной алхимик";
                man.Genres.Text = "боевик экшен";
                man.Star.Text = "4.74";
                mangaview.Children.Add(man);
            }
        }
    }
}
