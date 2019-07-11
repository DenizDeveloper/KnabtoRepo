using Knabto.Contracts;
using Knabto.Services;
using System;
using Xunit;

namespace Knabto.Tests
{
    public class CalculatorTest
    {
        [Fact]
        public void MultiplyTest()
        {
            //Arange
            ICalculator calculator = new Calculator();

            //Act
            decimal result = calculator.Multiply(2, 5);

            //Assert
            Assert.True(result == 10);
        }
    }
}
