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

  }
}
