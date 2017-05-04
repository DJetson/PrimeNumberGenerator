using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberGenerator.Interfaces
{
    public interface IGenerationStrategy
    {
        //string Name { get; }
        //string Description { get; }
        long GeneratePrime(long minValue);
        ICollection<IOption> Options { get; set; }
    }
}
