using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.NationalLottery
{
    public class NationalLotteryPlayer : Engine.IPlayer
    {
        private readonly ushort age;
        private readonly ushort[] numbers;
        public NationalLotteryPlayer(ushort playerAge, ushort[] numbers)
        {
            if(numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            if (numbers.Length != 6)
            {
                throw new ArgumentException("numbers must be equal to 6");
            }

            this.age = playerAge;
            this.numbers = numbers;
        }

        public ushort Age
        {
            get
            {
                return age;
            }
        }

        public ushort[] Numbers
        {
            get
            {
                // This could be randomised?
                return this.numbers;
            }
        }       
    }
}