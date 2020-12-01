using System;
using System.Collections.Generic;
using System.Text;

namespace Boek.Shared.Defines {
  public interface IUnitOfWork<T> :IDisposable {
    T Context { get; set; }
    void Save();
    void StartTransAction();
    void RollBack();
    void Commit();
  }
}
