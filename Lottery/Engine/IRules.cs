using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Engine
{
    public interface IRules
    {
        ushort MinimumPlayerAge { get; }
        bool CanPlay(ushort age);      
        ushort[] GenerateDraw();
        bool HasPlayerWon(IEnumerable<ushort> drawnNumbers, IEnumerable<ushort> playerNumbers);
    }
}
