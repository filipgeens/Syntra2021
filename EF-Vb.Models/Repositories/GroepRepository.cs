using EF_Vb.Models.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Vb.Models.Repositories {
  public class GroepRepository {
    public LoginContextBase CurrentContext { get; set; }

    DbSet<Groep> Set { get => CurrentContext.Groepen; }
    public GroepRepository(LoginContextBase ctx) {
      CurrentContext = ctx;
    }
    public void Create(Groep grp) => Set.Add(grp);
    public void Update(Groep grp) => Set.Update(grp);
    public void Delete(Groep grp) => Set.Remove(grp);
    public void Delete(int id) => Delete(Set.Find(id));
    public IQueryable<Groep> Query() => Set.AsQueryable();

    public IEnumerable<Groep> GetAll() => Set.ToList();
    public ObservableCollection<Groep> ToObservableCollection() {
      Set.ToList();      
      return Set.Local.ToObservableCollection();
    }
  }
}
