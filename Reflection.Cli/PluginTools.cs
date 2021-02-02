using Syntra.Shared.CLI;
using Syntra.Shared.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Reflection.Cli {
  public class DynamicPlugis {

    public static IEnumerable<ICliPlugin> FindAll(string subDir) {
      string dir = AppTools.GetAppWorkDirectory(subDir);
      List<ICliPlugin> result = new List<ICliPlugin>();
      if (Directory.Exists(dir)) {
        var assemblies = Directory.GetFiles(dir, "*.dll");
        foreach (var path in assemblies) {
          Assembly assm = Assembly.LoadFrom(path);
          Type baseType = typeof(ICliPlugin);
          var typelist = assm.GetExportedTypes().Where(t => baseType.IsAssignableFrom(t)).ToList();
          foreach (Type tp in typelist) {
            result.Add(Activator.CreateInstance(tp) as ICliPlugin);
          }
        }
      }
      return result;
    }

   
  }
}
