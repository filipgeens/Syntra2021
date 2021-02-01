using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Logic.Interfaces {
  public interface ITransferClient : IModelBase {
    public string RekeningNummer { get; set; }
    public string LandCode { get;  }

  }
}
