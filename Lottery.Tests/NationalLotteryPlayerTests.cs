using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace Lottery.Tests
{
    public class NationalLotteryPlayerTests
    {
        [Fact]
        public void ShouldThrowErrorNumbersNullException()
        {
            Action sut = () => new Lottery.NationalLottery.NationalLotteryPlayer(0, null);
            Assert.Throws<ArgumentNullException>("numbers", sut);
        }

        [Fact]
        public void ShouldThrowErrorNumbersLength()
        {
            Action sut = () => new Lottery.NationalLottery.NationalLotteryPlayer(0, new ushort[] { 1 });
            sut.ShouldThrow<ArgumentException>().WithMessage("numbers must be equal to 6");
        }
    }
}
