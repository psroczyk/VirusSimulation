using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;
using VirusSimulation.Abstract;
using VirusSimulation.States;

namespace VirusSimulation.Abstract
{
    public abstract class CellComponent : Canvas
    {
        private List<CellComponent> cellComponents;


        protected ICellState cellState;

        public int X { get; }

        public int Y { get; }

        protected CellComponent(int x, int y)
        {
            this.cellComponents = new List<CellComponent>();
            this.X = x;
            this.Y = y;
            this.cellState = new HealthyState();
            cellState.Handle(this);
        }

        public IIterator GetIterator()
        {
            return new CellIterator(cellComponents);
        }

        public void AddChild(CellComponent cellComponent)
        {
            this.cellComponents.Add(cellComponent);
        }

        public abstract void Infect();
        
        public abstract void Inure();

        public abstract void Cure();

        public void Timer_Elapsed_Infect(object sender, ElapsedEventArgs e, Cell cell)
        {
            var tim = (Timer)sender;
            tim.Stop();

            if (Settings.Instance.InureChanceValue >= RandomStatic.Instance.Next(1, 100))
                cell.Inure();
            else
                cell.Infect();

            if (cell.cellState is InfectedState)
            {
                var iterator = cell.GetIterator();

                while (iterator.HasNext())
                {
                    var cellN = iterator.Next();
                    if (Settings.Instance.InfectChanceValue >= RandomStatic.Instance.Next(1, 100))
                    {
                        cellN.Infect();
                    }
                }
            }
        }

        public static void Timer_Elapsed_Heal(object sender, ElapsedEventArgs e, Cell cell)
        {
            var tim = (Timer)sender;
            tim.Stop();
            cell.Cure();
        }
    }
}
