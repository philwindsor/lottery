using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Engine
{
    public class ShortRandomNumberGenerator : IRandomNumberGenerator<ushort>
    {
        public ShortRandomNumberGenerator()
        {

        }

        public IEnumerable<ushort> GenerateNumbers(ushort numberCount, ushort minNumber, ushort maxNumber)
        {            
            Random rand = new Random(DateTime.Now.Millisecond);

            IList<ushort> numbers = new List<ushort>();

            while (numbers.Count < numberCount)
            {
                var randNum = Convert.ToUInt16(rand.Next(minNumber, maxNumber));
                if (!numbers.Any(q => q == randNum))
                {
                    numbers.Add(randNum);
                }
            }

            return numbers.AsEnumerable();
        }
    }
}
