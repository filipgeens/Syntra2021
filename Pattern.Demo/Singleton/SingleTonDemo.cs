using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.Demo.Singleton {
  public class SingletonDemo {
    static SingletonDemo _myself = null;

    public int Counter { get; private set; } = 0;
    private SingletonDemo() {    }
    public string Talk() => $"Hi, I'm a singleton, pass {Counter++}";
    public static SingletonDemo Instance {
      get {
        _myself ??= new SingletonDemo();
        return _myself;
      }
    }
  }

  public class SingletonDemoAsync {
    static Lazy<SingletonDemoAsync> _myself = new Lazy<SingletonDemoAsync>(() => new SingletonDemoAsync());

    public int Counter { get; private set; } = 0;
    private SingletonDemoAsync() { }
    public string Talk() => $"Hi, I'm a singleton, pass {Counter++}";
    public static SingletonDemoAsync Instance { get => _myself.Value; }
  }

}
