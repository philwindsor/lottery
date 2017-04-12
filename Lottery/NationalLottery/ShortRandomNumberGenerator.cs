using Lottery.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.NationalLottery
{
    public class ShortRandomNumberGenerator : IRandomNumberGenerator<ushort>
    {
        public ShortRandomNumberGenerator()
        {

        }

        public IEnumerable<ushort> GenerateNumbers(ushort numberCount, ushort minNumber, ushort maxNumber)
        {
            if (minNumber >= maxNumber)
            {
                throw new ArgumentException($"{nameof(maxNumber)} must be greater than {nameof(minNumber)}.");
            }

            if (numberCount > (maxNumber - minNumber + 1))
            {
                throw new ArgumentException($"{nameof(numberCount)} is greater than requested range.");
            }

            // TODO: We could optimize this, if the range requested is equal to the min/max numbers we could just 
            // generate a sequence instead of running this random loop.

            Random rand = new Random(DateTime.Now.Millisecond);

            IList<ushort> numbers = new List<ushort>();

            while (numbers.Count < numberCount)
            {
                var randNum = Convert.ToUInt16(rand.Next(minNumber, maxNumber + 1));
                if (!numbers.Any(q => q == randNum))
                {
                    numbers.Add(randNum);
                }
            }

            return numbers.AsEnumerable();
        }
    }
}
