using Boek.Data.Db;
using Boek.Data.Models;
using Boek.Data.Repository;
using Boek.Data.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boek.Data.UnitOfWork {
  public class BoekUnit :UnitOfWorkBase<BoekDb>{
    public RepositoryBase<SubGenre> GenreRepo { get; set; }
    public RepositoryBase<Vorm> VormRepo { get; set; }
    public RepositoryBase<Auteur> AuteurRepo { get; set; }
    public RepositoryBase<Uitgeverij> UitgeverijRepo { get; set; }
    public TaalRepository TaalRepo { get; set; }
    public BoekRepository BoekRepo { get; set; }
    public BoekUnit() {
      GenreRepo = new RepositoryBase<SubGenre>(Context);
      VormRepo = new RepositoryBase<Vorm>(Context);
      AuteurRepo = new RepositoryBase<Auteur>(Context);
      UitgeverijRepo = new RepositoryBase<Uitgeverij>(Context);
      BoekRepo = new BoekRepository(Context);
      TaalRepo = new TaalRepository(Context);
    }

  }
}
