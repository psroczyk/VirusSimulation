﻿using System.Windows.Media;
using WpfApp1.Abstract;

namespace WpfApp1.States
{
    public class HealthyState : ICellState
    {
        public void Handle(Cell cell)
        {
            cell.Background = Brushes.LawnGreen;
        }
    }
}