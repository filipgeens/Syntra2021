using Boek.Data.Db;
using Boek.Data.Models;
using Boek.Data.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boek.Data.Repository {
  public class BoekRepository : RepositoryBase<Boekje> {
    public BoekRepository(DbContext ctx):base(ctx) { }

    public IQueryable<Boekje> FindInTitle(IQueryable<Boekje> query, string search) => (query ?? Query).Where(t => t.Naam.ToLower().Contains(search.ToLower()));

    public IQueryable<Boekje> FindInContent(IQueryable<Boekje> query, string search) {
      return Query.Where(t => t.KorteInhoud.ToLower().Contains(search.ToLower()));
    }

    public List<Boekje> FindExtended(string title, string korteInhoud,bool canLoadAll=false) {
      var q = Query;
      bool ok = false;
      if (title?.Length > 0) {
        q = FindInTitle(q, title);
        ok = true;
      }
      if (korteInhoud?.Length > 0) {
        q = FindInContent(q, korteInhoud);
        ok = true;
      }
      return (canLoadAll || ok) ? q.Include(t=>t.Genre).ThenInclude(s=>s.Genre).Include(t=>t.Auteur).ToList() : new List<Boekje>();    
    }

    public Boekje LoadBoekDetails(Boekje selectedBoek) {
      if (selectedBoek != null) {
        Context.Entry(selectedBoek).Reference(r => r.Taal).Load();
        Context.Entry(selectedBoek).Reference(r => r.Uitgeverij).Load();
      }
      return selectedBoek;
    }
  }
}
