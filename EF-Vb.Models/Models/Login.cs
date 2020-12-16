using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EF_Vb.Models {
  public class Login {
    public int Id { get; set; }
    [Required]
    public string LoginNaam { get; set; }
    [Required]
    public string Paswoord { get; set; }
    public string Opmerkingen { get; set; }
    public List<Groep> LidVan { get; set; } = new List<Groep>();


  }
}
