using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HuisartsCli.Models {
  public class Gemeente {
    public int ID { get; set; }
    [Required]
    public string Postnummer { get; set; }
    [Required]
    public string GemeenteNaam { get; set; }
  }
}
