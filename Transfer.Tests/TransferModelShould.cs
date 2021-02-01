using System;
using Transfer.Logic.Model;
using Xunit;

namespace Transfer.Tests {
  [Trait("Category","Models")]
  public class TransferModelShould {
    [Fact]
    public void TransferStandardDateTest() {
      TransferModel model = new TransferModel();
      Assert.True(model.CreatieDatum.ToShortDateString()==DateTime.Now.ToShortDateString());
    }
  }
}
