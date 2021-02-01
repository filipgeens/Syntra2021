using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Logic.Database;
using Transfer.Logic.Model;
using Transfer.Tests.Data;
using Xunit;

namespace Transfer.Tests {
  public class CountryDbShould {
    [Theory]
    [MemberData(nameof(CountrySeedObject.Seed),MemberType = typeof(CountrySeedObject))]
    public void AddCountriesTest(string code, string countryName) {
      var options = new DbContextOptionsBuilder<TransferContext>().UseSqlite("Data Source =:memory:").Options;
      using (TransferContext ctx = new TransferContext(options)) {
        ctx.Database.OpenConnection();
        ctx.Database.EnsureCreated();
        ctx.Countries.Add(new Country() { Code = code, Naam = countryName });
        ctx.SaveChanges();
        int itemCount = ctx.Countries.Count();
        Assert.True(ctx.Countries.Where(t => t.Code == code).Any());
      }   
    }


  }
}
