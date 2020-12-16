using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Vb.Models.Context {
  public class LoginSqlServerContext : LoginContextBase {

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseSqlServer("Data Source=FG-DELL;Initial Catalog=EF-Login;Integrated Security=True");
      base.OnConfiguring(optionsBuilder);
    }
  }
}
