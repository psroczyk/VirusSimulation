using System;
using System.Windows.Media;
using System.Windows.Threading;
using WpfApp1.Abstract;

namespace WpfApp1.States
{
    public class InfectedState : ICellState
    {
        public void Handle(Cell cell)
        {
            cell.X = 2;
        }
    }
}
