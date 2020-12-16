using Boek.Shared.Wpf;
using EF_Vb.Dialogs;
using EF_Vb.Models;
using EF_Vb.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EF_Vb.Viewmodels {
  public class MyLoginButtonCommand : ICommand {
    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter) => true;

    public void Execute(object parameter) {

    }
  }

  public class LoginViewmodel :ViewModelBase{
    #region Info
    /// Class : LoginViewmodel
    #endregion Info
    #region Definitions 
    #endregion Definitions
    #region Fields
    LoginUnitOfWork _unit = null;
    ObservableCollection<Login> _loginCollection = null;
    ObservableCollection<Groep> _groepCollection = null;
    #endregion Fields
    #region Constructors
    public LoginViewmodel() {
      GroupCommand = new ExecuteCommand(OnGroupCommand);
      LoginCommand = new ExecuteCommand(OnLoginCommand);
    }
    #endregion Constructors
    #region Properties
    #endregion Properties
    #region Methods
    #endregion Methods      



    public LoginUnitOfWork Unit {
      get {
        _unit ??= new LoginUnitOfWork();
        return _unit;
      }
      set {
        _unit = value;
      }
    }
    public Login SelectedLogin { get; set; }
    public Groep SelectedGroep { get; set; }
    public ICommand GroupCommand { get; set; }
    public ICommand LoginCommand { get; set; }
    public ObservableCollection<Login> LoginCollection {
      get {
        _loginCollection ??= Unit.Login.ToObservableCollection();
        return _loginCollection;
      }

      set {
        _loginCollection = value;
      }
    }
    public ObservableCollection<Groep> GroepCollection {
      get {
        _groepCollection ??= Unit.Groepen.ToObservableCollection();
        return _groepCollection;
      }

      set {
        _groepCollection = value;
      }
    }

    private void OnLoginCommand(string prm) {
      if (prm?.ToLower() == "add") {
        LoginDlg dlg = new LoginDlg(Unit);
        dlg.ShowDialog();
      } else if (prm?.ToLower() == "remove") {
        if (SelectedLogin != null) {
          Unit.Login.Delete(SelectedLogin);
          Unit.Save();
        }
      }
    }

    private void OnGroupCommand(string prm) {
      if (prm?.ToLower() == "add") {
        GroupDialog dlg = new GroupDialog(Unit);
        dlg.ShowDialog();
      } else if (prm?.ToLower() == "remove") {
        if (SelectedGroep != null) {
          Unit.Groepen.Delete(SelectedGroep);
          Unit.Save();
        }
      }
    }

  }
}
