using System;
using System.Threading;
using System.Timers;

namespace VirusSimulation
{
    public class RandomStatic
    {
        static int seed = Environment.TickCount;

        static readonly ThreadLocal<Random> random =
            new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref seed)));

        public static int Rand()
        {
            return random.Value.Next(1, 100);
        }
    }
}
