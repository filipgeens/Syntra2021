using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Boek.Shared.Defines {
  public interface IRepository<T>  where T : class, IModel {
    T Create(T item);
    void Delete(T item);
    void Delete(int id);
    void Update(T item);
    T Read(int id);
    IQueryable<T> Query { get; }
    IEnumerable<T> ReadAll();
    ObservableCollection<T> ToObservableCollection(bool fillIfEmpty = true);
  }
}
