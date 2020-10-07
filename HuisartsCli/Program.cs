using Huisarts.Database;
using HuisartsCli.Models;
using System;

namespace HuisartsCli {
  class Program {
    static void Main(string[] args) {
      HuisartsDbContext ctx = new HuisartsDbContext();
      if (ctx.Database.EnsureCreated()) {
        Gemeente Niels = new Gemeente { Postnummer = "8593", GemeenteNaam = "Nielsstad" };
        ctx.GemeenteSet.Add(Niels);
        Adres Adr = new Adres() { Gemeente = Niels, StraatNaam = "Sesamstraat", HuisNummer = "1" };
        ctx.AdresSet.Add(Adr);
        Persoon David = new Persoon() { VoorNaam = "David", AchterNaam = "Davidsen", Adres = Adr, GeboorteDatum = new DateTime(1900, 12, 6) };
        ctx.PersoonSet.Add(David);
        ctx.SaveChanges();
      }
    }
  }
}
