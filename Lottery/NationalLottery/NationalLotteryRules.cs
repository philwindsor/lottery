using Lottery.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.NationalLottery
{
    public class NationalLotteryRules : IRules
    {
        private readonly IRandomNumberGenerator<ushort> numberGenerator;
        public NationalLotteryRules(IRandomNumberGenerator<ushort> numberGenerator)
        {
            if (numberGenerator == null)
            {
                throw new ArgumentNullException(nameof(numberGenerator));
            }

            this.numberGenerator = numberGenerator;

        }

        private const ushort NumberWinCount = 6;

        public bool CanPlay(ushort age) => age >= MinimumPlayerAge;

        public ushort MinimumPlayerAge => 16;

        public ushort[] GenerateDraw()
        {
            return numberGenerator.GenerateNumbers(6, 1, 59).ToArray();
        }

        public bool HasPlayerWon(IEnumerable<ushort> drawnNumbers, IEnumerable<ushort> playerNumbers)
        {
            ushort numbersMatched = 0;

            foreach (var playernumber in playerNumbers)
            {
                if (drawnNumbers.Any(q => q == playernumber))
                {
                    numbersMatched++;
                }
            }

            return numbersMatched == NumberWinCount;
        }
    }
}
