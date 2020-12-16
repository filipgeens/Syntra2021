using EF_Vb.Models.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Vb.Models.Repositories {
  public class LoginRepository {

    public LoginContextBase CurrentContext { get; set; }

    DbSet<Login> Set { get => CurrentContext.Logins; }
    public LoginRepository(LoginContextBase ctx) {
      CurrentContext = ctx;
    }
    public void Create(Login lgn) => Set.Add(lgn);
    public void Update(Login lgn) => Set.Update(lgn);
    public void Delete(Login lgn) => Set.Remove(lgn);
    public void Delete(int id) => Delete(Set.Find(id));
    public IQueryable<Login> Query() => Set.AsQueryable();
    public Login OpId(int id) => Query().Where(t => t.Id == id).Include(i => i.LidVan).FirstOrDefault();
    public IQueryable<Login> QueryIncludeGroupsMember() => Query().Include(i => i.LidVan);
    public ObservableCollection<Login> ToObservableCollection() {
      if (Set.Local.Count < 1) {
        QueryIncludeGroupsMember().ToList();
      }
      return Set.Local.ToObservableCollection();
    }
  }
}
