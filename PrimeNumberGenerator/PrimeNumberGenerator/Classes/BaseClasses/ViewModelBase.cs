using PrimeNumberGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
