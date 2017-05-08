using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PrimeNumberGeneratorModels.Classes.BaseClasses
{
    public class NotifyBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName]string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
