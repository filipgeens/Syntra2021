using System;
using System.Collections.Generic;
using System.Text;

namespace Syntra.Shared.CLI {
	public interface ICliPlugin {
		string Name { get; }
		bool Execute(CLIBase parent, CliCommand Input);
		void ShowHelp();
	}
}
