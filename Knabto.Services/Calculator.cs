using Knabto.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knabto.Services
{
    public class Calculator : ICalculator
    {
        public decimal Multiply(decimal valueOne, decimal valueTwo) =>
            valueOne * valueTwo;
    }
}
