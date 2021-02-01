using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Logic.Interfaces;

namespace Transfer.Logic.Model {
  [Index(nameof(Code),IsUnique = true)]
  public class Country :IModelBase {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Code { get; set; }
    [Required]
    public string Naam { get; set; }
  }
}
