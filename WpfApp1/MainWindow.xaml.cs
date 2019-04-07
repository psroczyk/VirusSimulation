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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            TextBlock txt2 = new TextBlock();
            txt2.Text = "Quarter 1";
            txt2.FontSize = 12;
            txt2.FontWeight = FontWeights.Bold;
            Grid.SetRow(txt2, 1);
            Grid.SetColumn(txt2, 0);
            var spr = new Canvas();
            spr.Background= Brushes.White;

            Grid.SetRow(spr, 3);
            Grid.SetColumn(spr, 3);
            var point = new Cell(4, 5);
            myGrid.Children.Add(spr);
            myGrid.Children.Add(point);
        }

        private void MyGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
