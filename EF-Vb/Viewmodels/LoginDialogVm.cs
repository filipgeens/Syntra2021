using Syntra.Shared.Wpf;
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
  public class LoginDialogVm :ViewModelBase{
    public bool IsAdd { get; set; }= false;
    public LoginUnitOfWork UnitOfWork { get; set; }
    private Login _currentLogin = null;
    ObservableCollection<Groep> _memberGroups = null;
    public LoginDialogVm() {
      AddGroupCommand = new ExecuteCommand(OnAddGroupCommand);
      RemoveGroupCommand = new ExecuteCommand(OnRemoveGroupCommand);
    }

    private void OnRemoveGroupCommand(string obj) {
      if (SelectedMemberGroup != null) {
        MemberGroups.Remove(SelectedMemberGroup);
      }
    }

    private void OnAddGroupCommand(string obj) {
      if (SelectedGroup != null) {
        if (MemberGroups.Where(t => t.Id == SelectedGroup.Id).Any() == false) {
         MemberGroups.Add(SelectedGroup);
        }
      }
    }

    public Groep SelectedGroup { get; set; }

    public Groep SelectedMemberGroup { get; set; }
    private ObservableCollection<Groep> _allGroups = null;
    public ICommand AddGroupCommand { get; set; }
    public ICommand RemoveGroupCommand { get; set; }
    public Login CurrentLogin {
      get {
        _currentLogin ??= new Login();
        return _currentLogin;
      }

      set {
        _currentLogin = value;
        if (_currentLogin == null) IsAdd = true;
        Notify();
      }
    }

    public ObservableCollection<Groep> AllGroups {
      get {
        _allGroups ??=new ObservableCollection<Groep>(UnitOfWork.Groepen.GetAll());
        return _allGroups;
      }

      set {
        _allGroups = value;
      }
    }

    public ObservableCollection<Groep> MemberGroups {
      get {
        _memberGroups ??= new ObservableCollection<Groep>(CurrentLogin.LidVan);
        return _memberGroups;
      }

      set {
        _memberGroups = value;
      }
    }

    public void Save() {
      CurrentLogin.LidVan = MemberGroups.ToList();
      if (IsAdd) {
        UnitOfWork.Login.Create(CurrentLogin);
      } else {
        UnitOfWork.Login.Update(CurrentLogin);
      }
      UnitOfWork.Save();
    }
  }
}
