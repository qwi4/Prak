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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Linq;

namespace Prak
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Polyline polyline;
        private Polyline polyline2;
        private DispatcherTimer timer;
        private int currentX;

        public MainWindow()
        {
            InitializeComponent();

            // Инициализация Polyline
            polyline = new Polyline
            {
                Stroke = Brushes.Blue,
                StrokeThickness = 2
            };
            polyline2 = new Polyline
            {
                Stroke = Brushes.Green,
                StrokeThickness = 2
            };

            // Инициализация таймера
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.02);
            timer.Tick += Timer_Tick;

            // Добавление Polyline на Canvas
            cns.Children.Add(polyline);
            cns.Children.Add(polyline2);
            // Запуск таймера

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            // Генерация новой точки и добавление ее к Polyline
            double y = rnd.Next(0, 50);
            Point newPoint = new Point(currentX, y);
            polyline.Points.Add(newPoint);

            // Увеличение X для следующей точки
            currentX += 5;

            // Прокрутка графика, если он выходит за пределы Canvas
            if (currentX > cns.ActualWidth)
            {
                PointCollection sourcePoints = polyline.Points;
                if (polyline2.Points.Count != 0)
                {
                    polyline2.Points.Clear();
                }
                foreach(Point point in sourcePoints)
                {
                    polyline2.Points.Add(point);
                }
                polyline.Points.Clear(); // Удаление первой точки
                currentX = 0;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }
    }
}