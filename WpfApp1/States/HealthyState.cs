using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Abstract;
using WpfApp1.Enums;

namespace WpfApp1.States
{
    public class HealthyState : CellState
    {
        public HealthyState(CellState cellState)
        {
            this.State = cellState.State;
        }

        public override void Infect()
        {
            this.Cell.CellState = new InfectedState(this);
        }

        public override void Cure()
        {
            return;
        }
    }
}
