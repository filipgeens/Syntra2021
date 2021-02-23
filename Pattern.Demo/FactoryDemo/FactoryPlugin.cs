using Pattern.Demo.FactoryDemo;
using Syntra.Shared.CLI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.Demo {
  public class FactoryPlugin : ICliPlugin {
    public string Name { get; }

    public bool Execute(CLIBase parent, CliCommand Input) {
      switch (Input.Command) {
        case "transport":
          if (Input.Count > 1) {
            if (int.TryParse(Input[0], out int nPassengers) && int.TryParse(Input[1], out int distance)) {
              ITransportFactory f = new ComplexFactory();
              Console.WriteLine(f.SelectBest(nPassengers, distance)?.Name ?? "No transport");
              return true;
            }
          }
          break;      
      }
      return false;

    }

    public void ShowHelp() => Console.WriteLine("Help!");
  }
}
