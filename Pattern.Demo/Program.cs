using Syntra.Shared.CLI;
using System;

namespace Pattern.Demo {
  class Program {
    static void Main(string[] args) {
      CLIBase cli = new CLIBase();
      cli.Plugins.AddRange(typeof(Program).FindPlugins());
      cli.Run();
    }
  }
}
