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

namespace HomeScreen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            btnPlay.Visibility = System.Windows.Visibility.Hidden;
            btnExit.Visibility = System.Windows.Visibility.Hidden;
            btnAbout.Visibility = System.Windows.Visibility.Hidden;
            btnBack.Visibility = System.Windows.Visibility.Visible;
            Credits.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            btnExit.Visibility = System.Windows.Visibility.Visible;
            btnPlay.Visibility = System.Windows.Visibility.Visible;
            btnAbout.Visibility = System.Windows.Visibility.Visible;
            btnBack.Visibility = System.Windows.Visibility.Hidden;
            Credits.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}