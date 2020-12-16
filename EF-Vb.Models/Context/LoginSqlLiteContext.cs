using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Vb.Models.Context {
  public class LoginSqlLiteContext : LoginContextBase {

    public const string StandardSource = "Login.database";

    public string CurrentSource {
      get {
        _currentSource ??= $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).TrimEnd('\\')}\ {StandardSource}";
        return _currentSource;
      }
      set {
        _currentSource = value;
      }
    }
    string _currentSource = null;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseSqlite($"Data Source={CurrentSource}");
      base.OnConfiguring(optionsBuilder);
    }


  }
}
