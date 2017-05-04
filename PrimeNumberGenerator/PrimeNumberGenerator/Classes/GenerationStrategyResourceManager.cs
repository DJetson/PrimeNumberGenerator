using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberGenerator.Classes
{
    public static class GenerationStrategyResourceManager
    {
        public static string GetStrategyName(Type strategyType)
        {
            //TODO: This needs some error handling for missing resourceKeys
            string resourceKey = $"{strategyType.Name}Name";
            return Properties.Resources.ResourceManager.GetString(resourceKey);
        }

        public static string GetStrategyDescription(Type strategyType)
        {
            //TODO: This needs some error handling for missing resourceKeys
            string resourceKey = $"{strategyType.Name}Description";
            return Properties.Resources.ResourceManager.GetString(resourceKey);
        }
    }
}
