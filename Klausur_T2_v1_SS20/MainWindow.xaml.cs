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
using System.Windows.Threading;

namespace Klausur_T2_v1_SS20
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Stein> AlleKörper = new List<Stein>();
        List<Stein> zuLöschendeKörper = new List<Stein>();

        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(17);
            timer.Tick += Animiere;
        }

        private void Animiere(object sender, EventArgs e)
        {
            Zeichenfläche.Children.Clear();
            foreach (Stein k in AlleKörper)
            {
                if(k.Bewege(Zeichenfläche, timer.Interval))
                {
                    zuLöschendeKörper.Add(k);
                }
                k.Zeichne(Zeichenfläche);
            }
            AlleKörper.RemoveAll(x => zuLöschendeKörper.Contains(x));
        }

        private void BTN_Start_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            BTN_Start.IsEnabled = false;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (timer.IsEnabled)
            {
                switch (e.Key)
                {
                    case Key.K:
                        AlleKörper.Add(new Stein(Zeichenfläche, 6));
                        break;
                    case Key.S:
                        AlleKörper.Add(new Stein(Zeichenfläche, 12));
                        break;
                    case Key.F:
                        AlleKörper.Add(new Stein(Zeichenfläche, 24));
                        break;
                    case Key.Space:
                        AlleKörper.ForEach(x => x.ÄndereFarbe());
                        break;
                }
            }
        }
    }
}
