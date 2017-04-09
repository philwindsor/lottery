using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Engine
{
    public class NationalLottery : IEngine
    {
        private readonly IRandomNumberGenerator<ushort> numberGenerator;
        private const ushort numberCount = 8;
        public NationalLottery(IRandomNumberGenerator<ushort> numberGenerator)
        {
            if (numberGenerator == null)
            {
                throw new ArgumentNullException(nameof(numberGenerator));
            }

            this.numberGenerator = numberGenerator;

        }

        public void Run()
        {
            IEnumerable<ushort> numbersDrawn = numberGenerator.GenerateNumbers(numberCount, 1, 59);
            Console.WriteLine($"This weeks winning numbers are: {string.Join(", ", numbersDrawn.OrderBy(q => q))}");
        }
    }
}
