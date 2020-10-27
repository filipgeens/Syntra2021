using Boek.Data.Models;
using Boek.Data.Repository;
using Boek.Shared.Wpf;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Boek.App.Viewmodels {
  public class BoekViewModel :ViewModelBase{
    ObservableCollection<Boekje> _boekjes = new ObservableCollection<Boekje>();

    public BoekViewModel() {
      SearchCommand = new ExecuteCommand(OnSearchClicked);
    }

    private void OnSearchClicked(string obj) {
      using BoekRepo repo = new BoekRepo();
      BoekLijst.AddRange(repo.AllBooks);
    }

    public ICommand SearchCommand { get; set; }
    public ObservableCollection<Boekje> BoekLijst { get => _boekjes; protected set => _boekjes = value; }



  }
}
