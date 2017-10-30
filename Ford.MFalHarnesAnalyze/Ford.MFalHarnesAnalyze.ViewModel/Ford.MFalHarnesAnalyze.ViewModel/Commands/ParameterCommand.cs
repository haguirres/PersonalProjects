using System;
using System.Windows.Input;

namespace Ford.MFalHarnesAnalyze.ViewModel.Commands
{
    public class ParameterCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<object> action;

        public ParameterCommand(Action<object> action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action(parameter);
        }
    }
}