using System.Collections.Generic;
using System.Linq;
using VirusSimulation.Abstract;

namespace VirusSimulation
{
    public class CellIterator : IIterator
    {
        private int index = 0;
        private List<CellComponent> cells;

        public CellIterator(List<CellComponent> cells)
        {
            this.cells = cells;
        }

        public CellComponent Current()
        {
            return cells.ElementAt(index);
        }

        public CellComponent First()
        {
            index = 0;
            return cells.ElementAt(0);
        }

        public bool HasNext()
        {
            return index < cells.Count;
        }

        public CellComponent Next()
        {
            if (index == 0)
            {
                index++;
                return cells.First();
            }

            return cells.ElementAt(index++);
        }
    }
}
