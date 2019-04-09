using System.Windows.Controls;
using System.Windows.Media;
using WpfApp1.Enums;

namespace WpfApp1.Abstract
{
    public abstract class CellState
    {
        protected Brush ColorBrush { get; set; }

        public Cell Cell { get; set; }

        public State State { get; protected set; }

        public abstract void Infect();
        public abstract void Cure();
    }
}
