using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.Demo.FactoryDemo.Tranports {
  public class Bus : ITransport {
    public string Name { get => "Bus"; }
    public int Passengers { get; set; }
    public int MaxPassengers { get => 50; }
    public int MaxDistance { get => 1000; }
    public int PriceIndication { get => 400; }
  }
}
