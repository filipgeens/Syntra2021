using Syntra.Shared.CLI;
using System;

namespace CliPlugin.Converter {
  public class ConvertPlugin : ICliPlugin {
    const double ConvertBase = 2.54;
    public string Name { get => "English - Metric converter"; }

    public bool Execute(CLIBase parent, CliCommand Input) {
      if (Input.Count > 0 && double.TryParse(Input[0],out double baseNumber)) {
        double res=0;
        switch (Input.Command) {
          case "tocm":
            res=baseNumber / ConvertBase;
            break;
          case "toinch":
            res = baseNumber * ConvertBase;
            break;
          default:
            return false;
        }
        parent.Show($"The result is {res}");
        return true;
      }
      return false;
    }

    public void ShowHelp() {
      Console.WriteLine("help :-)");
    }
  }
}
