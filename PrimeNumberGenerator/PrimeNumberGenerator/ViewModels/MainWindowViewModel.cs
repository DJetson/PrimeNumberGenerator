using PrimeNumberGenerator.Classes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Diagnostics;
using PrimeNumberGeneratorModels.Interfaces;
using System.Collections.Generic;
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

        private ObservableCollection<PrimeViewModel> _Primes = new ObservableCollection<PrimeViewModel>() { new PrimeViewModel(1,1,TimeSpan.Zero),
                                                                                                            new PrimeViewModel(2,2,TimeSpan.Zero) };
        public ObservableCollection<PrimeViewModel> Primes
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

        private double _Milliseconds = 0.0;
        public double Milliseconds
        {
            get { return _Milliseconds; }
            set { _Milliseconds = value; NotifyPropertyChanged(); }
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
        private Stopwatch _stopwatch = Stopwatch.StartNew();

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

            _stopwatch.Start();

            for (int i = 0; i < SizeOfNextGeneratedCollection; i++)
            {
                NextPrime();
            }

            _stopwatch.Stop();
            Milliseconds = (double)((float)_stopwatch.Elapsed.Ticks / 10000.0f);
        }

        public long NextPrime()
        {
            long currentCandidate = Primes.Last().Model.Value + 1;
            
            while (currentCandidate < long.MaxValue)
            {
                long startTicks = _stopwatch.ElapsedTicks;

                if (SelectedGenerationStrategy.Model.ValidatePrime(currentCandidate))
                {
                    long elapsed = _stopwatch.ElapsedTicks - startTicks;
                    Primes.Add(new PrimeViewModel(Primes.Last().Model.Id + 1,currentCandidate,new TimeSpan(elapsed)));
                    return currentCandidate;
                }
                else
                    currentCandidate++;
            }

            throw new OverflowException($"No prime numbers exist found between {currentCandidate} and {long.MaxValue}.");
        }

    }
}