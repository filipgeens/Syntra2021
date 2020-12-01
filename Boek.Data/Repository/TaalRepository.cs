using Boek.Data.Db;
using Boek.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Boek.Data.Repository {
  public class TaalRepository {
    BoekDb _context = null;
    public BoekDb Context { get { return _context; } set => _context = value; }
    public TaalRepository(BoekDb ctx ) {
      Context = ctx;
    }
    public ObservableCollection<Taal> ToObservableCollection(bool fillIfEmpty = true) {
      if (fillIfEmpty && Context.Talen.Local.Count < 1) {
        Context.Talen.ToList();
      }
      return Context.Talen.Local.ToObservableCollection();
    }

    public void Dispose() {
      _context?.Dispose();
      _context = null;
    }
  }
}
