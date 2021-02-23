using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.Demo.FactoryDemo.Tranports {
  public class Taxi : ITransport {
    public string Name { get => "Taxi"; }
    public int Passengers { get; set; }
    public int MaxPassengers { get=> 4; }
    public int MaxDistance { get =>250; }
    public int PriceIndication { get=> 100; }
  }
}
