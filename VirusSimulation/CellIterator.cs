using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusSimulation
{
    public class CellIterator : IIterator
    {
        private int index = 0;
        private int[,] neighbours = new int[8, 2] { { -1, -1 }, { -1, 0 }, { -1, 1 }, { 0, -1 }, { 0, 1 }, { 1, -1 }, { 1, 0 }, { 1, 1 } };

        public bool HasNext()
        {
            return index < neighbours.Length;
        }

        public CellComponent Next()
        {

            int a, b;
        }
    }
}
