using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public CellComponent(int x, int y, ICellState cellState)
        {
            this.cellComponents = new List<CellComponent>();
            this.X = x;
            this.Y = y;
            this.cellState = cellState;
            cellState.Handle(this);
        }

        public IIterator GetIterator()
        {
            return new CellIterator(cellComponents);
        }

        public void Infect()
        {
            if (cellState is InfectedState) return;

            cellState = new InfectedState();
            cellState.Handle(this);
        }

        public void Inure()
        {
            cellState = new ImmuneState();
            cellState.Handle(this);
        }

        public void Cure()
        {
            cellState = new HealthyState();
            cellState.Handle(this);
        }

        public void AddChild(CellComponent cellComponent)
        {
            this.cellComponents.Add(cellComponent);
        }
    }
}
