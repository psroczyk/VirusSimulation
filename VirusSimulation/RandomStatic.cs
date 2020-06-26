using System;
using System.Timers;

namespace VirusSimulation
{
    public class RandomStatic
    {
        private static readonly Lazy<Random> Lazy = new Lazy<Random>(() => new Random());

        private RandomStatic() { }

        public static Random Instance => Lazy.Value;
    }
}
