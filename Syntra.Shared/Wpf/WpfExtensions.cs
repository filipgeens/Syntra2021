using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Syntra.Shared.Wpf {
  public static class WpfExtensions {
    public static void AddRange<T>(this ObservableCollection<T> dest, IEnumerable<T> src) {
      foreach (var item in src ?? new T[] { }) {
        dest?.Add(item);
      }
    }

  }
}
