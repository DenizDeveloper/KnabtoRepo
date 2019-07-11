using Knabto.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knabto.Tests.Mocks
{
    internal class CalculatorMock : ICalculator
    {
        public decimal Multiply(decimal valueOne, decimal valueTwo) =>
            12;
    }
}
