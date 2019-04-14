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
            InfectChanceSlider.ValueChanged += (sender, args) =>
            {
                InfectChanceValue.Content = InfectChanceSlider.Value + "%";
                Settings.Instance.InfectChanceValue = (int)InfectChanceSlider.Value;
            };

            InureChanceSlider.ValueChanged += (sender, args) =>
            {
                InureChanceValue.Content = InureChanceSlider.Value + "%";
                Settings.Instance.InureChanceValue = (int)InureChanceSlider.Value;
            };

            InfectTimeSlider.ValueChanged += (sender, args) =>
            {
                InfectTimeValue.Content = InfectTimeSlider.Value + "s";
                Settings.Instance.InfectTimeValue = (int)InfectTimeSlider.Value;
            };

            InureTimeSlider.ValueChanged += (sender, args) =>
            {
                InureTimeValue.Content = InureTimeSlider.Value + "s";
                Settings.Instance.InureTimeValue = (int)InureTimeSlider.Value;
            };
        }

        private void MyGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        }
    }
}
