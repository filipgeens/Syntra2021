using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF_Vb.Models {
  public class Groep {
    public int Id { get; set; }
    [Required]
    public string Naam { get; set; }
    public string Opmerkingen { get; set; }
    public List<Login> Leden { get; set; } = new List<Login>();

  }
}
