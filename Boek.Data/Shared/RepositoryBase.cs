using Boek.Shared.Defines;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Boek.Data.Shared {
  public class RepositoryBase<T> : IRepository<T> where T : class, IModel  {
    DbContext _context = null;
    DbSet<T> _table = null;
    public RepositoryBase(DbContext ctx) { Context = ctx; }
    public DbContext Context { get { return _context; } set => _context = value; }
    public DbSet<T> Set { get { _table ??= Context.Set<T>(); return _table; } }
    public T Create(T item) {
      EntityEntry<T> res = Set.Add(item);
      return res.Entity;
    }
    public void Delete(T item) {
      Set.Remove(item);
    }
    public void Delete(int id) => Delete(Set.Find(id));

    public T Read(int id) => Set.Find(id);

    public IEnumerable<T> ReadAll() => Set.ToList();
    public ObservableCollection<T> ToObservableCollection(bool fillIfEmpty=true) {
      if (fillIfEmpty && Set.Local.Count < 1) {
        Set.ToList();
      }
      return Set.Local.ToObservableCollection();
    }
    public IQueryable<T> Query => Set.AsQueryable();
    public void Update(T item) {
      Set.Update(item);
    }

  }
}
