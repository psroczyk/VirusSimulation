using System.Windows.Media;
using VirusSimulation.Abstract;

namespace VirusSimulation.States
{
    public class InfectedState : ICellState
    {
        public void Handle(Cell cell)
        {
            //if (cell.CellState is InfectedState) return;
            cell.Dispatcher.Invoke(() => { cell.Background= Brushes.DarkRed; });
            //cell.Background= Brushes.AliceBlue;
        }
    }
}
