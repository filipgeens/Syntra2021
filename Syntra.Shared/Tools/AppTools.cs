using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Syntra.Shared.Tools {
  public class AppTools {
    public static string GetAppWorkDirectory(string workdir=null) {
      workdir??=Assembly.GetExecutingAssembly().GetName().Name;
      string dir = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).TrimEnd('\\')}\{workdir}";
      if (!Directory.Exists(dir)) { try { Directory.CreateDirectory(dir); } catch { } }
      return dir;
    }
  }
}
