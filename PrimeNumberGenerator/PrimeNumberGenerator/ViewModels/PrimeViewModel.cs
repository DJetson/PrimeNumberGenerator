using PrimeNumberGenerator.Classes.BaseClasses;
using PrimeNumberGeneratorModels.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberGenerator.ViewModels
{
    public class PrimeViewModel : ViewModelBase
    {
        private PrimeNumber _Model;
        public PrimeNumber Model
        {
            get { return _Model; }
            private set { _Model = value; }
        }

        public PrimeViewModel(PrimeNumber primeNumber)
        {
            _Model = primeNumber;
        }

        public PrimeViewModel(int id, long primeValue, TimeSpan timeToCalculate)
        {
            _Model = new PrimeNumber(id) { Value = primeValue, TimeToCalculate = timeToCalculate };
        }
    }
}
