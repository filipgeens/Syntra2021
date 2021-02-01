using System;
using System.IO;

namespace Reflection.Cli {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("Load plugin file");
      try {
        PluginTools plugin = new PluginTools();
        if (plugin.LoadPlugin(args?.Length > 0 ? args[0] : null)) {
          Console.WriteLine($"Plugin loaded: {plugin.Plugin.FullName}");
          Console.WriteLine(plugin.Plugin.Location);
        }
      } catch (Exception ex) {
        Console.WriteLine(ex.Message);
      }
      Console.ReadKey();
    }
  }
}
