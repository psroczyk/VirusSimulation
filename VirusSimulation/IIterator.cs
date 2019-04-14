﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusSimulation
{
    public interface IIterator
    {
        bool HasNext();

        ICell Next();
    }
}
