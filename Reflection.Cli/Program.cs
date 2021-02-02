using Syntra.Shared.CLI;
using System;
using System.IO;

namespace Reflection.Cli {
  class Program {
    static void Main(string[] args) {
      CLIBase cli = new CLIBase();
      cli.Plugins.AddRange(DynamicPlugis.FindAll(@"CliDemo\Plugins"));
      cli.Run(args);
    }
  }
}
