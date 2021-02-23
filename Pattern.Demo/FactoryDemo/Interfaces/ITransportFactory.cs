using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.Demo.FactoryDemo {
  public interface ITransportFactory {
    IList<ITransport> Transports { get; } 
    ITransport SelectBest(int nPassengers, int distance);
  }
}
