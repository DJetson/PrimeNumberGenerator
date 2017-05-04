using PrimeNumberGenerator.Classes.BaseClasses;
using PrimeNumberGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberGenerator.Classes.Strategies
{
    public class BruteForceStrategy : NotifyBase, IGenerationStrategy
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName]string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion INotifyPropertyChanged

        private List<IOption> _Options;
        public ICollection<IOption> Options
        {
            get { return _Options; }
            set { _Options = value.ToList<IOption>(); NotifyPropertyChanged(); }
        }

        public long GeneratePrime(long minValue)
        {
            long currentCandidate = minValue + 1;

            while (currentCandidate < long.MaxValue)
            {
                if (ValidatePrime(currentCandidate))
                    return currentCandidate;
                else
                    currentCandidate++;
            }

            throw new OverflowException($"No prime numbers exist found between {minValue} and {long.MaxValue}.");
        }

        private bool ValidatePrime(long candidateValue)
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
