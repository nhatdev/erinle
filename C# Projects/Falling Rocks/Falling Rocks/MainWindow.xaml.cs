using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Falling_Rocks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DrawThread _drawThread;
        private int counter;

        public MainWindow()
        {
            InitializeComponent();
            Grid1.MouseUp += new MouseButtonEventHandler(Grid1_OnMouseUp);
            Button1.MouseUp += new MouseButtonEventHandler(Grid1_OnMouseUp);

            _drawThread = new DrawThread(this);
        }

        private void Grid1_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("You clicked me at " + e.GetPosition(this).ToString());
        }

        private void Button1_OnClick(object sender, RoutedEventArgs e)
        {
            _drawThread.Start();
        }

        public void Draw()
        {
            long lastUpdateTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            Text1.Dispatcher.BeginInvoke(new Action(() =>
            {
                Text1.Text = counter.ToString();
                counter++;
            }));
        }
    }
}
