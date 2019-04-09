using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp1.Abstract;
using WpfApp1.Enums;

namespace WpfApp1
{
    public class Cell : Canvas
    {
        public CellState CellState { get; set; }

        public int X { get; }

        public int Y { get; }


        public Cell(int x, int y, CellState cellState)
        {
            this.X = x;
            this.Y = y;
            this.CellState = cellState;
            Grid.SetColumn(this, x);
            Grid.SetRow(this, y);
            this.Background = Brushes.LawnGreen;
            this.MouseLeftButtonDown += new MouseButtonEventHandler(this.Cell_MouseLeftButtonDown);
        }


        private void Cell_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(X + " " + Y);
        }
    }
}
