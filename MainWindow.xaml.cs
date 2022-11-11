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

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        string shape_string = "Line";
        Point start, dest;
        Brush CurrentStrokeBrush = new SolidColorBrush(Colors.AntiqueWhite);
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadioButtonIsCheck(object sender, RoutedEventArgs e)
        {
            RadioButton rb1 = sender as RadioButton;
            shape_string = rb1.Content.ToString();
        }

        private void myCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            myCanvas.Cursor = Cursors.Cross;
            start = e.GetPosition(myCanvas);
            positionLabel.Content = $"座標點({start.X}),({start.Y}) - ({dest.X}),({dest.Y})";

            DrawLine(Brushes.Gray, 1);
        }

        private void myCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            dest = e.GetPosition(myCanvas);
            positionLabel.Content = $"座標點({start.X}),({start.Y}) - ({dest.X}),({dest.Y})";

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var line = myCanvas.Children.OfType<Line>().LastOrDefault();
                line.X2 = dest.X;
                line.Y2 = dest.Y;
            }
        }

        private void myCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var line = myCanvas.Children.OfType<Line>().LastOrDefault();
            line.Stroke = CurrentStrokeBrush;
            line.StrokeThickness = 3;

            myCanvas.Cursor = Cursors.Arrow;
        }

        private void DrawLine(Brush brush, int thickness)
        {
            Line Line = new Line()
            {
                Stroke = brush,
                X1 = start.X,
                Y1 = start.Y,
                X2 = dest.X,
                Y2 = dest.Y,
                StrokeThickness = thickness
            };
            myCanvas.Children.Add(Line);
        }
    }
}
