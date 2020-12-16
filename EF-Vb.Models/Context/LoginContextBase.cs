using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Vb.Models.Context {
  public class LoginContextBase :DbContext{
    public DbSet<Groep> Groepen { get; set; }
    public DbSet<Login> Logins { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<Groep>().HasData(new Groep() { Id = 1, Naam = "Default", Opmerkingen = "" });
      base.OnModelCreating(modelBuilder);
    }
  }
}
