using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boek.Data.Db {
  public class BoekDbSqlServer :BoekDb {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseSqlServer("");
      base.OnConfiguring(optionsBuilder);
    }
  }
}
