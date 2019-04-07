using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp1
{
    public class Cell : Canvas
    {
        public int X { get; }

        public int Y { get; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            Grid.SetColumn(this, x);
            Grid.SetRow(this, y);
            this.Background=Brushes.AntiqueWhite;
            this.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Cell_MouseLeftButtonDown);
        }

        public int State { get; set; }

        private void Cell_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(X + " " + Y);
            //Point p = Mouse.GetPosition(cnv);
            //p.X += cnv.Margin.Left;
            //p.Y += cnv.Margin.Top;
            //txt.Text = p.ToString();
        }
    }
}
