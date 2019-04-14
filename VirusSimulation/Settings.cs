using System;

namespace VirusSimulation
{
    public class Settings
    {
        private static readonly Lazy<Settings> Lazy = new Lazy<Settings>(() => new Settings());

        private Settings() { }

        public static Settings Instance => Lazy.Value;

        public int InfectChanceValue { get; set; }

        public int InureChanceValue { get; set; }

        public int InfectTimeValue { get; set; }

        public int InureTimeValue { get; set; }
    }
}
