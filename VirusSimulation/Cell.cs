using System;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Input;
using VirusSimulation.Abstract;
using VirusSimulation.States;
using Timer = System.Timers.Timer;

namespace VirusSimulation
{
    public class Cell : Canvas, ICell
    {
        public ICellState CellState { get; set; }

        public int X { get; }

        public int Y { get; }

        private Timer timer;

        public Cell(int x, int y, ICellState cellState)
        {
            X = x;
            Y = y;
            CellState = cellState;
            MouseLeftButtonDown += Cell_MouseLeftButtonDown;
            CellState.Handle(this);
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer.Stop();
            timer.Elapsed -= _timer_Elapsed;
            Inure();
        }

        public void Infect()
        {
            if (CellState is InfectedState) return;

            CellState = new InfectedState();
            CellState.Handle(this);
        }

        public void Inure()
        {
            CellState = new ImmuneState();
            CellState.Handle(this);
        }

        public void Cure()
        {
            CellState = new HealthyState();
            CellState.Handle(this);
        }

        private void Cell_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Infect();
            var rand = new Random(DateTime.Now.Millisecond);
            var time = rand.Next(100, 5000);
            timer = new Timer(time);
            timer.Elapsed += _timer_Elapsed;
            timer.Start();
        }
    }
}
