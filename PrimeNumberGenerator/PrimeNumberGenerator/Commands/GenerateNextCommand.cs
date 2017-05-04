using PrimeNumberGenerator.Classes;
using PrimeNumberGenerator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrimeNumberGenerator.Commands
{
    public class GenerateNextCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            MainWindowViewModel Parameter = parameter as MainWindowViewModel;

            if (Parameter == null)
                return false;

            if (Parameter?.GreaterThan < 3)
                return false;

            if (Parameter.SizeOfNextGeneratedCollection != -1 && Parameter?.SizeOfNextGeneratedCollection < 1)
                return false;

            return true;
        }

        public void Execute(object parameter)
        {
            //TODO: Most of the logic in this method should probably be moved off into the MainWindowViewModel because
            //      it just doesn't feel right being here. The MainWindowViewModel class already knows about most of the
            //      classes involved so there's not really a reason to have it here as well.
            MainWindowViewModel Parameter = parameter as MainWindowViewModel;

            Parameter.GeneratePrimes();
        }
    }
}
