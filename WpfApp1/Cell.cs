using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp1.Abstract;
using WpfApp1.States;
using Timer = System.Timers.Timer;

namespace WpfApp1
{
    public class Cell : Canvas
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
            timer.Elapsed -= new ElapsedEventHandler(_timer_Elapsed);
            Inure();
        }

        public void Infect()
        {
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
            //MessageBox.Show(X + " " + Y);
            Infect();
            var rand = new Random(DateTime.Now.Millisecond);
            var time = rand.Next(100, 5000);
            timer = new Timer(time);
            timer.Elapsed += _timer_Elapsed;
            timer.Start();
        }
    }
}
