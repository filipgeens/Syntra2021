using Boek.Shared.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace Boek.App.Viewmodels {

  public class MainViewmodel : ViewModelBase {
    Dictionary<string, ViewModelBase> _viewModels = new Dictionary<string, ViewModelBase>();
    ViewModelBase _selectedViewModel = null;
    public MainViewmodel() {
      ChangeToBoekViewCommand = new ExecuteCommand(OnBookClick);
      ChangeToAuteurViewCommand = new ExecuteCommand(OnAuteurClick);
      ViewModels.Add("boek", new BoekViewModel());
      ViewModels.Add("auteur", new AuteurViewModel());
    }
    public ViewModelBase SelectedViewModel { get=> _selectedViewModel; set { _selectedViewModel = value; Notify(); } }
    private void OnAuteurClick(string obj) {
      SelectedViewModel = ViewModels["auteur"];
    }
    private void OnBookClick(string obj) {
      SelectedViewModel = ViewModels["boek"];
    }

    public ICommand ChangeToBoekViewCommand { get; set; }
    public ICommand ChangeToAuteurViewCommand { get; set; }
    public Dictionary<string, ViewModelBase> ViewModels { get => _viewModels;  }
  }
}
