using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Boek.Data.Models {
  public class Taal {
    [Key]
    [StringLength(5)]
    public string Key { get; set; }
    [Required]
    public string Naam { get; set; }
  }
}
