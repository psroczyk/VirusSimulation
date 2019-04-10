﻿using System;
using System.Windows.Media;
using System.Windows.Threading;
using WpfApp1.Abstract;

namespace WpfApp1.States
{
    public class InfectedState : ICellState
    {
        public void Handle(Cell cell)
        {
            cell.Dispatcher.Invoke(() => { cell.Background= Brushes.DarkRed; });
            //cell.Background= Brushes.AliceBlue;
        }
    }
}
