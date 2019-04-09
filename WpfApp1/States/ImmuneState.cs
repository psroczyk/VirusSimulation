using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Abstract;

namespace WpfApp1.States
{
    public class ImmuneState : CellState
    {
        public ImmuneState(CellState cellState)
        {
            this.State = cellState.State;
        }

        public override void Infect()
        {
            throw new NotImplementedException();
        }

        public override void Cure()
        {
            throw new NotImplementedException();
        }
    }
}
