using Boek.Shared.Wpf;
using EF_Vb.Models;
using EF_Vb.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Vb.Viewmodels {
  public class GroupDialogVm : ViewModelBase {
    public bool IsAdd { get; set; } = false;
    public LoginUnitOfWork UnitOfWork { get; set; }

    public GroupDialogVm() {

    }
    public Groep CurrentGroep {
      get {
        _currentGroep ??= new Groep();
        return _currentGroep;
      }

      set {
        IsAdd = value == null;
        _currentGroep = value;
      }
    }

    private Groep _currentGroep = null;
    public void Save() {
      if (IsAdd) {
        UnitOfWork.Groepen.Create(CurrentGroep);
      } else {
        UnitOfWork.Groepen.Update(CurrentGroep);
      }
      UnitOfWork.Save();
    }
  }
}
