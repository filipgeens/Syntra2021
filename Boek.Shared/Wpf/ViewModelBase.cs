using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Boek.Shared.Wpf {
  public class ViewModelBase : INotifyPropertyChanged {
    protected event PropertyChangedEventHandler _propertyChangedEvent;

    public virtual event PropertyChangedEventHandler PropertyChanged {
      add => _propertyChangedEvent += value;
      remove => _propertyChangedEvent -= value;
    }
    public void UpdateScreen() {
      _propertyChangedEvent?.Invoke("",new PropertyChangedEventArgs(""));
    }

    public void Notify([CallerMemberName] string propertyName = "") {
      _propertyChangedEvent?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
