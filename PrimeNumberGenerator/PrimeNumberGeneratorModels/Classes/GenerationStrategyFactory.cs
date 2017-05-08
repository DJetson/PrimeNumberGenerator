using PrimeNumberGeneratorModels.Classes.Strategies;
using PrimeNumberGeneratorModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace PrimeNumberGenerator.Classes
{
    public class GenerationStrategyFactory
    {
        private List<Type> _StrategyTypes = new List<Type>() { typeof(BruteForceStrategy), typeof(CheckPrimeFactorsOnlyStrategy) };
        public List<Type> StrategyTypes
        {
            get { return _StrategyTypes; }
        }

        public IGenerationStrategy GetStrategyOfType<T>() where T : IGenerationStrategy, new()
        {
            return new T();
        }

        public IGenerationStrategy GetStrategyOfType(Type type)
        {
            MethodInfo generate = GetType().GetMethod("GetStrategyOfType",Type.EmptyTypes);
            MethodInfo generateWithType = generate.MakeGenericMethod(type);
            return generateWithType.Invoke(this, null) as IGenerationStrategy;
        }
    }

    
}