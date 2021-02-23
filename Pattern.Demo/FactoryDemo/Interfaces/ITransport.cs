using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.Demo.FactoryDemo {
  public interface ITransport {
    string Name { get; }
    int Passengers { get; set; }
    int MaxPassengers { get; }
    int MaxDistance { get; }
    int PriceIndication { get; }
  }
}
