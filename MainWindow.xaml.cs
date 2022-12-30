using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace stoperica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stopwatch stoperica = new Stopwatch();
        DispatcherTimer dispatchertimer = new DispatcherTimer();
        string trenutnoVrijeme = string.Empty;
        string zabiljezenoVrijeme = string.Empty;
       
        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            dispatchertimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dispatchertimer.Tick += new EventHandler(DodajVrijeme);
            dispatchertimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
        }

       
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            stoperica.Start();
            dispatchertimer.Start();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            stoperica.Stop();
        }

        private void buttonReset_Click(object sender, RoutedEventArgs e)
        {
            stoperica.Reset();
            txtStoperica.Text = "00:00:00";
        }
        void DodajVrijeme(object sender, EventArgs e)
        {
            if (stoperica.IsRunning)
            {
                TimeSpan ts = stoperica.Elapsed;
                trenutnoVrijeme = String.Format("{0:00}:{1:00}:{2:00}",
                ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                txtStoperica.Text = trenutnoVrijeme;
            }
        }

        private void btnSpremi_Click(object sender, RoutedEventArgs e)
        {
            
            zabiljezenoVrijeme += (" "+txtStoperica.Text);
            
        }

        private void btnPrikazi_Click(object sender, RoutedEventArgs e)
        {
            txtPrikazi.Text = zabiljezenoVrijeme;
        }
    }
}
