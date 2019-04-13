using System.Windows.Media;
using VirusSimulation.Abstract;

namespace VirusSimulation.States
{
    public class ImmuneState : ICellState
    {
        public void Handle(Cell cell)
        {
            cell.Dispatcher.Invoke(() => { cell.Background = Brushes.CadetBlue; });
        }
    }
}
