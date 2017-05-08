using PrimeNumberGeneratorModels.Classes.BaseClasses;
using PrimeNumberGeneratorModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PrimeNumberGeneratorModels.Classes.Strategies
{
    public class CheckPrimeFactorsOnlyStrategy : NotifyBase, IGenerationStrategy
    {
        private List<IOption> _Options;
        public ICollection<IOption> Options
        {
            get { return _Options; }
            set { _Options = value.ToList<IOption>(); NotifyPropertyChanged(); }
        }

        private ICollection<long> _Primes = new ObservableCollection<long>() { 1, 2 };

        public bool ValidatePrime(long candidateValue)
        {
            for (int i = 1; i < _Primes.Count; i++)
            {
                if (candidateValue % _Primes.ElementAt(i) == 0)
                    return false;

                if (_Primes.ElementAt(i) * _Primes.ElementAt(i) > candidateValue)
                    break;
            }

            _Primes.Add(candidateValue);
            return true;
        }
    }
}
