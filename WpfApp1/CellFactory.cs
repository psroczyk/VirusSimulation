using System.Windows.Controls;
using WpfApp1.States;

namespace WpfApp1
{
    public class CellFactory
    {
        public Cell CreateCell(int x, int y)
        {
            var cell = new Cell(x,y, new HealthyState());
            Grid.SetColumn(cell, x);
            Grid.SetRow(cell, y);
            return cell;
        }
    }
}
