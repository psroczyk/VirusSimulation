using System.Windows.Media;
using VirusSimulation.Abstract;

namespace VirusSimulation.States
{
    public class HealthyState : ICellState
    {
        public void Handle(CellComponent cell)
        {
            try
            {
                cell.Dispatcher.Invoke(() => { cell.Background = Brushes.LawnGreen; });
            }
            catch { }
        }
    }
}
