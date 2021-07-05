using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Core;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Platform _platform;
        private System.Windows.Shapes.Rectangle _Platform;
        public MainWindow()
        {
            InitializeComponent();
            _platform = new Platform(SystemParameters.PrimaryScreenWidth - 20, (SystemParameters.PrimaryScreenWidth - 20 )*0.1);
            Demo();
        }

        private void Demo()
        {
            var Borders = new System.Windows.Shapes.Rectangle();
            Borders.Stroke = Brushes.Goldenrod;
            Borders.MinWidth = System.Windows.SystemParameters.PrimaryScreenWidth-20;
            Borders.MinHeight = System.Windows.SystemParameters.PrimaryScreenHeight-150;
            Canvas.Children.Add(Borders);
            Canvas.SetLeft(Borders,10);
            Canvas.SetTop(Borders, 60);
            
            _Platform = new System.Windows.Shapes.Rectangle();
            _Platform.Fill = Brushes.Green;
            _Platform.Width = _platform.Width;
            _Platform.Height = 25;
            _Platform.Name = "_Platform";
            Canvas.Children.Add(_Platform);
            Canvas.SetLeft(_Platform,10 + _platform.XPosition);
            Canvas.SetBottom(_Platform, 25);
        }

        private void OnSizeChangedEvent(object sender, SizeChangedEventArgs e)
        {
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            var point = Mouse.GetPosition(Application.Current.MainWindow);
            _platform.XPosition = (point.X - 10 - _platform.Width/2);
            Canvas.SetLeft(_Platform, 10 + _platform.XPosition);
        }
    }
}