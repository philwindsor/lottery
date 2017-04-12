﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Engine
{
    public interface IEngine
    {
        void Run(IEnumerable<IPlayer> players);
    }
}
