using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace VirusSimulation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<KeyValuePair<int, int>> KeyValuePairs = new List<KeyValuePair<int, int>>();
        private BlockingCollection<Cell> cells;
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

        public MainWindow()
        {
            InitializeComponent();
            PopulateGridWithCells();
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

        private void PopulateGridWithCells()
        {
            cells = new BlockingCollection<Cell>();

            for (int i = 0; i < myGrid.ColumnDefinitions.Count; i++)
            {
                for (int j = 0; j < myGrid.RowDefinitions.Count; j++)
                {
                    var cell = new Cell(i, j);
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
        }

        private void MyGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var point = Mouse.GetPosition(myGrid);
            int row = 0, col = 0;
            double accumulatedHeight = 0.0, accumulatedWidth = 0.0;

            foreach (var rowDefinition in myGrid.RowDefinitions)
            {
                accumulatedHeight += rowDefinition.ActualHeight;
                if (accumulatedHeight >= point.Y)
                    break;
                row++;
            }

            foreach (var columnDefinition in myGrid.ColumnDefinitions)
            {
                accumulatedWidth += columnDefinition.ActualWidth;
                if (accumulatedWidth >= point.X)
                    break;
                col++;
            }

            var cell = cells.FirstOrDefault(x => x.X == col && x.Y == row);
            cell.Infect();
        }
    }
}
