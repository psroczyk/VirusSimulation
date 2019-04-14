using System.Windows;
using System.Windows.Input;

namespace VirusSimulation
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

            InitializeLabels();
        }

        private void InitializeLabels()
        {
            this.InfectChanceSlider.ValueChanged += (sender, args) => this.InfectChanceValue.Content = InfectChanceSlider.Value + "%";
            this.InureChanceSlider.ValueChanged += (sender, args) => this.InureChanceValue.Content = InureChanceSlider.Value + "%";
            this.InfectTimeSlider.ValueChanged += (sender, args) => this.InfectTimeValue.Content = InfectTimeSlider.Value + "s";
            this.InureTimeSlider.ValueChanged += (sender, args) => this.InureTimeValue.Content = InureTimeSlider.Value + "s";
        }

        private void MyGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        }
    }
}
