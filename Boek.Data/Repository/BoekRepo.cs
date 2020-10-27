using Boek.Data.Db;
using Boek.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boek.Data.Repository {
  public class BoekRepo : IDisposable {
    BoekDb _db = null;
    public BoekRepo() {}
    public BoekDb Db { get { _db??=new BoekDb(); return _db; } set => _db = value; }

    public List<Boekje> AllBooks {
      get {
       var res=Db.Boeken.Where(t => t.Id > 0).ToList();
        return res;
      }
    }


    public void Dispose() {
      _db?.Dispose();
      _db = null;
    }
  }
}
