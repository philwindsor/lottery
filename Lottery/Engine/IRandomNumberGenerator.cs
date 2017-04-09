using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Engine
{
    public interface IRandomNumberGenerator<T>
    {
        IEnumerable<T> GenerateNumbers(T numberCount, T minNumber, T maxNumber);        
    }
}
