﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusSimulation
{
    public interface ICell
    {
        void Infect();
        void Inure();
        void Cure();
    }
}
