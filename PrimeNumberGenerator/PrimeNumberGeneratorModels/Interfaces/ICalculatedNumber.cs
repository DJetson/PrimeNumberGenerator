using System;

namespace PrimeNumberGeneratorModels.Classes
{
    public interface ICalculatedNumber
    {
        TimeSpan TimeToCalculate { get; set; }
        long Value { get; set; }
    }
}