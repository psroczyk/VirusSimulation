using System.Windows.Media;
using VirusSimulation.Abstract;

namespace VirusSimulation.States
{
    public class ImmuneState : ICellState
    {
        public void Handle(Cell cell)
        {
            //if (cell.CellState is ImmuneState) return;

            cell.Dispatcher.Invoke(() => { cell.Background = Brushes.CadetBlue; });
        }
    }
}
