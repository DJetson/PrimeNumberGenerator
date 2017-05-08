using PrimeNumberGenerator.Interfaces;
using PrimeNumberGeneratorModels.Classes.BaseClasses;

namespace PrimeNumberGenerator.Classes.BaseClasses
{
    public class ViewModelBase : NotifyBase, IViewModel
    {
        private string _Name;
        virtual public string Name
        {
            get { return _Name; }
            set { _Name = value; NotifyPropertyChanged(); }
        }

        private string _Description;
        virtual public string Description
        {
            get { return _Description; }
            set { _Description = value; NotifyPropertyChanged(); }
        }
    }
}
