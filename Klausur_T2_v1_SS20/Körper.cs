using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Klausur_T2_v1_SS20
{
    abstract class Körper
    {
        public double x, y;
        protected double ay, vy=0;
        Polygon umriss;
        static protected Random rnd = new Random();

        public Körper(double x, double Radius)
        {
            this.x = x;
            y = 0;
            ay = 1000;

            umriss = new Polygon();
            for (int i = 0; i < 20; i++)
            {
                double r = Radius / 2.0 * rnd.NextDouble() + Radius;
                double winkel = 2 * Math.PI / 20 * i;
                umriss.Points.Add(new System.Windows.Point(r * Math.Cos(winkel), r * Math.Sin(winkel)));
            }
            umriss.Fill = Brushes.Gray;
        }

        public bool Bewege(Canvas ZF, TimeSpan time)
        {
            bool rausgeflogen = false;
            vy += ay * time.TotalSeconds;
            y += vy*time.TotalSeconds;
            if (y > ZF.ActualHeight) rausgeflogen = true;
            if (y < 0) rausgeflogen = true;
            return rausgeflogen;
        }

        public void Zeichne(Canvas ZF)
        {
            ZF.Children.Add(umriss);
            Canvas.SetLeft(umriss, x);
            Canvas.SetTop(umriss, y);
        }

        public  void ÄndereFarbe()
        {
            if (umriss.Fill == Brushes.Gray) umriss.Fill = Brushes.Brown;
            else umriss.Fill = Brushes.Gray;
        }
    }

    class Kiesel : Körper
    {
       
        public Kiesel(Canvas ZF)
            : base(rnd.NextDouble()*ZF.ActualWidth, 6)
        {
            
        }

    }

    class Stein : Körper
    {
        public Stein(Canvas ZF)
            : base(rnd.NextDouble() * ZF.ActualWidth, 12)
        {
            
        }
    }

    class Fels : Körper
    {
        
        public Fels(Canvas ZF)
            : base(rnd.NextDouble() * ZF.ActualWidth, 24)
        {
            
        }
    }
}
