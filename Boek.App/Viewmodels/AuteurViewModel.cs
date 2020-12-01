using Boek.App.Dialogs;
using Boek.Data.Db;
using Boek.Data.Models;
using Boek.Data.Repository;
using Boek.Shared.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Boek.App.Viewmodels {
  public class AuteurViewModel :ViewModelBase {

    AuteurRepository _repository = new AuteurRepository(new BoekDb());

    ObservableCollection<Auteur> _auteurList = null;
    public AuteurViewModel() {
      CrudCommand = new ExecuteCommand(OnCrudAuteur);
    }

    private void OnCrudAuteur(string param) {
      if (param == "add") {
        AddAuteurDlg dlg = new AddAuteurDlg(new Auteur());
        if (dlg.ShowDialog() == true) {
          _repository.Create(dlg.CurrentData);
        }
      }
    }

    public ObservableCollection<Auteur> AuteurList { get { _auteurList ??= _repository.ToObservableCollection(); return _auteurList; } set => _auteurList = value; }
    public ICommand CrudCommand { get; set; }
  }
}
