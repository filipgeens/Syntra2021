using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.Demo.FactoryDemo.Tranports {
  public class TukTuk : ITransport {
    public string Name { get => "TukTuk"; }
    public int Passengers { get; set; }
    public int MaxPassengers { get => 2; }
    public int MaxDistance { get => 20; }
    public int PriceIndication { get => 1; }
  }
}
