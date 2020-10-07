using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HuisartsCli.Models {
  public class Persoon {
    public int ID { get; set; }
    [Required]
    public string VoorNaam { get; set; }
    [Required]
    public string AchterNaam { get; set; }
    public DateTime GeboorteDatum { get; set; }
    public Adres Adres { get; set; }
    public int AdresID { get; set; }
  }
}
