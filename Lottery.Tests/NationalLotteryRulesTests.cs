using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Lottery.Tests
{
    [Trait("Category", "NationalLotteryRulesTests")]
    public class NationalLotteryRulesTests
    {
        [Theory]
        [InlineData(16)]
        [InlineData(17)]
        [InlineData(18)]
        public void ShouldAllowPlayers(ushort age)
        {
            var randomSub = NSubstitute.Substitute.For<Lottery.Engine.IRandomNumberGenerator<ushort>>();
            var sut = new NationalLottery.NationalLotteryRules(randomSub);
            Assert.True(sut.CanPlay(age));
        }

        [Theory]
        [InlineData(15)]
        [InlineData(14)]
        [InlineData(10)]
        public void ShouldNotAllowPlayers(ushort age)
        {
            var randomSub = NSubstitute.Substitute.For<Lottery.Engine.IRandomNumberGenerator<ushort>>();
            var sut = new NationalLottery.NationalLotteryRules(randomSub);
            Assert.False(sut.CanPlay(age));
        }

        [Theory]
        [InlineData(new ushort[] { 1, 2, 3, 4, 5, 6 }, new ushort[] { 1, 2, 3, 4, 5, 6 })]
        [InlineData(new ushort[] { 2, 1, 3, 4, 6, 5 }, new ushort[] { 1, 2, 3, 4, 5, 6 })]
        public void ShouldWinLottery(ushort[] playerNumbers, ushort[] drawNumbers)
        {
            var randomSub = NSubstitute.Substitute.For<Lottery.Engine.IRandomNumberGenerator<ushort>>();
            var sut = new NationalLottery.NationalLotteryRules(randomSub);
            Assert.True(sut.HasPlayerWon(drawNumbers, playerNumbers));
        }

        [Theory]
        [InlineData(new ushort[] { 1, 20, 3, 4, 5, 6 }, new ushort[] { 3, 4, 5, 6, 1, 2, })]
        [InlineData(new ushort[] { 2, 1, 3, 40, 5, 6 }, new ushort[] { 1, 2, 3, 4, 5, 6 })]
        public void ShouldNotWinLottery(ushort[] playerNumbers, ushort[] drawNumbers)
        {
            var randomSub = NSubstitute.Substitute.For<Lottery.Engine.IRandomNumberGenerator<ushort>>();
            var sut = new NationalLottery.NationalLotteryRules(randomSub);
            Assert.False(sut.HasPlayerWon(drawNumbers, playerNumbers));
        }
    }
}