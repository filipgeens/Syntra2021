using Boek.Data.Db;
using Boek.Data.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.ObjectModel;
using Boek.Data.Shared;
using Microsoft.EntityFrameworkCore;

namespace Boek.Data.Repository {
  public class AuteurRepository : RepositoryBase<Auteur>{
    public AuteurRepository(DbContext ctx):base(ctx) {

    }
  }
}
