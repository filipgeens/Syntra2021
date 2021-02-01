using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Reflection.Cli {
  public class PluginTools {
    Assembly _plugin = null;

    public Assembly Plugin { get { return _plugin; } set { _plugin = value; } }
    public bool LoadPlugin(string assmPath) {
      if (assmPath != null && File.Exists(assmPath)) {
        Plugin = Assembly.LoadFrom(assmPath);
        return Plugin != null;
      }
      return false;
    }

  }
}
