using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.Demo.FactoryDemo.Tranports {
  public class PrivateJet : ITransport {
    public string Name { get => "GulfStream"; }
    public int Passengers { get; set; }
    public int MaxPassengers { get => 12; }
    public int MaxDistance { get => 6500; }
    public int PriceIndication { get => 10000; }
  } 
}
