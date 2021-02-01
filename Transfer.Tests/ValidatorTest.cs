using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Logic.Interfaces;
using Transfer.Logic.Model;
using Moq;
using Xunit;

namespace Transfer.Tests {
  public class ValidatorTest {
    [Fact]
    public void HasValidatorOwnerTest() {
      TransferClient client = new TransferClient();
      Mock<IAccountValidator> moqValidator = new Mock<IAccountValidator>();
      client.Validator = moqValidator.Object;
      moqValidator.Setup(x => x.Owner).Returns(client);
      Assert.NotNull(client.Validator?.Owner);
    }
    [Fact]
    public void IsValidTest() {
      TransferClient client = new TransferClient();
      Mock<IAccountValidator> moqValidator = new Mock<IAccountValidator>();
      client.Validator = moqValidator.Object;
      moqValidator.Setup(x => x.IsValid()).Returns(true);
      Assert.True(client.IsValid());
    }
    [Theory]
    [InlineData("BE012.345678.90123",true)]
    [InlineData("BE012345678.90123",true)]
    [InlineData("BE01234567890123",true)]
    [InlineData("BE01234567", false)]
    public void IsValidIban(string iban,bool result) {
      Mock<IAccountValidator> moqValidator = new Mock<IAccountValidator>();
      moqValidator.Setup(x => x.ValideerRekening(It.IsRegex(@"^BE[\d\.]{14,17}$"))).Returns(true);
      Assert.True(moqValidator.Object.ValideerRekening(iban)==result);
    }
  }
}
