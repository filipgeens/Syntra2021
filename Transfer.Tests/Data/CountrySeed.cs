using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Tests.Data {
  public class CountrySeedObject {
    public static IEnumerable<object[]> Seed {
      get {
        List<object[]> seed = new List<object[]>();
        seed.Add(new object[] {"BE", "België" });
        seed.Add(new object[] {"NL", "Nederland" });
        seed.Add(new object[] {"FR", "Frankrijk" });
        seed.Add(new object[] {"FR", "Frankrijk" });
        seed.Add(new object[] {"BE", "België" });
        return seed.ToArray();
      }
    }
  }
}
