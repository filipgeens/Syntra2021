using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Syntra.Shared.Wpf {
    public class ExecuteCommand : ICommand {
      public event EventHandler CanExecuteChanged;
      public Action<string> _clickAction = null;
      public ExecuteCommand(Action<string> clickCb) {
        _clickAction = clickCb;
      }
      public bool CanExecute(object parameter) => true;

      public void Execute(object parameter) {
        _clickAction(parameter?.ToString());
      }
    
  }
}
