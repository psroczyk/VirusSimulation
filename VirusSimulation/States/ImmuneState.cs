using System.Windows.Media;
using VirusSimulation.Abstract;

namespace VirusSimulation.States
{
    public class ImmuneState : ICellState
    {
        public void Handle(CellComponent cell)
        {
            cell.Dispatcher.Invoke(() => { cell.Background = Brushes.CadetBlue; });
        }
    }
}
