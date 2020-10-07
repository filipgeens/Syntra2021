using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HuisartsCli.Models {
  public class Adres {
    public int ID { get; set; }
    [Required]
    public string StraatNaam { get; set; }
    [Required]
    public string HuisNummer { get; set; }
    [MaxLength(6)]
    public string Busnummer { get; set; }
    public Gemeente Gemeente { get; set; }
    public int GemeenteID { get; set; }
  }
}
