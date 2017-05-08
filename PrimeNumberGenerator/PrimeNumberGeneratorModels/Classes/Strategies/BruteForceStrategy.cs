using PrimeNumberGeneratorModels.Classes.BaseClasses;
using PrimeNumberGeneratorModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PrimeNumberGeneratorModels.Classes.Strategies
{
    public class BruteForceStrategy : NotifyBase, IGenerationStrategy
    {
        private List<IOption> _Options;
        public ICollection<IOption> Options
        {
            get { return _Options; }
            set { _Options = value.ToList<IOption>(); NotifyPropertyChanged(); }
        }

        public bool ValidatePrime(long candidateValue)
        {
            for (int i = 2; i < candidateValue; i++)
            {
                if (candidateValue % i == 0)
                    return false;
            }

            return true;
        }
    }
}
