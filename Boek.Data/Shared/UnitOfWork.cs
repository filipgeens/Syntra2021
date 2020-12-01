using Boek.Shared.Defines;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boek.Data.Shared {
  public class UnitOfWorkBase<T> : IUnitOfWork<T> where T: DbContext, new(){
    T _context = null;

    public T Context { get { _context??=new T(); return _context; } set => _context = value; }

    public void Commit() => Context.Database.CommitTransaction();

    public void Dispose() {    }

    public void RollBack() => Context.Database.RollbackTransaction();

    public void Save() =>Context.SaveChanges();

    public void StartTransAction() => Context.Database.BeginTransaction();
  }
}
