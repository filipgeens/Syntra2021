using Boek.Data.Models;
using Boek.Data.Repository;
using Boek.Shared.Wpf;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using Boek.App.Dialogs;
using Boek.Data.UnitOfWork;

namespace Boek.App.Viewmodels {
  public class BoekViewModel :ViewModelBase{
    ObservableCollection<Boekje> _boekjes = new ObservableCollection<Boekje>();

    public BoekViewModel() {
      SearchCommand = new ExecuteCommand(OnSearchClicked);
      NewCommand = new ExecuteCommand(OnNewItem);
      UpdateCommand = new ExecuteCommand(OnUpdate);

    }

    private void OnUpdate(string id) {
    }

    private void OnNewItem(string txt) {
      AddBoekDialog addDlg = new AddBoekDialog();
      if (addDlg.ShowDialog() == true) { 
      
      }
    }

    string _currentQuery = null;
    private void OnSearchClicked(string param) {
      BoekUnit unit = new BoekUnit();
      BoekRepository repo = unit.BoekRepo;
      BoekLijst.Clear();
      IQueryable<Boekje> query = null;
      if (TitleSearchString?.Length > 0) {
        query = repo.FindInTitle(query,TitleSearchString);
        CurrentQuery = query.ToQueryString();
      }
      if (ContentSearchString?.Length > 0) {
        query = repo.FindInContent(query,ContentSearchString);
        CurrentQuery = query.ToQueryString();
      }
      query ??= repo.Query;
      BoekLijst.AddRange(query.ToList());
      
    }
    public string TitleSearchString { get; set; }
    public string ContentSearchString { get; set; }
    public ICommand SearchCommand { get; set; }
    public ICommand NewCommand { get; set; }
    public ICommand UpdateCommand { get; set; }
    public ObservableCollection<Boekje> BoekLijst { get => _boekjes; protected set => _boekjes = value; }
    public string CurrentQuery { get => _currentQuery; set { _currentQuery = value; Notify(); } }
  }
}
