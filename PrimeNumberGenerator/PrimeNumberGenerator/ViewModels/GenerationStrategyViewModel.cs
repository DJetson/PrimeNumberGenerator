using PrimeNumberGenerator.Classes;
using PrimeNumberGenerator.Classes.BaseClasses;
using PrimeNumberGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberGenerator.ViewModels
{
    public class GenerationStrategyViewModel<T> : ViewModelBase where T : IGenerationStrategy
    {
        private T _Model;
        public T Model
        {
            get { return _Model; }
        }

        public override string Name
        {
            get
            {
                return GenerationStrategyResourceManager.GetStrategyName(_Model.GetType());
            }
        }

        public override string Description
        {
            get
            {
                return GenerationStrategyResourceManager.GetStrategyDescription(_Model.GetType());
            }
        }

        public GenerationStrategyViewModel(T strategy)
        {
            _Model = strategy;
        }
    }
}
