using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Abstract;

namespace WpfApp1.States
{
    public class InfectedState : CellState
    {
        public InfectedState(CellState cellState)
        {
            this.State = cellState.State;
        }

        public override void Infect()
        {
            return;
        }

        public override void Cure()
        {
            this.Cell.CellState = new ImmuneState(this);

        }
    }
}
