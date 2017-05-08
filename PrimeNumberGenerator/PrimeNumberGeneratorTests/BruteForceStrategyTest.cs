using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeNumberGeneratorModels.Interfaces;
using PrimeNumberGeneratorModels.Classes.Strategies;

namespace PrimeNumberGeneratorTests
{
    /// <summary>
    /// Summary description for GenerationStrategyTest
    /// </summary>
    [TestClass]
    public class BruteForceStrategyTest
    {
        private List<long> Primes = new List<long>() {  1,2,3,      5,      7,      11,     13,     17,
                                                        19,     23,     29,     31,     37,     41,
                                                        43,     47,     53,     59,     61,     67,
                                                        71,     73,     79,     83,     89,     97 };

        [TestMethod]
        public void TestNext()
        {
            IGenerationStrategy GenerationStrategy = new BruteForceStrategy();
            int p = 0;
            for (int i = 1; i < 100 && p < Primes.Count; i++)
            {
                long actual = i;
                long expected = Primes[p];
                if (GenerationStrategy.ValidatePrime(actual))
                {
                    Assert.AreEqual(expected, actual, $"{GenerationStrategy.GetType().Name}.Next() generated {actual} on iteration {i}");
                    p++;
                }
            }
        }

    }
}
