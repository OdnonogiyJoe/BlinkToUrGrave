using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace rage_sava
{
    public class ChavanCommand : ICommand
    {

        Action action;

        public ChavanCommand(Action action)
        {
            this.action = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action();
        }
    }
}
