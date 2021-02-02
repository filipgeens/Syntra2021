using Syntra.Shared.CLI;
using System;

namespace CliPlugin.Schelder {
  public class ScheldUit : ICliPlugin {
    public string Name { get=>"Ik maak u uit voor het vuil van de straat"; }

    public bool Execute(CLIBase parent, CliCommand Input) {
      string res = null;
      switch (Input.Command) {
        case "scheld":
          if (Input.Count > 0) {
            res = $"{Input[0]} is een dik varken, een onozelaar en een lapzwans!";
          } else res = "Pipo, kieken, varken en alles wat lelijk is";
          break;
        default:
          return false;
      }
      if (res?.Length > 0) {
        parent.ShowInColor(res, ConsoleColor.DarkRed, ConsoleColor.Green);
        return true;
      }
      return false;
    }

    public void ShowHelp() {

    }
  }
}
