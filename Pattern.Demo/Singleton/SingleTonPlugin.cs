using Syntra.Shared.CLI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.Demo.Singleton {
  public class SingleTonPlugin : ICliPlugin {
    public string Name { get; }
    public bool Execute(CLIBase parent, CliCommand Input) {
      switch (Input.Command) {
        case "singleton":
          Console.WriteLine(SingletonDemo.Instance.Talk());
          return true;
      }
      return false;
    }

    public void ShowHelp() => Console.WriteLine("Oei");
  }
  }
