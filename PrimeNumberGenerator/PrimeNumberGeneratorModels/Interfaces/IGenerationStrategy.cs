using System;
using System.Collections.Generic;

namespace PrimeNumberGeneratorModels.Interfaces
{
    public interface IGenerationStrategy
    {
        bool ValidatePrime(long candidateValue);

        //long Next();
        ICollection<IOption> Options { get; set; }
    }
}
