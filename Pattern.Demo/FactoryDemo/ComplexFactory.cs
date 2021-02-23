using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Pattern.Demo.FactoryDemo {
  public class ComplexFactory : SimpleTransportFactory {
    protected override void Init() {
      ITransport[] res = Assembly.GetCallingAssembly().GetTypes().Where(t => !t.IsInterface && typeof(ITransport).IsAssignableFrom(t)).Select(s => Activator.CreateInstance(s) as ITransport).ToArray();
      ((List<ITransport>)this.Transports).AddRange(res);
    }
  }
}
