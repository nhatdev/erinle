using System;
using System.Windows;

namespace FallingRocks
{
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
            BtnPlay.Visibility = System.Windows.Visibility.Hidden;
            BtnExit.Visibility = System.Windows.Visibility.Hidden;
            BtnAbout.Visibility = System.Windows.Visibility.Hidden;
            BtnBack.Visibility = System.Windows.Visibility.Visible;
            Credits.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            BtnExit.Visibility = System.Windows.Visibility.Visible;
            BtnPlay.Visibility = System.Windows.Visibility.Visible;
            BtnAbout.Visibility = System.Windows.Visibility.Visible;
            BtnBack.Visibility = System.Windows.Visibility.Hidden;
            Credits.Visibility = System.Windows.Visibility.Hidden;
        }

        private void BtnPlay_OnClick(object sender, RoutedEventArgs e)
        {
            GameWindow gameWindow = new GameWindow();
            gameWindow.Show();
        }

    }
}
