using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberGenerator.Classes
{
    static class PrimeGenerator
    {
        

        public static long GeneratePrime(long minValue)
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

        private static bool ValidatePrime(long candidateValue)
        {
            return NoOptimizations(candidateValue);

            //return (ModTest(minValue));
            //return MultiplyTest(minValue);


            //if (IsEvenNumber(minValue))
            //    return false;

        }

        private static bool MultiplyTest(long minValue)
        {
            throw new NotImplementedException();
        }

        private static bool ModTest(long value)
        {
            throw new NotImplementedException();
        }

        private static bool NoOptimizations(long value)
        {
            for (int i = 2; i < value; i++)
            {
                if (value % i == 0)
                    return false;
            }
            return true;
        }

        private static bool IsEvenNumber(long minValue)
        {
            return (minValue % 2) == 0;
        }
    }
}
