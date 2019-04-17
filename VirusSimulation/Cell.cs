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
            timer = new Timer();
        }

        public override void Infect()
        {
            if (timer.Enabled)
            {
                return;
            }

            cellState = new InfectedState();
            cellState.Handle(this);

            timer = new Timer(Settings.Instance.InfectTimeValue * 1000);
            timer.Elapsed += (sender, e) => MainWindow.Timer_Elapsed(sender, e, this);
            timer.Start();
        }

        public override void Inure()
        {
            if (timer.Enabled)
            {
                return;
            }

            cellState = new ImmuneState();
            cellState.Handle(this);
            timer = new Timer(Settings.Instance.InureTimeValue * 1000);
            timer.Elapsed += (s, e) => MainWindow.Timer_Elapsed_Heal(s, e, this);
            timer.Start();
        }

        public override void Cure()
        {
            if (timer.Enabled)
            {
                return;
            }

            cellState = new HealthyState();
            cellState.Handle(this);
        }
    }
}
