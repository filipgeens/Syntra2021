using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Logic.Interfaces {
  public interface IAccountValidator {
    ITransferClient Owner { get; set; }
    bool ValideerRekening(string nr);
    bool IsValid();
  }
}
