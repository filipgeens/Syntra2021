using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Logic.Model;

namespace Transfer.Logic.Database {
  public class TransferContext : DbContext{
    public DbSet<Country> Countries { get; set; }
    public DbSet<TransferClient> TransferClients { get; set; }
    public DbSet<TransferModel> TransferModels { get; set; }
    public TransferContext() {    }
    public TransferContext(DbContextOptions<TransferContext> options):base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);
    }

  }
}
