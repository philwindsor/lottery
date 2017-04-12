using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace Lottery.Tests
{
    [Trait("Category", "ShortRandomNumberTests")]
    public class ShortRandomNumberTests
    {
        [Theory]
        [InlineData(1, 1, 50)]
        [InlineData(5, 1, 50)]
        [InlineData(10, 1, 50)]
        public void ShouldGenerateRequestedNumberCount(ushort length, ushort start, ushort end)
        {
            var sut = new NationalLottery.ShortRandomNumberGenerator();
            var numbers = sut.GenerateNumbers(length, start, end);
            numbers.Should().HaveCount(length);
        }

        [Theory]
        [InlineData(6, 1, 6)]
        [InlineData(3, 1, 3)]
        [InlineData(100, 1, 100)]
        public void ShouldGenerateUniqueNumbers(ushort length, ushort start, ushort end)
        {
            var sut = new NationalLottery.ShortRandomNumberGenerator();
            sut.GenerateNumbers(length, start, end).Should().OnlyHaveUniqueItems();
        }

        [Fact]
        public void ShouldThrowErrorMaxNumberGreaterThanMin()
        {
            var sut = new NationalLottery.ShortRandomNumberGenerator();            

            Action action = () => sut.GenerateNumbers(8, 3, 2);

            action
                .ShouldThrow<ArgumentException>()
                .WithMessage("maxNumber must be greater than minNumber.");
        }

        [Fact]
        public void ShouldThrowErrorNumberCountGreaterThanRange()
        {
            var sut = new NationalLottery.ShortRandomNumberGenerator();

            Action action = () => sut.GenerateNumbers(8, 1, 2);            

            action
                .ShouldThrow<ArgumentException>()                
                .WithMessage("numberCount is greater than requested range.");
        }
    }
}
