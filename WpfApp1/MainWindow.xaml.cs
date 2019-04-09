using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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

            var factory = new CellFactory();

            for (int i = 0; i < myGrid.ColumnDefinitions.Count; i++)
            {
                for (int j = 0; j < myGrid.RowDefinitions.Count; j++)
                {
                    var point = factory.CreateCell(i, j);
                    myGrid.Children.Add(point);
                }
            }

        }

        private void MyGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
