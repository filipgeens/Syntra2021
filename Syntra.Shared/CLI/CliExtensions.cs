using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Syntra.Shared.CLI {
  public static class CliExtensions {
    public static IEnumerable<ICliPlugin> FindPlugins(this Type tp) => tp?.Assembly?.LoadPlugins() ?? new List<ICliPlugin>();
    public static IEnumerable<ICliPlugin> LoadPlugins(this Assembly assm) {
      List<ICliPlugin> result = new List<ICliPlugin>();
      Type[] typelist = assm?.GetExportedTypes().Where(t => typeof(ICliPlugin).IsAssignableFrom(t)).ToArray();
      foreach (Type tp in typelist ?? new Type[] { }) {
        result.Add(Activator.CreateInstance(tp) as ICliPlugin);
      }
      return result;
    }
  }
}
