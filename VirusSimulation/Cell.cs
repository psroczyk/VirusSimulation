using System;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Input;
using VirusSimulation.Abstract;
using VirusSimulation.States;
using Timer = System.Timers.Timer;

namespace VirusSimulation
{
    public class Cell : CellComponent
    {
        private Timer timer;

        public Cell(int x, int y, ICellState cellState) : base(x, y, cellState)
        {
            timer = new Timer(Settings.Instance.InfectTimeValue * 1000);
            MouseLeftButtonDown += Cell_MouseLeftButtonDown;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer.Stop();
            timer.Elapsed -= Timer_Elapsed;
            Inure();
        }


        private void Cell_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (timer.Enabled) return;

            Infect();
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }
    }
}
