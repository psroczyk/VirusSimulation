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

        public CellComponent(int x, int y)
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
    }
}
