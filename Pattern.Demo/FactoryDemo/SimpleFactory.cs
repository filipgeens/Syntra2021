using Pattern.Demo.FactoryDemo.Tranports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern.Demo.FactoryDemo {
  public class SimpleTransportFactory :ITransportFactory{
    public IList<ITransport> Transports { get; } = new List<ITransport>();
    public SimpleTransportFactory() {
      Init();
    }
    public ITransport SelectBest(int nPassengers, int distance) {
      return Transports.Where(t => t.MaxPassengers >= nPassengers && distance <= t.MaxDistance).OrderBy(o => o.PriceIndication).ThenBy(o => o.MaxDistance).FirstOrDefault();    
    }
    protected virtual void Init() {
      Transports.Add(new PrivateJet());
      Transports.Add(new Taxi());
      Transports.Add(new Bus());
    }
  }
}
