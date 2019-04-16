using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using System.Collections.Generic;
using VirusSimulation.States;
using VirusSimulation.Abstract;

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

            var cells = new List<CellComponent>();

            for (int i = 0; i < myGrid.ColumnDefinitions.Count; i++)
            {
                for (int j = 0; j < myGrid.RowDefinitions.Count; j++)
                {
                    var cell = new Cell(i, j, new HealthyState());
                    Grid.SetColumn(cell, i);
                    Grid.SetRow(cell, j);
                    cells.Add(cell);
                    myGrid.Children.Add(cell);
                }
            }

            foreach (var cell in cells)
            {
                foreach (var index in KeyValuePairs)
                {
                    int a = cell.X + index.Key, b = cell.Y + index.Value;
                    if (a < 0 || b < 0 || a > myGrid.RowDefinitions.Count - 1 || b > myGrid.ColumnDefinitions.Count - 1) continue;
                    cell.AddChild(cells.FirstOrDefault(x => x.X == a && x.Y == b));
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

        public static List<KeyValuePair<int, int>> KeyValuePairs = new List<KeyValuePair<int, int>>();

        static MainWindow()
        {
            KeyValuePairs.Add(new KeyValuePair<int, int>(-1, -1));
            KeyValuePairs.Add(new KeyValuePair<int, int>(-1, 0));
            KeyValuePairs.Add(new KeyValuePair<int, int>(-1, 1));
            KeyValuePairs.Add(new KeyValuePair<int, int>(0, -1));
            KeyValuePairs.Add(new KeyValuePair<int, int>(0, 1));
            KeyValuePairs.Add(new KeyValuePair<int, int>(1, -1));
            KeyValuePairs.Add(new KeyValuePair<int, int>(1, 0));
            KeyValuePairs.Add(new KeyValuePair<int, int>(1, 1));
        }
    }
}
