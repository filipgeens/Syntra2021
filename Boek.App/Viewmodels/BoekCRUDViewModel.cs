using Boek.Data.Db;
using Boek.Data.Models;
using Boek.Data.Repository;
using Boek.Data.Shared;
using Boek.Data.UnitOfWork;
using Boek.Shared.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Boek.App.Viewmodels {
  public class BoekCRUDViewModel : ViewModelBase {
    BoekUnit _dbUnit = new BoekUnit();
    Boekje _current = null;
    public ObservableCollection<SubGenre> GenreList { get; set; }
    public ObservableCollection<Vorm> VormList { get; set; }
    public ObservableCollection<Taal> TaalList { get; set; }
    public ObservableCollection<Auteur> AuteurList { get; set; }
    public ObservableCollection<Uitgeverij> UitgeverijList { get; set; }
    public Boekje Current { get => _current; set { _current = value; Notify(); } }
    public bool IsNew { get; set; } = true;
    public BoekUnit DbUnit { get => _dbUnit; set => _dbUnit = value; }

    public BoekCRUDViewModel(Boekje curBoek,bool isNew) {
      IsNew = isNew;
      Current = curBoek;
      GenreList = DbUnit.GenreRepo.ToObservableCollection();
      VormList = DbUnit.VormRepo.ToObservableCollection();
      AuteurList = DbUnit.AuteurRepo.ToObservableCollection();
      UitgeverijList = DbUnit.UitgeverijRepo.ToObservableCollection();
      TaalList = DbUnit.TaalRepo.ToObservableCollection();
    }
    public bool Save() {
      if (IsNew) DbUnit.BoekRepo.Create(Current);
      else DbUnit.BoekRepo.Update(Current);
      DbUnit.Save();
      return true;
    }

  }
}
