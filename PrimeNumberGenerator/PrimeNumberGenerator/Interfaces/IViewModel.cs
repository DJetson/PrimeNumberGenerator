using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberGenerator.Interfaces
{
    public interface IViewModel : INotifyPropertyChanged
    {
        string Name { get; set; }
    }
}
