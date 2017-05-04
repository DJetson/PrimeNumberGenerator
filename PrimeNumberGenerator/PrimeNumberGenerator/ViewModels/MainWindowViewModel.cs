using PrimeNumberGenerator.Classes;
using PrimeNumberGenerator.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Reflection;
using System;

namespace PrimeNumberGenerator.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName]string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private ObservableCollection<long> _Primes = new ObservableCollection<long>() { 1, 2, 3 };
        public ObservableCollection<long> Primes
        {
            get { return _Primes; }
            set { _Primes = value; NotifyPropertyChanged(); }
        }

        private long _GreaterThan = 3;
        public long GreaterThan
        {
            get { return _GreaterThan; }
            set { _GreaterThan = value; NotifyPropertyChanged(); }
        }

        private int _SizeOfNextGeneratedCollection = 100;
        public int SizeOfNextGeneratedCollection
        {
            get { return _SizeOfNextGeneratedCollection; }
            set { _SizeOfNextGeneratedCollection = value; NotifyPropertyChanged(); }
        }

        private GenerationStrategyViewModel<IGenerationStrategy> _SelectedGenerationStrategy;
        public GenerationStrategyViewModel<IGenerationStrategy> SelectedGenerationStrategy
        {
            get { return _SelectedGenerationStrategy; }
            set { _SelectedGenerationStrategy = value; NotifyPropertyChanged(); }
        }

        private ObservableCollection<GenerationStrategyViewModel<IGenerationStrategy>> _GenerationStrategyList;
        public ObservableCollection<GenerationStrategyViewModel<IGenerationStrategy>> GenerationStrategyList
        {
            get { return _GenerationStrategyList; }
            set { _GenerationStrategyList = value; NotifyPropertyChanged(); }
        }

        private GenerationStrategyFactory _GenerationStrategyFactory = new GenerationStrategyFactory();

        public MainWindowViewModel()
        {
            GenerationStrategyList = new ObservableCollection<GenerationStrategyViewModel<IGenerationStrategy>>();

            foreach (var strategy in _GenerationStrategyFactory.StrategyTypes)
                GenerationStrategyList.Add(new GenerationStrategyViewModel<IGenerationStrategy>(_GenerationStrategyFactory.GetStrategyOfType(strategy)));

            SelectedGenerationStrategy = GenerationStrategyList.First();
        }

        internal void GeneratePrimes()
        {
            int count = SizeOfNextGeneratedCollection == -1 ? int.MaxValue : SizeOfNextGeneratedCollection;

            for (int i = 0; i < SizeOfNextGeneratedCollection; i++)
            {
                Primes.Add(SelectedGenerationStrategy.Model.GeneratePrime(GreaterThan));
                GreaterThan = Primes.Last();
            }
        }

    }
}