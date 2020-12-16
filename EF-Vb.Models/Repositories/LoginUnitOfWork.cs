using EF_Vb.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Vb.Models.Repositories {
  public class LoginUnitOfWork :IDisposable{
    LoginContextBase _currentContext = null;
    GroepRepository _groepen = null;
    LoginRepository _login = null;

    public LoginUnitOfWork() { }
    public LoginUnitOfWork(LoginContextBase ctx) { CurrentContext = ctx; }
    public LoginContextBase CurrentContext {
      get {
        _currentContext ??= new LoginSqlLiteContext();
        return _currentContext;
      }
      set {
        _currentContext = value;
      }
    }
    public GroepRepository Groepen {
      get {
        _groepen ??= new GroepRepository(CurrentContext);
        return _groepen;
      }
    }
    public LoginRepository Login {
      get {
        _login ??= new LoginRepository(CurrentContext);
        return _login;
      }
    }

    public int Save() =>CurrentContext.SaveChanges();

    public void Dispose() {
      _currentContext?.Dispose();
      _currentContext = null;
    }
  }
}
