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
using System.IO;

namespace SmashOrPass
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int smash;

        private int pass;

        private int actualImage;
        private int numberOfImages;

        private const string pathPrefix = "D:\\Documents\\SmashOrPass\\";
        private const string pathSuffix = ".jpg";

        public MainWindow()
        {
            InitializeComponent();
            numberOfImages = Directory.GetFiles(pathPrefix).Length;
        }

        private void WindowKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left) SmashClick(this, null);
            if (e.Key == Key.Right) PassClick(this, null);
        }

        private void SmashClick(object sender, RoutedEventArgs e)
        {
            smash++;
            DisplaySmash();
            NextImage();
        }
        
        private void PassClick(object sender, RoutedEventArgs e)
        {
            pass++;
            DisplayPass();
            NextImage();
        }

        private void CancelSmash(object sender, RoutedEventArgs e)
        {
            smash--;
            DisplaySmash();
            PreviousImage();
        }

        private void CancelPass(object sender, RoutedEventArgs e)
        {
            pass--;
            DisplayPass();
            PreviousImage();
        }

        private void NextImage()
        {
            actualImage++;
            DisplayImage();
        }

        private void PreviousImage()
        {
            actualImage--;
            DisplayImage();
        }

        private void DisplaySmash()
        {
            Smash.Content = "Smash: " + smash;
        }

        private void DisplayPass()
        {
            Pass.Content = "Pass: " + pass;
        }

        private void DisplayImage()
        {
            if (actualImage < 0 || actualImage >= numberOfImages)
            {
                TestedImage.Source = null;
                return;
            }

            BitmapImage myBitmapImage = new();
            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri(pathPrefix + actualImage + pathSuffix);
            myBitmapImage.DecodePixelWidth = 1800;
            myBitmapImage.EndInit();
            TestedImage.Source = myBitmapImage;
        }
    }
}
