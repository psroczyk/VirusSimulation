using System;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp1.Abstract;
using WpfApp1.States;

namespace WpfApp1
{
    public class Cell : Canvas
    {
        public ICellState CellState { get; set; }

        public int X { get; }

        public int Y { get; }

        public Cell(int x, int y, ICellState cellState)
        {
            X = x;
            Y = y;
            CellState = cellState;
            MouseLeftButtonDown += Cell_MouseLeftButtonDown;
            CellState.Handle(this);
            var rand = new Random(200);
            var timer = new Timer(rand.Next(100,5000));
            timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
            timer.Enabled = true;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Infect();
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
            MessageBox.Show(X + " " + Y);
            Infect();
        }
    }
}
