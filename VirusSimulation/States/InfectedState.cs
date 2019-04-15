using System.Windows.Media;
using VirusSimulation.Abstract;

namespace VirusSimulation.States
{
    public class InfectedState : ICellState
    {
        public void Handle(CellComponent cell)
        {
            //if (cell.CellState is InfectedState) return;
            cell.Dispatcher.Invoke(() => { cell.Background= Brushes.DarkRed; });
            //cell.Background= Brushes.AliceBlue;
        }
    }
}
