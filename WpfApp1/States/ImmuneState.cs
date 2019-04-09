using System.Windows.Media;
using WpfApp1.Abstract;

namespace WpfApp1.States
{
    public class ImmuneState : ICellState
    {
        public void Handle(Cell cell)
        {
            cell.Background = Brushes.CadetBlue;
        }
    }
}
