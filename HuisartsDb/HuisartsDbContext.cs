using HuisartsCli.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Huisarts.Database {
  public class HuisartsDbContext :DbContext{
    public DbSet<Gemeente> GemeenteSet { get; set; }
    public DbSet<Adres> AdresSet { get; set; }
    public DbSet<Persoon> PersoonSet { get; set; }
    public HuisartsDbContext() {    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      string dbPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Trim('\\')}\huisarts";
      if (!Directory.Exists(dbPath)) { Directory.CreateDirectory(dbPath); }
      optionsBuilder.UseSqlite($@"Data source={dbPath}\demo.db");
      base.OnConfiguring(optionsBuilder);
    }
  }
}
