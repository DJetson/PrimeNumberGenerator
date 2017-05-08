using PrimeNumberGeneratorModels.Classes.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberGeneratorModels.Classes
{
    public class PrimeNumber : NotifyBase, ICalculatedNumber
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            private set { _Id = value; NotifyPropertyChanged(); }
        }

        private long _Value;
        public long Value
        {
            get { return _Value; }
            set { _Value = value; NotifyPropertyChanged(); }
        }

        private TimeSpan _TimeToCalculate;
        public TimeSpan TimeToCalculate
        {
            get { return _TimeToCalculate; }
            set { _TimeToCalculate = value; NotifyPropertyChanged(); }
        }

        public PrimeNumber(int id)
        {
            Id = id;
        }
    }
}
