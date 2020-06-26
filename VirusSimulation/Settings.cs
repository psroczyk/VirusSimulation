using System;
using System.Windows.Media;

namespace VirusSimulation
{
    public class Settings
    {
        private static readonly Lazy<Settings> Lazy = new Lazy<Settings>(() => new Settings());

        private Settings()
        {
        }

        public static Settings Instance => Lazy.Value;

        public int InfectChanceValue { get; set; } = 50;

        public int InureChanceValue { get; set; } = 50;

        public int InfectTimeValue { get; set; } = 3;

        public int InureTimeValue { get; set; } = 3;

        public Brush Infected { get; } = Brushes.DarkRed;

        public Brush Immune { get; } = Brushes.CadetBlue;

        public Brush Healthy { get; } = Brushes.LawnGreen;
    }
}
