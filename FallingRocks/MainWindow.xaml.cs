using System;
using System.Windows;

namespace FallingRocks
{
    public partial class MainWindow : Window
    {
        public Scores Scores;

        public MainWindow()
        {
            InitializeComponent();
            Scores = new Scores(this);
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
            BtnHighScores.Visibility = System.Windows.Visibility.Visible;
            BtnBack.Visibility = System.Windows.Visibility.Visible;
            Credits.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            BtnExit.Visibility = System.Windows.Visibility.Visible;
            BtnPlay.Visibility = System.Windows.Visibility.Visible;
            BtnAbout.Visibility = System.Windows.Visibility.Visible;
            BtnHighScores.Visibility = System.Windows.Visibility.Visible;
            BtnBack.Visibility = System.Windows.Visibility.Hidden;
            Credits.Visibility = System.Windows.Visibility.Hidden;
            HighScores.Text = "";
        }

        public void btnHighScores_Click(object sender, RoutedEventArgs e)
        {

            Scores.AddScores(15);
            //Scores.AddToHighScores("test");

            CurrentScores.Text = Scores.GetCurrentScores();

            HighScores.Text = 
                Environment.NewLine +
                "High Scores" +
                Environment.NewLine +
                Environment.NewLine +
                Scores.GetHighScores();

            BtnExit.Visibility = System.Windows.Visibility.Hidden;
            BtnPlay.Visibility = System.Windows.Visibility.Hidden;
            BtnAbout.Visibility = System.Windows.Visibility.Hidden;
            BtnHighScores.Visibility = System.Windows.Visibility.Hidden;
            BtnBack.Visibility = System.Windows.Visibility.Visible;
        }

        private void BtnPlay_OnClick(object sender, RoutedEventArgs e)
        {
            //GameWindow gameWindow = new GameWindow();
            //gameWindow.Show();
        }

    }
}
