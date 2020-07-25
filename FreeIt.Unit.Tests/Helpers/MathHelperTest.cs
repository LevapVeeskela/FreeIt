using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using FreeIt.Domain.Common.Helpers;
using Xunit;

namespace FreeIt.Unit.Tests.Helpers
{
    public class MathHelperTest
    {
        [Theory]
        [InlineData(1, 2, "+", 3)]
        [InlineData(-4, -6, "-", 2)]
        [InlineData(-2, 2, "*", -4)]
        [InlineData(20, 5, "/", 4)]
        public void CalculateTestShouldSucceed(double arg1, double arg2, string @operator, double result)
        {
            // Act
            var resultCalculate = MathHelper.Calculate(arg1, arg2, @operator);

            // Assert
            Assert.Equal(resultCalculate, result);
            Assert.IsType<double>(resultCalculate);
            Assert.NotEqual(0, resultCalculate);
        }  

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(4, 6, 24)]
        [InlineData(-200, 200, 40000)]
        [InlineData(100, -300, 400, 12000000)]
        public void CalculateMultiplyTestShouldSucceed(params int[] args)
        {
            // Arrange
            var result = args.LastOrDefault();
            var tempValues = args.ToList();
            tempValues.Remove(result);

            // Act
            var resultCalculate = MathHelper.Calculate(MathHelper.Multiple, tempValues.ToArray());

            // Assert
            Assert.Equal(resultCalculate, result);
            Assert.IsType<long>(resultCalculate);
            Assert.NotEqual(0, resultCalculate);
        }
        
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(4, 6, 10)]
        [InlineData(200, 200, 400)]
        [InlineData(56, 1234, 1290)]
        [InlineData(100, 300, 400, 800)]
        public void CalculateAdditionTestShouldSucceed(params int[] args)
        {
            // Arrange
            var result = args.LastOrDefault();
            var tempValues = args.ToList();
            tempValues.Remove(result);

            // Act
            var resultCalculate = MathHelper.Calculate(MathHelper.AddInColumn, tempValues.ToArray());

            // Assert
            Assert.Equal(resultCalculate, result);
            Assert.IsType<long>(resultCalculate);
            Assert.NotEqual(0, resultCalculate);
        }
    }
}